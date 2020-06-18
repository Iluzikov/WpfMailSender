using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfMailSender.Models
{
    public class MailSettings : INotifyPropertyChanged
    {
        private string _emailSubject;
        private string _emailText;
        private DateTime _emailDateTime;
       
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

        public DateTime EmailDateTime
        {
            get => _emailDateTime;
            set
            {
                if (value == _emailDateTime) return;
                _emailDateTime = value;
                OnPropertyChanged(nameof(_emailDateTime));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
