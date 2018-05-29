using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordsSearchEngine
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            _authorizationForm = new Authorization { Owner = this };
            _settingsForm = new Form4();
            
            SetSourceAsText(true); // По умолчанию установлен поиск слов в заданном тексте.
            _separators = new[] { ' ', '\n', '\r', ',', '.', '(', ')', '!', '?', '-', ';', ':', '"', '%', '\\', '/' };
            _resultList = new List<string>();
            _resultfileList = new List<string>();
        }

        public static SQLiteConnection UserDb;

        private readonly Authorization _authorizationForm;
        private readonly Form4 _settingsForm;

        private readonly char[] _separators; // Список возможных разделителей в исходном тексте.
        private List<string> _resultList;
        private List<string> _resultfileList;

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Устанавливаем связь с базой данных.
            UserDb = new SQLiteConnection("Data Source=Users.db; Version=3");
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            _authorizationForm.ShowDialog();
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settingsForm.ShowDialog();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (SearchInTextCriteria.Checked)
            {
                // Получаем список всех слов исходного текста.
                _resultList = OriginalText.Text.Split(_separators, StringSplitOptions.RemoveEmptyEntries).ToList();
                _resultfileList.Clear();

                if (CheckAllCriteria()) // Проверяем текст на наличие слов.
                {
                    FoundWords.Clear();
                    // Выводим список найденных слов/наименований файлов в окно результата.
                    foreach (string word in _resultList)
                        FoundWords.Text += word + Environment.NewLine;
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
                        FoundWords.Text += word + Environment.NewLine;
                }
                else
                    MessageBox.Show(@"В текстах файлов, находящийся в указанном каталоге,"
                        + @" нет слов, удовлетворяющим критериям поиска",
                        @"Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool CheckAllCriteria()
        {
            // Проверяем текст на критерии поиска.

            if (CapitalizedW.Checked)
                CapitalizedWords(_resultList);

            if (AbbreviationW.Checked)
                Abbreviation(_resultList);

            if (EnglishWordsCriteria.Checked)
                SearchEnglishWords(_resultList);

            if (WLenght.Checked)
                Length(_resultList, LengthValue.Text);

            if (WCombination.Checked)
                Combination(_resultList, CombinationValue.Text);

            if (GivenW.Checked)
                GivenWord(_resultList, WordValue.Text);

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
                
                if(CheckAllCriteria())
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
            _resultList= new List<string>();
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


        private void CapitalizedW_Click(object sender, EventArgs e)
        {
            SearchInFilesCriteria.Enabled = false;
            AbbreviationW.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            WLenght.Enabled = false;
            WCombination.Enabled = false;
            GivenW.Enabled = false;
        }

        private void AbbreviationW_Click(object sender, EventArgs e)
        {
            CapitalizedW.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            WLenght.Enabled = false;
            WCombination.Enabled = false;
            GivenW.Enabled = false;
        }

        private void EnglishWordsCriteria_Click(object sender, EventArgs e)
        {
            CapitalizedW.Enabled = false;
            AbbreviationW.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
            WLenght.Enabled = false;
            WCombination.Enabled = false;
            GivenW.Enabled = false;
        }

        private void WLengh_Click(object sender, EventArgs e)
        {
            CapitalizedW.Enabled = false;
            AbbreviationW.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
            WCombination.Enabled = false;
            GivenW.Enabled = false;
        }

        private void LengthRangeCriteria_Click(object sender, EventArgs e)
        {
            CapitalizedW.Enabled = false;
            AbbreviationW.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            WLenght.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
            WCombination.Enabled = false;
            GivenW.Enabled = false;
        }

        private void WCombination_Click(object sender, EventArgs e)
        {
            CapitalizedW.Enabled = false;
            AbbreviationW.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            WLenght.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
            GivenW.Enabled = false;
        }

        private void GivenW_Click(object sender, EventArgs e)
        {
            CapitalizedW.Enabled = false;
            AbbreviationW.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            WLenght.Enabled = false;
            WCombination.Enabled = false;
            SearchInFilesCriteria.Enabled = false;
        }

        private void SearchInFilesCriteria_Click(object sender, EventArgs e)
        {
            CapitalizedW.Enabled = false;
            AbbreviationW.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            WLenght.Enabled = false;
            WCombination.Enabled = false;
            GivenW.Enabled = false;
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                SourceDirectory.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenText_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog {Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*"};
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
            OriginalText.Enabled = textSourceValue;
            OpenText.Enabled = textSourceValue;
            SaveText.Enabled = textSourceValue;
            SourceDirectory.Enabled = !textSourceValue;
            Browse.Enabled = !textSourceValue;
        }
    }
}
