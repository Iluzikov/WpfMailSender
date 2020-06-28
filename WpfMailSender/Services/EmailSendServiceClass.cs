using CodePasswordDLL;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;
using System.Windows;
using WpfMailSender.EFData;
using WpfMailSender.Models;

namespace WpfMailSender.Services
{
    public class EmailSendServiceClass
    {
        private EFSmtp _smtp;
        private AuthSettings _auth;
        private MailSettings _mail;

        public EmailSendServiceClass(EFSmtp smtp, AuthSettings auth, MailSettings mail)
        {
            _smtp = smtp;
            _auth = auth;
            _mail = mail;
        }

        private void SendMail(string emailTo)
        {
            using (MailMessage mm = new MailMessage(_auth.EmailFrom, emailTo))
            {
                mm.Subject = _mail.EmailSubject;
                mm.Body = _mail.EmailText;
                mm.IsBodyHtml = false;

                using (SmtpClient sc = new SmtpClient(_smtp.Server, _smtp.Port))
                {
                    sc.EnableSsl = true;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new NetworkCredential(_auth.EmailFrom, CodePassword.GetPassword(_auth.Password));
                    try { sc.Send(mm); }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Возникла ошибка при отправке сообщения!\n{ex.Message}");
                    }
                }
            }
        }

        public void SendMails(ObservableCollection<EFEmail> emails)
        {
            foreach (EFEmail email in emails)
            {
                SendMail(email.Address);
            }
            MessageBox.Show("Сообщение отправлено");
        }

    }
}
