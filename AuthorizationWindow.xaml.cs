using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfMailSender
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public IList<SmtpSettings> smtpSettings { get; set; } = new ObservableCollection<SmtpSettings>();
        public AuthSettings authSettings { get; set; } = new AuthSettings();
        public SmtpSettings selectedSmtpServer { get; set; }


        public AuthorizationWindow()
        {
            InitializeComponent();
            smtpSettings.Add(new SmtpSettings { Name = "Mail", SmtpServer = "smtp.mail.ru", SmtpServerPort = 25 });
            smtpSettings.Add(new SmtpSettings { Name = "Yandex", SmtpServer = "smtp.yandex.ru", SmtpServerPort = 25 });
            smtpSettings.Add(new SmtpSettings { Name = "Google", SmtpServer = "smtp.gmail.com", SmtpServerPort = 58 });
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSmtpServer == null) return;
            if (string.IsNullOrWhiteSpace(authSettings.EmailFrom)
                || string.IsNullOrWhiteSpace(authSettings.Password)) return;
            if (!EmailIsValid(authSettings.EmailFrom)) return;
            DialogResult = true;
        }

        bool EmailIsValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
