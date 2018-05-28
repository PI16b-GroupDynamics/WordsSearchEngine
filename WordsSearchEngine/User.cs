using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WordsSearchEngine
{
    // Класс, объекты которого будут храниться в базе данных.
    // Свойства класса соответствуют полям таблицы.
    // Класс назван именем БД в единственном числе для соблюдения условностей Entity Framework.
    // Класс реализует интерфейс INotifyPropertyChanged для синхронного изменения записей в БД.
    class User : INotifyPropertyChanged
    {
        private string _login;
        private string _name;
        private string _password;
        private string _source;
        private string _result;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Source
        {
            get => _source;
            set
            {
                _source = value;
                OnPropertyChanged("Source");
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        // Этот метод вызывается методом set для каждого свойства.
        // Атрибут CallerMemberName, который применяется к необязательному параметру propertyName,
        // вызывает замену имени свойства вызывающего объекта в качестве аргумента.
        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // = if (PropertyChanged != null)
        }
    }
}
