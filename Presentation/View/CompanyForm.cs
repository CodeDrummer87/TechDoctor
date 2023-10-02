using Data;
using Data.Interfaces;
using Domain;
using Presentation.Forms;
using Presentation.Properties;

namespace Presentation.View
{
    public partial class CompanyForm : Form
    {
        private SettingsForm _settingsForm;
        private MainPage _mainPage;
        IUnitOfWork _unitOfWork;

        int iFormX, iFormY, iMouseX, iMouseY;

        private System.Windows.Forms.Timer timer;
        int timePeriod;

        public CompanyForm(SettingsForm settingsForm, MainPage mainPage)
        {
            InitializeComponent();
            _settingsForm = settingsForm;
            _mainPage = mainPage;
            _unitOfWork = new UnitOfWork();

            timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timePeriod = 3;
            timer.Tick += TimerTick;

            string aboutCompany = "О компании";
            if (_mainPage.company is not null && !_mainPage.company.Name!.Equals(string.Empty))
                aboutCompany = _mainPage.company.Name!;

            headerLabel.Text = aboutCompany;

            ToggleThemeMode();
        }


        #region Design

        public void HoverLabel(Label label, bool isHover)
        {
            label.ForeColor = isHover ? Color.WhiteSmoke : _mainPage.isNight ? Color.AliceBlue : Color.Wheat;
            label.BackColor = isHover ? Color.SteelBlue : Color.DarkSlateGray;
        }

        public void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label label)
                this.HoverLabel(label, true);
        }

        public void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label)
                this.HoverLabel(label, false);
        }

        private void BackButton_MouseEnter(object? sender, EventArgs e)
        {
            backButtonBox.Image = _mainPage.isNight ? Resources.back_dark : Resources.back_light;
        }

        private void BackButton_MouseLeave(object? sender, EventArgs e)
        {
            backButtonBox.Image = _mainPage.isNight ? Resources.back_light : Resources.back_dark;
        }

        public void ToggleThemeMode()
        {
            BackColor = _mainPage.isNight ? SystemColors.Desktop : SystemColors.GradientActiveCaption;
            panel.BackColor = _mainPage.isNight ? Color.DimGray : SystemColors.GradientInactiveCaption;
            panel.ForeColor = _mainPage.isNight ? Color.AliceBlue : Color.DarkSlateGray;

            backButtonBox.Image = _mainPage.isNight ? Resources.back_light : Resources.back_dark;
            headerLabel.ForeColor = _mainPage.isNight ? Color.AliceBlue : Color.DarkSlateGray;
            logoUploadBox.Image = _mainPage.isNight ? Resources.logo_upload_night : Resources.logo_upload_light;
            companyTitleTextBox.BackColor = _mainPage.isNight ? SystemColors.ScrollBar : SystemColors.Window;
        }

        #endregion



        #region Interface

        private void CompanyForm_Load(object sender, EventArgs e)
        {
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\NPC";
            if (Directory.Exists(directory))
            {
                string[] files = Directory.GetFiles(directory, "company_logo.*");
                if (files.Length > 0)
                {
                    FileInfo fileForLoad = new(files[0]);
                    string tempFile = directory + @"\_" + fileForLoad.Name;
                    File.Copy(files[0], tempFile, true);

                    logoUploadBox.Image = new Bitmap(tempFile);
                }
            }
        }

        private void BackButton_Click(object? sender, EventArgs e)
        {
            this.Hide();
            _settingsForm.Show();
            this.Dispose();
        }

        private void ThisForm_MouseDown(object sender, MouseEventArgs e)
        {
            iFormX = this.Location.X;
            iFormY = this.Location.Y;
            iMouseX = MousePosition.X;
            iMouseY = MousePosition.Y;
        }

        private void ThisForm_MouseMove(object sender, MouseEventArgs e)
        {
            int iMouseX2 = MousePosition.X;
            int iMouseY2 = MousePosition.Y;
            if (e.Button == MouseButtons.Left)
                this.Location = new Point(iFormX + (iMouseX2 - iMouseX), iFormY + (iMouseY2 - iMouseY));
        }

        private void SaveCompanyTitle_Click(object? sender, EventArgs e)
        {
            string companyTitle = companyTitleTextBox.Text.Trim();
            if (!companyTitle.Equals(string.Empty))
            {
                if (companyTitle.Length > 2)
                {
                    Company company = new Company { Id = 1, Name = companyTitle };

                    if (_mainPage.company == null)
                        _unitOfWork.Companies.Create(company);
                    else
                        _unitOfWork.Companies.Update(company);

                    _unitOfWork.Save();
                    _mainPage.company = company;

                    headerLabel.Text = companyTitle;
                    saveButton.Enabled = false;

                    DisplayCurrentMessage("Наименование предприятия сохранено", true);
                }
                else
                    DisplayCurrentMessage("Слишком короткое наименование", false);
            }
            else
                DisplayCurrentMessage("Введите наименование предприятия", false);
        }

        private void UploadLogo_Click(object? sender, EventArgs e)
        {
            OpenFileDialog fDialog = new();

            fDialog.Title = "Логотип компании";
            fDialog.Filter = "Файлы изображений(*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";

            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    logoUploadBox.Image = _mainPage.isNight ? Resources.logo_upload_night : Resources.logo_upload_light;
                    logoUploadBox.Image = new Bitmap(fDialog.FileName);
                    string sourcePath = fDialog.FileName;

                    FileInfo logo = new FileInfo(sourcePath);
                    string extension = logo.Extension;
                    string destinationPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                        @$"\NPC\company_logo{extension}";

                    logo.CopyTo(destinationPath, true);
                    DisplayCurrentMessage("Логотип успешно сохранён", true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Невозможно загрузить файл: {ex.Message}",
                        "Ошибка загрузки логотипа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion


        private void DisplayCurrentMessage(string message, bool isSuccess)
        {
            currentMessage.Text = message;
            currentMessage.ForeColor = isSuccess ? _mainPage.isNight ? Color.GreenYellow : Color.OliveDrab
                : _mainPage.isNight ? Color.Orange : Color.IndianRed;

            if (timePeriod < 3)
                timePeriod = 3;

            timer.Start();
        }

        private void TimerTick(object? sender, EventArgs e)
        {
            timePeriod--;

            if (timePeriod <= 0)
            {
                timer.Stop();
                timePeriod = 3;
                currentMessage.Text = string.Empty;
                companyTitleTextBox.Text = string.Empty;
            }
        }
    }
}
