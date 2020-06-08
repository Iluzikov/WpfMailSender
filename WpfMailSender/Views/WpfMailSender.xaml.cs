using System;
using System.Linq;
using System.Windows;
using WpfMailSender.Data;
using WpfMailSender.ViewModels;

namespace WpfMailSender.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //dgEmails.ItemsSource = DataBaseClass.DBEmails;
            //cbSmtp.ItemsSource = DataBaseClass.DBSmtp;
        }

        /// <summary>
        /// Перейти в планировщик
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tabCtrl.SelectedItem = tabItemPlanner;
        }

        private void btnSendAtOnce_Click(object sender, RoutedEventArgs e)
        {
            //model.SendMessage((IQueryable<Emails>)dgEmails.ItemsSource, (Smtp)cbSmtp.SelectedItem);
        }

        private void btnSendLater_Click(object sender, RoutedEventArgs e)
        {
            //var selectedDate = cldSchedulDate.SelectedDate ?? DateTime.Today;
            //model.SendMessageLater((IQueryable<Emails>)dgEmails.ItemsSource, (Smtp)cbSmtp.SelectedItem, selectedDate, tPicker.Text);

        }

    }
}
