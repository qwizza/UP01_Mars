namespace YPMars
{
    partial class OrderEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label HeadLabel;

        // --- Поиск контрагента ---
        private System.Windows.Forms.Label CounterpartyLabel;
        private System.Windows.Forms.TextBox CounterpartyTextBox;
        private System.Windows.Forms.ListBox CounterpartyListBox;

        private System.Windows.Forms.Label PlannedDateLabel;
        private System.Windows.Forms.DateTimePicker PlannedShipmentDatePicker;

        // --- Поиск номенклатуры ---
        private System.Windows.Forms.Label NomenclatureLabel;
        private System.Windows.Forms.TextBox NomenclatureTextBox;
        private System.Windows.Forms.ListBox NomenclatureListBox;

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
            this.CounterpartyTextBox = new System.Windows.Forms.TextBox();
            this.CounterpartyListBox = new System.Windows.Forms.ListBox();

            this.PlannedDateLabel = new System.Windows.Forms.Label();
            this.PlannedShipmentDatePicker = new System.Windows.Forms.DateTimePicker();

            this.NomenclatureLabel = new System.Windows.Forms.Label();
            this.NomenclatureTextBox = new System.Windows.Forms.TextBox();
            this.NomenclatureListBox = new System.Windows.Forms.ListBox();

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

            // 
            // HeadLabel
            // 
            this.HeadLabel.AutoSize = true;
            this.HeadLabel.Font = new System.Drawing.Font("Times New Roman", 20.25F);
            this.HeadLabel.Location = new System.Drawing.Point(220, 9);
            this.HeadLabel.Name = "HeadLabel";
            this.HeadLabel.Size = new System.Drawing.Size(157, 31);
            this.HeadLabel.TabIndex = 0;
            this.HeadLabel.Text = "Новый заказ";

            // --- Контрагент ---
            // 
            // CounterpartyLabel
            // 
            this.CounterpartyLabel.AutoSize = true;
            this.CounterpartyLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.CounterpartyLabel.Location = new System.Drawing.Point(12, 60);
            this.CounterpartyLabel.Name = "CounterpartyLabel";
            this.CounterpartyLabel.Size = new System.Drawing.Size(102, 21);
            this.CounterpartyLabel.TabIndex = 1;
            this.CounterpartyLabel.Text = "Контрагент:";

            // 
            // CounterpartyTextBox
            // 
            this.CounterpartyTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.CounterpartyTextBox.Location = new System.Drawing.Point(190, 57);
            this.CounterpartyTextBox.Name = "CounterpartyTextBox";
            this.CounterpartyTextBox.Size = new System.Drawing.Size(400, 29);
            this.CounterpartyTextBox.TabIndex = 2;
            this.CounterpartyTextBox.TextChanged += new System.EventHandler(this.CounterpartyTextBox_TextChanged);
            this.CounterpartyTextBox.Enter += new System.EventHandler(this.CounterpartyTextBox_Enter);

            // 
            // CounterpartyListBox
            // 
            this.CounterpartyListBox.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.CounterpartyListBox.FormattingEnabled = true;
            this.CounterpartyListBox.ItemHeight = 19;
            this.CounterpartyListBox.Location = new System.Drawing.Point(190, 86);
            this.CounterpartyListBox.Name = "CounterpartyListBox";
            this.CounterpartyListBox.Size = new System.Drawing.Size(400, 80);
            this.CounterpartyListBox.TabIndex = 3;
            this.CounterpartyListBox.Visible = false; // Изначально скрыт
            this.CounterpartyListBox.DoubleClick += new System.EventHandler(this.CounterpartyListBox_DoubleClick);

            // --- Дата отгрузки ---
            // 
            // PlannedDateLabel
            // 
            this.PlannedDateLabel.AutoSize = true;
            this.PlannedDateLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.PlannedDateLabel.Location = new System.Drawing.Point(12, 180);
            this.PlannedDateLabel.Name = "PlannedDateLabel";
            this.PlannedDateLabel.Size = new System.Drawing.Size(171, 21);
            this.PlannedDateLabel.TabIndex = 4;
            this.PlannedDateLabel.Text = "План. дата отгрузки";

            // 
            // PlannedShipmentDatePicker
            // 
            this.PlannedShipmentDatePicker.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.PlannedShipmentDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.PlannedShipmentDatePicker.Location = new System.Drawing.Point(190, 177);
            this.PlannedShipmentDatePicker.Name = "PlannedShipmentDatePicker";
            this.PlannedShipmentDatePicker.Size = new System.Drawing.Size(180, 29);
            this.PlannedShipmentDatePicker.TabIndex = 5;

            // --- Номенклатура ---
            // 
            // NomenclatureLabel
            // 
            this.NomenclatureLabel.AutoSize = true;
            this.NomenclatureLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.NomenclatureLabel.Location = new System.Drawing.Point(12, 225);
            this.NomenclatureLabel.Name = "NomenclatureLabel";
            this.NomenclatureLabel.Size = new System.Drawing.Size(124, 21);
            this.NomenclatureLabel.TabIndex = 6;
            this.NomenclatureLabel.Text = "Номенклатура:";

            // 
            // NomenclatureTextBox
            // 
            this.NomenclatureTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.NomenclatureTextBox.Location = new System.Drawing.Point(190, 222);
            this.NomenclatureTextBox.Name = "NomenclatureTextBox";
            this.NomenclatureTextBox.Size = new System.Drawing.Size(400, 29);
            this.NomenclatureTextBox.TabIndex = 7;
            this.NomenclatureTextBox.TextChanged += new System.EventHandler(this.NomenclatureTextBox_TextChanged);
            this.NomenclatureTextBox.Enter += new System.EventHandler(this.NomenclatureTextBox_Enter);

            // 
            // NomenclatureListBox
            // 
            this.NomenclatureListBox.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.NomenclatureListBox.FormattingEnabled = true;
            this.NomenclatureListBox.ItemHeight = 19;
            this.NomenclatureListBox.Location = new System.Drawing.Point(190, 251);
            this.NomenclatureListBox.Name = "NomenclatureListBox";
            this.NomenclatureListBox.Size = new System.Drawing.Size(400, 80);
            this.NomenclatureListBox.TabIndex = 8;
            this.NomenclatureListBox.Visible = false; // Изначально скрыт
            this.NomenclatureListBox.DoubleClick += new System.EventHandler(this.NomenclatureListBox_DoubleClick);

            // --- Количество ---
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.QuantityLabel.Location = new System.Drawing.Point(12, 345);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(105, 21);
            this.QuantityLabel.TabIndex = 9;
            this.QuantityLabel.Text = "Количество";

            // 
            // QuantityNumeric
            // 
            this.QuantityNumeric.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.QuantityNumeric.Location = new System.Drawing.Point(190, 342);
            this.QuantityNumeric.Name = "QuantityNumeric";
            this.QuantityNumeric.Size = new System.Drawing.Size(120, 29);
            this.QuantityNumeric.TabIndex = 10;

            // 
            // AddItemButton
            // 
            this.AddItemButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.AddItemButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddItemButton.FlatAppearance.BorderSize = 0;
            this.AddItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddItemButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.AddItemButton.ForeColor = System.Drawing.Color.White;
            this.AddItemButton.Location = new System.Drawing.Point(330, 342);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(180, 29);
            this.AddItemButton.TabIndex = 11;
            this.AddItemButton.Text = "Добавить позицию";
            this.AddItemButton.UseVisualStyleBackColor = false;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);

            // 
            // ItemsGrid
            // 
            this.ItemsGrid.BackgroundColor = System.Drawing.Color.White;
            this.ItemsGrid.ColumnHeadersHeight = 32;
            this.ItemsGrid.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ItemsGrid.Location = new System.Drawing.Point(12, 385);
            this.ItemsGrid.Name = "ItemsGrid";
            this.ItemsGrid.Size = new System.Drawing.Size(778, 150);
            this.ItemsGrid.TabIndex = 12;

            // 
            // TotalSumLabel
            // 
            this.TotalSumLabel.AutoSize = true;
            this.TotalSumLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.TotalSumLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.TotalSumLabel.Location = new System.Drawing.Point(12, 545);
            this.TotalSumLabel.Name = "TotalSumLabel";
            this.TotalSumLabel.Size = new System.Drawing.Size(235, 22);
            this.TotalSumLabel.TabIndex = 13;
            this.TotalSumLabel.Text = "Итоговая сумма: 0,00 руб.";

            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(450, 540);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(160, 32);
            this.SaveButton.TabIndex = 14;
            this.SaveButton.Text = "Сохранить заказ";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);

            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.CancelButton.Location = new System.Drawing.Point(630, 540);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(160, 32);
            this.CancelButton.TabIndex = 15;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);

            // 
            // OrderEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(810, 585); // Увеличили высоту формы для новых элементов
            this.Controls.Add(this.HeadLabel);
            this.Controls.Add(this.CounterpartyLabel);
            this.Controls.Add(this.CounterpartyTextBox);
            this.Controls.Add(this.CounterpartyListBox);
            this.Controls.Add(this.PlannedDateLabel);
            this.Controls.Add(this.PlannedShipmentDatePicker);
            this.Controls.Add(this.NomenclatureLabel);
            this.Controls.Add(this.NomenclatureTextBox);
            this.Controls.Add(this.NomenclatureListBox);
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