using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Image = System.Drawing.Image;

namespace WordsSearchEngine
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            MainMenu.Renderer = new MenuStripRenderer();
            AccountMenu.Renderer = new MenuStripRenderer();

            _recentTexts = new AdvancedStack();
            _recentResults = new AdvancedStack();

            SetRecentFiles(); // Загружаем недавно открытые файлы.
            UpdateRecentTexts();
            UpdateRecentResults();

            SetSourceAsText(true); // По умолчанию установлен поиск слов в заданном тексте.
            _separators = new[]
                {' ', '\n', '\r', ',', '.', '(', ')', '!', '?', '-', ';', ':', '"', '«', '»', '%', '\\', '/'};
            _resultList = new List<string>();
            _resultfileList = new List<string>();

            _settingsForm = new SettingsForm();

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
                e.Graphics.DrawLine(new Pen(SystemColors.ControlDark), 0, e.Item.Height / 2, e.Item.Width,
                    e.Item.Height / 2);
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
            if (GetCheckedCriteriaNumber() == 0)
            {
                MessageBox.Show(@"Выберите хотя бы один критерий поиска слов!", @"Words Search Engine",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

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

            if (GivenWordCriteria.Checked && WordValue.Text != "")
            {
                MessageBox.Show(@"Введите слово для поиска.", @"Words Search Engine", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (SearchInFilesCriteria.Checked)
            {
                if (Directory.Exists(SourceDirectory.Text))
                    return true;
                    MessageBox.Show(@"Укажите правильный каталог для поиска слов в файлах.",
                        @"Words Search Engine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
            }
            if(OriginalText.Text == "") MessageBox.Show(@"Введите текст для поиска слов.",
                @"Words Search Engine", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (!IsReadyToSearch()) return;

            SetButtonAccess(false);
            DeselectText(Color.Black, Color.White);
            FoundWords.Clear();

            if (SearchInTextCriteria.Checked)
            {
                // Получаем список всех слов исходного текста.
                _resultList = OriginalText.Text.Split(_separators, StringSplitOptions.RemoveEmptyEntries).ToList();
                _resultfileList.Clear();

                if (CheckAllCriteria()) // Проверяем текст на наличие слов.
                {
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
            }
            else
            {
                _resultfileList = new List<string>();
                SearchInFiles();

                if (_resultfileList.Count != 0)
                {
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
        }

        private bool CheckAllCriteria()
        {
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

            // Если список найденных слов не пуст, возвращаем true (поиск был успешным).
            return _resultList.Count != 0;
        }

        private void SearchInFiles()
        {
            var files = new List<string>();

            // Поиск в файлах осуществляется только в файлах с расширением ".txt".
            foreach (var file in Directory.GetFiles(SourceDirectory.Text).ToList())
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

        private void AppendResultFilesList(string file, List<string> wordList)
        {
            _resultfileList.Add(file);

            foreach (string word in wordList)
                _resultfileList.Add(word);

            _resultfileList.Add("");
        }

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
                // Если выбран критерий "заданное слово", то у остальных критерияев снимаем отметку и ограничиваем доступ.
                ChangeCriteriaAccess("false", "false", "false", "false", "false");
            else ChangeCriteriaAccess("true", "true", "true", "true", "true");
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
                ChangeCriteriaAccess(givenWord: "false");
            else ChangeCriteriaAccess(givenWord: "true");
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
            catch (FormatException)
            {
            }
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
                if (Users.CurrentUser != null)
                    Log.WriteEvent(DateTime.Now, "Открытие текста",
                        $"Пользователь{user} открыл текст из файла {path}.");
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
                Log.WriteEvent(DateTime.Now, title,
                    $"Пользователь{user} сохранил {name} в файл {saveFileDialog.FileName}.");
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
            var filepath = SaveInFile(Application.StartupPath + @"\Texts", DataType.Text, TextName.Text != ""
                    ? TextName.Text
                    : OriginalText.Text.Substring(0, length > 30 ? 30 : length),
                string.Join(Environment.NewLine, OriginalText.Lines));

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
            if (SearchInFilesCriteria.Checked) fileName = SourceDirectory.Text;
            else
            {
                if (_settingsForm.TextName.Checked)
                {
                    if ((fileName = GetTextName()) == null) return;
                }
                else
                    fileName = OriginalText.Text.Substring(0,
                        OriginalText.Text.Length > 30 ? 30 : OriginalText.Lines[0].Length);

                // Получаем название текста для указания его в файле результата.
                if (_settingsForm.SpecifyTextName.Checked)
                {
                    if ((textName = GetTextName()) == null) return;
                    textName = textName.Insert(0, "Название текста: ");
                }
            }

            // Формируем строку, содержащую критерии поиска слов, которую будем указывать в файле результата.
            if (_settingsForm.SpecifyCriteria.Checked)
            {
                var criteriaList = new StringBuilder("Критерии поиска: ", 32);
                if (CapitalizedLetterCriteria.Checked) criteriaList.Append("слова с прописной буквы, ");
                if (AbbreviationCriteria.Checked) criteriaList.Append("аббревиатуры, ");
                if (EnglishWordsCriteria.Checked) criteriaList.Append("английские слова, ");
                if (LengthCriteria.Checked) criteriaList.Append("длина слов: " + LengthValue.Text + ", ");
                if (CombinationCriteria.Checked)
                    criteriaList.Append("комбинация букв: " + CombinationValue.Text + ", ");
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
                var settings = new XmlWriterSettings {Indent = true, ConformanceLevel = ConformanceLevel.Auto};
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
                for (var i = _recentResults.Count - 1; i >= 0; i--)
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
                    else
                        Users.CurrentUser.Results.Remove(filepath);
                else
                {
                    if (type == DataType.Text)
                        _recentTexts.Remove(filepath);
                    else _recentResults.Remove(filepath);
                }

                if (dialogResilt == DialogResult.Yes)
                    LoadTextFromFile(GetFilePathBeforeLoading("Определение нового пути к файлу", DataType.Text));
            }

            if (type == DataType.Text) UpdateRecentTexts();
            else UpdateRecentResults();
        }

        // Открытие недавнего файла.
        // Запускаем в новом потоке, чтобы не зависало меню и форма в целом при возникновении исключений.
        private void LoadRecentTextsToolStripMenuItem_DropDownItemClicked(object sender,
            ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == @"Очистить список недавних текстов")
            {
                if (Users.CurrentUser != null)
                    Users.CurrentUser.Texts.Clear();
                else _recentTexts.Clear();
                UpdateRecentTexts();
            }
            else
            {
                new Thread(() =>
                {
                    Invoke((MethodInvoker) delegate
                    {
                        OpenWithFileExistenceCheck(e.ClickedItem.Text, DataType.Text);
                    });
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
                    Invoke((MethodInvoker) delegate
                    {
                        OpenWithFileExistenceCheck(e.ClickedItem.Text, DataType.Result);
                    });
                }).Start();
            }
        }

        // Загрузка текста из файла.
        private void OpenText_Click(object sender, EventArgs e) =>
            LoadTextFromFile(GetFilePathBeforeLoading("Загрузка текста", DataType.Text));

        private void LoadFromFileToolStripMenuItem_Click(object sender, EventArgs e) =>
            LoadTextFromFile(GetFilePathBeforeLoading("Загрузка текста", DataType.Text));

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

        private void AboutProgrammToolStripMenuItem_Click(object sender, EventArgs e) =>
            Process.Start(@"HTML\Spravka.htm");

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

        private void ChangeSignInButtonStyle(Color foreColor, Color backColor)
        {
            SignIn.ForeColor = foreColor;
            SignIn.BackColor = backColor;
        }

        private void SignIn_MouseEnter(object sender, EventArgs e)
        { ChangeSignInButtonStyle(Color.White, SystemColors.ControlDarkDark); }

        private void SignIn_MouseLeave(object sender, EventArgs e)
        { ChangeSignInButtonStyle(Color.Black, Color.Gainsboro); }

        private void AccountMenu_Opening(object sender, CancelEventArgs e)
        { ChangeSignInButtonStyle(Color.White, SystemColors.ControlDarkDark); }

        private void AccountMenu_MouseMove(object sender, MouseEventArgs e)
        { ChangeSignInButtonStyle(Color.White, SystemColors.ControlDarkDark); }

        private void AccountMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        { ChangeSignInButtonStyle(Color.Black, Color.Gainsboro); }

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

            if (!LoadRecentResultsToolStripMenuItem.Enabled) LoadRecentResultsToolStripMenuItem.Enabled = true;
            LoadRecentResultsToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            LoadRecentResultsToolStripMenuItem.DropDownItems.Add("Очистить список недавних результатов");
        }

        private void SetButtonAccess(bool accessFlag)
        {
            Search.Enabled = accessFlag;
            FileToolStripMenuItem.Enabled = accessFlag;
            ParamsToolStripMenuItem.Enabled = accessFlag;
            HelpToolStripMenuItem.Enabled = accessFlag;
            if (accessFlag)
            {
                if (SearchInTextCriteria.Checked)
                {
                    OpenText.Enabled = true;
                    SaveText.Enabled = true;
                }
            }
            else
            {
                OpenText.Enabled = false;
                SaveText.Enabled = false;
            }
           
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
            SourceDirectory.Enabled = !textSourceValue;
            Browse.Enabled = !textSourceValue;
            UpdateButtonAccess();
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
                Log.WriteEvent(DateTime.Now, "Деавторизация",
                    $"Пользователь {Users.CurrentUser.Login} вышел из системы.");
            Log.WriteEvent(DateTime.Now, "Закрытие приложения", "Приложение закрыто.");
        }

        private void UpdateButtonAccess()
        {
            // Если слова в тексте были выделены (после поиска), то отменяем выделение при нажатии какой-либо клавиши.
            if (_searchHasJustFinished) DeselectText(Color.Black, Color.White);

            if (SearchInTextCriteria.Checked)
            {
                // Делаем недоступной кнопку "Сохранить текст", если поле для ввода текста пустое.
                SaveText.Enabled = OriginalText.Text != "";
            }
            else SaveText.Enabled = false;
        }

        private void OriginalText_KeyUp(object sender, KeyEventArgs e) => UpdateButtonAccess();

        private void LengthValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != '-' && e.KeyChar != 8)
                e.Handled = true;
        }


        // Метод установки заднего фона кнопки.
        private static void SetButtonImage(Button button, string name)
        {
            if(button == null) return;
            if (File.Exists(@"Images\" + name)) button.BackgroundImage = Image.FromFile(@"Images\" + name);
        }

        // Сменяем задний фон кнопки, когда она становится недоступной.
        private void SaveText_EnabledChanged(object sender, EventArgs e) => SetButtonImage(SaveText,
            SaveText.Enabled ? "save.png" : "save_not_enabled.png");
        private void SaveResult_EnabledChanged(object sender, EventArgs e) => SetButtonImage(SaveResult,
            SaveText.Enabled ? "save.png" : "save_not_enabled.png");
        private void OpenText_EnabledChanged(object sender, EventArgs e) => SetButtonImage(OpenText,
            OpenText.Enabled ? "load.png" : "load_not_enabled.png");

        // Сменяем задний фон кнопки при наведении.
        private void SaveText_MouseEnter(object sender, EventArgs e) => SetButtonImage(SaveText, "save_hover.png");
        private void SaveResult_MouseEnter(object sender, EventArgs e) => SetButtonImage(SaveResult, "save_hover.png");
        private void OpenText_MouseEnter(object sender, EventArgs e) => SetButtonImage(OpenText, "load_hover.png");

        // Сменяем задний фон кнопки при выходе указателя мыши за пределы элемента управления.
        private void SaveText_MouseLeave(object sender, EventArgs e) => SetButtonImage(SaveText, "save.png");
        private void SaveResult_MouseLeave(object sender, EventArgs e) => SetButtonImage(SaveResult, "save.png");
        private void OpenText_MouseLeave(object sender, EventArgs e) => SetButtonImage(OpenText, "load.png");

        #endregion
    }

}