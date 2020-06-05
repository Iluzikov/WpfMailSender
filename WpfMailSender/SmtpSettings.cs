using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfMailSender
{
    public class SmtpSettings : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private int _smtpServerPort;
        private string _smtpServer;

        public SmtpSettings(int id, string name, int port, string server)
        {
            Id = id;
            Name = name;
            Port = port;
            Server = server;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged(nameof(_name));
            }
        }
        public int Port
        {
            get => _smtpServerPort;
            set
            {
                if (value == _smtpServerPort) return;
                _smtpServerPort = value;
                OnPropertyChanged(nameof(_smtpServerPort));
            }
        }
        public string Server
        {
            get => _smtpServer;
            set
            {
                if (value == _smtpServer) return;
                _smtpServer = value;
                OnPropertyChanged(nameof(_smtpServer));
            }
        }
        


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
