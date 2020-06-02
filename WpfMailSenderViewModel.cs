using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace WpfMailSender
{
    class WpfMailSenderViewModel
    {
        //public IList<SmtpSettings> smtpSettings { get; set; } = new ObservableCollection<SmtpSettings>();
        //public AuthSettings authSettings { get; set; } = new AuthSettings();
        //SmtpSettings _selectedSmtpServer { get; set; }
        public MailSettings mailSettings { get; set; } = new MailSettings();
        EmailSendServiceClass _servis;

        public WpfMailSenderViewModel()
        {
            //smtpSettings.Add(new SmtpSettings { Name = "Mail", SmtpServer = "smtp.mail.ru", SmtpServerPort = 25 });
            //smtpSettings.Add(new SmtpSettings { Name = "Yandex", SmtpServer = "smtp.yandex.ru", SmtpServerPort = 25 });
            //smtpSettings.Add(new SmtpSettings { Name = "Google", SmtpServer = "smtp.gmail.com", SmtpServerPort = 58 });

        }

        public string SendMessage(SmtpSettings _selectedSmtpServer, AuthSettings authSettings)
        {
            _servis = new EmailSendServiceClass();
            return _servis.SendMail(_selectedSmtpServer, authSettings, mailSettings);
        }

    }
}
