namespace WpfMailSender
{
    public static class MailSettings
    {
        public static string smtpServer = "smtp.mail.ru";
        public static int smtpServerPort = 25;
        public static string emailFrom { get; set; }
        public static string EmailTo { get; set; }
        public static string Password { get; set; }

    }
}
