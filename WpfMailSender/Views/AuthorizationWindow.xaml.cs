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
using WpfMailSender.Models;

namespace WpfMailSender
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthSettings authSettings { get; set; } = new AuthSettings();

        public AuthorizationWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsFillError()) return;
            DialogResult = true;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public bool IsFillError()
        {
            if (string.IsNullOrWhiteSpace(authSettings.EmailFrom)
                || string.IsNullOrWhiteSpace(authSettings.Password))
            {
                MessageBox.Show("Введите логин и пароль");
                return true;
            }
            if (!EmailIsValid(authSettings.EmailFrom))
            {
                MessageBox.Show("Некорректный логин");
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
