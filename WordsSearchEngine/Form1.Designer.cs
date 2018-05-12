namespace WordsSearchEngine
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.button1 = new System.Windows.Forms.Button();
            this.SaveText = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WordValue = new System.Windows.Forms.TextBox();
            this.GivenW = new System.Windows.Forms.CheckBox();
            this.CombinationValue = new System.Windows.Forms.TextBox();
            this.WCombination = new System.Windows.Forms.CheckBox();
            this.LengthValue = new System.Windows.Forms.TextBox();
            this.WLenght = new System.Windows.Forms.CheckBox();
            this.EnglishWordsCriteria = new System.Windows.Forms.CheckBox();
            this.AbbreviationW = new System.Windows.Forms.CheckBox();
            this.CapitalizedW = new System.Windows.Forms.CheckBox();
            this.Search = new System.Windows.Forms.Button();
            this.SourceDirectory = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.SaveResult = new System.Windows.Forms.Button();
            this.OpenText = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SearchInFilesCriteria = new System.Windows.Forms.RadioButton();
            this.DirectoryText = new System.Windows.Forms.Label();
            this.SearchInTextCriteria = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OriginalText
            // 
            this.OriginalText.Location = new System.Drawing.Point(30, 69);
            this.OriginalText.Name = "OriginalText";
            this.OriginalText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.OriginalText.Size = new System.Drawing.Size(450, 255);
            this.OriginalText.TabIndex = 0;
            this.OriginalText.Text = "";
            // 
            // FoundWords
            // 
            this.FoundWords.Location = new System.Drawing.Point(486, 69);
            this.FoundWords.Name = "FoundWords";
            this.FoundWords.ReadOnly = true;
            this.FoundWords.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.FoundWords.Size = new System.Drawing.Size(179, 311);
            this.FoundWords.TabIndex = 1;
            this.FoundWords.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(863, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьИзФайлаToolStripMenuItem,
            this.сохранитьВФайлToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // загрузитьИзФайлаToolStripMenuItem
            // 
            this.загрузитьИзФайлаToolStripMenuItem.Name = "загрузитьИзФайлаToolStripMenuItem";
            this.загрузитьИзФайлаToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.загрузитьИзФайлаToolStripMenuItem.Text = "Загрузить из файла";
            // 
            // сохранитьВФайлToolStripMenuItem
            // 
            this.сохранитьВФайлToolStripMenuItem.Name = "сохранитьВФайлToolStripMenuItem";
            this.сохранитьВФайлToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.сохранитьВФайлToolStripMenuItem.Text = "Сохранить в файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.параметрыToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            this.параметрыToolStripMenuItem.Click += new System.EventHandler(this.параметрыToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.описаниеПрогграммыToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // описаниеПрогграммыToolStripMenuItem
            // 
            this.описаниеПрогграммыToolStripMenuItem.Name = "описаниеПрогграммыToolStripMenuItem";
            this.описаниеПрогграммыToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.описаниеПрогграммыToolStripMenuItem.Text = "Помощь";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(693, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Вход";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SaveText
            // 
            this.SaveText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveText.BackgroundImage")));
            this.SaveText.FlatAppearance.BorderSize = 0;
            this.SaveText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveText.Location = new System.Drawing.Point(451, 37);
            this.SaveText.Name = "SaveText";
            this.SaveText.Size = new System.Drawing.Size(29, 29);
            this.SaveText.TabIndex = 4;
            this.toolTip1.SetToolTip(this.SaveText, "Сохранить в файл");
            this.SaveText.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WordValue);
            this.groupBox1.Controls.Add(this.GivenW);
            this.groupBox1.Controls.Add(this.CombinationValue);
            this.groupBox1.Controls.Add(this.WCombination);
            this.groupBox1.Controls.Add(this.LengthValue);
            this.groupBox1.Controls.Add(this.WLenght);
            this.groupBox1.Controls.Add(this.EnglishWordsCriteria);
            this.groupBox1.Controls.Add(this.AbbreviationW);
            this.groupBox1.Controls.Add(this.CapitalizedW);
            this.groupBox1.Location = new System.Drawing.Point(671, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 203);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Критерии поиска";
            // 
            // WordValue
            // 
            this.WordValue.Location = new System.Drawing.Point(31, 170);
            this.WordValue.Name = "WordValue";
            this.WordValue.Size = new System.Drawing.Size(138, 20);
            this.WordValue.TabIndex = 18;
            // 
            // GivenW
            // 
            this.GivenW.AutoSize = true;
            this.GivenW.Location = new System.Drawing.Point(13, 147);
            this.GivenW.Name = "GivenW";
            this.GivenW.Size = new System.Drawing.Size(111, 17);
            this.GivenW.TabIndex = 17;
            this.GivenW.Text = "Заданное слово:";
            this.GivenW.UseVisualStyleBackColor = true;
            // 
            // CombinationValue
            // 
            this.CombinationValue.Location = new System.Drawing.Point(125, 124);
            this.CombinationValue.Name = "CombinationValue";
            this.CombinationValue.Size = new System.Drawing.Size(44, 20);
            this.CombinationValue.TabIndex = 16;
            // 
            // WCombination
            // 
            this.WCombination.AutoSize = true;
            this.WCombination.Location = new System.Drawing.Point(13, 124);
            this.WCombination.Name = "WCombination";
            this.WCombination.Size = new System.Drawing.Size(118, 17);
            this.WCombination.TabIndex = 15;
            this.WCombination.Text = "Комбинация букв:";
            this.WCombination.UseVisualStyleBackColor = true;
            // 
            // LengthValue
            // 
            this.LengthValue.Location = new System.Drawing.Point(110, 98);
            this.LengthValue.Name = "LengthValue";
            this.LengthValue.Size = new System.Drawing.Size(59, 20);
            this.LengthValue.TabIndex = 13;
            // 
            // WLenght
            // 
            this.WLenght.AutoSize = true;
            this.WLenght.Location = new System.Drawing.Point(12, 100);
            this.WLenght.Name = "WLenght";
            this.WLenght.Size = new System.Drawing.Size(95, 17);
            this.WLenght.TabIndex = 11;
            this.WLenght.Text = "Длина слова:";
            this.WLenght.UseVisualStyleBackColor = true;
            // 
            // EnglishWordsCriteria
            // 
            this.EnglishWordsCriteria.AutoSize = true;
            this.EnglishWordsCriteria.Location = new System.Drawing.Point(12, 73);
            this.EnglishWordsCriteria.Name = "EnglishWordsCriteria";
            this.EnglishWordsCriteria.Size = new System.Drawing.Size(119, 17);
            this.EnglishWordsCriteria.TabIndex = 10;
            this.EnglishWordsCriteria.Text = "Английские слова";
            this.EnglishWordsCriteria.UseVisualStyleBackColor = true;
            // 
            // AbbreviationW
            // 
            this.AbbreviationW.AutoSize = true;
            this.AbbreviationW.Location = new System.Drawing.Point(12, 49);
            this.AbbreviationW.Name = "AbbreviationW";
            this.AbbreviationW.Size = new System.Drawing.Size(99, 17);
            this.AbbreviationW.TabIndex = 9;
            this.AbbreviationW.Text = "Аббревиатуры";
            this.AbbreviationW.UseVisualStyleBackColor = true;
            // 
            // CapitalizedW
            // 
            this.CapitalizedW.AutoSize = true;
            this.CapitalizedW.Location = new System.Drawing.Point(12, 26);
            this.CapitalizedW.Name = "CapitalizedW";
            this.CapitalizedW.Size = new System.Drawing.Size(157, 17);
            this.CapitalizedW.TabIndex = 8;
            this.CapitalizedW.Text = "Слова с прописной буквы";
            this.CapitalizedW.UseVisualStyleBackColor = true;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(671, 256);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(180, 23);
            this.Search.TabIndex = 7;
            this.Search.Text = "Найти";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // SourceDirectory
            // 
            this.SourceDirectory.Location = new System.Drawing.Point(144, 354);
            this.SourceDirectory.Name = "SourceDirectory";
            this.SourceDirectory.Size = new System.Drawing.Size(269, 20);
            this.SourceDirectory.TabIndex = 22;
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(419, 353);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(61, 23);
            this.Browse.TabIndex = 20;
            this.Browse.Text = "Обзор";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // SaveResult
            // 
            this.SaveResult.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveResult.BackgroundImage")));
            this.SaveResult.FlatAppearance.BorderSize = 0;
            this.SaveResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveResult.Location = new System.Drawing.Point(636, 37);
            this.SaveResult.Name = "SaveResult";
            this.SaveResult.Size = new System.Drawing.Size(29, 29);
            this.SaveResult.TabIndex = 22;
            this.toolTip1.SetToolTip(this.SaveResult, "Сохранить в файл");
            this.SaveResult.UseVisualStyleBackColor = true;
            // 
            // OpenText
            // 
            this.OpenText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenText.BackgroundImage")));
            this.OpenText.FlatAppearance.BorderSize = 0;
            this.OpenText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenText.Location = new System.Drawing.Point(419, 37);
            this.OpenText.Name = "OpenText";
            this.OpenText.Size = new System.Drawing.Size(29, 29);
            this.OpenText.TabIndex = 23;
            this.toolTip1.SetToolTip(this.OpenText, "Загрузить их файла");
            this.OpenText.UseVisualStyleBackColor = true;
            this.OpenText.Click += new System.EventHandler(this.OpenText_Click);
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
            this.SearchInFilesCriteria.Location = new System.Drawing.Point(12, 330);
            this.SearchInFilesCriteria.Name = "SearchInFilesCriteria";
            this.SearchInFilesCriteria.Size = new System.Drawing.Size(106, 17);
            this.SearchInFilesCriteria.TabIndex = 24;
            this.SearchInFilesCriteria.Text = "Поиск в файлах";
            this.SearchInFilesCriteria.UseVisualStyleBackColor = true;
            this.SearchInFilesCriteria.CheckedChanged += new System.EventHandler(this.SearchInFilesCriteria_CheckedChanged);
            // 
            // DirectoryText
            // 
            this.DirectoryText.AutoSize = true;
            this.DirectoryText.Location = new System.Drawing.Point(27, 357);
            this.DirectoryText.Name = "DirectoryText";
            this.DirectoryText.Size = new System.Drawing.Size(111, 13);
            this.DirectoryText.TabIndex = 25;
            this.DirectoryText.Text = "Каталог для поиска:";
            // 
            // SearchInTextCriteria
            // 
            this.SearchInTextCriteria.AutoSize = true;
            this.SearchInTextCriteria.Checked = true;
            this.SearchInTextCriteria.Location = new System.Drawing.Point(12, 43);
            this.SearchInTextCriteria.Name = "SearchInTextCriteria";
            this.SearchInTextCriteria.Size = new System.Drawing.Size(156, 17);
            this.SearchInTextCriteria.TabIndex = 26;
            this.SearchInTextCriteria.TabStop = true;
            this.SearchInTextCriteria.Text = "Поиск в заданном тексте";
            this.SearchInTextCriteria.UseVisualStyleBackColor = true;
            this.SearchInTextCriteria.CheckedChanged += new System.EventHandler(this.SearchInTextCriteria_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(486, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Результаты поиска:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 388);
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
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FoundWords);
            this.Controls.Add(this.OriginalText);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Search);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Words Search Engine";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox OriginalText;
        private System.Windows.Forms.RichTextBox FoundWords;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SaveText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox WLenght;
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
        private System.Windows.Forms.ToolStripMenuItem описаниеПрогграммыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьИзФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button SaveResult;
        private System.Windows.Forms.Button OpenText;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton SearchInFilesCriteria;
        private System.Windows.Forms.Label DirectoryText;
        private System.Windows.Forms.RadioButton SearchInTextCriteria;
        private System.Windows.Forms.Label label1;
    }
}

