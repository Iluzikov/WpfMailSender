using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfMailSender
{
    public class AuthorizationWindowViewModel
    {
        public IList<SmtpSettings> smtpSettings { get; set; } = new ObservableCollection<SmtpSettings>();
        public AuthSettings authSettings { get; set; } = new AuthSettings();
        public SmtpSettings selectedSmtpServer { get; set; }
        public string Status { get; set; }

        public AuthorizationWindowViewModel()
        {
            smtpSettings.Add(new SmtpSettings { Name = "Mail", SmtpServer = "smtp.mail.ru", SmtpServerPort = 25 });
            smtpSettings.Add(new SmtpSettings { Name = "Yandex", SmtpServer = "smtp.yandex.ru", SmtpServerPort = 25 });
            smtpSettings.Add(new SmtpSettings { Name = "Google", SmtpServer = "smtp.gmail.com", SmtpServerPort = 58 });
            
        }

        public bool IsFillError()
        {
            if (selectedSmtpServer == null)
            {
                Status = "Выберите SMTP сервер";
                return true;
            }
            if (string.IsNullOrWhiteSpace(authSettings.EmailFrom)
                || string.IsNullOrWhiteSpace(authSettings.Password))
            {
                Status = "Введите логин и пароль";
                return true;
            }
            if (!EmailIsValid(authSettings.EmailFrom))
            {
                Status = "Некорректный логин";
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
