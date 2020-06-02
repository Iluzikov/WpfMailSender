using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMailSender
{
    public class EmailSendServiceClass
    {
        
        public void SendMail(SmtpSettings strSmtpSettings, AuthSettings strAuthSettings, MailSettings strMailSettings)
        {
            using (MailMessage mm = new MailMessage(strAuthSettings.EmailFrom, strMailSettings.EmailTo))
            {
                mm.Subject = strMailSettings.EmailSubject;
                mm.Body = strMailSettings.EmailText;
                mm.IsBodyHtml = false;

                using (SmtpClient sc = new SmtpClient(strSmtpSettings.SmtpServer, strSmtpSettings.SmtpServerPort))
                {
                    sc.EnableSsl = true;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new NetworkCredential(strAuthSettings.EmailFrom, strAuthSettings.Password);
                    try { sc.Send(mm); }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Возникла ошибка при отправке сообщения!\n{ex.Message}");
                    }
                }
            }
        }
    }
}
