namespace Presentation.View
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            panel = new Panel();
            companySettings = new Label();
            deviceReconnectButton = new Label();
            displayEmployees = new Label();
            headerPanel = new Panel();
            headerLabel = new Label();
            backButtonBox = new PictureBox();
            toolTip = new ToolTip(components);
            panel.SuspendLayout();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)backButtonBox).BeginInit();
            SuspendLayout();
            // 
            // panel
            // 
            panel.BackColor = SystemColors.GradientInactiveCaption;
            panel.Controls.Add(companySettings);
            panel.Controls.Add(deviceReconnectButton);
            panel.Controls.Add(displayEmployees);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(9, 8);
            panel.Margin = new Padding(3, 2, 3, 2);
            panel.Name = "panel";
            panel.Size = new Size(241, 208);
            panel.TabIndex = 0;
            // 
            // companySettings
            // 
            companySettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            companySettings.BackColor = Color.DarkSlateGray;
            companySettings.BorderStyle = BorderStyle.Fixed3D;
            companySettings.Cursor = Cursors.Hand;
            companySettings.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            companySettings.ForeColor = Color.Wheat;
            companySettings.Location = new Point(24, 116);
            companySettings.Name = "companySettings";
            companySettings.Size = new Size(194, 30);
            companySettings.TabIndex = 24;
            companySettings.Text = "Компания";
            companySettings.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(companySettings, "Настроить данные компании");
            companySettings.Click += CompanySettings_Click;
            companySettings.MouseEnter += Button_MouseEnter;
            companySettings.MouseLeave += Button_MouseLeave;
            // 
            // deviceReconnectButton
            // 
            deviceReconnectButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            deviceReconnectButton.BackColor = Color.DarkSlateGray;
            deviceReconnectButton.BorderStyle = BorderStyle.Fixed3D;
            deviceReconnectButton.Cursor = Cursors.Hand;
            deviceReconnectButton.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            deviceReconnectButton.ForeColor = Color.Wheat;
            deviceReconnectButton.Location = new Point(24, 46);
            deviceReconnectButton.Name = "deviceReconnectButton";
            deviceReconnectButton.Size = new Size(194, 30);
            deviceReconnectButton.TabIndex = 23;
            deviceReconnectButton.Text = "Подключение к устройству";
            deviceReconnectButton.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(deviceReconnectButton, "Повторное подключение к устройству");
            deviceReconnectButton.Click += ReconnectToDeviceButton_Click;
            deviceReconnectButton.MouseEnter += Button_MouseEnter;
            deviceReconnectButton.MouseLeave += Button_MouseLeave;
            // 
            // displayEmployees
            // 
            displayEmployees.BackColor = Color.DarkSlateGray;
            displayEmployees.BorderStyle = BorderStyle.Fixed3D;
            displayEmployees.Cursor = Cursors.Hand;
            displayEmployees.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            displayEmployees.ForeColor = Color.Wheat;
            displayEmployees.Location = new Point(24, 158);
            displayEmployees.Name = "displayEmployees";
            displayEmployees.Size = new Size(194, 30);
            displayEmployees.TabIndex = 22;
            displayEmployees.Text = "Сотрудники";
            displayEmployees.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(displayEmployees, "Настроить должности и данные сотрудников");
            displayEmployees.Click += DisplayEmployees_Click;
            displayEmployees.MouseEnter += Button_MouseEnter;
            displayEmployees.MouseLeave += Button_MouseLeave;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(headerLabel);
            headerPanel.Controls.Add(backButtonBox);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(9, 8);
            headerPanel.Margin = new Padding(4, 4, 4, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(2, 2, 38, 2);
            headerPanel.Size = new Size(241, 34);
            headerPanel.TabIndex = 1;
            headerPanel.MouseDown += ThisForm_MouseDown;
            headerPanel.MouseMove += ThisForm_MouseMove;
            // 
            // headerLabel
            // 
            headerLabel.Dock = DockStyle.Fill;
            headerLabel.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            headerLabel.Location = new Point(39, 2);
            headerLabel.Margin = new Padding(4, 3, 4, 3);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(164, 30);
            headerLabel.TabIndex = 1;
            headerLabel.Text = "Настройки";
            headerLabel.TextAlign = ContentAlignment.MiddleCenter;
            headerLabel.MouseDown += ThisForm_MouseDown;
            headerLabel.MouseMove += ThisForm_MouseMove;
            // 
            // backButtonBox
            // 
            backButtonBox.Cursor = Cursors.Hand;
            backButtonBox.Dock = DockStyle.Left;
            backButtonBox.Image = Properties.Resources.back_dark;
            backButtonBox.Location = new Point(2, 2);
            backButtonBox.Margin = new Padding(3, 2, 3, 2);
            backButtonBox.Name = "backButtonBox";
            backButtonBox.Size = new Size(37, 30);
            backButtonBox.SizeMode = PictureBoxSizeMode.Zoom;
            backButtonBox.TabIndex = 0;
            backButtonBox.TabStop = false;
            toolTip.SetToolTip(backButtonBox, "Вернуться на основную страницу");
            backButtonBox.Click += BackButton_Click;
            backButtonBox.MouseEnter += BackButton_MouseEnter;
            backButtonBox.MouseLeave += BackButton_MouseLeave;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(259, 224);
            Controls.Add(headerPanel);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "SettingsForm";
            Padding = new Padding(9, 8, 9, 8);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Настройки";
            TopMost = true;
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            panel.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)backButtonBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private Label displayEmployees;
        private Label deviceReconnectButton;
        private Panel headerPanel;
        private PictureBox backButtonBox;
        private Label headerLabel;
        private Label companySettings;
        private ToolTip toolTip;
    }
}