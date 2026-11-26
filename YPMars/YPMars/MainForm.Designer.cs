namespace YPMars
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button RegistrButton;
        private System.Windows.Forms.Label UserInfoLabel;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOrders;
        private System.Windows.Forms.TabPage tabWarehouse;
        private System.Windows.Forms.TabPage tabReceipt;
        private System.Windows.Forms.TabPage tabWriteOff;

        // Элементы вкладки "Заказы"
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label CounterpartyLabel;
        private System.Windows.Forms.ComboBox cmbCounterparty;
        private System.Windows.Forms.Button ApplyFilterButton;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.DateTimePicker StartDateDatetimePick;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.DateTimePicker EndDateDatetimePick;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button NewOrderButton;
        private System.Windows.Forms.Button OrderDetailsButton;
        private System.Windows.Forms.Button GenerateReportButton; // ДОБАВЛЕНО

        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label TotalCountLabel;
        private System.Windows.Forms.Label TotalSumLabel;
        private System.Windows.Forms.DataGridView OrdersDataGridView;

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.ComboBox StatusCoboBox;
        private System.Windows.Forms.Button ChangeStatusButton;

        // Вкладки поступления, списания и склада
        private WarehouseControl warehouseControl1;
        private WarehouseReceiptControl warehouseReceiptControl1;
        private WarehouseWriteOffControl warehouseWriteOffControl1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.UserInfoLabel = new System.Windows.Forms.Label();
            this.RegistrButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.OrdersDataGridView = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusCoboBox = new System.Windows.Forms.ComboBox();
            this.ChangeStatusButton = new System.Windows.Forms.Button();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.TotalCountLabel = new System.Windows.Forms.Label();
            this.TotalSumLabel = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.GenerateReportButton = new System.Windows.Forms.Button();
            this.OrderDetailsButton = new System.Windows.Forms.Button();
            this.CounterpartyLabel = new System.Windows.Forms.Label();
            this.cmbCounterparty = new System.Windows.Forms.ComboBox();
            this.ApplyFilterButton = new System.Windows.Forms.Button();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.StartDateDatetimePick = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.EndDateDatetimePick = new System.Windows.Forms.DateTimePicker();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.NewOrderButton = new System.Windows.Forms.Button();
            this.tabWarehouse = new System.Windows.Forms.TabPage();
            this.tabReceipt = new System.Windows.Forms.TabPage();
            this.tabWriteOff = new System.Windows.Forms.TabPage();
            this.warehouseControl1 = new YPMars.WarehouseControl();
            this.warehouseReceiptControl1 = new YPMars.WarehouseReceiptControl();
            this.warehouseWriteOffControl1 = new YPMars.WarehouseWriteOffControl();
            this.panelHeader.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataGridView)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panelSummary.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.tabWarehouse.SuspendLayout();
            this.tabReceipt.SuspendLayout();
            this.tabWriteOff.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHeader.Controls.Add(this.UserInfoLabel);
            this.panelHeader.Controls.Add(this.RegistrButton);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1340, 40);
            this.panelHeader.TabIndex = 4;
            // 
            // UserInfoLabel
            // 
            this.UserInfoLabel.AutoSize = true;
            this.UserInfoLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.UserInfoLabel.Location = new System.Drawing.Point(15, 8);
            this.UserInfoLabel.Name = "UserInfoLabel";
            this.UserInfoLabel.Size = new System.Drawing.Size(0, 21);
            this.UserInfoLabel.TabIndex = 1;
            // 
            // RegistrButton
            // 
            this.RegistrButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RegistrButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.RegistrButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegistrButton.FlatAppearance.BorderSize = 0;
            this.RegistrButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegistrButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrButton.ForeColor = System.Drawing.Color.White;
            this.RegistrButton.Location = new System.Drawing.Point(1160, 5);
            this.RegistrButton.Name = "RegistrButton";
            this.RegistrButton.Size = new System.Drawing.Size(165, 28);
            this.RegistrButton.TabIndex = 0;
            this.RegistrButton.Text = "Регистрация ";
            this.RegistrButton.UseVisualStyleBackColor = false;
            this.RegistrButton.Click += new System.EventHandler(this.RegistrButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabOrders);
            this.tabControl1.Controls.Add(this.tabWarehouse);
            this.tabControl1.Controls.Add(this.tabReceipt);
            this.tabControl1.Controls.Add(this.tabWriteOff);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1340, 610);
            this.tabControl1.TabIndex = 5;
            // 
            // tabOrders
            // 
            this.tabOrders.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabOrders.Controls.Add(this.OrdersDataGridView);
            this.tabOrders.Controls.Add(this.panelBottom);
            this.tabOrders.Controls.Add(this.panelSummary);
            this.tabOrders.Controls.Add(this.panelTop);
            this.tabOrders.Location = new System.Drawing.Point(4, 28);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrders.Size = new System.Drawing.Size(1332, 578);
            this.tabOrders.TabIndex = 0;
            this.tabOrders.Text = "Заказы";
            // 
            // OrdersDataGridView
            // 
            this.OrdersDataGridView.AllowUserToAddRows = false;
            this.OrdersDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.OrdersDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.OrdersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OrdersDataGridView.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.OrdersDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OrdersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.OrdersDataGridView.ColumnHeadersHeight = 32;
            this.OrdersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdersDataGridView.Location = new System.Drawing.Point(3, 88);
            this.OrdersDataGridView.MultiSelect = false;
            this.OrdersDataGridView.Name = "OrdersDataGridView";
            this.OrdersDataGridView.ReadOnly = true;
            this.OrdersDataGridView.RowHeadersVisible = false;
            this.OrdersDataGridView.RowTemplate.Height = 28;
            this.OrdersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrdersDataGridView.Size = new System.Drawing.Size(1326, 432);
            this.OrdersDataGridView.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.StatusLabel);
            this.panelBottom.Controls.Add(this.StatusCoboBox);
            this.panelBottom.Controls.Add(this.ChangeStatusButton);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(3, 520);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1326, 55);
            this.panelBottom.TabIndex = 1;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.StatusLabel.Location = new System.Drawing.Point(12, 17);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(120, 20);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Новый статус:";
            // 
            // StatusCoboBox
            // 
            this.StatusCoboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusCoboBox.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.StatusCoboBox.FormattingEnabled = true;
            this.StatusCoboBox.Location = new System.Drawing.Point(135, 13);
            this.StatusCoboBox.Name = "StatusCoboBox";
            this.StatusCoboBox.Size = new System.Drawing.Size(190, 28);
            this.StatusCoboBox.TabIndex = 1;
            // 
            // ChangeStatusButton
            // 
            this.ChangeStatusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.ChangeStatusButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangeStatusButton.FlatAppearance.BorderSize = 0;
            this.ChangeStatusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeStatusButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.ChangeStatusButton.ForeColor = System.Drawing.Color.White;
            this.ChangeStatusButton.Location = new System.Drawing.Point(340, 13);
            this.ChangeStatusButton.Name = "ChangeStatusButton";
            this.ChangeStatusButton.Size = new System.Drawing.Size(150, 28);
            this.ChangeStatusButton.TabIndex = 2;
            this.ChangeStatusButton.Text = "Изменить статус";
            this.ChangeStatusButton.UseVisualStyleBackColor = false;
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSummary.Controls.Add(this.TotalCountLabel);
            this.panelSummary.Controls.Add(this.TotalSumLabel);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummary.Location = new System.Drawing.Point(3, 53);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(1326, 35);
            this.panelSummary.TabIndex = 2;
            // 
            // TotalCountLabel
            // 
            this.TotalCountLabel.AutoSize = true;
            this.TotalCountLabel.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.TotalCountLabel.ForeColor = System.Drawing.Color.Black;
            this.TotalCountLabel.Location = new System.Drawing.Point(12, 7);
            this.TotalCountLabel.Name = "TotalCountLabel";
            this.TotalCountLabel.Size = new System.Drawing.Size(141, 20);
            this.TotalCountLabel.TabIndex = 0;
            this.TotalCountLabel.Text = "Всего заказов: 0";
            // 
            // TotalSumLabel
            // 
            this.TotalSumLabel.AutoSize = true;
            this.TotalSumLabel.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.TotalSumLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.TotalSumLabel.Location = new System.Drawing.Point(250, 7);
            this.TotalSumLabel.Name = "TotalSumLabel";
            this.TotalSumLabel.Size = new System.Drawing.Size(225, 20);
            this.TotalSumLabel.TabIndex = 1;
            this.TotalSumLabel.Text = "Итоговая сумма: 0,00 руб.";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.GenerateReportButton);
            this.panelTop.Controls.Add(this.OrderDetailsButton);
            this.panelTop.Controls.Add(this.CounterpartyLabel);
            this.panelTop.Controls.Add(this.cmbCounterparty);
            this.panelTop.Controls.Add(this.ApplyFilterButton);
            this.panelTop.Controls.Add(this.StartDateLabel);
            this.panelTop.Controls.Add(this.StartDateDatetimePick);
            this.panelTop.Controls.Add(this.EndDateLabel);
            this.panelTop.Controls.Add(this.EndDateDatetimePick);
            this.panelTop.Controls.Add(this.RefreshButton);
            this.panelTop.Controls.Add(this.NewOrderButton);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1326, 50);
            this.panelTop.TabIndex = 3;
            // 
            // GenerateReportButton
            // 
            this.GenerateReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateReportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.GenerateReportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GenerateReportButton.FlatAppearance.BorderSize = 0;
            this.GenerateReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateReportButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.GenerateReportButton.ForeColor = System.Drawing.Color.White;
            this.GenerateReportButton.Location = new System.Drawing.Point(908, 9);
            this.GenerateReportButton.Name = "GenerateReportButton";
            this.GenerateReportButton.Size = new System.Drawing.Size(132, 28);
            this.GenerateReportButton.TabIndex = 11;
            this.GenerateReportButton.Text = "Отчет";
            this.GenerateReportButton.UseVisualStyleBackColor = false;
            this.GenerateReportButton.Click += new System.EventHandler(this.GenerateReportButton_Click);
            // 
            // OrderDetailsButton
            // 
            this.OrderDetailsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.OrderDetailsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OrderDetailsButton.FlatAppearance.BorderSize = 0;
            this.OrderDetailsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrderDetailsButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.OrderDetailsButton.ForeColor = System.Drawing.Color.White;
            this.OrderDetailsButton.Location = new System.Drawing.Point(864, 10);
            this.OrderDetailsButton.Name = "OrderDetailsButton";
            this.OrderDetailsButton.Size = new System.Drawing.Size(131, 28);
            this.OrderDetailsButton.TabIndex = 10;
            this.OrderDetailsButton.Text = "Состав заказа";
            this.OrderDetailsButton.UseVisualStyleBackColor = false;
            this.OrderDetailsButton.Click += new System.EventHandler(this.OrderDetailsButton_Click);
            // 
            // CounterpartyLabel
            // 
            this.CounterpartyLabel.AutoSize = true;
            this.CounterpartyLabel.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.CounterpartyLabel.Location = new System.Drawing.Point(10, 13);
            this.CounterpartyLabel.Name = "CounterpartyLabel";
            this.CounterpartyLabel.Size = new System.Drawing.Size(101, 20);
            this.CounterpartyLabel.TabIndex = 0;
            this.CounterpartyLabel.Text = "Контрагент:";
            // 
            // cmbCounterparty
            // 
            this.cmbCounterparty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCounterparty.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.cmbCounterparty.FormattingEnabled = true;
            this.cmbCounterparty.Location = new System.Drawing.Point(112, 10);
            this.cmbCounterparty.Name = "cmbCounterparty";
            this.cmbCounterparty.Size = new System.Drawing.Size(180, 28);
            this.cmbCounterparty.TabIndex = 1;
            // 
            // ApplyFilterButton
            // 
            this.ApplyFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.ApplyFilterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ApplyFilterButton.FlatAppearance.BorderSize = 0;
            this.ApplyFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyFilterButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.ApplyFilterButton.ForeColor = System.Drawing.Color.White;
            this.ApplyFilterButton.Location = new System.Drawing.Point(303, 10);
            this.ApplyFilterButton.Name = "ApplyFilterButton";
            this.ApplyFilterButton.Size = new System.Drawing.Size(90, 28);
            this.ApplyFilterButton.TabIndex = 2;
            this.ApplyFilterButton.Text = "Фильтр";
            this.ApplyFilterButton.UseVisualStyleBackColor = false;
            this.ApplyFilterButton.Click += new System.EventHandler(this.ApplyFilterButton_Click);
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.StartDateLabel.Location = new System.Drawing.Point(396, 13);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(105, 20);
            this.StartDateLabel.TabIndex = 3;
            this.StartDateLabel.Text = "Дата начала:";
            // 
            // StartDateDatetimePick
            // 
            this.StartDateDatetimePick.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.StartDateDatetimePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDateDatetimePick.Location = new System.Drawing.Point(501, 10);
            this.StartDateDatetimePick.Name = "StartDateDatetimePick";
            this.StartDateDatetimePick.Size = new System.Drawing.Size(110, 28);
            this.StartDateDatetimePick.TabIndex = 4;
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.EndDateLabel.Location = new System.Drawing.Point(614, 13);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(135, 20);
            this.EndDateLabel.TabIndex = 5;
            this.EndDateLabel.Text = "Дата окончания:";
            // 
            // EndDateDatetimePick
            // 
            this.EndDateDatetimePick.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.EndDateDatetimePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDateDatetimePick.Location = new System.Drawing.Point(749, 10);
            this.EndDateDatetimePick.Name = "EndDateDatetimePick";
            this.EndDateDatetimePick.Size = new System.Drawing.Size(110, 28);
            this.EndDateDatetimePick.TabIndex = 6;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.RefreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshButton.FlatAppearance.BorderSize = 0;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.RefreshButton.ForeColor = System.Drawing.Color.White;
            this.RefreshButton.Location = new System.Drawing.Point(1046, 9);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(134, 28);
            this.RefreshButton.TabIndex = 7;
            this.RefreshButton.Text = "Обновить";
            this.RefreshButton.UseVisualStyleBackColor = false;
            // 
            // NewOrderButton
            // 
            this.NewOrderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewOrderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.NewOrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewOrderButton.FlatAppearance.BorderSize = 0;
            this.NewOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewOrderButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.NewOrderButton.ForeColor = System.Drawing.Color.White;
            this.NewOrderButton.Location = new System.Drawing.Point(1186, 10);
            this.NewOrderButton.Name = "NewOrderButton";
            this.NewOrderButton.Size = new System.Drawing.Size(132, 28);
            this.NewOrderButton.TabIndex = 8;
            this.NewOrderButton.Text = "Новый заказ";
            this.NewOrderButton.UseVisualStyleBackColor = false;
            // 
            // tabWarehouse
            // 
            this.tabWarehouse.Controls.Add(this.warehouseControl1);
            this.tabWarehouse.Location = new System.Drawing.Point(4, 28);
            this.tabWarehouse.Name = "tabWarehouse";
            this.tabWarehouse.Padding = new System.Windows.Forms.Padding(3);
            this.tabWarehouse.Size = new System.Drawing.Size(1332, 578);
            this.tabWarehouse.TabIndex = 1;
            this.tabWarehouse.Text = "Склад";
            this.tabWarehouse.UseVisualStyleBackColor = true;
            // 
            // tabReceipt
            // 
            this.tabReceipt.Controls.Add(this.warehouseReceiptControl1);
            this.tabReceipt.Location = new System.Drawing.Point(4, 28);
            this.tabReceipt.Name = "tabReceipt";
            this.tabReceipt.Padding = new System.Windows.Forms.Padding(3);
            this.tabReceipt.Size = new System.Drawing.Size(1332, 578);
            this.tabReceipt.TabIndex = 2;
            this.tabReceipt.Text = "Поступление";
            this.tabReceipt.UseVisualStyleBackColor = true;
            // 
            // tabWriteOff
            // 
            this.tabWriteOff.Controls.Add(this.warehouseWriteOffControl1);
            this.tabWriteOff.Location = new System.Drawing.Point(4, 28);
            this.tabWriteOff.Name = "tabWriteOff";
            this.tabWriteOff.Padding = new System.Windows.Forms.Padding(3);
            this.tabWriteOff.Size = new System.Drawing.Size(1332, 578);
            this.tabWriteOff.TabIndex = 3;
            this.tabWriteOff.Text = "Списание";
            this.tabWriteOff.UseVisualStyleBackColor = true;
            // 
            // warehouseControl1
            // 
            this.warehouseControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.warehouseControl1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.warehouseControl1.Location = new System.Drawing.Point(3, 3);
            this.warehouseControl1.Name = "warehouseControl1";
            this.warehouseControl1.Size = new System.Drawing.Size(1326, 572);
            this.warehouseControl1.TabIndex = 0;
            // 
            // warehouseReceiptControl1
            // 
            this.warehouseReceiptControl1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.warehouseReceiptControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.warehouseReceiptControl1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.warehouseReceiptControl1.Location = new System.Drawing.Point(3, 3);
            this.warehouseReceiptControl1.Name = "warehouseReceiptControl1";
            this.warehouseReceiptControl1.Size = new System.Drawing.Size(1326, 572);
            this.warehouseReceiptControl1.TabIndex = 0;
            // 
            // warehouseWriteOffControl1
            // 
            this.warehouseWriteOffControl1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.warehouseWriteOffControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.warehouseWriteOffControl1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.warehouseWriteOffControl1.Location = new System.Drawing.Point(3, 3);
            this.warehouseWriteOffControl1.Name = "warehouseWriteOffControl1";
            this.warehouseWriteOffControl1.Size = new System.Drawing.Size(1326, 572);
            this.warehouseWriteOffControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1340, 650);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная форма (Завод МАРС)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataGridView)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.tabWarehouse.ResumeLayout(false);
            this.tabReceipt.ResumeLayout(false);
            this.tabWriteOff.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}