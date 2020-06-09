using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WpfMailSender.Data;
using WpfMailSender.Services;
using WpfMailSender.ViewModels.Base;

namespace WpfMailSender.ViewModels
{
    class EmailInfoViewModel : ViewModelBase
    {
        private WpfMailSenderViewModel MainVM { get; }
        DataAccessService _dbAccessService;

        private IEnumerable<Emails> _emailsList;
        public IEnumerable<Emails> EmailsList
        {
            get => _emailsList;
            set => Set(ref _emailsList, value);
        }

        public EmailInfoViewModel(WpfMailSenderViewModel MainVM)
        {
            this.MainVM = MainVM;

            _dbAccessService = new DataAccessService();
            GetEmails();
        }

        void GetEmails()
        {
            EmailsList = _dbAccessService.GetEmails();
            
        }
    }
}
