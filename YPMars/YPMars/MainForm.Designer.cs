namespace YPMars
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button RegistrButton;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.DateTimePicker StartDateDatetimePick;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.DateTimePicker EndDateDatetimePick;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button NewOrderButton;
        private System.Windows.Forms.Button OrderDetailsButton; // Новая кнопка состава заказа

        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label TotalCountLabel;
        private System.Windows.Forms.Label TotalSumLabel;

        private System.Windows.Forms.DataGridView OrdersDataGridView;

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.ComboBox StatusCoboBox;
        private System.Windows.Forms.Button ChangeStatusButton;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.RegistrButton = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.StartDateDatetimePick = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.EndDateDatetimePick = new System.Windows.Forms.DateTimePicker();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.NewOrderButton = new System.Windows.Forms.Button();
            this.OrderDetailsButton = new System.Windows.Forms.Button();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.TotalCountLabel = new System.Windows.Forms.Label();
            this.TotalSumLabel = new System.Windows.Forms.Label();
            this.OrdersDataGridView = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusCoboBox = new System.Windows.Forms.ComboBox();
            this.ChangeStatusButton = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataGridView)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHeader.Controls.Add(this.RegistrButton);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1100, 40);
            this.panelHeader.TabIndex = 4;
            // 
            // RegistrButton
            // 
            this.RegistrButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RegistrButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.RegistrButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegistrButton.FlatAppearance.BorderSize = 0;
            this.RegistrButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegistrButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrButton.ForeColor = System.Drawing.Color.White;
            this.RegistrButton.Location = new System.Drawing.Point(920, 5);
            this.RegistrButton.Name = "RegistrButton";
            this.RegistrButton.Size = new System.Drawing.Size(165, 28);
            this.RegistrButton.TabIndex = 0;
            this.RegistrButton.Text = "Регистрация ";
            this.RegistrButton.UseVisualStyleBackColor = false;
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
            this.panelTop.Controls.Add(this.OrderDetailsButton);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 40);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1100, 50);
            this.panelTop.TabIndex = 3;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.StartDateLabel.Location = new System.Drawing.Point(12, 13);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(105, 20);
            this.StartDateLabel.TabIndex = 0;
            this.StartDateLabel.Text = "Дата начала:";
            // 
            // StartDateDatetimePick
            // 
            this.StartDateDatetimePick.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.StartDateDatetimePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDateDatetimePick.Location = new System.Drawing.Point(120, 10);
            this.StartDateDatetimePick.Name = "StartDateDatetimePick";
            this.StartDateDatetimePick.Size = new System.Drawing.Size(130, 28);
            this.StartDateDatetimePick.TabIndex = 1;
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.EndDateLabel.Location = new System.Drawing.Point(265, 13);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(135, 20);
            this.EndDateLabel.TabIndex = 2;
            this.EndDateLabel.Text = "Дата окончания:";
            // 
            // EndDateDatetimePick
            // 
            this.EndDateDatetimePick.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.EndDateDatetimePick.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDateDatetimePick.Location = new System.Drawing.Point(400, 10);
            this.EndDateDatetimePick.Name = "EndDateDatetimePick";
            this.EndDateDatetimePick.Size = new System.Drawing.Size(130, 28);
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
            this.RefreshButton.Location = new System.Drawing.Point(550, 10);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(110, 28);
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
            this.NewOrderButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewOrderButton.ForeColor = System.Drawing.Color.White;
            this.NewOrderButton.Location = new System.Drawing.Point(675, 10);
            this.NewOrderButton.Name = "NewOrderButton";
            this.NewOrderButton.Size = new System.Drawing.Size(135, 28);
            this.NewOrderButton.TabIndex = 5;
            this.NewOrderButton.Text = "Новый заказ";
            this.NewOrderButton.UseVisualStyleBackColor = false;
            // 
            // OrderDetailsButton
            // 
            this.OrderDetailsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.OrderDetailsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OrderDetailsButton.FlatAppearance.BorderSize = 0;
            this.OrderDetailsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrderDetailsButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderDetailsButton.ForeColor = System.Drawing.Color.White;
            this.OrderDetailsButton.Location = new System.Drawing.Point(825, 10);
            this.OrderDetailsButton.Name = "OrderDetailsButton";
            this.OrderDetailsButton.Size = new System.Drawing.Size(145, 28);
            this.OrderDetailsButton.TabIndex = 6;
            this.OrderDetailsButton.Text = "Состав заказа";
            this.OrderDetailsButton.UseVisualStyleBackColor = false;
            this.OrderDetailsButton.Click += new System.EventHandler(this.OrderDetailsButton_Click);
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSummary.Controls.Add(this.TotalCountLabel);
            this.panelSummary.Controls.Add(this.TotalSumLabel);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummary.Location = new System.Drawing.Point(0, 90);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(1100, 35);
            this.panelSummary.TabIndex = 2;
            // 
            // TotalCountLabel
            // 
            this.TotalCountLabel.AutoSize = true;
            this.TotalCountLabel.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.TotalCountLabel.ForeColor = System.Drawing.Color.Black;
            this.TotalCountLabel.Location = new System.Drawing.Point(12, 7);
            this.TotalCountLabel.Name = "TotalCountLabel";
            this.TotalCountLabel.Size = new System.Drawing.Size(141, 20);
            this.TotalCountLabel.TabIndex = 0;
            this.TotalCountLabel.Text = "Всего заказов: 0";
            // 
            // TotalSumLabel
            // 
            this.TotalSumLabel.AutoSize = true;
            this.TotalSumLabel.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.TotalSumLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.TotalSumLabel.Location = new System.Drawing.Point(250, 7);
            this.TotalSumLabel.Name = "TotalSumLabel";
            this.TotalSumLabel.Size = new System.Drawing.Size(225, 20);
            this.TotalSumLabel.TabIndex = 1;
            this.TotalSumLabel.Text = "Итоговая сумма: 0,00 руб.";
            // 
            // OrdersDataGridView
            // 
            this.OrdersDataGridView.AllowUserToAddRows = false;
            this.OrdersDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.OrdersDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.OrdersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OrdersDataGridView.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.OrdersDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OrdersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.OrdersDataGridView.ColumnHeadersHeight = 32;
            this.OrdersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdersDataGridView.Location = new System.Drawing.Point(0, 125);
            this.OrdersDataGridView.MultiSelect = false;
            this.OrdersDataGridView.Name = "OrdersDataGridView";
            this.OrdersDataGridView.ReadOnly = true;
            this.OrdersDataGridView.RowHeadersVisible = false;
            this.OrdersDataGridView.RowTemplate.Height = 28;
            this.OrdersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrdersDataGridView.Size = new System.Drawing.Size(1100, 470);
            this.OrdersDataGridView.TabIndex = 0;
            this.OrdersDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrdersDataGridView_CellDoubleClick);
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
            this.panelBottom.Size = new System.Drawing.Size(1100, 55);
            this.panelBottom.TabIndex = 1;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.StatusLabel.Location = new System.Drawing.Point(12, 17);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(120, 20);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Новый статус:";
            // 
            // StatusCoboBox
            // 
            this.StatusCoboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusCoboBox.Font = new System.Drawing.Font("Times New Roman", 13.25F);
            this.StatusCoboBox.FormattingEnabled = true;
            this.StatusCoboBox.Location = new System.Drawing.Point(135, 13);
            this.StatusCoboBox.Name = "StatusCoboBox";
            this.StatusCoboBox.Size = new System.Drawing.Size(190, 28);
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
            this.ChangeStatusButton.Location = new System.Drawing.Point(340, 13);
            this.ChangeStatusButton.Name = "ChangeStatusButton";
            this.ChangeStatusButton.Size = new System.Drawing.Size(150, 28);
            this.ChangeStatusButton.TabIndex = 2;
            this.ChangeStatusButton.Text = "Изменить статус";
            this.ChangeStatusButton.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.OrdersDataGridView);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelSummary);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная форма - Управление заказами (Завод МАРС)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelHeader.ResumeLayout(false);
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