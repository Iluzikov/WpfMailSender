using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using WpfMailSender.Commands;
using WpfMailSender.Data;
using WpfMailSender.Services;
using WpfMailSender.ViewModels.Base;

namespace WpfMailSender.ViewModels
{
    internal class EmailInfoViewModel : ViewModelBase
    {
        public WpfMailSenderViewModel MainVM { get; internal set; }

        private readonly IDataAccessService _dataAccessService;

        #region Поиск адресата

        private string _emailsFilterText;
        public string EmailsFilterText
        {
            get => _emailsFilterText;
            set
            {
                if (!Set(ref _emailsFilterText, value)) return;
                _emailsListCollections.View.Refresh();
            }
        }
        private readonly CollectionViewSource _emailsListCollections = new CollectionViewSource();
        public ICollectionView EmailsListCollection => _emailsListCollections?.View;

        private bool _emailsFilterTextFlag = false;
        public bool EmailsFilterTextFlag
        {
            get => _emailsFilterTextFlag;
            set => Set(ref _emailsFilterTextFlag, value);
        }
        /// <summary>
        /// Метод фильтрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEmailFiltered(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Emails emails))
            {
                e.Accepted = false;
                return;
            }

            var filterText = _emailsFilterText;
            if (string.IsNullOrWhiteSpace(filterText))
                return;

            if (emails.Name.ToLower().Contains(filterText.ToLower())) return;
            if (emails.Email.ToLower().Contains(filterText.ToLower())) return;

            e.Accepted = false;
        }
        #endregion

        #region Список всех адресатов из БД
        private ObservableCollection<Emails> _emailsList;
        public ObservableCollection<Emails> EmailsList
        {
            get => _emailsList;
            set
            {
                if (!Set(ref _emailsList, value)) return;
                _emailsListCollections.Source = value;
                OnPropertyChanged(nameof(EmailsListCollection));
            }
        }
        #endregion

        #region Список получателей сообщения
        public ObservableCollection<Emails> RecipientList { get; set; }
        #endregion

        #region Выбранный Email адрес
        private Emails _selectedEmail;
        public Emails SelectedEmail
        {
            get => _selectedEmail;
            set => Set(ref _selectedEmail, value);
        }
        #endregion

        #region Выбранный получатель
        private Emails _selectedRecipient;
        public Emails SelectedRecipient
        {
            get => _selectedRecipient;
            set => Set(ref _selectedRecipient, value);
        }
        #endregion

        public EmailInfoViewModel(IDataAccessService dataService)
        {
            _dataAccessService = dataService;
            RecipientList = new ObservableCollection<Emails>();
            _emailsListCollections.Filter += OnEmailFiltered;

            #region Комманды
            GetEmailsCommand = new RelayCommand(OnGetEmailsCommandExecuted, CanGetEmailsCommandExecute);
            GetRecipientCommand = new RelayCommand(OnGetRecipientCommandExecuted, CanGetRecipientCommandExecute);
            RemoveRecipientCommand = new RelayCommand(OnRemoveRecipientCommandExecuted, CanRemoveRecipientCommandExecute);
            ClearRecipientCommand = new RelayCommand(OnClearRecipientCommandExecuted, CanClearRecipientCommandExecute);
            ClearFilterCommand = new RelayCommand(OnClearFilterCommandExecuted, CanClearFilterCommandExecute);
            #endregion
        }

        /// <summary>
        /// Получает список E-mail адресов через класс-сервис
        /// </summary>
        void GetEmails()
        {
            EmailsList = _dataAccessService.GetEmails();
            EmailsFilterTextFlag = true;
        }

        #region Команда получения списка Email

        public ICommand GetEmailsCommand { get; }
        private void OnGetEmailsCommandExecuted(object p)
        {
            GetEmails();
        }
        private bool CanGetEmailsCommandExecute(object p)
        {
            return EmailsList == null;
        }

        #endregion

        #region Команда добавления адреса в список получателей

        public ICommand GetRecipientCommand { get; }
        private void OnGetRecipientCommandExecuted(object p)
        {
            RecipientList.Add(SelectedEmail);
            EmailsList.Remove(SelectedEmail);
            SelectedEmail = null;
        }
        private bool CanGetRecipientCommandExecute(object p)
        {
            return SelectedEmail != null;
        }

        #endregion

        #region Команда удаления адреса из списка получателей

        public ICommand RemoveRecipientCommand { get; }
        private void OnRemoveRecipientCommandExecuted(object p)
        {
            var tempEmail = SelectedRecipient;
            RecipientList.Remove(tempEmail);
            EmailsList.Add(tempEmail);
            SelectedRecipient = null;
        }
        private bool CanRemoveRecipientCommandExecute(object p)
        {
            return SelectedRecipient != null;
        }
        #endregion

        #region Команда очистки списка получателей

        public ICommand ClearRecipientCommand { get; }
        private void OnClearRecipientCommandExecuted(object p)
        {
            foreach (var item in RecipientList)
            {
                EmailsList.Add(item);
            }
            RecipientList.Clear();
            SelectedRecipient = null;
        }
        private bool CanClearRecipientCommandExecute(object p)
        {
            return RecipientList.Count != 0;
        }
        #endregion

        #region Команда очистки поля фильтра

        public ICommand ClearFilterCommand { get; }
        private void OnClearFilterCommandExecuted(object p)
        {
            EmailsFilterText = null;
        }
        private bool CanClearFilterCommandExecute(object p)
        {
            return EmailsFilterText != null;
        }
        #endregion
    }
}
