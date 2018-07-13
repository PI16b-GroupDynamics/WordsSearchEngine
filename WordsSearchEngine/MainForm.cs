using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using iTextSharp.text.pdf.parser;
=======
<<<<<<< HEAD:WordsSearchEngine/Form1.cs
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
=======
using System.Data.SQLite;
>>>>>>> authorization:WordsSearchEngine/MainForm.cs
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Org.BouncyCastle.Crypto;
>>>>>>> 56453015507048d3d1cee879304888963969a9cf

namespace WordsSearchEngine
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
<<<<<<< HEAD

            MainMenu.Renderer = new MenuStripRenderer();
            AccountMenu.Renderer = new MenuStripRenderer();
            
            _recentTexts = new AdvancedStack();
            _recentResults = new AdvancedStack();

            SetRecentFiles(); // Загружаем недавно открытые файлы.
            UpdateRecentTexts();
            UpdateRecentResults();

            SetSourceAsText(true); // По умолчанию установлен поиск слов в заданном тексте.
            _separators = new[] {' ', '\n', '\r', ',', '.', '(', ')', '!', '?', '-', ';', ':', '"', '«', '»', '%', '\\', '/'};
            _resultList = new List<string>();
            _resultfileList = new List<string>();
            
            _settingsForm = new SettingsForm();
            _settingsForm.SetSettingsFromFile(); // Загружаем настройки с предыдущего запуска приложения.

            var welcomeScreen = new WelcomeScreen();
            welcomeScreen.ShowDialog();
        }

        #region Внутренние типы и члены.

        private readonly SettingsForm _settingsForm;

        private readonly char[] _separators; // Массив возможных разделителей в исходном тексте.
        private List<string> _resultList; // Список найденных слов.
        private List<string> _resultfileList; // Список названий файлов, в которых есть найденные слова.
        private bool _searchHasJustFinished; // Флаг, показывающий, что поиск только что закончен.
        private readonly AdvancedStack _recentTexts; // Список недавно открытых текстов.
        private readonly AdvancedStack _recentResults; // Список недавно сохранённых результатом поиска.

        private enum DataType { Text, Result } // Перечисление типа данных (текст или результат поиска),
        // с которым работает (открывает, сохраняет) пользователь.

        // Собственный класс функций рисования ToolStrip объектов.
        // Переопределён метод отрисовки заднего фона меню, цвета шрифта и разделителя.
        public class MenuStripRenderer : ToolStripRenderer
        {
            // Изменяем стиль меню.
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.ToolStrip.IsDropDown && (e.Item.Selected || e.Item.Pressed))
                {
                    e.Graphics.FillRectangle(SystemBrushes.ControlDarkDark, e.Item.ContentRectangle);
                    e.Item.ForeColor = Color.White;
                }
                else e.Item.ForeColor = Color.Black;

                if (!e.ToolStrip.IsDropDown) return;

                e.ToolStrip.BackColor = Color.Gainsboro;
                e.Item.ForeColor = Color.Black;
                if (e.Item.Selected || e.Item.Pressed)
                    e.Graphics.FillRectangle(SystemBrushes.ControlDark, e.Item.ContentRectangle);
            }

            // Рисуем собственный разделитель.
            protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
            {
                if (!(e.Item is ToolStripSeparator))
                    base.OnRenderSeparator(e);
                e.Graphics.DrawLine(new Pen(SystemColors.ControlDark), 0, e.Item.Height / 2, e.Item.Width, e.Item.Height / 2);
            }
        }

        #endregion

        #region Методы поиска слов по критериям.

        private void CapitalizedWords(List<string> words)
        {
            _resultList = new List<string>();

            foreach (var word in words)
            {
                if (char.IsUpper(word[0]))
                    _resultList.Add(word);
            }
        }

        private void Abbreviation(List<string> words)
        {
            _resultList = new List<string>();

            foreach (var word in words)
            {
                if (word.Length == 1) continue;
                var isAbbreviation = true;
                for (int i = 0; i < word.Length && isAbbreviation; i++)
                {
                    if (!char.IsUpper(word[i]))
                        isAbbreviation = false;
                }

                if (isAbbreviation)
                    _resultList.Add(word);
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

        private void Length(List<string> words, string length)
        {
            _resultList = new List<string>();
            // Проверяем, не ввёел ли пользователь диапазон длин.
            if (length.IndexOf('-') == -1)
            {
                // Поиск слов по одному значению длины.
                foreach (var s in words)
                {
                    if (s.Length == Convert.ToInt32(length))
                        _resultList.Add(s);
                }
            }
            else
            {
                // Поиск слов, чья длина колеблется в заданном диапазоне.
                int lowBound = Convert.ToInt32(length.Substring(0, length.IndexOf('-')));
                int upperBound = Convert.ToInt32(length.Substring(length.IndexOf('-') + 1));

                _resultList = new List<string>();
                foreach (string word in words)
                {
                    if (word.Length >= lowBound && word.Length <= upperBound)
                        _resultList.Add(word);
                }
            }
        }

        private void Combination(List<string> words, string combination)
        {
            _resultList = new List<string>();
            foreach (var word in words)
                if (word.IndexOf(combination, StringComparison.CurrentCultureIgnoreCase) != -1)
                    _resultList.Add(word);
        }

        private void GivenWord(List<string> words, string givenWord)
        {
            _resultList = new List<string>();
            foreach (var word in words)
                if (String.Equals(word, givenWord, StringComparison.CurrentCultureIgnoreCase))
                    _resultList.Add(word);
        }

        #endregion

        #region Реализация события нажатия на кнопку "Найти" и сопутствующие методы.
        private bool IsReadyToSearch()
        {
            if (LengthCriteria.Checked)
            {
                if (LengthValue.Text == "")
                {
                    MessageBox.Show(@"Введите длину слова.", @"Words Search Engine", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return false;
                }

                if (LengthValue.Text.IndexOf('-') != -1)
                {
                    try
                    {
                        // Проверяем корректность заданного диапазона длин слов.
                        int lowBound = Convert.ToInt16(LengthValue.Text.Substring(0, LengthValue.Text.IndexOf('-')));
                        int upperBound = Convert.ToInt16(LengthValue.Text.Substring(LengthValue.Text.IndexOf('-') + 1));
                        if (lowBound >= upperBound) throw new Exception();
                    }
                    catch
                    {
                        MessageBox.Show(@"Некорректно задана длина слова." + '\n' +
                                        @"Введите либо одно значение длины слова, либо диапазон длин через дефис. Например: 2, 5, 7-8, 3-4.",
                            @"Words Search Engine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                else if (Convert.ToInt16(LengthValue.Text) == 0)
                {
                    MessageBox.Show(@"Некорректно задана длина слова." + '\n' +
                                    @"Введите значение больше нуля.", @"Words Search Engine", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            if (CombinationCriteria.Checked && CombinationValue.Text == "")
            {
                MessageBox.Show(@"Введите комбинацию букв слова. Например: оро, по, ция.", @"Words Search Engine",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (!GivenWordCriteria.Checked || WordValue.Text != "") return true;

            MessageBox.Show(@"Введите слово для поиска.", @"Words Search Engine", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            return false;

=======
<<<<<<< HEAD:WordsSearchEngine/Form1.cs
            _authorizationForm = new Form2();

            _settingsForm = new Form4();
            _settingsForm.checkBox1.Checked = false;
            _settingsForm.checkBox4.Checked = false;
            _settingsForm.checkBox5.Checked = true;
            _settingsForm.textBox1.Text = Application.StartupPath + @"\Results";

            ToolsFile();
=======

            _authorizationForm = new Authorization { Owner = this };
            _settingsForm = new Form4();
            
>>>>>>> authorization:WordsSearchEngine/MainForm.cs
            SetSourceAsText(true); // По умолчанию установлен поиск слов в заданном тексте.
            _separators = new[] { ' ', '\n', '\r', ',', '.', '(', ')', '!', '?', '-', ';', ':', '"', '%', '\\', '/' };
            _resultList = new List<string>();
            _resultfileList = new List<string>();
            _originaltxt = new Dictionary<int, string>();
        }

<<<<<<< HEAD:WordsSearchEngine/Form1.cs
        private readonly Form2 _authorizationForm;
        Form4 _settingsForm;
=======
        public static SQLiteConnection UserDb;

        private readonly Authorization _authorizationForm;
        private readonly Form4 _settingsForm;
>>>>>>> authorization:WordsSearchEngine/MainForm.cs

        private readonly char[] _separators; // Список возможных разделителей в исходном тексте.
        private List<string> _resultList;
        private List<string> _resultfileList;
        private Dictionary<int, string> _originaltxt;

<<<<<<< HEAD:WordsSearchEngine/Form1.cs
        public void ToolsFile()
=======
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Устанавливаем связь с базой данных.
            UserDb = new SQLiteConnection("Data Source=Users.db; Version=3");
        }

        private void SignUp_Click(object sender, EventArgs e)
>>>>>>> authorization:WordsSearchEngine/MainForm.cs
        {
            string path = @"System";
            string fullPath = Path.GetFullPath(path) + "\\Tools.dat";
            string toRes = Application.StartupPath + @"\Results";
            string[] tools = new string[] { "false", "false", "true", toRes };
            // This text is added only once to the file.
            if (!File.Exists(fullPath))
            {
                // Create a file to write to.
                File.WriteAllLines(fullPath, tools, Encoding.UTF8);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _authorizationForm.ShowDialog();
>>>>>>> 56453015507048d3d1cee879304888963969a9cf
        }

        private void Search_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (!IsReadyToSearch()) return;

            SetButtonAccess(false);
            DeselectText(Color.Black, Color.White);
            FoundWords.Clear();
=======
            Search.Enabled = false;
            FileToolStripMenuItem.Enabled = false;
            ParamsToolStripMenuItem.Enabled = false;
            HelpToolStripMenuItem.Enabled = false;
            button1.Enabled = false;
            OpenText.Enabled = false;
            SaveText.Enabled = false;
            SaveResult.Enabled = false;
>>>>>>> 56453015507048d3d1cee879304888963969a9cf

            if (SearchInTextCriteria.Checked)
            {
                // Получаем список всех слов исходного текста.
                _resultList = OriginalText.Text.Split(_separators, StringSplitOptions.RemoveEmptyEntries).ToList();
<<<<<<< HEAD
=======
                // _originaltxt = OriginalText.Text.Split(_separators, StringSplitOptions.RemoveEmptyEntries).ToDictionary();
>>>>>>> 56453015507048d3d1cee879304888963969a9cf
                _resultfileList.Clear();

                if (CheckAllCriteria()) // Проверяем текст на наличие слов.
                {
<<<<<<< HEAD
                    FoundWords.BackColor = Color.White;
                    SaveResult.Enabled = true;
                    // Выводим список найденных слов/наименований файлов в окно результата.
                    foreach (string word in _resultList)
                        FoundWords.Text += word + Environment.NewLine;

                    // Выделяем найденные слова определённым цветом.
                    HighlightWordsWithColor(_settingsForm.TextColor.Checked ? GetForeColor() : GetBackColor());
                    MessageBox.Show(@"Поиск слов успешно завершён.", @"Words Search Engine", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    FoundWords.BackColor = Color.FromName("Control");
                    SaveResult.Enabled = false;
                    MessageBox.Show(@"В тексте нет слов, удовлетворяющим критериям поиска.",
                        @"Words Search Engine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
=======
                    FoundWords.Clear();
                    // Выводим список найденных слов/наименований файлов в окно результата.
                    MessageBox.Show(@"Поиск слов закончен", @"Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (string word in _resultList)
                    {
                        FoundWords.Text += word + Environment.NewLine;
                    }
                }
                else
                    MessageBox.Show(@"В тексте нет слов, удовлетворяющим критериям поиска",
                        @"Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
>>>>>>> 56453015507048d3d1cee879304888963969a9cf
            }
            else
            {
                _resultfileList = new List<string>();
                SearchInFiles();

                if (_resultfileList.Count != 0)
                {
<<<<<<< HEAD
                    FoundWords.BackColor = Color.White;
                    SaveResult.Enabled = true;
                    // Выводим список наименований файлов в окно результата.
                    foreach (string word in _resultfileList)
                        FoundWords.Text += word + Environment.NewLine;

                    MessageBox.Show(@"Поиск слов успешно завершён.", @"Words Search Engine", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    FoundWords.BackColor = Color.FromName("Control");
                    SaveResult.Enabled = false;
                    MessageBox.Show(@"В текстах файлов, находящийся в указанном каталоге,"
                                    + @" нет слов, удовлетворяющим критериям поиска",
                        @"Words Search Engine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            SetButtonAccess(true);
            _searchHasJustFinished = true;
=======
                    FoundWords.Clear();
                    MessageBox.Show(@"Поиск слов закончен", @"Результаты поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Выводим список наименований файлов в окно результата.
                    foreach (string word in _resultfileList)
                    {
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
>>>>>>> 56453015507048d3d1cee879304888963969a9cf
        }

        private bool CheckAllCriteria()
        {
<<<<<<< HEAD
            // Проверяем текст на критерии поиска.
            if (CapitalizedLetterCriteria.Checked)
                CapitalizedWords(_resultList);

            if (AbbreviationCriteria.Checked)
                Abbreviation(_resultList);

            if (EnglishWordsCriteria.Checked)
                SearchEnglishWords(_resultList);

            if (LengthCriteria.Checked)
                Length(_resultList, LengthValue.Text);

            if (CombinationCriteria.Checked)
                Combination(_resultList, CombinationValue.Text);

            if (GivenWordCriteria.Checked)
                GivenWord(_resultList, WordValue.Text);
=======
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

            if (WLength.Checked)
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
>>>>>>> 56453015507048d3d1cee879304888963969a9cf

            // Если список найденных слов не пуст, возвращаем true (поиск был успешным).
            return _resultList.Count != 0;
        }

        private void SearchInFiles()
        {
<<<<<<< HEAD
            var files = new List<string>();

            // Поиск в файлах осуществляется только в файлах с расширением ".txt".
            foreach (var file in Directory.GetFiles(SourceDirectory.Text).ToList())
=======
            List<string> files = new List<string>();

            // Поиск в файлах осуществляется только в файлах с расширением ".txt".
            foreach (string file in Directory.GetFiles(SourceDirectory.Text).ToList())
>>>>>>> 56453015507048d3d1cee879304888963969a9cf
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

<<<<<<< HEAD
        private void AppendResultFilesList(string file, List<string> wordList)
=======
        void AppendResultFilesList(string file, List<string> wordList)
>>>>>>> 56453015507048d3d1cee879304888963969a9cf
        {
            _resultfileList.Add(file);

            foreach (string word in wordList)
                _resultfileList.Add(word);

            _resultfileList.Add("");
        }

<<<<<<< HEAD
        #endregion

        #region Выделение найденных слов и выделение текста.

        // Очистка выделения найденных слов текста.
        private void DeselectText(Color selectionColor, Color selectionBackColor)
        {
            var cursorPosition = OriginalText.SelectionStart;
            _searchHasJustFinished = false;
            OriginalText.Select(0, OriginalText.Text.Length);
            OriginalText.SelectionColor = selectionColor;
            OriginalText.SelectionBackColor = selectionBackColor;
            OriginalText.Select(cursorPosition, 0);
        }

        // Получение количества выбранных критериев поиска для определения цвета выделения текста.
        private int GetCheckedCriteriaNumber()
        {
            var number = 0;
            if (CapitalizedLetterCriteria.Checked) number++;
            if (AbbreviationCriteria.Checked) number++;
            if (EnglishWordsCriteria.Checked) number++;
            if (LengthCriteria.Checked) number++;
            if (CombinationCriteria.Checked) number++;
            if (GivenWordCriteria.Checked) number++;
            return number;
        }

        private Color GetForeColor()
        {
            if (GetCheckedCriteriaNumber() > 1) return Color.Gray;
            if (CapitalizedLetterCriteria.Checked) return Color.Red;
            if (AbbreviationCriteria.Checked) return Color.Blue;
            if (EnglishWordsCriteria.Checked) return Color.ForestGreen;
            if (LengthCriteria.Checked) return Color.DarkGoldenrod;
            if (CombinationCriteria.Checked) return Color.Teal;
            return Color.DarkViolet;
        }

        private Color GetBackColor()
        {
            if (GetCheckedCriteriaNumber() > 1) return Color.LightGray;
            if (CapitalizedLetterCriteria.Checked) return Color.LightCoral;
            if (AbbreviationCriteria.Checked) return Color.LightBlue;
            if (EnglishWordsCriteria.Checked) return Color.LightGreen;
            if (LengthCriteria.Checked) return Color.Gold;
            if (CombinationCriteria.Checked) return Color.MediumTurquoise;
            return Color.Violet;
        }

        private bool IsSeparator(char c) => _separators.Any(separator => c == separator);
        
        private void HighlightWordsWithColor(Color color)
        {
            // Если выбраны критерии поиска "Заданное слово" или "Комбинация букв",
            // то сравниваем слова без учёта регистра.
            StringComparison stringComparison = GivenWordCriteria.Checked || CombinationCriteria.Checked
                ? StringComparison.CurrentCultureIgnoreCase
                : StringComparison.Ordinal;

            foreach (string word in _resultList)
            {
                var index = -1;
                do
                {
                    index = OriginalText.Text.IndexOf(word, index + 1, stringComparison);

                    // Проверяем предыдущий символ до найденного вхождения.
                    if (index == 0 || index != 0 && IsSeparator(OriginalText.Text[index - 1]))
                        // Проверяем следующий символ за найденным вхождением.
                        if (index + word.Length == OriginalText.Text.Length ||
                            index + word.Length != OriginalText.Text.Length &&
                            IsSeparator(OriginalText.Text[index + word.Length]))
                        {
                            // Если перед и после слова стоит разделитель
                            // (либо данное слово является первым и последним в тексте),
                            // то выделяем слово с учётом настоек (либо цвет текста, либо цвет фона текста).
                            OriginalText.Select(index, word.Length);

                            if (_settingsForm.TextColor.Checked)
                                OriginalText.SelectionColor = color;
                            else OriginalText.SelectionBackColor = color;
                        }
                } while (OriginalText.Text.IndexOf(word, index + 1, stringComparison) != -1);
            }

            OriginalText.Select(0, 0);
        }

        #endregion

        #region Отслеживание выбора критериев на форме с проверкой их на совместимость.
        
        private void GivenWordCriteria_CheckedChanged(object sender, EventArgs e)
        {
            if (GivenWordCriteria.Checked)
            {
                if (OriginalText.Text != "") Search.Enabled = true;
                // Если выбран критерий "заданное слово", то у остальных критерияев снимаем отметку и ограничиваем доступ.
                ChangeCriteriaAccess("false", "false", "false", "false", "false");
            }
            else
            {
                Search.Enabled = false;
                ChangeCriteriaAccess("true", "true", "true", "true", "true");
            }
        }

        // Проверка на совместимость выбранных критериев.
        private void CheckCriteriaIntegrity(object sender, EventArgs e)
        {
            // Ограничиваем доступ к взаимоисключиющимся критериям.

            // Выбран критерий "Слова с прописной буквы".
            if (CapitalizedLetterCriteria.Checked)
                ChangeCriteriaAccess(abbreviation: "false");
            else if (!CombinationCriteria.Checked)
                ChangeCriteriaAccess(abbreviation: "true");

            // Выбран критерий "Аббревиатуры".
            if (AbbreviationCriteria.Checked)
                ChangeCriteriaAccess("false", combination: "false");
            else ChangeCriteriaAccess("true", combination: "true");

            // Выбран критерий "Комбинация букв".
            if (CombinationCriteria.Checked) ChangeCriteriaAccess(abbreviation: "false");
            else if (!CapitalizedLetterCriteria.Checked)
                ChangeCriteriaAccess(abbreviation: "true");

            // Огриничиваем доступ к критерию "Заданное слово", если выбран хотя бы один какой-то критерий.
            if (CapitalizedLetterCriteria.Checked || AbbreviationCriteria.Checked || EnglishWordsCriteria.Checked
                || LengthCriteria.Checked || CombinationCriteria.Checked)
            {
                if (OriginalText.Text != "") Search.Enabled = true;
                ChangeCriteriaAccess(givenWord: "false");
            }
            else
            {
                ChangeCriteriaAccess(givenWord: "true");
                Search.Enabled = false;
            }
        }

        // Изменяем доступ к взаимоисключающимся критериям.
        // Метод изменяет доступ только тогда, когда он задан, в противном случае - оставляет текущее значение.
        private void ChangeCriteriaAccess(string capitalLetter = "", string abbreviation = "", string englishWords = "",
            string length = "", string combination = "", string givenWord = "")
        {
            try
            {
                if (capitalLetter != "")
                {
                    CapitalizedLetterCriteria.Enabled = Convert.ToBoolean(capitalLetter);
                    if (Convert.ToBoolean(capitalLetter) == false) CapitalizedLetterCriteria.Checked = false;
                }

                if (abbreviation != "")
                {
                    AbbreviationCriteria.Enabled = Convert.ToBoolean(abbreviation);
                    if (Convert.ToBoolean(abbreviation) == false) AbbreviationCriteria.Checked = false;
                }

                if (englishWords != "")
                {
                    EnglishWordsCriteria.Enabled = Convert.ToBoolean(englishWords);
                    if (Convert.ToBoolean(englishWords) == false) EnglishWordsCriteria.Checked = false;
                }

                if (length != "")
                {
                    LengthCriteria.Enabled = Convert.ToBoolean(length);
                    LengthValue.Enabled = Convert.ToBoolean(length);
                    if (Convert.ToBoolean(length) == false) LengthCriteria.Checked = false;
                }

                if (combination != "")
                {
                    CombinationCriteria.Enabled = Convert.ToBoolean(combination);
                    CombinationValue.Enabled = Convert.ToBoolean(combination);
                    if (Convert.ToBoolean(combination) == false) CombinationCriteria.Checked = false;
                }

                if (givenWord != "")
                {
                    GivenWordCriteria.Enabled = Convert.ToBoolean(givenWord);
                    WordValue.Enabled = Convert.ToBoolean(givenWord);
                    if (Convert.ToBoolean(givenWord) == false) GivenWordCriteria.Checked = false;
                }
            }
            catch (FormatException) { }
        }

        #endregion

        #region Загрузка в поле текстов из файлов и сохранение текстов и результатов в файл.

        private void LoadTextFromFile(string path)
        {
            if (path == null) return;
            try
            {
                if (path.EndsWith(".pdf"))
                {
                    // Файл .pdf открываем особенным способом.
                    using (var reader = new PdfReader(path))
                    {
                        var text = new StringBuilder();
                        for (var i = 1; i <= reader.NumberOfPages; i++)
                            text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                        OriginalText.Text = text.ToString();
                    }
                }
                else if (path.EndsWith(".txt"))
                    OriginalText.Text = File.ReadAllText(path, Encoding.GetEncoding(1251));


                UpdateButtonAccess();
                AddRecentText(path);
                UpdateRecentTexts();
                
                var user = Users.CurrentUser != null ? " " + Users.CurrentUser.Login : "";
                if (Users.CurrentUser != null) Log.WriteEvent(DateTime.Now, "Открытие текста", $"Пользователь{user} открыл текст из файла {path}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Произошла ошибка при чтении текста из файла." +
                                Environment.NewLine + Environment.NewLine + @"Дополнительные сведения: " +
                                Environment.NewLine + ex.Message, @"Words Search Engine",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Получение расположения файла перед открытием файла.
        private string GetFilePathBeforeLoading(string target, DataType type)
        {
            bool wrongExtension;
            do
            {
                wrongExtension = false;
                openFileDialog = new OpenFileDialog
                {
                    InitialDirectory = Application.StartupPath + "\\" + (type == DataType.Text ? "Texts" : "Results"),
                    Title = target,
                    Filter = @"txt files(*.txt)|*.txt|pdf files(*.pdf)|*.pdf"
                };
                if (openFileDialog.ShowDialog() != DialogResult.OK) return null;

                if (!openFileDialog.FileName.EndsWith(".pdf") && !openFileDialog.FileName.EndsWith(".txt"))
                {
                    MessageBox.Show(@"Выберите .txt или .pdf файл!", @"Words Search Engine",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    wrongExtension = true;
                }
            } while (wrongExtension);

            return openFileDialog.FileName;
        }

        private string SaveInFile(string directory, DataType type, string fileName, string text)
        {
            var title = type == DataType.Text ? "Сохранение текста" : "Сохранение результата поиска";

            bool wrongExtension;
            // Открываем диалоговое окно выбора расположения файла,
            // пока пользователь не выберет одно из возможных расширений файла.
            do
            {
                wrongExtension = false;
                saveFileDialog = new SaveFileDialog
                {
                    InitialDirectory = directory,
                    FileName = fileName,
                    Title = title,
                    Filter = @"txt files(*.txt)|*.txt|pdf files(*.pdf)|*.pdf"
                };
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return null;

                if (!saveFileDialog.FileName.EndsWith(".pdf") && !saveFileDialog.FileName.EndsWith(".txt"))
                {
                    MessageBox.Show(@"Выберите .txt или .pdf файл!", @"Words Search Engine",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    wrongExtension = true;
                }
            } while (wrongExtension);

            // Выбираем алгоритм записи текста в файл в зависимости от указанного расширения.
            try
            {
                if (saveFileDialog.FileName.EndsWith(".txt"))
                    File.WriteAllText(saveFileDialog.FileName, text, Encoding.GetEncoding(1251));
                else if (saveFileDialog.FileName.EndsWith(".pdf"))
                {

                    var document = new Document();
                    var baseFont = BaseFont.CreateFont(Application.StartupPath + @"\System\ARIAL.TTF",
                        Encoding.GetEncoding(1251).BodyName, BaseFont.NOT_EMBEDDED);
                    var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE,
                        iTextSharp.text.Font.NORMAL);

                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();
                    document.Add(new Paragraph(text, font));
                    document.Close();
                }

                var name = type == DataType.Text ? "текст" : "результат поиска";
                var user = Users.CurrentUser != null ? " " + Users.CurrentUser.Login : "";
                Log.WriteEvent(DateTime.Now, title, $"Пользователь{user} сохранил {name} в файл {saveFileDialog.FileName}.");
                return saveFileDialog.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Произошла ошибка при сохранении текста в файл." +
                                Environment.NewLine + Environment.NewLine + @"Дополнительные сведения: " +
                                Environment.NewLine + ex.Message, @"Words Search Engine",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void SaveTextInFile()
        {
            var length = OriginalText.Text.Length;
            var filepath = SaveInFile(Application.StartupPath + @"\Texts", DataType.Text, TextName.Text != "" ? TextName.Text
                        : OriginalText.Text.Substring(0, length > 30 ? 30 : length), string.Join(Environment.NewLine, OriginalText.Lines));

            if (filepath == null) return;

            AddRecentText(filepath);
            UpdateRecentTexts();
        }

        private string GetTextName()
        {
            if (TextName.Text != "") return TextName.Text;
            MessageBox.Show(@"Введите название текста для сохранения результатов в файл!", @"Words Search Engine",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return null;
        }

        private void SaveResultInFile()
        {
            string fileName;
            string textName = null;
            string criteria = null;

            // В зависимости от установленных настроек определяем название текста,
            // которое будет использоваться в названии файла.
            if (_settingsForm.TextName.Checked)
            { if ((fileName = GetTextName()) == null) return; }
            else fileName = OriginalText.Text.Substring(0, OriginalText.Text.Length > 30 ? 30 : OriginalText.Lines[0].Length);

            // Получаем название текста для указания его в файле результата.
            if (_settingsForm.SpecifyTextName.Checked)
            {
                if ((textName = GetTextName()) == null) return;
                textName = textName.Insert(0, "Название текста: ");
            }

            // Формируем строку, содержащую критерии поиска слов, которую будем указывать в файле результата.
            if (_settingsForm.SpecifyCriteria.Checked)
            {
                var criteriaList = new StringBuilder("Критерии поиска: ", 32);
                if (CapitalizedLetterCriteria.Checked) criteriaList.Append("слова с прописной буквы, ");
                if (AbbreviationCriteria.Checked) criteriaList.Append("аббревиатуры, ");
                if (EnglishWordsCriteria.Checked) criteriaList.Append("английские слова, ");
                if (LengthCriteria.Checked) criteriaList.Append("длина слов: " + LengthValue.Text + ", ");
                if (CombinationCriteria.Checked) criteriaList.Append("комбинация букв: " + CombinationValue.Text + ", ");
                if (GivenWordCriteria.Checked) criteriaList.Append("заданное слово: " + WordValue.Text + ", ");

                criteriaList.Replace(", ", "", criteriaList.Length - 2, 2);
                criteria = criteriaList.ToString();
            }

            var text = new StringBuilder(FoundWords.Text.Length + 30);
            if (textName != null) text.AppendLine(textName);
            if (criteria != null) text.AppendLine(criteria);
            if (text.ToString() != string.Empty) text.AppendLine();
            text.Append(string.Join(Environment.NewLine, FoundWords.Lines));

            var filepath = SaveInFile(_settingsForm.Path.Text, DataType.Result, fileName, text.ToString());
            if (filepath == null) return;

            AddRecentResult(filepath);
            UpdateRecentResults();
        }

        #endregion

        #region Сохранение и загрузка недавних файлов в документ XML.

        // Сохранение расположений недавних файлов.
        public void SaveRecentFiles()
        {
            XmlWriter writer = null;
            try
            {
                var settings = new XmlWriterSettings { Indent = true, ConformanceLevel = ConformanceLevel.Auto};
                writer = XmlWriter.Create(@"System\RecentFiles.xml", settings);

                writer.WriteStartDocument();
                writer.WriteStartElement("RecentFiles");

                // Записываем пути к недавно открытым текстам.
                writer.WriteStartElement("TextFiles");
                for (var i = _recentTexts.Count - 1; i >= 0; i--)
                    writer.WriteElementString("textfile", _recentTexts.ToArray()[i]);

                writer.WriteEndElement();

                // Записываем пути к недавно сохранённым результатам.
                writer.WriteStartElement("ResultFiles");
                for(var i = _recentResults.Count - 1; i >= 0; i--)
                   writer.WriteElementString("resultfile", _recentResults.ToArray()[i]);
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Произошла ошибка при записи расположений недавних файлов." +
                                Environment.NewLine + Environment.NewLine + @"Дополнительные сведения: " +
                                Environment.NewLine + ex.Message, @"Words Search Engine",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                writer?.Close();
            }
        }

        // Загрузка расположений недавних файлов.
        public void SetRecentFiles()
        {
            XmlReader reader = null;
            try
            {
                reader = XmlReader.Create(@"System\RecentFiles.xml");
                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case "textfile":
                            _recentTexts.PushUnique(reader.ReadElementContentAsString());
                            break;
                        case "resultfile":
                            _recentResults.PushUnique(reader.ReadElementContentAsString());
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Возникла ошибка при получении расположений недавних файлов." +
                                Environment.NewLine + Environment.NewLine + @"Дополнительные сведения: " +
                                Environment.NewLine + ex.Message, @"Words Search Engine",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                reader?.Close();
            }
        }

        #endregion

        #region Кнопки меню.

        private void OpenWithFileExistenceCheck(string filepath, DataType type)
        {
            if (File.Exists(filepath))
                LoadTextFromFile(filepath);
            else
            {
                var dialogResilt = MessageBox.Show(@"Невозможно считать данные файла " + filepath +
                                                   @", так как данный файл не найден. Возможно, он был перемещён либо удалён." +
                                                   Environment.NewLine + Environment.NewLine +
                                                   @"Указать новое расположение файла?", @"Words Search Engine",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                // Удаляем путь к данному файлу и обновляем меню
                if (Users.CurrentUser != null)
                    if (type == DataType.Text)
                        Users.CurrentUser.Texts.Remove(filepath);
                    else Users.CurrentUser.Results.Remove(filepath);
                else
                {
                    if (type == DataType.Text)
                        _recentTexts.Remove(filepath);
                    else _recentResults.Remove(filepath);
                }

                if (dialogResilt == DialogResult.Yes)
                    LoadTextFromFile(GetFilePathBeforeLoading("Определение нового пути к файлу", DataType.Text));
            }

            if(type == DataType.Text) UpdateRecentTexts();
            else UpdateRecentResults();
        }

        // Открытие недавнего файла.
        // Запускаем в новом потоке, чтобы не зависало меню и форма в целом при возникновении исключений.
        private void LoadRecentTextsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == @"Очистить список недавних текстов")
            {
                if(Users.CurrentUser != null)
                    Users.CurrentUser.Texts.Clear();
                else _recentTexts.Clear();
                UpdateRecentTexts();
            }
            else
            {
                new Thread(() =>
                {
                    Invoke((MethodInvoker) delegate { OpenWithFileExistenceCheck(e.ClickedItem.Text, DataType.Text); });
                }).Start();
            }
        }

        private void LoadRecentResultsToolStripMenuItem_DropDownItemClicked(object sender,
            ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == @"Очистить список недавних результатов")
            {
                if (Users.CurrentUser != null)
                    Users.CurrentUser.Results.Clear();
                else _recentResults.Clear();
                UpdateRecentResults();
            }
            else
            {
                new Thread(() =>
            {
                Invoke((MethodInvoker) delegate { OpenWithFileExistenceCheck(e.ClickedItem.Text, DataType.Result); });
            }).Start();
        }
    }

        // Загрузка текста из файла.
        private void OpenText_Click(object sender, EventArgs e) => LoadTextFromFile(GetFilePathBeforeLoading("Загрузка текста", DataType.Text));

        private void LoadFromFileToolStripMenuItem_Click(object sender, EventArgs e) => LoadTextFromFile(GetFilePathBeforeLoading("Загрузка текста", DataType.Text));

        // Сохранение текста в файл.
        private void SaveText_Click(object sender, EventArgs e) => SaveTextInFile();

        private void SaveInFileToolStripMenuItem_Click(object sender, EventArgs e) => SaveTextInFile();

        // Сохранение результата поиска в файл.
        private void SaveResult_Click(object sender, EventArgs e) => SaveResultInFile();

        private void SaveInFileResultText_Click(object sender, EventArgs e) => SaveResultInFile();

        // Настройки.
        private void ParamsToolStripMenuItem_Click(object sender, EventArgs e) => _settingsForm.ShowDialog();

        // Справка.
        private void InstructionStripMenuItem_Click(object sender, EventArgs e) => Process.Start(@"HTML\Spravka.htm");

        private void AboutProgrammToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(@"HTML\Spravka.htm");

        // Вход.
        private void SignIn_Click(object sender, EventArgs e)
        {
            if (SignIn.Text == @"Вход")
            {
                new Authorization().ShowDialog();
                if (Users.CurrentUser == null) return;

                SignIn.Text = Users.CurrentUser.Name;
                UpdateRecentTexts();
                UpdateRecentResults();
            }
            else AccountMenu.Show(SignIn, new Point(0, SignIn.Height));
        }

        private void SignUp_MouseEnter(object sender, EventArgs e) { SignIn.ForeColor = Color.White; }

        private void SignUp_MouseLeave(object sender, EventArgs e) { SignIn.ForeColor = Color.Black; }

        private void SignOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.CurrentUser.SaveRecentFiles();
            Log.WriteEvent(DateTime.Now, "Деавторизация", $"Пользователь {Users.CurrentUser.Login} вышел из системы.");
            Users.CurrentUser = null;
            SignIn.Text = @"Вход";
            UpdateRecentTexts();
            UpdateRecentResults();
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AccountSettings().ShowDialog();

            if (Users.CurrentUser != null) SignIn.Text = Users.CurrentUser.Name;
            else
            {
                SignIn.Text = @"Вход";
                UpdateRecentTexts();
                UpdateRecentResults();
            }
        }

        #endregion

        #region События формы, её кнопок и дополнительные методы.

        private void AddRecentText(string filepath)
        {
            // Добавляем название файла в список недавно открытых текстов.
            if (Users.CurrentUser != null)
                Users.CurrentUser.Texts.PushUnique(filepath);
            else _recentTexts.PushUnique(filepath);
        }

        private void AddRecentResult(string filepath)
        {
            // Добавляем название файла в список недавно открытых текстов.
            if (Users.CurrentUser != null)
                Users.CurrentUser.Results.PushUnique(filepath);
            else _recentResults.PushUnique(filepath);
        }

        private void UpdateRecentTexts()
        {
            // Обновляем список недавних текстов в меню.
            LoadRecentTextsToolStripMenuItem.DropDownItems.Clear();

            if (Users.CurrentUser != null)
                foreach (var text in Users.CurrentUser.Texts)
                    LoadRecentTextsToolStripMenuItem.DropDownItems.Add(text);
            else
                foreach (var text in _recentTexts)
                    LoadRecentTextsToolStripMenuItem.DropDownItems.Add(text);

            if (LoadRecentTextsToolStripMenuItem.DropDownItems.Count == 0)
            {
                LoadRecentTextsToolStripMenuItem.Enabled = false;
                return;
            }
            if (!LoadRecentTextsToolStripMenuItem.Enabled) LoadRecentTextsToolStripMenuItem.Enabled = true;
            LoadRecentTextsToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            LoadRecentTextsToolStripMenuItem.DropDownItems.Add("Очистить список недавних текстов");
        }

        private void UpdateRecentResults()
        {
            // Обновляем список недавних результатов в меню.
            LoadRecentResultsToolStripMenuItem.DropDownItems.Clear();

            if (Users.CurrentUser != null)
                foreach (var result in Users.CurrentUser.Results)
                    LoadRecentResultsToolStripMenuItem.DropDownItems.Add(result);
            else
                foreach (var result in _recentResults)
                    LoadRecentResultsToolStripMenuItem.DropDownItems.Add(result);

            if (LoadRecentResultsToolStripMenuItem.DropDownItems.Count == 0)
            {
                LoadRecentResultsToolStripMenuItem.Enabled = false;
                return;
            }

            if(!LoadRecentResultsToolStripMenuItem.Enabled) LoadRecentResultsToolStripMenuItem.Enabled = true;
            LoadRecentResultsToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            LoadRecentResultsToolStripMenuItem.DropDownItems.Add("Очистить список недавних результатов");
        }

        private void SetButtonAccess(bool accessFlag)
        {
            Search.Enabled = accessFlag;
            FileToolStripMenuItem.Enabled = accessFlag;
            ParamsToolStripMenuItem.Enabled = accessFlag;
            HelpToolStripMenuItem.Enabled = accessFlag;
            OpenText.Enabled = accessFlag;
            SaveText.Enabled = accessFlag;
            if (!accessFlag) SaveResult.Enabled = false;
        }

        private void SetSourceAsText(bool textSourceValue)
        {
            // Изменяем доступ к элементам управления в зависимости
            // от источника поиска (заданный текст или тексты в файлах).
            TextName.Enabled = textSourceValue;
            if (textSourceValue) DeselectText(Color.Black, Color.White);
            else DeselectText(Color.Gray, Color.FromName("Control"));
            OriginalText.Select(0, 0);
            OriginalText.Enabled = textSourceValue;
            OpenText.Enabled = textSourceValue;
            if (OriginalText.Text != "") SaveText.Enabled = textSourceValue;
            SourceDirectory.Enabled = !textSourceValue;
            Browse.Enabled = !textSourceValue;
        }

        // Источник поиска слов - заданный в поле текст.
        private void SearchInTextCriteria_CheckedChanged(object sender, EventArgs e) => SetSourceAsText(true);

        // Источник поиска слов - тексты файлов (т.е. не заданный в окне текст).
        private void SearchInFilesCriteria_CheckedChanged(object sender, EventArgs e) => SetSourceAsText(false);
        
        private void Browse_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
                SourceDirectory.Text = FolderBrowserDialog.SelectedPath;
        }

        
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Горячие клавиши для начала поиска Ctrl + B)
            if (e.Control && e.KeyCode == Keys.B)
                Search_Click(sender, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settingsForm.SaveSettingsToFile();
            SaveRecentFiles();
            if (Users.CurrentUser != null)
                Log.WriteEvent(DateTime.Now, "Деавторизация", $"Пользователь {Users.CurrentUser.Login} вышел из системы.");
            Log.WriteEvent(DateTime.Now, "Закрытие приложения", "Приложение закрыто.");
        }

        private void UpdateButtonAccess()
        {
            // Если слова в тексте были выделены (после поиска), то отменяем выделение при нажатии какой-либо клавиши.
            if (_searchHasJustFinished) DeselectText(Color.Black, Color.White);

            // Делаем недоступной кнопку "Сохранить текст", если поле для ввода текста пустое.
            if (OriginalText.Text != "")
            {
                SaveText.Enabled = true;
                // Делаем доступной кнопку "Найти", если выбран хотя бы один критерий.
                Search.Enabled = GetCheckedCriteriaNumber() > 0;
            }
            else
            {
                SaveText.Enabled = false;
                Search.Enabled = false;
            }
        }

        private void OriginalText_KeyUp(object sender, KeyEventArgs e) => UpdateButtonAccess();

        private void LengthValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != '-' && e.KeyChar != 8)
                e.Handled = true;
        }

        #endregion
=======
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
            // Источник поиска слов - заданный в окне текст.
            SetSourceAsText(true);
        }

        private void SearchInFilesCriteria_CheckedChanged(object sender, EventArgs e)
        {
            // Источник поиска слов - тексты файлов (т.е. не заданный в окне текст).
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

        // Проверка на совместимость выбранных критериев.
        private void CheckCriteriaIntegrity()
        {
            if (CapitalizedW.Checked || AbbreviationW.Checked || EnglishWordsCriteria.Checked ||
                WLength.Checked || WCombination.Checked)
            {
                GivenW.Enabled = false;
                WordValue.Enabled = false;
            }
            else
            {
                GivenW.Enabled = true;
                WordValue.Enabled = true;
            }

            if (!GivenW.Checked) return;
            CapitalizedW.Enabled = false;
            AbbreviationW.Enabled = false;
            EnglishWordsCriteria.Enabled = false;
            WLength.Enabled = false;
            LengthValue.Enabled = false;
            WCombination.Enabled = false;
            CombinationValue.Enabled = false;
        }

        // Изменяем доступ к взаимоисключаеющимся критериям.
        // Метод изменяет доступ только тогда, когда он задан, в противном случае - оставляет текущее значение.
        private void ChangeCriteriaAccess(string capitalLetter = "", string abbreviation = "", string englishWords = "",
            string length = "", string combination = "", string givenWord = "")
        {
            if (capitalLetter != "") CapitalizedW.Enabled = Convert.ToBoolean(capitalLetter);
            if (abbreviation != "") AbbreviationW.Enabled = Convert.ToBoolean(abbreviation);
            if (englishWords != "") EnglishWordsCriteria.Enabled = Convert.ToBoolean(englishWords);

            if (length != "")
            {
                WLength.Enabled = Convert.ToBoolean(length);
                LengthValue.Enabled = Convert.ToBoolean(length);
            }

            if (combination != "")
            {
                WCombination.Enabled = Convert.ToBoolean(combination);
                CombinationValue.Enabled = Convert.ToBoolean(combination);
            }

            if (givenWord != "")
            {
                GivenW.Enabled = Convert.ToBoolean(givenWord);
                WordValue.Enabled = Convert.ToBoolean(givenWord);
            }

            CheckCriteriaIntegrity();
        }

        private void CapitalizedW_CheckedChanged(object sender, EventArgs e)
        {
            if (CapitalizedW.Checked)
                ChangeCriteriaAccess(abbreviation: "false", givenWord: "false");
            else ChangeCriteriaAccess(abbreviation: "true", givenWord: "true");
        }


        private void AbbreviationW_CheckedChanged(object sender, EventArgs e)
        {
            if(AbbreviationW.Checked)
                ChangeCriteriaAccess("false", givenWord: "false", combination: "false");
            else ChangeCriteriaAccess("true", givenWord: "true", combination: "true");
        }

        private void EnglishWordsCriteria_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCriteriaAccess(givenWord: EnglishWordsCriteria.Checked ? "false" : "true");
        }

        private void WLength_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCriteriaAccess(givenWord: WLength.Checked ? "false" : "true");
        }

        private void WCombination_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCriteriaAccess(givenWord: WCombination.Checked ? "false" : "true");
        }

        private void GivenW_CheckedChanged(object sender, EventArgs e)
        {
            if (CapitalizedW.Checked)
                ChangeCriteriaAccess("false", "false", "false", "false", "false");
            else ChangeCriteriaAccess("true", "true", "true", "true", "true");
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
            string ResFileName = null;
            string ResFileNameIn = null;
            string ResFileCritStr = null;
            string[] ResFileCrit = new string[6];
            if (_settingsForm.checkBox1.Checked == true)
            {
                if (TextName.Text != "")
                {
                    ResFileName = TextName.Text;
                }
            }

            if (_settingsForm.checkBox4.Checked == true)
            {
                if (TextName.Text != "")
                {
                    ResFileNameIn = "Имя текста: " + TextName.Text;
                }
            }

            if (_settingsForm.checkBox5.Checked == true)
            {
                if (CapitalizedW.Checked == true) { ResFileCrit[0] = "Слова с прописной буквы, "; }
                if (AbbreviationW.Checked == true) { ResFileCrit[1] = "Аббревиатуры, "; }
                if (EnglishWordsCriteria.Checked == true) { ResFileCrit[2] = "Английские слова, "; }
                if (WLength.Checked == true) { ResFileCrit[3] = "Длина слов: " + LengthValue.Text + ", "; }
                if (WCombination.Checked == true) { ResFileCrit[4] = "Комбинация слов: " + CombinationValue.Text + ", "; }
                if (GivenW.Checked == true) { ResFileCrit[5] = "Заданное слово: " + WordValue.Text + ", "; }

                for (int i = 0; i < ResFileCrit.Length; i++)
                {
                    if (ResFileCrit[i] == null)
                    {
                        ResFileCrit[i] = "-, ";
                    }
                }

                ResFileCritStr = "Критерии поиска: " + string.Concat(ResFileCrit);
            }

            Document document = new Document();
            try
            {
                string FileName = @"\Text.pdf";
                if (_settingsForm.checkBox1.Checked == true) { FileName = @"\" + TextName.Text + ".pdf"; }
                string FilePath = _settingsForm.textBox1.Text + FileName;
                BaseFont baseFont = BaseFont.CreateFont(Application.StartupPath + @"\System\ARIAL.TTF", Encoding.GetEncoding(1251).BodyName, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                using (FileStream stream = new FileStream(FilePath, FileMode.Create))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    if (_settingsForm.checkBox4.Checked == true) { document.Add(new Paragraph(ResFileNameIn, font)); }
                    if (_settingsForm.checkBox5.Checked == true) { document.Add(new Paragraph(ResFileCritStr, font)); }
                    document.Add(new Paragraph(FoundWords.Text, font));
                    document.Close();

                    MessageBox.Show("Результирующий файл " + FileName + " сохранен", "Оповещение",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (DocumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
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
            openFileDialog1 = new OpenFileDialog {Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*"};
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
            string ResFileName = null;
            string ResFileNameIn = null;
            string ResFileCritStr = null;
            string[] ResFileCrit = new string[6];
            if (_settingsForm.checkBox1.Checked == true)
            {
                if (TextName.Text != "")
                {
                    ResFileName = TextName.Text;
                }
            }

            if (_settingsForm.checkBox4.Checked == true)
            {
                if (TextName.Text != "")
                {
                    ResFileNameIn = "Имя текста: " + TextName.Text;
                }
            }

            if (_settingsForm.checkBox5.Checked == true)
            {
                if (CapitalizedW.Checked == true) { ResFileCrit[0] = "Слова с прописной буквы, "; }
                if (AbbreviationW.Checked == true) { ResFileCrit[1] = "Аббревиатуры, "; }
                if (EnglishWordsCriteria.Checked == true) { ResFileCrit[2] = "Английские слова, "; }
                if (WLength.Checked == true) { ResFileCrit[3] = "Длина слов: " + LengthValue.Text + ", "; }
                if (WCombination.Checked == true) { ResFileCrit[4] = "Комбинация слов: " + CombinationValue.Text + ", "; }
                if (GivenW.Checked == true) { ResFileCrit[5] = "Заданное слово: " + WordValue.Text + ", "; }

                for (int i = 0; i < ResFileCrit.Length; i++)
                {
                    if (ResFileCrit[i] == null)
                    {
                        ResFileCrit[i] = "-, ";
                    }
                }

                ResFileCritStr = "Критерии поиска: " + string.Concat(ResFileCrit);
            }

            Document document = new Document();
            try
            {
                string FileName = @"\Text.pdf";
                if (_settingsForm.checkBox1.Checked == true) { FileName = @"\" + TextName.Text + ".pdf"; }
                string FilePath = _settingsForm.textBox1.Text + FileName;
                BaseFont baseFont = BaseFont.CreateFont(Application.StartupPath + @"\System\ARIAL.TTF", Encoding.GetEncoding(1251).BodyName, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                using (FileStream stream = new FileStream(FilePath, FileMode.Create))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    if (_settingsForm.checkBox4.Checked == true) { document.Add(new Paragraph(ResFileNameIn, font)); }
                    if (_settingsForm.checkBox5.Checked == true) { document.Add(new Paragraph(ResFileCritStr, font)); }
                    document.Add(new Paragraph(FoundWords.Text, font));
                    document.Close();

                    MessageBox.Show("Результирующий файл " + FileName + " сохранен", "Оповещение",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (DocumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
>>>>>>> 56453015507048d3d1cee879304888963969a9cf
    }
}