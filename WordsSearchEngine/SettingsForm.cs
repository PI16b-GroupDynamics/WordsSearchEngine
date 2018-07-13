using System;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace WordsSearchEngine
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            ResetSettings();
        }

        private bool _textName;
        private bool _specifyTextName;
        private bool _specifyCriteria;
        private bool _foreColor;
        private string _path;

        private void ResetSettings()
        {
            _textName = TextName.Checked = false;
            _specifyTextName = SpecifyTextName.Checked = false;
            _specifyCriteria = SpecifyCriteria.Checked = false;
            _foreColor = TextColor.Checked = true;
            _path = Path.Text = Application.StartupPath + @"\Results";
        }

        private void SaveSettings(bool save)
        {
            if (save)
            {
                _textName = TextName.Checked;
                _specifyTextName = SpecifyTextName.Checked;
                _specifyCriteria = SpecifyCriteria.Checked;
                _foreColor = TextColor.Checked;
                if (Directory.Exists(Path.Text))
                    _path = Path.Text;
                else
                {
                    MessageBox.Show(@"Данной директории не существует!" + '\n' + @"Расположение файла не изменилось!",
                        @"WordsSearchEngine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Path.Text = _path;
                }
            }
            else
            {
                TextName.Checked = _textName;
                SpecifyTextName.Checked = _specifyTextName;
                SpecifyCriteria.Checked = _specifyCriteria;
                TextColor.Checked = _foreColor;
                BackgroundColor.Checked = !_foreColor;
                Path.Text = _path;
            }
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                Path.Text = folderBrowserDialog1.SelectedPath;
        }

        private void RestoreDefaultSettings_Click(object sender, EventArgs e)
        {
            ResetSettings();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            SaveSettings(true);
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            SaveSettings(false);
            Close();
        }

        // Сохранение настроек в файл.
        public void SaveSettingsToFile()
        {
            XmlWriter writer = null;
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings {Indent = true};
                writer = XmlWriter.Create(@"System\Settings.xml", settings);

                writer.WriteStartDocument();
                writer.WriteStartElement("Settings");
                
                writer.WriteElementString("TextNameForFile", _textName.ToString().ToLower());
                writer.WriteElementString("SpecifyTextName", _specifyTextName.ToString().ToLower());
                writer.WriteElementString("SpecifyCriteria", _specifyCriteria.ToString().ToLower());
                writer.WriteElementString("FilePath", _path);
                writer.WriteElementString("ForeColor", _foreColor.ToString().ToLower());

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
            catch (SerializationException ex)
            {
                MessageBox.Show(@"Возникла ошибка при записи настроек в файл." +
                                Environment.NewLine + Environment.NewLine + @"Дополнительные сведения: " +
                                Environment.NewLine + ex.Message, @"WordsSearchEngine",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Возникла ошибка при записи настроек в файл." +
                                Environment.NewLine + Environment.NewLine + @"Дополнительные сведения: " +
                                Environment.NewLine + ex.Message, @"WordsSearchEngine",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                writer?.Close();
            }
        }

        // Установка параметров настроек в форме.
        public void SetSettingsFromFile()
        {
            XmlReader reader = null;
            try
            {
                reader = XmlReader.Create(@"System\Settings.xml");
                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case "TextNameForFile": TextName.Checked = reader.ReadElementContentAsBoolean(); break;
                        case "SpecifyTextName": SpecifyTextName.Checked = reader.ReadElementContentAsBoolean(); break;
                        case "SpecifyCriteria": SpecifyCriteria.Checked = reader.ReadElementContentAsBoolean(); break;
                        case "FilePath": Path.Text = reader.ReadElementContentAsString(); break;
                        case "ForeColor":
                            if (reader.ReadElementContentAsBoolean())
                                TextColor.Checked = true;
                            else BackgroundColor.Checked = true;
                            break;
                    }
                }
            }
            catch (XmlException ex)
            {
                MessageBox.Show(@"Возникла ошибка при получении настроек из файла." +
                                Environment.NewLine + Environment.NewLine + @"Дополнительные сведения: " +
                                Environment.NewLine + ex.Message, @"WordsSearchEngine",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Возникла ошибка при получении настроек из файла." +
                                Environment.NewLine + Environment.NewLine + @"Дополнительные сведения: " +
                                Environment.NewLine + ex.Message, @"WordsSearchEngine",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetSettings();
            }
            finally
            {
                reader?.Close();
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings(false);
        }
    }
}
