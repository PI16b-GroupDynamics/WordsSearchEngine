namespace WordsSearchEngine
{
    partial class AccountSettings
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
            this.ChangePassword = new System.Windows.Forms.Button();
            this.SaveLogin = new System.Windows.Forms.Button();
            this.SaveName = new System.Windows.Forms.Button();
            this.DeleteAccount = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.TLogin = new System.Windows.Forms.Label();
            this.TName = new System.Windows.Forms.Label();
            this.ConfirmPassword = new System.Windows.Forms.TextBox();
            this.TConfirmPassword = new System.Windows.Forms.Label();
            this.NewPassword = new System.Windows.Forms.TextBox();
            this.TNewPassword = new System.Windows.Forms.Label();
            this.OldPassword = new System.Windows.Forms.TextBox();
            this.TOldPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChangePassword
            // 
            this.ChangePassword.Location = new System.Drawing.Point(258, 213);
            this.ChangePassword.Name = "ChangePassword";
            this.ChangePassword.Size = new System.Drawing.Size(152, 26);
            this.ChangePassword.TabIndex = 8;
            this.ChangePassword.Text = "Изменить пароль";
            this.ChangePassword.UseVisualStyleBackColor = true;
            this.ChangePassword.Click += new System.EventHandler(this.ChangePassword_Click);
            // 
            // SaveLogin
            // 
            this.SaveLogin.Location = new System.Drawing.Point(309, 54);
            this.SaveLogin.Name = "SaveLogin";
            this.SaveLogin.Size = new System.Drawing.Size(101, 26);
            this.SaveLogin.TabIndex = 4;
            this.SaveLogin.Text = "Сохранить";
            this.SaveLogin.UseVisualStyleBackColor = true;
            this.SaveLogin.Click += new System.EventHandler(this.SaveLogin_Click);
            // 
            // SaveName
            // 
            this.SaveName.Location = new System.Drawing.Point(309, 20);
            this.SaveName.Name = "SaveName";
            this.SaveName.Size = new System.Drawing.Size(101, 26);
            this.SaveName.TabIndex = 2;
            this.SaveName.Text = "Сохранить";
            this.SaveName.UseVisualStyleBackColor = true;
            this.SaveName.Click += new System.EventHandler(this.SaveName_Click);
            // 
            // DeleteAccount
            // 
            this.DeleteAccount.Location = new System.Drawing.Point(31, 213);
            this.DeleteAccount.Name = "DeleteAccount";
            this.DeleteAccount.Size = new System.Drawing.Size(152, 26);
            this.DeleteAccount.TabIndex = 9;
            this.DeleteAccount.Text = "Удалить учётную запись";
            this.DeleteAccount.UseVisualStyleBackColor = true;
            this.DeleteAccount.Click += new System.EventHandler(this.DeleteAccount_Click);
            // 
            // Login
            // 
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Login.Location = new System.Drawing.Point(105, 54);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(189, 26);
            this.Login.TabIndex = 3;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            this.Login.Leave += new System.EventHandler(this.Login_Leave);
            // 
            // UserName
            // 
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserName.Location = new System.Drawing.Point(105, 20);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(189, 26);
            this.UserName.TabIndex = 1;
            this.UserName.Click += new System.EventHandler(this.UserName_Click);
            this.UserName.Leave += new System.EventHandler(this.UserName_Leave);
            // 
            // TLogin
            // 
            this.TLogin.AutoSize = true;
            this.TLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TLogin.Location = new System.Drawing.Point(31, 57);
            this.TLogin.Name = "TLogin";
            this.TLogin.Size = new System.Drawing.Size(59, 20);
            this.TLogin.TabIndex = 27;
            this.TLogin.Text = "Логин:";
            // 
            // TName
            // 
            this.TName.AutoSize = true;
            this.TName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TName.Location = new System.Drawing.Point(31, 22);
            this.TName.Name = "TName";
            this.TName.Size = new System.Drawing.Size(44, 20);
            this.TName.TabIndex = 26;
            this.TName.Text = "Имя:";
            // 
            // ConfirmPassword
            // 
            this.ConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConfirmPassword.Location = new System.Drawing.Point(189, 170);
            this.ConfirmPassword.Name = "ConfirmPassword";
            this.ConfirmPassword.PasswordChar = '*';
            this.ConfirmPassword.Size = new System.Drawing.Size(221, 26);
            this.ConfirmPassword.TabIndex = 7;
            // 
            // TConfirmPassword
            // 
            this.TConfirmPassword.AutoSize = true;
            this.TConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TConfirmPassword.Location = new System.Drawing.Point(27, 173);
            this.TConfirmPassword.Name = "TConfirmPassword";
            this.TConfirmPassword.Size = new System.Drawing.Size(156, 20);
            this.TConfirmPassword.TabIndex = 25;
            this.TConfirmPassword.Text = "Повторите пароль:";
            // 
            // NewPassword
            // 
            this.NewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewPassword.Location = new System.Drawing.Point(189, 138);
            this.NewPassword.Name = "NewPassword";
            this.NewPassword.PasswordChar = '*';
            this.NewPassword.Size = new System.Drawing.Size(221, 26);
            this.NewPassword.TabIndex = 6;
            // 
            // TNewPassword
            // 
            this.TNewPassword.AutoSize = true;
            this.TNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TNewPassword.Location = new System.Drawing.Point(27, 141);
            this.TNewPassword.Name = "TNewPassword";
            this.TNewPassword.Size = new System.Drawing.Size(122, 20);
            this.TNewPassword.TabIndex = 24;
            this.TNewPassword.Text = "Новый пароль:";
            // 
            // OldPassword
            // 
            this.OldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OldPassword.Location = new System.Drawing.Point(189, 101);
            this.OldPassword.Name = "OldPassword";
            this.OldPassword.PasswordChar = '*';
            this.OldPassword.Size = new System.Drawing.Size(221, 26);
            this.OldPassword.TabIndex = 5;
            // 
            // TOldPassword
            // 
            this.TOldPassword.AutoSize = true;
            this.TOldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TOldPassword.Location = new System.Drawing.Point(27, 104);
            this.TOldPassword.Name = "TOldPassword";
            this.TOldPassword.Size = new System.Drawing.Size(136, 20);
            this.TOldPassword.TabIndex = 23;
            this.TOldPassword.Text = "Текущий пароль:";
            // 
            // AccountSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 259);
            this.Controls.Add(this.ChangePassword);
            this.Controls.Add(this.SaveLogin);
            this.Controls.Add(this.SaveName);
            this.Controls.Add(this.DeleteAccount);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.TLogin);
            this.Controls.Add(this.TName);
            this.Controls.Add(this.ConfirmPassword);
            this.Controls.Add(this.TConfirmPassword);
            this.Controls.Add(this.NewPassword);
            this.Controls.Add(this.TNewPassword);
            this.Controls.Add(this.OldPassword);
            this.Controls.Add(this.TOldPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AccountSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры учётной записи";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChangePassword;
        private System.Windows.Forms.Button SaveLogin;
        private System.Windows.Forms.Button SaveName;
        private System.Windows.Forms.Button DeleteAccount;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Label TLogin;
        private System.Windows.Forms.Label TName;
        private System.Windows.Forms.TextBox ConfirmPassword;
        private System.Windows.Forms.Label TConfirmPassword;
        private System.Windows.Forms.TextBox NewPassword;
        private System.Windows.Forms.Label TNewPassword;
        private System.Windows.Forms.TextBox OldPassword;
        private System.Windows.Forms.Label TOldPassword;
    }
}