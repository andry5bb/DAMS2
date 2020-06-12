using System;
using System.Net;
using DAMS.EventReminder;
using DAMS.EventReminder.Notifier;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;
using DAMS.EventReminder.Event;
using System.Configuration;
using System.Collections.Specialized;
using DAMS.NotificationSystems.All.Email;
using Newtonsoft.Json;

// 3 окремий приватний метод припеа емейл баді(контент) в 
//якому буде міститися логіка як робиться мейл контент (знайти шаблом email event notification template)
//знайти html шаблон і змінити в ньому 2-3 місця (ім'я, дату і т.д.)

namespace DAMS.NotificationSystems.All.Email
{  
    public class EmailNotifier : INotifier
    {
        public NotificationResult Notify(NotificationInfo eventInfo)
        {            
            var a = PrepareSmtpClient();
            NotificationResult result = new NotificationResult();
            try
            {
                a.Send(FormEmail(eventInfo));
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
            string NameNotifier = ConfigurationManager.AppSettings.Get("NameAdmin");
            MailAddress fromMailAddress = new MailAddress(mailFrom, NameNotifier);
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