using Presentation.Properties;

namespace Presentation.View
{
    partial class ResistancePlotForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResistancePlotForm));
            quitAppButton = new PictureBox();
            logoBox = new PictureBox();
            plot = new OxyPlot.WindowsForms.PlotView();
            toolTip = new ToolTip(components);
            collapseAppBox = new PictureBox();
            backToListBox = new PictureBox();
            resetModelButton = new Label();
            formHeader = new Label();
            tips = new Label();
            themeSwitcher = new PictureBox();
            headerPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)quitAppButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)collapseAppBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)backToListBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)themeSwitcher).BeginInit();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // quitAppButton
            // 
            quitAppButton.Image = Resources.quit;
            quitAppButton.Location = new Point(1086, 4);
            quitAppButton.Margin = new Padding(0);
            quitAppButton.Name = "quitAppButton";
            quitAppButton.Size = new Size(38, 38);
            quitAppButton.SizeMode = PictureBoxSizeMode.Zoom;
            quitAppButton.TabIndex = 0;
            quitAppButton.TabStop = false;
            toolTip.SetToolTip(quitAppButton, "Выйти из программы");
            quitAppButton.Click += QuitAppBox_Click;
            quitAppButton.MouseEnter += QuitAppBox_MouseEnter;
            quitAppButton.MouseLeave += QuitAppBox_MouseLeave;
            // 
            // logoBox
            // 
            logoBox.Image = Resources.logo;
            logoBox.Location = new Point(10, 9);
            logoBox.Margin = new Padding(3, 2, 3, 2);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(228, 75);
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 1;
            logoBox.TabStop = false;
            toolTip.SetToolTip(logoBox, "Перейти на сайт разработчика");
            logoBox.Click += Logo_Click;
            // 
            // plot
            // 
            plot.BackColor = SystemColors.GradientInactiveCaption;
            plot.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            plot.Location = new Point(10, 139);
            plot.Margin = new Padding(3, 2, 3, 2);
            plot.Name = "plot";
            plot.PanCursor = Cursors.Hand;
            plot.Size = new Size(1362, 473);
            plot.TabIndex = 2;
            plot.Text = "plotView1";
            plot.ZoomHorizontalCursor = Cursors.SizeWE;
            plot.ZoomRectangleCursor = Cursors.SizeNWSE;
            plot.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // collapseAppBox
            // 
            collapseAppBox.Image = Resources.collapse;
            collapseAppBox.Location = new Point(1048, 4);
            collapseAppBox.Margin = new Padding(0);
            collapseAppBox.Name = "collapseAppBox";
            collapseAppBox.Size = new Size(38, 38);
            collapseAppBox.SizeMode = PictureBoxSizeMode.Zoom;
            collapseAppBox.TabIndex = 4;
            collapseAppBox.TabStop = false;
            toolTip.SetToolTip(collapseAppBox, "Свернуть программу");
            collapseAppBox.Click += CollapseApplication;
            collapseAppBox.MouseEnter += CollapseAppBox_MouseEneter;
            collapseAppBox.MouseLeave += CollapseAppBox_MouseLeave;
            // 
            // backToListBox
            // 
            backToListBox.Dock = DockStyle.Left;
            backToListBox.Image = Resources.back_dark;
            backToListBox.Location = new Point(4, 4);
            backToListBox.Margin = new Padding(0);
            backToListBox.Name = "backToListBox";
            backToListBox.Size = new Size(38, 38);
            backToListBox.SizeMode = PictureBoxSizeMode.Zoom;
            backToListBox.TabIndex = 5;
            backToListBox.TabStop = false;
            toolTip.SetToolTip(backToListBox, "Вернуться к списку измерений");
            backToListBox.Click += BackToMeasuringsPage_Click;
            backToListBox.MouseEnter += BackToMeasuringsPage_MouseEnter;
            backToListBox.MouseLeave += BackToMeasuringsPage_MouseLeave;
            // 
            // resetModelButton
            // 
            resetModelButton.BackColor = SystemColors.GradientInactiveCaption;
            resetModelButton.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            resetModelButton.ForeColor = Color.SlateGray;
            resetModelButton.Location = new Point(1063, 139);
            resetModelButton.Name = "resetModelButton";
            resetModelButton.Size = new Size(309, 20);
            resetModelButton.TabIndex = 24;
            resetModelButton.Text = "Вернуть исходный вид графика";
            resetModelButton.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(resetModelButton, "Сбросить пользовательские настройки графика");
            resetModelButton.Click += ResetModelButton_Click;
            resetModelButton.MouseEnter += ResetModelButton_MouseEnter;
            resetModelButton.MouseLeave += ResetModelButton_MouseLeave;
            // 
            // formHeader
            // 
            formHeader.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point);
            formHeader.ForeColor = Color.DarkSlateGray;
            formHeader.Location = new Point(42, 4);
            formHeader.Name = "formHeader";
            formHeader.Size = new Size(1082, 38);
            formHeader.TabIndex = 3;
            formHeader.Text = "Диаграмма сопротивления на локомотиве";
            formHeader.TextAlign = ContentAlignment.MiddleCenter;
            formHeader.MouseDown += ThisForm_MouseDown;
            formHeader.MouseMove += ThisForm_MouseMove;
            // 
            // tips
            // 
            tips.Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            tips.ForeColor = Color.SteelBlue;
            tips.Location = new Point(260, 52);
            tips.Name = "tips";
            tips.Size = new Size(1065, 78);
            tips.TabIndex = 6;
            tips.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // themeSwitcher
            // 
            themeSwitcher.Cursor = Cursors.Hand;
            themeSwitcher.Image = Resources.dark_theme;
            themeSwitcher.Location = new Point(1010, 4);
            themeSwitcher.Margin = new Padding(0);
            themeSwitcher.Name = "themeSwitcher";
            themeSwitcher.Size = new Size(38, 38);
            themeSwitcher.SizeMode = PictureBoxSizeMode.Zoom;
            themeSwitcher.TabIndex = 23;
            themeSwitcher.TabStop = false;
            themeSwitcher.Click += ThemeSwitcher_Click;
            themeSwitcher.MouseEnter += ThemeSwitcher_MouseEnter;
            themeSwitcher.MouseLeave += ThemeSwith_MouseLeave;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(quitAppButton);
            headerPanel.Controls.Add(collapseAppBox);
            headerPanel.Controls.Add(themeSwitcher);
            headerPanel.Controls.Add(formHeader);
            headerPanel.Controls.Add(backToListBox);
            headerPanel.Location = new Point(244, 12);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(4);
            headerPanel.Size = new Size(1128, 46);
            headerPanel.TabIndex = 25;
            // 
            // ResistancePlotForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1382, 621);
            Controls.Add(headerPanel);
            Controls.Add(resetModelButton);
            Controls.Add(tips);
            Controls.Add(plot);
            Controls.Add(logoBox);
            Cursor = Cursors.Hand;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "ResistancePlotForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Диаграмма сопротивления";
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            ((System.ComponentModel.ISupportInitialize)quitAppButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)collapseAppBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)backToListBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)themeSwitcher).EndInit();
            headerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox quitAppButton;
        private PictureBox logoBox;
        private OxyPlot.WindowsForms.PlotView plot;
        private ToolTip toolTip;
        private Label formHeader;
        private PictureBox collapseAppBox;
        private PictureBox backToListBox;
        private Label tips;
        private PictureBox themeSwitcher;
        private Label resetModelButton;
        private Panel headerPanel;
    }
}