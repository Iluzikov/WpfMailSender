using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<Emails> _emailsList;
        public ObservableCollection<Emails> EmailsList
        {
            get => _emailsList;
            set => Set(ref _emailsList, value);
        }

        public EmailInfoViewModel(IDataAccessService dataService)
        {
            _dataAccessService = dataService;
            GetEmailsCommand = new RelayCommand(OnGetEmailsCommandExecuted, CanGetEmailsCommandExecute);
        }

        /// <summary>
        /// Получает список E-mail адресов через класс-сервис
        /// </summary>
        void GetEmails()
        {
            EmailsList = _dataAccessService.GetEmails();
        }

        #region Команды получения списка Email

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
    }
}
