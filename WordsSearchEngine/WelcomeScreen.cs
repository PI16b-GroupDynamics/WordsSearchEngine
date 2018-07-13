using System;
using System.Windows.Forms;

namespace WordsSearchEngine
{
    public partial class WelcomeScreen : Form
    {
        public WelcomeScreen()
        {
            InitializeComponent();

            Log.WriteEvent(DateTime.Now, "Запуск приложения", "Приложение запущено.");
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
