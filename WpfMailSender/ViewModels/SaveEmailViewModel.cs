using System.Windows.Input;
using WpfMailSender.Commands;
using WpfMailSender.EFData;
using WpfMailSender.ViewModels.Base;

namespace WpfMailSender.ViewModels
{
    class SaveEmailViewModel : ViewModelBase
    {
        ViewModelLocator locator = new ViewModelLocator();
        EFEmail _emailInfo;
        public EFEmail EmailInfo
        {
            get => _emailInfo;
            set => Set(ref _emailInfo, value);
        }

        public SaveEmailViewModel()
        {
            EmailInfo = new EFEmail();
            SaveEmailCommand = new RelayCommand(OnSaveEmailCommandExecuted, CanSaveEmailCommandExecut);
        }

        /// <summary>
        /// Сохранить Email
        /// </summary>
        void SaveEmail()
        {
            locator.EmailInfoModel.AddEmailAddress(EmailInfo);
            EmailInfo = null;
        }

        #region Комманда добавить Email
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
