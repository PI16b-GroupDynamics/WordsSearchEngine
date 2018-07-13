using System;
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
            Close();
        }
        
        private void CreateAccount_Click(object sender, EventArgs e)
        {
            Visible = false;
            _registration.ShowDialog();
            Visible = true;
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            if (!Users.SetCurrentUser(Login.Text.ToLower(), Password.Text))
                MessageBox.Show(@"Некорректный логин или пароль!",
                    @"Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                Log.WriteEvent(DateTime.Now, "Авторизация", $"Пользователь {Users.CurrentUser.Login} выполнил вход в систему.");
                Close();
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
    }
}
