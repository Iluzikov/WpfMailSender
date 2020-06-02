using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WpfMailSenderViewModel model { get; set; } = new WpfMailSenderViewModel();
        SendEndWindow sendEndWindow;
        AuthorizationWindow authWindow;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = model;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            authWindow = new AuthorizationWindow();
            authWindow.Owner = this;
            authWindow.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            authWindow = new AuthorizationWindow();
            authWindow.Owner = this;
            if (authWindow.ShowDialog() == true)
            {

                sendEndWindow = new SendEndWindow(model.SendMessage(authWindow.selectedSmtpServer, authWindow.authSettings));
                sendEndWindow.Owner = this;
                sendEndWindow.ShowDialog();
            }
        }
    }
}
