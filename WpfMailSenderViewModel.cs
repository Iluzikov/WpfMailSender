using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

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
            smtpSettings.Add(new SmtpSettings { Name = "Google", SmtpServer = "smtp.gmail.com", SmtpServerPort = 58 });

        }

        public string SendMessage()
        {
            if (selectedSmtpServer == null) return "Не выбран SMTP сервер";
            if (string.IsNullOrWhiteSpace(authSettings.EmailFrom) 
                || string.IsNullOrWhiteSpace(authSettings.Password)) return "Введите логин и пароль";
            if (!EmailIsValid(authSettings.EmailFrom)) return "Некорректный логин";
            if (string.IsNullOrWhiteSpace(mailSettings.EmailTo)) return "Введите email адрес получателя";
            if (!EmailIsValid(mailSettings.EmailTo)) return "Некорректный email адрес получателя";
            if (string.IsNullOrWhiteSpace(mailSettings.EmailText)) return "Введите текст сообщения";
            _servis = new EmailSendServiceClass();
            return _servis.SendMail(selectedSmtpServer, authSettings, mailSettings);
        }

        bool EmailIsValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
    }
}
