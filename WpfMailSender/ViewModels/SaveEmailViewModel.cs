using System;
using System.Windows;
using System.Windows.Input;
using WpfMailSender.Commands;
using WpfMailSender.Data;
using WpfMailSender.Services;
using WpfMailSender.ViewModels.Base;

namespace WpfMailSender.ViewModels
{
    class SaveEmailViewModel : ViewModelBase
    {
        private string _emailName;
        public string EmailName
        {
            get => _emailName;
            set => Set(ref _emailName, value);
        }
        private string _emailAddress;
        public string EmailAddress
        {
            get => _emailAddress;
            set => Set(ref _emailAddress, value);
        }

        ViewModelLocator locator = new ViewModelLocator();
        Emails _emailInfo;
        public Emails EmailInfo
        {
            get => _emailInfo;
            set => Set(ref _emailInfo, value);
        }

        private readonly IDataAccessService _dataAccessService;

        public SaveEmailViewModel(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
            EmailInfo = new Emails();
            SaveEmailCommand = new RelayCommand(OnSaveEmailCommandExecuted, CanSaveEmailCommandExecut);
        }

        void SaveEmail()
        {
            int SaveResult = _dataAccessService.CreateEmail(EmailInfo);

            if (SaveResult != 0)
            {
                MessageBox.Show($"Email добавлен");
            }
            else MessageBox.Show($"Ошибка добавления Email");
        }

        #region Добавить Email
        public ICommand SaveEmailCommand { get; }

        private bool CanSaveEmailCommandExecut(object p)
        {
            return true;
        }
        private void OnSaveEmailCommandExecuted(object p)
        {
            SaveEmail();
        }
        #endregion

    }
}
