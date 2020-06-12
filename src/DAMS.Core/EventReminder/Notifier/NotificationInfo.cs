using DAMS.Helpers;
using System;

namespace DAMS.EventReminder.Notifier
{
    public class NotificationInfo
    {
        private string emailTest;
        public RegexValidator regexEmail = new RegexValidator();
        public string EventName { get; }
        public DateTime EventDate { get; }
        public string EmailRecipient
        {
            get
            {
                return emailTest;
            }
            set
            {
                if (regexEmail.RegExEmail(value) == true)
                {
                    emailTest = value;
                }
                if (regexEmail.RegExEmail(value) == false)
                {
                    throw new ArgumentException(String.Format("{0} Invalid email input format ", value), "email");
                }
            }
        }

        public NotificationInfo(string eventName, DateTime eventDate, string emailRecipient)
        {
            EventName = eventName;
            EventDate = eventDate;
            EmailRecipient = emailRecipient;
        }
    }
}