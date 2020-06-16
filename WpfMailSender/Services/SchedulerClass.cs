using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using WpfMailSender.Data;

namespace WpfMailSender.Services
{
    /// <summary>
    /// Класс планировщик, создает рассписание и следит за его выполнением
    /// Автоматизирует рассылку писем в соответствии с расписанием
    /// </summary>
    public class SchedulerClass
    {
        DispatcherTimer _timer = new DispatcherTimer();
        EmailSendServiceClass _emailSenderService;
        DateTime _dtSend;
        ObservableCollection<Emails> _emails;

        Dictionary<DateTime, string> _dicDates = new Dictionary<DateTime, string>();
        public Dictionary<DateTime, string> DatesEmailTexts
        {
            get => _dicDates;
            set
            {
                _dicDates = value;
                _dicDates = _dicDates.OrderBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }


        /// <summary>
        /// Конверирует строку из DateTimePicker в TimeSpan
        /// </summary>
        /// <param name="strSendTime"></param>
        /// <returns></returns>
        public TimeSpan GetSendTime(string strSendTime)
        {
            TimeSpan tsSendTime = new TimeSpan();
            try
            {
                tsSendTime = TimeSpan.Parse(strSendTime);
            }
            catch { }
            return tsSendTime;
        }

        /// <summary>
        /// Отправка писем
        /// </summary>
        /// <param name="dtSend"></param>
        /// <param name="emailSender"></param>
        /// <param name="emails"></param>
        public void SendEmails(DateTime dtSend, EmailSendServiceClass emailSender, ObservableCollection<Emails> emails)
        {
            _emailSenderService = emailSender;
            _dtSend = dtSend;
            _emails = emails;
            _timer.Tick += Timer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // метод изменен по методичке урок 4
            if(_dicDates.Count == 0)
            {
                _timer.Stop();
                MessageBox.Show("Письма отправлены");
            }
            else if( _dicDates.Keys.First<DateTime>().ToShortTimeString() == DateTime.Now.ToShortTimeString())
            {
                _emailSenderService.SendMails(_emails);
                _dicDates.Remove(_dicDates.Keys.First<DateTime>());
            }

            //if (_dtSend.ToShortTimeString() == DateTime.Now.ToShortTimeString())
            //{
            //    _emailSenderService.SendMails(_emails);
            //    _timer.Stop();
            //    MessageBox.Show("Письма отправлены");
            //}
        }


    }
}
