namespace YPMars
{
    partial class AuthForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.HeadName = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Imput = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.ToggleButten = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbLogin
            // 
            this.tbLogin.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLogin.Location = new System.Drawing.Point(98, 88);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(202, 29);
            this.tbLogin.TabIndex = 0;
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPassword.Location = new System.Drawing.Point(98, 136);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(202, 29);
            this.tbPassword.TabIndex = 1;
            // 
            // HeadName
            // 
            this.HeadName.AutoSize = true;
            this.HeadName.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeadName.Location = new System.Drawing.Point(84, 22);
            this.HeadName.Name = "HeadName";
            this.HeadName.Size = new System.Drawing.Size(161, 31);
            this.HeadName.TabIndex = 2;
            this.HeadName.Text = "Авторизация";
            // 
            // login
            // 
            this.login.AutoSize = true;
            this.login.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login.Location = new System.Drawing.Point(23, 88);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(61, 21);
            this.login.TabIndex = 3;
            this.login.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(23, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Пароль";
            // 
            // Imput
            // 
            this.Imput.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Imput.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Imput.Location = new System.Drawing.Point(27, 186);
            this.Imput.Name = "Imput";
            this.Imput.Size = new System.Drawing.Size(118, 29);
            this.Imput.TabIndex = 5;
            this.Imput.Text = "Войти";
            this.Imput.UseVisualStyleBackColor = false;
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Cancel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancel.Location = new System.Drawing.Point(182, 186);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(118, 29);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = false;
            // 
            // ToggleButten
            // 
            this.ToggleButten.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ToggleButten.FlatAppearance.BorderSize = 0;
            this.ToggleButten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToggleButten.Image = ((System.Drawing.Image)(resources.GetObject("ToggleButten.Image")));
            this.ToggleButten.Location = new System.Drawing.Point(273, 140);
            this.ToggleButten.Name = "ToggleButten";
            this.ToggleButten.Size = new System.Drawing.Size(24, 22);
            this.ToggleButten.TabIndex = 7;
            this.ToggleButten.UseVisualStyleBackColor = false;
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(329, 237);
            this.Controls.Add(this.ToggleButten);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Imput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.login);
            this.Controls.Add(this.HeadName);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuthForm";
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label HeadName;
        private System.Windows.Forms.Label login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Imput;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button ToggleButten;
    }
}