using System;

namespace DAMS.EventReminder
{
    public interface IEvent
    {
        public DateTime NextNotificationDate { get; set; }
    }
}