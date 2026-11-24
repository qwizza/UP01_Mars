namespace YPMars
{
    partial class WarehouseControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTopWarehouse;
        private System.Windows.Forms.Button RefreshButton;

        private System.Windows.Forms.Panel panelSummaryWarehouse;
        private System.Windows.Forms.Label TotalCountLabel;
        private System.Windows.Forms.Label TotalSumLabel;
        private System.Windows.Forms.Label TotalAvailableLabel;
        private System.Windows.Forms.Button ReceiptButton;

        private System.Windows.Forms.DataGridView WarehouseDataGridView;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTopWarehouse = new System.Windows.Forms.Panel();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.ReceiptButton = new System.Windows.Forms.Button();
            this.panelSummaryWarehouse = new System.Windows.Forms.Panel();
            this.TotalCountLabel = new System.Windows.Forms.Label();
            this.TotalSumLabel = new System.Windows.Forms.Label();
            this.TotalAvailableLabel = new System.Windows.Forms.Label();
            this.WarehouseDataGridView = new System.Windows.Forms.DataGridView();
            this.panelTopWarehouse.SuspendLayout();
            this.panelSummaryWarehouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTopWarehouse
            // 
            this.panelTopWarehouse.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelTopWarehouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopWarehouse.Controls.Add(this.RefreshButton);
            this.panelTopWarehouse.Controls.Add(this.ReceiptButton);
            this.panelTopWarehouse.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopWarehouse.Location = new System.Drawing.Point(0, 0);
            this.panelTopWarehouse.Name = "panelTopWarehouse";
            this.panelTopWarehouse.Size = new System.Drawing.Size(1340, 50);
            this.panelTopWarehouse.TabIndex = 0;
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
            this.RefreshButton.Location = new System.Drawing.Point(1054, 10);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(115, 28);
            this.RefreshButton.TabIndex = 0;
            this.RefreshButton.Text = "Обновить";
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ReceiptButton
            // 
            this.ReceiptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReceiptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.ReceiptButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReceiptButton.FlatAppearance.BorderSize = 0;
            this.ReceiptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReceiptButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.ReceiptButton.ForeColor = System.Drawing.Color.White;
            this.ReceiptButton.Location = new System.Drawing.Point(1175, 10);
            this.ReceiptButton.Name = "ReceiptButton";
            this.ReceiptButton.Size = new System.Drawing.Size(150, 28);
            this.ReceiptButton.TabIndex = 1;
            this.ReceiptButton.Text = "Поступление";
            this.ReceiptButton.UseVisualStyleBackColor = false;
            this.ReceiptButton.Click += new System.EventHandler(this.ReceiptButton_Click);
            // 
            // panelSummaryWarehouse
            // 
            this.panelSummaryWarehouse.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSummaryWarehouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSummaryWarehouse.Controls.Add(this.TotalCountLabel);
            this.panelSummaryWarehouse.Controls.Add(this.TotalSumLabel);
            this.panelSummaryWarehouse.Controls.Add(this.TotalAvailableLabel);
            this.panelSummaryWarehouse.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummaryWarehouse.Location = new System.Drawing.Point(0, 50);
            this.panelSummaryWarehouse.Name = "panelSummaryWarehouse";
            this.panelSummaryWarehouse.Size = new System.Drawing.Size(1340, 35);
            this.panelSummaryWarehouse.TabIndex = 1;
            // 
            // TotalCountLabel
            // 
            this.TotalCountLabel.AutoSize = true;
            this.TotalCountLabel.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.TotalCountLabel.Location = new System.Drawing.Point(12, 7);
            this.TotalCountLabel.Name = "TotalCountLabel";
            this.TotalCountLabel.Size = new System.Drawing.Size(229, 20);
            this.TotalCountLabel.TabIndex = 0;
            this.TotalCountLabel.Text = "Всего позиций на складе: 0";
            // 
            // TotalSumLabel
            // 
            this.TotalSumLabel.AutoSize = true;
            this.TotalSumLabel.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.TotalSumLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.TotalSumLabel.Location = new System.Drawing.Point(270, 7);
            this.TotalSumLabel.Name = "TotalSumLabel";
            this.TotalSumLabel.Size = new System.Drawing.Size(238, 20);
            this.TotalSumLabel.TabIndex = 1;
            this.TotalSumLabel.Text = "Общая стоимость: 0,00 руб.";
            // 
            // TotalAvailableLabel
            // 
            this.TotalAvailableLabel.AutoSize = true;
            this.TotalAvailableLabel.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.TotalAvailableLabel.Location = new System.Drawing.Point(580, 7);
            this.TotalAvailableLabel.Name = "TotalAvailableLabel";
            this.TotalAvailableLabel.Size = new System.Drawing.Size(230, 20);
            this.TotalAvailableLabel.TabIndex = 2;
            this.TotalAvailableLabel.Text = "Доступно к отгрузке: 0 шт.";
            // 
            // WarehouseDataGridView
            // 
            this.WarehouseDataGridView.AllowUserToAddRows = false;
            this.WarehouseDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.WarehouseDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.WarehouseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WarehouseDataGridView.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.WarehouseDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WarehouseDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.WarehouseDataGridView.ColumnHeadersHeight = 32;
            this.WarehouseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WarehouseDataGridView.Location = new System.Drawing.Point(0, 85);
            this.WarehouseDataGridView.MultiSelect = false;
            this.WarehouseDataGridView.Name = "WarehouseDataGridView";
            this.WarehouseDataGridView.ReadOnly = true;
            this.WarehouseDataGridView.RowHeadersVisible = false;
            this.WarehouseDataGridView.RowTemplate.Height = 28;
            this.WarehouseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WarehouseDataGridView.Size = new System.Drawing.Size(1340, 470);
            this.WarehouseDataGridView.TabIndex = 2;
            // 
            // WarehouseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WarehouseDataGridView);
            this.Controls.Add(this.panelSummaryWarehouse);
            this.Controls.Add(this.panelTopWarehouse);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "WarehouseControl";
            this.Size = new System.Drawing.Size(1340, 555);
            this.panelTopWarehouse.ResumeLayout(false);
            this.panelSummaryWarehouse.ResumeLayout(false);
            this.panelSummaryWarehouse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseDataGridView)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
