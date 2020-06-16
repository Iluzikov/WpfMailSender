using System.Collections.ObjectModel;
using System.Linq;
using WpfMailSender.Data;

namespace WpfMailSender.Services
{
    public interface IDataAccessService
    {
        ObservableCollection<Emails> GetEmails();
        int CreateEmail(Emails email);
        int CreateSmtp(Smtp smtp);
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
    
        public int CreateEmail(Emails email)
        {
            if (_context.Emails.Contains(email)) return email.Id;
            _context.Emails.InsertOnSubmit(email);
            _context.SubmitChanges();
            return email.Id;
        }
        public int CreateSmtp(Smtp smtp)
        {
            if (_context.Smtp.Contains(smtp)) return smtp.Id;
            _context.Smtp.InsertOnSubmit(smtp);
            _context.SubmitChanges();
            return smtp.Id;
        }
    }
}
