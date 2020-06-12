﻿using System.Collections.ObjectModel;
using WpfMailSender.Data;

namespace WpfMailSender.Services
{
    public interface IDataAccessService
    {
        ObservableCollection<Emails> GetEmails();
    }
    public class DataAccessService : IDataAccessService
    {
        private DataEmailsDataContext _context;
        public DataAccessService()
        {
            _context = new DataEmailsDataContext();
        }
        public ObservableCollection<Emails> GetEmails()
        {
            ObservableCollection<Emails> EmailsList = new ObservableCollection<Emails>();
            foreach (var item in _context.Emails)
            {
                EmailsList.Add(item);
            }
            return EmailsList;
        }

        public ObservableCollection<Smtp> GetSmtp()
        {
            var SmtpList = new ObservableCollection<Smtp>();
            foreach (var item in _context.Smtp)
            {
                SmtpList.Add(item);
            }
            return SmtpList;
        }
    }
}
