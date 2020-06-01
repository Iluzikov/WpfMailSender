using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfMailSender
{
    public class MailSettings : INotifyPropertyChanged
    {
        
        private string _emailFrom;
        private string _password;
        private string _emailTo;
        private string _emailSubject;
        private string _emailText;

       
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
        public string EmailTo
        {
            get => _emailTo;
            set
            {
                if (value == _emailTo) return;
                _emailTo = value;
                OnPropertyChanged(nameof(_emailTo));
            }
        }
        public string EmailSubject
        {
            get => _emailSubject;
            set
            {
                if (value == _emailSubject) return;
                _emailSubject = value;
                OnPropertyChanged(nameof(_emailSubject));
            }
        }
        public string EmailText
        {
            get => _emailText;
            set
            {
                if (value == _emailText) return;
                _emailText = value;
                OnPropertyChanged(nameof(_emailText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
