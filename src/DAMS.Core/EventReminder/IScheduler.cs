using DAMS.EventReminder.Scheduler;
using System.Collections.Generic;

namespace DAMS.EventReminder
{
   public interface IScheduler
    {
       public NotificationBucket PrepareNotificationBucket(IEnumerable<IEvent> events);
        
    }
}
