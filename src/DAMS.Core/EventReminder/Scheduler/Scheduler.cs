using System;
using System.Collections.Generic;

namespace DAMS.EventReminder.Scheduler
{
    public class Scheduler: IScheduler
    { 
      public NotificationBucket PrepareNotificationBucket(IEnumerable<IEvent> events)
      {
            var now = DateTime.Now;
            NotificationBucket bucket = new NotificationBucket();

            foreach (var currentEvent in events)
            {
                TimeSpan left = currentEvent.NextNotificationDate - now;               
                if (left.Minutes < 5 && left.Minutes >= 0)
                {
                     bucket.Add(currentEvent);                  
                }
            }           
                 return bucket;
      }

    }
}

