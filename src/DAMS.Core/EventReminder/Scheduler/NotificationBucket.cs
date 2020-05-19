using System;
using System.Collections.Generic;

namespace DAMS.EventReminder.Scheduler
{
    public class NotificationBucket
    {
        public IEnumerable<IEvent> NextEvents { get; set; }

        internal void Add(IEvent currentEvent)
        {
            throw new NotImplementedException();
        }

        //public NotificationBucket (IEnumerable<IEvent> nextEvent)
        //{
        //    NextEvents = nextEvent;
        //}
    }
}
