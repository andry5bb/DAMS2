using System;
using System.Net;
using DAMS.EventReminder;
using DAMS.EventReminder.Notifier;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;
using EO.Internal;
using DAMS.EventReminder.Event;
using System.Configuration;
using System.Collections.Specialized;

// 3 окремий приватний метод припеа емейл баді(контент) в 
//якому буде міститися логіка як робиться мейл контент (знайти шаблом email event notification template)
//знайти html шаблон і змінити в ньому 2-3 місця (ім'я, дату і т.д.)

namespace DAMS.NotificationSystems.All.Email
{  
    public class EmailNotifier : INotifier
    {
        public NotificationResult Notify(NotificationInfo eventInfo)
        {
            string mailFrom = ConfigurationManager.AppSettings.Get("fromMailAddress");
            // відправник - встановлюємо адресу і відображається в листі ім'я
            MailAddress fromMailAddress = new MailAddress(mailFrom);
            // кому відправляємо
            MailAddress toAddress = new MailAddress(eventInfo.EmailRecipient);
            // створюємо об'єкт повідомлення
            MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress);
            // Тема листа
            mailMessage.Subject = "Нагадування про подію!";
            // текст листа
            mailMessage.Body = eventInfo.EventName + eventInfo.EventDate; // окремий приватний метод припеа емейл баді(контент) в 
            //якому буде міститися логіка як робиться мейл контент (знайти шаблом email event notification template)
            //знайти html шаблон і змінити в ньому 2-3 місця (ім'я, дату і т.д.)
            // лист представляє код html / прапор використання html
            mailMessage.IsBodyHtml = true;
            // вкладений файл
            //mailMessage.Attachments.Add(new Attachment("C:/Users/Андрей/Desktop"));
            string smtpHost = ConfigurationManager.AppSettings.Get("Host_smtp");
            string login = ConfigurationManager.AppSettings.Get("login");
            string password = ConfigurationManager.AppSettings.Get("password");
            // адрес smtp-сервера і порт, з якого будемо відправляти повідомлення
            var smtp = new SmtpClient
            {
                Host = smtpHost,
                Port = 25,
                //встановлюємо при необхідності SSL
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                // логін та пароль
                Credentials = new NetworkCredential(login, password),
            };
            NotificationResult result = new NotificationResult();
            //спроба відправки повідомлення
            try
            {
                smtp.Send(mailMessage);
                // якщо вдало, то встановлюємо статус
                result.IsSuccess = true;
            }
            catch 
            {
                result.Details = "Error";
            }
            return result; 
        } 
    }
}