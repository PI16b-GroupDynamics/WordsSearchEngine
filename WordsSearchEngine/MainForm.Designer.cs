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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
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
            this.SourceDirectory = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.SaveResult = new System.Windows.Forms.Button();
            this.OpenText = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.OriginalText = new System.Windows.Forms.RichTextBox();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SearchInFilesCriteria = new System.Windows.Forms.RadioButton();
            this.DirectoryText = new System.Windows.Forms.Label();
            this.SearchInTextCriteria = new System.Windows.Forms.RadioButton();
            this.TSearchResults = new System.Windows.Forms.Label();
            this.TTextName = new System.Windows.Forms.Label();
            this.TextName = new System.Windows.Forms.TextBox();
            this.AccountMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SignOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SignIn = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.MainMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.AccountMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // FoundWords
            // 
            this.FoundWords.BackColor = System.Drawing.SystemColors.Control;
            this.FoundWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FoundWords.Location = new System.Drawing.Point(486, 63);
            this.FoundWords.Name = "FoundWords";
            this.FoundWords.ReadOnly = true;
            this.FoundWords.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.FoundWords.Size = new System.Drawing.Size(179, 313);
            this.FoundWords.TabIndex = 17;
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
            this.MainMenu.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadFromFileToolStripMenuItem,
            this.SaveInFileToolStripMenuItem,
            this.SaveInFileResultText,
            this.toolStripMenuItem1,
            this.LoadRecentTextsToolStripMenuItem,
            this.LoadRecentResultsToolStripMenuItem});
            this.FileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.ShowShortcutKeys = false;
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // LoadFromFileToolStripMenuItem
            // 
            this.LoadFromFileToolStripMenuItem.Name = "LoadFromFileToolStripMenuItem";
            this.LoadFromFileToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.LoadFromFileToolStripMenuItem.Text = "Загрузить текст из файла";
            this.LoadFromFileToolStripMenuItem.Click += new System.EventHandler(this.LoadFromFileToolStripMenuItem_Click);
            // 
            // SaveInFileToolStripMenuItem
            // 
            this.SaveInFileToolStripMenuItem.Name = "SaveInFileToolStripMenuItem";
            this.SaveInFileToolStripMenuItem.ShowShortcutKeys = false;
            this.SaveInFileToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.SaveInFileToolStripMenuItem.Text = "Сохранить текст в файл";
            this.SaveInFileToolStripMenuItem.Click += new System.EventHandler(this.SaveInFileToolStripMenuItem_Click);
            // 
            // SaveInFileResultText
            // 
            this.SaveInFileResultText.Name = "SaveInFileResultText";
            this.SaveInFileResultText.Size = new System.Drawing.Size(309, 22);
            this.SaveInFileResultText.Text = "Сохранить результат поиска в файл";
            this.SaveInFileResultText.Click += new System.EventHandler(this.SaveInFileResultText_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(306, 6);
            // 
            // LoadRecentTextsToolStripMenuItem
            // 
            this.LoadRecentTextsToolStripMenuItem.Name = "LoadRecentTextsToolStripMenuItem";
            this.LoadRecentTextsToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.LoadRecentTextsToolStripMenuItem.Text = "Загрузить последние тексты";
            this.LoadRecentTextsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.LoadRecentTextsToolStripMenuItem_DropDownItemClicked);
            // 
            // LoadRecentResultsToolStripMenuItem
            // 
            this.LoadRecentResultsToolStripMenuItem.Name = "LoadRecentResultsToolStripMenuItem";
            this.LoadRecentResultsToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.LoadRecentResultsToolStripMenuItem.Text = "Открыть последние результаты поиска";
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
            this.SaveText.Enabled = false;
            this.SaveText.FlatAppearance.BorderSize = 0;
            this.SaveText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveText.Location = new System.Drawing.Point(451, 33);
            this.SaveText.Name = "SaveText";
            this.SaveText.Size = new System.Drawing.Size(29, 29);
            this.SaveText.TabIndex = 19;
            this.toolTip.SetToolTip(this.SaveText, "Сохранить в файл");
            this.SaveText.UseVisualStyleBackColor = true;
            this.SaveText.Click += new System.EventHandler(this.SaveText_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(671, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 277);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Критерии поиска";
            // 
            // WordValue
            // 
            this.WordValue.Location = new System.Drawing.Point(23, 247);
            this.WordValue.Name = "WordValue";
            this.WordValue.Size = new System.Drawing.Size(139, 22);
            this.WordValue.TabIndex = 15;
            this.toolTip.SetToolTip(this.WordValue, "Поле для слова, по которому будет осуществляться поиск");
            // 
            // GivenWordCriteria
            // 
            this.GivenWordCriteria.AutoSize = true;
            this.GivenWordCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GivenWordCriteria.Location = new System.Drawing.Point(6, 222);
            this.GivenWordCriteria.Name = "GivenWordCriteria";
            this.GivenWordCriteria.Size = new System.Drawing.Size(123, 19);
            this.GivenWordCriteria.TabIndex = 14;
            this.GivenWordCriteria.Text = "Заданное слово:";
            this.GivenWordCriteria.UseVisualStyleBackColor = true;
            this.GivenWordCriteria.CheckedChanged += new System.EventHandler(this.GivenWordCriteria_CheckedChanged);
            // 
            // CombinationValue
            // 
            this.CombinationValue.Location = new System.Drawing.Point(23, 192);
            this.CombinationValue.Name = "CombinationValue";
            this.CombinationValue.Size = new System.Drawing.Size(139, 22);
            this.CombinationValue.TabIndex = 13;
            this.toolTip.SetToolTip(this.CombinationValue, "Поле для указания комбинации букв");
            // 
            // CombinationCriteria
            // 
            this.CombinationCriteria.AutoSize = true;
            this.CombinationCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CombinationCriteria.Location = new System.Drawing.Point(7, 167);
            this.CombinationCriteria.Name = "CombinationCriteria";
            this.CombinationCriteria.Size = new System.Drawing.Size(130, 19);
            this.CombinationCriteria.TabIndex = 12;
            this.CombinationCriteria.Text = "Комбинация букв:";
            this.CombinationCriteria.UseVisualStyleBackColor = true;
            this.CombinationCriteria.CheckedChanged += new System.EventHandler(this.CheckCriteriaIntegrity);
            // 
            // LengthValue
            // 
            this.LengthValue.Location = new System.Drawing.Point(23, 134);
            this.LengthValue.Name = "LengthValue";
            this.LengthValue.Size = new System.Drawing.Size(139, 22);
            this.LengthValue.TabIndex = 11;
            this.toolTip.SetToolTip(this.LengthValue, "Поле для указания длины слова");
            this.LengthValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LengthValue_KeyPress);
            // 
            // LengthCriteria
            // 
            this.LengthCriteria.AutoSize = true;
            this.LengthCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LengthCriteria.Location = new System.Drawing.Point(6, 109);
            this.LengthCriteria.Name = "LengthCriteria";
            this.LengthCriteria.Size = new System.Drawing.Size(103, 19);
            this.LengthCriteria.TabIndex = 10;
            this.LengthCriteria.Text = "Длина слова:";
            this.LengthCriteria.UseVisualStyleBackColor = true;
            this.LengthCriteria.CheckedChanged += new System.EventHandler(this.CheckCriteriaIntegrity);
            // 
            // EnglishWordsCriteria
            // 
            this.EnglishWordsCriteria.AutoSize = true;
            this.EnglishWordsCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnglishWordsCriteria.Location = new System.Drawing.Point(6, 82);
            this.EnglishWordsCriteria.Name = "EnglishWordsCriteria";
            this.EnglishWordsCriteria.Size = new System.Drawing.Size(129, 19);
            this.EnglishWordsCriteria.TabIndex = 9;
            this.EnglishWordsCriteria.Text = "Английские слова";
            this.EnglishWordsCriteria.UseVisualStyleBackColor = true;
            this.EnglishWordsCriteria.CheckedChanged += new System.EventHandler(this.CheckCriteriaIntegrity);
            // 
            // AbbreviationCriteria
            // 
            this.AbbreviationCriteria.AutoSize = true;
            this.AbbreviationCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AbbreviationCriteria.Location = new System.Drawing.Point(6, 55);
            this.AbbreviationCriteria.Name = "AbbreviationCriteria";
            this.AbbreviationCriteria.Size = new System.Drawing.Size(110, 19);
            this.AbbreviationCriteria.TabIndex = 8;
            this.AbbreviationCriteria.Text = "Аббревиатуры";
            this.AbbreviationCriteria.UseVisualStyleBackColor = true;
            this.AbbreviationCriteria.CheckedChanged += new System.EventHandler(this.CheckCriteriaIntegrity);
            // 
            // CapitalizedLetterCriteria
            // 
            this.CapitalizedLetterCriteria.AutoSize = true;
            this.CapitalizedLetterCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CapitalizedLetterCriteria.Location = new System.Drawing.Point(6, 27);
            this.CapitalizedLetterCriteria.Name = "CapitalizedLetterCriteria";
            this.CapitalizedLetterCriteria.Size = new System.Drawing.Size(173, 19);
            this.CapitalizedLetterCriteria.TabIndex = 7;
            this.CapitalizedLetterCriteria.Text = "Слова с прописной буквы";
            this.CapitalizedLetterCriteria.UseVisualStyleBackColor = true;
            this.CapitalizedLetterCriteria.CheckedChanged += new System.EventHandler(this.CheckCriteriaIntegrity);
            // 
            // Search
            // 
            this.Search.Enabled = false;
            this.Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Search.Location = new System.Drawing.Point(671, 346);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(180, 26);
            this.Search.TabIndex = 16;
            this.Search.Text = "Найти";
            this.toolTip.SetToolTip(this.Search, "Найти (Ctrl + B)");
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // SourceDirectory
            // 
            this.SourceDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SourceDirectory.Location = new System.Drawing.Point(154, 354);
            this.SourceDirectory.Name = "SourceDirectory";
            this.SourceDirectory.Size = new System.Drawing.Size(238, 22);
            this.SourceDirectory.TabIndex = 22;
            // 
            // Browse
            // 
            this.Browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Browse.Location = new System.Drawing.Point(398, 353);
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
            this.SaveResult.Enabled = false;
            this.SaveResult.FlatAppearance.BorderSize = 0;
            this.SaveResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveResult.Location = new System.Drawing.Point(636, 33);
            this.SaveResult.Name = "SaveResult";
            this.SaveResult.Size = new System.Drawing.Size(29, 29);
            this.SaveResult.TabIndex = 18;
            this.toolTip.SetToolTip(this.SaveResult, "Сохранить в файл");
            this.SaveResult.UseVisualStyleBackColor = true;
            this.SaveResult.Click += new System.EventHandler(this.SaveResult_Click);
            // 
            // OpenText
            // 
            this.OpenText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenText.BackgroundImage")));
            this.OpenText.FlatAppearance.BorderSize = 0;
            this.OpenText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenText.Location = new System.Drawing.Point(416, 33);
            this.OpenText.Name = "OpenText";
            this.OpenText.Size = new System.Drawing.Size(29, 29);
            this.OpenText.TabIndex = 1;
            this.toolTip.SetToolTip(this.OpenText, "Загрузить из файла");
            this.OpenText.UseVisualStyleBackColor = true;
            this.OpenText.Click += new System.EventHandler(this.OpenText_Click);
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
            this.OriginalText.ShowSelectionMargin = true;
            this.OriginalText.Size = new System.Drawing.Size(468, 261);
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
            this.openFileDialog.FileName = "openFileDialog1";
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
            // TSearchResults
            // 
            this.TSearchResults.AutoSize = true;
            this.TSearchResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TSearchResults.Location = new System.Drawing.Point(486, 45);
            this.TSearchResults.Name = "TSearchResults";
            this.TSearchResults.Size = new System.Drawing.Size(139, 16);
            this.TSearchResults.TabIndex = 27;
            this.TSearchResults.Text = "Результаты поиска:";
            // 
            // TTextName
            // 
            this.TTextName.AutoSize = true;
            this.TTextName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TTextName.Location = new System.Drawing.Point(159, 39);
            this.TTextName.Name = "TTextName";
            this.TTextName.Size = new System.Drawing.Size(77, 16);
            this.TTextName.TabIndex = 28;
            this.TTextName.Text = "Название:";
            // 
            // TextName
            // 
            this.TextName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextName.Location = new System.Drawing.Point(242, 36);
            this.TextName.Name = "TextName";
            this.TextName.Size = new System.Drawing.Size(150, 22);
            this.TextName.TabIndex = 29;
            // 
            // AccountMenu
            // 
            this.AccountMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.OptionsToolStripMenuItem,
            this.SignOutToolStripMenuItem});
            this.AccountMenu.Name = "contextMenuStrip1";
            this.AccountMenu.Size = new System.Drawing.Size(228, 76);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(224, 6);
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.OptionsToolStripMenuItem.Text = "Параметры учётной записи";
            this.OptionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // SignOutToolStripMenuItem
            // 
            this.SignOutToolStripMenuItem.Name = "SignOutToolStripMenuItem";
            this.SignOutToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.SignOutToolStripMenuItem.Text = "Выйти";
            this.SignOutToolStripMenuItem.Click += new System.EventHandler(this.SignOutToolStripMenuItem_Click);
            // 
            // SignIn
            // 
            this.SignIn.BackColor = System.Drawing.Color.Gainsboro;
            this.SignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SignIn.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.SignIn.FlatAppearance.BorderSize = 0;
            this.SignIn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SignIn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignIn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SignIn.Location = new System.Drawing.Point(636, 0);
            this.SignIn.Name = "SignIn";
            this.SignIn.Size = new System.Drawing.Size(227, 25);
            this.SignIn.TabIndex = 34;
            this.SignIn.Text = "Вход";
            this.SignIn.UseVisualStyleBackColor = false;
            this.SignIn.Click += new System.EventHandler(this.SignIn_Click);
            this.SignIn.MouseEnter += new System.EventHandler(this.SignUp_MouseEnter);
            this.SignIn.MouseLeave += new System.EventHandler(this.SignUp_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 388);
            this.Controls.Add(this.SignIn);
            this.Controls.Add(this.TextName);
            this.Controls.Add(this.TTextName);
            this.Controls.Add(this.TSearchResults);
            this.Controls.Add(this.SearchInTextCriteria);
            this.Controls.Add(this.DirectoryText);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.SourceDirectory);
            this.Controls.Add(this.SearchInFilesCriteria);
            this.Controls.Add(this.OpenText);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SaveText);
            this.Controls.Add(this.FoundWords);
            this.Controls.Add(this.OriginalText);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.SaveResult);
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
        private System.Windows.Forms.ToolStripMenuItem AboutProgrammToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button SaveResult;
        private System.Windows.Forms.Button OpenText;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.RadioButton SearchInFilesCriteria;
        private System.Windows.Forms.Label DirectoryText;
        private System.Windows.Forms.RadioButton SearchInTextCriteria;
        private System.Windows.Forms.Label TSearchResults;
        private System.Windows.Forms.Label TTextName;
        private System.Windows.Forms.TextBox TextName;
        private System.Windows.Forms.ToolStripMenuItem SaveInFileResultText;
        private System.Windows.Forms.RichTextBox OriginalText;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem LoadRecentTextsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadRecentResultsToolStripMenuItem;
        private System.Windows.Forms.Button SignIn;
        private System.Windows.Forms.ContextMenuStrip AccountMenu;
        private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SignOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

