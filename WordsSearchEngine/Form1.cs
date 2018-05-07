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

        private void button4_Click(object sender, EventArgs e)
        {
            string Text = richTextBox1.Text;

            if (checkBox1.Checked)
            {
                CapitalizedWords(Text);
            }
            if (checkBox2.Checked)
            {
                Abbreviation(Text);
            }
            if (checkBox3.Checked)
            {
            }
            if (checkBox4.Checked)
            {
                int dl = Convert.ToInt32(textBox1.Text);
                Length(Text, dl);
            }
            if (checkBox5.Checked)
            {
            }
            if (checkBox6.Checked)
            {
                string Kr6 = textBox3.Text;
                Combination(Text, Kr6);
            }
            if (checkBox7.Checked)
            {
                string Kr7 = textBox4.Text;
                GivenWord(Text, Kr7);
            }
            if (checkBox8.Checked)
            {
            }
        }

        void CapitalizedWords(string txt)
        {
            string[] words = txt.Split(new Char[] { ' ', ',', '.', ':', '?', '!', ';', '-' });

            foreach (var s in words)
            {
                if (s.Trim() != "")
                {
                    if (char.IsUpper(s[0]))
                    {
                        richTextBox2.Text = richTextBox2.Text + s + "\n";
                    }
                }
            }
        }

        void Abbreviation(string txt)
        {
            string[] words = txt.Split(new Char[] { ' ', ',', '.', ':', '?', '!', ';', '-' });
            string tmp = "";

            foreach (var s in words)
            {
                if (s.Trim() != "")
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (char.IsUpper(s[i]))
                        {
                            tmp = tmp + s[i];
                        }
                        else
                        {
                            tmp = "";
                            break;
                        }
                    }
                    if (s == tmp)
                    {
                        richTextBox2.Text = richTextBox2.Text + tmp + "\n";
                        tmp = "";
                    }
                }
            }
        }

        void Length(string txt, int len)
        {
            string[] words = txt.Split(new Char[] { ' ', ',', '.', ':', '?', '!', ';', '-' });

            foreach (var s in words)
            {
                if (s.Trim() != "")
                {
                    if (s.Length == len)
                    {
                        richTextBox2.Text = richTextBox2.Text + s + "\n";
                    }
                }
            }
        }

        void Combination(string txt, string sl)
        {
            string[] words = txt.Split(new Char[] { ' ', ',', '.', ':', '?', '!', ';', '-' });
            Char chrS = sl[0];
            Char chrE = sl[sl.Length - 1];

            foreach (var s in words)
            {
                string tmp = s;
                if (tmp.Trim() != "")
                {
                    int startIndex = tmp.IndexOf(chrS);
                    if (startIndex >= 0)
                    {
                        int endIndex = tmp.LastIndexOf(chrE);
                        if (endIndex >= 0)
                        {
                            int len = endIndex - startIndex + 1;
                            string tmp1 = tmp.Substring(startIndex, len);
                            if (tmp1.Length < sl.Length)
                            {
                                break;
                            }
                            else
                            {
                                if (tmp1 == sl)
                                {
                                    richTextBox2.Text = richTextBox2.Text + s + "\n";
                                }
                                else
                                {
                                    startIndex = tmp1.IndexOf(chrS);
                                    string tmp2 = tmp1.Substring(startIndex, sl.Length);
                                    if (tmp2 == sl)
                                    {
                                        richTextBox2.Text = richTextBox2.Text + s + "\n";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        void GivenWord(string txt, string sl)
        {
            int ecx = 0;
            string[] words = txt.Split(new Char[] { ' ', ',', '.', ':', '?', '!', ';', '-' });

            foreach (var s in words)
            {
                if (s.Trim() != "")
                {
                    if (s == sl)
                    {
                        richTextBox2.Text = richTextBox2.Text + s + "\n";
                        ecx++;
                    }
                }
            }
            string mes = "Количество вхождений заданного слова в текст: " + Convert.ToString(ecx);
            MessageBox.Show(mes);
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox8.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox8.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox8.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox8.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
        }

        private void checkBox5_Click(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            checkBox8.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
        }

        private void checkBox6_Click(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox8.Enabled = false;
            checkBox7.Enabled = false;
        }

        private void checkBox7_Click(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox8.Enabled = false;
        }

        private void checkBox8_Click(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
