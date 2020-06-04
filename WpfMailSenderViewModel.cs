using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfMailSender
{
    class WpfMailSenderViewModel
    {
        public MailSettings mailSettings { get; set; } = new MailSettings();
        //public AuthSettings authSettings { get; set; } = new AuthSettings();
        public SmtpSettings SelectedSmtp { get; set; } = new SmtpSettings();
        EmailSendServiceClass _service;
        //ObservableCollection<Emails> selectedEmails { get; set; } = new ObservableCollection<Emails>();
        public string Status { get; set; }
 
        public void SendMessage(IQueryable<Emails> emails)
        {
            if (IsFillError()) return;
            AuthorizationWindow authWindow = new AuthorizationWindow();
            if (authWindow.ShowDialog() == true)
            {
                _service = new EmailSendServiceClass(SelectedSmtp, authWindow.authSettings, mailSettings);
                _service.SendMails(emails);
            }
        }

        public bool IsFillError()
        {
            if (string.IsNullOrWhiteSpace(mailSettings.EmailText) 
                || string.IsNullOrWhiteSpace(mailSettings.EmailSubject))
            {
                MessageBox.Show("Введите адрес получателя и текст сообщения", "Внимание!");
                return true;
            }
            return false;
        }
        //bool EmailIsValid(string email)
        //{
        //    string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
        //    Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
        //    return isMatch.Success;
        //}
    }
}
