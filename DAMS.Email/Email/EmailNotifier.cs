using System.Net;
using DAMS.EventReminder;
using DAMS.EventReminder.Notifier;
using System.Net.Mail;
using System.Configuration;

namespace DAMS.NotificationSystems.All.Email
{
    public class EmailNotifier : INotifier
    {
        public NotificationResult Notify(NotificationInfo eventInfo)
        {            
            var prepareSmtpClient = PrepareSmtpClient();
            NotificationResult result = new NotificationResult();
            try
            {
                prepareSmtpClient.Send(FormEmail(eventInfo));
                result.IsSuccess = true;
            }
            catch 
            {
                result.Details = "Error";
            }
            return result; 
        }

        private MailMessage FormEmail(NotificationInfo eventInfo)
        {
            string mailFrom = ConfigurationManager.AppSettings.Get("fromMailAddress");
            string from = ConfigurationManager.AppSettings.Get("NameAdmin");
            MailAddress fromMailAddress = new MailAddress(mailFrom, from);
            MailAddress toAddress = new MailAddress(eventInfo.EmailRecipient);
            MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress);
            mailMessage.Subject = "Нагадування про подію!";
            mailMessage.Body = eventInfo.EventName + eventInfo.EventDate; 
            mailMessage.IsBodyHtml = true;
            return mailMessage;
        }

        private SmtpClient PrepareSmtpClient()
        {
            string smtpHost = ConfigurationManager.AppSettings.Get("Host_smtp");
            string login = ConfigurationManager.AppSettings.Get("login");
            string password = ConfigurationManager.AppSettings.Get("password");
            var smtp = new SmtpClient
            {
                Host = smtpHost,
                Port = 25,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(login, password),
            };
            return smtp;
        }
    }
}