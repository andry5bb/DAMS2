using System;
using System.Collections.Generic;

namespace DAMS.EventReminder.Scheduler
{
    public class Scheduler: IScheduler
    {
        public List<IEvent> PrepareNotificationBucket(IEnumerable<IEvent> events)
        {           
            var now = DateTime.Now;
            List<IEvent> notificationBucket = new List<IEvent>();

            foreach (var currentEvent in events)
            {
                TimeSpan left = currentEvent.NextNotificationDate - now;               
                if (left.Minutes < 5 && left.Minutes >= 0 )
                {
                     notificationBucket.Add(currentEvent);                  
                }
            }
            return notificationBucket;
        }       
    }
}
