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

       
        private void Accept_Click(object sender, System.EventArgs e)
        {
            try
            {
                MainForm.UserDB.Open();
                using (var command = MainForm.UserDB.CreateCommand())
                {
                    // Проверка на уникальность логина.

                    command.CommandText =
                        "insert into [Users] (Login, Name, Password) values (@login, @name, @password)";
                    // Определяем параметры команды.
                    command.Parameters.AddWithValue("Login", Login.Text);
                    command.Parameters.AddWithValue("Name", UserName.Text.ToUpper());
                    command.Parameters.AddWithValue("Password", Password.Text);

                    command.ExecuteNonQuery(); // Выполняем вставку записей.

                    MessageBox.Show(@"Аккаун успешно создан!", @"Регистрация");
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка регистрации",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            finally
            {
                MainForm.UserDB.Close();
            }
        }
    }
}
