using System;
using System.Windows;
using System.Windows.Controls;
using WpfMailSender.Models;

namespace WpfMailSender.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ListViewItemScheduler.xaml
    /// </summary>
    public partial class ListViewItemScheduler : UserControl
    {
        MessageTextWindow textWindow;
        public MailSettings MailSet { get; set; }
        public ListViewItemScheduler()
        {
            InitializeComponent();
            MailSet = new MailSettings();
        }

        private void btnControlDelete_Click(object sender, RoutedEventArgs e)
        {
            ((ListView)this.Parent).Items.Remove(this);
        }

        private void btnMessageEdit_Click(object sender, RoutedEventArgs e)
        {
            textWindow = new MessageTextWindow(MailSet.EmailSubject, MailSet.EmailText);
            if (textWindow.ShowDialog() == true)
            {
                MailSet.EmailSubject = textWindow.tbSubject.Text;
                MailSet.EmailText = textWindow.tbText.Text;
                
            }
        }

        private void dtpDateTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            MailSet.EmailDateTime = dtpDateTime.Value ?? DateTime.Now;
        }
    }
}
