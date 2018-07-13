using System;
<<<<<<< HEAD
=======
using System.Data.SQLite;
>>>>>>> 56453015507048d3d1cee879304888963969a9cf
using System.Drawing;
using System.Windows.Forms;

namespace WordsSearchEngine
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
            _registration = new Registration();
        }

        private readonly Registration _registration;

        private void Back_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            Close();
=======
            Visible = false;
>>>>>>> 56453015507048d3d1cee879304888963969a9cf
        }
        
        private void CreateAccount_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
=======
            ((MainForm) Owner).Visible = true;
>>>>>>> 56453015507048d3d1cee879304888963969a9cf
            Visible = false;
            _registration.ShowDialog();
            Visible = true;
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (!Users.SetCurrentUser(Login.Text.ToLower(), Password.Text))
                MessageBox.Show(@"Некорректный логин или пароль!",
                    @"Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                Log.WriteEvent(DateTime.Now, "Авторизация", $"Пользователь {Users.CurrentUser.Login} выполнил вход в систему.");
                Close();
=======
            try
            {
                MainForm.UserDb.Open();
                using (var command = MainForm.UserDb.CreateCommand())
                {
                    command.CommandText = "select Name from users where Login = @login and Password = @password";
                    command.Parameters.AddWithValue("Login", Login.Text.ToLower());
                    command.Parameters.AddWithValue("Password", Password.Text);
                    string name = (string)command.ExecuteScalar();
                    if (!string.IsNullOrEmpty(name))
                    {
                        ((MainForm)Owner).SignUp.Text = name;
                        Visible = false;
                    }
                    else {
                        MessageBox.Show(@"Некорректный логин или пароль!",
                            @"Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    //SQLiteDataReader reader = command.ExecuteReader();
                    //if (reader.HasRows)
                    //{
                    //    SignUp.Text = (string)reader[0];
                    //    Visible = false;
                    //}
                    //else
                    //{
                    //    MessageBox.Show(@"Некорректный логин или пароль!", @"Ошибка регистрации",
                    //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                    //}
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка авторизации",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            finally
            {
                MainForm.UserDb.Close();
>>>>>>> 56453015507048d3d1cee879304888963969a9cf
            }
        }
        private void CreateAccount_MouseEnter(object sender, EventArgs e)
        {
            CreateAccount.Font = new Font(CreateAccount.Font, FontStyle.Underline);
        }

        private void CreateAccount_MouseLeave(object sender, EventArgs e)
        {
            CreateAccount.Font = new Font(CreateAccount.Font, FontStyle.Regular);
        }
<<<<<<< HEAD
=======

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }
>>>>>>> 56453015507048d3d1cee879304888963969a9cf
    }
}
