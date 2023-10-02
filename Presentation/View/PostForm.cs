using Data;
using Data.Interfaces;
using Domain.EmployeeData;

namespace Presentation.View
{
    public partial class PostForm : Form
    {
        private EmployeeSettingsForm _empSettingsForm;
        private bool isNight;
        private readonly IUnitOfWork _unitOfWork;

        private Post _post;

        public PostForm(EmployeeSettingsForm empSettingsForm, bool isNight)
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
            _empSettingsForm = empSettingsForm;
            TopMost = true;
            this.isNight = isNight;
            ToggleThemeMode();
        }

        public PostForm(EmployeeSettingsForm empSettingsForm, bool isNight, Post post) : this(empSettingsForm, isNight)
        {
            _post = post;
            this.Text = $"Редактирование должности \"{post.Name}\"";
            panel.Text = $"Редактирование должности \"{post.Name}\"";
            postNameBox.Text = _post.Name;
            postRelevance.Checked = _post.IsActive == (byte)1 ? true : false;
            savePostButton.Text = "Изменить";
        }



        #region Design

        private void HoverLabel(Label label, bool isHover)
        {
            label.ForeColor = isHover ? Color.WhiteSmoke : (isNight ? Color.AliceBlue : Color.Wheat);
            label.BackColor = isHover ? Color.SteelBlue : Color.DarkSlateGray;
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label label)
                HoverLabel(label, true);
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label)
                HoverLabel(label, false);
        }

        private void ToggleThemeMode()
        {
            BackColor = isNight ? SystemColors.Desktop : SystemColors.GradientActiveCaption;
            Opacity = isNight ? 0.94F : 1.0F;
            panel.BackColor = isNight ? Color.DimGray : SystemColors.GradientInactiveCaption;
            panel.ForeColor = isNight ? Color.AliceBlue : Color.DarkSlateGray;

            postRelevance.ForeColor = isNight ? Color.SkyBlue : Color.DarkSlateGray;
            postNameBox.BackColor = isNight ? SystemColors.ScrollBar : SystemColors.Window;

            foreach (var control in panel.Controls)
                if (control is Label label)
                    label.ForeColor = isNight ? Color.AliceBlue : Color.Wheat;
        }

        #endregion



        #region Interface

        private void CancelButton_Click(object sender, EventArgs e) => CloseForm();

        private void SavePostButton_Click(object sender, EventArgs e)
        {
            if (savePostButton.Text.Equals("Сохранить"))
                CreateNewPost();
            else
                UpdateSelectedPost();
        }

        #endregion



        private void CloseForm()
        {
            _empSettingsForm.Opacity = 1;
            _empSettingsForm.Enabled = true;
            this.Close();
            this.Dispose();
        }

        private void CreateNewPost()
        {
            Post post = new()
            {
                Name = postNameBox.Text.Trim().ToLower(),
                IsActive = postRelevance.Checked ? (byte)1 : (byte)0
            };

            _unitOfWork.Posts.Create(post);
            _unitOfWork.Save();

            postNameBox.Text = string.Empty;
            CloseForm();

            _empSettingsForm.SetPostListToComboBox();
            string postProperty = post.IsActive == (byte)1 ? "действующих" : "нерелевантных";
            _empSettingsForm.DisplayCurrentMessage($"Должность \"{post.Name}\" добавлена в список {postProperty} должностей", true);
        }

        private void UpdateSelectedPost()
        {
            _post.Name = postNameBox.Text;
            _post.IsActive = postRelevance.Checked ? (byte)1 : (byte)0;
            _unitOfWork.Posts.Update(_post);
            _unitOfWork.Save();

            postNameBox.Text = string.Empty;
            CloseForm();

            _empSettingsForm?.SetPostListToComboBox();
            _empSettingsForm?.DisplayCurrentMessage($"Должность \"{_post.Name}\" успешно изменена", true);
        }

        private void FieldText_Changed(object sender, EventArgs e)
        {
            string value = postNameBox.Text.Trim();
            savePostButton.Enabled = (value != String.Empty && value.Length > 3);
        }
    }
}
