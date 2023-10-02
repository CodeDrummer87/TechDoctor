using System.Security.Permissions;

namespace Presentation.Forms
{
    partial class MainPage
    {
        public class VerticalProgressBar : ProgressBar
        {
            protected override CreateParams CreateParams
            {
                get
                {
                    new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();

                    CreateParams cp = base.CreateParams;
                    cp.Style |= 0x04;
                    return cp;
                }
            }

            public VerticalProgressBar()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                if (ProgressBarRenderer.IsSupported)
                {
                    ProgressBarRenderer.DrawVerticalBar(e.Graphics, e.ClipRectangle);

                    const int HORIZ_OFFSET = 3;
                    const int VERT_OFFSET = 2;

                    if (this.Minimum == this.Maximum || (this.Value - Minimum) == 0 ||
                            this.Height < 2 * VERT_OFFSET || this.Width < 2 * VERT_OFFSET)
                        return;

                    int barHeight = (this.Value - this.Minimum) * this.Height / (this.Maximum - this.Minimum);
                    barHeight = Math.Min(barHeight, this.Height - 2 * VERT_OFFSET);
                    int barWidth = this.Width - 2 * HORIZ_OFFSET;

                    if (this.RightToLeftLayout && this.RightToLeft == System.Windows.Forms.RightToLeft.No)
                    {
                        ProgressBarRenderer.DrawVerticalChunks(e.Graphics,
                                new Rectangle(HORIZ_OFFSET, VERT_OFFSET, barWidth, barHeight));
                    }
                    else
                    {
                        int blockHeight = 10;
                        int wholeBarHeight = Convert.ToInt32(barHeight / blockHeight) * blockHeight;
                        int wholeBarY = this.Height - wholeBarHeight - VERT_OFFSET;
                        int restBarHeight = barHeight % blockHeight;
                        int restBarY = this.Height - barHeight - VERT_OFFSET;
                        ProgressBarRenderer.DrawVerticalChunks(e.Graphics,
                            new Rectangle(HORIZ_OFFSET, wholeBarY, barWidth, wholeBarHeight));
                        ProgressBarRenderer.DrawVerticalChunks(e.Graphics,
                            new Rectangle(HORIZ_OFFSET, restBarY, barWidth, restBarHeight));
                    }
                }

                base.OnPaint(e);
            }
        }

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            logoBox = new PictureBox();
            allDataFromDevice = new Label();
            mainPageToolTip = new ToolTip(components);
            allDataFromDb = new Label();
            clearDeviceMemoryButton = new Label();
            addDataFromFile = new Label();
            settings = new Label();
            npcptLinkLabel = new LinkLabel();
            dataReverseButton = new PictureBox();
            themeSwitcher = new PictureBox();
            collapseAppBox = new PictureBox();
            quitAppButton = new PictureBox();
            sidePanel = new Panel();
            mainPanel = new Panel();
            dataPanel = new Panel();
            panel = new Panel();
            tableScrollProgressRight = new VerticalProgressBar();
            tableScrollProgressLeft = new VerticalProgressBar();
            progressBar = new ProgressBar();
            footerTablePanel = new Panel();
            tableCurrentMessage = new Label();
            headerTablePanel = new Panel();
            headerTable = new TableLayoutPanel();
            headerTableFourth = new Label();
            headerTableThird = new Label();
            headerTableSecond = new Label();
            headerTableFirst = new Label();
            headerTableFifth = new Label();
            footerPanel = new Panel();
            panel1 = new Panel();
            currentMessage = new Label();
            headerPanel = new Panel();
            searchPanel = new Panel();
            panelMiddle = new Panel();
            searchCondition = new Label();
            rightPartSearchPanel = new Panel();
            searchText = new TextBox();
            leftPartSearchPanel = new Panel();
            searchLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataReverseButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)themeSwitcher).BeginInit();
            ((System.ComponentModel.ISupportInitialize)collapseAppBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)quitAppButton).BeginInit();
            sidePanel.SuspendLayout();
            mainPanel.SuspendLayout();
            dataPanel.SuspendLayout();
            panel.SuspendLayout();
            footerTablePanel.SuspendLayout();
            headerTablePanel.SuspendLayout();
            headerTable.SuspendLayout();
            footerPanel.SuspendLayout();
            panel1.SuspendLayout();
            headerPanel.SuspendLayout();
            searchPanel.SuspendLayout();
            panelMiddle.SuspendLayout();
            rightPartSearchPanel.SuspendLayout();
            leftPartSearchPanel.SuspendLayout();
            SuspendLayout();
            // 
            // logoBox
            // 
            logoBox.Cursor = Cursors.Hand;
            logoBox.Dock = DockStyle.Top;
            logoBox.Image = Properties.Resources.logo;
            logoBox.Location = new Point(5, 5);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(275, 107);
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 2;
            logoBox.TabStop = false;
            mainPageToolTip.SetToolTip(logoBox, "Посетить сайт НПЦ \"ПромТех\"");
            logoBox.Click += NpcptLinkLabelClicked;
            logoBox.MouseDown += ThisForm_MouseDown;
            logoBox.MouseMove += ThisForm_MouseMove;
            // 
            // allDataFromDevice
            // 
            allDataFromDevice.BackColor = Color.DarkSlateGray;
            allDataFromDevice.BorderStyle = BorderStyle.Fixed3D;
            allDataFromDevice.Cursor = Cursors.Hand;
            allDataFromDevice.Enabled = false;
            allDataFromDevice.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            allDataFromDevice.ForeColor = Color.Wheat;
            allDataFromDevice.Location = new Point(31, 197);
            allDataFromDevice.Name = "allDataFromDevice";
            allDataFromDevice.Size = new Size(222, 55);
            allDataFromDevice.TabIndex = 3;
            allDataFromDevice.Text = "Загрузить данные с устройства";
            allDataFromDevice.TextAlign = ContentAlignment.MiddleCenter;
            mainPageToolTip.SetToolTip(allDataFromDevice, "Загрузить и сохранить данные с подключённого устройства");
            allDataFromDevice.Click += GetAllDataFromDeviceButton_Click;
            allDataFromDevice.MouseEnter += Button_MouseEnter;
            allDataFromDevice.MouseLeave += Button_MouseLeave;
            // 
            // allDataFromDb
            // 
            allDataFromDb.BackColor = Color.DarkSlateGray;
            allDataFromDb.BorderStyle = BorderStyle.Fixed3D;
            allDataFromDb.Cursor = Cursors.Hand;
            allDataFromDb.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            allDataFromDb.ForeColor = Color.Wheat;
            allDataFromDb.Location = new Point(31, 385);
            allDataFromDb.Name = "allDataFromDb";
            allDataFromDb.Size = new Size(222, 55);
            allDataFromDb.TabIndex = 12;
            allDataFromDb.Text = "Загрузить данные из Базы Данных";
            allDataFromDb.TextAlign = ContentAlignment.MiddleCenter;
            mainPageToolTip.SetToolTip(allDataFromDb, "Загрузить сохранённые данные");
            allDataFromDb.Click += GetAllDataFromDbButton_Click;
            allDataFromDb.MouseEnter += Button_MouseEnter;
            allDataFromDb.MouseLeave += Button_MouseLeave;
            // 
            // clearDeviceMemoryButton
            // 
            clearDeviceMemoryButton.BackColor = Color.DarkSlateGray;
            clearDeviceMemoryButton.BorderStyle = BorderStyle.Fixed3D;
            clearDeviceMemoryButton.Cursor = Cursors.Hand;
            clearDeviceMemoryButton.Enabled = false;
            clearDeviceMemoryButton.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            clearDeviceMemoryButton.ForeColor = Color.Wheat;
            clearDeviceMemoryButton.Location = new Point(31, 252);
            clearDeviceMemoryButton.Name = "clearDeviceMemoryButton";
            clearDeviceMemoryButton.Size = new Size(222, 63);
            clearDeviceMemoryButton.TabIndex = 13;
            clearDeviceMemoryButton.Text = "Очистить память устройства";
            clearDeviceMemoryButton.TextAlign = ContentAlignment.MiddleCenter;
            mainPageToolTip.SetToolTip(clearDeviceMemoryButton, "Последние данные выгружены. Доступна очистка памяти устройства");
            clearDeviceMemoryButton.MouseEnter += Button_MouseEnter;
            clearDeviceMemoryButton.MouseLeave += Button_MouseLeave;
            // 
            // addDataFromFile
            // 
            addDataFromFile.BackColor = Color.DarkSlateGray;
            addDataFromFile.BorderStyle = BorderStyle.Fixed3D;
            addDataFromFile.Cursor = Cursors.Hand;
            addDataFromFile.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            addDataFromFile.ForeColor = Color.Wheat;
            addDataFromFile.Location = new Point(31, 315);
            addDataFromFile.Name = "addDataFromFile";
            addDataFromFile.Size = new Size(222, 55);
            addDataFromFile.TabIndex = 19;
            addDataFromFile.Text = "Загрузить данные из файла CSV";
            addDataFromFile.TextAlign = ContentAlignment.MiddleCenter;
            mainPageToolTip.SetToolTip(addDataFromFile, "Загрузить данные в программу из файла");
            addDataFromFile.Click += GetDataFromFile_Click;
            addDataFromFile.MouseEnter += Button_MouseEnter;
            addDataFromFile.MouseLeave += Button_MouseLeave;
            // 
            // settings
            // 
            settings.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            settings.BackColor = Color.DarkSlateGray;
            settings.BorderStyle = BorderStyle.Fixed3D;
            settings.Cursor = Cursors.Hand;
            settings.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            settings.ForeColor = Color.Wheat;
            settings.Location = new Point(31, 761);
            settings.Name = "settings";
            settings.Size = new Size(222, 40);
            settings.TabIndex = 23;
            settings.Text = "Настройки программы";
            settings.TextAlign = ContentAlignment.MiddleCenter;
            mainPageToolTip.SetToolTip(settings, "Перейти к настройкам программы");
            settings.Click += SettingsButton_Click;
            settings.MouseEnter += Button_MouseEnter;
            settings.MouseLeave += Button_MouseLeave;
            // 
            // npcptLinkLabel
            // 
            npcptLinkLabel.ActiveLinkColor = Color.OrangeRed;
            npcptLinkLabel.AutoSize = true;
            npcptLinkLabel.Cursor = Cursors.Hand;
            npcptLinkLabel.Dock = DockStyle.Fill;
            npcptLinkLabel.Font = new Font("Courier New", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            npcptLinkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
            npcptLinkLabel.LinkColor = Color.DimGray;
            npcptLinkLabel.Location = new Point(5, 13);
            npcptLinkLabel.Name = "npcptLinkLabel";
            npcptLinkLabel.Size = new Size(109, 21);
            npcptLinkLabel.TabIndex = 10;
            npcptLinkLabel.TabStop = true;
            npcptLinkLabel.Text = "npcpt.com";
            npcptLinkLabel.TextAlign = ContentAlignment.MiddleCenter;
            mainPageToolTip.SetToolTip(npcptLinkLabel, "Перейти на сайт разработчика");
            npcptLinkLabel.Click += NpcptLinkLabelClicked;
            // 
            // dataReverseButton
            // 
            dataReverseButton.Cursor = Cursors.Hand;
            dataReverseButton.Enabled = false;
            dataReverseButton.Image = Properties.Resources.data_reverse;
            dataReverseButton.Location = new Point(653, 8);
            dataReverseButton.Name = "dataReverseButton";
            dataReverseButton.Size = new Size(43, 51);
            dataReverseButton.SizeMode = PictureBoxSizeMode.Zoom;
            dataReverseButton.TabIndex = 20;
            dataReverseButton.TabStop = false;
            dataReverseButton.Tag = "DESC";
            mainPageToolTip.SetToolTip(dataReverseButton, "Реверс актуальности данных");
            dataReverseButton.Click += DataReverseButton_Click;
            dataReverseButton.MouseEnter += DataReverseButton_MouseEnter;
            dataReverseButton.MouseLeave += DataReverseButton_MouseLeave;
            // 
            // themeSwitcher
            // 
            themeSwitcher.Cursor = Cursors.Hand;
            themeSwitcher.Dock = DockStyle.Right;
            themeSwitcher.Image = Properties.Resources.dark_theme;
            themeSwitcher.Location = new Point(1140, 5);
            themeSwitcher.Name = "themeSwitcher";
            themeSwitcher.Size = new Size(43, 51);
            themeSwitcher.SizeMode = PictureBoxSizeMode.Zoom;
            themeSwitcher.TabIndex = 22;
            themeSwitcher.TabStop = false;
            mainPageToolTip.SetToolTip(themeSwitcher, "Переключить на ночной режим");
            themeSwitcher.Click += ThemeSwitcher_Click;
            themeSwitcher.MouseEnter += ThemeSwitcher_MouseEnter;
            themeSwitcher.MouseLeave += ThemeSwith_MouseLeave;
            // 
            // collapseAppBox
            // 
            collapseAppBox.Cursor = Cursors.Hand;
            collapseAppBox.Dock = DockStyle.Right;
            collapseAppBox.Image = Properties.Resources.collapse;
            collapseAppBox.Location = new Point(1183, 5);
            collapseAppBox.Name = "collapseAppBox";
            collapseAppBox.Size = new Size(43, 51);
            collapseAppBox.SizeMode = PictureBoxSizeMode.Zoom;
            collapseAppBox.TabIndex = 18;
            collapseAppBox.TabStop = false;
            mainPageToolTip.SetToolTip(collapseAppBox, "Свернуть программу");
            collapseAppBox.Click += CollapseAppBox_Click;
            collapseAppBox.MouseEnter += CollapseAppBox_MouseEnter;
            collapseAppBox.MouseLeave += CollapseAppBox_MouseLeave;
            // 
            // quitAppButton
            // 
            quitAppButton.Cursor = Cursors.Hand;
            quitAppButton.Dock = DockStyle.Right;
            quitAppButton.Image = Properties.Resources.quit;
            quitAppButton.Location = new Point(1226, 5);
            quitAppButton.Name = "quitAppButton";
            quitAppButton.Size = new Size(43, 51);
            quitAppButton.SizeMode = PictureBoxSizeMode.Zoom;
            quitAppButton.TabIndex = 10;
            quitAppButton.TabStop = false;
            mainPageToolTip.SetToolTip(quitAppButton, "Выйти из программы");
            quitAppButton.Click += QuitApplication;
            quitAppButton.MouseEnter += QuitAppButton_MouseEnter;
            quitAppButton.MouseLeave += QuitAppButton_MouseLeave;
            // 
            // sidePanel
            // 
            sidePanel.Controls.Add(settings);
            sidePanel.Controls.Add(logoBox);
            sidePanel.Controls.Add(allDataFromDevice);
            sidePanel.Controls.Add(addDataFromFile);
            sidePanel.Controls.Add(clearDeviceMemoryButton);
            sidePanel.Controls.Add(allDataFromDb);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.Location = new Point(5, 5);
            sidePanel.Margin = new Padding(3, 4, 3, 4);
            sidePanel.Name = "sidePanel";
            sidePanel.Padding = new Padding(5);
            sidePanel.Size = new Size(285, 818);
            sidePanel.TabIndex = 23;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(dataPanel);
            mainPanel.Controls.Add(footerPanel);
            mainPanel.Controls.Add(headerPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(290, 5);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(5);
            mainPanel.Size = new Size(1284, 818);
            mainPanel.TabIndex = 24;
            // 
            // dataPanel
            // 
            dataPanel.Controls.Add(panel);
            dataPanel.Controls.Add(footerTablePanel);
            dataPanel.Controls.Add(headerTablePanel);
            dataPanel.Dock = DockStyle.Fill;
            dataPanel.Location = new Point(5, 66);
            dataPanel.Margin = new Padding(3, 4, 3, 4);
            dataPanel.Name = "dataPanel";
            dataPanel.Padding = new Padding(5, 13, 5, 13);
            dataPanel.Size = new Size(1274, 686);
            dataPanel.TabIndex = 13;
            // 
            // panel
            // 
            panel.Controls.Add(tableScrollProgressRight);
            panel.Controls.Add(tableScrollProgressLeft);
            panel.Controls.Add(progressBar);
            panel.Dock = DockStyle.Top;
            panel.Location = new Point(5, 69);
            panel.Margin = new Padding(3, 4, 3, 4);
            panel.Name = "panel";
            panel.Padding = new Padding(2, 0, 2, 0);
            panel.Size = new Size(1264, 545);
            panel.TabIndex = 2;
            // 
            // tableScrollProgressRight
            // 
            tableScrollProgressRight.Dock = DockStyle.Right;
            tableScrollProgressRight.Location = new Point(1252, 0);
            tableScrollProgressRight.Name = "tableScrollProgressRight";
            tableScrollProgressRight.RightToLeftLayout = true;
            tableScrollProgressRight.Size = new Size(10, 545);
            tableScrollProgressRight.TabIndex = 8;
            tableScrollProgressRight.Visible = false;
            // 
            // tableScrollProgressLeft
            // 
            tableScrollProgressLeft.Dock = DockStyle.Left;
            tableScrollProgressLeft.Location = new Point(2, 0);
            tableScrollProgressLeft.Name = "tableScrollProgressLeft";
            tableScrollProgressLeft.RightToLeftLayout = true;
            tableScrollProgressLeft.Size = new Size(10, 545);
            tableScrollProgressLeft.TabIndex = 7;
            tableScrollProgressLeft.Visible = false;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(413, 249);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(397, 29);
            progressBar.Step = 1;
            progressBar.TabIndex = 6;
            progressBar.Visible = false;
            // 
            // footerTablePanel
            // 
            footerTablePanel.Controls.Add(tableCurrentMessage);
            footerTablePanel.Dock = DockStyle.Bottom;
            footerTablePanel.Location = new Point(5, 617);
            footerTablePanel.Margin = new Padding(3, 4, 3, 4);
            footerTablePanel.Name = "footerTablePanel";
            footerTablePanel.Padding = new Padding(86, 5, 86, 5);
            footerTablePanel.Size = new Size(1264, 56);
            footerTablePanel.TabIndex = 1;
            // 
            // tableCurrentMessage
            // 
            tableCurrentMessage.Dock = DockStyle.Fill;
            tableCurrentMessage.Font = new Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            tableCurrentMessage.ForeColor = Color.DarkSlateGray;
            tableCurrentMessage.Location = new Point(86, 5);
            tableCurrentMessage.Name = "tableCurrentMessage";
            tableCurrentMessage.Size = new Size(1092, 46);
            tableCurrentMessage.TabIndex = 3;
            tableCurrentMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerTablePanel
            // 
            headerTablePanel.Controls.Add(headerTable);
            headerTablePanel.Dock = DockStyle.Top;
            headerTablePanel.Location = new Point(5, 13);
            headerTablePanel.Margin = new Padding(3, 4, 3, 4);
            headerTablePanel.Name = "headerTablePanel";
            headerTablePanel.Padding = new Padding(11, 5, 11, 5);
            headerTablePanel.Size = new Size(1264, 56);
            headerTablePanel.TabIndex = 0;
            // 
            // headerTable
            // 
            headerTable.ColumnCount = 5;
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23F));
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            headerTable.Controls.Add(headerTableFourth, 3, 0);
            headerTable.Controls.Add(headerTableThird, 2, 0);
            headerTable.Controls.Add(headerTableSecond, 1, 0);
            headerTable.Controls.Add(headerTableFirst, 0, 0);
            headerTable.Controls.Add(headerTableFifth, 4, 0);
            headerTable.Dock = DockStyle.Fill;
            headerTable.Location = new Point(11, 5);
            headerTable.Name = "headerTable";
            headerTable.RowCount = 1;
            headerTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            headerTable.Size = new Size(1242, 46);
            headerTable.TabIndex = 1;
            // 
            // headerTableFourth
            // 
            headerTableFourth.AutoSize = true;
            headerTableFourth.BackColor = Color.DarkSlateGray;
            headerTableFourth.Dock = DockStyle.Fill;
            headerTableFourth.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            headerTableFourth.ForeColor = Color.AntiqueWhite;
            headerTableFourth.Location = new Point(746, 0);
            headerTableFourth.Name = "headerTableFourth";
            headerTableFourth.Size = new Size(279, 46);
            headerTableFourth.TabIndex = 4;
            headerTableFourth.Text = "Вид измерения";
            headerTableFourth.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerTableThird
            // 
            headerTableThird.AutoSize = true;
            headerTableThird.BackColor = Color.DarkSlateGray;
            headerTableThird.Dock = DockStyle.Fill;
            headerTableThird.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            headerTableThird.ForeColor = Color.AntiqueWhite;
            headerTableThird.Location = new Point(399, 0);
            headerTableThird.Name = "headerTableThird";
            headerTableThird.Size = new Size(341, 46);
            headerTableThird.TabIndex = 3;
            headerTableThird.Text = "Значения измерений";
            headerTableThird.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerTableSecond
            // 
            headerTableSecond.AutoSize = true;
            headerTableSecond.BackColor = Color.DarkSlateGray;
            headerTableSecond.Dock = DockStyle.Fill;
            headerTableSecond.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            headerTableSecond.ForeColor = Color.AntiqueWhite;
            headerTableSecond.Location = new Point(201, 0);
            headerTableSecond.Name = "headerTableSecond";
            headerTableSecond.Size = new Size(192, 46);
            headerTableSecond.TabIndex = 2;
            headerTableSecond.Text = "Таб.N сотрудника";
            headerTableSecond.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerTableFirst
            // 
            headerTableFirst.AutoSize = true;
            headerTableFirst.BackColor = Color.DarkSlateGray;
            headerTableFirst.Dock = DockStyle.Fill;
            headerTableFirst.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            headerTableFirst.ForeColor = Color.AntiqueWhite;
            headerTableFirst.Location = new Point(3, 0);
            headerTableFirst.Name = "headerTableFirst";
            headerTableFirst.Size = new Size(192, 46);
            headerTableFirst.TabIndex = 1;
            headerTableFirst.Text = "Локомотив";
            headerTableFirst.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerTableFifth
            // 
            headerTableFifth.AutoSize = true;
            headerTableFifth.BackColor = Color.DarkSlateGray;
            headerTableFifth.Dock = DockStyle.Fill;
            headerTableFifth.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            headerTableFifth.ForeColor = Color.AntiqueWhite;
            headerTableFifth.Location = new Point(1031, 0);
            headerTableFifth.Name = "headerTableFifth";
            headerTableFifth.Size = new Size(208, 46);
            headerTableFifth.TabIndex = 5;
            headerTableFifth.Text = "Дата сохранения";
            headerTableFifth.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // footerPanel
            // 
            footerPanel.Controls.Add(panel1);
            footerPanel.Controls.Add(currentMessage);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(5, 752);
            footerPanel.Margin = new Padding(3, 4, 3, 4);
            footerPanel.Name = "footerPanel";
            footerPanel.Padding = new Padding(10, 5, 5, 5);
            footerPanel.Size = new Size(1274, 61);
            footerPanel.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.Controls.Add(npcptLinkLabel);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1129, 5);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5, 13, 5, 13);
            panel1.Size = new Size(140, 51);
            panel1.TabIndex = 7;
            // 
            // currentMessage
            // 
            currentMessage.Dock = DockStyle.Fill;
            currentMessage.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            currentMessage.Location = new Point(10, 5);
            currentMessage.Name = "currentMessage";
            currentMessage.Size = new Size(1259, 51);
            currentMessage.TabIndex = 11;
            currentMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(dataReverseButton);
            headerPanel.Controls.Add(themeSwitcher);
            headerPanel.Controls.Add(searchPanel);
            headerPanel.Controls.Add(collapseAppBox);
            headerPanel.Controls.Add(quitAppButton);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(5, 5);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(5);
            headerPanel.Size = new Size(1274, 61);
            headerPanel.TabIndex = 11;
            headerPanel.Paint += headerPanel_Paint;
            headerPanel.MouseDown += ThisForm_MouseDown;
            headerPanel.MouseMove += ThisForm_MouseMove;
            // 
            // searchPanel
            // 
            searchPanel.BackColor = Color.DarkSlateGray;
            searchPanel.Controls.Add(panelMiddle);
            searchPanel.Controls.Add(rightPartSearchPanel);
            searchPanel.Controls.Add(leftPartSearchPanel);
            searchPanel.Dock = DockStyle.Left;
            searchPanel.Location = new Point(5, 5);
            searchPanel.Name = "searchPanel";
            searchPanel.Padding = new Padding(11, 8, 11, 8);
            searchPanel.Size = new Size(555, 51);
            searchPanel.TabIndex = 17;
            searchPanel.MouseDown += ThisForm_MouseDown;
            searchPanel.MouseMove += ThisForm_MouseMove;
            // 
            // panelMiddle
            // 
            panelMiddle.Controls.Add(searchCondition);
            panelMiddle.Dock = DockStyle.Fill;
            panelMiddle.Location = new Point(127, 8);
            panelMiddle.Name = "panelMiddle";
            panelMiddle.Size = new Size(206, 35);
            panelMiddle.TabIndex = 18;
            // 
            // searchCondition
            // 
            searchCondition.Cursor = Cursors.Hand;
            searchCondition.Dock = DockStyle.Fill;
            searchCondition.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            searchCondition.ForeColor = Color.YellowGreen;
            searchCondition.Location = new Point(0, 0);
            searchCondition.Name = "searchCondition";
            searchCondition.Size = new Size(206, 35);
            searchCondition.TabIndex = 15;
            searchCondition.Text = "локомотиву";
            searchCondition.TextAlign = ContentAlignment.MiddleCenter;
            searchCondition.Click += SelectSearchCondition;
            // 
            // rightPartSearchPanel
            // 
            rightPartSearchPanel.Controls.Add(searchText);
            rightPartSearchPanel.Dock = DockStyle.Right;
            rightPartSearchPanel.Location = new Point(333, 8);
            rightPartSearchPanel.Margin = new Padding(0);
            rightPartSearchPanel.Name = "rightPartSearchPanel";
            rightPartSearchPanel.Padding = new Padding(2);
            rightPartSearchPanel.Size = new Size(211, 35);
            rightPartSearchPanel.TabIndex = 17;
            // 
            // searchText
            // 
            searchText.Dock = DockStyle.Fill;
            searchText.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            searchText.Location = new Point(2, 2);
            searchText.Margin = new Padding(0);
            searchText.Name = "searchText";
            searchText.Size = new Size(207, 28);
            searchText.TabIndex = 16;
            searchText.TextChanged += GetAllData;
            searchText.KeyPress += CheckKeyPress;
            // 
            // leftPartSearchPanel
            // 
            leftPartSearchPanel.Controls.Add(searchLabel);
            leftPartSearchPanel.Dock = DockStyle.Left;
            leftPartSearchPanel.Location = new Point(11, 8);
            leftPartSearchPanel.Margin = new Padding(3, 4, 3, 4);
            leftPartSearchPanel.Name = "leftPartSearchPanel";
            leftPartSearchPanel.Size = new Size(116, 35);
            leftPartSearchPanel.TabIndex = 17;
            // 
            // searchLabel
            // 
            searchLabel.Dock = DockStyle.Fill;
            searchLabel.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            searchLabel.ForeColor = Color.LemonChiffon;
            searchLabel.Location = new Point(0, 0);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(116, 35);
            searchLabel.TabIndex = 14;
            searchLabel.Text = "Поиск по";
            searchLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1579, 828);
            Controls.Add(mainPanel);
            Controls.Add(sidePanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainPage";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главная страница";
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataReverseButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)themeSwitcher).EndInit();
            ((System.ComponentModel.ISupportInitialize)collapseAppBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)quitAppButton).EndInit();
            sidePanel.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            dataPanel.ResumeLayout(false);
            panel.ResumeLayout(false);
            footerTablePanel.ResumeLayout(false);
            headerTablePanel.ResumeLayout(false);
            headerTable.ResumeLayout(false);
            headerTable.PerformLayout();
            footerPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            headerPanel.ResumeLayout(false);
            searchPanel.ResumeLayout(false);
            panelMiddle.ResumeLayout(false);
            rightPartSearchPanel.ResumeLayout(false);
            rightPartSearchPanel.PerformLayout();
            leftPartSearchPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private PictureBox logoBox;
        private Label allDataFromDevice;
        private ToolTip mainPageToolTip;
        private Label allDataFromDb;
        private Label clearDeviceMemoryButton;
        private Label addDataFromFile;
        private Label settings;
        private Panel sidePanel;
        private Panel mainPanel;
        private Panel headerPanel;
        private PictureBox dataReverseButton;
        private PictureBox themeSwitcher;
        private Panel searchPanel;
        private Label searchLabel;
        private TextBox searchText;
        private Label searchCondition;
        private PictureBox collapseAppBox;
        private PictureBox quitAppButton;
        private Panel footerPanel;
        private Label currentMessage;
        private LinkLabel npcptLinkLabel;
        private Panel dataPanel;
        private Panel headerTablePanel;
        private TableLayoutPanel headerTable;
        private Label headerTableFourth;
        private Label headerTableThird;
        private Label headerTableSecond;
        private Label headerTableFirst;
        private Label headerTableFifth;
        private Panel footerTablePanel;
        private Label tableCurrentMessage;
        private Panel panel;
        private VerticalProgressBar tableScrollProgressLeft;
        private VerticalProgressBar tableScrollProgressRight;
        private ProgressBar progressBar;
        private Panel panel1;
        private Panel leftPartSearchPanel;
        private Panel rightPartSearchPanel;
        private Panel panelMiddle;
    }
}