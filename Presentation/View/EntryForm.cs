using Data;
using Data.Interfaces;
using Domain;
using Presentation.Properties;

namespace Presentation.Forms
{
    public partial class EntryForm : Form
    {
        IUnitOfWork _unitOfWork;
        bool _isDarkTheme;

        private System.Windows.Forms.Timer timer;
        int timePeriod;

        public Company company;

        public EntryForm()
        {
            InitializeComponent();

            _unitOfWork = new UnitOfWork();
            _isDarkTheme = _unitOfWork.GetThemeValue();
            ToggleThemeMode();
            timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timePeriod = 2;
            timer.Tick += TimerTick;

            company = GetCurrentCompanyId();
        }

        private void TimerTick(object? sender, EventArgs e)
        {
            timePeriod--;

            if (timePeriod <= 0)
            {
                timer.Stop();
                timePeriod = 2;

                this.Hide();
                MainPage mainPage = new(this, _isDarkTheme);
                mainPage.Show();
            }
        }

        private void EntryForm_Load(object sender, EventArgs e) => timer.Start();

        public void ToggleThemeMode()
        {
            Opacity = _isDarkTheme ? 0.94F : 1.0F;
            BackColor = _isDarkTheme ? SystemColors.Desktop : SystemColors.GradientActiveCaption;
            logoBox.Image = _isDarkTheme ? Resources.logo_dark : Resources.logo;
        }

        private Company GetCurrentCompanyId()
        {
            return _unitOfWork.Companies.Get(1);
        }
    }
}
