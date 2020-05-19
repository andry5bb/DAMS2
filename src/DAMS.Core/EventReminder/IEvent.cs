using DAMS.EventReminder.Event;
using DAMS.EventReminder.Notifier;
using System;

namespace DAMS.EventReminder
{
    public interface IEvent 
    {         
        DateTime NextNotificationDate { get;}
        string Name { get; set; }
        TimeSpan NotifyBefore { get; set; }       
        public EventStatus Status { get; set; }
        void Notify();
        void UpdateStatus(NotificationResult result);
    }
}