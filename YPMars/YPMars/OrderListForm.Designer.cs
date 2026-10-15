namespace YPMars
{
    partial class OrderListForm
    {
        private System.ComponentModel.IContainer components = null;

        // Верхняя панель фильтрации
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.DateTimePicker StartDateDatetimePick;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.DateTimePicker EndDateDatetimePick;
        private System.Windows.Forms.Button RefreshButton;

        // Информационная панель (итоги)
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label TotalCountLabel;
        private System.Windows.Forms.Label TotalSumLabel;

        // Таблица заказов
        private System.Windows.Forms.DataGridView OrdersDataGridView;

        // Нижняя панель смены статуса
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.ComboBox StatusCoboBox;
        private System.Windows.Forms.Button ChangeStatusButton;
        private System.Windows.Forms.Button NewOrderButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderListForm));
            this.panelTop = new System.Windows.Forms.Panel();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.StartDateDatetimePick = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.EndDateDatetimePick = new System.Windows.Forms.DateTimePicker();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.NewOrderButton = new System.Windows.Forms.Button();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.TotalCountLabel = new System.Windows.Forms.Label();
            this.TotalSumLabel = new System.Windows.Forms.Label();
            this.OrdersDataGridView = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusCoboBox = new System.Windows.Forms.ComboBox();
            this.ChangeStatusButton = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataGridView)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.StartDateLabel);
            this.panelTop.Controls.Add(this.StartDateDatetimePick);
            this.panelTop.Controls.Add(this.EndDateLabel);
            this.panelTop.Controls.Add(this.EndDateDatetimePick);
            this.panelTop.Controls.Add(this.RefreshButton);
            this.panelTop.Controls.Add(this.NewOrderButton);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.panelTop.Size = new System.Drawing.Size(1100, 55);
            this.panelTop.TabIndex = 3;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartDateLabel.Location = new System.Drawing.Point(12, 18);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(108, 21);
            this.StartDateLabel.TabIndex = 0;
            this.StartDateLabel.Text = "Дата начала:";
            // 
            // StartDateDatetimePick
            // 
            this.StartDateDatetimePick.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartDateDatetimePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDateDatetimePick.Location = new System.Drawing.Point(126, 13);
            this.StartDateDatetimePick.Name = "StartDateDatetimePick";
            this.StartDateDatetimePick.Size = new System.Drawing.Size(150, 29);
            this.StartDateDatetimePick.TabIndex = 1;
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EndDateLabel.Location = new System.Drawing.Point(284, 17);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(141, 21);
            this.EndDateLabel.TabIndex = 2;
            this.EndDateLabel.Text = "Дата окончания:";
            // 
            // EndDateDatetimePick
            // 
            this.EndDateDatetimePick.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EndDateDatetimePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDateDatetimePick.Location = new System.Drawing.Point(431, 13);
            this.EndDateDatetimePick.Name = "EndDateDatetimePick";
            this.EndDateDatetimePick.Size = new System.Drawing.Size(150, 29);
            this.EndDateDatetimePick.TabIndex = 3;
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.RefreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshButton.FlatAppearance.BorderSize = 0;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RefreshButton.ForeColor = System.Drawing.Color.White;
            this.RefreshButton.Location = new System.Drawing.Point(597, 13);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(119, 28);
            this.RefreshButton.TabIndex = 4;
            this.RefreshButton.Text = "Обновить";
            this.RefreshButton.UseVisualStyleBackColor = false;
            // 
            // NewOrderButton
            // 
            this.NewOrderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.NewOrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewOrderButton.FlatAppearance.BorderSize = 0;
            this.NewOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewOrderButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.NewOrderButton.ForeColor = System.Drawing.Color.White;
            this.NewOrderButton.Location = new System.Drawing.Point(740, 13);
            this.NewOrderButton.Name = "NewOrderButton";
            this.NewOrderButton.Size = new System.Drawing.Size(160, 28);
            this.NewOrderButton.TabIndex = 5;
            this.NewOrderButton.Text = "Новый заказ";
            this.NewOrderButton.UseVisualStyleBackColor = false;
            this.NewOrderButton.Click += new System.EventHandler(this.NewOrderButton_Click);
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSummary.Controls.Add(this.TotalCountLabel);
            this.panelSummary.Controls.Add(this.TotalSumLabel);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummary.Location = new System.Drawing.Point(0, 55);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panelSummary.Size = new System.Drawing.Size(1100, 35);
            this.panelSummary.TabIndex = 2;
            // 
            // TotalCountLabel
            // 
            this.TotalCountLabel.AutoSize = true;
            this.TotalCountLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TotalCountLabel.Location = new System.Drawing.Point(12, 8);
            this.TotalCountLabel.Name = "TotalCountLabel";
            this.TotalCountLabel.Size = new System.Drawing.Size(157, 22);
            this.TotalCountLabel.TabIndex = 0;
            this.TotalCountLabel.Text = "Всего заказов: 0.";
            // 
            // TotalSumLabel
            // 
            this.TotalSumLabel.AutoSize = true;
            this.TotalSumLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TotalSumLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.TotalSumLabel.Location = new System.Drawing.Point(250, 8);
            this.TotalSumLabel.Name = "TotalSumLabel";
            this.TotalSumLabel.Size = new System.Drawing.Size(235, 22);
            this.TotalSumLabel.TabIndex = 1;
            this.TotalSumLabel.Text = "Итоговая сумма: 0,00 руб.";
            // 
            // OrdersDataGridView
            // 
            this.OrdersDataGridView.AllowUserToAddRows = false;
            this.OrdersDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.OrdersDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.OrdersDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.OrdersDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OrdersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.OrdersDataGridView.ColumnHeadersHeight = 32;
            this.OrdersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdersDataGridView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OrdersDataGridView.Location = new System.Drawing.Point(0, 90);
            this.OrdersDataGridView.MultiSelect = false;
            this.OrdersDataGridView.Name = "OrdersDataGridView";
            this.OrdersDataGridView.ReadOnly = true;
            this.OrdersDataGridView.RowHeadersVisible = false;
            this.OrdersDataGridView.RowTemplate.Height = 26;
            this.OrdersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrdersDataGridView.Size = new System.Drawing.Size(1100, 505);
            this.OrdersDataGridView.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.StatusLabel);
            this.panelBottom.Controls.Add(this.StatusCoboBox);
            this.panelBottom.Controls.Add(this.ChangeStatusButton);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 595);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.panelBottom.Size = new System.Drawing.Size(1100, 55);
            this.panelBottom.TabIndex = 1;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel.Location = new System.Drawing.Point(12, 18);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(125, 21);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Новый статус:";
            // 
            // StatusCoboBox
            // 
            this.StatusCoboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusCoboBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusCoboBox.Location = new System.Drawing.Point(143, 15);
            this.StatusCoboBox.Name = "StatusCoboBox";
            this.StatusCoboBox.Size = new System.Drawing.Size(200, 29);
            this.StatusCoboBox.TabIndex = 1;
            // 
            // ChangeStatusButton
            // 
            this.ChangeStatusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.ChangeStatusButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangeStatusButton.FlatAppearance.BorderSize = 0;
            this.ChangeStatusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeStatusButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeStatusButton.ForeColor = System.Drawing.Color.White;
            this.ChangeStatusButton.Location = new System.Drawing.Point(359, 16);
            this.ChangeStatusButton.Name = "ChangeStatusButton";
            this.ChangeStatusButton.Size = new System.Drawing.Size(140, 28);
            this.ChangeStatusButton.TabIndex = 2;
            this.ChangeStatusButton.Text = "Изменить статус";
            this.ChangeStatusButton.UseVisualStyleBackColor = false;
            // 
            // OrderListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.OrdersDataGridView);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelSummary);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "OrderListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Список заказов";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataGridView)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}