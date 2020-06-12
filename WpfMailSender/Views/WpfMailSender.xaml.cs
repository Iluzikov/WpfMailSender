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

        private void btnSendLater_Click(object sender, RoutedEventArgs e)
        {
            //var selectedDate = cldSchedulDate.SelectedDate ?? DateTime.Today;
            //model.SendMessageLater((IQueryable<Emails>)dgEmails.ItemsSource, (Smtp)cbSmtp.SelectedItem, selectedDate, tPicker.Text);

        }

    }
}
