using DAMS.EventReminder.Notifier;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAMS.EventReminder.Event
{
    class PeriodEvent : IEvent
    {
        public DateTime Date { get; set; }
        public PeriodType PeriodType { get; set; }
        public DateTime NextNotificationDate { get; set; }
        public string Name { get; set; }
        public TimeSpan NotifyBefore { get; set; }
        public INotifier Notifier { get; set; }
        public EventStatus Status { get; set; }


        public PeriodEvent(INotifier notifier, DateTime date, PeriodType period)
        {
            Notifier = notifier;
            Status = EventStatus.Active;
            PeriodType = period;
            Date = date;
        }

        public void Notify()
        {
            Notifier.Notify();
        }

        public void UpdateStatus(NotificationResult result)
        {
            if (result.IsSuccess == true)
            {
                Status = EventStatus.Closed;
            }
            if (result.IsSuccess == false)
            {
                Status = EventStatus.Failed;
            }
        }
    }
}
