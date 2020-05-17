using System.Collections.Generic;

namespace DAMS.EventReminder
{
   public interface IScheduler
    {
        List<IEvent> PrepareNotificationBucket(IEnumerable<IEvent> events); 
    }
}
