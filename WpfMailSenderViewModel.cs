using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfMailSender
{
    class WpfMailSenderViewModel
    {
        public IList<SmtpSettings> smtpSettings { get; set; } = new ObservableCollection<SmtpSettings>();
        public MailSettings mailSettings;
        public AuthSettings authSettings;

        public WpfMailSenderViewModel()
        {
            smtpSettings.Add(new SmtpSettings { Name = "Mail", SmtpServer = "smtp.mail.ru", SmtpServerPort = 465 });
            smtpSettings.Add(new SmtpSettings { Name = "Yandex", SmtpServer = "smtp.yandex.ru", SmtpServerPort = 465 });
            smtpSettings.Add(new SmtpSettings { Name = "Google", SmtpServer = "smtp.gmail.com", SmtpServerPort = 465 });

            mailSettings = new MailSettings();
            authSettings = new AuthSettings();

        }
    }
}
