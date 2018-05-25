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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            form3 = new Form3();
        }

        private Form3 form3;

        private void button3_Click(object sender, EventArgs e)
        {
            form3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
