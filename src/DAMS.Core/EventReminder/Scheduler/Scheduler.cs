using System;
using System.Collections.Generic;
using System.Linq;

namespace DAMS.EventReminder.Scheduler
{
    public class Scheduler: IScheduler
    {
        public NotificationBucket PrepareNotificationBucket(IEnumerable<IEvent> events)
        {
            var now = DateTime.Now;
            var bucket = new NotificationBucket();

            foreach (var currentEvent in events)
            {
                TimeSpan left = currentEvent.NextNotificationDate - now;
                if (left.Minutes < 5 && left.Minutes >= 0 )
                {
                    bucket.NextEvents.Add(currentEvent);
                }
                bucket.Remove(events);
            }
            return bucket;
        }
    }
}
