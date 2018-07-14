using System.Windows.Forms;

namespace WordsSearchEngine
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FoundWords = new System.Windows.Forms.RichTextBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveInFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveInFileResultText = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadRecentTextsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadRecentResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ParamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InstructionStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutProgrammToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveText = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WordValue = new System.Windows.Forms.TextBox();
            this.GivenWordCriteria = new System.Windows.Forms.CheckBox();
            this.CombinationValue = new System.Windows.Forms.TextBox();
            this.CombinationCriteria = new System.Windows.Forms.CheckBox();
            this.LengthValue = new System.Windows.Forms.TextBox();
            this.LengthCriteria = new System.Windows.Forms.CheckBox();
            this.EnglishWordsCriteria = new System.Windows.Forms.CheckBox();
            this.AbbreviationCriteria = new System.Windows.Forms.CheckBox();
            this.CapitalizedLetterCriteria = new System.Windows.Forms.CheckBox();
            this.Search = new System.Windows.Forms.Button();
            this.SignIn = new System.Windows.Forms.Button();
            this.SourceDirectory = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.SaveResult = new System.Windows.Forms.Button();
            this.OpenText = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.OriginalText = new System.Windows.Forms.RichTextBox();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SearchInFilesCriteria = new System.Windows.Forms.RadioButton();
            this.DirectoryText = new System.Windows.Forms.Label();
            this.SearchInTextCriteria = new System.Windows.Forms.RadioButton();
            this.SearchResults = new System.Windows.Forms.Label();
            this.TTextName = new System.Windows.Forms.Label();
            this.TextName = new System.Windows.Forms.TextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SignOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccountMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MainMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.AccountMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // FoundWords
            // 
            this.FoundWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FoundWords.Location = new System.Drawing.Point(467, 63);
            this.FoundWords.Name = "FoundWords";
            this.FoundWords.ReadOnly = true;
            this.FoundWords.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.FoundWords.Size = new System.Drawing.Size(175, 313);
            this.FoundWords.TabIndex = 1;
            this.FoundWords.Text = "";
            this.toolTip.SetToolTip(this.FoundWords, "Результирующее поле");
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ParamsToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(863, 25);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "MainMenu";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadFromFileToolStripMenuItem,
            this.SaveInFileToolStripMenuItem,
            this.SaveInFileResultText,
            this.toolStripSeparator2,
            this.LoadRecentTextsToolStripMenuItem,
            this.LoadRecentResultsToolStripMenuItem});
            this.FileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // LoadFromFileToolStripMenuItem
            // 
            this.LoadFromFileToolStripMenuItem.Name = "LoadFromFileToolStripMenuItem";
            this.LoadFromFileToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.LoadFromFileToolStripMenuItem.Text = "Загрузить из файла текст";
            this.LoadFromFileToolStripMenuItem.Click += new System.EventHandler(this.LoadFromFileToolStripMenuItem_Click);
            // 
            // SaveInFileToolStripMenuItem
            // 
            this.SaveInFileToolStripMenuItem.Name = "SaveInFileToolStripMenuItem";
            this.SaveInFileToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.SaveInFileToolStripMenuItem.Text = "Сохранить в файл текст";
            this.SaveInFileToolStripMenuItem.Click += new System.EventHandler(this.SaveInFileToolStripMenuItem_Click);
            // 
            // SaveInFileResultText
            // 
            this.SaveInFileResultText.Name = "SaveInFileResultText";
            this.SaveInFileResultText.Size = new System.Drawing.Size(302, 22);
            this.SaveInFileResultText.Text = "Сохранить в файл результат поиска";
            this.SaveInFileResultText.Click += new System.EventHandler(this.SaveInFileResultText_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(299, 6);
            // 
            // LoadRecentTextsToolStripMenuItem
            // 
            this.LoadRecentTextsToolStripMenuItem.Name = "LoadRecentTextsToolStripMenuItem";
            this.LoadRecentTextsToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.LoadRecentTextsToolStripMenuItem.Text = "Открыть недавние тексты";
            this.LoadRecentTextsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.LoadRecentTextsToolStripMenuItem_DropDownItemClicked);
            // 
            // LoadRecentResultsToolStripMenuItem
            // 
            this.LoadRecentResultsToolStripMenuItem.Name = "LoadRecentResultsToolStripMenuItem";
            this.LoadRecentResultsToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.LoadRecentResultsToolStripMenuItem.Text = "Открыть недавние результаты поиска";
            this.LoadRecentResultsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.LoadRecentResultsToolStripMenuItem_DropDownItemClicked);
            // 
            // ParamsToolStripMenuItem
            // 
            this.ParamsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParamsToolStripMenuItem.Name = "ParamsToolStripMenuItem";
            this.ParamsToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
            this.ParamsToolStripMenuItem.Text = "Настройки";
            this.ParamsToolStripMenuItem.Click += new System.EventHandler(this.ParamsToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InstructionStripMenuItem,
            this.AboutProgrammToolStripMenuItem});
            this.HelpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(70, 21);
            this.HelpToolStripMenuItem.Text = "Справка";
            // 
            // InstructionStripMenuItem
            // 
            this.InstructionStripMenuItem.Name = "InstructionStripMenuItem";
            this.InstructionStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.InstructionStripMenuItem.Text = "Инструкция";
            this.InstructionStripMenuItem.Click += new System.EventHandler(this.InstructionStripMenuItem_Click);
            // 
            // AboutProgrammToolStripMenuItem
            // 
            this.AboutProgrammToolStripMenuItem.Name = "AboutProgrammToolStripMenuItem";
            this.AboutProgrammToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.AboutProgrammToolStripMenuItem.Text = "О программе";
            this.AboutProgrammToolStripMenuItem.Click += new System.EventHandler(this.AboutProgrammToolStripMenuItem_Click);
            // 
            // SaveText
            // 
            this.SaveText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveText.BackgroundImage")));
            this.SaveText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveText.Enabled = false;
            this.SaveText.FlatAppearance.BorderSize = 0;
            this.SaveText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveText.Location = new System.Drawing.Point(432, 33);
            this.SaveText.Name = "SaveText";
            this.SaveText.Size = new System.Drawing.Size(29, 29);
            this.SaveText.TabIndex = 4;
            this.toolTip.SetToolTip(this.SaveText, "Сохранить в файл");
            this.SaveText.UseVisualStyleBackColor = true;
            this.SaveText.EnabledChanged += new System.EventHandler(this.SaveText_EnabledChanged);
            this.SaveText.Click += new System.EventHandler(this.SaveText_Click);
            this.SaveText.MouseEnter += new System.EventHandler(this.SaveText_MouseEnter);
            this.SaveText.MouseLeave += new System.EventHandler(this.SaveText_MouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WordValue);
            this.groupBox1.Controls.Add(this.GivenWordCriteria);
            this.groupBox1.Controls.Add(this.CombinationValue);
            this.groupBox1.Controls.Add(this.CombinationCriteria);
            this.groupBox1.Controls.Add(this.LengthValue);
            this.groupBox1.Controls.Add(this.LengthCriteria);
            this.groupBox1.Controls.Add(this.EnglishWordsCriteria);
            this.groupBox1.Controls.Add(this.AbbreviationCriteria);
            this.groupBox1.Controls.Add(this.CapitalizedLetterCriteria);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(648, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 295);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Критерии поиска";
            // 
            // WordValue
            // 
            this.WordValue.Location = new System.Drawing.Point(23, 258);
            this.WordValue.Name = "WordValue";
            this.WordValue.Size = new System.Drawing.Size(164, 22);
            this.WordValue.TabIndex = 18;
            this.toolTip.SetToolTip(this.WordValue, "Поле для слова, по которому будет осуществляться поиск");
            // 
            // GivenWordCriteria
            // 
            this.GivenWordCriteria.AutoSize = true;
            this.GivenWordCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GivenWordCriteria.Location = new System.Drawing.Point(6, 233);
            this.GivenWordCriteria.Name = "GivenWordCriteria";
            this.GivenWordCriteria.Size = new System.Drawing.Size(137, 20);
            this.GivenWordCriteria.TabIndex = 17;
            this.GivenWordCriteria.Text = "Заданное слово:";
            this.GivenWordCriteria.UseVisualStyleBackColor = true;
            this.GivenWordCriteria.CheckedChanged += new System.EventHandler(this.GivenWordCriteria_CheckedChanged);
            // 
            // CombinationValue
            // 
            this.CombinationValue.Location = new System.Drawing.Point(23, 199);
            this.CombinationValue.Name = "CombinationValue";
            this.CombinationValue.Size = new System.Drawing.Size(164, 22);
            this.CombinationValue.TabIndex = 16;
            this.toolTip.SetToolTip(this.CombinationValue, "Поле для указания комбинации букв");
            // 
            // CombinationCriteria
            // 
            this.CombinationCriteria.AutoSize = true;
            this.CombinationCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CombinationCriteria.Location = new System.Drawing.Point(7, 174);
            this.CombinationCriteria.Name = "CombinationCriteria";
            this.CombinationCriteria.Size = new System.Drawing.Size(144, 20);
            this.CombinationCriteria.TabIndex = 15;
            this.CombinationCriteria.Text = "Комбинация букв:";
            this.CombinationCriteria.UseVisualStyleBackColor = true;
            this.CombinationCriteria.CheckedChanged += new System.EventHandler(this.CheckCriteriaIntegrity);
            // 
            // LengthValue
            // 
            this.LengthValue.Location = new System.Drawing.Point(23, 142);
            this.LengthValue.Name = "LengthValue";
            this.LengthValue.Size = new System.Drawing.Size(164, 22);
            this.LengthValue.TabIndex = 13;
            this.toolTip.SetToolTip(this.LengthValue, "Поле для указания длины слова");
            this.LengthValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LengthValue_KeyPress);
            // 
            // LengthCriteria
            // 
            this.LengthCriteria.AutoSize = true;
            this.LengthCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LengthCriteria.Location = new System.Drawing.Point(6, 116);
            this.LengthCriteria.Name = "LengthCriteria";
            this.LengthCriteria.Size = new System.Drawing.Size(113, 20);
            this.LengthCriteria.TabIndex = 11;
            this.LengthCriteria.Text = "Длина слова:";
            this.LengthCriteria.UseVisualStyleBackColor = true;
            this.LengthCriteria.CheckedChanged += new System.EventHandler(this.CheckCriteriaIntegrity);
            // 
            // EnglishWordsCriteria
            // 
            this.EnglishWordsCriteria.AutoSize = true;
            this.EnglishWordsCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnglishWordsCriteria.Location = new System.Drawing.Point(6, 88);
            this.EnglishWordsCriteria.Name = "EnglishWordsCriteria";
            this.EnglishWordsCriteria.Size = new System.Drawing.Size(146, 20);
            this.EnglishWordsCriteria.TabIndex = 10;
            this.EnglishWordsCriteria.Text = "Английские слова";
            this.EnglishWordsCriteria.UseVisualStyleBackColor = true;
            this.EnglishWordsCriteria.CheckedChanged += new System.EventHandler(this.CheckCriteriaIntegrity);
            // 
            // AbbreviationCriteria
            // 
            this.AbbreviationCriteria.AutoSize = true;
            this.AbbreviationCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AbbreviationCriteria.Location = new System.Drawing.Point(6, 60);
            this.AbbreviationCriteria.Name = "AbbreviationCriteria";
            this.AbbreviationCriteria.Size = new System.Drawing.Size(124, 20);
            this.AbbreviationCriteria.TabIndex = 9;
            this.AbbreviationCriteria.Text = "Аббревиатуры";
            this.AbbreviationCriteria.UseVisualStyleBackColor = true;
            this.AbbreviationCriteria.CheckedChanged += new System.EventHandler(this.CheckCriteriaIntegrity);
            // 
            // CapitalizedLetterCriteria
            // 
            this.CapitalizedLetterCriteria.AutoSize = true;
            this.CapitalizedLetterCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CapitalizedLetterCriteria.Location = new System.Drawing.Point(6, 32);
            this.CapitalizedLetterCriteria.Name = "CapitalizedLetterCriteria";
            this.CapitalizedLetterCriteria.Size = new System.Drawing.Size(195, 20);
            this.CapitalizedLetterCriteria.TabIndex = 8;
            this.CapitalizedLetterCriteria.Text = "Слова с прописной буквы";
            this.CapitalizedLetterCriteria.UseVisualStyleBackColor = true;
            this.CapitalizedLetterCriteria.CheckedChanged += new System.EventHandler(this.CheckCriteriaIntegrity);
            // 
            // Search
            // 
            this.Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Search.Location = new System.Drawing.Point(648, 346);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(203, 30);
            this.Search.TabIndex = 7;
            this.Search.Text = "Найти";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // SignIn
            // 
            this.SignIn.BackColor = System.Drawing.Color.Gainsboro;
            this.SignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SignIn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SignIn.FlatAppearance.BorderSize = 0;
            this.SignIn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SignIn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignIn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SignIn.Location = new System.Drawing.Point(613, 0);
            this.SignIn.Name = "SignIn";
            this.SignIn.Size = new System.Drawing.Size(250, 25);
            this.SignIn.TabIndex = 3;
            this.SignIn.Text = "Вход";
            this.SignIn.UseVisualStyleBackColor = false;
            this.SignIn.Click += new System.EventHandler(this.SignIn_Click);
            this.SignIn.MouseEnter += new System.EventHandler(this.SignIn_MouseEnter);
            this.SignIn.MouseLeave += new System.EventHandler(this.SignIn_MouseLeave);
            // 
            // SourceDirectory
            // 
            this.SourceDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SourceDirectory.Location = new System.Drawing.Point(154, 354);
            this.SourceDirectory.Name = "SourceDirectory";
            this.SourceDirectory.Size = new System.Drawing.Size(219, 22);
            this.SourceDirectory.TabIndex = 22;
            // 
            // Browse
            // 
            this.Browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Browse.Location = new System.Drawing.Point(379, 353);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(82, 23);
            this.Browse.TabIndex = 20;
            this.Browse.Text = "Обзор...";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // SaveResult
            // 
            this.SaveResult.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveResult.BackgroundImage")));
            this.SaveResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveResult.Enabled = false;
            this.SaveResult.FlatAppearance.BorderSize = 0;
            this.SaveResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveResult.Location = new System.Drawing.Point(613, 33);
            this.SaveResult.Name = "SaveResult";
            this.SaveResult.Size = new System.Drawing.Size(29, 29);
            this.SaveResult.TabIndex = 22;
            this.toolTip.SetToolTip(this.SaveResult, "Сохранить в файл");
            this.SaveResult.UseVisualStyleBackColor = true;
            this.SaveResult.EnabledChanged += new System.EventHandler(this.SaveResult_EnabledChanged);
            this.SaveResult.Click += new System.EventHandler(this.SaveResult_Click);
            this.SaveResult.MouseEnter += new System.EventHandler(this.SaveResult_MouseEnter);
            this.SaveResult.MouseLeave += new System.EventHandler(this.SaveResult_MouseLeave);
            // 
            // OpenText
            // 
            this.OpenText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenText.BackgroundImage")));
            this.OpenText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenText.FlatAppearance.BorderSize = 0;
            this.OpenText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenText.Location = new System.Drawing.Point(399, 34);
            this.OpenText.Name = "OpenText";
            this.OpenText.Size = new System.Drawing.Size(27, 27);
            this.OpenText.TabIndex = 23;
            this.toolTip.SetToolTip(this.OpenText, "Загрузить из файла");
            this.OpenText.UseVisualStyleBackColor = true;
            this.OpenText.EnabledChanged += new System.EventHandler(this.OpenText_EnabledChanged);
            this.OpenText.Click += new System.EventHandler(this.OpenText_Click);
            this.OpenText.MouseEnter += new System.EventHandler(this.OpenText_MouseEnter);
            this.OpenText.MouseLeave += new System.EventHandler(this.OpenText_MouseLeave);
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // OriginalText
            // 
            this.OriginalText.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OriginalText.Location = new System.Drawing.Point(14, 63);
            this.OriginalText.Name = "OriginalText";
            this.OriginalText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.OriginalText.Size = new System.Drawing.Size(447, 261);
            this.OriginalText.TabIndex = 0;
            this.OriginalText.Text = "";
            this.toolTip.SetToolTip(this.OriginalText, "Поле исходного текста");
            this.OriginalText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OriginalText_KeyUp);
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.Description = "Определение каталога для поиска слов в файлах";
            this.FolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.FolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "saveFileDialog";
            // 
            // SearchInFilesCriteria
            // 
            this.SearchInFilesCriteria.AutoSize = true;
            this.SearchInFilesCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchInFilesCriteria.Location = new System.Drawing.Point(12, 330);
            this.SearchInFilesCriteria.Name = "SearchInFilesCriteria";
            this.SearchInFilesCriteria.Size = new System.Drawing.Size(129, 20);
            this.SearchInFilesCriteria.TabIndex = 24;
            this.SearchInFilesCriteria.Text = "Поиск в файлах";
            this.SearchInFilesCriteria.UseVisualStyleBackColor = true;
            this.SearchInFilesCriteria.CheckedChanged += new System.EventHandler(this.SearchInFilesCriteria_CheckedChanged);
            // 
            // DirectoryText
            // 
            this.DirectoryText.AutoSize = true;
            this.DirectoryText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DirectoryText.Location = new System.Drawing.Point(12, 356);
            this.DirectoryText.Name = "DirectoryText";
            this.DirectoryText.Size = new System.Drawing.Size(139, 16);
            this.DirectoryText.TabIndex = 25;
            this.DirectoryText.Text = "Каталог для поиска:";
            // 
            // SearchInTextCriteria
            // 
            this.SearchInTextCriteria.AutoSize = true;
            this.SearchInTextCriteria.Checked = true;
            this.SearchInTextCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchInTextCriteria.Location = new System.Drawing.Point(12, 33);
            this.SearchInTextCriteria.Name = "SearchInTextCriteria";
            this.SearchInTextCriteria.Size = new System.Drawing.Size(124, 20);
            this.SearchInTextCriteria.TabIndex = 26;
            this.SearchInTextCriteria.TabStop = true;
            this.SearchInTextCriteria.Text = "Поиск в тексте";
            this.SearchInTextCriteria.UseVisualStyleBackColor = true;
            this.SearchInTextCriteria.CheckedChanged += new System.EventHandler(this.SearchInTextCriteria_CheckedChanged);
            // 
            // SearchResults
            // 
            this.SearchResults.AutoSize = true;
            this.SearchResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchResults.Location = new System.Drawing.Point(467, 40);
            this.SearchResults.Name = "SearchResults";
            this.SearchResults.Size = new System.Drawing.Size(139, 16);
            this.SearchResults.TabIndex = 27;
            this.SearchResults.Text = "Результаты поиска:";
            // 
            // TTextName
            // 
            this.TTextName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TTextName.Location = new System.Drawing.Point(157, 35);
            this.TTextName.Name = "TTextName";
            this.TTextName.Size = new System.Drawing.Size(82, 21);
            this.TTextName.TabIndex = 30;
            this.TTextName.Text = "Название:";
            // 
            // TextName
            // 
            this.TextName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextName.Location = new System.Drawing.Point(242, 32);
            this.TextName.Name = "TextName";
            this.TextName.Size = new System.Drawing.Size(150, 22);
            this.TextName.TabIndex = 29;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(246, 6);
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.OptionsToolStripMenuItem.Text = "Параметры учётной записи...";
            this.OptionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // SignOutToolStripMenuItem
            // 
            this.SignOutToolStripMenuItem.Name = "SignOutToolStripMenuItem";
            this.SignOutToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.SignOutToolStripMenuItem.Text = "Выйти";
            this.SignOutToolStripMenuItem.Click += new System.EventHandler(this.SignOutToolStripMenuItem_Click);
            // 
            // AccountMenu
            // 
            this.AccountMenu.AutoSize = false;
            this.AccountMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.OptionsToolStripMenuItem,
            this.SignOutToolStripMenuItem});
            this.AccountMenu.Name = "AccountMenu";
            this.AccountMenu.Size = new System.Drawing.Size(250, 54);
            this.AccountMenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.AccountMenu_Closing);
            this.AccountMenu.Opening += new System.ComponentModel.CancelEventHandler(this.AccountMenu_Opening);
            this.AccountMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AccountMenu_MouseMove);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 388);
            this.Controls.Add(this.TextName);
            this.Controls.Add(this.TTextName);
            this.Controls.Add(this.SearchResults);
            this.Controls.Add(this.SearchInTextCriteria);
            this.Controls.Add(this.DirectoryText);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.SourceDirectory);
            this.Controls.Add(this.SearchInFilesCriteria);
            this.Controls.Add(this.OpenText);
            this.Controls.Add(this.SaveResult);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SaveText);
            this.Controls.Add(this.SignIn);
            this.Controls.Add(this.FoundWords);
            this.Controls.Add(this.OriginalText);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.Search);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Words Search Engine";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.AccountMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox FoundWords;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ParamsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.Button SaveText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox LengthCriteria;
        private System.Windows.Forms.CheckBox EnglishWordsCriteria;
        private System.Windows.Forms.CheckBox AbbreviationCriteria;
        private System.Windows.Forms.CheckBox CapitalizedLetterCriteria;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button SignIn;
        private System.Windows.Forms.TextBox WordValue;
        private System.Windows.Forms.CheckBox GivenWordCriteria;
        private System.Windows.Forms.TextBox CombinationValue;
        private System.Windows.Forms.CheckBox CombinationCriteria;
        private System.Windows.Forms.TextBox LengthValue;
        private System.Windows.Forms.TextBox SourceDirectory;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.ToolStripMenuItem InstructionStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveInFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadRecentTextsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadRecentResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutProgrammToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button SaveResult;
        private System.Windows.Forms.Button OpenText;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.RadioButton SearchInFilesCriteria;
        private System.Windows.Forms.Label DirectoryText;
        private System.Windows.Forms.RadioButton SearchInTextCriteria;
        private System.Windows.Forms.Label SearchResults;
        private System.Windows.Forms.Label TTextName;
        private System.Windows.Forms.TextBox TextName;
        private System.Windows.Forms.ToolStripMenuItem SaveInFileResultText;
        private System.Windows.Forms.RichTextBox OriginalText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SignOutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip AccountMenu;
        private ToolStripSeparator toolStripSeparator2;
    }
}

