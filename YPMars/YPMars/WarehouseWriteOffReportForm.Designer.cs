namespace YPMars
{
    partial class WarehouseWriteOffReportForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.DataGridView ReportDataGridView;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label SummaryLabel;
        private System.Windows.Forms.Button ExportDocxButton;
        private System.Windows.Forms.Button CloseButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.ReportDataGridView = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.SummaryLabel = new System.Windows.Forms.Label();
            this.ExportDocxButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataGridView)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelTop.Controls.Add(this.StartDateLabel);
            this.panelTop.Controls.Add(this.ExportDocxButton);
            this.panelTop.Controls.Add(this.StartDatePicker);
            this.panelTop.Controls.Add(this.EndDateLabel);
            this.panelTop.Controls.Add(this.EndDatePicker);
            this.panelTop.Controls.Add(this.GenerateButton);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 50);
            this.panelTop.TabIndex = 2;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.StartDateLabel.Location = new System.Drawing.Point(15, 15);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(25, 20);
            this.StartDateLabel.TabIndex = 0;
            this.StartDateLabel.Text = "С:";
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDatePicker.Location = new System.Drawing.Point(50, 12);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(120, 28);
            this.StartDatePicker.TabIndex = 1;
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.EndDateLabel.Location = new System.Drawing.Point(190, 15);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(35, 20);
            this.EndDateLabel.TabIndex = 2;
            this.EndDateLabel.Text = "По:";
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDatePicker.Location = new System.Drawing.Point(230, 12);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(120, 28);
            this.EndDatePicker.TabIndex = 3;
            // 
            // GenerateButton
            // 
            this.GenerateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.GenerateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GenerateButton.FlatAppearance.BorderSize = 0;
            this.GenerateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateButton.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.GenerateButton.ForeColor = System.Drawing.Color.White;
            this.GenerateButton.Location = new System.Drawing.Point(370, 12);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(150, 28);
            this.GenerateButton.TabIndex = 4;
            this.GenerateButton.Text = "Сформировать";
            this.GenerateButton.UseVisualStyleBackColor = false;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // ReportDataGridView
            // 
            this.ReportDataGridView.AllowUserToAddRows = false;
            this.ReportDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ReportDataGridView.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.ReportDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ReportDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportDataGridView.Location = new System.Drawing.Point(0, 50);
            this.ReportDataGridView.Name = "ReportDataGridView";
            this.ReportDataGridView.ReadOnly = true;
            this.ReportDataGridView.RowHeadersVisible = false;
            this.ReportDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReportDataGridView.Size = new System.Drawing.Size(900, 395);
            this.ReportDataGridView.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelBottom.Controls.Add(this.SummaryLabel);
            this.panelBottom.Controls.Add(this.CloseButton);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 445);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(900, 55);
            this.panelBottom.TabIndex = 1;
            // 
            // SummaryLabel
            // 
            this.SummaryLabel.AutoSize = true;
            this.SummaryLabel.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.SummaryLabel.Location = new System.Drawing.Point(15, 17);
            this.SummaryLabel.Name = "SummaryLabel";
            this.SummaryLabel.Size = new System.Drawing.Size(651, 20);
            this.SummaryLabel.TabIndex = 0;
            this.SummaryLabel.Text = "Всего строк: 0. Суммарное количество: 0 шт. Суммарная стоимость: 0,00 руб.";
            // 
            // ExportDocxButton
            // 
            this.ExportDocxButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportDocxButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.ExportDocxButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExportDocxButton.FlatAppearance.BorderSize = 0;
            this.ExportDocxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportDocxButton.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.ExportDocxButton.ForeColor = System.Drawing.Color.White;
            this.ExportDocxButton.Location = new System.Drawing.Point(543, 12);
            this.ExportDocxButton.Name = "ExportDocxButton";
            this.ExportDocxButton.Size = new System.Drawing.Size(170, 30);
            this.ExportDocxButton.TabIndex = 1;
            this.ExportDocxButton.Text = "Выгрузить в Word";
            this.ExportDocxButton.UseVisualStyleBackColor = false;
            this.ExportDocxButton.Click += new System.EventHandler(this.ExportDocxButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(1485, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 30);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // WarehouseWriteOffReportForm
            // 
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.ReportDataGridView);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "WarehouseWriteOffReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отчёт по списаниям";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataGridView)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}