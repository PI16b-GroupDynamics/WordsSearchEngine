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
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.GivenW = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.WCombination = new System.Windows.Forms.CheckBox();
            this.LengthRange = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LengthRangeCriteria = new System.Windows.Forms.CheckBox();
            this.WLenght = new System.Windows.Forms.CheckBox();
            this.EnglishWordsCriteria = new System.Windows.Forms.CheckBox();
            this.AbbreviationW = new System.Windows.Forms.CheckBox();
            this.CapitalizedW = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SearchInFilesCriteria = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SearchDirectory = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OriginalText
            // 
            this.OriginalText.Location = new System.Drawing.Point(12, 39);
            this.OriginalText.Name = "OriginalText";
            this.OriginalText.Size = new System.Drawing.Size(468, 337);
            this.OriginalText.TabIndex = 0;
            this.OriginalText.Text = "";
            // 
            // FoundWords
            // 
            this.FoundWords.Location = new System.Drawing.Point(486, 39);
            this.FoundWords.Name = "FoundWords";
            this.FoundWords.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.FoundWords.Size = new System.Drawing.Size(147, 337);
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
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
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
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.описаниеПрогграммыToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.описаниеПрогграммыToolStripMenuItem.Text = "Помощь";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(448, 345);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 29);
            this.button2.TabIndex = 4;
            this.toolTip1.SetToolTip(this.button2, "Сохранить в файл");
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.GivenW);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.WCombination);
            this.groupBox1.Controls.Add(this.LengthRange);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.LengthRangeCriteria);
            this.groupBox1.Controls.Add(this.WLenght);
            this.groupBox1.Controls.Add(this.EnglishWordsCriteria);
            this.groupBox1.Controls.Add(this.AbbreviationW);
            this.groupBox1.Controls.Add(this.CapitalizedW);
            this.groupBox1.Location = new System.Drawing.Point(641, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 247);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Критерии поиска";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(33, 202);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(138, 20);
            this.textBox4.TabIndex = 18;
            // 
            // GivenW
            // 
            this.GivenW.AutoSize = true;
            this.GivenW.Location = new System.Drawing.Point(6, 180);
            this.GivenW.Name = "GivenW";
            this.GivenW.Size = new System.Drawing.Size(111, 17);
            this.GivenW.TabIndex = 17;
            this.GivenW.Text = "Заданное слово:";
            this.GivenW.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(120, 152);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(44, 20);
            this.textBox3.TabIndex = 16;
            // 
            // WCombination
            // 
            this.WCombination.AutoSize = true;
            this.WCombination.Location = new System.Drawing.Point(6, 154);
            this.WCombination.Name = "WCombination";
            this.WCombination.Size = new System.Drawing.Size(118, 17);
            this.WCombination.TabIndex = 15;
            this.WCombination.Text = "Комбинация букв:";
            this.WCombination.UseVisualStyleBackColor = true;
            // 
            // LengthRange
            // 
            this.LengthRange.Location = new System.Drawing.Point(104, 123);
            this.LengthRange.Name = "LengthRange";
            this.LengthRange.Size = new System.Drawing.Size(59, 20);
            this.LengthRange.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 98);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(59, 20);
            this.textBox1.TabIndex = 13;
            // 
            // LengthRangeCriteria
            // 
            this.LengthRangeCriteria.AutoSize = true;
            this.LengthRangeCriteria.Location = new System.Drawing.Point(6, 126);
            this.LengthRangeCriteria.Name = "LengthRangeCriteria";
            this.LengthRangeCriteria.Size = new System.Drawing.Size(80, 17);
            this.LengthRangeCriteria.TabIndex = 12;
            this.LengthRangeCriteria.Text = "Диапазон:";
            this.LengthRangeCriteria.UseVisualStyleBackColor = true;
            // 
            // WLenght
            // 
            this.WLenght.AutoSize = true;
            this.WLenght.Location = new System.Drawing.Point(6, 100);
            this.WLenght.Name = "WLenght";
            this.WLenght.Size = new System.Drawing.Size(95, 17);
            this.WLenght.TabIndex = 11;
            this.WLenght.Text = "Длина слова:";
            this.WLenght.UseVisualStyleBackColor = true;
            // 
            // EnglishWordsCriteria
            // 
            this.EnglishWordsCriteria.AutoSize = true;
            this.EnglishWordsCriteria.Location = new System.Drawing.Point(6, 73);
            this.EnglishWordsCriteria.Name = "EnglishWordsCriteria";
            this.EnglishWordsCriteria.Size = new System.Drawing.Size(119, 17);
            this.EnglishWordsCriteria.TabIndex = 10;
            this.EnglishWordsCriteria.Text = "Английские слова";
            this.EnglishWordsCriteria.UseVisualStyleBackColor = true;
            // 
            // AbbreviationW
            // 
            this.AbbreviationW.AutoSize = true;
            this.AbbreviationW.Location = new System.Drawing.Point(6, 49);
            this.AbbreviationW.Name = "AbbreviationW";
            this.AbbreviationW.Size = new System.Drawing.Size(99, 17);
            this.AbbreviationW.TabIndex = 9;
            this.AbbreviationW.Text = "Аббревиатуры";
            this.AbbreviationW.UseVisualStyleBackColor = true;
            // 
            // CapitalizedW
            // 
            this.CapitalizedW.AutoSize = true;
            this.CapitalizedW.Location = new System.Drawing.Point(6, 26);
            this.CapitalizedW.Name = "CapitalizedW";
            this.CapitalizedW.Size = new System.Drawing.Size(157, 17);
            this.CapitalizedW.TabIndex = 8;
            this.CapitalizedW.Text = "Слова с прописной буквы";
            this.CapitalizedW.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(641, 353);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Найти";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // SearchInFilesCriteria
            // 
            this.SearchInFilesCriteria.AutoSize = true;
            this.SearchInFilesCriteria.Location = new System.Drawing.Point(8, 21);
            this.SearchInFilesCriteria.Name = "SearchInFilesCriteria";
            this.SearchInFilesCriteria.Size = new System.Drawing.Size(115, 17);
            this.SearchInFilesCriteria.TabIndex = 19;
            this.SearchInFilesCriteria.Text = "Найти в каталоге";
            this.SearchInFilesCriteria.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SearchDirectory);
            this.groupBox2.Controls.Add(this.Browse);
            this.groupBox2.Controls.Add(this.SearchInFilesCriteria);
            this.groupBox2.Location = new System.Drawing.Point(639, 275);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 72);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поиск в файлах";
            // 
            // SearchDirectory
            // 
            this.SearchDirectory.Location = new System.Drawing.Point(6, 42);
            this.SearchDirectory.Name = "SearchDirectory";
            this.SearchDirectory.Size = new System.Drawing.Size(140, 20);
            this.SearchDirectory.TabIndex = 22;
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(152, 39);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(24, 23);
            this.Browse.TabIndex = 20;
            this.Browse.Text = "...";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(583, 345);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 29);
            this.button3.TabIndex = 22;
            this.toolTip1.SetToolTip(this.button3, "Сохранить в файл");
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(414, 345);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(29, 29);
            this.button6.TabIndex = 23;
            this.toolTip1.SetToolTip(this.button6, "Загрузить их файла");
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 388);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FoundWords);
            this.Controls.Add(this.OriginalText);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button4);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Words Search Engine";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox LengthRangeCriteria;
        private System.Windows.Forms.CheckBox WLenght;
        private System.Windows.Forms.CheckBox EnglishWordsCriteria;
        private System.Windows.Forms.CheckBox AbbreviationW;
        private System.Windows.Forms.CheckBox CapitalizedW;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckBox GivenW;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox WCombination;
        private System.Windows.Forms.TextBox LengthRange;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox SearchInFilesCriteria;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox SearchDirectory;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.ToolStripMenuItem описаниеПрогграммыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьИзФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

