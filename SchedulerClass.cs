using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WpfMailSender
{
    /// <summary>
    /// Класс планировщик, создает рассписание и следит за его выполнением
    /// Автоматизирует рассылку писем в соответствии с расписанием
    /// </summary>
    class SchedulerClass
    {
        DispatcherTimer _timer = new DispatcherTimer();
        EmailSendServiceClass _emailSenderService;
        DateTime _dtSend;
        IQueryable<Emails> _emails;

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
        public void SendEmails(DateTime dtSend, EmailSendServiceClass emailSender, IQueryable<Emails> emails)
        {
            _emailSenderService = emailSender;
            _dtSend = dtSend;
            _emails = emails;
            _timer.Tick += Timer_Tick;
            _timer.Interval = new TimeSpan(0,0,1);
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(_dtSend.ToShortTimeString() == DateTime.Now.ToShortTimeString())
            {
                _emailSenderService.SendMails(_emails);
                _timer.Stop();
                MessageBox.Show("Письма отправлены");
            }
        }


    }
}
