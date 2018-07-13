using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WordsSearchEngine
{
    class Log
    {
        public static void WriteEvent(DateTime dateTime, string newEvent, string message)
        {
            try
            {
                using (var connection = new SQLiteConnection(@"Data Source=Log.db; Version=3"))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText =
                            $"insert into Log (DateTime, Event, Message) values ('{dateTime}', '{newEvent}', '{message}')";

                        command.ExecuteNonQuery(); // Выполняем вставку записи в журнал.
                    }
                }
            }
            catch (Exception e)
            {
                ShowErrorMessage(e.Message);
            }
        }

        private static void ShowErrorMessage(string message)
        {
            DialogResult result = MessageBox.Show(@"Возникла ошибка при попытке записи события в журнал. " +
                                                  @"Возможно, файл журнала событий повреждён, перемещен либо удалён. " +
                                                  @"Если продолжить работу с программой, возможно ее непредсказуемое поведение. " +
                                                  Environment.NewLine + Environment.NewLine +
                                                  @"Убедитесь в наличии файла журнала по пути " +
                                                  Application.StartupPath + @"\Log.db, затем проверьте его на отсутствие повреждений, " +
                                                  @"после чего перезапустите приложение." +
                                                  Environment.NewLine + Environment.NewLine + @"Дополнительные сведения: " +
                                                  Environment.NewLine + message, @"WordsSearchEngine",
                MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            if (result is DialogResult.Abort)
                Application.Exit();
            if (result is DialogResult.Retry)
                Application.Restart();
        }
    }
}
