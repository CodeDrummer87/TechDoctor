namespace Presentation.View
{
    partial class AllMeasurementsFromLocoForm
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllMeasurementsFromLocoForm));
            logoBox = new PictureBox();
            headerDefault = new Label();
            headerLoco = new Label();
            insTable = new TableLayoutPanel();
            ins3Value = new Label();
            ins3lab = new Label();
            ins2Value = new Label();
            ins2lab = new Label();
            ins1Value = new Label();
            ins1lab = new Label();
            headerLabel2 = new Label();
            headerLabel1 = new Label();
            tableTitle1 = new Label();
            panel = new Panel();
            seMeasuredBy = new Label();
            ubkMeasuredBy = new Label();
            insMeasuredBy = new Label();
            ubkTable = new TableLayoutPanel();
            ubk3Value = new Label();
            ubk3lab = new Label();
            ubk2Value = new Label();
            ubk2lab = new Label();
            ubk1Value = new Label();
            ubk1lab = new Label();
            headerLabel16 = new Label();
            headerLabel17 = new Label();
            tableTitle2 = new Label();
            seTable = new TableLayoutPanel();
            _se12Value = new Label();
            _se12lab = new Label();
            _se11Value = new Label();
            _se11lab = new Label();
            _se10Value = new Label();
            _se10lab = new Label();
            _se9Value = new Label();
            _se9lab = new Label();
            _se8Value = new Label();
            _se8lab = new Label();
            _se7Value = new Label();
            _se7lab = new Label();
            _se6Value = new Label();
            _se6lab = new Label();
            _se5Value = new Label();
            _se5lab = new Label();
            _se4Value = new Label();
            _se4lab = new Label();
            _se3Value = new Label();
            _se3lab = new Label();
            _se2Value = new Label();
            _se2lab = new Label();
            _se1Value = new Label();
            headerLabel24 = new Label();
            headerLabel25 = new Label();
            _se1lab = new Label();
            tableTitle3 = new Label();
            label14 = new Label();
            backToListBox = new PictureBox();
            toolTip = new ToolTip(components);
            createReportButton = new Label();
            collapseAppBox = new PictureBox();
            buildResistanceChartButton = new Label();
            quitAppButton = new PictureBox();
            currentMessage = new Label();
            plotTip = new Label();
            themeSwitcher = new PictureBox();
            savingDate = new Label();
            sidePanel = new Panel();
            headerPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            insTable.SuspendLayout();
            panel.SuspendLayout();
            ubkTable.SuspendLayout();
            seTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)backToListBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)collapseAppBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)quitAppButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)themeSwitcher).BeginInit();
            sidePanel.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // logoBox
            // 
            logoBox.Cursor = Cursors.Hand;
            logoBox.Dock = DockStyle.Top;
            logoBox.Image = Properties.Resources.logo;
            logoBox.Location = new Point(0, 0);
            logoBox.Margin = new Padding(3, 2, 3, 2);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(249, 80);
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 0;
            logoBox.TabStop = false;
            logoBox.Click += NpcptLinkLabelClicked;
            // 
            // headerDefault
            // 
            headerDefault.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point);
            headerDefault.ForeColor = Color.DarkSlateGray;
            headerDefault.Location = new Point(382, 9);
            headerDefault.Name = "headerDefault";
            headerDefault.Size = new Size(831, 43);
            headerDefault.TabIndex = 1;
            headerDefault.Text = "Данные о проведении измерений на электровозе";
            headerDefault.TextAlign = ContentAlignment.MiddleCenter;
            headerDefault.MouseDown += ThisForm_MouseDown;
            headerDefault.MouseMove += ThisForm_MouseMove;
            // 
            // headerLoco
            // 
            headerLoco.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point);
            headerLoco.ForeColor = Color.DarkSlateGray;
            headerLoco.Location = new Point(260, 52);
            headerLoco.Name = "headerLoco";
            headerLoco.Size = new Size(1082, 43);
            headerLoco.TabIndex = 2;
            headerLoco.Text = "ВЛ80т-854";
            headerLoco.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // insTable
            // 
            insTable.ColumnCount = 2;
            insTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            insTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            insTable.Controls.Add(ins3Value, 1, 3);
            insTable.Controls.Add(ins3lab, 0, 3);
            insTable.Controls.Add(ins2Value, 1, 2);
            insTable.Controls.Add(ins2lab, 0, 2);
            insTable.Controls.Add(ins1Value, 1, 1);
            insTable.Controls.Add(ins1lab, 0, 1);
            insTable.Controls.Add(headerLabel2, 1, 0);
            insTable.Controls.Add(headerLabel1, 0, 0);
            insTable.Location = new Point(10, 94);
            insTable.Margin = new Padding(3, 2, 3, 2);
            insTable.Name = "insTable";
            insTable.RowCount = 4;
            insTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            insTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            insTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            insTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            insTable.Size = new Size(481, 90);
            insTable.TabIndex = 3;
            insTable.Tag = "INS";
            // 
            // ins3Value
            // 
            ins3Value.AutoSize = true;
            ins3Value.BackColor = Color.Linen;
            ins3Value.Dock = DockStyle.Fill;
            ins3Value.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ins3Value.Location = new Point(315, 66);
            ins3Value.Name = "ins3Value";
            ins3Value.Size = new Size(163, 24);
            ins3Value.TabIndex = 10;
            ins3Value.Tag = "3";
            ins3Value.Text = "-";
            ins3Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ins3lab
            // 
            ins3lab.AutoSize = true;
            ins3lab.BackColor = Color.Linen;
            ins3lab.Dock = DockStyle.Fill;
            ins3lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ins3lab.Location = new Point(3, 66);
            ins3lab.Name = "ins3lab";
            ins3lab.Size = new Size(306, 24);
            ins3lab.TabIndex = 9;
            ins3lab.Tag = "3";
            ins3lab.Text = "Цепь управления и Корпус";
            ins3lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ins2Value
            // 
            ins2Value.AutoSize = true;
            ins2Value.BackColor = Color.AntiqueWhite;
            ins2Value.Dock = DockStyle.Fill;
            ins2Value.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ins2Value.Location = new Point(315, 44);
            ins2Value.Name = "ins2Value";
            ins2Value.Size = new Size(163, 22);
            ins2Value.TabIndex = 7;
            ins2Value.Tag = "2";
            ins2Value.Text = "-";
            ins2Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ins2lab
            // 
            ins2lab.AutoSize = true;
            ins2lab.BackColor = Color.AntiqueWhite;
            ins2lab.Dock = DockStyle.Fill;
            ins2lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ins2lab.Location = new Point(3, 44);
            ins2lab.Name = "ins2lab";
            ins2lab.Size = new Size(306, 22);
            ins2lab.TabIndex = 6;
            ins2lab.Tag = "2";
            ins2lab.Text = "Силовая цепь и Цепь управления";
            ins2lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ins1Value
            // 
            ins1Value.AutoSize = true;
            ins1Value.BackColor = Color.Linen;
            ins1Value.Dock = DockStyle.Fill;
            ins1Value.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ins1Value.Location = new Point(315, 22);
            ins1Value.Name = "ins1Value";
            ins1Value.Size = new Size(163, 22);
            ins1Value.TabIndex = 4;
            ins1Value.Tag = "1";
            ins1Value.Text = "-";
            ins1Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ins1lab
            // 
            ins1lab.AutoSize = true;
            ins1lab.BackColor = Color.Linen;
            ins1lab.Dock = DockStyle.Fill;
            ins1lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ins1lab.Location = new Point(3, 22);
            ins1lab.Name = "ins1lab";
            ins1lab.Size = new Size(306, 22);
            ins1lab.TabIndex = 3;
            ins1lab.Tag = "1";
            ins1lab.Text = "Силовая цепь и Корпус";
            ins1lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerLabel2
            // 
            headerLabel2.AutoSize = true;
            headerLabel2.BackColor = Color.DarkSlateGray;
            headerLabel2.Dock = DockStyle.Fill;
            headerLabel2.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            headerLabel2.ForeColor = Color.AntiqueWhite;
            headerLabel2.Location = new Point(315, 0);
            headerLabel2.Name = "headerLabel2";
            headerLabel2.Size = new Size(163, 22);
            headerLabel2.TabIndex = 1;
            headerLabel2.Text = "Значение";
            headerLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerLabel1
            // 
            headerLabel1.AutoSize = true;
            headerLabel1.BackColor = Color.DarkSlateGray;
            headerLabel1.Dock = DockStyle.Fill;
            headerLabel1.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            headerLabel1.ForeColor = Color.AntiqueWhite;
            headerLabel1.Location = new Point(3, 0);
            headerLabel1.Name = "headerLabel1";
            headerLabel1.Size = new Size(306, 22);
            headerLabel1.TabIndex = 0;
            headerLabel1.Text = "Сопротивление изоляции";
            headerLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableTitle1
            // 
            tableTitle1.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            tableTitle1.Location = new Point(13, 74);
            tableTitle1.Name = "tableTitle1";
            tableTitle1.Size = new Size(476, 20);
            tableTitle1.TabIndex = 0;
            tableTitle1.Tag = "INS";
            tableTitle1.Text = "Сопротивление изоляции";
            tableTitle1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.BackColor = SystemColors.GradientInactiveCaption;
            panel.Controls.Add(seMeasuredBy);
            panel.Controls.Add(ubkMeasuredBy);
            panel.Controls.Add(insMeasuredBy);
            panel.Controls.Add(ubkTable);
            panel.Controls.Add(tableTitle2);
            panel.Controls.Add(seTable);
            panel.Controls.Add(tableTitle3);
            panel.Controls.Add(tableTitle1);
            panel.Controls.Add(insTable);
            panel.Location = new Point(247, 89);
            panel.Margin = new Padding(3, 2, 3, 2);
            panel.Name = "panel";
            panel.Size = new Size(1110, 488);
            panel.TabIndex = 4;
            // 
            // seMeasuredBy
            // 
            seMeasuredBy.AutoSize = true;
            seMeasuredBy.Location = new Point(801, 392);
            seMeasuredBy.Name = "seMeasuredBy";
            seMeasuredBy.Size = new Size(58, 15);
            seMeasuredBy.TabIndex = 10;
            seMeasuredBy.Tag = "se";
            seMeasuredBy.Text = "измерил:";
            seMeasuredBy.Visible = false;
            // 
            // ubkMeasuredBy
            // 
            ubkMeasuredBy.AutoSize = true;
            ubkMeasuredBy.Location = new Point(236, 324);
            ubkMeasuredBy.Name = "ubkMeasuredBy";
            ubkMeasuredBy.Size = new Size(58, 15);
            ubkMeasuredBy.TabIndex = 9;
            ubkMeasuredBy.Tag = "ubk";
            ubkMeasuredBy.Text = "измерил:";
            ubkMeasuredBy.Visible = false;
            // 
            // insMeasuredBy
            // 
            insMeasuredBy.AutoSize = true;
            insMeasuredBy.Location = new Point(236, 184);
            insMeasuredBy.Name = "insMeasuredBy";
            insMeasuredBy.Size = new Size(58, 15);
            insMeasuredBy.TabIndex = 8;
            insMeasuredBy.Tag = "ins";
            insMeasuredBy.Text = "измерил:";
            insMeasuredBy.Visible = false;
            // 
            // ubkTable
            // 
            ubkTable.ColumnCount = 2;
            ubkTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            ubkTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            ubkTable.Controls.Add(ubk3Value, 1, 3);
            ubkTable.Controls.Add(ubk3lab, 0, 3);
            ubkTable.Controls.Add(ubk2Value, 1, 2);
            ubkTable.Controls.Add(ubk2lab, 0, 2);
            ubkTable.Controls.Add(ubk1Value, 1, 1);
            ubkTable.Controls.Add(ubk1lab, 0, 1);
            ubkTable.Controls.Add(headerLabel16, 1, 0);
            ubkTable.Controls.Add(headerLabel17, 0, 0);
            ubkTable.Location = new Point(10, 231);
            ubkTable.Margin = new Padding(3, 2, 3, 2);
            ubkTable.Name = "ubkTable";
            ubkTable.RowCount = 4;
            ubkTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            ubkTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            ubkTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            ubkTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            ubkTable.Size = new Size(481, 90);
            ubkTable.TabIndex = 7;
            ubkTable.Tag = "UBK";
            // 
            // ubk3Value
            // 
            ubk3Value.AutoSize = true;
            ubk3Value.BackColor = Color.Linen;
            ubk3Value.Dock = DockStyle.Fill;
            ubk3Value.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ubk3Value.Location = new Point(315, 66);
            ubk3Value.Name = "ubk3Value";
            ubk3Value.Size = new Size(163, 24);
            ubk3Value.TabIndex = 10;
            ubk3Value.Tag = "3";
            ubk3Value.Text = "-";
            ubk3Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ubk3lab
            // 
            ubk3lab.AutoSize = true;
            ubk3lab.BackColor = Color.Linen;
            ubk3lab.Dock = DockStyle.Fill;
            ubk3lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ubk3lab.Location = new Point(3, 66);
            ubk3lab.Name = "ubk3lab";
            ubk3lab.Size = new Size(306, 24);
            ubk3lab.TabIndex = 9;
            ubk3lab.Tag = "3";
            ubk3lab.Text = "Цепь управления и Корпус";
            ubk3lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ubk2Value
            // 
            ubk2Value.AutoSize = true;
            ubk2Value.BackColor = Color.AntiqueWhite;
            ubk2Value.Dock = DockStyle.Fill;
            ubk2Value.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ubk2Value.Location = new Point(315, 44);
            ubk2Value.Name = "ubk2Value";
            ubk2Value.Size = new Size(163, 22);
            ubk2Value.TabIndex = 7;
            ubk2Value.Tag = "2";
            ubk2Value.Text = "-";
            ubk2Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ubk2lab
            // 
            ubk2lab.AutoSize = true;
            ubk2lab.BackColor = Color.AntiqueWhite;
            ubk2lab.Dock = DockStyle.Fill;
            ubk2lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ubk2lab.Location = new Point(3, 44);
            ubk2lab.Name = "ubk2lab";
            ubk2lab.Size = new Size(306, 22);
            ubk2lab.TabIndex = 6;
            ubk2lab.Tag = "2";
            ubk2lab.Text = "Силовая цепь и Цепь управления";
            ubk2lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ubk1Value
            // 
            ubk1Value.AutoSize = true;
            ubk1Value.BackColor = Color.Linen;
            ubk1Value.Dock = DockStyle.Fill;
            ubk1Value.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ubk1Value.Location = new Point(315, 22);
            ubk1Value.Name = "ubk1Value";
            ubk1Value.Size = new Size(163, 22);
            ubk1Value.TabIndex = 4;
            ubk1Value.Tag = "1";
            ubk1Value.Text = "-";
            ubk1Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ubk1lab
            // 
            ubk1lab.AutoSize = true;
            ubk1lab.BackColor = Color.Linen;
            ubk1lab.Dock = DockStyle.Fill;
            ubk1lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            ubk1lab.Location = new Point(3, 22);
            ubk1lab.Name = "ubk1lab";
            ubk1lab.Size = new Size(306, 22);
            ubk1lab.TabIndex = 3;
            ubk1lab.Tag = "1";
            ubk1lab.Text = "Силовая цепь и Корпус";
            ubk1lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerLabel16
            // 
            headerLabel16.AutoSize = true;
            headerLabel16.BackColor = Color.DarkSlateGray;
            headerLabel16.Dock = DockStyle.Fill;
            headerLabel16.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            headerLabel16.ForeColor = Color.AntiqueWhite;
            headerLabel16.Location = new Point(315, 0);
            headerLabel16.Name = "headerLabel16";
            headerLabel16.Size = new Size(163, 22);
            headerLabel16.TabIndex = 1;
            headerLabel16.Text = "Значение";
            headerLabel16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerLabel17
            // 
            headerLabel17.AutoSize = true;
            headerLabel17.BackColor = Color.DarkSlateGray;
            headerLabel17.Dock = DockStyle.Fill;
            headerLabel17.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            headerLabel17.ForeColor = Color.AntiqueWhite;
            headerLabel17.Location = new Point(3, 0);
            headerLabel17.Name = "headerLabel17";
            headerLabel17.Size = new Size(306, 22);
            headerLabel17.TabIndex = 0;
            headerLabel17.Text = "Возвратное напряжение";
            headerLabel17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableTitle2
            // 
            tableTitle2.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            tableTitle2.Location = new Point(13, 208);
            tableTitle2.Name = "tableTitle2";
            tableTitle2.Size = new Size(476, 20);
            tableTitle2.TabIndex = 6;
            tableTitle2.Tag = "UBK";
            tableTitle2.Text = "Возвратное напряжение";
            tableTitle2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // seTable
            // 
            seTable.ColumnCount = 2;
            seTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            seTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            seTable.Controls.Add(_se12Value, 1, 12);
            seTable.Controls.Add(_se12lab, 0, 12);
            seTable.Controls.Add(_se11Value, 1, 11);
            seTable.Controls.Add(_se11lab, 0, 11);
            seTable.Controls.Add(_se10Value, 1, 10);
            seTable.Controls.Add(_se10lab, 0, 10);
            seTable.Controls.Add(_se9Value, 1, 9);
            seTable.Controls.Add(_se9lab, 0, 9);
            seTable.Controls.Add(_se8Value, 1, 8);
            seTable.Controls.Add(_se8lab, 0, 8);
            seTable.Controls.Add(_se7Value, 1, 7);
            seTable.Controls.Add(_se7lab, 0, 7);
            seTable.Controls.Add(_se6Value, 1, 6);
            seTable.Controls.Add(_se6lab, 0, 6);
            seTable.Controls.Add(_se5Value, 1, 5);
            seTable.Controls.Add(_se5lab, 0, 5);
            seTable.Controls.Add(_se4Value, 1, 4);
            seTable.Controls.Add(_se4lab, 0, 4);
            seTable.Controls.Add(_se3Value, 1, 3);
            seTable.Controls.Add(_se3lab, 0, 3);
            seTable.Controls.Add(_se2Value, 1, 2);
            seTable.Controls.Add(_se2lab, 0, 2);
            seTable.Controls.Add(_se1Value, 1, 1);
            seTable.Controls.Add(headerLabel24, 1, 0);
            seTable.Controls.Add(headerLabel25, 0, 0);
            seTable.Controls.Add(_se1lab, 0, 1);
            seTable.Location = new Point(509, 94);
            seTable.Margin = new Padding(3, 2, 3, 2);
            seTable.Name = "seTable";
            seTable.RowCount = 13;
            seTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            seTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            seTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            seTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            seTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            seTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            seTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            seTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            seTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            seTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            seTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            seTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            seTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            seTable.Size = new Size(583, 295);
            seTable.TabIndex = 5;
            seTable.Tag = "SE";
            // 
            // _se12Value
            // 
            _se12Value.AutoSize = true;
            _se12Value.BackColor = Color.AntiqueWhite;
            _se12Value.Dock = DockStyle.Fill;
            _se12Value.Location = new Point(381, 264);
            _se12Value.Name = "_se12Value";
            _se12Value.Size = new Size(199, 31);
            _se12Value.TabIndex = 37;
            _se12Value.Tag = "12";
            _se12Value.Text = "-";
            _se12Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se12lab
            // 
            _se12lab.AutoSize = true;
            _se12lab.BackColor = Color.AntiqueWhite;
            _se12lab.Dock = DockStyle.Fill;
            _se12lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            _se12lab.Location = new Point(3, 264);
            _se12lab.Name = "_se12lab";
            _se12lab.Size = new Size(372, 31);
            _se12lab.TabIndex = 36;
            _se12lab.Tag = "12";
            _se12lab.Text = "Ослабление возбуждения 2 ступень";
            _se12lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se11Value
            // 
            _se11Value.AutoSize = true;
            _se11Value.BackColor = Color.Linen;
            _se11Value.Dock = DockStyle.Fill;
            _se11Value.Location = new Point(381, 242);
            _se11Value.Name = "_se11Value";
            _se11Value.Size = new Size(199, 22);
            _se11Value.TabIndex = 34;
            _se11Value.Tag = "11";
            _se11Value.Text = "-";
            _se11Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se11lab
            // 
            _se11lab.AutoSize = true;
            _se11lab.BackColor = Color.Linen;
            _se11lab.Dock = DockStyle.Fill;
            _se11lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            _se11lab.Location = new Point(3, 242);
            _se11lab.Name = "_se11lab";
            _se11lab.Size = new Size(372, 22);
            _se11lab.TabIndex = 33;
            _se11lab.Tag = "11";
            _se11lab.Text = "Ослабление возбуждения 1 ступень";
            _se11lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se10Value
            // 
            _se10Value.AutoSize = true;
            _se10Value.BackColor = Color.AntiqueWhite;
            _se10Value.Dock = DockStyle.Fill;
            _se10Value.Location = new Point(381, 220);
            _se10Value.Name = "_se10Value";
            _se10Value.Size = new Size(199, 22);
            _se10Value.TabIndex = 31;
            _se10Value.Tag = "10";
            _se10Value.Text = "-";
            _se10Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se10lab
            // 
            _se10lab.AutoSize = true;
            _se10lab.BackColor = Color.AntiqueWhite;
            _se10lab.Dock = DockStyle.Fill;
            _se10lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            _se10lab.Location = new Point(3, 220);
            _se10lab.Name = "_se10lab";
            _se10lab.Size = new Size(372, 22);
            _se10lab.TabIndex = 30;
            _se10lab.Tag = "10";
            _se10lab.Text = "Полное возбуждение 8";
            _se10lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se9Value
            // 
            _se9Value.AutoSize = true;
            _se9Value.BackColor = Color.Linen;
            _se9Value.Dock = DockStyle.Fill;
            _se9Value.Location = new Point(381, 198);
            _se9Value.Name = "_se9Value";
            _se9Value.Size = new Size(199, 22);
            _se9Value.TabIndex = 28;
            _se9Value.Tag = "9";
            _se9Value.Text = "-";
            _se9Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se9lab
            // 
            _se9lab.AutoSize = true;
            _se9lab.BackColor = Color.Linen;
            _se9lab.Dock = DockStyle.Fill;
            _se9lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            _se9lab.Location = new Point(3, 198);
            _se9lab.Name = "_se9lab";
            _se9lab.Size = new Size(372, 22);
            _se9lab.TabIndex = 27;
            _se9lab.Tag = "9";
            _se9lab.Text = "Полное возбуждение 7";
            _se9lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se8Value
            // 
            _se8Value.AutoSize = true;
            _se8Value.BackColor = Color.AntiqueWhite;
            _se8Value.Dock = DockStyle.Fill;
            _se8Value.Location = new Point(381, 176);
            _se8Value.Name = "_se8Value";
            _se8Value.Size = new Size(199, 22);
            _se8Value.TabIndex = 25;
            _se8Value.Tag = "8";
            _se8Value.Text = "-";
            _se8Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se8lab
            // 
            _se8lab.AutoSize = true;
            _se8lab.BackColor = Color.AntiqueWhite;
            _se8lab.Dock = DockStyle.Fill;
            _se8lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            _se8lab.Location = new Point(3, 176);
            _se8lab.Name = "_se8lab";
            _se8lab.Size = new Size(372, 22);
            _se8lab.TabIndex = 24;
            _se8lab.Tag = "8";
            _se8lab.Text = "Полное возбуждение 6";
            _se8lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se7Value
            // 
            _se7Value.AutoSize = true;
            _se7Value.BackColor = Color.Linen;
            _se7Value.Dock = DockStyle.Fill;
            _se7Value.Location = new Point(381, 154);
            _se7Value.Name = "_se7Value";
            _se7Value.Size = new Size(199, 22);
            _se7Value.TabIndex = 22;
            _se7Value.Tag = "7";
            _se7Value.Text = "-";
            _se7Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se7lab
            // 
            _se7lab.AutoSize = true;
            _se7lab.BackColor = Color.Linen;
            _se7lab.Dock = DockStyle.Fill;
            _se7lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            _se7lab.Location = new Point(3, 154);
            _se7lab.Name = "_se7lab";
            _se7lab.Size = new Size(372, 22);
            _se7lab.TabIndex = 21;
            _se7lab.Tag = "7";
            _se7lab.Text = "Полное возбуждение 5";
            _se7lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se6Value
            // 
            _se6Value.AutoSize = true;
            _se6Value.BackColor = Color.AntiqueWhite;
            _se6Value.Dock = DockStyle.Fill;
            _se6Value.Location = new Point(381, 132);
            _se6Value.Name = "_se6Value";
            _se6Value.Size = new Size(199, 22);
            _se6Value.TabIndex = 19;
            _se6Value.Tag = "6";
            _se6Value.Text = "-";
            _se6Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se6lab
            // 
            _se6lab.AutoSize = true;
            _se6lab.BackColor = Color.AntiqueWhite;
            _se6lab.Dock = DockStyle.Fill;
            _se6lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            _se6lab.Location = new Point(3, 132);
            _se6lab.Name = "_se6lab";
            _se6lab.Size = new Size(372, 22);
            _se6lab.TabIndex = 18;
            _se6lab.Tag = "6";
            _se6lab.Text = "Полное возбуждение 4";
            _se6lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se5Value
            // 
            _se5Value.AutoSize = true;
            _se5Value.BackColor = Color.Linen;
            _se5Value.Dock = DockStyle.Fill;
            _se5Value.Location = new Point(381, 110);
            _se5Value.Name = "_se5Value";
            _se5Value.Size = new Size(199, 22);
            _se5Value.TabIndex = 16;
            _se5Value.Tag = "5";
            _se5Value.Text = "-";
            _se5Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se5lab
            // 
            _se5lab.AutoSize = true;
            _se5lab.BackColor = Color.Linen;
            _se5lab.Dock = DockStyle.Fill;
            _se5lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            _se5lab.Location = new Point(3, 110);
            _se5lab.Name = "_se5lab";
            _se5lab.Size = new Size(372, 22);
            _se5lab.TabIndex = 15;
            _se5lab.Tag = "5";
            _se5lab.Text = "Полное возбуждение 3";
            _se5lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se4Value
            // 
            _se4Value.AutoSize = true;
            _se4Value.BackColor = Color.AntiqueWhite;
            _se4Value.Dock = DockStyle.Fill;
            _se4Value.Location = new Point(381, 88);
            _se4Value.Name = "_se4Value";
            _se4Value.Size = new Size(199, 22);
            _se4Value.TabIndex = 13;
            _se4Value.Tag = "4";
            _se4Value.Text = "-";
            _se4Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se4lab
            // 
            _se4lab.AutoSize = true;
            _se4lab.BackColor = Color.AntiqueWhite;
            _se4lab.Dock = DockStyle.Fill;
            _se4lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            _se4lab.Location = new Point(3, 88);
            _se4lab.Name = "_se4lab";
            _se4lab.Size = new Size(372, 22);
            _se4lab.TabIndex = 12;
            _se4lab.Tag = "4";
            _se4lab.Text = "Полное возбуждение 2";
            _se4lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se3Value
            // 
            _se3Value.AutoSize = true;
            _se3Value.BackColor = Color.Linen;
            _se3Value.Dock = DockStyle.Fill;
            _se3Value.Location = new Point(381, 66);
            _se3Value.Name = "_se3Value";
            _se3Value.Size = new Size(199, 22);
            _se3Value.TabIndex = 10;
            _se3Value.Tag = "3";
            _se3Value.Text = "-";
            _se3Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se3lab
            // 
            _se3lab.AutoSize = true;
            _se3lab.BackColor = Color.Linen;
            _se3lab.Dock = DockStyle.Fill;
            _se3lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            _se3lab.Location = new Point(3, 66);
            _se3lab.Name = "_se3lab";
            _se3lab.Size = new Size(372, 22);
            _se3lab.TabIndex = 9;
            _se3lab.Tag = "3";
            _se3lab.Text = "Полное возбуждение 1";
            _se3lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se2Value
            // 
            _se2Value.AutoSize = true;
            _se2Value.BackColor = Color.AntiqueWhite;
            _se2Value.Dock = DockStyle.Fill;
            _se2Value.Location = new Point(381, 44);
            _se2Value.Name = "_se2Value";
            _se2Value.Size = new Size(199, 22);
            _se2Value.TabIndex = 7;
            _se2Value.Tag = "2";
            _se2Value.Text = "-";
            _se2Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se2lab
            // 
            _se2lab.AutoSize = true;
            _se2lab.BackColor = Color.AntiqueWhite;
            _se2lab.Dock = DockStyle.Fill;
            _se2lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            _se2lab.Location = new Point(3, 44);
            _se2lab.Name = "_se2lab";
            _se2lab.Size = new Size(372, 22);
            _se2lab.TabIndex = 6;
            _se2lab.Tag = "2";
            _se2lab.Text = "Холостой ход";
            _se2lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se1Value
            // 
            _se1Value.AutoSize = true;
            _se1Value.BackColor = Color.Linen;
            _se1Value.Dock = DockStyle.Fill;
            _se1Value.Location = new Point(381, 22);
            _se1Value.Name = "_se1Value";
            _se1Value.Size = new Size(199, 22);
            _se1Value.TabIndex = 4;
            _se1Value.Tag = "1";
            _se1Value.Text = "-";
            _se1Value.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerLabel24
            // 
            headerLabel24.AutoSize = true;
            headerLabel24.BackColor = Color.DarkSlateGray;
            headerLabel24.Dock = DockStyle.Fill;
            headerLabel24.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            headerLabel24.ForeColor = Color.AntiqueWhite;
            headerLabel24.Location = new Point(381, 0);
            headerLabel24.Name = "headerLabel24";
            headerLabel24.Size = new Size(199, 22);
            headerLabel24.TabIndex = 1;
            headerLabel24.Text = "Значение";
            headerLabel24.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerLabel25
            // 
            headerLabel25.AutoSize = true;
            headerLabel25.BackColor = Color.DarkSlateGray;
            headerLabel25.Dock = DockStyle.Fill;
            headerLabel25.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            headerLabel25.ForeColor = Color.AntiqueWhite;
            headerLabel25.Location = new Point(3, 0);
            headerLabel25.Name = "headerLabel25";
            headerLabel25.Size = new Size(372, 22);
            headerLabel25.TabIndex = 0;
            headerLabel25.Text = "Схемы управления";
            headerLabel25.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _se1lab
            // 
            _se1lab.AutoSize = true;
            _se1lab.BackColor = Color.Linen;
            _se1lab.Dock = DockStyle.Fill;
            _se1lab.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            _se1lab.Location = new Point(3, 22);
            _se1lab.Name = "_se1lab";
            _se1lab.Size = new Size(372, 22);
            _se1lab.TabIndex = 3;
            _se1lab.Tag = "1";
            _se1lab.Text = "Пуск дизеля";
            _se1lab.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableTitle3
            // 
            tableTitle3.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            tableTitle3.Location = new Point(509, 72);
            tableTitle3.Name = "tableTitle3";
            tableTitle3.Size = new Size(583, 20);
            tableTitle3.TabIndex = 4;
            tableTitle3.Tag = "SE";
            tableTitle3.Text = "Сопротивление цепей управления при проверке секвенции";
            tableTitle3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = SystemColors.Control;
            label14.Dock = DockStyle.Fill;
            label14.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(4, 4);
            label14.Name = "label14";
            label14.Size = new Size(0, 17);
            label14.TabIndex = 12;
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // backToListBox
            // 
            backToListBox.Cursor = Cursors.Hand;
            backToListBox.Image = Properties.Resources.back_dark;
            backToListBox.Location = new Point(260, 9);
            backToListBox.Margin = new Padding(3, 2, 3, 2);
            backToListBox.Name = "backToListBox";
            backToListBox.Size = new Size(38, 38);
            backToListBox.SizeMode = PictureBoxSizeMode.Zoom;
            backToListBox.TabIndex = 15;
            backToListBox.TabStop = false;
            toolTip.SetToolTip(backToListBox, "Вернуться к списку измерений");
            backToListBox.Click += BackToMainPage;
            backToListBox.MouseEnter += BackToList_MouseEnter;
            backToListBox.MouseLeave += BackToList_MouseLeave;
            // 
            // createReportButton
            // 
            createReportButton.BackColor = Color.DarkSlateGray;
            createReportButton.Cursor = Cursors.Hand;
            createReportButton.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            createReportButton.ForeColor = Color.Wheat;
            createReportButton.Location = new Point(9, 229);
            createReportButton.Name = "createReportButton";
            createReportButton.Size = new Size(228, 40);
            createReportButton.TabIndex = 16;
            createReportButton.Text = "Сформировать отчёт";
            createReportButton.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(createReportButton, "Создать PDF отчёт по текущему локомотиву");
            createReportButton.Click += CreateReportButton_Click;
            createReportButton.MouseEnter += Button_MouseEnter;
            createReportButton.MouseLeave += Button_MouseLeave;
            // 
            // collapseAppBox
            // 
            collapseAppBox.Cursor = Cursors.Hand;
            collapseAppBox.Dock = DockStyle.Left;
            collapseAppBox.Image = Properties.Resources.collapse;
            collapseAppBox.Location = new Point(42, 4);
            collapseAppBox.Margin = new Padding(3, 2, 3, 2);
            collapseAppBox.Name = "collapseAppBox";
            collapseAppBox.Size = new Size(38, 38);
            collapseAppBox.SizeMode = PictureBoxSizeMode.Zoom;
            collapseAppBox.TabIndex = 18;
            collapseAppBox.TabStop = false;
            toolTip.SetToolTip(collapseAppBox, "Свернуть программу");
            collapseAppBox.Click += CollapseAppBox_Click;
            collapseAppBox.MouseEnter += CollapseAppBox_MouseEnter;
            collapseAppBox.MouseLeave += CollapseAppBox_MouseLeave;
            // 
            // buildResistanceChartButton
            // 
            buildResistanceChartButton.BackColor = Color.DarkSlateGray;
            buildResistanceChartButton.Cursor = Cursors.Hand;
            buildResistanceChartButton.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            buildResistanceChartButton.ForeColor = Color.Wheat;
            buildResistanceChartButton.Location = new Point(9, 139);
            buildResistanceChartButton.Name = "buildResistanceChartButton";
            buildResistanceChartButton.Size = new Size(228, 40);
            buildResistanceChartButton.TabIndex = 19;
            buildResistanceChartButton.Text = "Диаграмма сопротивления";
            buildResistanceChartButton.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(buildResistanceChartButton, "Построить диаграмму сопротивления");
            buildResistanceChartButton.Click += BuildResistancePlot_Click;
            buildResistanceChartButton.MouseEnter += Button_MouseEnter;
            buildResistanceChartButton.MouseLeave += Button_MouseLeave;
            // 
            // quitAppButton
            // 
            quitAppButton.Cursor = Cursors.Hand;
            quitAppButton.Dock = DockStyle.Right;
            quitAppButton.Image = Properties.Resources.quit;
            quitAppButton.Location = new Point(80, 4);
            quitAppButton.Margin = new Padding(3, 2, 3, 2);
            quitAppButton.Name = "quitAppButton";
            quitAppButton.Size = new Size(38, 38);
            quitAppButton.SizeMode = PictureBoxSizeMode.Zoom;
            quitAppButton.TabIndex = 21;
            quitAppButton.TabStop = false;
            toolTip.SetToolTip(quitAppButton, "Выйти из программы");
            quitAppButton.Click += QuitAppBox_Click;
            quitAppButton.MouseEnter += QuitAppBox_MouseEnter;
            quitAppButton.MouseLeave += QuitAppBox_MouseLeave;
            // 
            // currentMessage
            // 
            currentMessage.Anchor = AnchorStyles.Bottom;
            currentMessage.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            currentMessage.Location = new Point(369, 585);
            currentMessage.Name = "currentMessage";
            currentMessage.Size = new Size(787, 19);
            currentMessage.TabIndex = 17;
            currentMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // plotTip
            // 
            plotTip.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            plotTip.ForeColor = Color.Firebrick;
            plotTip.Location = new Point(9, 178);
            plotTip.Name = "plotTip";
            plotTip.Size = new Size(228, 29);
            plotTip.TabIndex = 20;
            plotTip.Text = "Измерения не проводились";
            plotTip.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // themeSwitcher
            // 
            themeSwitcher.Cursor = Cursors.Hand;
            themeSwitcher.Dock = DockStyle.Left;
            themeSwitcher.Image = Properties.Resources.dark_theme;
            themeSwitcher.Location = new Point(4, 4);
            themeSwitcher.Margin = new Padding(3, 2, 3, 2);
            themeSwitcher.Name = "themeSwitcher";
            themeSwitcher.Size = new Size(38, 38);
            themeSwitcher.SizeMode = PictureBoxSizeMode.Zoom;
            themeSwitcher.TabIndex = 24;
            themeSwitcher.TabStop = false;
            themeSwitcher.Click += ThemeSwitcher_Click;
            themeSwitcher.MouseEnter += ThemeSwitcher_MouseEnter;
            themeSwitcher.MouseLeave += ThemeSwith_MouseLeave;
            // 
            // savingDate
            // 
            savingDate.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            savingDate.ForeColor = Color.DarkSlateGray;
            savingDate.Location = new Point(1016, 70);
            savingDate.Name = "savingDate";
            savingDate.Size = new Size(340, 19);
            savingDate.TabIndex = 25;
            savingDate.Text = "по состоянию на [дата]";
            savingDate.TextAlign = ContentAlignment.BottomCenter;
            // 
            // sidePanel
            // 
            sidePanel.Controls.Add(logoBox);
            sidePanel.Controls.Add(buildResistanceChartButton);
            sidePanel.Controls.Add(createReportButton);
            sidePanel.Controls.Add(plotTip);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.Location = new Point(4, 4);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(249, 613);
            sidePanel.TabIndex = 26;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(quitAppButton);
            headerPanel.Controls.Add(collapseAppBox);
            headerPanel.Controls.Add(themeSwitcher);
            headerPanel.Location = new Point(1235, 9);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(4);
            headerPanel.Size = new Size(122, 46);
            headerPanel.TabIndex = 27;
            // 
            // AllMeasurementsFromLocoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1382, 621);
            Controls.Add(headerPanel);
            Controls.Add(sidePanel);
            Controls.Add(savingDate);
            Controls.Add(currentMessage);
            Controls.Add(backToListBox);
            Controls.Add(label14);
            Controls.Add(panel);
            Controls.Add(headerLoco);
            Controls.Add(headerDefault);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "AllMeasurementsFromLocoForm";
            Padding = new Padding(4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AllMeasurementsFromLocoForm";
            Load += LoadForm;
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            insTable.ResumeLayout(false);
            insTable.PerformLayout();
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ubkTable.ResumeLayout(false);
            ubkTable.PerformLayout();
            seTable.ResumeLayout(false);
            seTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)backToListBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)collapseAppBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)quitAppButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)themeSwitcher).EndInit();
            sidePanel.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox logoBox;
        private Label headerDefault;
        private Label headerLoco;
        private TableLayoutPanel insTable;
        private Label tableTitle1;
        private Label headerLabel1;
        private Label headerLabel2;
        private Label ins3Value;
        private Label ins3lab;
        private Label ins2Value;
        private Label ins2lab;
        private Label ins1Value;
        private Label ins1lab;
        private Panel panel;
        private Label tableTitle3;
        private TableLayoutPanel seTable;
        private Label headerLabel24;
        private Label headerLabel25;
        private Label label14;
        private Label _se12Value;
        private Label _se12lab;
        private Label _se11Value;
        private Label _se11lab;
        private Label _se10Value;
        private Label _se10lab;
        private Label _se9Value;
        private Label _se9lab;
        private Label _se8Value;
        private Label _se8lab;
        private Label _se7Value;
        private Label _se7lab;
        private Label _se6Value;
        private Label _se6lab;
        private Label _se5Value;
        private Label _se5lab;
        private Label _se4Value;
        private Label _se4lab;
        private Label _se3Value;
        private Label _se3lab;
        private Label _se2Value;
        private Label _se2lab;
        private Label _se1Value;
        private Label _se1lab;
        private PictureBox backToListBox;
        private ToolTip toolTip;
        private Label createReportButton;
        private Label currentMessage;
        private PictureBox collapseAppBox;
        private Label buildResistanceChartButton;
        private Label plotTip;
        private PictureBox quitAppButton;
        private Label tableTitle2;
        private TableLayoutPanel ubkTable;
        private Label ubk3Value;
        private Label ubk3lab;
        private Label ubk2Value;
        private Label ubk2lab;
        private Label ubk1Value;
        private Label ubk1lab;
        private Label headerLabel16;
        private Label headerLabel17;
        private PictureBox themeSwitcher;
        private Label savingDate;
        private Label insMeasuredBy;
        private Label ubkMeasuredBy;
        private Label seMeasuredBy;
        private Panel sidePanel;
        private Panel headerPanel;
    }
}