namespace YPMars
{
    partial class WarehouseReceiptControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblNomenclature;
        private System.Windows.Forms.ComboBox NomenclatureComboBox;
        private System.Windows.Forms.Label lblCurrentQty;
        private System.Windows.Forms.TextBox CurrentQuantityTextBox;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown QuantityNumericUpDown;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown UnitPriceNumericUpDown;
        private System.Windows.Forms.Button SaveButton;

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
            this.lblNomenclature = new System.Windows.Forms.Label();
            this.NomenclatureComboBox = new System.Windows.Forms.ComboBox();
            this.lblCurrentQty = new System.Windows.Forms.Label();
            this.CurrentQuantityTextBox = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.QuantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.UnitPriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitPriceNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomenclature
            // 
            this.lblNomenclature.AutoSize = true;
            this.lblNomenclature.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lblNomenclature.Location = new System.Drawing.Point(30, 40);
            this.lblNomenclature.Name = "lblNomenclature";
            this.lblNomenclature.Size = new System.Drawing.Size(129, 21);
            this.lblNomenclature.TabIndex = 0;
            this.lblNomenclature.Text = "Номенклатура:";
            // 
            // NomenclatureComboBox
            // 
            this.NomenclatureComboBox.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.NomenclatureComboBox.FormattingEnabled = true;
            this.NomenclatureComboBox.Location = new System.Drawing.Point(200, 37);
            this.NomenclatureComboBox.Name = "NomenclatureComboBox";
            this.NomenclatureComboBox.Size = new System.Drawing.Size(300, 29);
            this.NomenclatureComboBox.TabIndex = 1;
            this.NomenclatureComboBox.SelectedIndexChanged += new System.EventHandler(this.NomenclatureComboBox_SelectedIndexChanged);
            this.NomenclatureComboBox.TextChanged += new System.EventHandler(this.NomenclatureComboBox_SelectedIndexChanged);
            // 
            // lblCurrentQty
            // 
            this.lblCurrentQty.AutoSize = true;
            this.lblCurrentQty.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lblCurrentQty.Location = new System.Drawing.Point(30, 90);
            this.lblCurrentQty.Name = "lblCurrentQty";
            this.lblCurrentQty.Size = new System.Drawing.Size(148, 21);
            this.lblCurrentQty.TabIndex = 2;
            this.lblCurrentQty.Text = "Текущий остаток:";
            // 
            // CurrentQuantityTextBox
            // 
            this.CurrentQuantityTextBox.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.CurrentQuantityTextBox.Location = new System.Drawing.Point(200, 87);
            this.CurrentQuantityTextBox.Name = "CurrentQuantityTextBox";
            this.CurrentQuantityTextBox.ReadOnly = true;
            this.CurrentQuantityTextBox.Size = new System.Drawing.Size(300, 29);
            this.CurrentQuantityTextBox.TabIndex = 3;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lblQuantity.Location = new System.Drawing.Point(30, 140);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(116, 21);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Поступление:";
            // 
            // QuantityNumericUpDown
            // 
            this.QuantityNumericUpDown.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.QuantityNumericUpDown.Location = new System.Drawing.Point(200, 137);
            this.QuantityNumericUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.QuantityNumericUpDown.Name = "QuantityNumericUpDown";
            this.QuantityNumericUpDown.Size = new System.Drawing.Size(300, 29);
            this.QuantityNumericUpDown.TabIndex = 5;
            this.QuantityNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lblPrice.Location = new System.Drawing.Point(30, 190);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(103, 21);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Цена за ед.:";
            // 
            // UnitPriceNumericUpDown
            // 
            this.UnitPriceNumericUpDown.DecimalPlaces = 2;
            this.UnitPriceNumericUpDown.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.UnitPriceNumericUpDown.Location = new System.Drawing.Point(200, 187);
            this.UnitPriceNumericUpDown.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.UnitPriceNumericUpDown.Name = "UnitPriceNumericUpDown";
            this.UnitPriceNumericUpDown.Size = new System.Drawing.Size(300, 29);
            this.UnitPriceNumericUpDown.TabIndex = 7;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(200, 240);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(180, 35);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Оприходовать";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // WarehouseReceiptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.UnitPriceNumericUpDown);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.QuantityNumericUpDown);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.CurrentQuantityTextBox);
            this.Controls.Add(this.lblCurrentQty);
            this.Controls.Add(this.NomenclatureComboBox);
            this.Controls.Add(this.lblNomenclature);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "WarehouseReceiptControl";
            this.Size = new System.Drawing.Size(600, 350);
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitPriceNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
