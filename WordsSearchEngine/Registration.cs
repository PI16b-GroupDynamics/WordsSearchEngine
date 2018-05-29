using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WordsSearchEngine
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

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
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
