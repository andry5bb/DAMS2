using System.Collections.Generic;

namespace DAMS.EventReminder
{
    interface IScheduler
    {
        void PrepareNotificationBucket(IEnumerable<IEvent> events);
    }
}
