using Data;
using Data.Interfaces;
using Domain;
using Domain.ElectricValues;
using Domain.EmployeeData;
using Domain.LocomotiveData;
using HidSharp;
using Presentation.Properties;
using Presentation.View;
using System.Data;
using System.Text;

namespace Presentation.Forms
{
    [Obsolete]  //.:: Атрибут, убирающий предупреждения об использовании устаревших классов [HidDeviceLoader etc.]
    public partial class MainPage : Form
    {
        private EntryForm _entryForm;
        private bool _isDeviceConnected;

        IUnitOfWork _unitOfWork;

        private System.Windows.Forms.Timer timer;
        int timePeriod;

        private HidDeviceLoader? _loader;
        private HidDevice? _device;
        private HidStream? _stream;
        byte[] txBuffer = new byte[0x40];
        byte[] rxBuffer = new byte[0x1000];

        private bool _isEvenTableRow = false;
        private int _firstFreshLoadedDataIndex = 0;

        private int publishedRecords = 0;
        private int _recordCounter = 0;
        private int _scrollBarHeight = 0;
        private TableLayoutPanel table;

        int iFormX, iFormY, iMouseX, iMouseY;

        public const int _numberOfUploadedRecords = 30;
        public bool isNight;
        public Company company;

        public MainPage(EntryForm entryForm, bool themeValue)
        {
            InitializeComponent();

            isNight = themeValue;
            _entryForm = entryForm;
            _unitOfWork = new UnitOfWork();

            searchPanel.Enabled = false;
            tableScrollProgressLeft.Visible = false;
            tableScrollProgressRight.Visible = false;

            timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timePeriod = 5;
            timer.Tick += TimerTick;

            company = _entryForm.company;

            SetProgressBar();
            ToggleThemeMode();
            ConnectToDevice(false);
        }


        #region Interface

        public void QuitApplication(object? sender, EventArgs e) => _entryForm.Close();

        public void NpcptLinkLabelClicked(object? sender, EventArgs e)
            => System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://npcpt.com",
                UseShellExecute = true
            });

        private void GetAllDataFromDeviceButton_Click(object? sender, EventArgs e)
            => UploadDataFromDevice();

        private void GetAllDataFromDbButton_Click(object? sender, EventArgs e)
        {
            _firstFreshLoadedDataIndex = 0;
            if (publishedRecords != 0)
            {
                publishedRecords = 0;
                ClearTableControls(headerTable, table);
            }

            DataFilter filter = searchCondition.Text.Equals("локомотиву") ? DataFilter.Locomotive : DataFilter.PersonnelNumber;
            string condition = searchText.Text;
            _recordCounter = _unitOfWork.MeasuringsData.Count(filter, condition);
            string reverse = dataReverseButton.Tag!.ToString()!;

            List<MeasuringData> list = _unitOfWork.MeasuringsData.GetAll(filter, condition, _numberOfUploadedRecords, publishedRecords, reverse);

            if (list.Count > 0)
            {
                searchPanel.Enabled = true;
                tableScrollProgressLeft.Visible = true;
                tableScrollProgressRight.Visible = true;
                dataReverseButton.Enabled = true;

                AddDataToTable(list);
                DisplayCurrentMessage("Данные загружены", true);
            }
            else
                DisplayCurrentMessage("Нет данных", false);

            SetTableScrollProgress(list.Count);
        }

        private void GetAllData(object? sender, EventArgs e)
        {
            publishedRecords = 0;
            ClearTableControls(headerTable, table);
            tableCurrentMessage.Text = string.Empty;

            _firstFreshLoadedDataIndex = 0;
            List<MeasuringData> measuringsData = DownloadData();
            AddDataToTable(measuringsData);
            SetTableScrollProgress(measuringsData.Count);
        }

        private void TableRow_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                int measuringDataId = Convert.ToInt32(label.Tag);

                AllMeasurementsFromLocoForm measuringDataForm = new(this, measuringDataId);
                this.Hide();
                measuringDataForm.Show();
            }
        }

        private void SelectSearchCondition(object sender, EventArgs e)
        {
            publishedRecords = 0;
            searchText.Text = string.Empty;

            if (searchCondition.Text == "локомотиву")
            {
                searchCondition.Text = "таб.N сотрудника";
                mainPageToolTip.SetToolTip(searchCondition, "Искать по табельному номеру сотрудника, проводившего измерения");
            }
            else
            {
                searchCondition.Text = "локомотиву";
                mainPageToolTip.SetToolTip(searchCondition, "Искать по серии и номеру локомотива");
            }

            searchText.Focus();
        }

        private void CheckKeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (searchCondition.Text == "таб.N сотрудника")
            {
                if (!Char.IsDigit(number) && number != 8)   // ASCII: 8 = Backspace
                {
                    e.Handled = true;
                    DisplayCurrentMessage("При фильтрации по табельному номеру сотрудника используйте только цифры", false);
                }
            }
        }

        private void CollapseAppBox_Click(object sender, EventArgs e)
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

        private void GetDataFromFile_Click(object sender, EventArgs e)
        {
            searchPanel.Enabled = false;
            dataReverseButton.Enabled = false;

            OpenFileDialog fDialog = new();

            var defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\NPC";
            fDialog.InitialDirectory = Directory.Exists(defaultPath) ?
                defaultPath : Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            fDialog.Title = "Выберите файл...";
            fDialog.Filter = "Файлы данных CSV (*.csv)|*.csv";

            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = fDialog.FileName;
                    var data = File.ReadAllLines(path);
                    addDataFromFile.Enabled = false;

                    progressBar.Visible = true;
                    tableScrollProgressLeft.Visible = true;
                    tableScrollProgressRight.Visible = true;
                    progressBar.Maximum = data.Length;

                    publishedRecords = 0;
                    _firstFreshLoadedDataIndex = 0; //.:: Set to zero to trigger the condition for obtaining the first index of fresh data in SaveDataInDb()

                    for (int i = 0; i < data.Length; i++)
                    {
                        SaveDataInDB(data[i]);
                        progressBar.PerformStep();
                    }
                    DisplayCurrentMessage($"Данные с файла загружены и сохранены", true);

                    if (progressBar.Maximum == progressBar.Value)
                    {
                        progressBar.Visible = false;
                        addDataFromFile.Enabled = true;
                    }

                    //.:: Выгрузка из БД свежих данных
                    tableScrollProgressLeft.Visible = true;
                    tableScrollProgressRight.Visible = true;

                    DataFilter filter = searchCondition.Text.Equals("локомотиву") ? DataFilter.Locomotive : DataFilter.PersonnelNumber;
                    //.:: Найти общее количество только свежих записей :::
                    _recordCounter = _unitOfWork.MeasuringsData.CountLastRecords(_firstFreshLoadedDataIndex);
                    List<MeasuringData> measuringsData =
                        _unitOfWork.MeasuringsData.GetAllFreshEntries(filter, string.Empty, _numberOfUploadedRecords, publishedRecords, _firstFreshLoadedDataIndex);

                    //.:: Проверка и вывод таблицы, если записей больше нуля
                    if (table is not null)
                    {
                        ClearTableControls(headerTable, table);
                        publishedRecords = 0;
                    }
                    AddDataToTable(measuringsData);
                    SetTableScrollProgress(measuringsData.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Невозможно загрузить файл CSV: \n{ex.Message}",
                        "Ошибка загрузки файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    searchPanel.Enabled = false;
                    dataReverseButton.Enabled = false;
                }
                finally
                {
                    progressBar.Visible = false;
                    progressBar.Value = 0;
                }
            }
        }

        private void DataReverseButton_Click(object sender, EventArgs e)
        {
            dataReverseButton.Tag = dataReverseButton.Tag!.ToString()!.Equals("DESC") ? "ASC" : "DESC";
            string reverse = dataReverseButton.Tag!.ToString()!;

            DataFilter filter = searchCondition.Text.Equals("локомотиву") ? DataFilter.Locomotive : DataFilter.PersonnelNumber;
            string condition = searchText.Text;

            ClearTableControls(headerTable, table);
            _firstFreshLoadedDataIndex = 0;
            publishedRecords = 0;
            List<MeasuringData> data = _unitOfWork.MeasuringsData.GetAll(filter, condition, _numberOfUploadedRecords, publishedRecords, reverse);
            AddDataToTable(data);
            SetTableScrollProgress(data.Count);

            DisplayCurrentMessage("Данные реверсированы по дате", true);
        }

        private void Label_MouseWheel(object sender, MouseEventArgs e)
        {
            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            int numberOfPixelsToMove = numberOfTextLinesToMove * 3;

            if (numberOfPixelsToMove != 0 && publishedRecords > 12)
            {
                int rowHeight = panel.Height / 12;

                int newCoordinateY = table.Location.Y + numberOfPixelsToMove;
                int lowerLimit = (publishedRecords - 12) * rowHeight;
                int y = newCoordinateY < 0 ? (newCoordinateY > -lowerLimit ? newCoordinateY : -lowerLimit) : 0;
                table.Location = new Point(table.Location.X, y);

                if (table.Location.Y % -(18 * rowHeight) == 0 && publishedRecords < _recordCounter && numberOfTextLinesToMove < 0)
                {
                    DisplayCurrentMessage("Подгрузка данных...", true);
                    List<MeasuringData> measuringsData = DownloadData();
                    AddDataToTable(measuringsData);
                }

                int maxValue = tableScrollProgressLeft.Maximum;
                int currentValue = _scrollBarHeight + Math.Abs(table.Location.Y);
                int progressValue = currentValue <= maxValue ? currentValue : maxValue;
                tableScrollProgressLeft.Value = tableScrollProgressRight.Value = progressValue;

                int offset = table.Location.Y / -rowHeight;
                string range = publishedRecords == 1 ? "1" : publishedRecords == 2 ?
                "1, 2" : publishedRecords >= 12 ? $"{1 + offset} - {12 + offset}" : $"1 - {publishedRecords}";
                string message = _recordCounter == 0 ? "Нет данных" :
                    $"Показано записей {range} из {_recordCounter}";

                tableCurrentMessage.Text = message;
            }
        }

        private void ThemeSwitcher_Click(object? sender, EventArgs e)
        {
            isNight = !isNight;
            ToggleThemeMode();
            _unitOfWork.SetThemeValue(isNight);
            _unitOfWork.Save();
        }

        private void SettingsButton_Click(object? sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(this);
            this.Hide();
            settingsForm.Show();
        }

        #endregion


        #region Design
        public void HoverLabel(Label label, bool isHover)
        {
            label.ForeColor = isHover ? Color.WhiteSmoke : isNight ? Color.AliceBlue : Color.Wheat;
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

        private void QuitAppButton_MouseEnter(object sender, EventArgs e)
        {
            quitAppButton.Image = Resources.quit_hover;
        }

        private void QuitAppButton_MouseLeave(object sender, EventArgs e)
        {
            quitAppButton.Image = isNight ? Resources.quit_dark : Resources.quit;
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
                        table.Controls[i].Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        table.Controls[i].ForeColor = Color.DarkOliveGreen;
                        table.Controls[i].BackColor = Color.Honeydew;
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
                        table.Controls[i].Font = new Font("Verdana", 9.4F, FontStyle.Regular, GraphicsUnit.Point);
                        table.Controls[i].ForeColor = Color.Black;
                        table.Controls[i].BackColor = Convert.ToInt32(rowNumber) % 2 == 0 ?
                            (isNight ? Color.LightSlateGray : Color.Linen)
                            : (isNight ? Color.LightSteelBlue : Color.AntiqueWhite);
                    }
                }
            }
        }

        private void CollapseAppBox_MouseEnter(object sender, EventArgs e)
        {
            collapseAppBox.Image = Resources.collapse_hover;
        }

        private void CollapseAppBox_MouseLeave(object sender, EventArgs e)
        {
            collapseAppBox.Image = isNight ? Resources.collapse_dark : Resources.collapse;
        }

        private void DataReverseButton_MouseEnter(object sender, EventArgs e)
        {
            dataReverseButton.Image = Resources.data_reverse_hover;
        }

        private void DataReverseButton_MouseLeave(object sender, EventArgs e)
        {
            dataReverseButton.Image = isNight ? Resources.data_reverse_dark : Resources.data_reverse;
        }

        private void ThemeSwitcher_MouseEnter(object? sender, EventArgs e)
        {
            themeSwitcher.Image = isNight ? Resources.light_theme_hover : Resources.dark_theme_hover;
        }

        private void ThemeSwith_MouseLeave(object? sender, EventArgs e)
        {
            themeSwitcher.Image = isNight ? Resources.light_theme_dark : Resources.dark_theme;
        }

        public void ToggleThemeMode()
        {
            logoBox.Image = isNight ? Resources.logo_dark : Resources.logo;
            themeSwitcher.Size = isNight ? new Size(40, 40) : new Size(36, 36);
            themeSwitcher.Location = isNight ? new Point(1425, 12) : new Point(1429, 16);
            themeSwitcher.Image = isNight ? Resources.light_theme_dark : Resources.dark_theme;

            dataReverseButton.Image = isNight ? Resources.data_reverse_dark : Resources.data_reverse;
            collapseAppBox.Image = isNight ? Resources.collapse_dark : Resources.collapse;
            quitAppButton.Image = isNight ? Resources.quit_dark : Resources.quit;

            string tipMessage = isNight ? "Переключить на дневной режим" : "Переключить на ночной режим";
            mainPageToolTip.SetToolTip(themeSwitcher, tipMessage);

            BackColor = isNight ? SystemColors.Desktop : SystemColors.GradientActiveCaption;

            Opacity = isNight ? 0.95F : 1.0F;
            searchText.BackColor = isNight ? SystemColors.ScrollBar : SystemColors.Window;
            dataPanel.BackColor = isNight ? Color.DimGray : SystemColors.GradientInactiveCaption;
            npcptLinkLabel.LinkColor = isNight ? Color.SkyBlue : Color.DimGray;

            foreach (var control in this.Controls)
                if (control is Label label && !label.Name.Equals("currentMessage"))
                    label.ForeColor = isNight ? Color.AliceBlue : Color.Wheat;

            foreach (var control in headerTable.Controls)
                if (control is Label label)
                    label.ForeColor = isNight ? Color.AliceBlue : Color.AntiqueWhite;

            tableCurrentMessage.ForeColor = isNight ? Color.AliceBlue : Color.DarkSlateGray;
            searchLabel.ForeColor = isNight ? Color.AliceBlue : Color.LemonChiffon;
            searchCondition.ForeColor = isNight ? Color.SkyBlue : Color.YellowGreen;

            if (table is not null)
            {
                foreach (var control in table.Controls)
                {
                    if (control is Label label)
                    {
                        string rowNumber = label.Name.Substring(3);
                        label.BackColor = Convert.ToInt32(rowNumber) % 2 == 0 ?
                            (isNight ? Color.LightSlateGray : Color.Linen)
                            : (isNight ? Color.LightSteelBlue : Color.AntiqueWhite);
                    }
                }
            }
        }

        private void SetProgressBar()
        {
            int width = panel.Width / 3;
            int height = panel.Height / 20;
            progressBar.Size = new Size(width, height);

            int x = panel.Width / 2 - width / 2;
            int y = panel.Height / 2 - height / 2;
            progressBar.Location = new Point(x, y);
        }


        #endregion


        private void DisplayCurrentMessage(string message, bool isSuccess)
        {
            currentMessage.Text = message;
            currentMessage.ForeColor = isSuccess ? isNight ? Color.GreenYellow : Color.OliveDrab
                : isNight ? Color.Orange : Color.IndianRed;

            if (timePeriod < 5)
                timePeriod = 5;

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
            }
        }

        public void ConnectToDevice(bool isFromSettings)
        {
            _loader = new HidDeviceLoader();
            _device = _loader.GetDevices(1155, 22352).FirstOrDefault()!;

            string currentMessage = string.Empty;
            if (_device == null)
            {
                _isDeviceConnected = false;
                currentMessage = "Не удалось установить соединение с прибором по USB";
                if (isFromSettings)
                {
                    MessageBox.Show(currentMessage, "Отсутствует соединение с прибором", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    DisplayCurrentMessage(currentMessage, false);
            }
            else
            {
                _isDeviceConnected = true;
                allDataFromDevice.Enabled = true;

                currentMessage = "Прибор подключён успешно";
                if (isFromSettings)
                {
                    MessageBox.Show(currentMessage, "Соединение установлено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    DisplayCurrentMessage(currentMessage, true);
            }
        }

        private int GetRecordsCounter()
        {
            if (_isDeviceConnected)
            {
                #region Код Артура

                if (!_device!.TryOpen(out _stream))
                {
                    DisplayCurrentMessage("Не удалось получить доступ к устройству", false);
                    return 0;
                }

                using (_stream)
                {
                    int recordsCounter = 0;

                    txBuffer[0] = 0;
                    txBuffer[1] = 4;
                    txBuffer[2] = 0x67;
                    txBuffer[3] = 0x65;
                    txBuffer[4] = 0x74;
                    txBuffer[5] = 0x51;
                    _stream.Write(txBuffer, 0, 6);

                    try
                    {
                        recordsCounter = _stream.Read(rxBuffer);
                    }
                    catch (TimeoutException)
                    {
                        DisplayCurrentMessage("Истекло время ожидания чтения потока", false);
                    }

                    return recordsCounter;
                }

                #endregion
            }
            else
                DisplayCurrentMessage("Устройство не подключено. Проверьте USB-соединение", false);

            return 0;
        }

        private string GetStringRecord(int index)
        {
            if (_isDeviceConnected)
            {
                #region Код Артура

                if (!_device!.TryOpen(out _stream))
                {
                    DisplayCurrentMessage("Не удалось получить доступ к устройству", false);
                    return string.Empty;
                }

                using (_stream)
                {
                    int count = 0;

                    Int16 recNumb = Convert.ToInt16(index);
                    txBuffer[0] = 0;
                    txBuffer[1] = 6;
                    txBuffer[2] = 0x72;
                    txBuffer[3] = 0x65;
                    txBuffer[4] = 0x61;
                    txBuffer[5] = 0x64;
                    txBuffer[6] = Convert.ToByte(0xff & recNumb);
                    txBuffer[7] = Convert.ToByte((0xff00 & recNumb) >> 8);
                    _stream.Write(txBuffer, 0, 8);

                    try
                    {
                        count = _stream.Read(rxBuffer);
                    }
                    catch (TimeoutException)
                    {
                        DisplayCurrentMessage("Истекло время ожидания чтения потока", false);
                    }

                    if (count > 0)
                    {
                        string dataString = Encoding.UTF8.GetString(rxBuffer, 2, 2 + rxBuffer[1]);
                        return dataString;
                    }
                    return string.Empty;
                }

                #endregion
            }
            else
                DisplayCurrentMessage("Устройство не подключено. Проверьте USB-соединение", false);

            return string.Empty;
        }

        private Label CreateLabelForRowCell(string text, int xPoint, int yPoint, int rowNumber, int measuringDataId, bool isEven)
        {
            Label label = new();
            label.AutoSize = true;
            label.BackColor = isEven ? (isNight ? Color.LightSteelBlue : Color.AntiqueWhite)
                                     : (isNight ? Color.LightSlateGray : Color.Linen);
            label.Dock = DockStyle.Fill;
            label.Font = new Font("Verdana", 9.4F, FontStyle.Regular, GraphicsUnit.Point);
            label.Location = new Point(xPoint, yPoint);
            label.Name = "row" + rowNumber;
            label.Size = new Size(152, 40);
            label.TabIndex = 1;
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Tag = measuringDataId;
            label.Cursor = Cursors.Hand;

            label.MouseEnter += HoverCellTable!;
            label.MouseLeave += LeaveCellTable!;
            label.MouseDoubleClick += TableRow_DoubleClick!;
            label.MouseWheel += Label_MouseWheel!;

            return label;
        }

        private string? RemoveZeros(string data)
        {
            data = data.Trim().Replace('.', ',');
            float value;
            float.TryParse(string.Join("", data.Where(c => char.IsDigit(c) || c == ',')), out value);
            return value == 0.0000F ? null : value.ToString();
        }

        private string RecordDataToString(Measuring measuring, string denotement)
        {
            string unit = denotement.Contains("UBK") ? "В" :
                denotement.Contains("INS") ? "" : "Ом";
            StringBuilder sb = new();

            sb = RecordData(sb, measuring.FirstValue!, unit);
            sb = RecordData(sb, measuring.SecondValue!, unit);
            sb = RecordData(sb, measuring.ThirdValue!, unit);
            sb = RecordData(sb, measuring.FourthValue!, unit);
            sb = RecordData(sb, measuring.FifthValue!, unit);
            sb = RecordData(sb, measuring.SixthValue!, unit);

            return sb.ToString().Trim();

        }

        private StringBuilder RecordData(StringBuilder sb, string data, string unit)
        {
            if (!string.IsNullOrEmpty(data))
                sb.Append($" ({data} {unit}) ");

            return sb;
        }

        private void UploadDataFromDevice()
        {
            publishedRecords = 0;
            _firstFreshLoadedDataIndex = 0;
            dataReverseButton.Enabled = false;
            searchPanel.Visible = false;

            int recordsCounter = GetRecordsCounter();
            progressBar.Visible = true;
            progressBar.Maximum = recordsCounter;

            if (_isDeviceConnected && recordsCounter > 0)
            {
                for (int i = 0; i < recordsCounter; i++)
                {
                    string strData = GetStringRecord(i);
                    SaveDataInDB(strData);
                    progressBar.PerformStep();
                }
                DisplayCurrentMessage($"Данные с устройства загружены и сохранены", true);

                progressBar.Visible = false;

                //.:: Предложение пользователю сразу очистить память устройства, т.к. все данные с него выгружены и сохранены в БД
                DialogResult clearDeviceMemory = MessageBox.Show("Все данные c устройства выгружены и сохранены в базе данных приложения." +
                    " Очистить память устройства?", "Внимание!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (clearDeviceMemory == DialogResult.Yes)
                {
                    //.:: Код очистки памяти устройства :::
                }
                else
                {
                    allDataFromDevice.Enabled = false;
                }

                //.:: Выгрузка из БД свежих данных
                tableScrollProgressLeft.Visible = true;
                tableScrollProgressRight.Visible = true;

                _recordCounter = _unitOfWork.MeasuringsData.CountLastRecords(_firstFreshLoadedDataIndex);
                DataFilter filter = searchCondition.Text.Equals("локомотиву") ? DataFilter.Locomotive : DataFilter.PersonnelNumber;
                List<MeasuringData> measuringsData =
                     _unitOfWork.MeasuringsData
                    .GetAllFreshEntries(filter, string.Empty, _numberOfUploadedRecords, publishedRecords, _firstFreshLoadedDataIndex);

                if (table is not null)
                {
                    ClearTableControls(headerTable, table);
                    publishedRecords = 0;
                }
                AddDataToTable(measuringsData);
                SetTableScrollProgress(measuringsData.Count);
            }
            else
                DisplayCurrentMessage("Устройство не подключено. Проверьте USB-соединение", false);
        }

        private void SaveDataInDB(string data)
        {
            data = data.Replace('\0', ';');
            string[] values = data.Split(';');

            //.:: 1) Сохранение значений измерений
            Measuring measuring = new();

            for (int i = 5; i < values.Length; i++)
            {
                string? value = string.IsNullOrEmpty(values[i].Trim()) ?
                    null : values[4].Trim().Equals("INS") ?
                    SetValueForINS(values[i]) : RemoveZeros(values[i]);
                switch (i)
                {
                    case 5: measuring.FirstValue = value; break;
                    case 6: measuring.SecondValue = value; break;
                    case 7: measuring.ThirdValue = value; break;
                    case 8: measuring.FourthValue = value; break;
                    case 9: measuring.FifthValue = value; break;
                    case 10: measuring.SixthValue = value; break;
                }
            }
            if (values[4] == " INS")
                Console.Write("");

            LocoSeries locoSeries = _unitOfWork.LocoSeries.GetByTranslit(values[2]);

            int locoNumberInt = Convert.ToInt32(values[3]);
            string locoNumber = locoNumberInt < 10 ? "00" + locoNumberInt
                : (locoNumberInt > 9 && locoNumberInt < 100) ? "0" + locoNumberInt : locoNumberInt.ToString();

            Locomotive locomotive;
            if (locoSeries.Id != 0)
            {
                locomotive = _unitOfWork.Locomotives.GetBySeriesIdAndNumber(locoSeries.Id, locoNumberInt);

                MeasuringData mData = new();
                if (locomotive == null)
                {
                    locomotive = new()
                    {
                        SeriesId = locoSeries.Id,
                        Number = locoNumber
                    };
                    _unitOfWork.Locomotives.Create(locomotive!);
                    _unitOfWork.Save();
                }

                mData.LocomotiveId = locomotive!.Id;

                string personnelNumber = string.IsNullOrEmpty(values[1].Trim()) ? string.Empty : values[1].Trim();
                if (personnelNumber != string.Empty)
                {
                    Employee employee;
                    employee = _unitOfWork.Employees.SearchByPersonnelNumber(personnelNumber);
                    if (employee == null)
                    {
                        Person person = new()
                        {
                            Firstname = "-",
                            Surname = "-",
                            Lastname = "-"
                        };
                        _unitOfWork.Persons.Create(person);
                        _unitOfWork.Save();

                        employee = new()
                        {
                            PersonId = person.Id,
                            PostId = 1,
                            PersonnelNumber = values[1],
                            IsActive = 1
                        };
                        _unitOfWork.Employees.Create(employee!);
                        _unitOfWork.Save();
                    }

                    mData.EmployeeId = employee.Id;
                }
                else
                    mData.EmployeeId = 1;

                _unitOfWork.Measurings.Create(measuring);
                _unitOfWork.Save();

                mData.MeasuringId = measuring.Id;
                mData.Denotement = values[4].Trim();
                mData.SaveDate = DateTime.Now.ToString("D");

                _unitOfWork.MeasuringsData.Create(mData);
                _unitOfWork.Save();

                if (_firstFreshLoadedDataIndex == 0 && !mData.Denotement.Contains("D"))
                    _firstFreshLoadedDataIndex = mData.Id;
            }
            else
                MessageBox.Show($"В Базе Данных приложения отсутствует запись по данной серии локомотива.",
                    $"Серия локомотива {values[2]} не найдена", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private string? SetValueForINS(string data)
        {
            data = data.Trim().Replace('.', ',');

            float value;
            float.TryParse(string.Join("", data.Where(c => char.IsDigit(c) || c == ',')), out value);

            string numericValueString = GetNumericValueString(data).Trim();

            if (value > 0.000001F)
            {
                data = data.Replace("MOm", "МОм");
                data = data.Replace(numericValueString, $" {value} ");
                return data;
            }
            return null;
        }

        private string GetNumericValueString(string data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (char.IsDigit(data[i]))
                    sb.Append(data[i]);
                if (data[i] == '.' || data[i] == ',')
                    sb.Append(data[i]);
            }

            return sb.ToString();
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

        private TableLayoutPanel CreateTable()
        {
            TableLayoutPanel table = new();

            table.ColumnCount = 5;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            table.Location = new Point(10, 4);
            table.Name = "table";
            table.Size = new Size(headerTable.Width, 0);
            table.TabIndex = 1;
            table.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel.MouseWheel += Label_MouseWheel!;

            /*
             * headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23F));
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            headerTable.Dock = DockStyle.Fill;
            headerTable.Location = new Point(0, 4);
            headerTable.Margin = new Padding(3, 2, 3, 2);
            headerTable.Name = "headerTable";
            headerTable.RowCount = 1;
            headerTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            headerTable.Size = new Size(1089, 34);
            headerTable.TabIndex = 1;
             */

            return table;
        }

        private void AddDataToTable(List<MeasuringData> list)
        {
            if (list.Count > 0)
            {
                if (table is null)
                {
                    table = CreateTable();
                    panel.Controls.Add(table);
                }

                publishedRecords += list.Count;

                SuspendLayout();
                for (int i = 0; i < list.Count; i++)
                {
                    int locoId = list[i].LocomotiveId;
                    Locomotive locomotive = _unitOfWork.Locomotives.Get(locoId!);
                    LocoSeries locoSeries = _unitOfWork.LocoSeries.Get(locomotive.SeriesId);
                    string loco = $"{locoSeries.Series}-{locomotive.Number}";

                    int? employeeId = list[i].EmployeeId;
                    Employee employee = new();
                    if (employeeId != null)
                    {
                        employee = _unitOfWork.Employees.Get((int)employeeId!);
                    }
                    string personnelNumber = string.IsNullOrEmpty(employee.PersonnelNumber) ?
                        "не указан" : employee.PersonnelNumber;

                    int measuringId = list[i].MeasuringId;
                    Measuring measuring = _unitOfWork.Measurings.Get(measuringId);
                    string data = RecordDataToString(measuring, list[i].Denotement!.Trim());

                    string measuringType = list[i].Denotement!.Contains("SE") ?
                        "Сопротивление\nцепей управления" :
                        list[i].Denotement!.Contains("INS") ? "Сопротивление\nизоляции" : "Возвратное\nнапряжение" +
                        "";

                    string saveDate = list[i].SaveDate!;

                    CreateTableRow(loco, personnelNumber!, data, measuringType, saveDate, list[i].Id);
                }
                ToggleThemeMode();
                ResumeLayout();

                string range = publishedRecords == 1 ? "1" : publishedRecords == 2 ?
                    "1, 2" : publishedRecords >= 12 ? "1 - 12" : $"1 - {publishedRecords}";
                string message = _recordCounter == 0 ? "Нет данных" :
                    $"Показано записей {range} из {_recordCounter}";

                tableCurrentMessage.Text = message;
            }
        }

        private void CreateTableRow(string loco, string employee, string values, string measuringType, string saveDate, int measuringDataId)
        {
            SuspendLayout();
            int addValue = panel.Height / 12;
            int width = table.Size.Height + addValue;    //45;
            table.Size = new Size(headerTable.Width, width);
            int rowNumber = table.RowCount++;
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            table.Controls.Add(CreateLabelForRowCell(loco, 0, width, rowNumber, measuringDataId, _isEvenTableRow));
            table.Controls.Add(CreateLabelForRowCell(employee, 0, width, rowNumber, measuringDataId, _isEvenTableRow));
            table.Controls.Add(CreateLabelForRowCell(values, 0, width, rowNumber, measuringDataId, _isEvenTableRow));
            table.Controls.Add(CreateLabelForRowCell(measuringType, 0, width, rowNumber, measuringDataId, _isEvenTableRow));
            table.Controls.Add(CreateLabelForRowCell(saveDate, 0, width, rowNumber, measuringDataId, _isEvenTableRow));
            _isEvenTableRow = !_isEvenTableRow;
            ResumeLayout();
        }

        private List<MeasuringData> DownloadData()
        {
            List<MeasuringData> measuringsData = new();

            string condition = searchText.Text;
            string reverse = dataReverseButton.Tag!.ToString()!;
            DataFilter filter = searchCondition.Text == "локомотиву" ? DataFilter.Locomotive : DataFilter.PersonnelNumber;

            _recordCounter = _unitOfWork.MeasuringsData.Count(filter, condition);
            measuringsData = _unitOfWork.MeasuringsData.GetAll(filter, condition, _numberOfUploadedRecords, publishedRecords, reverse);

            return measuringsData;
        }

        public void ClearTableControls(TableLayoutPanel sampleTable, TableLayoutPanel table)
        {
            table.Parent!.SuspendLayout();
            this.SuspendLayout();

            int numberOfControls = table.Controls.Count;
            while (numberOfControls > 0)
                table.Controls.RemoveAt(--numberOfControls);

            table.Size = new Size(sampleTable.Width, 0);
            table.Location = new Point(10, 4);
            table.RowCount = 0;

            table.Parent!.ResumeLayout();
            this.ResumeLayout();
        }

        private void headerPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
