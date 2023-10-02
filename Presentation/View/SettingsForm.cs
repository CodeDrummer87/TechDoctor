using Presentation.Forms;
using Presentation.Properties;

namespace Presentation.View
{
    public partial class SettingsForm : Form
    {
        private MainPage _mainPage;

        int iFormX, iFormY, iMouseX, iMouseY;

        public SettingsForm(MainPage mainPage)
        {
            InitializeComponent();

            _mainPage = mainPage;
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
        }

        #endregion


        #region Interface

        private void BackButton_Click(object? sender, EventArgs e)
        {
            this.Hide();
            _mainPage.Show();
            this.Dispose();
        }

        private void DisplayEmployees_Click(object sender, EventArgs e)
        {
            EmployeeSettingsForm employeesForm = new EmployeeSettingsForm(_mainPage, this);
            this.Hide();
            employeesForm.Show();
        }

        private void CompanySettings_Click(object? sender, EventArgs e)
        {
            CompanyForm companyForm = new(this, _mainPage);
            this.Hide();
            companyForm.Show();
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

        private void ReconnectToDeviceButton_Click(object? sender, EventArgs e) => _mainPage.ConnectToDevice(true);

        #endregion
    }
}
