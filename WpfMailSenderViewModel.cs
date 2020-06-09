using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace WpfMailSender
{
    class WpfMailSenderViewModel
    {
        public MailSettings mailSettings { get; set; } = new MailSettings();
        EmailSendServiceClass _servis;
        public string Status { get; set; }
 
        public string SendMessage(SmtpSettings _selectedSmtpServer, AuthSettings authSettings)
        {
            _servis = new EmailSendServiceClass();
            return _servis.SendMail(_selectedSmtpServer, authSettings, mailSettings);
        }

        public bool IsFillError()
        {
            if (string.IsNullOrWhiteSpace(mailSettings.EmailText)
                || string.IsNullOrWhiteSpace(mailSettings.EmailTo))
            {
                Status = "Введите адрес получателя и текст сообщения";
                return true;
            }
            if (!EmailIsValid(mailSettings.EmailTo))
            {
                Status = "Некорректный адрес получателя";
                return true;
            }
            return false;
        }
        bool EmailIsValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
    }
}
