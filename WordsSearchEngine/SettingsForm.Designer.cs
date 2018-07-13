namespace WordsSearchEngine
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FileSettings = new System.Windows.Forms.GroupBox();
            this.Browse = new System.Windows.Forms.Button();
            this.Path = new System.Windows.Forms.TextBox();
            this.FilePath = new System.Windows.Forms.Label();
            this.SpecifyCriteria = new System.Windows.Forms.CheckBox();
            this.SpecifyTextName = new System.Windows.Forms.CheckBox();
            this.Structure = new System.Windows.Forms.Label();
            this.TextName = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.HighlightSettings = new System.Windows.Forms.GroupBox();
            this.BackgroundColor = new System.Windows.Forms.RadioButton();
            this.TextColor = new System.Windows.Forms.RadioButton();
            this.Cancel = new System.Windows.Forms.Button();
            this.Ok = new System.Windows.Forms.Button();
            this.RestoreDefaultSettings = new System.Windows.Forms.Button();
            this.FileSettings.SuspendLayout();
            this.HighlightSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileSettings
            // 
            this.FileSettings.Controls.Add(this.Browse);
            this.FileSettings.Controls.Add(this.Path);
            this.FileSettings.Controls.Add(this.FilePath);
            this.FileSettings.Controls.Add(this.SpecifyCriteria);
            this.FileSettings.Controls.Add(this.SpecifyTextName);
            this.FileSettings.Controls.Add(this.Structure);
            this.FileSettings.Controls.Add(this.TextName);
            this.FileSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileSettings.Location = new System.Drawing.Point(12, 12);
            this.FileSettings.Name = "FileSettings";
            this.FileSettings.Size = new System.Drawing.Size(531, 154);
            this.FileSettings.TabIndex = 0;
            this.FileSettings.TabStop = false;
            this.FileSettings.Text = "Параметры файла результатов";
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(423, 115);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(86, 25);
            this.Browse.TabIndex = 5;
            this.Browse.Text = "Обзор...";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(131, 118);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(286, 22);
            this.Path.TabIndex = 4;
            // 
            // FilePath
            // 
            this.FilePath.AutoSize = true;
            this.FilePath.Location = new System.Drawing.Point(18, 121);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(108, 16);
            this.FilePath.TabIndex = 7;
            this.FilePath.Text = "Расположение:";
            // 
            // SpecifyCriteria
            // 
            this.SpecifyCriteria.AutoSize = true;
            this.SpecifyCriteria.Location = new System.Drawing.Point(132, 85);
            this.SpecifyCriteria.Name = "SpecifyCriteria";
            this.SpecifyCriteria.Size = new System.Drawing.Size(195, 20);
            this.SpecifyCriteria.TabIndex = 3;
            this.SpecifyCriteria.Text = "Указать критерии поиска";
            this.SpecifyCriteria.UseVisualStyleBackColor = true;
            // 
            // SpecifyTextName
            // 
            this.SpecifyTextName.AutoSize = true;
            this.SpecifyTextName.Location = new System.Drawing.Point(132, 60);
            this.SpecifyTextName.Name = "SpecifyTextName";
            this.SpecifyTextName.Size = new System.Drawing.Size(195, 20);
            this.SpecifyTextName.TabIndex = 2;
            this.SpecifyTextName.Text = "Указать название текста";
            this.SpecifyTextName.UseVisualStyleBackColor = true;
            // 
            // Structure
            // 
            this.Structure.AutoSize = true;
            this.Structure.Location = new System.Drawing.Point(18, 60);
            this.Structure.Name = "Structure";
            this.Structure.Size = new System.Drawing.Size(81, 16);
            this.Structure.TabIndex = 4;
            this.Structure.Text = "Структура:";
            // 
            // TextName
            // 
            this.TextName.AutoSize = true;
            this.TextName.Location = new System.Drawing.Point(21, 32);
            this.TextName.Name = "TextName";
            this.TextName.Size = new System.Drawing.Size(316, 20);
            this.TextName.TabIndex = 1;
            this.TextName.Text = "Имя файла соответствует названию текста";
            this.TextName.UseVisualStyleBackColor = true;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // HighlightSettings
            // 
            this.HighlightSettings.Controls.Add(this.BackgroundColor);
            this.HighlightSettings.Controls.Add(this.TextColor);
            this.HighlightSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HighlightSettings.Location = new System.Drawing.Point(17, 176);
            this.HighlightSettings.Name = "HighlightSettings";
            this.HighlightSettings.Size = new System.Drawing.Size(526, 67);
            this.HighlightSettings.TabIndex = 1;
            this.HighlightSettings.TabStop = false;
            this.HighlightSettings.Text = "Параметры выделения слов";
            // 
            // BackgroundColor
            // 
            this.BackgroundColor.AutoSize = true;
            this.BackgroundColor.Location = new System.Drawing.Point(144, 36);
            this.BackgroundColor.Name = "BackgroundColor";
            this.BackgroundColor.Size = new System.Drawing.Size(100, 20);
            this.BackgroundColor.TabIndex = 7;
            this.BackgroundColor.Text = "Фон текста";
            this.BackgroundColor.UseVisualStyleBackColor = true;
            // 
            // TextColor
            // 
            this.TextColor.AutoSize = true;
            this.TextColor.Location = new System.Drawing.Point(16, 36);
            this.TextColor.Name = "TextColor";
            this.TextColor.Size = new System.Drawing.Size(105, 20);
            this.TextColor.TabIndex = 6;
            this.TextColor.Text = "Цвет текста";
            this.TextColor.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(463, 249);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(80, 23);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(376, 249);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(80, 23);
            this.Ok.TabIndex = 8;
            this.Ok.Text = "ОК";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // RestoreDefaultSettings
            // 
            this.RestoreDefaultSettings.Location = new System.Drawing.Point(17, 249);
            this.RestoreDefaultSettings.Name = "RestoreDefaultSettings";
            this.RestoreDefaultSettings.Size = new System.Drawing.Size(111, 23);
            this.RestoreDefaultSettings.TabIndex = 10;
            this.RestoreDefaultSettings.Text = "По умолчанию";
            this.RestoreDefaultSettings.UseVisualStyleBackColor = true;
            this.RestoreDefaultSettings.Click += new System.EventHandler(this.RestoreDefaultSettings_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 282);
            this.Controls.Add(this.RestoreDefaultSettings);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.HighlightSettings);
            this.Controls.Add(this.FileSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.FileSettings.ResumeLayout(false);
            this.FileSettings.PerformLayout();
            this.HighlightSettings.ResumeLayout(false);
            this.HighlightSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox FileSettings;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Label FilePath;
        private System.Windows.Forms.Label Structure;
        public System.Windows.Forms.CheckBox TextName;
        public System.Windows.Forms.TextBox Path;
        public System.Windows.Forms.CheckBox SpecifyCriteria;
        public System.Windows.Forms.CheckBox SpecifyTextName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox HighlightSettings;
        private System.Windows.Forms.RadioButton BackgroundColor;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button RestoreDefaultSettings;
        public System.Windows.Forms.RadioButton TextColor;
    }
}