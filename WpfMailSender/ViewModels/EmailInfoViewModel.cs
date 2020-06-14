using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
                if(!Set(ref _emailsFilterText, value)) return;
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

        #region Выбранный адрес
        private Emails _selectedEmail;
        public Emails SelectedEmail
        {
            get => _selectedEmail;
            set => Set(ref _selectedEmail, value);
        }
        #endregion

        public EmailInfoViewModel(IDataAccessService dataService)
        {
            _dataAccessService = dataService;
            RecipientList = new ObservableCollection<Emails>();
            GetEmailsCommand = new RelayCommand(OnGetEmailsCommandExecuted, CanGetEmailsCommandExecute);
            GetRecipientCommand = new RelayCommand(OnGetRecipientCommandExecuted, CanGetRecipientCommandExecute);
            _emailsListCollections.Filter += OnEmailFiltered;
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
            return true;
        }

        #endregion

        #region Команда добавления адреса в список получателей

        public ICommand GetRecipientCommand { get; }
        private void OnGetRecipientCommandExecuted(object p)
        {
            RecipientList.Add(SelectedEmail);
        }
        private bool CanGetRecipientCommandExecute(object p)
        {
            return SelectedEmail != null;
        }

        #endregion
    }
}
