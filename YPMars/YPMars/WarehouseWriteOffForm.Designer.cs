namespace YPMars
{
    partial class WarehouseWriteOffForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label NomenclatureLabel;
        private System.Windows.Forms.ComboBox NomenclatureComboBox;
        private System.Windows.Forms.Label AvailableQuantityLabel;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.NumericUpDown QuantityNumeric;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.TextBox UnitPriceTextBox;
        private System.Windows.Forms.Label TotalSumLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.NomenclatureLabel = new System.Windows.Forms.Label();
            this.NomenclatureComboBox = new System.Windows.Forms.ComboBox();
            this.AvailableQuantityLabel = new System.Windows.Forms.Label();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.QuantityNumeric = new System.Windows.Forms.NumericUpDown();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.UnitPriceTextBox = new System.Windows.Forms.TextBox();
            this.TotalSumLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // NomenclatureLabel
            // 
            this.NomenclatureLabel.AutoSize = true;
            this.NomenclatureLabel.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.NomenclatureLabel.Location = new System.Drawing.Point(15, 20);
            this.NomenclatureLabel.Name = "NomenclatureLabel";
            this.NomenclatureLabel.Size = new System.Drawing.Size(124, 20);
            this.NomenclatureLabel.TabIndex = 0;
            this.NomenclatureLabel.Text = "Номенклатура:";
            // 
            // NomenclatureComboBox
            // 
            this.NomenclatureComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NomenclatureComboBox.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.NomenclatureComboBox.Location = new System.Drawing.Point(160, 17);
            this.NomenclatureComboBox.Name = "NomenclatureComboBox";
            this.NomenclatureComboBox.Size = new System.Drawing.Size(250, 28);
            this.NomenclatureComboBox.TabIndex = 1;
            // 
            // AvailableQuantityLabel
            // 
            this.AvailableQuantityLabel.AutoSize = true;
            this.AvailableQuantityLabel.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.AvailableQuantityLabel.ForeColor = System.Drawing.Color.DimGray;
            this.AvailableQuantityLabel.Location = new System.Drawing.Point(160, 50);
            this.AvailableQuantityLabel.Name = "AvailableQuantityLabel";
            this.AvailableQuantityLabel.Size = new System.Drawing.Size(115, 19);
            this.AvailableQuantityLabel.TabIndex = 2;
            this.AvailableQuantityLabel.Text = "Доступно: 0 шт.";
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.QuantityLabel.Location = new System.Drawing.Point(15, 85);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(103, 20);
            this.QuantityLabel.TabIndex = 3;
            this.QuantityLabel.Text = "Количество:";
            // 
            // QuantityNumeric
            // 
            this.QuantityNumeric.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.QuantityNumeric.Location = new System.Drawing.Point(160, 82);
            this.QuantityNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.QuantityNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QuantityNumeric.Name = "QuantityNumeric";
            this.QuantityNumeric.Size = new System.Drawing.Size(120, 28);
            this.QuantityNumeric.TabIndex = 4;
            this.QuantityNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.PriceLabel.Location = new System.Drawing.Point(15, 130);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(99, 20);
            this.PriceLabel.TabIndex = 5;
            this.PriceLabel.Text = "Цена за ед.:";
            // 
            // UnitPriceTextBox
            // 
            this.UnitPriceTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UnitPriceTextBox.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.UnitPriceTextBox.Location = new System.Drawing.Point(160, 127);
            this.UnitPriceTextBox.Name = "UnitPriceTextBox";
            this.UnitPriceTextBox.ReadOnly = true;
            this.UnitPriceTextBox.Size = new System.Drawing.Size(150, 28);
            this.UnitPriceTextBox.TabIndex = 6;
            // 
            // TotalSumLabel
            // 
            this.TotalSumLabel.AutoSize = true;
            this.TotalSumLabel.Font = new System.Drawing.Font("Times New Roman", 13.25F, System.Drawing.FontStyle.Bold);
            this.TotalSumLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.TotalSumLabel.Location = new System.Drawing.Point(15, 175);
            this.TotalSumLabel.Name = "TotalSumLabel";
            this.TotalSumLabel.Size = new System.Drawing.Size(145, 20);
            this.TotalSumLabel.TabIndex = 7;
            this.TotalSumLabel.Text = "Сумма: 0,00 руб.";
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(160, 210);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(115, 30);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Списать";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.CancelButton.ForeColor = System.Drawing.Color.White;
            this.CancelButton.Location = new System.Drawing.Point(295, 210);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(115, 30);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // WarehouseWriteOffForm
            // 
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(430, 260);
            this.Controls.Add(this.NomenclatureLabel);
            this.Controls.Add(this.NomenclatureComboBox);
            this.Controls.Add(this.AvailableQuantityLabel);
            this.Controls.Add(this.QuantityLabel);
            this.Controls.Add(this.QuantityNumeric);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.UnitPriceTextBox);
            this.Controls.Add(this.TotalSumLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WarehouseWriteOffForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Списание со склада";
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}