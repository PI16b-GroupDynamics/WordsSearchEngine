using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordsSearchEngine
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { MessageBox.Show(@"Не забудьте указать имя текста",
                @"Оповещание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true) { MessageBox.Show(@"Не забудьте указать имя текста",
                @"Оповещание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
    }
}
