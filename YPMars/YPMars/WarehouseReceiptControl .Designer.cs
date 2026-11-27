namespace YPMars
{
    partial class WarehouseReceiptControl
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView ReceiptDataGridView;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SaveAllButton;
        private System.Windows.Forms.Button ClearListButton;
        private System.Windows.Forms.Button ReportButton; // ДОБАВЛЕНО

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.ReceiptDataGridView = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveAllButton = new System.Windows.Forms.Button();
            this.ClearListButton = new System.Windows.Forms.Button();
            this.ReportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ReceiptDataGridView
            // 
            this.ReceiptDataGridView.AllowUserToAddRows = false;
            this.ReceiptDataGridView.AllowUserToDeleteRows = false;
            this.ReceiptDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ReceiptDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.ReceiptDataGridView.Location = new System.Drawing.Point(30, 30);
            this.ReceiptDataGridView.MultiSelect = false;
            this.ReceiptDataGridView.Name = "ReceiptDataGridView";
            this.ReceiptDataGridView.ReadOnly = true;
            this.ReceiptDataGridView.RowHeadersVisible = false;
            this.ReceiptDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReceiptDataGridView.Size = new System.Drawing.Size(800, 350);
            this.ReceiptDataGridView.TabIndex = 6;
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.AddButton.ForeColor = System.Drawing.Color.White;
            this.AddButton.Location = new System.Drawing.Point(30, 400);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(194, 35);
            this.AddButton.TabIndex = 5;
            this.AddButton.Text = "Добавить товар";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.EditButton.ForeColor = System.Drawing.Color.White;
            this.EditButton.Location = new System.Drawing.Point(436, 400);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(194, 35);
            this.EditButton.TabIndex = 4;
            this.EditButton.Text = "Редактировать";
            this.EditButton.UseVisualStyleBackColor = false;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.DeleteButton.ForeColor = System.Drawing.Color.White;
            this.DeleteButton.Location = new System.Drawing.Point(230, 400);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(194, 35);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SaveAllButton
            // 
            this.SaveAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.SaveAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveAllButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.SaveAllButton.ForeColor = System.Drawing.Color.White;
            this.SaveAllButton.Location = new System.Drawing.Point(30, 460);
            this.SaveAllButton.Name = "SaveAllButton";
            this.SaveAllButton.Size = new System.Drawing.Size(394, 40);
            this.SaveAllButton.TabIndex = 1;
            this.SaveAllButton.Text = "Оприходовать всё";
            this.SaveAllButton.UseVisualStyleBackColor = false;
            this.SaveAllButton.Click += new System.EventHandler(this.SaveAllButton_Click);
            // 
            // ClearListButton
            // 
            this.ClearListButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClearListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearListButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.ClearListButton.ForeColor = System.Drawing.Color.White;
            this.ClearListButton.Location = new System.Drawing.Point(636, 400);
            this.ClearListButton.Name = "ClearListButton";
            this.ClearListButton.Size = new System.Drawing.Size(194, 35);
            this.ClearListButton.TabIndex = 2;
            this.ClearListButton.Text = "Очистить";
            this.ClearListButton.UseVisualStyleBackColor = false;
            this.ClearListButton.Click += new System.EventHandler(this.ClearListButton_Click);
            // 
            // ReportButton
            // 
            this.ReportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.ReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportButton.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.ReportButton.ForeColor = System.Drawing.Color.White;
            this.ReportButton.Location = new System.Drawing.Point(436, 460);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(394, 40);
            this.ReportButton.TabIndex = 0;
            this.ReportButton.Text = "Отчет о приемки товара";
            this.ReportButton.UseVisualStyleBackColor = false;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // WarehouseReceiptControl
            // 
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(this.ReportButton);
            this.Controls.Add(this.SaveAllButton);
            this.Controls.Add(this.ClearListButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ReceiptDataGridView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "WarehouseReceiptControl";
            this.Size = new System.Drawing.Size(880, 520);
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptDataGridView)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
