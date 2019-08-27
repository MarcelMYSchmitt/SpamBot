using SpamBot.Configuration;
using System;
using System.Net.Mail;
using System.Text;

namespace SpamBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Have fun sending mails!");
            Console.WriteLine("But first let me take....uah load environment variables...");

            var configurationProvider = new ConfigurationProvider().CreateConfiguration();
            var emailSender = configurationProvider[ConfigurationKeys.EmailSender];
            var emailReceiver = configurationProvider[ConfigurationKeys.EmailReceiver];
            var emailSubject = configurationProvider[ConfigurationKeys.EmailSubject];
            var emailContent = configurationProvider[ConfigurationKeys.EmailContent];
            var amountEmailsToSend = int.Parse(configurationProvider[ConfigurationKeys.AmountEmailsToSend]);
            var smtpClientPort = int.Parse(configurationProvider[ConfigurationKeys.SmtpClientPort]);
            var smtpClientHost = configurationProvider[ConfigurationKeys.SmtpClientHost];
            var emailUserName = configurationProvider[ConfigurationKeys.EmailUserName];
            var emailUserPassword = configurationProvider[ConfigurationKeys.EmailUserPassword];


            var smtpClient = new SmtpClient
            {
                Port = smtpClientPort,
                Host = smtpClientHost,
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(emailUserName, emailUserPassword)
            };

            var mail = new MailMessage($"{emailSender}", $"{emailReceiver}", $"{emailSubject}", $"{emailContent}")
            {
                BodyEncoding = UTF8Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };

            for (int i=1; i<= amountEmailsToSend; i++)
            {
                smtpClient.Send(mail);
                Console.WriteLine($"Sent {i} mails to {mail.To}.");
            }

            Console.WriteLine("Hope you had fun sending mails!");
        }
    }
}
