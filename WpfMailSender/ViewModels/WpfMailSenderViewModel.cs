﻿using System;
using System.Linq;
using System.Resources;
using System.Windows;
using WpfMailSender.Data;
using WpfMailSender.Models;
using WpfMailSender.Services;
using WpfMailSender.ViewModels.Base;

namespace WpfMailSender.ViewModels
{
    class WpfMailSenderViewModel : ViewModelBase
    {
        public MailSettings mailSettings { get; set; } = new MailSettings();
        EmailSendServiceClass _sendService;
        SchedulerClass _scheduler;
        
        /// <summary>
        /// Статус
        /// </summary>
        private string _status;
        public string Status 
        {
            get => _status;
            set => Set(ref _status, value);
        }

        public void SendMessage(IQueryable<Emails> emails, Smtp selectedSmtp)
        {
            if (IsFillError()) return;
            AuthorizationWindow authWindow = new AuthorizationWindow();
            if (authWindow.ShowDialog() == true)
            {
                _sendService = new EmailSendServiceClass(selectedSmtp, authWindow.authSettings, mailSettings);
                _sendService.SendMails(emails);
            }
        }

        public void SendMessageLater(IQueryable<Emails> emails, Smtp selectedSmtp, DateTime selectedSendDate, string selectedSendTime)
        {
            if (IsFillError()) return;
            AuthorizationWindow authWindow = new AuthorizationWindow();
            _scheduler = new SchedulerClass();
            TimeSpan tsSendTime = _scheduler.GetSendTime(selectedSendTime);
            if (tsSendTime == new TimeSpan())
            {
                MessageBox.Show("Некорректный формат даты", "ВНИМАНИЕ!");
                return;
            }
            DateTime dtSendDateTime = selectedSendDate.Add(tsSendTime);
            if (dtSendDateTime < DateTime.Now)
            {
                MessageBox.Show("Дата и время отправи не могут быть раньше настоящего времени", "ВНИМАНИЕ!");
                return;
            }
            if (authWindow.ShowDialog() == true)
            {
                _sendService = new EmailSendServiceClass(selectedSmtp, authWindow.authSettings, mailSettings);
                _sendService.SendMails(emails);
            }
        }

        public bool IsFillError()
        {
            if (string.IsNullOrWhiteSpace(mailSettings.EmailText)
                || string.IsNullOrWhiteSpace(mailSettings.EmailSubject))
            {
                MessageBox.Show("Введите адрес получателя и текст сообщения", "Внимание!");
                return true;
            }
            return false;
        }

    }
}
