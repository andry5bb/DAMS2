using DAMS.EventReminder.Event;
using DAMS.EventReminder.Notifier;
using System;

namespace DAMS.EventReminder
{
    public interface IEvent
    {
        DateTime NextNotificationDate { get; set; }
        string Name { get; set; }
        TimeSpan NotifyBefore { get; set; }
        INotifier Notifier { get; set; }
        static EventStatus Status { get; set; }


        void Notify();
        void UpdateStatus(NotificationResult result);
    }
}