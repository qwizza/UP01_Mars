namespace YPMars
{
    partial class ReceiptItemEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblNomenclature;
        private System.Windows.Forms.ComboBox NomenclatureComboBox;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown QuantityNumericUpDown;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown UnitPriceNumericUpDown;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptItemEditForm));
            this.lblNomenclature = new System.Windows.Forms.Label();
            this.NomenclatureComboBox = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.QuantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.UnitPriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitPriceNumericUpDown)).BeginInit();
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
            this.lblNomenclature.TabIndex = 6;
            this.lblNomenclature.Text = "Номенклатура:";
            // 
            // NomenclatureComboBox
            // 
            this.NomenclatureComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.NomenclatureComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.NomenclatureComboBox.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.NomenclatureComboBox.Location = new System.Drawing.Point(167, 22);
            this.NomenclatureComboBox.Name = "NomenclatureComboBox";
            this.NomenclatureComboBox.Size = new System.Drawing.Size(250, 29);
            this.NomenclatureComboBox.TabIndex = 5;
            this.NomenclatureComboBox.SelectedIndexChanged += new System.EventHandler(this.NomenclatureComboBox_SelectedIndexChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lblQuantity.Location = new System.Drawing.Point(20, 70);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(109, 21);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Количество:";
            // 
            // QuantityNumericUpDown
            // 
            this.QuantityNumericUpDown.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.QuantityNumericUpDown.Location = new System.Drawing.Point(167, 68);
            this.QuantityNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.QuantityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QuantityNumericUpDown.Name = "QuantityNumericUpDown";
            this.QuantityNumericUpDown.Size = new System.Drawing.Size(150, 29);
            this.QuantityNumericUpDown.TabIndex = 3;
            this.QuantityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lblPrice.Location = new System.Drawing.Point(20, 115);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(153, 21);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "Цена за ед. (руб.):";
            // 
            // UnitPriceNumericUpDown
            // 
            this.UnitPriceNumericUpDown.DecimalPlaces = 2;
            this.UnitPriceNumericUpDown.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.UnitPriceNumericUpDown.Location = new System.Drawing.Point(167, 113);
            this.UnitPriceNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.UnitPriceNumericUpDown.Name = "UnitPriceNumericUpDown";
            this.UnitPriceNumericUpDown.Size = new System.Drawing.Size(150, 29);
            this.UnitPriceNumericUpDown.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelBottom.Controls.Add(this.SaveButton);
            this.panelBottom.Controls.Add(this.CancelButton);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 165);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(440, 55);
            this.panelBottom.TabIndex = 0;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(175, 12);
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
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.CancelButton.ForeColor = System.Drawing.Color.White;
            this.CancelButton.Location = new System.Drawing.Point(305, 12);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(115, 32);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ReceiptItemEditForm
            // 
            this.ClientSize = new System.Drawing.Size(440, 220);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.UnitPriceNumericUpDown);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.QuantityNumericUpDown);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.NomenclatureComboBox);
            this.Controls.Add(this.lblNomenclature);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceiptItemEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры позиции";
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitPriceNumericUpDown)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}