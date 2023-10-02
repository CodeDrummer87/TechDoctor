using Data;
using Data.Interfaces;
using OxyPlot;
using Presentation.Forms;
using Presentation.Properties;

namespace Presentation.View
{
    public partial class ResistancePlotForm : Form
    {
        MainPage _mainPage;
        IUnitOfWork _unitOfWork;
        private AllMeasurementsFromLocoForm _allMeasuringsDataForm;
        int iFormX, iFormY, iMouseX, iMouseY;

        public ResistancePlotForm(AllMeasurementsFromLocoForm allMeasuringsDataForm, MainPage mainPage, PlotModel model, string locoSeriesNumber)
        {
            InitializeComponent();

            _unitOfWork = new UnitOfWork();
            _allMeasuringsDataForm = allMeasuringsDataForm;
            _mainPage = mainPage;
            formHeader.Text = $"Локомотив {locoSeriesNumber}";
            toolTip.SetToolTip(backToListBox, $"Закрыть и вернуться к измерениям на {locoSeriesNumber}");

            tips.Text = "1. Масштабирование оси производится вращением колёсика мыши при наведённом указателе на данную ось.\n" +
                "2. Масштабирование всего графика производится вращением колёсика мыши при наведённом указателе на график.\n" +
                "3. Перемещение графика производится перемещением указателя мыши при зажатой правой кнопке мыши на графике.\n" +
                "4. Для просмотра координат точки на графике, навести указатель на график и нажать левую кнопку мыши.";

            plot.Model = model;
            plot.Text = formHeader.Text;
            ToggleThemeMode();
        }



        #region Interface

        private void Logo_Click(object sender, EventArgs e)
            => _allMeasuringsDataForm.NpcptLinkLabelClicked(sender, e);

        private void BackToMeasuringsPage_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainPage.ToggleThemeMode();
            _allMeasuringsDataForm.ToggleThemeMode();
            _allMeasuringsDataForm.Show();
            plot.Model = null;

            this.Dispose();
        }

        private void CollapseApplication(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void QuitAppBox_Click(object sender, EventArgs e) => _mainPage.QuitApplication(sender, e);

        private void ThemeSwitcher_Click(object? sender, EventArgs e)
        {
            _mainPage.isNight = !_mainPage.isNight;
            _unitOfWork.SetThemeValue(_mainPage.isNight);
            _unitOfWork.Save();
            ToggleThemeMode();
        }

        private void ResetModelButton_Click(object? sender, EventArgs e)
        {
            plot.Model.ResetAllAxes();
            plot.Refresh();
        }

        #endregion


        #region Design

        private void BackToMeasuringsPage_MouseEnter(object sender, EventArgs e)
        {
            backToListBox.Image = _mainPage.isNight ? Resources.back_dark : Resources.back_light;
        }

        private void BackToMeasuringsPage_MouseLeave(object sender, EventArgs e)
        {
            backToListBox.Image = _mainPage.isNight ? Resources.back_light : Resources.back_dark;
        }

        private void CollapseAppBox_MouseEneter(object sender, EventArgs e)
        {
            collapseAppBox.Image = Resources.collapse_hover;
        }

        private void CollapseAppBox_MouseLeave(object sender, EventArgs e)
        {
            collapseAppBox.Image = _mainPage.isNight ? Resources.collapse_dark : Resources.collapse;
        }

        private void QuitAppBox_MouseEnter(object sender, EventArgs e)
        {
            quitAppButton.Image = Resources.quit_hover;
        }

        private void QuitAppBox_MouseLeave(object sender, EventArgs e)
        {
            quitAppButton.Image = _mainPage.isNight ? Resources.quit_dark : Resources.quit;
        }

        private void ThemeSwitcher_MouseEnter(object? sender, EventArgs e)
        {
            themeSwitcher.Image = _mainPage.isNight ? Resources.light_theme_hover : Resources.dark_theme_hover;
        }

        private void ThemeSwith_MouseLeave(object? sender, EventArgs e)
        {
            themeSwitcher.Image = _mainPage.isNight ? Resources.light_theme_dark : Resources.dark_theme;
        }

        private void ResetModelButton_MouseEnter(object? sender, EventArgs e)
        {
            resetModelButton.ForeColor = Color.Black;
            resetModelButton.BackColor = SystemColors.ButtonFace;
        }

        private void ResetModelButton_MouseLeave(object? sender, EventArgs e)
        {
            resetModelButton.ForeColor = _mainPage.isNight ? SystemColors.ButtonFace : Color.SlateGray;
            resetModelButton.BackColor = _mainPage.isNight ? Color.DimGray : SystemColors.GradientInactiveCaption;
        }

        private void ToggleThemeMode()
        {
            Opacity = _mainPage.isNight ? 0.95F : 1.0F;
            BackColor = _mainPage.isNight ? SystemColors.Desktop : SystemColors.GradientActiveCaption;
            logoBox.Image = _mainPage.isNight ? Resources.logo_dark : Resources.logo;
            plot.BackColor = _mainPage.isNight ? Color.DimGray : SystemColors.GradientInactiveCaption;
            plot.Model.TextColor = _mainPage.isNight ? OxyColor.FromRgb(243, 254, 255) : OxyColor.FromRgb(40, 90, 0);
            resetModelButton.ForeColor = _mainPage.isNight ? SystemColors.ButtonFace : Color.SlateGray;
            resetModelButton.BackColor = _mainPage.isNight ? Color.DimGray : SystemColors.GradientInactiveCaption;

            backToListBox.Image = _mainPage.isNight ? Resources.back_light : Resources.back_dark;
            themeSwitcher.Image = _mainPage.isNight ? Resources.light_theme_dark : Resources.dark_theme;
            collapseAppBox.Image = _mainPage.isNight ? Resources.collapse_dark : Resources.collapse;
            quitAppButton.Image = _mainPage.isNight ? Resources.quit_dark : Resources.quit;

            string tipMessage = _mainPage.isNight ? "Переключить на дневной режим" : "Переключить на ночной режим";
            toolTip.SetToolTip(themeSwitcher, tipMessage);

            formHeader.ForeColor = _mainPage.isNight ? Color.AliceBlue : Color.DarkSlateGray;
            tips.ForeColor = _mainPage.isNight ? Color.SkyBlue : Color.SteelBlue;
        }

        #endregion
    }
}
