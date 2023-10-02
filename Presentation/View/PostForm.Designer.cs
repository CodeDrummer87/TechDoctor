using Color = System.Drawing.Color;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
using SizeF = System.Drawing.SizeF;

namespace Presentation.View
{
    partial class PostForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostForm));
            panel = new GroupBox();
            cancelButton = new Label();
            savePostButton = new Label();
            postRelevance = new CheckBox();
            postNameBox = new TextBox();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.BackColor = SystemColors.GradientInactiveCaption;
            panel.Controls.Add(cancelButton);
            panel.Controls.Add(savePostButton);
            panel.Controls.Add(postRelevance);
            panel.Controls.Add(postNameBox);
            panel.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            panel.ForeColor = Color.DarkSlateGray;
            panel.Location = new Point(12, 12);
            panel.Name = "panel";
            panel.Size = new Size(697, 125);
            panel.TabIndex = 0;
            panel.TabStop = false;
            panel.Text = "Создание новой должности";
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.DarkSlateGray;
            cancelButton.Cursor = Cursors.Hand;
            cancelButton.ForeColor = Color.Wheat;
            cancelButton.Location = new Point(15, 82);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(323, 25);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Отмена";
            cancelButton.TextAlign = ContentAlignment.MiddleCenter;
            cancelButton.Click += CancelButton_Click;
            cancelButton.MouseEnter += Button_MouseEnter;
            cancelButton.MouseLeave += Button_MouseLeave;
            // 
            // savePostButton
            // 
            savePostButton.BackColor = Color.DarkSlateGray;
            savePostButton.Cursor = Cursors.Hand;
            savePostButton.Enabled = false;
            savePostButton.ForeColor = Color.Wheat;
            savePostButton.Location = new Point(344, 82);
            savePostButton.Name = "savePostButton";
            savePostButton.Size = new Size(337, 25);
            savePostButton.TabIndex = 2;
            savePostButton.Text = "Сохранить";
            savePostButton.TextAlign = ContentAlignment.MiddleCenter;
            savePostButton.Click += SavePostButton_Click;
            savePostButton.MouseEnter += Button_MouseEnter;
            savePostButton.MouseLeave += Button_MouseLeave;
            // 
            // postRelevance
            // 
            postRelevance.AutoSize = true;
            postRelevance.Checked = true;
            postRelevance.CheckState = CheckState.Checked;
            postRelevance.Cursor = Cursors.Hand;
            postRelevance.Location = new Point(506, 41);
            postRelevance.Name = "postRelevance";
            postRelevance.Size = new Size(175, 24);
            postRelevance.TabIndex = 1;
            postRelevance.Text = "Релевантность";
            postRelevance.UseVisualStyleBackColor = true;
            // 
            // postNameBox
            // 
            postNameBox.Location = new Point(15, 39);
            postNameBox.Name = "postNameBox";
            postNameBox.Size = new Size(485, 28);
            postNameBox.TabIndex = 0;
            postNameBox.TextChanged += FieldText_Changed;
            postNameBox.KeyPress += FieldText_Changed;
            // 
            // PostForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(721, 149);
            Controls.Add(panel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PostForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Новая должность";
            TopMost = true;
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox panel;
        private TextBox postNameBox;
        private CheckBox postRelevance;
        private Label savePostButton;
        private Label cancelButton;
    }
}