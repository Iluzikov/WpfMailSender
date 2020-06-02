using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WpfMailSenderViewModel model { get; set; } = new WpfMailSenderViewModel();

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
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            model.SendMessage();
        }
    }
}
