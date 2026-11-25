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
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataGridView)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            this.panelTop.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 50;
            this.panelTop.Controls.Add(this.StartDateLabel);
            this.panelTop.Controls.Add(this.StartDatePicker);
            this.panelTop.Controls.Add(this.EndDateLabel);
            this.panelTop.Controls.Add(this.EndDatePicker);
            this.panelTop.Controls.Add(this.GenerateButton);

            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.StartDateLabel.Location = new System.Drawing.Point(15, 15);
            this.StartDateLabel.Text = "С:";

            this.StartDatePicker.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDatePicker.Location = new System.Drawing.Point(50, 12);
            this.StartDatePicker.Size = new System.Drawing.Size(120, 28);

            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.EndDateLabel.Location = new System.Drawing.Point(190, 15);
            this.EndDateLabel.Text = "По:";

            this.EndDatePicker.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDatePicker.Location = new System.Drawing.Point(230, 12);
            this.EndDatePicker.Size = new System.Drawing.Size(120, 28);

            this.GenerateButton.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.GenerateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateButton.FlatAppearance.BorderSize = 0;
            this.GenerateButton.ForeColor = System.Drawing.Color.White;
            this.GenerateButton.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.GenerateButton.Location = new System.Drawing.Point(370, 12);
            this.GenerateButton.Size = new System.Drawing.Size(150, 28);
            this.GenerateButton.Text = "Сформировать";
            this.GenerateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);

            this.ReportDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportDataGridView.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.ReportDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ReportDataGridView.RowHeadersVisible = false;
            this.ReportDataGridView.AllowUserToAddRows = false;
            this.ReportDataGridView.ReadOnly = true;
            this.ReportDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReportDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.panelBottom.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 55;
            this.panelBottom.Controls.Add(this.SummaryLabel);
            this.panelBottom.Controls.Add(this.ExportDocxButton);
            this.panelBottom.Controls.Add(this.CloseButton);

            this.SummaryLabel.AutoSize = true;
            this.SummaryLabel.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.SummaryLabel.Location = new System.Drawing.Point(15, 17);
            this.SummaryLabel.Text = "Всего строк: 0. Суммарное количество: 0 шт. Суммарная стоимость: 0,00 руб.";

            this.ExportDocxButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.ExportDocxButton.BackColor = System.Drawing.Color.FromArgb(0, 150, 90);
            this.ExportDocxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportDocxButton.FlatAppearance.BorderSize = 0;
            this.ExportDocxButton.ForeColor = System.Drawing.Color.White;
            this.ExportDocxButton.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.ExportDocxButton.Location = new System.Drawing.Point(600, 12);
            this.ExportDocxButton.Size = new System.Drawing.Size(170, 30);
            this.ExportDocxButton.Text = "Выгрузить в Word";
            this.ExportDocxButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExportDocxButton.Click += new System.EventHandler(this.ExportDocxButton_Click);

            this.CloseButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.CloseButton.Location = new System.Drawing.Point(785, 12);
            this.CloseButton.Size = new System.Drawing.Size(100, 30);
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);

            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.ReportDataGridView);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отчёт по списаниям";

            ((System.ComponentModel.ISupportInitialize)(this.ReportDataGridView)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}