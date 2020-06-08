using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace DAMS.EventReminder.Notifier
{
    public struct NotificationInfo
    {
        public string EventName { get; }
        public DateTime EventDate { get; }
        public string EmailRecipient { get; set; }



        public NotificationInfo(string eventName, DateTime eventDate, string emailRecipient)
        {
            EventName = eventName;
            EventDate = eventDate;
            // TODO : Add validation with regex
            EmailRecipient = emailRecipient;
        }
        public void RegEX (string emailRecipient)
        {
        //test:
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            // статичний метод IsMatch, який дозволяє перевірити вхідні рядок з шаблоном на відповідність:
            // Змінна pattern задає регулярний вираз для перевірки адреси електронної пошти.
            // Цей вираз пропонує нам Microsoft на сторінках msdn.
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("МЕТОД 2 Введiть адресу електронної пошти: ");
            //Console.ResetColor();
            emailRecipient = Console.ReadLine();
           
                if (Regex.IsMatch(emailRecipient, pattern, RegexOptions.IgnoreCase))
                {
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine("Email подтвержден");
                //Console.ResetColor();
                EmailRecipient = emailRecipient;
                }
                else
                {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный email");
                    //Console.ResetColor();
                }
            //goto test;
        }
    }
}
