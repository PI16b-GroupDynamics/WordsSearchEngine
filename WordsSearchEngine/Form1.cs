using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

            _separators = new[] { ' ', '\n', ',', '.', '(', ')', '!', '?', '-', ';', ':', '"', '%' };
        }

        private Form2 form2;
        private Form4 form4;

        private char[] _separators; // Список возможных разделителей в исходном тексте.
        
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
            string Text = OriginalText.Text;

            if (checkBox1.Checked)
            {
                CapitalizedWords(Text);
            }
            if (checkBox2.Checked)
            {
                Abbreviation(Text);
            }
            if (EnglishWordsCriteria.Checked)
                SearchEnglishWords(Text);

            if (checkBox4.Checked)
            {
                int dl = Convert.ToInt32(textBox1.Text);
                Length(Text, dl);
            }

            if (LengthRangeCriteria.Checked)
                SearchWordsOfGivenLength(Text, LengthRange.Text);
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

            if (SearchInFilesCriteria.Checked)
                SearchInFiles();
        }

        void CapitalizedWords(string txt, string fileName = null)
        {
            List<string> resultList = new List<string>(); // Список с найденными словами/наименованиями файлов.

            string[] words = txt.Split(new Char[] { ' ', ',', '.', ':', '?', '!', ';', '-' });

            foreach (var s in words)
            {
                if (s.Trim() != "")
                {
                    if (char.IsUpper(s[0]))
                    {
                        resultList.Add(s);
                    }
                }
            }

            if (resultList.Count != 0)
            {
                if (fileName != null) FoundWords.Text += fileName + Environment.NewLine;
                foreach (string foundWord in resultList)
                {
                    FoundWords.Text += foundWord + Environment.NewLine;
                }
            }
        }

        void Abbreviation(string txt, string fileName = null)
        {
            List<string> resultList = new List<string>(); // Список с найденными словами/наименованиями файлов.

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
                        FoundWords.Text = FoundWords.Text + tmp + "\n";
                        tmp = "";
                    }
                }
            }

            if (resultList.Count != 0)
            {
                if (fileName != null) FoundWords.Text += fileName + Environment.NewLine;
                foreach (string foundWord in resultList)
                {
                    FoundWords.Text += foundWord + Environment.NewLine;
                }
            }
        }

        private void SearchEnglishWords(string text, string fileName = null)
        {
            List<string> resultList = new List<string>(); // Список с найденными словами/наименованиями файлов.

            string[] words = text.Split(_separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i][0] >= 65 && words[i][0] <= 90 || words[i][0] >= 97 && words[i][0] <= 122)
                    resultList.Add(words[i]);
            }

            if(resultList.Count != 0)
            {
                if (fileName != null) FoundWords.Text += fileName + Environment.NewLine;
                foreach (string foundWord in resultList)
                {
                    FoundWords.Text += foundWord + Environment.NewLine;
                }
            }
        }

        void Length(string txt, int len, string fileName = null)
        {
            List<string> resultList = new List<string>(); // Список с найденными словами/наименованиями файлов.

            string[] words = txt.Split(new Char[] { ' ', ',', '.', ':', '?', '!', ';', '-' });

            foreach (var s in words)
            {
                if (s.Trim() != "")
                {
                    if (s.Length == len)
                    {
                        resultList.Add(s);
                    }
                }
            }

            if (resultList.Count != 0)
            {
                if (fileName != null) FoundWords.Text += fileName + Environment.NewLine;
                foreach (string foundWord in resultList)
                {
                    FoundWords.Text += foundWord + Environment.NewLine;
                }
            }
        }

        private void SearchWordsOfGivenLength(string text, string lengthRange, string fileName = null)
        {
            List<string> resultList = new List<string>(); // Список с найденными словами/наименованиями файлов.

            int lowBound, upperBound;
            if (lengthRange.IndexOf("-") == -1) return;
            
            lowBound = Convert.ToInt32(lengthRange.Substring(0, lengthRange.IndexOf("-")));
            upperBound = Convert.ToInt32(lengthRange.Substring(lengthRange.IndexOf("-") + 1));

            string[] words = text.Split(_separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
               if(word.Length >= lowBound && word.Length <= upperBound)
                   resultList.Add(word);
            }

            if (resultList.Count != 0)
            {
                if (fileName != null) FoundWords.Text += fileName + Environment.NewLine;
                foreach (string foundWord in resultList)
                {
                    FoundWords.Text += foundWord + Environment.NewLine;
                }
            }
        }
        void Combination(string txt, string sl, string fileName = null)
        {
            List<string> resultList = new List<string>(); // Список с найденными словами/наименованиями файлов.

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
                                    resultList.Add(s);
                                }
                                else
                                {
                                    startIndex = tmp1.IndexOf(chrS);
                                    string tmp2 = tmp1.Substring(startIndex, sl.Length);
                                    if (tmp2 == sl)
                                    {
                                        resultList.Add(s);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (resultList.Count != 0)
            {
                if (fileName != null) FoundWords.Text += fileName + Environment.NewLine;
                foreach (string foundWord in resultList)
                {
                    FoundWords.Text += foundWord + Environment.NewLine;
                }
            }
        }

        void GivenWord(string txt, string sl, string fileName = null)
        {
            List<string> resultList = new List<string>(); // Список с найденными словами/наименованиями файлов.

            int ecx = 0;
            string[] words = txt.Split(new Char[] { ' ', ',', '.', ':', '?', '!', ';', '-' });

            foreach (var s in words)
            {
                if (s.Trim() != "")
                {
                    if (s == sl)
                    {
                       resultList.Add(s);
                        ecx++;
                    }
                }
            }
            string mes = "Количество вхождений заданного слова в текст: " + Convert.ToString(ecx);
            MessageBox.Show(mes);

            if (resultList.Count != 0)
            {
                if (fileName != null) FoundWords.Text += fileName + Environment.NewLine;
                foreach (string foundWord in resultList)
                {
                    FoundWords.Text += foundWord + Environment.NewLine;
                }
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            SearchInFilesCriteria.Enabled = false;
            checkBox2.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            checkBox4.Enabled = false;
            LengthRangeCriteria.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            checkBox4.Enabled = false;
            LengthRangeCriteria.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
            checkBox4.Enabled = false;
            LengthRangeCriteria.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
            LengthRangeCriteria.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
        }

        private void checkBox5_Click(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            checkBox4.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
        }

        private void checkBox6_Click(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            checkBox4.Enabled = false;
            LengthRangeCriteria.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
            checkBox7.Enabled = false;
        }

        private void checkBox7_Click(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            checkBox4.Enabled = false;
            LengthRangeCriteria.Enabled = false;
            checkBox6.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
        }

        private void checkBox8_Click(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            checkBox4.Enabled = false;
            LengthRangeCriteria.Enabled = false;
            checkBox6.Enabled = false;
            checkBox7.Enabled = false;
        }

        private void SearchInFiles()
        {
            List<string> files = Directory.GetFiles(SearchDirectory.Text).ToList();

            for (int i = 0; i < files.Count; i++)
            {
                if(EnglishWordsCriteria.Checked)
                    SearchEnglishWords(File.ReadAllText(files[i], Encoding.GetEncoding(1251)), files[i]);
            }
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                SearchDirectory.Text = FolderBrowserDialog.SelectedPath;
            }
        }
    }
}
