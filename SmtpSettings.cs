using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfMailSender
{
    public class SmtpSettings : INotifyPropertyChanged
    {
        private string _smtpServer;
        private int _smtpServerPort;
        public string SmtpServer
        {
            get => _smtpServer;
            set
            {
                if (value == _smtpServer) return;
                _smtpServer = value;
                OnPropertyChanged(nameof(_smtpServer));
            }
        }
        public int SmtpServerPort
        {
            get => _smtpServerPort;
            set
            {
                if (value == _smtpServerPort) return;
                _smtpServerPort = value;
                OnPropertyChanged(nameof(_smtpServerPort));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
