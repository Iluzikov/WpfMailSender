﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using CodePasswordDLL;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMailSender
{
    public class EmailSendServiceClass
    {
        private Smtp _smtp;
        private AuthSettings _auth;
        private MailSettings _mail;

        public EmailSendServiceClass(Smtp smtp, AuthSettings auth, MailSettings mail)
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

        public void SendMails(IQueryable<Emails> emails)
        {
            foreach(Emails email in emails)
            {
                SendMail(email.Email);
            }
        }

    }
}
