using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfMailSender
{
    public class AuthSettings : INotifyPropertyChanged
    {
        private string _emailFrom;
        private string _password;

        public string EmailFrom
        {
            get => _emailFrom;
            set
            {
                if (value == _emailFrom) return;
                _emailFrom = value;
                OnPropertyChanged(nameof(_emailFrom));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged(nameof(_password));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
