using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
            _authorizationForm = new Form2();

            _settingsForm = new Form4();
            _settingsForm.checkBox1.Checked = false;
            _settingsForm.checkBox4.Checked = false;
            _settingsForm.checkBox5.Checked = true;
            _settingsForm.textBox1.Text = Application.StartupPath + @"\Results";

            SetSourceAsText(true); // По умолчанию установлен поиск слов в заданном тексте.
            _separators = new[] { ' ', '\n', '\r', ',', '.', '(', ')', '!', '?', '-', ';', ':', '"', '%', '\\', '/' };
            _resultList = new List<string>();
            _resultfileList = new List<string>();
            _originaltxt = new Dictionary<int, string>();
        }

        private readonly Form2 _authorizationForm;
        Form4 _settingsForm;

        private readonly char[] _separators; // Список возможных разделителей в исходном тексте.
        private List<string> _resultList;
        private List<string> _resultfileList;
        private Dictionary<int, string> _originaltxt;

        private void button1_Click(object sender, EventArgs e)
        {
            _authorizationForm.ShowDialog();
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Search.Enabled = false;
            FileToolStripMenuItem.Enabled = false;
            ParamsToolStripMenuItem.Enabled = false;
            HelpToolStripMenuItem.Enabled = false;
            button1.Enabled = false;
            OpenText.Enabled = false;
            SaveText.Enabled = false;
            SaveResult.Enabled = false;

            if (SearchInTextCriteria.Checked)
            {
                // Получаем список всех слов исходного текста.
                _resultList = OriginalText.Text.Split(_separators, StringSplitOptions.RemoveEmptyEntries).ToList();
                // _originaltxt = OriginalText.Text.Split(_separators, StringSplitOptions.RemoveEmptyEntries).ToDictionary();
                _resultfileList.Clear();

                if (CheckAllCriteria()) // Проверяем текст на наличие слов.
                {
                    FoundWords.Clear();
                    // Выводим список найденных слов/наименований файлов в окно результата.
                    foreach (string word in _resultList)
                    {
                        MessageBox.Show(@"Поиск слов закончен", @"Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FoundWords.Text += word + Environment.NewLine;
                    }
                }
                else
                    MessageBox.Show(@"В тексте нет слов, удовлетворяющим критериям поиска",
                        @"Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _resultfileList = new List<string>();
                SearchInFiles();

                if (_resultfileList.Count != 0)
                {
                    FoundWords.Clear();
                    // Выводим список наименований файлов в окно результата.
                    foreach (string word in _resultfileList)
                    {
                        MessageBox.Show(@"Поиск слов закончен", @"Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FoundWords.Text += word + Environment.NewLine;
                    }
                }
                else
                    MessageBox.Show(@"В текстах файлов, находящийся в указанном каталоге,"
                        + @" нет слов, удовлетворяющим критериям поиска",
                        @"Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Search.Enabled = true;
            FileToolStripMenuItem.Enabled = true;
            ParamsToolStripMenuItem.Enabled = true;
            HelpToolStripMenuItem.Enabled = true;
            button1.Enabled = true;
            OpenText.Enabled = true;
            SaveText.Enabled = true;
            SaveResult.Enabled = true;
        }

        private bool CheckAllCriteria()
        {
            // Проверяем текст на критерии поиска
            int index = 0;
            if (CapitalizedW.Checked)
            {
                CapitalizedWords(_resultList);
                foreach (string word in _resultList)
                {
                    index = OriginalText.Text.IndexOf(word);
                    OriginalText.SelectionStart = index;
                    OriginalText.SelectionLength = word.Length;
                    OriginalText.SelectionColor = Color.Aqua;
                    OriginalText.SelectionLength = 0;
                }
            }

            if (AbbreviationW.Checked)
            {
                Abbreviation(_resultList);
                foreach (string word in _resultList)
                {
                    index = OriginalText.Text.IndexOf(word);
                    OriginalText.SelectionStart = index;
                    OriginalText.SelectionLength = word.Length;
                    OriginalText.SelectionColor = Color.DarkBlue;
                    OriginalText.SelectionLength = 0;
                }
            }

            if (EnglishWordsCriteria.Checked)
            {
                SearchEnglishWords(_resultList);
                foreach (string word in _resultList)
                {
                    index = OriginalText.Text.IndexOf(word);
                    OriginalText.SelectionStart = index;
                    OriginalText.SelectionLength = word.Length;
                    OriginalText.SelectionColor = Color.ForestGreen;
                    OriginalText.SelectionLength = 0;
                }
            }

            if (WLenght.Checked)
            {
                Length(_resultList, LengthValue.Text);
                foreach (string word in _resultList)
                {
                    index = OriginalText.Text.IndexOf(word);
                    OriginalText.SelectionStart = index;
                    OriginalText.SelectionLength = word.Length;
                    OriginalText.SelectionColor = Color.Gold;
                    OriginalText.SelectionLength = 0;
                }
            }

            if (WCombination.Checked)
            {
                Combination(_resultList, CombinationValue.Text);
                foreach (string word in _resultList)
                {
                    index = OriginalText.Text.IndexOf(word);
                    OriginalText.SelectionStart = index;
                    OriginalText.SelectionLength = word.Length;
                    OriginalText.SelectionColor = Color.LightBlue;
                    OriginalText.SelectionLength = 0;
                }
            }

            if (GivenW.Checked)
            {
                GivenWord(_resultList, WordValue.Text);
                foreach (string word in _resultList)
                {
                    index = OriginalText.Text.IndexOf(word);
                    OriginalText.SelectionStart = index;
                    OriginalText.SelectionLength = word.Length;
                    OriginalText.SelectionColor = Color.Maroon;
                    OriginalText.SelectionLength = 0;
                }
            }

            // Если список найденных слов не пуст, возвращаем true (поиск был успешным).
            return _resultList.Count != 0;
        }

        private void SearchInFiles()
        {
            List<string> files = new List<string>();

            // Поиск в файлах осуществляется только в файлах с расширением ".txt".
            foreach (string file in Directory.GetFiles(SourceDirectory.Text).ToList())
            {
                if (file.EndsWith(".txt"))
                    files.Add(file.Replace(SourceDirectory.Text + "\\", ""));
            }

            foreach (string file in files)
            {
                // Получаем список слов файла.
                _resultList = File.ReadAllText(SourceDirectory.Text + "\\" + file,
                    Encoding.GetEncoding(1251)).Split(_separators, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (CheckAllCriteria())
                    AppendResultFilesList(file, _resultList);
            }

            /*
            // Аналогичный код, но с использованием Linq.
            // Преимущества:
            // 1) можно добавить поиск в подкаталогах,
            // 2) можно попробовать искать слова в файлах .docx, .rtf, .pdf.

            // Получаем список файлов заданной директории.
            var files = from retrievedFile in Directory.EnumerateFiles(SourceDirectory.Text, "*.txt",
                    SearchOption.TopDirectoryOnly)
                select new
                {
                    Name = retrievedFile.Replace(SourceDirectory.Text + "\\", ""), 
                    WordList = File.ReadAllText(retrievedFile, Encoding.GetEncoding(1251)).Split(_separators, StringSplitOptions.RemoveEmptyEntries).ToList()
                };

            foreach (var file in files)
            {
                //string encoding; // Автоопределение кодировки.
                //using (StreamReader sr = new StreamReader(SourceDirectory.Text + "\\" + file.Name, true))
                //{
                //   sr.ReadToEnd();
                //  encoding = sr.CurrentEncoding.ToString();
                //}
                _resultList = file.WordList;
                if(CheckAllCriteria())
                    AppendResultFilesList(file.Name, _resultList);
            }
            */
        }

        void AppendResultFilesList(string file, List<string> wordList)
        {
            _resultfileList.Add(file);

            foreach (string word in wordList)
                _resultfileList.Add(word);

            _resultfileList.Add("");
        }

        void CapitalizedWords(List<string> words)
        {
            _resultList = new List<string>();

            foreach (var s in words)
            {
                if (s.Trim() != "")
                {
                    if (char.IsUpper(s[0]))
                    {
                        _resultList.Add(s);
                    }
                }
            }
        }

        void Abbreviation(List<string> words)
        {
            _resultList = new List<string>();
            string tmp = "";

            foreach (var word in words)
            {
                if (word.Trim() != "")
                {
                    foreach (var letter in word)
                    {
                        if (char.IsUpper(letter))
                        {
                            tmp = tmp + letter;
                        }
                        else
                        {
                            tmp = "";
                            break;
                        }
                    }

                    if (word == tmp)
                    {
                        _resultList.Add(tmp);
                        tmp = "";
                    }
                }
            }
        }

        private void SearchEnglishWords(List<string> words)
        {
            _resultList = new List<string>();
            foreach (string word in words)
            {
                // Проверяем, является ли первая буква символом английского алфавита.
                if (word[0] >= 65 && word[0] <= 90 || word[0] >= 97 && word[0] <= 122)
                    _resultList.Add(word);
            }
        }

        void Length(List<string> words, string len)
        {
            _resultList = new List<string>();
            // Проверяем, не ввёел ли пользователь диапазон длин.
            if (len.IndexOf('-') == -1)
            {
                // Поиск слов по одному значению длины.
                foreach (var s in words)
                {
                    if (s.Trim() != "")
                    {
                        if (s.Length == Convert.ToInt32(len))
                        {
                            _resultList.Add(s);
                        }
                    }
                }
            }
            else
            {
                // Поиск слов, чья длина колеблется в заданном диапазоне.
                int lowBound = Convert.ToInt32(len.Substring(0, len.IndexOf('-')));
                int upperBound = Convert.ToInt32(len.Substring(len.IndexOf('-') + 1));

                _resultList = new List<string>();
                foreach (string word in words)
                {
                    if (word.Length >= lowBound && word.Length <= upperBound)
                        _resultList.Add(word);
                }
            }
        }

        void Combination(List<string> words, string sl)
        {
            _resultList = new List<string>();
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
                            if (tmp1.Length >= sl.Length)
                            {
                                if (tmp1 == sl)
                                {
                                    _resultList.Add(s);
                                }
                                else
                                {
                                    startIndex = tmp1.IndexOf(chrS);
                                    string tmp2 = tmp1.Substring(startIndex, sl.Length);
                                    if (tmp2 == sl)
                                    {
                                        _resultList.Add(s);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void GivenWord(List<string> words, string sl)
        {
            _resultList = new List<string>();
            int ecx = 0;
            foreach (var s in words)
            {
                if (s.Trim() != "")
                {
                    if (s == sl)
                    {
                        _resultList.Add(s);
                        ecx++;
                    }
                }
            }

            string mes = "Количество вхождений заданного слова в текст: " + Convert.ToString(ecx);
            MessageBox.Show(mes);
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                SourceDirectory.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void OpenText_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OriginalText.Text = File.ReadAllText(openFileDialog1.FileName, Encoding.Default);
            }
        }

        private void SearchInTextCriteria_CheckedChanged(object sender, EventArgs e)
        {
            // Источник поска слов - заданный в окне текст.
            SetSourceAsText(true);
        }

        private void SearchInFilesCriteria_CheckedChanged(object sender, EventArgs e)
        {
            // Источник поска слов - тексты файлов (т.е. не заданный в окне текст).
            SetSourceAsText(false);
        }

        private void SetSourceAsText(bool textSourceValue)
        {
            // Изменяем доступ к элементам управления в зависимости
            // от источника поиска (заданный текст или тексты в файлах).
            TextName.Enabled = textSourceValue;
            OriginalText.Enabled = textSourceValue;
            OpenText.Enabled = textSourceValue;
            SaveText.Enabled = textSourceValue;
            SourceDirectory.Enabled = !textSourceValue;
            Browse.Enabled = !textSourceValue;
        }

        private void CapitalizedW_CheckedChanged(object sender, EventArgs e)
        {
            SearchInFilesCriteria.Enabled = false;
            AbbreviationW.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            WLenght.Enabled = false;
            WCombination.Enabled = false;
            GivenW.Enabled = false;
        }

        private void AbbreviationW_CheckedChanged(object sender, EventArgs e)
        {
            CapitalizedW.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            WLenght.Enabled = false;
            WCombination.Enabled = false;
            GivenW.Enabled = false;
        }

        private void EnglishWordsCriteria_CheckedChanged(object sender, EventArgs e)
        {
            CapitalizedW.Enabled = false;
            AbbreviationW.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
            WLenght.Enabled = false;
            WCombination.Enabled = false;
            GivenW.Enabled = false;
        }

        private void WLenght_CheckedChanged(object sender, EventArgs e)
        {
            CapitalizedW.Enabled = false;
            AbbreviationW.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
            WCombination.Enabled = false;
            GivenW.Enabled = false;
        }

        private void WCombination_CheckedChanged(object sender, EventArgs e)
        {
            CapitalizedW.Enabled = false;
            AbbreviationW.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            WLenght.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
            GivenW.Enabled = false;
        }

        private void GivenW_CheckedChanged(object sender, EventArgs e)
        {
            CapitalizedW.Enabled = false;
            AbbreviationW.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            WLenght.Enabled = false;
            WCombination.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
        }

        private void SaveText_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "Сохранить как PDF";
            sfd.Filter = "(*.pdf)|*.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (OriginalText.Text != "")
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document();
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();
                    doc.Add(new iTextSharp.text.Paragraph(OriginalText.Text));
                    doc.Close();
                    MessageBox.Show("Текст успешно сохранен в PDF", "Оповещение");
                }
                else
                {
                    MessageBox.Show("Поле пусто. Сохранять в PDF нечего", "Оповещение",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void SaveResult_Click(object sender, EventArgs e)
        {

        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(@"Вы действительно хотите выйти ?",
                        @"Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                Application.Exit();
            }
        }

        private void ParamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settingsForm.ShowDialog();
        }

        private void InstructionStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "//HTML/Spravka.htm");
        }

        private void ProgrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "//HTML/About_prg.htm");
        }

        private void LoadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OriginalText.Text = File.ReadAllText(openFileDialog1.FileName, Encoding.Default);
            }
        }

        private void SaveInFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "Сохранить как PDF";
            sfd.Filter = "(*.pdf)|*.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (OriginalText.Text != "")
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document();
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();
                    doc.Add(new iTextSharp.text.Paragraph(OriginalText.Text));
                    doc.Close();
                    MessageBox.Show("Текст успешно сохранен в PDF", "Оповещение");
                }
                else
                {
                    MessageBox.Show("Поле пусто. Сохранять в PDF нечего", "Оповещение",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void SaveInFileResultTextToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaveInFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "Сохранить как PDF";
            sfd.Filter = "(*.pdf)|*.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (OriginalText.Text != "")
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document();
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();
                    doc.Add(new iTextSharp.text.Paragraph(OriginalText.Text));
                    doc.Close();
                    MessageBox.Show("Текст успешно сохранен в PDF", "Оповещение");
                }
                else
                {
                    MessageBox.Show("Поле пусто. Сохранять в PDF нечего", "Оповещение",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void SaveInFileResultText_Click(object sender, EventArgs e)
        {

        }
    }
}