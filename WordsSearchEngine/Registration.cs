using System;
using System.Windows.Forms;

namespace WordsSearchEngine
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void ClearTextBoxes()
        {
            UserName.Text = "";
            Login.Text = "";
            Password.Text = "";
            Confirmation.Text = "";
        }

        private void Accept_Click(object sender, EventArgs e)
        {

            // Проверка на ввод всех значений в форму.
            if (UserName.Text.Trim() == string.Empty || Login.Text.Trim() == string.Empty ||
                Password.Text.Trim() == string.Empty || Confirmation.Text.Trim() == string.Empty)
            {
                MessageBox.Show(@"Заполните все поля!",
                    @"Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Проверка на совпадение паролей.
            if (Password.Text != Confirmation.Text)
            {
                MessageBox.Show(@"Пароли не совпадают!",
                    @"Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Проверка на уникальность логина.
            if (!Users.IsLoginUnique(Login.Text.ToLower()))
            {
                MessageBox.Show(@"Пользователь с данным логином уже зарегистрирован! Введите другое значение.",
                    @"Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Users.Add(UserName.Text, Login.Text.ToLower(), Password.Text);
            MessageBox.Show(@"Аккаун успешно создан!", @"Регистрация");
            Log.WriteEvent(DateTime.Now, "Регистрация", $"Зарегистрирован новый пользователь {Login.Text}.");
            ClearTextBoxes();
            Visible = false;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            Visible = false;
        }
    }
}
