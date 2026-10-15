namespace YPMars
{
    partial class OrderEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label HeadLabel;
        private System.Windows.Forms.Label CounterpartyLabel;
        private System.Windows.Forms.ComboBox CounterpartyComboBox;
        private System.Windows.Forms.Label PlannedDateLabel;
        private System.Windows.Forms.DateTimePicker PlannedShipmentDatePicker;
        private System.Windows.Forms.Label NomenclatureLabel;
        private System.Windows.Forms.ComboBox NomenclatureComboBox;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.NumericUpDown QuantityNumeric;
        private System.Windows.Forms.Button AddItemButton;
        private System.Windows.Forms.DataGridView ItemsGrid;
        private System.Windows.Forms.Label TotalSumLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderEditForm));
            this.HeadLabel = new System.Windows.Forms.Label();
            this.CounterpartyLabel = new System.Windows.Forms.Label();
            this.CounterpartyComboBox = new System.Windows.Forms.ComboBox();
            this.PlannedDateLabel = new System.Windows.Forms.Label();
            this.PlannedShipmentDatePicker = new System.Windows.Forms.DateTimePicker();
            this.NomenclatureLabel = new System.Windows.Forms.Label();
            this.NomenclatureComboBox = new System.Windows.Forms.ComboBox();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.QuantityNumeric = new System.Windows.Forms.NumericUpDown();
            this.AddItemButton = new System.Windows.Forms.Button();
            this.ItemsGrid = new System.Windows.Forms.DataGridView();
            this.TotalSumLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsGrid)).BeginInit();
            this.SuspendLayout();

            // HeadLabel
            this.HeadLabel.AutoSize = true;
            this.HeadLabel.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular);
            this.HeadLabel.Location = new System.Drawing.Point(220, 9);
            this.HeadLabel.Name = "HeadLabel";
            this.HeadLabel.Size = new System.Drawing.Size(220, 31);
            this.HeadLabel.TabIndex = 0;
            this.HeadLabel.Text = "Новый заказ";

            // CounterpartyLabel
            this.CounterpartyLabel.AutoSize = true;
            this.CounterpartyLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.CounterpartyLabel.Location = new System.Drawing.Point(12, 60);
            this.CounterpartyLabel.Name = "CounterpartyLabel";
            this.CounterpartyLabel.Size = new System.Drawing.Size(104, 21);
            this.CounterpartyLabel.TabIndex = 1;
            this.CounterpartyLabel.Text = "Контрагент";

            // CounterpartyComboBox
            this.CounterpartyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CounterpartyComboBox.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.CounterpartyComboBox.Location = new System.Drawing.Point(190, 57);
            this.CounterpartyComboBox.Name = "CounterpartyComboBox";
            this.CounterpartyComboBox.Size = new System.Drawing.Size(400, 29);
            this.CounterpartyComboBox.TabIndex = 2;

            // PlannedDateLabel
            this.PlannedDateLabel.AutoSize = true;
            this.PlannedDateLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.PlannedDateLabel.Location = new System.Drawing.Point(12, 100);
            this.PlannedDateLabel.Name = "PlannedDateLabel";
            this.PlannedDateLabel.Size = new System.Drawing.Size(172, 21);
            this.PlannedDateLabel.TabIndex = 3;
            this.PlannedDateLabel.Text = "План. дата отгрузки";

            // PlannedShipmentDatePicker
            this.PlannedShipmentDatePicker.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.PlannedShipmentDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.PlannedShipmentDatePicker.Location = new System.Drawing.Point(190, 97);
            this.PlannedShipmentDatePicker.Name = "PlannedShipmentDatePicker";
            this.PlannedShipmentDatePicker.Size = new System.Drawing.Size(180, 29);
            this.PlannedShipmentDatePicker.TabIndex = 4;

            // NomenclatureLabel
            this.NomenclatureLabel.AutoSize = true;
            this.NomenclatureLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.NomenclatureLabel.Location = new System.Drawing.Point(12, 145);
            this.NomenclatureLabel.Name = "NomenclatureLabel";
            this.NomenclatureLabel.Size = new System.Drawing.Size(122, 21);
            this.NomenclatureLabel.TabIndex = 5;
            this.NomenclatureLabel.Text = "Номенклатура";

            // NomenclatureComboBox
            this.NomenclatureComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NomenclatureComboBox.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.NomenclatureComboBox.Location = new System.Drawing.Point(190, 142);
            this.NomenclatureComboBox.Name = "NomenclatureComboBox";
            this.NomenclatureComboBox.Size = new System.Drawing.Size(400, 29);
            this.NomenclatureComboBox.TabIndex = 6;

            // QuantityLabel
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.QuantityLabel.Location = new System.Drawing.Point(12, 185);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(100, 21);
            this.QuantityLabel.TabIndex = 7;
            this.QuantityLabel.Text = "Количество";

            // QuantityNumeric
            this.QuantityNumeric.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.QuantityNumeric.Location = new System.Drawing.Point(190, 182);
            this.QuantityNumeric.Name = "QuantityNumeric";
            this.QuantityNumeric.Size = new System.Drawing.Size(120, 29);
            this.QuantityNumeric.TabIndex = 8;

            // AddItemButton
            this.AddItemButton.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.AddItemButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddItemButton.FlatAppearance.BorderSize = 0;
            this.AddItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddItemButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.AddItemButton.ForeColor = System.Drawing.Color.White;
            this.AddItemButton.Location = new System.Drawing.Point(330, 182);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(180, 29);
            this.AddItemButton.TabIndex = 9;
            this.AddItemButton.Text = "Добавить позицию";
            this.AddItemButton.UseVisualStyleBackColor = false;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);

            // ItemsGrid
            this.ItemsGrid.BackgroundColor = System.Drawing.Color.White;
            this.ItemsGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ItemsGrid.ColumnHeadersHeight = 32;
            this.ItemsGrid.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ItemsGrid.Location = new System.Drawing.Point(12, 225);
            this.ItemsGrid.Name = "ItemsGrid";
            this.ItemsGrid.Size = new System.Drawing.Size(778, 250);
            this.ItemsGrid.TabIndex = 10;

            // TotalSumLabel
            this.TotalSumLabel.AutoSize = true;
            this.TotalSumLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.TotalSumLabel.ForeColor = System.Drawing.Color.FromArgb(0, 100, 0);
            this.TotalSumLabel.Location = new System.Drawing.Point(12, 485);
            this.TotalSumLabel.Name = "TotalSumLabel";
            this.TotalSumLabel.Size = new System.Drawing.Size(235, 22);
            this.TotalSumLabel.TabIndex = 11;
            this.TotalSumLabel.Text = "Итоговая сумма: 0,00 руб.";

            // SaveButton
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(0, 150, 90);
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(450, 480);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(160, 32);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Сохранить заказ";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);

            // CancelButton
            this.CancelButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.CancelButton.Location = new System.Drawing.Point(630, 480);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(160, 32);
            this.CancelButton.TabIndex = 13;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);

            // OrderEditForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(810, 525);
            this.Controls.Add(this.HeadLabel);
            this.Controls.Add(this.CounterpartyLabel);
            this.Controls.Add(this.CounterpartyComboBox);
            this.Controls.Add(this.PlannedDateLabel);
            this.Controls.Add(this.PlannedShipmentDatePicker);
            this.Controls.Add(this.NomenclatureLabel);
            this.Controls.Add(this.NomenclatureComboBox);
            this.Controls.Add(this.QuantityLabel);
            this.Controls.Add(this.QuantityNumeric);
            this.Controls.Add(this.AddItemButton);
            this.Controls.Add(this.ItemsGrid);
            this.Controls.Add(this.TotalSumLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новый заказ";
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}