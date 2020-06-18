using System.Windows;

namespace WpfMailSender.Views
{
    /// <summary>
    /// Логика взаимодействия для MessageTextWindow.xaml
    /// </summary>
    public partial class MessageTextWindow : Window
    {
        public MessageTextWindow()
        {
            InitializeComponent();
        }

        public MessageTextWindow(string subj, string text):this()
        {
            tbSubject.Text = subj;
            tbText.Text = text;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbSubject.Text) || string.IsNullOrWhiteSpace(tbText.Text))
            {
                MessageBox.Show("Введите тему и текст сообщения.", "Внимание!");
                return;
            }
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
