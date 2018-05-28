namespace WordsSearchEngine
{
    partial class Registration
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
            this.Password = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.TPassword = new System.Windows.Forms.Label();
            this.TLogin = new System.Windows.Forms.Label();
            this.TName = new System.Windows.Forms.Label();
            this.Confirmation = new System.Windows.Forms.TextBox();
            this.TConfirmation = new System.Windows.Forms.Label();
            this.Accept = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(133, 84);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(236, 20);
            this.Password.TabIndex = 11;
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(133, 52);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(236, 20);
            this.Login.TabIndex = 10;
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(133, 22);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(236, 20);
            this.UserName.TabIndex = 9;
            // 
            // TPassword
            // 
            this.TPassword.AutoSize = true;
            this.TPassword.Location = new System.Drawing.Point(27, 89);
            this.TPassword.Name = "TPassword";
            this.TPassword.Size = new System.Drawing.Size(48, 13);
            this.TPassword.TabIndex = 8;
            this.TPassword.Text = "Пароль:";
            // 
            // TLogin
            // 
            this.TLogin.AutoSize = true;
            this.TLogin.Location = new System.Drawing.Point(27, 58);
            this.TLogin.Name = "TLogin";
            this.TLogin.Size = new System.Drawing.Size(41, 13);
            this.TLogin.TabIndex = 7;
            this.TLogin.Text = "Логин:";
            // 
            // TName
            // 
            this.TName.AutoSize = true;
            this.TName.Location = new System.Drawing.Point(27, 29);
            this.TName.Name = "TName";
            this.TName.Size = new System.Drawing.Size(32, 13);
            this.TName.TabIndex = 6;
            this.TName.Text = "Имя:";
            // 
            // Confirmation
            // 
            this.Confirmation.Location = new System.Drawing.Point(133, 114);
            this.Confirmation.Name = "Confirmation";
            this.Confirmation.Size = new System.Drawing.Size(236, 20);
            this.Confirmation.TabIndex = 13;
            // 
            // TConfirmation
            // 
            this.TConfirmation.AutoSize = true;
            this.TConfirmation.Location = new System.Drawing.Point(27, 117);
            this.TConfirmation.Name = "TConfirmation";
            this.TConfirmation.Size = new System.Drawing.Size(103, 13);
            this.TConfirmation.TabIndex = 12;
            this.TConfirmation.Text = "Повторить пароль:";
            // 
            // Accept
            // 
            this.Accept.Location = new System.Drawing.Point(165, 153);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(132, 23);
            this.Accept.TabIndex = 14;
            this.Accept.Text = "Зарегистрироваться";
            this.Accept.UseVisualStyleBackColor = true;
            this.Accept.Click += new System.EventHandler(this.Accept_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(303, 153);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(66, 23);
            this.Cancel.TabIndex = 15;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 192);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Accept);
            this.Controls.Add(this.Confirmation);
            this.Controls.Add(this.TConfirmation);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.TPassword);
            this.Controls.Add(this.TLogin);
            this.Controls.Add(this.TName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Label TPassword;
        private System.Windows.Forms.Label TLogin;
        private System.Windows.Forms.Label TName;
        private System.Windows.Forms.TextBox Confirmation;
        private System.Windows.Forms.Label TConfirmation;
        private System.Windows.Forms.Button Accept;
        private System.Windows.Forms.Button Cancel;
    }
}