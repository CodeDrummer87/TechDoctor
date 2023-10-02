using Data;
using Data.Interfaces;
using Domain;
using Domain.EmployeeData;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Presentation.Forms;
using Presentation.Properties;

namespace Presentation.View
{
    public partial class EmployeeSettingsForm : Form
    {
        private MainPage _mainPage;
        private SettingsForm _settingsForm;
        private IUnitOfWork _unitOfWork;

        private System.Windows.Forms.Timer timer;
        int timePeriod;

        private string _selectedRowNumber = string.Empty;

        private int publishedRecords = 0;
        private int _recordCounter = 0;
        private int _scrollBarHeight = 0;
        private TableLayoutPanel table;

        int iFormX, iFormY, iMouseX, iMouseY;

        public EmployeeSettingsForm(MainPage mainPage, SettingsForm settingsForm)
        {
            InitializeComponent();
            _mainPage = mainPage;
            _settingsForm = settingsForm;
            _unitOfWork = new UnitOfWork();

            timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timePeriod = 5;
            timer.Tick += TimerTick;

            ToggleThemeMode();

            selectCondition.SelectedIndex = 1;
            DisplayConditonField(false);
            GetEmployeeData();
            SetPostListToComboBox();
        }


        #region Design

        private void HoverLabel(Label label, bool isHover)
        {
            label.ForeColor = isHover ? Color.WhiteSmoke : (_mainPage.isNight ? Color.AliceBlue : Color.Wheat);
            label.BackColor = isHover ? Color.SteelBlue : Color.DarkSlateGray;
        }

        private void BackToMatinPage_MouseEnter(object sender, EventArgs e)
        {
            backToListBox.Image = _mainPage.isNight ? Resources.back_dark : Resources.back_light;
        }

        private void BackToMatinPage_MouseLeave(object sender, EventArgs e)
        {
            backToListBox.Image = _mainPage.isNight ? Resources.back_light : Resources.back_dark;
        }

        private void CollapseAppBox_MouseEnter(object sender, EventArgs e)
        {
            collapseAppBox.Image = Resources.collapse_hover;
        }

        private void CollapseAppBox_MouseLeave(object sender, EventArgs e)
        {
            collapseAppBox.Image = _mainPage.isNight ? Resources.collapse_dark : Resources.collapse;
        }

        private void QuitAppButton_MouseEnter(object sender, EventArgs e)
        {
            quitAppButton.Image = Resources.quit_hover;
        }

        private void QuitAppButton_MouseLeave(object sender, EventArgs e)
        {
            quitAppButton.Image = _mainPage.isNight ? Resources.quit_dark : Resources.quit;
        }

        private void RadioButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is RadioButton radioButton)
                Hover_RadioButton(radioButton, true);
        }

        private void RadioButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is RadioButton radioButton)
                Hover_RadioButton(radioButton, false);
        }

        private void Hover_RadioButton(RadioButton radioButton, bool isHover)
        {
            radioButton.ForeColor = isHover ? Color.Honeydew : (_mainPage.isNight ? Color.SkyBlue : Color.DarkSlateGray);
        }

        private void HoverCellTable(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                string rowNumber = label.Name.Substring(3);
                for (int i = 0; i < table.Controls.Count; i++)
                {
                    if (table.Controls[i].Name == "row" + rowNumber)
                    {
                        if (!table.Controls[i].Name.Equals(_selectedRowNumber))
                        {
                            table.Controls[i].Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                            table.Controls[i].ForeColor = Color.DarkOliveGreen;
                            table.Controls[i].BackColor = Color.Honeydew;
                        }
                    }
                }
            }
        }

        private void LeaveCellTable(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                string rowNumber = label.Name.Substring(3);
                for (int i = 0; i < table.Controls.Count; i++)
                {
                    if (table.Controls[i].Name == "row" + rowNumber)
                    {
                        if (!table.Controls[i].Name.Equals(_selectedRowNumber))
                        {
                            table.Controls[i].Font = new Font("Verdana", 9.4F, FontStyle.Regular, GraphicsUnit.Point);
                            table.Controls[i].ForeColor = Color.Black;
                            table.Controls[i].BackColor = Convert.ToInt32(rowNumber) % 2 == 0 ?
                                  (_mainPage.isNight ? Color.LightSlateGray : Color.Linen)
                                : (_mainPage.isNight ? Color.LightSteelBlue : Color.AntiqueWhite);
                        }
                    }
                }
            }
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

        private void ThemeSwitcher_MouseEnter(object? sender, EventArgs e)
        {
            themeSwitcher.Image = _mainPage.isNight ? Resources.light_theme_hover : Resources.dark_theme_hover;
        }

        private void ThemeSwith_MouseLeave(object? sender, EventArgs e)
        {
            themeSwitcher.Image = _mainPage.isNight ? Resources.light_theme_dark : Resources.dark_theme;
        }

        private void ToggleThemeMode()
        {
            logoBox.Image = _mainPage.isNight ? Resources.logo_dark : Resources.logo;
            themeSwitcher.Size = _mainPage.isNight ? new Size(40, 40) : new Size(36, 36);
            themeSwitcher.Location = _mainPage.isNight ? new Point(1425, 12) : new Point(1429, 16);
            themeSwitcher.Image = _mainPage.isNight ? Resources.light_theme_dark : Resources.dark_theme;
            collapseAppBox.Image = _mainPage.isNight ? Resources.collapse_dark : Resources.collapse;
            quitAppButton.Image = _mainPage.isNight ? Resources.quit_dark : Resources.quit;
            backToListBox.Image = _mainPage.isNight ? Resources.back_light : Resources.back_dark;
            employeesHeader.ForeColor = _mainPage.isNight ? Color.SkyBlue : Color.DarkSlateGray;
            dataManagementHeader.ForeColor = _mainPage.isNight ? Color.SkyBlue : Color.DarkSlateGray;

            string tipMessage = _mainPage.isNight ? "Переключить на дневной режим" : "Переключить на ночной режим";
            toolTip.SetToolTip(themeSwitcher, tipMessage);

            BackColor = _mainPage.isNight ? SystemColors.Desktop : SystemColors.GradientActiveCaption;

            Opacity = _mainPage.isNight ? 0.95F : 1.0F;
            condition.BackColor = _mainPage.isNight ? SystemColors.ScrollBar : SystemColors.Window;
            displayRelevancePost.ForeColor = _mainPage.isNight ? Color.AliceBlue : SystemColors.ControlText;
            postComboBox.BackColor = _mainPage.isNight ? SystemColors.ScrollBar : SystemColors.Window;
            dataPanel.BackColor = _mainPage.isNight ? Color.DimGray : SystemColors.GradientInactiveCaption;
            npcptLinkLabel.LinkColor = _mainPage.isNight ? Color.SkyBlue : Color.DimGray;

            foreach (var control in this.Controls)
            {
                if (control is Label label)
                    if (label.Name.Contains("Button"))
                    {
                        label.ForeColor = _mainPage.isNight ? Color.AliceBlue : Color.Wheat;
                    }
                    else
                        label.ForeColor = _mainPage.isNight ? Color.AliceBlue : Color.DarkSlateGray;
            }

            foreach (var control in headerTable.Controls)
                if (control is Label label)
                    label.ForeColor = _mainPage.isNight ? Color.AliceBlue : Color.AntiqueWhite;

            foreach (var control in filterBlock.Controls)
                if (control is RadioButton rButton)
                    rButton.ForeColor = _mainPage.isNight ? Color.SkyBlue : Color.DarkSlateGray;

            filterBlock.ForeColor = _mainPage.isNight ? Color.AliceBlue : Color.DarkSlateGray;
            tableCurrentMessage.ForeColor = _mainPage.isNight ? Color.AliceBlue : Color.DarkSlateGray;

            if (table is not null)
                foreach (var control in table.Controls)
                    if (control is Label label)
                    {
                        string rowNumber = label.Name.Substring(3);
                        label.BackColor = Convert.ToInt32(rowNumber) % 2 == 0 ?
                            (_mainPage.isNight ? Color.LightSlateGray : Color.Linen)
                            : (_mainPage.isNight ? Color.LightSteelBlue : Color.AntiqueWhite);
                    }

            if (!_selectedRowNumber.Equals(string.Empty) && table is not null)
                foreach (var control in table.Controls)
                    if (control is Label label && label.Name.Equals(_selectedRowNumber))
                    {
                        label.ForeColor = _mainPage.isNight ? Color.Lime : Color.White;
                        label.BackColor = _mainPage.isNight ? Color.DarkOliveGreen : Color.SteelBlue;
                    }
        }

        #endregion


        #region Interface

        private void TimerTick(object? sender, EventArgs e)
        {
            timePeriod--;

            if (timePeriod <= 0)
            {
                timer.Stop();
                timePeriod = 3;
                currentMessage.Text = string.Empty;
            }
        }

        private void BackToSettingsForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            _mainPage.ToggleThemeMode();
            _settingsForm.ToggleThemeMode();
            _settingsForm.Show();
            this.Dispose();
        }

        private void CollapseAppBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void QuitAppButton_Click(object sender, EventArgs e) => _mainPage.QuitApplication(sender, e);

        private void Link_Click(object sender, EventArgs e) => _mainPage.NpcptLinkLabelClicked(sender, e);

        private void ThisForm_MouseDown(object sender, MouseEventArgs e)
        {
            iFormX = this.Location.X;
            iFormY = this.Location.Y;
            iMouseX = MousePosition.X;
            iMouseY = MousePosition.Y;
        }

        private void ThisForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!selectCondition.Focused && !postComboBox.Focused)
            {
                int iMouseX2 = MousePosition.X;
                int iMouseY2 = MousePosition.Y;
                if (e.Button == MouseButtons.Left)
                    this.Location = new Point(iFormX + (iMouseX2 - iMouseX), iFormY + (iMouseY2 - iMouseY));
            }
        }

        private void DisplayConditonField(bool isDisplay)
        {
            if (isDisplay)
            {
                condition.Visible = true;
                selectCondition.Visible = false;
                condition.Focus();
            }
            else
            {
                condition.Visible = false;
                selectCondition.Visible = true;
            }
        }

        private void FilterValueChanged(object sender, EventArgs e)
        {
            GetEmployeeData();
        }

        private void CheckKeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (personnelNumberFilter.Checked)
            {
                if (!Char.IsDigit(number) && number != 8)   // ASCII: 8 = Backspace
                {
                    e.Handled = true;
                    DisplayCurrentMessage("При фильтрации по табельному номеру сотрудника используйте только цифры", false);
                }
            }
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayConditonField(false);
            GetEmployeeData();
        }

        private void AddPostButton_Click(object sender, EventArgs e)
        {
            PostForm postForm = new(this, _mainPage.isNight);
            this.Opacity = 0.7;
            this.Enabled = false;
            postForm.ShowDialog();
        }

        private void RemoveSelectedPostButton_Click(object sender, EventArgs e)
        {
            int index = postComboBox.SelectedIndex;
            if (postComboBox.Items[index] is Post post)
            {
                DialogResult result = MessageBox.Show($"Удалить должность {post.Name}?", "Внимание!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    if (post.Id != 1)
                    {
                        _unitOfWork.Employees.SetDefaultPost(post.Id);
                        RemovePost(post.Id);
                        SetPostListToComboBox();
                        GetEmployeeData();
                        DisplayCurrentMessage($"Должность \"{post.Name}\" успешно удалена", true);
                    }
                    else
                        DisplayCurrentMessage("Нельзя удалить должность, созданную для присвоения по умолчанию", false);
                }
            }
        }

        private void EditSelectedPostButton_Click(object sender, EventArgs e)
        {
            int index = postComboBox.SelectedIndex;
            if (postComboBox.Items[index] is Post post)
            {
                PostForm postForm = new(this, _mainPage.isNight, post);
                this.Opacity = 0.7;
                this.Enabled = true;
                postForm.ShowDialog();
            }
        }

        private void PostRelevanceChanged(object sender, EventArgs e) => SetPostListToComboBox();

        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            EmployeeForm empForm = new(this, _mainPage.isNight);
            this.Opacity = 0.7;
            this.Enabled = false;
            empForm.ShowDialog();
        }

        private void TableRow_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                string oldRowNumber = string.Empty;
                bool isSelected = _selectedRowNumber == string.Empty ? false : true;

                string rowNumber = label.Name.Substring(3);
                if (isSelected)
                    oldRowNumber = _selectedRowNumber.Substring(3);

                for (int i = 0; i < table.Controls.Count; i++)
                {
                    if (isSelected && table.Controls[i].Name.Equals(_selectedRowNumber))
                    {
                        table.Controls[i].Font = new Font("Verdana", 9.4F, FontStyle.Regular, GraphicsUnit.Point);
                        table.Controls[i].ForeColor = Color.Black;
                        table.Controls[i].BackColor = Convert.ToInt32(oldRowNumber) % 2 == 0 ?
                              (_mainPage.isNight ? Color.LightSlateGray : Color.Linen)
                            : (_mainPage.isNight ? Color.LightSteelBlue : Color.AntiqueWhite);
                    }

                    if (table.Controls[i].Name == "row" + rowNumber)
                    {
                        table.Controls[i].Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        table.Controls[i].ForeColor = _mainPage.isNight ? Color.Lime : Color.White;
                        table.Controls[i].BackColor = _mainPage.isNight ? Color.DarkOliveGreen : Color.SteelBlue;
                    }
                }

                _selectedRowNumber = label.Name;
            }
        }

        private void RemoveSelectedEmployeeButton_Click(object senderm, EventArgs e)
        {
            if (_selectedRowNumber != string.Empty)
            {
                int employeeId = GetEmployeeIdFromSelectedRow();
                if (employeeId != 0)
                {
                    DialogResult result = MessageBox.Show($"Удалить выбранного сотрудника?", "Внимание!",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        RemoveEmployee(employeeId);
                        GetEmployeeData();
                        DisplayCurrentMessage("Удаление сотрудника прошло успешно", true);
                    }
                }
                else
                    DisplayCurrentMessage("Ошибка удаления: сотрудник не найден", false);
            }
            else
                DisplayCurrentMessage("Не выбран сотрудник для удаления", false);
        }

        private void EditSelectedEmployeeButton_Click(object sender, EventArgs e)
        {
            if (_selectedRowNumber != string.Empty)
            {
                int employeeId = GetEmployeeIdFromSelectedRow();
                if (employeeId != 0)
                {
                    EmployeeForm empForm = new(this, _mainPage.isNight, employeeId);
                    this.Opacity = 0.7;
                    this.Enabled = true;
                    empForm.ShowDialog();
                }
                else
                    DisplayCurrentMessage("Ошибка редактирования: сотрудник не найден", false);
            }
            else
                DisplayCurrentMessage("Не выбран сотрудник для редактирования данных", false);
        }

        private async void Label_MouseWheel(object? sender, MouseEventArgs e)
        {
            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            int numberOfPixelsToMove = numberOfTextLinesToMove * 3;

            if (numberOfPixelsToMove != 0 && publishedRecords > 12)
            {
                int value = table.Location.Y + numberOfPixelsToMove;
                int lowerLimit = (publishedRecords - 12) * panel.Height / 12;
                int y = value < 0 ? (value > -lowerLimit ? value : -lowerLimit) : 0;
                table.Location = new Point(table.Location.X, y);

                if (table.Location.Y % -(18 * panel.Height / 12) == 0 && publishedRecords < _recordCounter && numberOfTextLinesToMove < 0)
                {
                    DisplayCurrentMessage("Подгрузка данных...", true);
                    List<EmployeeViewModel> data = await DownloadData();
                    AddDataToTable(data);
                }

                int maxValue = tableScrollProgressLeft.Maximum;
                int currentValue = _scrollBarHeight + Math.Abs(table.Location.Y);
                int progressValue = currentValue <= maxValue ? currentValue : maxValue;
                tableScrollProgressLeft.Value = tableScrollProgressRight.Value = progressValue;

                int offset = table.Location.Y / -(panel.Height / 12);
                string range = publishedRecords == 1 ? "1" : publishedRecords == 2 ?
                "1, 2" : publishedRecords >= 12 ? $"{1 + offset} - {12 + offset}" : $"1 - {publishedRecords}";
                string message = _recordCounter == 0 ? "Нет данных" :
                    $"Показано записей {range} из {_recordCounter}";

                tableCurrentMessage.Text = message;
            }
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            condition.Text = string.Empty;
            bool flag = GetFilterValue() is DataFilter.Relevance ? false : true;
            DisplayConditonField(flag);
            GetEmployeeData();
        }

        private async void ThemeSwitcher_Click(object? sender, EventArgs e)
        {
            _mainPage.isNight = !_mainPage.isNight;
            await _unitOfWork.SetThemeValue(_mainPage.isNight);
            _unitOfWork.Save();
            ToggleThemeMode();
        }

        #endregion



        public void GetEmployeeData()
        {
            _selectedRowNumber = string.Empty;
            tableCurrentMessage.Text = string.Empty;

            publishedRecords = 0;
            _recordCounter = 0;
            _scrollBarHeight = 0;
            if (table is not null)
                _mainPage.ClearTableControls(headerTable, table!);

            DataFilter filter = GetFilterValue();
            string condition = filter is DataFilter.Relevance ? selectCondition.SelectedIndex.ToString() : this.condition.Text;
            _recordCounter = _unitOfWork.Employees.Count(filter, condition);

            List<EmployeeViewModel> data = _unitOfWork.Employees.GetEmployeeData(filter, condition, MainPage._numberOfUploadedRecords, publishedRecords);

            if (data.Count > 0)
            {
                if (table is null)
                {
                    table = CreateTable();
                    panel.Controls.Add(table);
                }

                tableScrollProgressLeft.Visible = true;
                tableScrollProgressRight.Visible = true;

                AddDataToTable(data);
                SetTableScrollProgress(data.Count);

                DisplayCurrentMessage("Данные загружены", true);
            }
            else
            {
                DisplayCurrentMessage("Нет данных", false);
                tableCurrentMessage.Text = string.Empty;
                tableScrollProgressLeft.Visible = false;
                tableScrollProgressRight.Visible = false;
            }
        }

        private DataFilter GetFilterValue()
        {
            var controls = filterBlock.Controls;
            foreach (var control in controls)
            {
                if (control is RadioButton rButton)
                    if (rButton.Checked)
                        return rButton.Tag switch
                        {
                            "lastname" => DataFilter.Lastname,
                            "post" => DataFilter.Post,
                            "personnelNumber" => DataFilter.PersonnelNumber,
                            _ => DataFilter.Relevance
                        };
            }

            return DataFilter.Relevance;
        }

        private void CreateTableRow(EmployeeViewModel model)
        {
            int addValue = panel.Height / 12;
            int height = table.Size.Height + addValue;
            table.Size = new Size(headerTable.Width, height);
            int rowNumber = table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            table.Controls.Add(CreateLabelForRowCell(model.PersonnelNumber!, 3, height, rowNumber, model.EmployeeId));
            table.Controls.Add(CreateLabelForRowCell(model.Lastname!, 126, height, rowNumber, model.EmployeeId));
            table.Controls.Add(CreateLabelForRowCell(model.Firstname!, 310, height, rowNumber, model.EmployeeId));
            table.Controls.Add(CreateLabelForRowCell(model.Surname!, 494, height, rowNumber, model.EmployeeId));
            table.Controls.Add(CreateLabelForRowCell(model.Post!, 862, height, rowNumber, model.EmployeeId));
            string relevance = model.IsActive == 1 ? "действующий" : "уволен";
            table.Controls.Add(CreateLabelForRowCell(relevance, 1046, height, rowNumber, model.EmployeeId));
        }

        private Label CreateLabelForRowCell(string text, int xPoint, int yPoint, int rowNumber, int employeeId)
        {
            Label label = new();
            label.AutoSize = true;
            label.BackColor = rowNumber % 2 == 0 ? (_mainPage.isNight ? Color.LightSlateGray : Color.Linen)
                                     : (_mainPage.isNight ? Color.LightSteelBlue : Color.AntiqueWhite);
            label.Dock = DockStyle.Fill;
            label.Font = new Font("Verdana", 9.4F, FontStyle.Regular, GraphicsUnit.Point);
            label.Location = new Point(xPoint, yPoint);
            label.Name = "row" + rowNumber;
            label.Size = new Size(152, 40);
            label.TabIndex = 1;
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Tag = employeeId;
            label.Cursor = Cursors.Hand;

            label.MouseEnter += HoverCellTable!;
            label.MouseLeave += LeaveCellTable!;
            label.MouseClick += TableRow_Click!;
            label.MouseWheel += Label_MouseWheel;

            return label;
        }

        public void DisplayCurrentMessage(string message, bool isSuccess)
        {
            currentMessage.Text = message;
            currentMessage.ForeColor = isSuccess ? _mainPage.isNight ? Color.GreenYellow : Color.OliveDrab
                : _mainPage.isNight ? Color.Orange : Color.IndianRed;

            if (timePeriod < 5)
                timePeriod = 5;

            timer.Start();
        }

        private List<Post> GetCurrentPostList()
        {
            byte relevance = displayRelevancePost.Checked ? (byte)1 : (byte)0;
            return _unitOfWork.Posts.GetAll(relevance).ToList();
        }

        public void SetPostListToComboBox()
        {
            postComboBox.Items.Clear();
            postComboBox.ResetText();

            List<Post> posts = GetCurrentPostList();
            if (posts.Count > 1)
            {
                for (int i = 1; i < posts.Count; i++)
                    postComboBox.Items.Add(posts[i]);

                postComboBox.DisplayMember = "Name";

            }
            else
                postComboBox.Items.Add("список должностей пуст");

            postComboBox.SelectedIndex = 0;
        }

        private void RemovePost(int postId)
        {
            _unitOfWork.Posts.Delete(postId);
            _unitOfWork.Save();
        }

        private void RemoveEmployee(int employeeId)
        {
            _unitOfWork.MeasuringsData.UnbindDataBeforeDelete(employeeId);
            _unitOfWork.Employees.Delete(employeeId);
            _unitOfWork.Save();
        }

        private int GetEmployeeIdFromSelectedRow()
        {
            if (_selectedRowNumber != string.Empty)
            {
                for (int i = 0; i < table.Controls.Count; i++)
                    if (table.Controls[i] is Label label)
                        if (label.Name.Equals(_selectedRowNumber))
                            return (int)label.Tag!;
            }

            return 0;
        }

        private TableLayoutPanel CreateTable()
        {
            TableLayoutPanel table = new();

            table.ColumnCount = 6;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));

            table.Location = new Point(10, 4);
            table.Name = "table";
            table.Size = new Size(headerTable.Width, 0);
            table.TabIndex = 1;
            panel.MouseWheel += Label_MouseWheel!;

            return table;
        }

        private void AddDataToTable(List<EmployeeViewModel> list)
        {
            publishedRecords += list.Count;

            SuspendLayout();
            for (int i = 0; i < list.Count; i++)
            {
                CreateTableRow(list[i]);
            }
            ResumeLayout();

            string range = publishedRecords == 1 ? "1" : publishedRecords == 2 ?
                "1, 2" : publishedRecords >= 12 ? "1 - 12" : $"1 - {publishedRecords}";
            string message = _recordCounter == 0 ? "Нет данных" :
                $"Показано записей {range} из {_recordCounter}";

            tableCurrentMessage.Text = message;
        }

        private void SetTableScrollProgress(int numberOfRecords)
        {
            if (numberOfRecords < 12)
            {
                tableScrollProgressLeft.Visible = false;
                tableScrollProgressRight.Visible = false;
            }
            else
            {
                tableScrollProgressLeft.Visible = true;
                tableScrollProgressRight.Visible = true;

                int rowHeight = panel.Height / 12;

                tableScrollProgressLeft.Maximum = tableScrollProgressRight.Maximum = _recordCounter * rowHeight;
                _scrollBarHeight = numberOfRecords >= 12 ? panel.Height : numberOfRecords * rowHeight;

                tableScrollProgressLeft.Height = _scrollBarHeight;
                tableScrollProgressRight.Height = _scrollBarHeight;

                int progressValue = numberOfRecords > 0 && numberOfRecords <= 12 ? _scrollBarHeight :
                    numberOfRecords > 0 && numberOfRecords > 12 ? _scrollBarHeight + Math.Abs(table.Location.Y) : 0;
                tableScrollProgressLeft.Value = tableScrollProgressRight.Value = progressValue;
            }
        }

        private async Task<List<EmployeeViewModel>> DownloadData()
        {
            List<EmployeeViewModel> list = new();
            DataFilter filter = GetFilterValue();
            string condition = filter is DataFilter.Relevance ? selectCondition.SelectedIndex.ToString() : this.condition.Text;

            await Task.Run(() =>
            {
                list = _unitOfWork.Employees.GetEmployeeData(filter, condition, MainPage._numberOfUploadedRecords, publishedRecords);
            });

            return list;
        }
    }
}
