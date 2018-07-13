using System;
using System.Drawing;
using System.Windows.Forms;

namespace WordsSearchEngine
{
    public partial class AccountSettings : Form
    {
        public AccountSettings()
        {
            InitializeComponent();
            SetUserData();
            OldPassword.Select();
        }

        // Устанавливаем данные пользователя.
        private void SetUserData()
        {
            if (Users.CurrentUser == null) return;

            UserName.Text = Users.CurrentUser.Name;
            SetTextBoxStyle(UserName, SystemColors.Control, BorderStyle.None);
            Login.Text = Users.CurrentUser.Login;
            SetTextBoxStyle(Login, SystemColors.Control, BorderStyle.None);
        }

        private void SetTextBoxStyle(TextBoxBase sender, Color color, BorderStyle style)
        {
            sender.BackColor = color;
            sender.BorderStyle = style;
        }

        private void DeleteAccount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    @"Вы действительно хотите удалить свой аккаунт?" + Environment.NewLine +
                    @"Вся работа при этом будет потеряна.", @"Words Search Engine",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes) return;

            Log.WriteEvent(DateTime.Now, "Удаление учётной записи", $"Пользователь {Users.CurrentUser.Login} удалил свою учётную запись.");
            Users.CurrentUser.DeleteAccount();
            Users.CurrentUser = null;
            Close();
        }

        private void UserName_Click(object sender, EventArgs e)
        { SetTextBoxStyle(UserName, SystemColors.Window, BorderStyle.Fixed3D); }

        private void Login_Click(object sender, EventArgs e) 
        { SetTextBoxStyle(Login, SystemColors.Window, BorderStyle.Fixed3D); }

        private void UserName_Leave(object sender, EventArgs e)
        { if(UserName.Text == Users.CurrentUser.Name) SetTextBoxStyle(UserName, SystemColors.Control, BorderStyle.None); }

        private void Login_Leave(object sender, EventArgs e)
        { if (Login.Text == Users.CurrentUser.Login) SetTextBoxStyle(Login, SystemColors.Control, BorderStyle.None); }

        private void SaveName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UserName.Text.Trim()))
            {
                var oldName = Users.CurrentUser.Name;
                if(!Users.CurrentUser.SetName(UserName.Text)) return;

                Log.WriteEvent(DateTime.Now, "Изменение учётной записи",
                    $"Пользователь {Users.CurrentUser.Login} изменил своё имя {oldName} на {Users.CurrentUser.Name}.");
                SetTextBoxStyle(UserName, SystemColors.Control, BorderStyle.None);
                MessageBox.Show(@"Имя пользователя успешно сохранено!", @"Параметры учётной записи", MessageBoxButtons.OK,
                    MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show(@"Введите имя пользователя!", @"Ошибка изменения имени пользователя",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UserName.Text = Users.CurrentUser.Name;
            }
        }
        
        private void SaveLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Login.Text.Trim()))
            {
                if (!Users.IsLoginUnique(Login.Text.ToLower()))
                    MessageBox.Show(@"Пользователь с данным логином уже зарегистрирован! Введите другое значение.",
                        @"Ошибка изменения логина", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    SetTextBoxStyle(Login, SystemColors.Control, BorderStyle.None);
                    var oldLogin = Users.CurrentUser.Login;
                    if (Users.CurrentUser.SetLogin(Login.Text))
                    {
                        MessageBox.Show(@"Логин успешно сохранён!", @"Параметры учётной записи", MessageBoxButtons.OK,
                            MessageBoxIcon.None);
                        Log.WriteEvent(DateTime.Now, "Изменение учётной записи",
                            $"Пользователь {Users.CurrentUser.Login} изменил свой логин с {oldLogin} на {Users.CurrentUser.Login}");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Введите логин!", @"Ошибка изменения логина", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            Login.Text = Users.CurrentUser.Login;
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {            
            // Проверка на ввод всех необходимых значений.
            if (OldPassword.Text.Trim() == string.Empty || NewPassword.Text.Trim() == string.Empty
                || ConfirmPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"Заполните все поля!",
                    @"Ошибка изменения пароля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Проверка на совпадение паролей.
            if (NewPassword.Text != ConfirmPassword.Text)
            {
                MessageBox.Show(@"Пароли не совпадают!",
                    @"Ошибка изменения пароля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!Users.CurrentUser.SetNewPassword(OldPassword.Text, NewPassword.Text))
            {
                MessageBox.Show(@"Неверно указан текущий пароль!", @"Ошибка изменения пароля", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            Log.WriteEvent(DateTime.Now, "Изменение учётной записи",
                $"Пользователь {Users.CurrentUser.Login} изменил свой пароль.");
            OldPassword.Text = "";
            NewPassword.Text = "";
            ConfirmPassword.Text = "";
        }
    }
}
