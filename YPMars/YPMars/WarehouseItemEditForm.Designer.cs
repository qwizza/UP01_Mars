namespace YPMars
{
    partial class WarehouseItemEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblNomenclature;
        private System.Windows.Forms.TextBox NomenclatureTextBox;
        private System.Windows.Forms.Label lblStorageZone;
        private System.Windows.Forms.ComboBox StorageZoneComboBox;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.NumericUpDown UnitPriceNumeric;
        private System.Windows.Forms.Label StockInfoLabel;
        private System.Windows.Forms.Label lblReserve;
        private System.Windows.Forms.NumericUpDown ReserveNumeric;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarehouseItemEditForm));
            this.lblNomenclature = new System.Windows.Forms.Label();
            this.NomenclatureTextBox = new System.Windows.Forms.TextBox();
            this.lblStorageZone = new System.Windows.Forms.Label();
            this.StorageZoneComboBox = new System.Windows.Forms.ComboBox();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.UnitPriceNumeric = new System.Windows.Forms.NumericUpDown();
            this.StockInfoLabel = new System.Windows.Forms.Label();
            this.lblReserve = new System.Windows.Forms.Label();
            this.ReserveNumeric = new System.Windows.Forms.NumericUpDown();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UnitPriceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveNumeric)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNomenclature
            // 
            this.lblNomenclature.AutoSize = true;
            this.lblNomenclature.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lblNomenclature.Location = new System.Drawing.Point(20, 25);
            this.lblNomenclature.Name = "lblNomenclature";
            this.lblNomenclature.Size = new System.Drawing.Size(128, 21);
            this.lblNomenclature.TabIndex = 0;
            this.lblNomenclature.Text = "Номенклатура:";
            // 
            // NomenclatureTextBox
            // 
            this.NomenclatureTextBox.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.NomenclatureTextBox.Location = new System.Drawing.Point(215, 22);
            this.NomenclatureTextBox.Name = "NomenclatureTextBox";
            this.NomenclatureTextBox.ReadOnly = true;
            this.NomenclatureTextBox.Size = new System.Drawing.Size(265, 29);
            this.NomenclatureTextBox.TabIndex = 1;
            // 
            // lblStorageZone
            // 
            this.lblStorageZone.AutoSize = true;
            this.lblStorageZone.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lblStorageZone.Location = new System.Drawing.Point(20, 71);
            this.lblStorageZone.Name = "lblStorageZone";
            this.lblStorageZone.Size = new System.Drawing.Size(131, 21);
            this.lblStorageZone.TabIndex = 2;
            this.lblStorageZone.Text = "Зона хранения:";
            // 
            // StorageZoneComboBox
            // 
            this.StorageZoneComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StorageZoneComboBox.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.StorageZoneComboBox.FormattingEnabled = true;
            this.StorageZoneComboBox.Location = new System.Drawing.Point(215, 68);
            this.StorageZoneComboBox.Name = "StorageZoneComboBox";
            this.StorageZoneComboBox.Size = new System.Drawing.Size(265, 29);
            this.StorageZoneComboBox.TabIndex = 3;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lblUnitPrice.Location = new System.Drawing.Point(20, 117);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(153, 21);
            this.lblUnitPrice.TabIndex = 4;
            this.lblUnitPrice.Text = "Цена за ед. (руб.):";
            // 
            // UnitPriceNumeric
            // 
            this.UnitPriceNumeric.DecimalPlaces = 2;
            this.UnitPriceNumeric.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.UnitPriceNumeric.Location = new System.Drawing.Point(215, 114);
            this.UnitPriceNumeric.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.UnitPriceNumeric.Name = "UnitPriceNumeric";
            this.UnitPriceNumeric.Size = new System.Drawing.Size(160, 29);
            this.UnitPriceNumeric.TabIndex = 5;
            // 
            // StockInfoLabel
            // 
            this.StockInfoLabel.AutoSize = true;
            this.StockInfoLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.StockInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(160)))));
            this.StockInfoLabel.Location = new System.Drawing.Point(20, 160);
            this.StockInfoLabel.Name = "StockInfoLabel";
            this.StockInfoLabel.Size = new System.Drawing.Size(342, 19);
            this.StockInfoLabel.TabIndex = 6;
            this.StockInfoLabel.Text = "Всего: 0 шт. | В резерве: 0 шт. | Доступно: 0 шт.";
            // 
            // lblReserve
            // 
            this.lblReserve.AutoSize = true;
            this.lblReserve.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lblReserve.Location = new System.Drawing.Point(20, 201);
            this.lblReserve.Name = "lblReserve";
            this.lblReserve.Size = new System.Drawing.Size(168, 21);
            this.lblReserve.TabIndex = 7;
            this.lblReserve.Text = "Положить в резерв:";
            // 
            // ReserveNumeric
            // 
            this.ReserveNumeric.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.ReserveNumeric.Location = new System.Drawing.Point(215, 198);
            this.ReserveNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ReserveNumeric.Name = "ReserveNumeric";
            this.ReserveNumeric.Size = new System.Drawing.Size(160, 29);
            this.ReserveNumeric.TabIndex = 8;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.SaveButton);
            this.panelBottom.Controls.Add(this.CancelButton);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 265);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(500, 55);
            this.panelBottom.TabIndex = 9;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(235, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(115, 32);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.CancelButton.ForeColor = System.Drawing.Color.White;
            this.CancelButton.Location = new System.Drawing.Point(365, 12);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(115, 32);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // WarehouseItemEditForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 320);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.ReserveNumeric);
            this.Controls.Add(this.lblReserve);
            this.Controls.Add(this.StockInfoLabel);
            this.Controls.Add(this.UnitPriceNumeric);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.StorageZoneComboBox);
            this.Controls.Add(this.lblStorageZone);
            this.Controls.Add(this.NomenclatureTextBox);
            this.Controls.Add(this.lblNomenclature);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WarehouseItemEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование позиции на складе";
            ((System.ComponentModel.ISupportInitialize)(this.UnitPriceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveNumeric)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}