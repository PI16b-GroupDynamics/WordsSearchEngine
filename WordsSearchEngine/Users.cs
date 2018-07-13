using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace WordsSearchEngine
{
    public class Users
    {
        public class User
        {
            private string _password;
            private string _salt;

            public string Login { get; set; }
            public string Name { get; set; }

            public AdvancedStack Texts { get; set; } // Массив строк расположений файлов с текстами.
            public AdvancedStack Results { get; set; } // Массив строк расположений файлов результатов.

            public User(string login, string name, string password, string salt, AdvancedStack texts, AdvancedStack results)
            {
                Login = login;
                Name = name;

                _password = password;
                _salt = salt;

                Texts = texts;
                Results = results;
            }

            public bool SetNewPassword(string oldPassword, string newPassword)
            {
                if (!HashEncryptor.SlowEquals(_password.ToBytes(),
                    HashEncryptor.EncodePassword(oldPassword, _salt).ToBytes()))
                    return false;
                    try
                    {
                        using (var connection = new SQLiteConnection(@"Data Source=Users.db; Version=3"))
                        {
                            connection.Open();
                            using (var command = new SQLiteCommand(connection))
                            {
                                var salt = HashEncryptor.GenerateSalt();
                                var password = HashEncryptor.EncodePassword(newPassword, salt);
                                command.CommandText = $"update Users set Password = '{password}', Salt = '{salt}' where Login = '{Login}'";
                                command.ExecuteNonQuery();
                                _salt = salt;
                                _password = password;
                                return true;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ShowErrorMessage(e.Message);
                        return false;
                    }
            }

            public bool SetLogin(string newLogin)
            {
                try
                {
                    using (var connection = new SQLiteConnection(@"Data Source=Users.db; Version=3"))
                    {
                        connection.Open();
                        using (var command = new SQLiteCommand(connection))
                        {
                            command.CommandText = $"update Users set Login = '{newLogin}' where Login = '{Login}'";
                            command.ExecuteNonQuery();
                            Login = newLogin;
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    ShowErrorMessage(e.Message);
                    return false;
                }
            }

            public bool SetName(string newName)
            {
                try
                {
                    using (var connection = new SQLiteConnection(@"Data Source=Users.db; Version=3"))
                    {
                        connection.Open();
                        using (var command = new SQLiteCommand(connection))
                        {
                            command.CommandText = $"update Users set Name = '{newName}' where Login = '{Login}'";
                            command.ExecuteNonQuery();
                            Name = newName;
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    ShowErrorMessage(e.Message);
                    return false;
                }
            }

            public void SaveRecentFiles()
            {
                var texts = string.Join("|", Texts.ToArray());
                var results = string.Join("|", Results.ToArray());

                try
                {
                    using (var connection = new SQLiteConnection(@"Data Source=Users.db; Version=3"))
                    {
                        connection.Open();
                        using (var command = new SQLiteCommand(connection))
                        {
                            command.CommandText = $"update Users set Texts = '{texts}', Results = '{results}' where Login = '{Login}'";
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception e)
                {
                    ShowErrorMessage(e.Message);
                }
            }

            public void DeleteAccount()
            {
                try
                {
                    using (var connection = new SQLiteConnection(@"Data Source=Users.db; Version=3"))
                    {
                        connection.Open();
                        using (var command = new SQLiteCommand(connection))
                        {
                            command.CommandText = $"delete from Users where Login = '{Login}'";
                            command.ExecuteScalar();
                        }
                    }
                }
                catch (Exception e)
                {
                    ShowErrorMessage(e.Message);
                }
            }
        }

        public static User CurrentUser;

        // Проверка на уникальность логина.
        public static bool IsLoginUnique(string login)
        {
            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=Users.db; Version=3"))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = $"select Login from users where Login = '{login}'";
                        var retrievedlogin = (string) command.ExecuteScalar();
                        return string.IsNullOrEmpty(retrievedlogin);
                    }
                }
            }
            catch (Exception e)
            {
                ShowErrorMessage(e.Message);
                return false;
            }
        }

        // Добавление пользователя в базу данных.
        public static void Add(string name, string login, string password)
        {
            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=Users.db; Version=3"))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(connection))
                    {
                        var salt = HashEncryptor.GenerateSalt();
                        var passwordHash = HashEncryptor.EncodePassword(password, salt);

                        command.CommandText =
                            $"insert into Users (Name, Login, Password, Salt) values ('{name}', '{login}', '{passwordHash}', '{salt}')";

                        command.ExecuteNonQuery(); // Выполняем вставку записей.
                    }
                }
            }
            catch (Exception e)
            {
                ShowErrorMessage(e.Message);
            }
        }

        public static bool SetCurrentUser(string login, string password)
        {
            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=Users.db; Version=3"))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = $"select * from users where Login = '{login}'";
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows) return false;
                            if (!reader.Read()) return false;

                            var userLogin = reader.GetValue(0).ToString();
                            var userName = reader.GetValue(1).ToString();
                            var userPassword = reader.GetValue(2).ToString();
                            var userSalt = reader.GetValue(3).ToString();
                            var userTexts = reader.GetValue(4).ToString().Split('|').ToList();
                            var userResults = reader.GetValue(5).ToString().Split('|').ToList();

                            if (!HashEncryptor.SlowEquals(userPassword.ToBytes(),
                                HashEncryptor.EncodePassword(password, userSalt).ToBytes()))
                                return false;

                            // Устанавливаем текущего пользователя.
                            CurrentUser = new User(userLogin, userName, userPassword, userSalt,
                                new AdvancedStack(userTexts), new AdvancedStack(userResults));
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ShowErrorMessage(e.Message);
                return false;
            }
        }

        private static void ShowErrorMessage(string message)
        {
            var result = MessageBox.Show(@"Возникла ошибка при попытке доступа к базе данных. " +
                                                  @"Возможно, база данных повреждена, перемещена либо удалена. " +
                                                  @"Если продолжить работу с программой, возможно ее непредсказуемое поведение. " +
                                                  Environment.NewLine + Environment.NewLine +
                                                  @"Убедитесь в наличии файла базы данных по пути " +
                                                  Application.StartupPath + @"\Users.db, затем проверьте его на отсутствие повреждений, " +
                                                  @"после чего перезапустите приложение." +
                                                  Environment.NewLine + Environment.NewLine + @"Дополнительные сведения: " +
                                                  Environment.NewLine + message, @"WordsSearchEngine",
                MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

            if (result == DialogResult.Abort)
                Application.Exit();
            else if (result == DialogResult.Retry)
            {
                Application.Restart();
            }
        }
    }
}
