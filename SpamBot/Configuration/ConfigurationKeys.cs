namespace SpamBot.Configuration
{
    public static class ConfigurationKeys
    {
        public static readonly string EmailSender = "EmailSender";
        public static readonly string EmailReceiver = "EmailReceiver";
        public static readonly string EmailSubject = "EmailSubject";
        public static readonly string EmailContent = "EmailContent";
        public static readonly string AmountEmailsToSend = "AmountEmailsToSend";

        public static readonly string SmtpClientPort = "SmtpClientPort";
        public static readonly string SmtpClientHost = "SmtpClientHost";

        public static readonly string EmailUserName = "EmailUserName";
        public static readonly string EmailUserPassword = "EmailUserPassword";
    }
}