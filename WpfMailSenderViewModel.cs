using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfMailSender
{
    class WpfMailSenderViewModel
    {
        public IList<SmtpSettings> smtpSettings { get; set; } = new ObservableCollection<SmtpSettings>();
        public MailSettings mailSettings { get; set; } = new MailSettings();
        public AuthSettings authSettings { get; set; } = new AuthSettings();
        public SmtpSettings selectedSmtpServer { get; set; }
        EmailSendServiceClass _servis;

        public WpfMailSenderViewModel()
        {
            smtpSettings.Add(new SmtpSettings { Name = "Mail", SmtpServer = "smtp.mail.ru", SmtpServerPort = 25 });
            smtpSettings.Add(new SmtpSettings { Name = "Yandex", SmtpServer = "smtp.yandex.ru", SmtpServerPort = 25 });
            smtpSettings.Add(new SmtpSettings { Name = "Google", SmtpServer = "smtp.gmail.com", SmtpServerPort = 25 });

        }

        public void SendMessage()
        {
            _servis = new EmailSendServiceClass();
            _servis.SendMail(selectedSmtpServer, authSettings, mailSettings);
        }

    }
}
