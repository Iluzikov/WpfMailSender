using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using WpfMailSender.Commands;
using WpfMailSender.Data;
using WpfMailSender.Models;
using WpfMailSender.Services;
using WpfMailSender.ViewModels.Base;
using WpfMailSender.Views.UserControls;

namespace WpfMailSender.ViewModels
{
    [MarkupExtensionReturnType(typeof(WpfMailSenderViewModel))]
    internal class WpfMailSenderViewModel : ViewModelBase
    {
        #region Модели-представлений
        public EmailInfoViewModel EmailInfoVM { get; }
        public SaveEmailViewModel SaveEmailVM { get; }
        public MyTabSwitcherViewModel MyTabSwitcherVM { get; }
        public MailSettings mailSettings { get; set; } = new MailSettings();
        #endregion

        EmailSendServiceClass _sendService;
        SchedulerClass _scheduler;
        readonly DataAccessService _dataService = new DataAccessService();

        #region данные TabControl
        public int TabItemMax { get; private set; } = 3;
        private int _selectedTab = 0;
        public int SelectedTab
        {
            get => _selectedTab;
            set => Set(ref _selectedTab, value);
        }
        #endregion

        #region данные SMTP серверов
        private IEnumerable<Smtp> _smtpList;
        public IEnumerable<Smtp> SmtpList
        {
            get => _smtpList;
            set => Set(ref _smtpList, value);
        }

        private Smtp _selectedSmtp;
        public Smtp SelectedSmtp
        {
            get => _selectedSmtp;
            set => Set(ref _selectedSmtp, value);
        }
        #endregion

        #region Статус
        private string _status;
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
        #endregion

        public WpfMailSenderViewModel(
               EmailInfoViewModel emailInfoModel, 
               MyTabSwitcherViewModel myTabSwitcherViewModel,
               SaveEmailViewModel saveEmailViewModel)
        {
            EmailInfoVM = emailInfoModel;
            SaveEmailVM = saveEmailViewModel;
            emailInfoModel.MainVM = this;
            MyTabSwitcherVM = myTabSwitcherViewModel;
            myTabSwitcherViewModel.MainVM = this;
            GetSmtp();
            
            #region Команды
            CloseApplicationCommand = new RelayCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecut);
            SendAtOnceCommand = new RelayCommand(OnSendAtOnceCommandExecuted, CanSendAtOnceCommandExecut);
            #endregion

        }

        #region Команды

        #region Закрывает приложение
        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecut(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region Отправить сразу
        public ICommand SendAtOnceCommand { get; }

        private bool CanSendAtOnceCommandExecut(object p)
        {
            return SelectedSmtp != null && EmailInfoVM.RecipientList.Count != 0;
        }
        private void OnSendAtOnceCommandExecuted(object p)
        {
            SendMessage();
        }
        #endregion

        #endregion

        /// <summary>
        /// получить список SMTP серверов
        /// </summary>
        public void GetSmtp()
        {
            SmtpList = _dataService.GetSmtp();
        }

        /// <summary>
        /// Отправить сразу
        /// </summary>
        public void SendMessage()
        {
            if (IsFillError())
            {
                SelectedTab = 2;
                return;
            }
            AuthorizationWindow authWindow = new AuthorizationWindow();
            if (authWindow.ShowDialog() == true)
            {
                _sendService = new EmailSendServiceClass(SelectedSmtp, authWindow.authSettings, mailSettings);
                _sendService.SendMails(EmailInfoVM.RecipientList);
            }
        }

        /// <summary>
        /// Отправить запланированно
        /// </summary>
        /// <param name="emails"></param>
        /// <param name="selectedSmtp"></param>
        /// <param name="selectedSendDate"></param>
        /// <param name="selectedSendTime"></param>
        public void SendMessageLater(MailSettings mailSettings)
        {
            AuthorizationWindow authWindow = new AuthorizationWindow();
            _scheduler = new SchedulerClass();
            TimeSpan tsSendTime = _scheduler.GetSendTime(mailSettings.EmailDateTime.ToShortTimeString());
            if (tsSendTime == new TimeSpan())
            {
                MessageBox.Show("Некорректный формат даты", "ВНИМАНИЕ!");
                return;
            }
            DateTime dtSendDateTime = mailSettings.EmailDateTime.Date.Add(tsSendTime);
            if (dtSendDateTime < DateTime.Now)
            {
                MessageBox.Show("Дата и время отправления не могут быть раньше настоящего времени", "ВНИМАНИЕ!");
                return;
            }
            if (authWindow.ShowDialog() == true)
            {
                _sendService = new EmailSendServiceClass(SelectedSmtp, authWindow.authSettings, mailSettings);
                _sendService.SendMails(EmailInfoVM.RecipientList);
            }
        }
        
        /// <summary>
        /// Проверка заполнения полей сообщения
        /// </summary>
        /// <returns></returns>
        public bool IsFillError()
        {
            if (string.IsNullOrWhiteSpace(mailSettings.EmailText)
                || string.IsNullOrWhiteSpace(mailSettings.EmailSubject))
            {
                MessageBox.Show("Введите тему и текст сообщения", "Внимание!");
                return true;
            }
            return false;
        }

    }
}
