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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            _mainform = new Form1();
        }

        private readonly Form1 _mainform;

        private void Start_Click(object sender, EventArgs e)
        {
            _mainform.ShowDialog();
        }
    }
}
