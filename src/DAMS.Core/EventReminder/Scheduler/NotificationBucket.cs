using System;
using System.Collections.Generic;
using System.Linq;

namespace DAMS.EventReminder.Scheduler
{
    public class NotificationBucket
    {
        public List<IEvent> NextEvents { get; set; }

        public IEnumerable<IEvent> Remove(IEnumerable<IEvent> @event)
        {
            var testEv = @event.ToList<IEvent>();
            foreach (var item in testEv)
            {
                if (item.Status == Event.EventStatus.Closed)
                {
                    testEv.Remove(item);
                }
            }
            return testEv;
        }
    }
}
