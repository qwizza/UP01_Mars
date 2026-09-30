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
            this.SuspendLayout();
            // 
            // RegistrButton
            // 
            this.RegistrButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.RegistrButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegistrButton.Font = new System.Drawing.Font("Comic Sans MS", 66.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrButton.Location = new System.Drawing.Point(0, 0);
            this.RegistrButton.Name = "RegistrButton";
            this.RegistrButton.Size = new System.Drawing.Size(987, 554);
            this.RegistrButton.TabIndex = 0;
            this.RegistrButton.Text = "ЗАРЕГИСТРИРОВАТЬСЯ";
            this.RegistrButton.UseVisualStyleBackColor = false;
            this.RegistrButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 554);
            this.Controls.Add(this.RegistrButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Mars";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RegistrButton;
    }
}

