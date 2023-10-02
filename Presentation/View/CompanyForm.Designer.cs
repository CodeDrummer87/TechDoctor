namespace Presentation.View
{
    partial class CompanyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyForm));
            panel = new Panel();
            middlePanel = new Panel();
            saveButton = new Label();
            companyTitleTextBox = new TextBox();
            aboutLabel = new Label();
            bottomPanel = new Panel();
            currentMessage = new Label();
            headerPanel = new Panel();
            headerLabel = new Label();
            backButtonBox = new PictureBox();
            logoUploadBox = new PictureBox();
            toolTip = new ToolTip(components);
            panel.SuspendLayout();
            middlePanel.SuspendLayout();
            bottomPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)backButtonBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoUploadBox).BeginInit();
            SuspendLayout();
            // 
            // panel
            // 
            panel.BackColor = SystemColors.GradientInactiveCaption;
            panel.Controls.Add(middlePanel);
            panel.Controls.Add(bottomPanel);
            panel.Controls.Add(headerPanel);
            panel.Controls.Add(logoUploadBox);
            panel.Location = new Point(10, 10);
            panel.Name = "panel";
            panel.Padding = new Padding(10);
            panel.Size = new Size(782, 238);
            panel.TabIndex = 0;
            panel.MouseDown += ThisForm_MouseDown;
            panel.MouseMove += ThisForm_MouseMove;
            // 
            // middlePanel
            // 
            middlePanel.Controls.Add(saveButton);
            middlePanel.Controls.Add(companyTitleTextBox);
            middlePanel.Controls.Add(aboutLabel);
            middlePanel.Dock = DockStyle.Fill;
            middlePanel.Location = new Point(10, 56);
            middlePanel.Name = "middlePanel";
            middlePanel.Padding = new Padding(10);
            middlePanel.Size = new Size(431, 128);
            middlePanel.TabIndex = 3;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.DarkSlateGray;
            saveButton.Cursor = Cursors.Hand;
            saveButton.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            saveButton.ForeColor = Color.Wheat;
            saveButton.Location = new Point(13, 100);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(405, 25);
            saveButton.TabIndex = 2;
            saveButton.Text = "Сохранить наименование";
            saveButton.TextAlign = ContentAlignment.MiddleCenter;
            saveButton.Click += SaveCompanyTitle_Click;
            saveButton.MouseEnter += Button_MouseEnter;
            saveButton.MouseLeave += Button_MouseLeave;
            // 
            // companyTitleTextBox
            // 
            companyTitleTextBox.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            companyTitleTextBox.Location = new Point(13, 44);
            companyTitleTextBox.Name = "companyTitleTextBox";
            companyTitleTextBox.PlaceholderText = "Введите наименование";
            companyTitleTextBox.Size = new Size(405, 28);
            companyTitleTextBox.TabIndex = 1;
            // 
            // aboutLabel
            // 
            aboutLabel.AutoSize = true;
            aboutLabel.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            aboutLabel.Location = new Point(15, 17);
            aboutLabel.Name = "aboutLabel";
            aboutLabel.Size = new Size(294, 20);
            aboutLabel.TabIndex = 0;
            aboutLabel.Text = "Наименование предприятия:";
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(currentMessage);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(10, 184);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new Padding(10);
            bottomPanel.Size = new Size(431, 44);
            bottomPanel.TabIndex = 2;
            // 
            // currentMessage
            // 
            currentMessage.Dock = DockStyle.Fill;
            currentMessage.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            currentMessage.Location = new Point(10, 10);
            currentMessage.Name = "currentMessage";
            currentMessage.Size = new Size(411, 24);
            currentMessage.TabIndex = 0;
            currentMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(headerLabel);
            headerPanel.Controls.Add(backButtonBox);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(10, 10);
            headerPanel.Margin = new Padding(5);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(2, 2, 46, 2);
            headerPanel.Size = new Size(431, 46);
            headerPanel.TabIndex = 1;
            headerPanel.MouseDown += ThisForm_MouseDown;
            headerPanel.MouseMove += ThisForm_MouseMove;
            // 
            // headerLabel
            // 
            headerLabel.Dock = DockStyle.Fill;
            headerLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            headerLabel.Location = new Point(44, 2);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(341, 42);
            headerLabel.TabIndex = 1;
            headerLabel.Text = "О компании";
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
            backButtonBox.Name = "backButtonBox";
            backButtonBox.Size = new Size(42, 42);
            backButtonBox.SizeMode = PictureBoxSizeMode.Zoom;
            backButtonBox.TabIndex = 0;
            backButtonBox.TabStop = false;
            toolTip.SetToolTip(backButtonBox, "Вернуться к настройкам программы");
            backButtonBox.Click += BackButton_Click;
            backButtonBox.MouseEnter += BackButton_MouseEnter;
            backButtonBox.MouseLeave += BackButton_MouseLeave;
            // 
            // logoUploadBox
            // 
            logoUploadBox.Cursor = Cursors.Hand;
            logoUploadBox.Dock = DockStyle.Right;
            logoUploadBox.Image = Properties.Resources.logo_upload_light;
            logoUploadBox.Location = new Point(441, 10);
            logoUploadBox.Margin = new Padding(5);
            logoUploadBox.Name = "logoUploadBox";
            logoUploadBox.Size = new Size(331, 218);
            logoUploadBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoUploadBox.TabIndex = 0;
            logoUploadBox.TabStop = false;
            toolTip.SetToolTip(logoUploadBox, "Загрузите логотип компании");
            logoUploadBox.Click += UploadLogo_Click;
            // 
            // CompanyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(802, 258);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CompanyForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "О компании...";
            Load += CompanyForm_Load;
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            panel.ResumeLayout(false);
            middlePanel.ResumeLayout(false);
            middlePanel.PerformLayout();
            bottomPanel.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)backButtonBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoUploadBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private PictureBox logoUploadBox;
        private Panel headerPanel;
        private PictureBox backButtonBox;
        private Label headerLabel;
        private ToolTip toolTip;
        private Panel bottomPanel;
        private Label currentMessage;
        private Panel middlePanel;
        private Label aboutLabel;
        private Label saveButton;
        private TextBox companyTitleTextBox;
    }
}