using System.Collections.ObjectModel;
using WpfMailSender.Data;

namespace WpfMailSender.Services
{
    //public interface IDataAccessService
    //{
    //    ObservableCollection<Emails> GetEmails();
    //}
    class DataAccessService
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
    }
}
