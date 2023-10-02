using Data;
using Data.Interfaces;
using Domain.EmployeeData;

namespace Presentation.View
{
    public partial class EmployeeForm : Form
    {
        private EmployeeSettingsForm _empSettingsForm;
        private bool isNight;
        private IUnitOfWork _unitOfWork;
        private bool _isEnteredDataValid;
        private string selectedPost = string.Empty;

        private Employee _employee;
        private Person _person;
        private Post _post;

        public EmployeeForm(EmployeeSettingsForm empSettingsForm, bool isNight)
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork();
            _empSettingsForm = empSettingsForm;
            _isEnteredDataValid = true;

            SetPostListToComboBox();
            this.isNight = isNight;
            ToggleThemeMode();
        }

        public EmployeeForm(EmployeeSettingsForm empSettingsForm, bool isNight, int employeeId) : this(empSettingsForm, isNight)
        {
            _employee = _unitOfWork.Employees.Get(employeeId);
            _person = _unitOfWork.Persons.Get((int)_employee.PersonId!);
            _post = _unitOfWork.Posts.Get((int)_employee.PostId!);
            selectedPost = _post.Name!;

            string title = "Редактирование данных сотрудника";
            this.Text = title;
            panel.Text = title;

            lastnameTextBox.Text = _person.Lastname;
            firstnameTextBox.Text = _person.Firstname;
            surnameTextBox.Text = _person.Surname;
            personnelNumberTextBox.Text = _employee.PersonnelNumber;
            personnelNumberTextBox.Enabled = false;
            employeeRelevance.Checked = _employee.IsActive == 1 ? true : false;
            saveButton.Text = "Изменить";

            saveButton.Enabled = true;
            matchNotify.Visible = false;

            SetPostListToComboBox();
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

            foreach (var control in panel.Controls)
            {
                if (control is Label label)
                {
                    if (label.Name.Contains("Button"))
                    {
                        label.ForeColor = isNight ? Color.AliceBlue : Color.Wheat;
                    }
                    else if (!label.Name.Contains("Notify"))
                    {
                        label.ForeColor = isNight ? Color.AliceBlue : Color.DarkSlateGray;
                    }
                    else
                        label.ForeColor = isNight ? Color.Orange : Color.Red;
                }

                if (control is TextBox textBox)
                {
                    textBox.BackColor = isNight ? SystemColors.ScrollBar : SystemColors.Window;
                }
            }
        }

        #endregion



        #region Interface

        private void CancelButton_Click(object sender, EventArgs e) => CloseForm();

        private void ChangeCheckBox(object sender, EventArgs e) => SetPostListToComboBox();

        private void CheckKeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)   // ASCII: 8 = Backspace
            {
                e.Handled = true;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_isEnteredDataValid)
            {
                string statusMessage = SaveEmployee();
                bool isSuccess = statusMessage == string.Empty ? false : true;
                statusMessage = isSuccess ? statusMessage : "Ошибка: не выбрана должность сотрудника";
                _empSettingsForm.GetEmployeeData();
                _empSettingsForm.DisplayCurrentMessage(statusMessage, isSuccess);
            }
            else
                _empSettingsForm.DisplayCurrentMessage("Ошибка: некорректные данные для сохранения сотрудника", false);

            CloseForm();
        }

        private void PostComboBox_SelectedIndexChanged(object sender, EventArgs e) => ValidateEnteredData(sender, e);

        #endregion


        private void CloseForm()
        {
            _empSettingsForm.Opacity = 1;
            _empSettingsForm.Enabled = true;
            this.Close();
            this.Dispose();
        }

        private List<Post> GetCurrentPostList()
        {
            byte relevance = employeeRelevance.Checked ? (byte)1 : (byte)0;
            return _unitOfWork.Posts.GetAll(relevance).ToList();
        }

        public void SetPostListToComboBox()
        {

            postComboBox.Items.Clear();
            postComboBox.ResetText();

            List<Post> posts = GetCurrentPostList();
            int selectedIndex = 0;
            for (int i = 0; i < posts.Count; i++)
            {
                postComboBox.Items.Add(posts[i]);
                if (selectedPost.Equals(posts[i].Name))
                    selectedIndex = i;
            }

            postComboBox.DisplayMember = "Name";
            if (posts.Count > 0)
                postComboBox.SelectedIndex = posts.Count > 1 ?
                    selectedPost != string.Empty ? selectedIndex : 1 : 0;

            CheckSelectedPost();
        }

        private string SaveEmployee()
        {
            if (saveButton.Text.Equals("Сохранить"))
                return CreateNewEmployee();

            return EditSelectedEmployee();
        }

        private void ValidateEnteredData(object sender, EventArgs e)
        {
            _isEnteredDataValid = true;
            foreach (var control in panel.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (textBox.Text.Trim() == string.Empty)
                    {
                        _isEnteredDataValid = false;
                        if (textBox.Name.Equals("personnelNumberTextBox"))
                            emptyPersonnelNumberNotify.Visible = true;
                        break;
                    }
                    else
                    {
                        if (textBox.Name.Equals("personnelNumberTextBox"))
                        {
                            emptyPersonnelNumberNotify.Visible = false;
                            if (saveButton.Text.Equals("Сохранить"))
                            {
                                Employee employee = _unitOfWork.Employees.GetByPersonnelNumber(textBox.Text);
                                matchNotify.Visible = employee != null ? true : false;
                                _isEnteredDataValid = employee != null ? false : true;
                            }
                        }
                    }
                }
            }

            saveButton.Enabled = _isEnteredDataValid;
            CheckSelectedPost();
        }

        private string CreateNewEmployee()
        {
            _employee = new Employee();
            int index = postComboBox.SelectedIndex;
            if (postComboBox.Items[index] is Post post)
            {
                _employee.PostId = post.Id;

                _person = new Person()
                {
                    Lastname = lastnameTextBox.Text,
                    Firstname = firstnameTextBox.Text,
                    Surname = surnameTextBox.Text,
                };

                _unitOfWork.Persons.Create(_person);
                _unitOfWork.Save();

                _employee.PersonId = _person.Id;
                _employee.PersonnelNumber = personnelNumberTextBox.Text;
                _employee.IsActive = employeeRelevance.Checked ? (byte)1 : (byte)0;

                _unitOfWork.Employees.Create(_employee);
                _unitOfWork.Save();

                string employeeFullName = $"{_person.Lastname} {_person.Firstname[0]}.{_person.Surname[0]}.";
                return $"{employeeFullName} (таб.N {_employee.PersonnelNumber}) добавлен в список сотрудников";
            }

            return string.Empty;
        }

        private string EditSelectedEmployee()
        {
            int index = postComboBox.SelectedIndex;
            if (postComboBox.Items[index] is Post post)
            {
                _person.Lastname = lastnameTextBox.Text;
                _person.Firstname = firstnameTextBox.Text;
                _person.Surname = surnameTextBox.Text;

                _unitOfWork.Persons.Update(_person);

                _employee.PostId = post.Id;
                _employee.IsActive = employeeRelevance.Checked ? (byte)1 : (byte)0;

                _unitOfWork.Employees.Update(_employee);
                _unitOfWork.Save();

                string employeeFullName = $"{_person.Lastname} {_person.Firstname[0]}.{_person.Surname[0]}.";
                return $"Данные сотрудника {employeeFullName} (таб.N {_employee.PersonnelNumber}) изменены";
            }

            return string.Empty;
        }

        private void CheckSelectedPost()
        {
            if (_isEnteredDataValid && employeeRelevance.Checked)
            {
                _isEnteredDataValid = postComboBox.SelectedIndex != 0;
                incorrectPostNotify.Visible = postComboBox.SelectedIndex == 0;
                saveButton.Enabled = postComboBox.SelectedIndex != 0;
            }
        }
    }
}
