namespace YPMars
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.RegistrButton = new System.Windows.Forms.Button();
            this.OrderListLLab = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // RegistrButton
            // 
            this.RegistrButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.RegistrButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrButton.Location = new System.Drawing.Point(12, 11);
            this.RegistrButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegistrButton.Name = "RegistrButton";
            this.RegistrButton.Size = new System.Drawing.Size(165, 30);
            this.RegistrButton.TabIndex = 1;
            this.RegistrButton.Text = "Зарегистрировать";
            this.RegistrButton.UseVisualStyleBackColor = false;
            this.RegistrButton.Click += new System.EventHandler(this.RegistrButton_Click);
            // 
            // OrderListLLab
            // 
            this.OrderListLLab.AutoSize = true;
            this.OrderListLLab.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderListLLab.Location = new System.Drawing.Point(12, 235);
            this.OrderListLLab.Name = "OrderListLLab";
            this.OrderListLLab.Size = new System.Drawing.Size(136, 21);
            this.OrderListLLab.TabIndex = 2;
            this.OrderListLLab.TabStop = true;
            this.OrderListLLab.Text = "Списки заказов";
            this.OrderListLLab.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OrderListLLab_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 554);
            this.Controls.Add(this.OrderListLLab);
            this.Controls.Add(this.RegistrButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Mars";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegistrButton;
        private System.Windows.Forms.LinkLabel OrderListLLab;
    }
}

