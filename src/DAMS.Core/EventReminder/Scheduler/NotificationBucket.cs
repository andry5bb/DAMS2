﻿using System.Collections.Generic;

namespace DAMS.EventReminder.Scheduler
{
    public class NotificationBucket
    {
        private List<IEvent> _events = new List<IEvent>(); 
        
        public IEnumerable<IEvent> NextEvents => _events as IEnumerable<IEvent>;


        public NotificationBucket(IEnumerable<IEvent> events)
        {
            _events = new List<IEvent>(events); 
        }
        public NotificationBucket()
        {

        }


        public void Remove(IEvent @event)
        {
            _events.Remove(@event);
        }

        public void Add(IEvent @event)
        {
            _events.Add(@event);
        }
    }
}
