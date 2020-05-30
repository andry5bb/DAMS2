using System;

namespace DAMS.EventReminder.Notifier
{
    public struct EventInfo
    {
        public string EventName { get; }
        public DateTime EventDate { get; }


        public EventInfo(string eventName, DateTime eventDate)
        {
            EventName = eventName;
            EventDate = eventDate;
        }
    }
}
