using Presentation.Properties;
using static Presentation.Forms.MainPage;

namespace Presentation.View
{
    partial class EmployeeSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeSettingsForm));
            logoBox = new PictureBox();
            filterBlock = new GroupBox();
            condition = new TextBox();
            relevanceFilter = new RadioButton();
            personnelNumberFilter = new RadioButton();
            postFilter = new RadioButton();
            lastnameFilter = new RadioButton();
            selectCondition = new ComboBox();
            toolTip = new ToolTip(components);
            editSelectedPostButton = new Label();
            editSelectedEmployeeButton = new Label();
            addPostButton = new Label();
            addEmployeeButton = new Label();
            removeSelectedPostButton = new Label();
            removeSelectedEmployeeButton = new Label();
            dataManagementHeader = new Label();
            currentPostListLabel = new Label();
            postComboBox = new ComboBox();
            docContextBindingSource = new BindingSource(components);
            displayRelevancePost = new CheckBox();
            employeeActionsLabel = new Label();
            sidePanel = new Panel();
            mainPanel = new Panel();
            dataPanel = new Panel();
            panel = new Panel();
            tableScrollProgressRight = new VerticalProgressBar();
            tableScrollProgressLeft = new VerticalProgressBar();
            footerTablePanel = new Panel();
            tableCurrentMessage = new Label();
            headerTablePanel = new Panel();
            headerTable = new TableLayoutPanel();
            headerTableFourth = new Label();
            headerTableThird = new Label();
            headerTableSecond = new Label();
            headerTableFirst = new Label();
            headerTableFifth = new Label();
            headerTableSeventh = new Label();
            footerPanel = new Panel();
            panel2 = new Panel();
            npcptLinkLabel = new LinkLabel();
            currentMessage = new Label();
            panel1 = new Panel();
            employeesHeader = new Label();
            buttonsPanel = new Panel();
            collapseAppBox = new PictureBox();
            quitAppButton = new PictureBox();
            themeSwitcher = new PictureBox();
            backToListBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            filterBlock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)docContextBindingSource).BeginInit();
            sidePanel.SuspendLayout();
            mainPanel.SuspendLayout();
            dataPanel.SuspendLayout();
            panel.SuspendLayout();
            footerTablePanel.SuspendLayout();
            headerTablePanel.SuspendLayout();
            headerTable.SuspendLayout();
            footerPanel.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)collapseAppBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)quitAppButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)themeSwitcher).BeginInit();
            ((System.ComponentModel.ISupportInitialize)backToListBox).BeginInit();
            SuspendLayout();
            // 
            // logoBox
            // 
            logoBox.Cursor = Cursors.Hand;
            logoBox.Dock = DockStyle.Top;
            logoBox.Image = Resources.logo;
            logoBox.Location = new Point(5, 5);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(275, 107);
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 0;
            logoBox.TabStop = false;
            toolTip.SetToolTip(logoBox, "Посетить сайт НПЦ \"ПромТех\"");
            logoBox.Click += Link_Click;
            // 
            // filterBlock
            // 
            filterBlock.Controls.Add(condition);
            filterBlock.Controls.Add(relevanceFilter);
            filterBlock.Controls.Add(personnelNumberFilter);
            filterBlock.Controls.Add(postFilter);
            filterBlock.Controls.Add(lastnameFilter);
            filterBlock.Controls.Add(selectCondition);
            filterBlock.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            filterBlock.ForeColor = Color.DarkSlateGray;
            filterBlock.Location = new Point(11, 141);
            filterBlock.Name = "filterBlock";
            filterBlock.Size = new Size(261, 211);
            filterBlock.TabIndex = 6;
            filterBlock.TabStop = false;
            filterBlock.Text = "Фильтрация";
            // 
            // condition
            // 
            condition.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            condition.Location = new Point(6, 171);
            condition.Name = "condition";
            condition.Size = new Size(249, 28);
            condition.TabIndex = 9;
            condition.TextAlign = HorizontalAlignment.Center;
            condition.TextChanged += FilterValueChanged;
            condition.KeyPress += CheckKeyPress;
            // 
            // relevanceFilter
            // 
            relevanceFilter.AutoSize = true;
            relevanceFilter.Checked = true;
            relevanceFilter.Cursor = Cursors.Hand;
            relevanceFilter.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            relevanceFilter.Location = new Point(15, 51);
            relevanceFilter.Name = "relevanceFilter";
            relevanceFilter.Size = new Size(205, 24);
            relevanceFilter.TabIndex = 3;
            relevanceFilter.TabStop = true;
            relevanceFilter.Tag = "relevance";
            relevanceFilter.Text = "по релевантности";
            relevanceFilter.UseVisualStyleBackColor = true;
            relevanceFilter.CheckedChanged += CheckedChanged;
            relevanceFilter.MouseEnter += RadioButton_MouseEnter;
            relevanceFilter.MouseLeave += RadioButton_MouseLeave;
            // 
            // personnelNumberFilter
            // 
            personnelNumberFilter.AutoSize = true;
            personnelNumberFilter.Cursor = Cursors.Hand;
            personnelNumberFilter.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            personnelNumberFilter.Location = new Point(15, 109);
            personnelNumberFilter.Name = "personnelNumberFilter";
            personnelNumberFilter.Size = new Size(121, 24);
            personnelNumberFilter.TabIndex = 2;
            personnelNumberFilter.Tag = "personnelNumber";
            personnelNumberFilter.Text = "по Таб. N";
            personnelNumberFilter.UseVisualStyleBackColor = true;
            personnelNumberFilter.CheckedChanged += CheckedChanged;
            personnelNumberFilter.MouseEnter += RadioButton_MouseEnter;
            personnelNumberFilter.MouseLeave += RadioButton_MouseLeave;
            // 
            // postFilter
            // 
            postFilter.AutoSize = true;
            postFilter.Cursor = Cursors.Hand;
            postFilter.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            postFilter.Location = new Point(15, 140);
            postFilter.Name = "postFilter";
            postFilter.Size = new Size(168, 24);
            postFilter.TabIndex = 1;
            postFilter.Tag = "post";
            postFilter.Text = "по должности";
            postFilter.UseVisualStyleBackColor = true;
            postFilter.CheckedChanged += CheckedChanged;
            postFilter.MouseEnter += RadioButton_MouseEnter;
            postFilter.MouseLeave += RadioButton_MouseLeave;
            // 
            // lastnameFilter
            // 
            lastnameFilter.AutoSize = true;
            lastnameFilter.Cursor = Cursors.Hand;
            lastnameFilter.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lastnameFilter.Location = new Point(15, 80);
            lastnameFilter.Name = "lastnameFilter";
            lastnameFilter.Size = new Size(149, 24);
            lastnameFilter.TabIndex = 0;
            lastnameFilter.Tag = "lastname";
            lastnameFilter.Text = "по фамилии";
            lastnameFilter.UseVisualStyleBackColor = true;
            lastnameFilter.CheckedChanged += CheckedChanged;
            lastnameFilter.MouseEnter += RadioButton_MouseEnter;
            lastnameFilter.MouseLeave += RadioButton_MouseLeave;
            // 
            // selectCondition
            // 
            selectCondition.BackColor = SystemColors.ButtonHighlight;
            selectCondition.Cursor = Cursors.Hand;
            selectCondition.DropDownStyle = ComboBoxStyle.DropDownList;
            selectCondition.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            selectCondition.FormattingEnabled = true;
            selectCondition.Items.AddRange(new object[] { "Уволенные", "Действующие" });
            selectCondition.Location = new Point(6, 171);
            selectCondition.Name = "selectCondition";
            selectCondition.RightToLeft = RightToLeft.No;
            selectCondition.Size = new Size(249, 28);
            selectCondition.TabIndex = 9;
            selectCondition.SelectedIndexChanged += SelectedIndexChanged;
            // 
            // editSelectedPostButton
            // 
            editSelectedPostButton.BackColor = Color.DarkSlateGray;
            editSelectedPostButton.Cursor = Cursors.Hand;
            editSelectedPostButton.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            editSelectedPostButton.ForeColor = Color.Wheat;
            editSelectedPostButton.Location = new Point(11, 541);
            editSelectedPostButton.Name = "editSelectedPostButton";
            editSelectedPostButton.Size = new Size(261, 25);
            editSelectedPostButton.TabIndex = 17;
            editSelectedPostButton.Text = "Изменить выбранную должность";
            editSelectedPostButton.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(editSelectedPostButton, "Редактировать должность, выбранную в выпадающем списке");
            editSelectedPostButton.Click += EditSelectedPostButton_Click;
            editSelectedPostButton.MouseEnter += Button_MouseEnter;
            editSelectedPostButton.MouseLeave += Button_MouseLeave;
            // 
            // editSelectedEmployeeButton
            // 
            editSelectedEmployeeButton.BackColor = Color.DarkSlateGray;
            editSelectedEmployeeButton.Cursor = Cursors.Hand;
            editSelectedEmployeeButton.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            editSelectedEmployeeButton.ForeColor = Color.Wheat;
            editSelectedEmployeeButton.Location = new Point(11, 677);
            editSelectedEmployeeButton.Name = "editSelectedEmployeeButton";
            editSelectedEmployeeButton.Size = new Size(261, 25);
            editSelectedEmployeeButton.TabIndex = 20;
            editSelectedEmployeeButton.Text = "Редактировать данные сотрудника";
            editSelectedEmployeeButton.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(editSelectedEmployeeButton, "Выберите сотрудника в таблице и нажмите эту кнопку, чтобы изменить его данные");
            editSelectedEmployeeButton.Click += EditSelectedEmployeeButton_Click;
            editSelectedEmployeeButton.MouseEnter += Button_MouseEnter;
            editSelectedEmployeeButton.MouseLeave += Button_MouseLeave;
            // 
            // addPostButton
            // 
            addPostButton.BackColor = Color.DarkSlateGray;
            addPostButton.Cursor = Cursors.Hand;
            addPostButton.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            addPostButton.ForeColor = Color.Wheat;
            addPostButton.Location = new Point(11, 597);
            addPostButton.Name = "addPostButton";
            addPostButton.Size = new Size(261, 25);
            addPostButton.TabIndex = 13;
            addPostButton.Text = "Добавить новую должность";
            addPostButton.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(addPostButton, "Создать новую должность");
            addPostButton.Click += AddPostButton_Click;
            addPostButton.MouseEnter += Button_MouseEnter;
            addPostButton.MouseLeave += Button_MouseLeave;
            // 
            // addEmployeeButton
            // 
            addEmployeeButton.BackColor = Color.DarkSlateGray;
            addEmployeeButton.Cursor = Cursors.Hand;
            addEmployeeButton.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            addEmployeeButton.ForeColor = Color.Wheat;
            addEmployeeButton.Location = new Point(11, 733);
            addEmployeeButton.Name = "addEmployeeButton";
            addEmployeeButton.Size = new Size(261, 25);
            addEmployeeButton.TabIndex = 14;
            addEmployeeButton.Text = "Добавить нового сотрудника";
            addEmployeeButton.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(addEmployeeButton, "Создать нового сотрудника");
            addEmployeeButton.Click += AddEmployeeButton_Click;
            addEmployeeButton.MouseEnter += Button_MouseEnter;
            addEmployeeButton.MouseLeave += Button_MouseLeave;
            // 
            // removeSelectedPostButton
            // 
            removeSelectedPostButton.BackColor = Color.DarkSlateGray;
            removeSelectedPostButton.Cursor = Cursors.Hand;
            removeSelectedPostButton.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            removeSelectedPostButton.ForeColor = Color.Wheat;
            removeSelectedPostButton.Location = new Point(11, 569);
            removeSelectedPostButton.Name = "removeSelectedPostButton";
            removeSelectedPostButton.Size = new Size(261, 25);
            removeSelectedPostButton.TabIndex = 15;
            removeSelectedPostButton.Text = "Удалить выбранную должность";
            removeSelectedPostButton.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(removeSelectedPostButton, "Удалить должность, выбранную в выпадающем списке");
            removeSelectedPostButton.Click += RemoveSelectedPostButton_Click;
            removeSelectedPostButton.MouseEnter += Button_MouseEnter;
            removeSelectedPostButton.MouseLeave += Button_MouseLeave;
            // 
            // removeSelectedEmployeeButton
            // 
            removeSelectedEmployeeButton.BackColor = Color.DarkSlateGray;
            removeSelectedEmployeeButton.Cursor = Cursors.Hand;
            removeSelectedEmployeeButton.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            removeSelectedEmployeeButton.ForeColor = Color.Wheat;
            removeSelectedEmployeeButton.Location = new Point(11, 705);
            removeSelectedEmployeeButton.Name = "removeSelectedEmployeeButton";
            removeSelectedEmployeeButton.Size = new Size(261, 25);
            removeSelectedEmployeeButton.TabIndex = 19;
            removeSelectedEmployeeButton.Text = "Удалить выбранного сотрудника";
            removeSelectedEmployeeButton.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(removeSelectedEmployeeButton, "Выберите сотрудника в таблице и нажмите эту кнопку, чтобы удалить его");
            removeSelectedEmployeeButton.Click += RemoveSelectedEmployeeButton_Click;
            removeSelectedEmployeeButton.MouseEnter += Button_MouseEnter;
            removeSelectedEmployeeButton.MouseLeave += Button_MouseLeave;
            // 
            // dataManagementHeader
            // 
            dataManagementHeader.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            dataManagementHeader.ForeColor = Color.DarkSlateGray;
            dataManagementHeader.Location = new Point(11, 437);
            dataManagementHeader.Name = "dataManagementHeader";
            dataManagementHeader.Size = new Size(261, 25);
            dataManagementHeader.TabIndex = 10;
            dataManagementHeader.Text = "Управление данными";
            dataManagementHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // currentPostListLabel
            // 
            currentPostListLabel.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            currentPostListLabel.Location = new Point(11, 463);
            currentPostListLabel.Name = "currentPostListLabel";
            currentPostListLabel.Size = new Size(261, 25);
            currentPostListLabel.TabIndex = 11;
            currentPostListLabel.Text = "текущий список должностей";
            currentPostListLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // postComboBox
            // 
            postComboBox.Cursor = Cursors.Hand;
            postComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            postComboBox.FormattingEnabled = true;
            postComboBox.Location = new Point(11, 491);
            postComboBox.Name = "postComboBox";
            postComboBox.Size = new Size(260, 28);
            postComboBox.TabIndex = 12;
            // 
            // docContextBindingSource
            // 
            docContextBindingSource.DataSource = typeof(Data.DocContext);
            // 
            // displayRelevancePost
            // 
            displayRelevancePost.AutoSize = true;
            displayRelevancePost.Checked = true;
            displayRelevancePost.CheckState = CheckState.Checked;
            displayRelevancePost.Cursor = Cursors.Hand;
            displayRelevancePost.Font = new Font("Verdana", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            displayRelevancePost.Location = new Point(19, 519);
            displayRelevancePost.Name = "displayRelevancePost";
            displayRelevancePost.Size = new Size(247, 20);
            displayRelevancePost.TabIndex = 16;
            displayRelevancePost.Text = "только релевантные должности";
            displayRelevancePost.UseVisualStyleBackColor = true;
            displayRelevancePost.CheckedChanged += PostRelevanceChanged;
            // 
            // employeeActionsLabel
            // 
            employeeActionsLabel.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            employeeActionsLabel.Location = new Point(11, 652);
            employeeActionsLabel.Name = "employeeActionsLabel";
            employeeActionsLabel.Size = new Size(261, 25);
            employeeActionsLabel.TabIndex = 18;
            employeeActionsLabel.Text = "действия с сотрудниками";
            employeeActionsLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // sidePanel
            // 
            sidePanel.Controls.Add(currentPostListLabel);
            sidePanel.Controls.Add(logoBox);
            sidePanel.Controls.Add(editSelectedEmployeeButton);
            sidePanel.Controls.Add(filterBlock);
            sidePanel.Controls.Add(dataManagementHeader);
            sidePanel.Controls.Add(removeSelectedEmployeeButton);
            sidePanel.Controls.Add(removeSelectedPostButton);
            sidePanel.Controls.Add(postComboBox);
            sidePanel.Controls.Add(displayRelevancePost);
            sidePanel.Controls.Add(employeeActionsLabel);
            sidePanel.Controls.Add(addEmployeeButton);
            sidePanel.Controls.Add(addPostButton);
            sidePanel.Controls.Add(editSelectedPostButton);
            sidePanel.Dock = DockStyle.Left;
            sidePanel.Location = new Point(5, 5);
            sidePanel.Margin = new Padding(3, 4, 3, 4);
            sidePanel.Name = "sidePanel";
            sidePanel.Padding = new Padding(5);
            sidePanel.Size = new Size(285, 818);
            sidePanel.TabIndex = 24;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(dataPanel);
            mainPanel.Controls.Add(footerPanel);
            mainPanel.Controls.Add(panel1);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(290, 5);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(5);
            mainPanel.Size = new Size(1284, 818);
            mainPanel.TabIndex = 25;
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
            dataPanel.TabIndex = 34;
            // 
            // panel
            // 
            panel.Controls.Add(tableScrollProgressRight);
            panel.Controls.Add(tableScrollProgressLeft);
            panel.Location = new Point(5, 69);
            panel.Margin = new Padding(3, 4, 3, 4);
            panel.Name = "panel";
            panel.Padding = new Padding(2, 0, 2, 0);
            panel.Size = new Size(1267, 545);
            panel.TabIndex = 2;
            // 
            // tableScrollProgressRight
            // 
            tableScrollProgressRight.Dock = DockStyle.Right;
            tableScrollProgressRight.Location = new Point(1255, 0);
            tableScrollProgressRight.Name = "tableScrollProgressRight";
            tableScrollProgressRight.RightToLeftLayout = true;
            tableScrollProgressRight.Size = new Size(10, 545);
            tableScrollProgressRight.TabIndex = 5;
            tableScrollProgressRight.Visible = false;
            // 
            // tableScrollProgressLeft
            // 
            tableScrollProgressLeft.Dock = DockStyle.Left;
            tableScrollProgressLeft.Location = new Point(2, 0);
            tableScrollProgressLeft.Name = "tableScrollProgressLeft";
            tableScrollProgressLeft.RightToLeftLayout = true;
            tableScrollProgressLeft.Size = new Size(10, 545);
            tableScrollProgressLeft.TabIndex = 4;
            tableScrollProgressLeft.Visible = false;
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
            headerTable.ColumnCount = 6;
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            headerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            headerTable.Controls.Add(headerTableFourth, 3, 0);
            headerTable.Controls.Add(headerTableThird, 2, 0);
            headerTable.Controls.Add(headerTableSecond, 1, 0);
            headerTable.Controls.Add(headerTableFirst, 0, 0);
            headerTable.Controls.Add(headerTableFifth, 4, 0);
            headerTable.Controls.Add(headerTableSeventh, 5, 0);
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
            headerTableFourth.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            headerTableFourth.ForeColor = Color.AntiqueWhite;
            headerTableFourth.Location = new Point(536, 0);
            headerTableFourth.Name = "headerTableFourth";
            headerTableFourth.Size = new Size(205, 46);
            headerTableFourth.TabIndex = 4;
            headerTableFourth.Text = "Отчество";
            headerTableFourth.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerTableThird
            // 
            headerTableThird.AutoSize = true;
            headerTableThird.BackColor = Color.DarkSlateGray;
            headerTableThird.Dock = DockStyle.Fill;
            headerTableThird.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            headerTableThird.ForeColor = Color.AntiqueWhite;
            headerTableThird.Location = new Point(325, 0);
            headerTableThird.Name = "headerTableThird";
            headerTableThird.Size = new Size(205, 46);
            headerTableThird.TabIndex = 3;
            headerTableThird.Text = "Имя";
            headerTableThird.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerTableSecond
            // 
            headerTableSecond.AutoSize = true;
            headerTableSecond.BackColor = Color.DarkSlateGray;
            headerTableSecond.Dock = DockStyle.Fill;
            headerTableSecond.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            headerTableSecond.ForeColor = Color.AntiqueWhite;
            headerTableSecond.Location = new Point(114, 0);
            headerTableSecond.Name = "headerTableSecond";
            headerTableSecond.Size = new Size(205, 46);
            headerTableSecond.TabIndex = 2;
            headerTableSecond.Text = "Фамилия";
            headerTableSecond.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerTableFirst
            // 
            headerTableFirst.AutoSize = true;
            headerTableFirst.BackColor = Color.DarkSlateGray;
            headerTableFirst.Dock = DockStyle.Fill;
            headerTableFirst.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            headerTableFirst.ForeColor = Color.AntiqueWhite;
            headerTableFirst.Location = new Point(3, 0);
            headerTableFirst.Name = "headerTableFirst";
            headerTableFirst.Size = new Size(105, 46);
            headerTableFirst.TabIndex = 1;
            headerTableFirst.Text = "Таб. N";
            headerTableFirst.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerTableFifth
            // 
            headerTableFifth.AutoSize = true;
            headerTableFifth.BackColor = Color.DarkSlateGray;
            headerTableFifth.Dock = DockStyle.Fill;
            headerTableFifth.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            headerTableFifth.ForeColor = Color.AntiqueWhite;
            headerTableFifth.Location = new Point(747, 0);
            headerTableFifth.Name = "headerTableFifth";
            headerTableFifth.Size = new Size(304, 46);
            headerTableFifth.TabIndex = 5;
            headerTableFifth.Text = "Должность";
            headerTableFifth.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // headerTableSeventh
            // 
            headerTableSeventh.AutoSize = true;
            headerTableSeventh.BackColor = Color.DarkSlateGray;
            headerTableSeventh.Dock = DockStyle.Fill;
            headerTableSeventh.Font = new Font("Verdana", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            headerTableSeventh.ForeColor = Color.AntiqueWhite;
            headerTableSeventh.Location = new Point(1057, 0);
            headerTableSeventh.Name = "headerTableSeventh";
            headerTableSeventh.Size = new Size(182, 46);
            headerTableSeventh.TabIndex = 6;
            headerTableSeventh.Text = "Релевантность";
            headerTableSeventh.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // footerPanel
            // 
            footerPanel.Controls.Add(panel2);
            footerPanel.Controls.Add(currentMessage);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(5, 752);
            footerPanel.Margin = new Padding(3, 4, 3, 4);
            footerPanel.Name = "footerPanel";
            footerPanel.Padding = new Padding(10, 5, 5, 5);
            footerPanel.Size = new Size(1274, 61);
            footerPanel.TabIndex = 33;
            // 
            // panel2
            // 
            panel2.Controls.Add(npcptLinkLabel);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(1129, 5);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5, 13, 5, 13);
            panel2.Size = new Size(140, 51);
            panel2.TabIndex = 13;
            // 
            // npcptLinkLabel
            // 
            npcptLinkLabel.ActiveLinkColor = Color.OrangeRed;
            npcptLinkLabel.Cursor = Cursors.Hand;
            npcptLinkLabel.Dock = DockStyle.Fill;
            npcptLinkLabel.Font = new Font("Courier New", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            npcptLinkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
            npcptLinkLabel.LinkColor = Color.DimGray;
            npcptLinkLabel.Location = new Point(5, 13);
            npcptLinkLabel.Name = "npcptLinkLabel";
            npcptLinkLabel.Size = new Size(130, 25);
            npcptLinkLabel.TabIndex = 11;
            npcptLinkLabel.TabStop = true;
            npcptLinkLabel.Text = "npcpt.com";
            npcptLinkLabel.TextAlign = ContentAlignment.MiddleCenter;
            npcptLinkLabel.Click += Link_Click;
            // 
            // currentMessage
            // 
            currentMessage.Dock = DockStyle.Fill;
            currentMessage.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            currentMessage.Location = new Point(10, 5);
            currentMessage.Name = "currentMessage";
            currentMessage.Size = new Size(1259, 51);
            currentMessage.TabIndex = 12;
            currentMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(employeesHeader);
            panel1.Controls.Add(buttonsPanel);
            panel1.Controls.Add(backToListBox);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(5, 5);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(1274, 61);
            panel1.TabIndex = 32;
            // 
            // employeesHeader
            // 
            employeesHeader.Dock = DockStyle.Fill;
            employeesHeader.Font = new Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            employeesHeader.ForeColor = Color.DarkSlateGray;
            employeesHeader.Location = new Point(48, 5);
            employeesHeader.Margin = new Padding(3, 4, 3, 4);
            employeesHeader.Name = "employeesHeader";
            employeesHeader.Size = new Size(1091, 51);
            employeesHeader.TabIndex = 31;
            employeesHeader.Text = "Сотрудники";
            employeesHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(collapseAppBox);
            buttonsPanel.Controls.Add(quitAppButton);
            buttonsPanel.Controls.Add(themeSwitcher);
            buttonsPanel.Dock = DockStyle.Right;
            buttonsPanel.Location = new Point(1139, 5);
            buttonsPanel.Margin = new Padding(3, 4, 3, 4);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(130, 51);
            buttonsPanel.TabIndex = 0;
            // 
            // collapseAppBox
            // 
            collapseAppBox.Cursor = Cursors.Hand;
            collapseAppBox.Image = Resources.collapse;
            collapseAppBox.Location = new Point(43, 0);
            collapseAppBox.Name = "collapseAppBox";
            collapseAppBox.Size = new Size(44, 51);
            collapseAppBox.SizeMode = PictureBoxSizeMode.Zoom;
            collapseAppBox.TabIndex = 3;
            collapseAppBox.TabStop = false;
            collapseAppBox.Click += CollapseAppBox_Click;
            collapseAppBox.MouseEnter += CollapseAppBox_MouseEnter;
            collapseAppBox.MouseLeave += CollapseAppBox_MouseLeave;
            // 
            // quitAppButton
            // 
            quitAppButton.Cursor = Cursors.Hand;
            quitAppButton.Dock = DockStyle.Right;
            quitAppButton.Image = Resources.quit;
            quitAppButton.Location = new Point(87, 0);
            quitAppButton.Name = "quitAppButton";
            quitAppButton.Size = new Size(43, 51);
            quitAppButton.SizeMode = PictureBoxSizeMode.Zoom;
            quitAppButton.TabIndex = 2;
            quitAppButton.TabStop = false;
            quitAppButton.Click += QuitAppButton_Click;
            quitAppButton.MouseEnter += QuitAppButton_MouseEnter;
            quitAppButton.MouseLeave += QuitAppButton_MouseLeave;
            // 
            // themeSwitcher
            // 
            themeSwitcher.Cursor = Cursors.Hand;
            themeSwitcher.Dock = DockStyle.Left;
            themeSwitcher.Image = Resources.dark_theme;
            themeSwitcher.Location = new Point(0, 0);
            themeSwitcher.Name = "themeSwitcher";
            themeSwitcher.Size = new Size(43, 51);
            themeSwitcher.SizeMode = PictureBoxSizeMode.Zoom;
            themeSwitcher.TabIndex = 23;
            themeSwitcher.TabStop = false;
            themeSwitcher.Click += ThemeSwitcher_Click;
            themeSwitcher.MouseEnter += ThemeSwitcher_MouseEnter;
            themeSwitcher.MouseLeave += ThemeSwith_MouseLeave;
            // 
            // backToListBox
            // 
            backToListBox.Cursor = Cursors.Hand;
            backToListBox.Dock = DockStyle.Left;
            backToListBox.Image = Resources.back_dark;
            backToListBox.Location = new Point(5, 5);
            backToListBox.Name = "backToListBox";
            backToListBox.Size = new Size(43, 51);
            backToListBox.SizeMode = PictureBoxSizeMode.Zoom;
            backToListBox.TabIndex = 4;
            backToListBox.TabStop = false;
            backToListBox.Click += BackToSettingsForm_Click;
            backToListBox.MouseEnter += BackToMatinPage_MouseEnter;
            backToListBox.MouseLeave += BackToMatinPage_MouseLeave;
            // 
            // EmployeeSettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1579, 828);
            Controls.Add(mainPanel);
            Controls.Add(sidePanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EmployeeSettingsForm";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Сотрудники";
            MouseDown += ThisForm_MouseDown;
            MouseMove += ThisForm_MouseMove;
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            filterBlock.ResumeLayout(false);
            filterBlock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)docContextBindingSource).EndInit();
            sidePanel.ResumeLayout(false);
            sidePanel.PerformLayout();
            mainPanel.ResumeLayout(false);
            dataPanel.ResumeLayout(false);
            panel.ResumeLayout(false);
            footerTablePanel.ResumeLayout(false);
            headerTablePanel.ResumeLayout(false);
            headerTable.ResumeLayout(false);
            headerTable.PerformLayout();
            footerPanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            buttonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)collapseAppBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)quitAppButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)themeSwitcher).EndInit();
            ((System.ComponentModel.ISupportInitialize)backToListBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox logoBox;
        private GroupBox filterBlock;
        private RadioButton lastnameFilter;
        private RadioButton postFilter;
        private RadioButton personnelNumberFilter;
        private RadioButton relevanceFilter;
        private TextBox condition;
        private ToolTip toolTip;
        private ComboBox selectCondition;
        private Label dataManagementHeader;
        private Label currentPostListLabel;
        private ComboBox postComboBox;
        private BindingSource docContextBindingSource;
        private Label addPostButton;
        private Label addEmployeeButton;
        private Label removeSelectedPostButton;
        private CheckBox displayRelevancePost;
        private Label editSelectedPostButton;
        private Label employeeActionsLabel;
        private Label removeSelectedEmployeeButton;
        private Label editSelectedEmployeeButton;
        private Panel sidePanel;
        private Panel mainPanel;
        private Panel panel1;
        private Panel buttonsPanel;
        private PictureBox collapseAppBox;
        private PictureBox quitAppButton;
        private PictureBox themeSwitcher;
        private PictureBox backToListBox;
        private Label employeesHeader;
        private Panel footerPanel;
        private Label currentMessage;
        private LinkLabel npcptLinkLabel;
        private Panel dataPanel;
        private Panel panel;
        private VerticalProgressBar tableScrollProgressRight;
        private VerticalProgressBar tableScrollProgressLeft;
        private Panel footerTablePanel;
        private Label tableCurrentMessage;
        private Panel headerTablePanel;
        private TableLayoutPanel headerTable;
        private Label headerTableFourth;
        private Label headerTableThird;
        private Label headerTableSecond;
        private Label headerTableFirst;
        private Label headerTableFifth;
        private Label headerTableSeventh;
        private Panel panel2;
    }
}