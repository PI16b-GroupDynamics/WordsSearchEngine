using System;
<<<<<<< HEAD
=======
using System.Data.SQLite;
>>>>>>> 56453015507048d3d1cee879304888963969a9cf
using System.Windows.Forms;

namespace WordsSearchEngine
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
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
=======
        private void Accept_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.UserDb.Open();
                using (var command = MainForm.UserDb.CreateCommand())
                {
                    // Проверка на ввод всех значений в форму.
                    if (UserName.Text == string.Empty || Login.Text == string.Empty ||
                        Password.Text == string.Empty || Confirmation.Text == string.Empty)
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
                    command.CommandText = "select Login from users where Login = @login";
                    command.Parameters.AddWithValue("Login", Login.Text.ToLower());
                    var login = (string) command.ExecuteScalar();
                    if (!string.IsNullOrEmpty(login))
                    {
                        MessageBox.Show(@"Пользователь с данным логином уже зарегистрирован! Введите другое значние.",
                            @"Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    command.CommandText =
                        "insert into [Users] (Login, Name, Password) values (@login, @name, @password)";
                    // Определяем параметры команды.
                    command.Parameters.AddWithValue("Login", Login.Text.ToLower());
                    command.Parameters.AddWithValue("Name", UserName.Text);
                    command.Parameters.AddWithValue("Password", Password.Text);

                    command.ExecuteNonQuery(); // Выполняем вставку записей.

                    MessageBox.Show(@"Аккаун успешно создан!", @"Регистрация");
                    Visible = false;
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка регистрации",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            finally
            {
                MainForm.UserDb.Close();
            }
>>>>>>> 56453015507048d3d1cee879304888963969a9cf
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            ClearTextBoxes();
=======
>>>>>>> 56453015507048d3d1cee879304888963969a9cf
            Visible = false;
        }
    }
}
