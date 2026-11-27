namespace YPMars
{
    partial class WarehouseWriteOffControl
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
        private System.Windows.Forms.Button ReportButton; // ДОБАВЛЕНО

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
            this.ReportButton = new System.Windows.Forms.Button(); // ДОБАВЛЕНО
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // NomenclatureLabel
            // 
            this.NomenclatureLabel.AutoSize = true;
            this.NomenclatureLabel.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.NomenclatureLabel.Location = new System.Drawing.Point(30, 40);
            this.NomenclatureLabel.Name = "NomenclatureLabel";
            this.NomenclatureLabel.Size = new System.Drawing.Size(129, 21);
            this.NomenclatureLabel.TabIndex = 0;
            this.NomenclatureLabel.Text = "Номенклатура:";
            // 
            // NomenclatureComboBox
            // 
            this.NomenclatureComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.NomenclatureComboBox.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.NomenclatureComboBox.Location = new System.Drawing.Point(200, 37);
            this.NomenclatureComboBox.Name = "NomenclatureComboBox";
            this.NomenclatureComboBox.Size = new System.Drawing.Size(300, 29);
            this.NomenclatureComboBox.TabIndex = 1;
            // 
            // AvailableQuantityLabel
            // 
            this.AvailableQuantityLabel.AutoSize = true;
            this.AvailableQuantityLabel.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.AvailableQuantityLabel.ForeColor = System.Drawing.Color.DimGray;
            this.AvailableQuantityLabel.Location = new System.Drawing.Point(200, 72);
            this.AvailableQuantityLabel.Name = "AvailableQuantityLabel";
            this.AvailableQuantityLabel.Size = new System.Drawing.Size(122, 20);
            this.AvailableQuantityLabel.TabIndex = 2;
            this.AvailableQuantityLabel.Text = "Доступно: 0 шт.";
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.QuantityLabel.Location = new System.Drawing.Point(30, 120);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(105, 21);
            this.QuantityLabel.TabIndex = 3;
            this.QuantityLabel.Text = "Количество:";
            // 
            // QuantityNumeric
            // 
            this.QuantityNumeric.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.QuantityNumeric.Location = new System.Drawing.Point(200, 117);
            this.QuantityNumeric.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.QuantityNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.QuantityNumeric.Name = "QuantityNumeric";
            this.QuantityNumeric.Size = new System.Drawing.Size(150, 29);
            this.QuantityNumeric.TabIndex = 4;
            this.QuantityNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.PriceLabel.Location = new System.Drawing.Point(30, 170);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(103, 21);
            this.PriceLabel.TabIndex = 5;
            this.PriceLabel.Text = "Цена за ед.:";
            // 
            // UnitPriceTextBox
            // 
            this.UnitPriceTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UnitPriceTextBox.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.UnitPriceTextBox.Location = new System.Drawing.Point(200, 167);
            this.UnitPriceTextBox.Name = "UnitPriceTextBox";
            this.UnitPriceTextBox.ReadOnly = true;
            this.UnitPriceTextBox.Size = new System.Drawing.Size(150, 29);
            this.UnitPriceTextBox.TabIndex = 6;
            // 
            // TotalSumLabel
            // 
            this.TotalSumLabel.AutoSize = true;
            this.TotalSumLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.TotalSumLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.TotalSumLabel.Location = new System.Drawing.Point(30, 220);
            this.TotalSumLabel.Name = "TotalSumLabel";
            this.TotalSumLabel.Size = new System.Drawing.Size(163, 22);
            this.TotalSumLabel.TabIndex = 7;
            this.TotalSumLabel.Text = "Сумма: 0,00 руб.";
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(200, 260);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(150, 35);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Списать";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ReportButton (ДОБАВЛЕНО)
            // 
            this.ReportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.ReportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReportButton.FlatAppearance.BorderSize = 0;
            this.ReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.ReportButton.ForeColor = System.Drawing.Color.White;
            this.ReportButton.Location = new System.Drawing.Point(370, 260);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(190, 35);
            this.ReportButton.TabIndex = 9;
            this.ReportButton.Text = "Отчет по списаниям";
            this.ReportButton.UseVisualStyleBackColor = false;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // WarehouseWriteOffControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(this.ReportButton); // ДОБАВЛЕНО
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.TotalSumLabel);
            this.Controls.Add(this.UnitPriceTextBox);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.QuantityNumeric);
            this.Controls.Add(this.QuantityLabel);
            this.Controls.Add(this.AvailableQuantityLabel);
            this.Controls.Add(this.NomenclatureComboBox);
            this.Controls.Add(this.NomenclatureLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "WarehouseWriteOffControl";
            this.Size = new System.Drawing.Size(600, 350);
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
