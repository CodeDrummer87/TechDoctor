using Data;
using Data.Interfaces;
using Domain;
using Domain.ElectricValues;
using Domain.LocomotiveData;
using GroupDocs.Merger;
using GroupDocs.Merger.Domain.Options;
using OpenHtmlToPdf;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Presentation.Forms;
using Presentation.Properties;
using System.Diagnostics;
using System.Text;

namespace Presentation.View
{
    public partial class AllMeasurementsFromLocoForm : Form
    {
        MainPage _mainPage;
        IUnitOfWork _unitOfWork;

        Locomotive _locomotive;
        string _locoType = string.Empty;
        string _locoSeriesNumber = string.Empty;

        private System.Windows.Forms.Timer timer;
        int timePeriod;

        MeasuringData _measuringData;

        private string[] _tableCellValues = new string[18];
        ReportDataStruct reportDataStruct = new();
        PlotModel _model;

        int iFormX, iFormY, iMouseX, iMouseY;

        public AllMeasurementsFromLocoForm(MainPage mainPage, int measuringDataId)
        {
            InitializeComponent();

            insTable.Visible = ubkTable.Visible = seTable.Visible = false;
            tableTitle1.Visible = tableTitle2.Visible = tableTitle3.Visible = false;

            _unitOfWork = new UnitOfWork();
            _mainPage = mainPage;
            _measuringData = _unitOfWork!.MeasuringsData.Get(measuringDataId);
            _locomotive = _unitOfWork.Locomotives.Get(_measuringData.LocomotiveId);
            _locoSeriesNumber = _unitOfWork.Locomotives.GetLocoSeriesNumber(_measuringData.LocomotiveId, out _locoType);

            buildResistanceChartButton.Enabled = CheckForPlotPoints(_locomotive.Id);

            timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timePeriod = 5;
            timer.Tick += TimerTick;

            this.Text = _locoSeriesNumber;
            this.savingDate.Text = "по состоянию на " + _measuringData.SaveDate;

            double[] yPoints = GetAllPointsForPlot(_locomotive.Id);
            if (yPoints != null)
                _model = GetPlotModel(yPoints);

            for (int i = 0; i < _tableCellValues.Count(); i++)
                _tableCellValues[i] = "-";

            ToggleThemeMode();
        }


        #region Interface

        private void LoadForm(object sender, EventArgs e)
        {
            headerDefault.Text = $"Данные о проведении измерений на {_locoType.ToLower()}е";
            headerLoco.Text = _locoSeriesNumber;
            List<string> measurements = _unitOfWork.MeasuringsData.GetAllMeasurementsByLocoId(_locomotive.Id).ToList();

            DateTime currentDate = DateTime.Parse(_measuringData.SaveDate!);
            MeasurementsCheckingStruct measureChecking = new MeasurementsCheckingStruct();
            int tableCounter = 0;
            measurements = DeleteIrrelevantData(measurements, currentDate, out measureChecking, out tableCounter);

            foreach (string data in measurements)
                ParseDataString(data);

            DisplayTables(measureChecking, tableCounter);
        }

        public void NpcptLinkLabelClicked(object? sender, EventArgs e)
            => Process.Start(new ProcessStartInfo
            {
                FileName = "https://npcpt.com",
                UseShellExecute = true
            });

        private void BackToMainPage(object sender, EventArgs e)
        {
            this.Hide();
            _mainPage.ToggleThemeMode();
            _mainPage.Show();
            this.Dispose();
        }

        private void CreateReportButton_Click(object sender, EventArgs e) => CreateReport();

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

        private void BuildResistancePlot_Click(object sender, EventArgs e)
        {
            ResistancePlotForm plotForm = new(this, _mainPage, _model, _locoSeriesNumber);
            this.Hide();
            plotForm.ShowDialog();
        }

        private void QuitAppBox_Click(object sender, EventArgs e) => _mainPage.QuitApplication(sender, e);

        private async void ThemeSwitcher_Click(object? sender, EventArgs e)
        {
            _mainPage.isNight = !_mainPage.isNight;
            await _unitOfWork.SetThemeValue(_mainPage.isNight);
            _unitOfWork.Save();
            ToggleThemeMode();
        }

        #endregion



        #region Design

        private void BackToList_MouseEnter(object sender, EventArgs e)
        {
            backToListBox.Image = _mainPage.isNight ? Resources.back_dark : Resources.back_light;
        }

        private void BackToList_MouseLeave(object sender, EventArgs e)
        {
            backToListBox.Image = _mainPage.isNight ? Resources.back_light : Resources.back_dark;
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label label)
                _mainPage.HoverLabel(label, true);
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label)
                _mainPage.HoverLabel(label, false);
        }

        private void CollapseAppBox_MouseEnter(object sender, EventArgs e)
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

        public void ToggleThemeMode()
        {
            Opacity = _mainPage.isNight ? 0.95F : 1.0F;
            BackColor = _mainPage.isNight ? SystemColors.Desktop : SystemColors.GradientActiveCaption;
            logoBox.Image = _mainPage.isNight ? Resources.logo_dark : Resources.logo;
            panel.BackColor = _mainPage.isNight ? Color.DimGray : SystemColors.GradientInactiveCaption;

            backToListBox.Image = _mainPage.isNight ? Resources.back_light : Resources.back_dark;
            themeSwitcher.Image = _mainPage.isNight ? Resources.light_theme_dark : Resources.dark_theme;
            collapseAppBox.Image = _mainPage.isNight ? Resources.collapse_dark : Resources.collapse;
            quitAppButton.Image = _mainPage.isNight ? Resources.quit_dark : Resources.quit;

            string tipMessage = _mainPage.isNight ? "Переключить на дневной режим" : "Переключить на ночной режим";
            toolTip.SetToolTip(themeSwitcher, tipMessage);

            plotTip.ForeColor = (plotTip.ForeColor == Color.Firebrick || plotTip.ForeColor == Color.DarkSalmon) ?
                (_mainPage.isNight ? Color.DarkSalmon : Color.Firebrick)
                : (_mainPage.isNight ? Color.PaleGreen : Color.DarkOliveGreen);

            foreach (var control in this.Controls)
            {
                if (control is Label label)
                    if (label.Name.Contains("Button"))
                    {
                        label.ForeColor = _mainPage.isNight ? Color.AliceBlue : Color.Wheat;
                    }
                    else if (!label.Name.Contains("Tip"))
                        label.ForeColor = _mainPage.isNight ? Color.AliceBlue : Color.DarkSlateGray;
            }

            foreach (var control in panel.Controls)
            {
                if (control is Label label)
                    label.ForeColor = _mainPage.isNight ? Color.AliceBlue : SystemColors.ControlText;

                if (control is TableLayoutPanel table)
                    foreach (var ctrl in table.Controls)
                        if (ctrl is Label _label && !_label.Name.Contains("header"))
                        {
                            string rowNumber = _label.Name.Substring(3).Replace("Value", "").Replace("lab", "");
                            _label.BackColor = Convert.ToInt32(rowNumber) % 2 == 0 ?
                                (_mainPage.isNight ? Color.LightSlateGray : Color.Linen)
                                : (_mainPage.isNight ? Color.LightSteelBlue : Color.AntiqueWhite);
                        }
            }
        }

        #endregion


        private void ParseDataString(string data)
        {
            string[] values = data.Split(';');
            bool isAvailableValues = false;
            string employeeInfo = string.Empty;

            reportDataStruct.SaveDate = values[1];

            switch (values[0].Trim())
            {
                case "INS":
                    _tableCellValues[0] = ins1Value.Text = IsMeasured(values[3]) ? values[3] : "-";
                    _tableCellValues[1] = ins2Value.Text = IsMeasured(values[4]) ? values[4] : "-";
                    _tableCellValues[2] = ins3Value.Text = IsMeasured(values[5]) ? values[5] : "-";

                    reportDataStruct.PerformerINS = $"измерил сотрудник: {values[2].Replace("..", "ФИО не указано")}";
                    insMeasuredBy.Text = reportDataStruct.PerformerINS;
                    break;

                case "UBK":
                    _tableCellValues[3] = ubk1Value.Text = IsMeasured(values[3]) ? values[3] + " В" : "-";
                    _tableCellValues[4] = ubk2Value.Text = IsMeasured(values[4]) ? values[4] + " В" : "-";
                    _tableCellValues[5] = ubk3Value.Text = IsMeasured(values[5]) ? values[5] + " В" : "-";

                    reportDataStruct.PerformerUBK = $"измерил сотрудник: {values[2].Replace("..", "ФИО не указано")}";
                    ubkMeasuredBy.Text = reportDataStruct.PerformerUBK;
                    break;

                case "SE1":
                    _tableCellValues[6] = _se1Value.Text = IsMeasured(values[3]) ? values[3] + " Ом" : "-";
                    _tableCellValues[7] = _se2Value.Text = IsMeasured(values[4]) ? values[4] + " Ом" : "-";
                    _tableCellValues[8] = _se3Value.Text = IsMeasured(values[5]) ? values[5] + " Ом" : "-";

                    isAvailableValues = true;
                    employeeInfo = values[2];
                    break;

                case "SE2":
                    _tableCellValues[9] = _se4Value.Text = IsMeasured(values[3]) ? values[3] + " Ом" : "-";
                    _tableCellValues[10] = _se5Value.Text = IsMeasured(values[4]) ? values[4] + " Ом" : "-";
                    _tableCellValues[11] = _se6Value.Text = IsMeasured(values[5]) ? values[5] + " Ом" : "-";

                    isAvailableValues = true;
                    employeeInfo = values[2];
                    break;

                case "SE3":
                    _tableCellValues[12] = _se7Value.Text = IsMeasured(values[3]) ? values[3] + " Ом" : "-";
                    _tableCellValues[13] = _se8Value.Text = IsMeasured(values[4]) ? values[4] + " Ом" : "-";
                    _tableCellValues[14] = _se9Value.Text = IsMeasured(values[5]) ? values[5] + " Ом" : "-";

                    isAvailableValues = true;
                    employeeInfo = values[2];
                    break;

                case "SE4":
                    _tableCellValues[15] = _se10Value.Text = IsMeasured(values[3]) ? values[3] + " Ом" : "-";
                    _tableCellValues[16] = _se11Value.Text = IsMeasured(values[4]) ? values[4] + " Ом" : "-";
                    _tableCellValues[17] = _se12Value.Text = IsMeasured(values[5]) ? values[5] + " Ом" : "-";

                    isAvailableValues = true;
                    employeeInfo = values[2];
                    break;
            }

            if (isAvailableValues)
            {
                reportDataStruct.PerformerSE = $"измерил сотрудник: {employeeInfo.Replace("..", "ФИО не указано")}";
                seMeasuredBy.Text = reportDataStruct.PerformerSE;
            }
        }

        private bool IsMeasured(string value) => value.Equals("-1") ? false
            : string.IsNullOrEmpty(value) ? false : true;

        private List<string> DeleteIrrelevantData(List<string> data, DateTime currentDate, out MeasurementsCheckingStruct measureChecking, out int count)
        {
            count = 0;
            measureChecking = new MeasurementsCheckingStruct();
            bool _isRemoved = false;

            for (int i = 0; i < data.Count(); i++)
            {
                data[i] = data[i].Trim();
                DateTime date = PopDate(data[i]);

                if (date <= currentDate)
                {
                    if (data[i].StartsWith("INS"))
                    {
                        if (!measureChecking.ins.isInStock)
                        {
                            ++count;
                            measureChecking.ins.isInStock = true;
                        }
                        else
                            _isRemoved = true;
                    }

                    if (data[i].StartsWith("UBK"))
                    {
                        if (!measureChecking.ubk.isInStock)
                        {
                            ++count;
                            measureChecking.ubk.isInStock = true;
                        }
                        else
                            _isRemoved = true;
                    }

                    if (data[i].StartsWith("SE1"))
                    {
                        if (!measureChecking.se1.isInStock)
                            measureChecking.se1.isInStock = true;
                        else
                            _isRemoved = true;
                    }

                    if (data[i].StartsWith("SE2"))
                    {
                        if (!measureChecking.se2.isInStock)
                            measureChecking.se2.isInStock = true;
                        else
                            _isRemoved = true;
                    }

                    if (data[i].StartsWith("SE3"))
                    {
                        if (!measureChecking.se3.isInStock)
                            measureChecking.se3.isInStock = true;
                        else
                            _isRemoved = true;
                    }

                    if (data[i].StartsWith("SE4"))
                    {
                        if (!measureChecking.se4.isInStock)
                            measureChecking.se4.isInStock = true;
                        else
                            _isRemoved = true;
                    }

                    if (data[i].Contains("DI"))
                        _isRemoved = true;

                    if (_isRemoved)
                    {
                        data.RemoveAt(i--);
                        _isRemoved = false;
                    }
                }
                else
                    data.RemoveAt(i--);

            }

            if (measureChecking.se1.isInStock || measureChecking.se2.isInStock || measureChecking.se3.isInStock || measureChecking.se4.isInStock)
                ++count;

            return data;
        }

        private async void CreateReport()
        {
            createReportButton.Enabled = false;
            DirectoryInfo dir = GetDirectoryForSaving();

            int protocolNumber = GetProtocolNumber(dir);
            reportDataStruct.ProtocolNumber = protocolNumber;

            var currentDate = DateTime.Now;
            string date = currentDate.ToString("D");
            string reportName = $"Протокол N {protocolNumber} ({_locoSeriesNumber}) от {date}";
            string reportFullName = dir + $@"\{reportName}pdf";
            int totalPages = buildResistanceChartButton.Enabled ? 2 : 1;
            reportDataStruct.PageCounter = totalPages;

            List<string> temporaryFiles = new();
            string mainReportPage = await CreateMainReportPage(protocolNumber, reportFullName, totalPages);
            if (buildResistanceChartButton.Enabled)
            {
                string secondDoc = await CreateTempPlotPDF();
                temporaryFiles.Add(mainReportPage);
                temporaryFiles.Add(secondDoc);
                string tempFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\NPC\temp.pdf";

                using (Merger merger = new(temporaryFiles[0]))
                {
                    merger.Join(temporaryFiles[1]);
                    merger.Save(@tempFile);

                    //.:: Rotate the second page 90 degrees :::
                    RotateOptions rotateOptions = new RotateOptions(RotateMode.Rotate90, new int[] { 2 });
                    using (Merger _merger = new Merger(tempFile))
                    {
                        _merger.RotatePages(rotateOptions);
                        _merger.Save(reportFullName);
                    }
                }

                temporaryFiles.Add(tempFile);
            }

            DisplayCurrentMessage($"Формируется отчёт N {protocolNumber} по локомотиву {_locoSeriesNumber}", true);
            DeleteTemporaryFiles(temporaryFiles);
        }

        private string GetCurrentMonthName()
        {
            switch (DateTime.Now.Month)
            {
                case 1: return "Январь";
                case 2: return "Февраль";
                case 3: return "Март";
                case 4: return "Апрель";
                case 5: return "Май";
                case 6: return "Июнь";
                case 7: return "Июль";
                case 8: return "Август";
                case 9: return "Сентябрь";
                case 10: return "Октябрь";
                case 11: return "Ноябрь";
                default: return "Декабрь";
            }
        }

        private DirectoryInfo GetDirectoryForSaving()
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            DirectoryInfo dir = new(desktopPath);
            if (!Directory.Exists(desktopPath + @"\Протоколы"))
                dir.CreateSubdirectory("Протоколы");

            dir = new(desktopPath + @"\Протоколы");

            string currentYear = DateTime.Now.Year.ToString();
            if (!Directory.Exists(dir + @"\" + currentYear))
                dir.CreateSubdirectory(currentYear);

            dir = new(dir + @"\" + currentYear);

            string currentMonth = GetCurrentMonthName();
            if (!Directory.Exists(dir + @"\" + currentMonth))
                dir.CreateSubdirectory(currentMonth);

            dir = new(dir + @"\" + currentMonth);

            return dir;
        }

        private int GetProtocolNumber(DirectoryInfo dir)
        {
            if (dir.GetFiles().Count() > 0)
            {
                var allReports = dir.GetFiles();
                int maxProtocolNumber = 0;
                for (int i = 0; i < allReports.Count(); i++)
                {
                    string fileName = allReports[i].Name;
                    if (fileName.Contains("Протокол N"))
                    {
                        int firstIndex = fileName.IndexOf("N") + 2;
                        int lastIndex = fileName.IndexOf("(") - 1;
                        string number = fileName.Substring(firstIndex, lastIndex - firstIndex);
                        int intNumber = Convert.ToInt32(number);
                        if (intNumber > maxProtocolNumber)
                            maxProtocolNumber = intNumber;
                    }
                    else continue;
                }

                return ++maxProtocolNumber;
            }

            return 1;
        }

        private void DisplayCurrentMessage(string message, bool isSuccess)
        {
            currentMessage.Text = message;
            currentMessage.ForeColor = isSuccess ? _mainPage.isNight ? Color.GreenYellow : Color.OliveDrab
                : _mainPage.isNight ? Color.Orange : Color.IndianRed;

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
                if (!createReportButton.Enabled)
                    createReportButton.Enabled = true;
            }
        }

        private bool CheckForPlotPoints(int locoId)
        {
            int countPlotPoints = _unitOfWork.MeasuringsData.CountPlotPoints(locoId);
            bool isExistPoints = countPlotPoints > 0 ? true : false;

            plotTip.Text = isExistPoints ? "Данные в наличии" : "Измерения не проводились";
            plotTip.ForeColor = isExistPoints ? Color.DarkOliveGreen : Color.Firebrick;

            return countPlotPoints > 0 ? true : false;
        }

        private double[] GetAllPointsForPlot(int locoId)
        {
            string[] points = _unitOfWork.Measurings.GetAllPlotPoints(locoId).ToArray<string>();

            double[] yPoints = new double[300];
            if (points[49] != null)
            {
                int index = 0;
                for (int i = 0; i < points.Length; i++)
                {
                    if (points[i] != null)
                    {
                        string[] values = points[i].Split(';');
                        for (int j = 0; j < 6; j++)
                            yPoints[index++] = Convert.ToDouble(values[j]);
                    }
                }
            }

            return yPoints;
        }

        private PlotModel GetPlotModel(double[] points)
        {
            var model = new PlotModel() { Title = "График сопротивления" };

            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Время (t, сек)" });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = 0, Title = "Сопротивление (R, Ом)" });

            var funcSeries = new LineSeries();
            funcSeries.MarkerType = MarkerType.Circle;
            funcSeries.Color = OxyColors.CadetBlue; //.YellowGreen; .Peru; .CadetBlue; .LightBlue; .LightCoral; .LightSkyBlue
            funcSeries.MarkerFill = OxyColors.Wheat;
            funcSeries.MarkerStroke = OxyColors.Black;
            funcSeries.MarkerStrokeThickness = 1;
            funcSeries.MarkerSize = 3;

            double x = 0.00;
            for (int i = 0; i < points.Length; i++)
            {
                funcSeries.Points.Add(new DataPoint(Math.Round(x, 2), points[i]));
                x += 0.02;
            }

            model.Series.Add(funcSeries);

            return model;
        }

        private async Task<string> CreateMainReportPage(int protocolNumber, string reportFullName, int totalPages)
        {
            string applicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = $@"{applicationDataPath}\NPC\tempMeasuring.pdf";

            string reportPageName = buildResistanceChartButton.Enabled ? @path : @reportFullName;

            await Task.Run(() =>
            {
                //.:: Troubleshooting cyrillic ::::::
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                string html = GetHtmlCode(reportDataStruct);
                var pdf = Pdf.From(html).OfSize(PaperSize.A4);
                byte[] content = pdf.Content();
                File.WriteAllBytes(reportPageName, content);

                int index = reportFullName.IndexOf("Протоколы");
                string shortPath = reportFullName.Substring(index);

                MessageBox.Show($"Протокол N {protocolNumber} ({_locoSeriesNumber}) будет создан и расположен на " +
                    $"вашем рабочем столе в папке Протоколы:\n~\\{shortPath}", "Формирование отчёта", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });

            return reportPageName;
        }

        private string GetHtmlCode(ReportDataStruct reportData)
        {
            string date = reportData.SaveDate;

            string pathToNPC = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\NPC";
            string logoPath = pathToNPC + @"\logo.png";
            logoPath = logoPath.Replace(@"\", "/");

            string companyLogoPath = string.Empty;
            string[] files = Directory.GetFiles(pathToNPC, "company_logo.*");

            float width = 300.0F;
            float height = 125.0F;

            if (files.Length > 0)
            {
                companyLogoPath = files[0].Replace(@"\", "/");

                Image img = Image.FromFile(files[0]);
                width = img.Width;
                height = img.Height;

                if (width > 300)
                {
                    while (width > 300)
                    {
                        width = width - width / 10;
                        height = height - height / 10;
                    }
                }
            }

            StringBuilder htmlCode = new(
                "<!DOCTYPE html> " +
                "<html lang=\"ru\"> " +
                "<head> " +
                "<meta charset=\"UTF-8\"> " +
                "<title>Отчёт</title> " +
            #region CSS
                "<style> " +
                "   html { " +
                "       margin: 0; " +
                "       font-size: 1.4rem; " +
                "       line-height: 17px; " +
                "       font-family: Tahoma; " +
                "   } " +
                "   header { " +
                "       height: 100mm; " +
                "   } " +
                "   .logoBox { " +
                "       width: 90%; " +
                "       margin: 0 auto; " +
                "   } " +
                "   .npcLogo { " +
                "       float: right; " +
                "       width: 300px; " +
                "       height: 125px; " +
                $"      background: url({logoPath}) no-repeat; " +
                $"      background-size: 100%; " +
                "   } " +
                "   .customerLogo { " +
                $"      width: {(int)width}px; " +
                $"      height: {(int)height}px; " +
                $"      background: url({companyLogoPath}) no-repeat; " +
                $"      background-size: 100%; " +
                "   } " +
                "   article { " +
                "       height: 250mm; " +
                "   } " +
                "   footer { " +
                "       text-align: center; " +
                "       font-size: 0.8rem; " +
                "   } " +
                "   h2 { " +
                "       text-align: center; " +
                "   } " +
                "   hr { " +
                "       border: none; " +
                "       outline: none; " +
                "       background-color: black; " +
                "       height: 1px; " +
                "       width: 90%; " +
                "   } " +
                "   .about { " +
                "       width: 90%; " +
                "       line-height: 0.4; " +
                "       margin: auto; " +
                "   } " +
                "   .about p { " +
                "       font-weight: bold; " +
                "   } " +
                "   span { " +
                "       color: rgb(58, 57, 57); " +
                "       font-weight: normal; " +
                "   } " +
                "   .date, .measuredBy { " +
                "       text-align: right; " +
                "       font-size: 0.8rem; " +
                "       width: 95%; " +
                "       margin: 0; " +
                "   } " +
                "   table, th, td { " +
                "       border: 1px solid black; " +
                "   } " +
                "   table, .tableTitle { " +
                "       width: 90%; " +
                "       margin: 2px auto; " +
                "   } " +
                "   th { " +
                "       text-align: center; " +
                "       background-color: rgb(224, 220, 220); " +
                "   } " +
                "   th, td { " +
                "       padding: 4px 0 4px 4px; " +
                "   } " +
                "   .lastColumn { " +
                "       text-align: center; " +
                "       width: 30%; " +
                "   } " +
                "</style> " +
            #endregion
                "</head> " +

                "<body> " +
            #region header
                    "<header> " +
                    "   <div class=\"logoBox\"> " +
                    "       <div class=\"npcLogo\"></div> " +
                    "       <div class=\"customerLogo\"></div> " +
                    "   </div> " +
                        $"<h2>Протокол N {reportData.ProtocolNumber}</h2> " +
                        "<hr/> " +
                        "<div class=\"about\"> " +
                            $"<p class=\"date\"><span>от {date}</span></p> " +
                            "<br/> " +
                            $"<p>{_locoType}: <span>{_locoSeriesNumber}</span></p> " +
                        "</div> " +
                    "</header> " +
            #endregion

            #region article
                    "<article> ");

            if (!string.IsNullOrEmpty(reportData.PerformerINS))
            {
                htmlCode.Append(
                    "<br/><br/> " +
                    "<p class=\"tableTitle\">1. Сопротивление изоляции:</p> " +
                    "<table> " +
                        "<tr> " +
                            "<th>Сопротивление изоляции</th> " +
                            "<th class=\"lastColumn\">Значение</th> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Силовая цепь и Корпус</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[0]}</td> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Силовая цепь и Цепь управления</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[1]}</td> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Цепь управления и Корпус</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[2]}</td> " +
                        "</tr> " +
                    "</table> " +
                    $"<p class=\"measuredBy\">{reportData.PerformerINS}</p> ");
            }

            if (!string.IsNullOrEmpty(reportData.PerformerUBK))
            {
                htmlCode.Append(
                    "<br/><br/> " +
                    "<p class=\"tableTitle\">2. Возвратное напряжение:</p> " +
                    "<table> " +
                        "<tr> " +
                            "<th>Возвратное напряжение</th> " +
                            "<th class=\"lastColumn\">Значение</th> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Силовая цепь и Корпус</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[3]}</td> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Силовая цепь и Цепь управления</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[4]}</td> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Цепь управления и Корпус</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[5]}</td> " +
                        "</tr> " +
                    "</table> " +
                    $"<p class=\"measuredBy\">{reportData.PerformerUBK}</p> ");
            }

            if (!string.IsNullOrEmpty(reportData.PerformerSE))
            {
                htmlCode.Append(
                    "<br/><br/> " +
                    "<p class=\"tableTitle\">3. Сопротивление цепей управления при проверке секвенции:</p> " +
                    "<table> " +
                        "<tr> " +
                            "<th>Схемы управления</th> " +
                            "<th class=\"lastColumn\">Значение</th> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Пуск дизеля</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[6]}</td> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Холостой ход</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[7]}</td> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Полное возбуждение 1</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[8]}</td> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Полное возбуждение 2</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[9]}</td> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Полное возбуждение 3</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[10]}</td> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Полное возбуждение 4</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[11]}</td> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Полное возбуждение 5</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[12]}</td> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Полное возбуждение 6</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[13]}</td> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Полное возбуждение 7</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[14]}</td> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Полное возбуждение 8</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[15]}</td> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Ослабление возбуждения 1 ступень</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[16]}</td> " +
                        "</tr> " +
                        "<tr> " +
                            "<td>Ослабление возбуждения 2 ступень</td> " +
                            $"<td class=\"lastColumn\">{_tableCellValues[17]}</td> " +
                        "</tr> " +
                    "</table> " +
                    $"<p class=\"measuredBy\">{reportData.PerformerSE}</p> ");
            }

            htmlCode.Append(
                "<br/><br/> " +
                "</article> " +
            #endregion

                "</body> " +
                "</html>");

            return htmlCode.ToString();
        }

        private async Task<string> CreateTempPlotPDF()
        {
            string applicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = $@"{applicationDataPath}\NPC\tempPlot.pdf";

            await Task.Run(() =>
            {
                using (var stream = File.Create(path))
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    var exporter = new OxyPlot.SkiaSharp.PdfExporter { Width = 835, Height = 591 }; //.:: A4 in points (1 point = 1/72 inch)
                    _model.Subtitle = $"{_locoType} {_locoSeriesNumber}";
                    _model.TextColor = OxyColor.FromRgb(0, 0, 0);
                    exporter.Export(_model, stream);

                    _model.TextColor = _mainPage.isNight ? OxyColor.FromRgb(243, 254, 255) : OxyColor.FromRgb(40, 90, 0);
                }
            });

            return path;
        }

        private void DeleteTemporaryFiles(List<string> files)
        {
            try
            {
                foreach (var filePath in files)
                {
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                }
            }
            catch (Exception)
            {
                //.:: Запись в логи об ошибке
            }
        }

        private DateTime PopDate(string data)
        {
            string date = data.Split(';')[1];

            return DateTime.Parse(date);
        }

        private void DisplayTables(MeasurementsCheckingStruct measureChecking, int tablesCount)
        {
            if (measureChecking.ins.isInStock)
            {
                tableTitle1.Visible = true;
                insTable.Visible = true;
                insMeasuredBy.Visible = true;
            }

            if (measureChecking.ubk.isInStock)
            {
                tableTitle2.Visible = true;
                ubkTable.Visible = true;
                ubkMeasuredBy.Visible = true;
            }

            if (measureChecking.se1.isInStock || measureChecking.se2.isInStock || measureChecking.se3.isInStock || measureChecking.se4.isInStock)
            {
                tableTitle3.Visible = true;
                seTable.Visible = true;
                seMeasuredBy.Visible = true;
            }

            SetTableLocation(tablesCount);
        }

        private void SetTableLocation(int count)
        {
            int x;
            int y;

            if (count == 1)
            {
                foreach (var control in panel.Controls)
                {
                    if (control is TableLayoutPanel table && table.Visible)
                    {
                        x = panel.Width / 2 - table.Width / 2;
                        y = 126;
                        table.Location = new Point(x, y);

                        foreach (var ctrl in panel.Controls)
                            if (ctrl is Label label && label.Tag!.Equals(table.Tag))
                                label.Location = new Point(x - 3, y - 27);
                    }
                }
            }

            if (count == 2)
            {
                bool isFirstTablePublished = false;
                int savedWidth = 0;

                foreach (var control in panel.Controls)
                {
                    if (control is TableLayoutPanel table && table.Visible)
                    {
                        if (!isFirstTablePublished)
                        {
                            x = 12;
                            savedWidth += table.Width;
                            isFirstTablePublished = true;
                        }
                        else
                            x = 32 + savedWidth;

                        y = 126;
                        table.Location = new Point(x, y);

                        foreach (var ctrl in panel.Controls)
                            if (ctrl is Label label && label.Tag!.Equals(table.Tag))
                                label.Location = new Point(x - 3, y - 27);
                    }
                }
            }

            foreach (var control in panel.Controls)
            {
                if (control is TableLayoutPanel table && table.Visible)
                {
                    string feature = table.Name.Substring(0, 2);
                    foreach (var ctrl in panel.Controls)
                    {
                        if (ctrl is Label label && label.Name.Substring(0, 2).Equals(feature))
                        {
                            x = table.Location.X + table.Width - label.Width;
                            y = table.Location.Y + table.Height + 4;
                            label.Location = new Point(x, y);
                        }
                    }
                }
            }
        }
    }
}
