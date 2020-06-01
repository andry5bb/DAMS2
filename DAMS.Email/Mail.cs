using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;

namespace DAMS.Email
{
    class Mail
    {
        static void Main(string[] args)
        {
            // відправник - встановлюємо адресу і відображається в листі ім'я
            MailAddress from = new MailAddress("dams.notifier@gmail.com", "Admin");
            // кому відправляємо
            MailAddress to = new MailAddress("andry5bb@gmail.com");
            // створюємо об'єкт повідомлення
            MailMessage m = new MailMessage(from, to);
            // Тема листа
            m.Subject = "Notification about event";
            // текст листа
            m.Body = "<h2>У Мішки завтра день народження! </h2>";
            // лист представляє код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера і порт, з якого будемо відправляти повідомлення
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25);
            // логін та пароль
            smtp.Credentials = new NetworkCredential("dams.notifier@gmail.com", "DAMS2020");
            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.Read();
        }
    }
}
