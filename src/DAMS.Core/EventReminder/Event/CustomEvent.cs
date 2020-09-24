using Castle.Components.DictionaryAdapter;
using DAMS.EventReminder;
using DAMS.EventReminder.Event;
using DAMS.EventReminder.Notifier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DAMS.Models;

namespace DAMS.EventReminder
{
    // TODO: Refactor: extract logic responsible for calculation of the next event date to private method.
    //       Use this method wherever it could be used.
    //[Table("Name table")]

    public class CustomEvent : IEvent
    {
        private INotifier notifier;
       // private readonly DAMSDbContext dAMSDb;
        public IEnumerable<CustomEventDate> Dates { get; set; }
        public DateTime NextNotificationDate
        {
            get
            {
                DateTime nextNotification = new DateTime(); //db.MyEventsModels.Min(p => p.Date);
                return nextNotification;
            }
        }
        public string Name { get; set; }
        public TimeSpan NotifyBefore { get; set; }
        public EventStatus Status { get; set; }


        public CustomEvent(INotifier notifier, IEnumerable<DateTime> dates) // зачем нам конструктори?
        {
            this.notifier = notifier;
            Dates = (IEnumerable<CustomEventDate>)dates.ToDictionary((current) => current, (current) => EventStatus.Active);
            Name = "My Event";
            NotifyBefore = new TimeSpan(0, 5, 0);
            Status = EventStatus.Active;
        }

        public CustomEvent(INotifier notifier, IEnumerable<DateTime> dates, string name, TimeSpan time, EventStatus status)
        {
            this.notifier = notifier;
            Dates = (IEnumerable<CustomEventDate>)dates.ToDictionary((current) => current, (current) => EventStatus.Active);
            Name = name;
            NotifyBefore = time;
            Status = status;
        }


        public void Notify()
        {
            // Remove following line after GetNextEventDate() will be implemented.
            // DateTime nextEventDate = Dates.First(d => d.Value == EventStatus.Active).Key;
            DateTime nextEventDate = GetNextEventDate();

            var eventInfo = new NotificationInfo(Name, nextEventDate, "");
            NotificationResult notificationResult = notifier.Notify(eventInfo);
            UpdateStatus(notificationResult);
        }

        public void UpdateStatus(NotificationResult result)
        {
            foreach (IEnumerable<CustomEventDate> element in Dates)
            {
                if (element. == EventStatus.Active)
                {
                    if (result.IsSuccess == true)
                    {
                        Dates[element.Key] = EventStatus.Closed;
                    }
                    else
                    {
                        Dates[element.Key] = EventStatus.Failed;
                    }
                    break;
                }
                //}
            }

            private DateTime GetNextEventDate()
            {
                throw new NotImplementedException();
            }
        }
}
