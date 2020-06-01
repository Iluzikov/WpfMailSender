using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender
{
    public class EmailSendServiceClass
    {
        public List<SmtpSettings> smtpSettings;
        public MailSettings mailSettings;
        public AuthSettings authSettings;
        public EmailSendServiceClass()
        {
            smtpSettings = new List<SmtpSettings>
            {
                new SmtpSettings { Name = "Mail", SmtpServer = "smtp.mail.ru", SmtpServerPort = 465 },
                new SmtpSettings { Name = "Yandex",SmtpServer = "smtp.yandex.ru", SmtpServerPort = 465 },
                new SmtpSettings { Name = "Google",SmtpServer = "smtp.gmail.com", SmtpServerPort = 465 }
            };

            mailSettings = new MailSettings();
        }

        public void SendMail(SmtpSettings strSmtpSettings, string strMailFrom, string strMailTo, string strSubject, string strBody)
        {
            using (MailMessage mm = new MailMessage(strMailFrom, strMailTo))
            {
                mm.Subject = strSubject;
                mm.Body = strBody;
                mm.IsBodyHtml = false;

                using (SmtpClient sc = new SmtpClient(strSmtpSettings.SmtpServer, strSmtpSettings.SmtpServerPort))
                {
                    sc.EnableSsl = true;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new NetworkCredential(authSettings.EmailFrom, authSettings.Password);
                    try { sc.Send(mm); }
                    catch (Exception ex)
                    {
                        //MessageBox.Show($"Возникла ошибка при отправке сообщения!\n{ex.Message}");
                    }
                }
            }
        }
    }
}
