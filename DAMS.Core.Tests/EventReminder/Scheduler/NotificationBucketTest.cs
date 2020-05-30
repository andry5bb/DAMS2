using System;
using System.Collections.Generic;
using DAMS.EventReminder;
using DAMS.EventReminder.Event;
using DAMS.EventReminder.Scheduler;
using FluentAssertions;
using NUnit.Framework;

namespace DAMS.Core.Tests.EventReminder.Scheduler
{
    class NotificationBucketTest
    {
        public NotificationBucket NotificationBucketInstance { get; set; }

        private INotifier _notifier;
        private DateTime _eventDate;
        private IEnumerable<IEvent> events;

        #region Add()

        [Test]
        public void Check_Method_Add_in_NotificationBucket()
        {
            //Arrang створюються змінні для того щоб виконати тестування
            var events = new List<IEvent>()
            {
                new OneTimeEvent (_notifier, DateTime.Now.AddMinutes(10).AddSeconds(60)),
                new OneTimeEvent (_notifier, DateTime.Now.AddMinutes(15).AddSeconds(50)),
                new OneTimeEvent (_notifier, DateTime.Now.AddMinutes(4).AddSeconds(40)),
                new OneTimeEvent (_notifier, DateTime.Now.AddMinutes(3).AddSeconds(40)),
            };
            NotificationBucketInstance = new NotificationBucket(events);

            var evented = new OneTimeEvent(_notifier, DateTime.Now.AddMinutes(10).AddSeconds(60));

            //Act виконуються определенние действия над системой           
            NotificationBucketInstance.Add(evented);


            //Assert очікуваний результат
            NotificationBucketInstance.Should().NotBeNull();
            NotificationBucketInstance.NextEvents.Should().HaveCount(5);

        }

        #endregion
        #region Remove()
        [Test]
        public void Check_Method_Remove_in_NotificationBucket()
        {
            //Arrang створюються змінні для того щоб виконати тестування
            var eventTest = new OneTimeEvent(_notifier, new DateTime(2000, 12, 10));
            var events = new List<IEvent>()
            {
                eventTest,
                new OneTimeEvent (_notifier, new DateTime(2000,12,10)),
                new OneTimeEvent (_notifier, DateTime.Now.AddMinutes(15).AddSeconds(50)),
            };
            NotificationBucketInstance = new NotificationBucket(events);
           

            //Act виконуються определенние действия над системой           
            NotificationBucketInstance.Remove(eventTest);


            //Assert очікуваний результат
            NotificationBucketInstance.Should().NotBeNull();
            NotificationBucketInstance.NextEvents.Should().HaveCount(2);

        }
    }
    #endregion
}
