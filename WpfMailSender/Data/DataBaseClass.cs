using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.Data
{
    public static class DataBaseClass
    {
        private static DataEmailsDataContext _emails = new DataEmailsDataContext();
        public static IQueryable<Emails> DBEmails
        {
            get
            {
                return _emails.Emails.Select(c => c);
            }
        }

        private static DataEmailsDataContext _smtpServers = new DataEmailsDataContext();

        public static IQueryable<Smtp> DBSmtp
        {
            get
            {
                return _smtpServers.Smtp.Select(c => c);
            }
        }

        private static DataEmailsDataContext _senders = new DataEmailsDataContext();

        public static IQueryable<Sender> DBSenders
        {
            get
            {
                return _senders.Sender.Select(c => c);
            }
        }
    }
}
