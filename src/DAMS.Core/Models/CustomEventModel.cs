using DAMS.EventReminder;
using DAMS.EventReminder.Event;
using DAMS.EventReminder.Notifier;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAMS.Models
{
    public class CustomEventModel :IEvent
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual TimeSpan NotifyBefore { get ; set ; }
        public virtual EventStatus Status { get ; set ; }
        public virtual IEnumerable<CustomEventDate> MyEventModels { get; set; }
        public DateTime NextNotificationDate => DateTime.MinValue;
        public void Notify()
        {
        }

        public void UpdateStatus(NotificationResult result)
        {
        }
    }
}
