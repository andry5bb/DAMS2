using DAMS.EventReminder.Event;
using DAMS.EventReminder.Notifier;
using System;

namespace DAMS.EventReminder
{
    public interface IEvent 
    {
        DateTime NextNotificationDate { get;} // EventDate - NotifyBefore 
        string Name { get; set; }
        TimeSpan NotifyBefore { get; set; }// зробити огранічений вибор 1 час 12 сасов і т.д.
        public EventStatus Status { get; set; } // ізміняти время івента
        void Notify();
        void UpdateStatus(NotificationResult result);
    }
}