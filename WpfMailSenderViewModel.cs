using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace WpfMailSender
{
    class WpfMailSenderViewModel
    {
        public MailSettings mailSettings { get; set; } = new MailSettings();
        public SmtpSettings SelectedSmtp { get; set; } = new SmtpSettings();
        EmailSendServiceClass _servis;
        public string Status { get; set; }
 
        public void SendMessage(SmtpSettings selectedSmtpServer, AuthSettings authSettings, MailSettings mailSettings)
        {
            _servis = new EmailSendServiceClass(selectedSmtpServer, authSettings, mailSettings);
            //return _servis.SendMails();
        }

        public bool IsFillError()
        {
            if (string.IsNullOrWhiteSpace(mailSettings.EmailText))
            {
                Status = "Введите адрес получателя и текст сообщения";
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
