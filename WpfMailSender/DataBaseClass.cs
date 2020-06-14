using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender
{
    public static class DataBaseClass
    {
        private static DataBaseDataContext _emails = new DataBaseDataContext();
        public static IQueryable<Emails> DBEmails
        {
            get
            {
                return _emails.Emails.Select(c => c);
            }
        }

        private static DataBaseDataContext _smtpServers = new DataBaseDataContext();

        public static IQueryable<Smtp> DBSmtp
        {
            get
            {
                return _smtpServers.Smtp.Select(c => c);
            }
        }
    }
}
