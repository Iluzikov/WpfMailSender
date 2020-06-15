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
        private Emails _newEmail;
        public Emails NewEmail
        {
            get => _newEmail;
            set => Set(ref _newEmail, value);
        }

        private readonly IDataAccessService _dataAccessService;

        public SaveEmailViewModel(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
            SaveEmailCommand = new RelayCommand(OnSaveEmailCommandExecuted, CanSaveEmailCommandExecut);
        }

        void SaveEmail()
        {
            int SaveResult = _dataAccessService.CreateEmail(NewEmail);
            if (SaveResult > 0) MessageBox.Show($"Email добавлен");
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
