using System.Collections.Generic;
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

        //DataAccessService _dbAccessService;
        private readonly IDataAccessService _dataAccessService;

        private IEnumerable<Emails> _emailsList;
        public IEnumerable<Emails> EmailsList
        {
            get => _emailsList;
            set => Set(ref _emailsList, value);
        }

        public EmailInfoViewModel(IDataAccessService dataService)
        {
            _dataAccessService = dataService;
            GetEmailsCommand = new RelayCommand(OnGetEmailsCommandExecuted, CanGetEmailsCommandExecute);
        }

        void GetEmails()
        {
            EmailsList = _dataAccessService.GetEmails();
        }

        #region Команды

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
