namespace YPMars
{
    partial class OrderDetailsForm
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

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDetailsForm));
            this.panelSummary = new System.Windows.Forms.Panel();
            this.SummaryLabel = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.AddItemButton = new System.Windows.Forms.Button();
            this.EditItemButton = new System.Windows.Forms.Button();
            this.DeleteItemButton = new System.Windows.Forms.Button();
            this.ItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSummary.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSummary.Controls.Add(this.SummaryLabel);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummary.Location = new System.Drawing.Point(0, 0);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(784, 35);
            this.panelSummary.TabIndex = 1;
            // 
            // SummaryLabel
            // 
            this.SummaryLabel.AutoSize = true;
            this.SummaryLabel.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.SummaryLabel.ForeColor = System.Drawing.Color.Black;
            this.SummaryLabel.Location = new System.Drawing.Point(12, 7);
            this.SummaryLabel.Name = "SummaryLabel";
            this.SummaryLabel.Size = new System.Drawing.Size(406, 20);
            this.SummaryLabel.TabIndex = 0;
            this.SummaryLabel.Text = "В заказе нет позиций. Итоговая сумма: 0,00 руб.";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.AddItemButton);
            this.panelBottom.Controls.Add(this.EditItemButton);
            this.panelBottom.Controls.Add(this.DeleteItemButton);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 445);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(784, 55);
            this.panelBottom.TabIndex = 2;
            // 
            // AddItemButton
            // 
            this.AddItemButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.AddItemButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddItemButton.FlatAppearance.BorderSize = 0;
            this.AddItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddItemButton.Font = new System.Drawing.Font("Times New Roman", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddItemButton.ForeColor = System.Drawing.Color.White;
            this.AddItemButton.Location = new System.Drawing.Point(12, 13);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(165, 28);
            this.AddItemButton.TabIndex = 0;
            this.AddItemButton.Text = "Добавить позицию";
            this.AddItemButton.UseVisualStyleBackColor = false;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);
            // 
            // EditItemButton
            // 
            this.EditItemButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.EditItemButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditItemButton.FlatAppearance.BorderSize = 0;
            this.EditItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditItemButton.Font = new System.Drawing.Font("Times New Roman", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditItemButton.ForeColor = System.Drawing.Color.White;
            this.EditItemButton.Location = new System.Drawing.Point(190, 13);
            this.EditItemButton.Name = "EditItemButton";
            this.EditItemButton.Size = new System.Drawing.Size(195, 28);
            this.EditItemButton.TabIndex = 1;
            this.EditItemButton.Text = "Редактировать позицию";
            this.EditItemButton.UseVisualStyleBackColor = false;
            this.EditItemButton.Click += new System.EventHandler(this.EditItemButton_Click);
            // 
            // DeleteItemButton
            // 
            this.DeleteItemButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.DeleteItemButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteItemButton.FlatAppearance.BorderSize = 0;
            this.DeleteItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteItemButton.Font = new System.Drawing.Font("Times New Roman", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteItemButton.ForeColor = System.Drawing.Color.White;
            this.DeleteItemButton.Location = new System.Drawing.Point(398, 13);
            this.DeleteItemButton.Name = "DeleteItemButton";
            this.DeleteItemButton.Size = new System.Drawing.Size(160, 28);
            this.DeleteItemButton.TabIndex = 2;
            this.DeleteItemButton.Text = "Удалить позицию";
            this.DeleteItemButton.UseVisualStyleBackColor = false;
            // 
            // ItemsDataGridView
            // 
            this.ItemsDataGridView.AllowUserToAddRows = false;
            this.ItemsDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ItemsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ItemsDataGridView.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.ItemsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ItemsDataGridView.ColumnHeadersHeight = 32;
            this.ItemsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colQuantity,
            this.colUnitPrice,
            this.colTotalPrice});
            this.ItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsDataGridView.Location = new System.Drawing.Point(0, 35);
            this.ItemsDataGridView.MultiSelect = false;
            this.ItemsDataGridView.Name = "ItemsDataGridView";
            this.ItemsDataGridView.ReadOnly = true;
            this.ItemsDataGridView.RowHeadersVisible = false;
            this.ItemsDataGridView.RowTemplate.Height = 28;
            this.ItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemsDataGridView.Size = new System.Drawing.Size(784, 410);
            this.ItemsDataGridView.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "NomenclatureName";
            this.colName.HeaderText = "Наименование";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 330;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "Quantity";
            this.colQuantity.HeaderText = "Количество";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Width = 120;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            this.colUnitPrice.HeaderText = "Цена за ед.";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            this.colUnitPrice.Width = 150;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.DataPropertyName = "TotalPrice";
            this.colTotalPrice.HeaderText = "Сумма";
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.ReadOnly = true;
            this.colTotalPrice.Width = 160;
            // 
            // OrderDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 500);
            this.Controls.Add(this.ItemsDataGridView);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelSummary);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Состав заказа";
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label SummaryLabel;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button AddItemButton;
        private System.Windows.Forms.Button EditItemButton;
        private System.Windows.Forms.Button DeleteItemButton;
        private System.Windows.Forms.DataGridView ItemsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPrice;
    }
}