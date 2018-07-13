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
<<<<<<< HEAD:WordsSearchEngine/Form1.Designer.cs
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.FoundWords = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveInFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveInFileResultText = new System.Windows.Forms.ToolStripMenuItem();
            this.ParamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InstructionStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProgrammToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
=======
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OriginalText = new System.Windows.Forms.RichTextBox();
            this.FoundWords = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьИзФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.описаниеПрогграммыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SignUp = new System.Windows.Forms.Button();
>>>>>>> authorization:WordsSearchEngine/MainForm.Designer.cs
            this.SaveText = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WordValue = new System.Windows.Forms.TextBox();
            this.GivenW = new System.Windows.Forms.CheckBox();
            this.CombinationValue = new System.Windows.Forms.TextBox();
            this.WCombination = new System.Windows.Forms.CheckBox();
            this.LengthValue = new System.Windows.Forms.TextBox();
            this.WLength = new System.Windows.Forms.CheckBox();
            this.EnglishWordsCriteria = new System.Windows.Forms.CheckBox();
            this.AbbreviationW = new System.Windows.Forms.CheckBox();
            this.CapitalizedW = new System.Windows.Forms.CheckBox();
            this.Search = new System.Windows.Forms.Button();
            this.SourceDirectory = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.SaveResult = new System.Windows.Forms.Button();
            this.OpenText = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.OriginalText = new System.Windows.Forms.RichTextBox();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SearchInFilesCriteria = new System.Windows.Forms.RadioButton();
            this.DirectoryText = new System.Windows.Forms.Label();
            this.SearchInTextCriteria = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextName = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FoundWords
            // 
            this.FoundWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FoundWords.Location = new System.Drawing.Point(486, 63);
            this.FoundWords.Name = "FoundWords";
            this.FoundWords.ReadOnly = true;
            this.FoundWords.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.FoundWords.Size = new System.Drawing.Size(179, 313);
            this.FoundWords.TabIndex = 1;
            this.FoundWords.Text = "";
            this.toolTip1.SetToolTip(this.FoundWords, "Результирующее поле");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ParamsToolStripMenuItem,
            this.HelpToolStripMenuItem,
            this.ExitToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(863, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadFromFileToolStripMenuItem,
            this.SaveInFileToolStripMenuItem,
            this.SaveInFileResultText});
            this.FileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // LoadFromFileToolStripMenuItem
            // 
            this.LoadFromFileToolStripMenuItem.Name = "LoadFromFileToolStripMenuItem";
            this.LoadFromFileToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.LoadFromFileToolStripMenuItem.Text = "Загрузить из файла текст";
            this.LoadFromFileToolStripMenuItem.Click += new System.EventHandler(this.LoadFromFileToolStripMenuItem_Click);
            // 
            // SaveInFileToolStripMenuItem
            // 
            this.SaveInFileToolStripMenuItem.Name = "SaveInFileToolStripMenuItem";
            this.SaveInFileToolStripMenuItem.Size = new System.Drawing.Size(291, 22);
            this.SaveInFileToolStripMenuItem.Text = "Сохранить в файл текст";
            this.SaveInFileToolStripMenuItem.Click += new System.EventHandler(this.SaveInFileToolStripMenuItem_Click_1);
            // 
            // SaveInFileResultText
            // 
            this.SaveInFileResultText.Name = "SaveInFileResultText";
            this.SaveInFileResultText.Size = new System.Drawing.Size(291, 22);
            this.SaveInFileResultText.Text = "Сохранить в файл результат поиска";
            this.SaveInFileResultText.Click += new System.EventHandler(this.SaveInFileResultText_Click);
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
            this.ProgrammToolStripMenuItem});
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
            // ProgrammToolStripMenuItem
            // 
            this.ProgrammToolStripMenuItem.Name = "ProgrammToolStripMenuItem";
            this.ProgrammToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ProgrammToolStripMenuItem.Text = "О программе";
            this.ProgrammToolStripMenuItem.Click += new System.EventHandler(this.ProgrammToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem1
            // 
            this.ExitToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1";
            this.ExitToolStripMenuItem1.Size = new System.Drawing.Size(57, 21);
            this.ExitToolStripMenuItem1.Text = "Выход";
            this.ExitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem1_Click);
            // 
            // SignUp
            // 
<<<<<<< HEAD:WordsSearchEngine/Form1.Designer.cs
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(702, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Вход";
            this.toolTip1.SetToolTip(this.button1, "Вход или Регистрация");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
=======
            this.SignUp.BackColor = System.Drawing.Color.Gainsboro;
            this.SignUp.FlatAppearance.BorderSize = 0;
            this.SignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignUp.Location = new System.Drawing.Point(725, 0);
            this.SignUp.Name = "SignUp";
            this.SignUp.Size = new System.Drawing.Size(138, 23);
            this.SignUp.TabIndex = 3;
            this.SignUp.Text = "Вход";
            this.SignUp.UseVisualStyleBackColor = false;
            this.SignUp.Click += new System.EventHandler(this.SignUp_Click);
>>>>>>> authorization:WordsSearchEngine/MainForm.Designer.cs
            // 
            // SaveText
            // 
            this.SaveText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveText.BackgroundImage")));
            this.SaveText.FlatAppearance.BorderSize = 0;
            this.SaveText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveText.Location = new System.Drawing.Point(451, 33);
            this.SaveText.Name = "SaveText";
            this.SaveText.Size = new System.Drawing.Size(29, 29);
            this.SaveText.TabIndex = 4;
            this.toolTip1.SetToolTip(this.SaveText, "Сохранить в файл");
            this.SaveText.UseVisualStyleBackColor = true;
            this.SaveText.Click += new System.EventHandler(this.SaveText_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WordValue);
            this.groupBox1.Controls.Add(this.GivenW);
            this.groupBox1.Controls.Add(this.CombinationValue);
            this.groupBox1.Controls.Add(this.WCombination);
            this.groupBox1.Controls.Add(this.LengthValue);
            this.groupBox1.Controls.Add(this.WLength);
            this.groupBox1.Controls.Add(this.EnglishWordsCriteria);
            this.groupBox1.Controls.Add(this.AbbreviationW);
            this.groupBox1.Controls.Add(this.CapitalizedW);
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
            this.WordValue.Size = new System.Drawing.Size(104, 22);
            this.WordValue.TabIndex = 18;
            this.toolTip1.SetToolTip(this.WordValue, "Поле для слова, по которому будет осуществляться поиск");
            // 
            // GivenW
            // 
            this.GivenW.AutoSize = true;
            this.GivenW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GivenW.Location = new System.Drawing.Point(6, 222);
            this.GivenW.Name = "GivenW";
            this.GivenW.Size = new System.Drawing.Size(123, 19);
            this.GivenW.TabIndex = 17;
            this.GivenW.Text = "Заданное слово:";
            this.GivenW.UseVisualStyleBackColor = true;
            this.GivenW.CheckedChanged += new System.EventHandler(this.GivenW_CheckedChanged);
            // 
            // CombinationValue
            // 
            this.CombinationValue.Location = new System.Drawing.Point(23, 192);
            this.CombinationValue.Name = "CombinationValue";
            this.CombinationValue.Size = new System.Drawing.Size(104, 22);
            this.CombinationValue.TabIndex = 16;
            this.toolTip1.SetToolTip(this.CombinationValue, "Поле для указания комбинации букв");
            // 
            // WCombination
            // 
            this.WCombination.AutoSize = true;
            this.WCombination.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WCombination.Location = new System.Drawing.Point(7, 167);
            this.WCombination.Name = "WCombination";
            this.WCombination.Size = new System.Drawing.Size(130, 19);
            this.WCombination.TabIndex = 15;
            this.WCombination.Text = "Комбинация букв:";
            this.WCombination.UseVisualStyleBackColor = true;
            this.WCombination.CheckedChanged += new System.EventHandler(this.WCombination_CheckedChanged);
            // 
            // LengthValue
            // 
            this.LengthValue.Location = new System.Drawing.Point(23, 134);
            this.LengthValue.Name = "LengthValue";
            this.LengthValue.Size = new System.Drawing.Size(104, 22);
            this.LengthValue.TabIndex = 13;
            this.toolTip1.SetToolTip(this.LengthValue, "Поле для указания длины слова");
            // 
            // WLength
            // 
            this.WLength.AutoSize = true;
            this.WLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WLength.Location = new System.Drawing.Point(6, 109);
            this.WLength.Name = "WLength";
            this.WLength.Size = new System.Drawing.Size(103, 19);
            this.WLength.TabIndex = 11;
            this.WLength.Text = "Длина слова:";
            this.WLength.UseVisualStyleBackColor = true;
            this.WLength.CheckedChanged += new System.EventHandler(this.WLength_CheckedChanged);
            // 
            // EnglishWordsCriteria
            // 
            this.EnglishWordsCriteria.AutoSize = true;
            this.EnglishWordsCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnglishWordsCriteria.Location = new System.Drawing.Point(6, 82);
            this.EnglishWordsCriteria.Name = "EnglishWordsCriteria";
            this.EnglishWordsCriteria.Size = new System.Drawing.Size(129, 19);
            this.EnglishWordsCriteria.TabIndex = 10;
            this.EnglishWordsCriteria.Text = "Английские слова";
            this.EnglishWordsCriteria.UseVisualStyleBackColor = true;
            this.EnglishWordsCriteria.CheckedChanged += new System.EventHandler(this.EnglishWordsCriteria_CheckedChanged);
            // 
            // AbbreviationW
            // 
            this.AbbreviationW.AutoSize = true;
            this.AbbreviationW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AbbreviationW.Location = new System.Drawing.Point(6, 55);
            this.AbbreviationW.Name = "AbbreviationW";
            this.AbbreviationW.Size = new System.Drawing.Size(110, 19);
            this.AbbreviationW.TabIndex = 9;
            this.AbbreviationW.Text = "Аббревиатуры";
            this.AbbreviationW.UseVisualStyleBackColor = true;
            this.AbbreviationW.CheckedChanged += new System.EventHandler(this.AbbreviationW_CheckedChanged);
            // 
            // CapitalizedW
            // 
            this.CapitalizedW.AutoSize = true;
            this.CapitalizedW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CapitalizedW.Location = new System.Drawing.Point(6, 27);
            this.CapitalizedW.Name = "CapitalizedW";
            this.CapitalizedW.Size = new System.Drawing.Size(173, 19);
            this.CapitalizedW.TabIndex = 8;
            this.CapitalizedW.Text = "Слова с прописной буквы";
            this.CapitalizedW.UseVisualStyleBackColor = true;
            this.CapitalizedW.CheckedChanged += new System.EventHandler(this.CapitalizedW_CheckedChanged);
            // 
            // Search
            // 
            this.Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Search.Location = new System.Drawing.Point(671, 346);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(180, 26);
            this.Search.TabIndex = 7;
            this.Search.Text = "Найти";
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
            this.SaveResult.FlatAppearance.BorderSize = 0;
            this.SaveResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveResult.Location = new System.Drawing.Point(615, 66);
            this.SaveResult.Name = "SaveResult";
            this.SaveResult.Size = new System.Drawing.Size(29, 29);
            this.SaveResult.TabIndex = 22;
            this.toolTip1.SetToolTip(this.SaveResult, "Сохранить в файл");
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
            this.OpenText.TabIndex = 23;
            this.toolTip1.SetToolTip(this.OpenText, "Загрузить из файла");
            this.OpenText.UseVisualStyleBackColor = true;
            this.OpenText.Click += new System.EventHandler(this.OpenText_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // OriginalText
            // 
            this.OriginalText.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OriginalText.Location = new System.Drawing.Point(14, 63);
            this.OriginalText.Name = "OriginalText";
            this.OriginalText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.OriginalText.Size = new System.Drawing.Size(468, 261);
            this.OriginalText.TabIndex = 0;
            this.OriginalText.Text = "";
            this.toolTip1.SetToolTip(this.OriginalText, "Поле исходного текста");
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.Description = "Определение каталога для поиска слов в файлах";
            this.FolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.FolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(486, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Результаты поиска:";
            // 
<<<<<<< HEAD:WordsSearchEngine/Form1.Designer.cs
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(152, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Имя текста:";
            // 
            // TextName
            // 
            this.TextName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextName.Location = new System.Drawing.Point(242, 33);
            this.TextName.Name = "TextName";
            this.TextName.Size = new System.Drawing.Size(150, 22);
            this.TextName.TabIndex = 29;
            // 
            // Form1
=======
            // MainForm
>>>>>>> authorization:WordsSearchEngine/MainForm.Designer.cs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 388);
            this.Controls.Add(this.TextName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchInTextCriteria);
            this.Controls.Add(this.DirectoryText);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.SourceDirectory);
            this.Controls.Add(this.SearchInFilesCriteria);
            this.Controls.Add(this.OpenText);
            this.Controls.Add(this.SaveResult);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SaveText);
            this.Controls.Add(this.SignUp);
            this.Controls.Add(this.FoundWords);
            this.Controls.Add(this.OriginalText);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Search);
            this.MainMenuStrip = this.menuStrip1;
<<<<<<< HEAD:WordsSearchEngine/Form1.Designer.cs
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "     ";
=======
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Words Search Engine";
            this.Load += new System.EventHandler(this.MainForm_Load);
>>>>>>> authorization:WordsSearchEngine/MainForm.Designer.cs
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox FoundWords;
        private System.Windows.Forms.MenuStrip menuStrip1;
<<<<<<< HEAD:WordsSearchEngine/Form1.Designer.cs
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ParamsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.Button button1;
=======
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
>>>>>>> authorization:WordsSearchEngine/MainForm.Designer.cs
        private System.Windows.Forms.Button SaveText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox WLength;
        private System.Windows.Forms.CheckBox EnglishWordsCriteria;
        private System.Windows.Forms.CheckBox AbbreviationW;
        private System.Windows.Forms.CheckBox CapitalizedW;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.TextBox WordValue;
        private System.Windows.Forms.CheckBox GivenW;
        private System.Windows.Forms.TextBox CombinationValue;
        private System.Windows.Forms.CheckBox WCombination;
        private System.Windows.Forms.TextBox LengthValue;
        private System.Windows.Forms.TextBox SourceDirectory;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.ToolStripMenuItem InstructionStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveInFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProgrammToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button SaveResult;
        private System.Windows.Forms.Button OpenText;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton SearchInFilesCriteria;
        private System.Windows.Forms.Label DirectoryText;
        private System.Windows.Forms.RadioButton SearchInTextCriteria;
        private System.Windows.Forms.Label label1;
<<<<<<< HEAD:WordsSearchEngine/Form1.Designer.cs
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextName;
        private System.Windows.Forms.ToolStripMenuItem SaveInFileResultText;
        private System.Windows.Forms.RichTextBox OriginalText;
=======
        public System.Windows.Forms.Button SignUp;
>>>>>>> authorization:WordsSearchEngine/MainForm.Designer.cs
    }
}

