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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2();
            form4 = new Form4();
        }

        private Form2 form2;
        private Form4 form4;
        private void button1_Click(object sender, EventArgs e)
        {
            form2.ShowDialog();
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form4.ShowDialog();
        }
    }
}
