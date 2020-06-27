using System;
using System.Windows;
using System.Windows.Input;
using WpfMailSender.Commands;
using WpfMailSender.Data;
using WpfMailSender.EFData;
using WpfMailSender.Services;
using WpfMailSender.ViewModels.Base;

namespace WpfMailSender.ViewModels
{
    class SaveEmailViewModel : ViewModelBase
    {
        //private string _emailName;
        //public string EmailName
        //{
        //    get => _emailName;
        //    set => Set(ref _emailName, value);
        //}
        //private string _emailAddress;
        //public string EmailAddress
        //{
        //    get => _emailAddress;
        //    set => Set(ref _emailAddress, value);
        //}

        ViewModelLocator locator = new ViewModelLocator();
        EFEmail _emailInfo;
        public EFEmail EmailInfo
        {
            get => _emailInfo;
            set => Set(ref _emailInfo, value);
        }


        public SaveEmailViewModel(IDataAccessService dataAccessService)
        {
            EmailInfo = new EFEmail();
            SaveEmailCommand = new RelayCommand(OnSaveEmailCommandExecuted, CanSaveEmailCommandExecut);
        }

        void SaveEmail()
        {
            locator.EmailInfoModel.AddEmailAddress(EmailInfo);
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
