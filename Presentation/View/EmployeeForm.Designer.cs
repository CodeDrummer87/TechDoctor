using Color = System.Drawing.Color;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
using SizeF = System.Drawing.SizeF;

namespace Presentation.View
{
    partial class EmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            panel = new GroupBox();
            emptyPersonnelNumberNotify = new Label();
            incorrectPostNotify = new Label();
            matchNotify = new Label();
            cancelButton = new Label();
            saveButton = new Label();
            employeeRelevance = new CheckBox();
            label6 = new Label();
            personnelNumberTextBox = new TextBox();
            label5 = new Label();
            postComboBox = new ComboBox();
            label3 = new Label();
            surnameTextBox = new TextBox();
            label2 = new Label();
            firstnameTextBox = new TextBox();
            label1 = new Label();
            lastnameTextBox = new TextBox();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.BackColor = SystemColors.GradientInactiveCaption;
            panel.Controls.Add(emptyPersonnelNumberNotify);
            panel.Controls.Add(incorrectPostNotify);
            panel.Controls.Add(matchNotify);
            panel.Controls.Add(cancelButton);
            panel.Controls.Add(saveButton);
            panel.Controls.Add(employeeRelevance);
            panel.Controls.Add(label6);
            panel.Controls.Add(personnelNumberTextBox);
            panel.Controls.Add(label5);
            panel.Controls.Add(postComboBox);
            panel.Controls.Add(label3);
            panel.Controls.Add(surnameTextBox);
            panel.Controls.Add(label2);
            panel.Controls.Add(firstnameTextBox);
            panel.Controls.Add(label1);
            panel.Controls.Add(lastnameTextBox);
            panel.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            panel.ForeColor = Color.DarkSlateGray;
            panel.Location = new Point(12, 12);
            panel.Name = "panel";
            panel.Size = new Size(632, 308);
            panel.TabIndex = 0;
            panel.TabStop = false;
            panel.Text = "Новый сотрудник";
            // 
            // emptyPersonnelNumberNotify
            // 
            emptyPersonnelNumberNotify.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            emptyPersonnelNumberNotify.ForeColor = Color.Red;
            emptyPersonnelNumberNotify.Location = new Point(420, 149);
            emptyPersonnelNumberNotify.Name = "emptyPersonnelNumberNotify";
            emptyPersonnelNumberNotify.Size = new Size(204, 24);
            emptyPersonnelNumberNotify.TabIndex = 17;
            emptyPersonnelNumberNotify.Text = "укажите табельный номер";
            emptyPersonnelNumberNotify.Visible = false;
            // 
            // incorrectPostNotify
            // 
            incorrectPostNotify.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            incorrectPostNotify.ForeColor = Color.Red;
            incorrectPostNotify.Location = new Point(407, 33);
            incorrectPostNotify.Name = "incorrectPostNotify";
            incorrectPostNotify.Size = new Size(217, 25);
            incorrectPostNotify.TabIndex = 16;
            incorrectPostNotify.Text = "выберите другую должность";
            incorrectPostNotify.TextAlign = ContentAlignment.BottomLeft;
            incorrectPostNotify.Visible = false;
            // 
            // matchNotify
            // 
            matchNotify.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            matchNotify.ForeColor = Color.Red;
            matchNotify.Location = new Point(352, 91);
            matchNotify.Name = "matchNotify";
            matchNotify.Size = new Size(272, 25);
            matchNotify.TabIndex = 15;
            matchNotify.Text = "данный табельный номер уже занят";
            matchNotify.TextAlign = ContentAlignment.BottomLeft;
            matchNotify.Visible = false;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.DarkSlateGray;
            cancelButton.Cursor = Cursors.Hand;
            cancelButton.ForeColor = Color.Wheat;
            cancelButton.Location = new Point(6, 262);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(220, 25);
            cancelButton.TabIndex = 14;
            cancelButton.Text = "Отмена";
            cancelButton.TextAlign = ContentAlignment.MiddleCenter;
            cancelButton.Click += CancelButton_Click;
            cancelButton.MouseEnter += Button_MouseEnter;
            cancelButton.MouseLeave += Button_MouseLeave;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.DarkSlateGray;
            saveButton.Cursor = Cursors.Hand;
            saveButton.Enabled = false;
            saveButton.ForeColor = Color.Wheat;
            saveButton.Location = new Point(277, 262);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(347, 25);
            saveButton.TabIndex = 13;
            saveButton.Text = "Сохранить";
            saveButton.TextAlign = ContentAlignment.MiddleCenter;
            saveButton.Click += SaveButton_Click;
            saveButton.MouseEnter += Button_MouseEnter;
            saveButton.MouseLeave += Button_MouseLeave;
            // 
            // employeeRelevance
            // 
            employeeRelevance.AutoSize = true;
            employeeRelevance.Checked = true;
            employeeRelevance.CheckState = CheckState.Checked;
            employeeRelevance.Cursor = Cursors.Hand;
            employeeRelevance.Location = new Point(277, 180);
            employeeRelevance.Name = "employeeRelevance";
            employeeRelevance.Size = new Size(273, 24);
            employeeRelevance.TabIndex = 12;
            employeeRelevance.Text = "действующий сотрудник";
            employeeRelevance.UseVisualStyleBackColor = true;
            employeeRelevance.CheckedChanged += ChangeCheckBox;
            // 
            // label6
            // 
            label6.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(277, 91);
            label6.Name = "label6";
            label6.Size = new Size(347, 24);
            label6.TabIndex = 11;
            label6.Text = "Таб.N";
            label6.TextAlign = ContentAlignment.BottomLeft;
            // 
            // personnelNumberTextBox
            // 
            personnelNumberTextBox.Location = new Point(277, 118);
            personnelNumberTextBox.Name = "personnelNumberTextBox";
            personnelNumberTextBox.Size = new Size(347, 28);
            personnelNumberTextBox.TabIndex = 10;
            personnelNumberTextBox.TextAlign = HorizontalAlignment.Center;
            personnelNumberTextBox.TextChanged += ValidateEnteredData;
            personnelNumberTextBox.KeyPress += CheckKeyPress;
            // 
            // label5
            // 
            label5.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(277, 33);
            label5.Name = "label5";
            label5.Size = new Size(347, 24);
            label5.TabIndex = 9;
            label5.Text = "Должность";
            label5.TextAlign = ContentAlignment.BottomLeft;
            // 
            // postComboBox
            // 
            postComboBox.Cursor = Cursors.Hand;
            postComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            postComboBox.FormattingEnabled = true;
            postComboBox.Location = new Point(277, 60);
            postComboBox.Name = "postComboBox";
            postComboBox.Size = new Size(347, 28);
            postComboBox.TabIndex = 8;
            postComboBox.SelectedIndexChanged += PostComboBox_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(6, 149);
            label3.Name = "label3";
            label3.Size = new Size(220, 24);
            label3.TabIndex = 5;
            label3.Text = "Отчество";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // surnameTextBox
            // 
            surnameTextBox.Location = new Point(6, 176);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new Size(220, 28);
            surnameTextBox.TabIndex = 4;
            surnameTextBox.TextAlign = HorizontalAlignment.Center;
            surnameTextBox.TextChanged += ValidateEnteredData;
            // 
            // label2
            // 
            label2.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(6, 91);
            label2.Name = "label2";
            label2.Size = new Size(220, 24);
            label2.TabIndex = 3;
            label2.Text = "Имя";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // firstnameTextBox
            // 
            firstnameTextBox.Location = new Point(6, 118);
            firstnameTextBox.Name = "firstnameTextBox";
            firstnameTextBox.Size = new Size(220, 28);
            firstnameTextBox.TabIndex = 2;
            firstnameTextBox.TextAlign = HorizontalAlignment.Center;
            firstnameTextBox.TextChanged += ValidateEnteredData;
            // 
            // label1
            // 
            label1.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 33);
            label1.Name = "label1";
            label1.Size = new Size(220, 24);
            label1.TabIndex = 1;
            label1.Text = "Фамилия";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lastnameTextBox
            // 
            lastnameTextBox.Location = new Point(6, 60);
            lastnameTextBox.Name = "lastnameTextBox";
            lastnameTextBox.Size = new Size(220, 28);
            lastnameTextBox.TabIndex = 0;
            lastnameTextBox.TextAlign = HorizontalAlignment.Center;
            lastnameTextBox.TextChanged += ValidateEnteredData;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(654, 331);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EmployeeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Новый сотрудник";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox panel;
        private Label label1;
        private TextBox lastnameTextBox;
        private Label label5;
        private ComboBox postComboBox;
        private Label label3;
        private TextBox surnameTextBox;
        private Label label2;
        private TextBox firstnameTextBox;
        private CheckBox employeeRelevance;
        private Label label6;
        private TextBox personnelNumberTextBox;
        private Label saveButton;
        private Label cancelButton;
        private Label matchNotify;
        private Label incorrectPostNotify;
        private Label emptyPersonnelNumberNotify;
    }
}