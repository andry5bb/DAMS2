using DAMS.Helpers;
using System;
using System.Text.RegularExpressions;

namespace DAMS.EventReminder.Notifier
{
    public class NotificationInfo
    {
        public string EventName { get; }
        public DateTime EventDate { get; }
        private string emailTest;
        public RegexValidator regex = new RegexValidator();
        public string EmailRecipient
        {
            get
            {
                return emailTest;
            }
            set
            {
                if (regex.RegEx(value) == true)
                {
                    emailTest = value;
                }
                if (regex.RegEx(value) == false)
                {
                    //throw new ArgumentException("email");
                    //var user = GetUse(value);
                    throw new ArgumentException(String.Format("{0} Invalid email input format ", value), "email");
                    //System.ArgumentException argEx = new System.ArgumentException("Index is out of range", "index", e);
                    //throw argEx;
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
