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
        /// <summary>
        /// System under test
        /// </summary>

        public NotificationBucket NotificationBucketInstance { get; set; }

        private INotifier _notifier;

        #region Add()

        [Test]
        public void Add_should_add_new_event()
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

            var newEvent = new OneTimeEvent(_notifier, DateTime.Now.AddMinutes(10).AddSeconds(60));

            //Act виконуються определенние действия над системой
            NotificationBucketInstance.Add(newEvent);

            //Assert очікуваний результат
            NotificationBucketInstance.Should().NotBeNull();
            NotificationBucketInstance.NextEvents.Should().HaveCount(5);
            NotificationBucketInstance.NextEvents.Should().Contain(events);
        }

        #endregion
        #region Remove()
        [Test]
        public void Remove_should_remove_old_event()
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

            //Act виконуються визначенні дії над системой
            NotificationBucketInstance.Remove(eventTest);

            //Assert очікуваний результат
            NotificationBucketInstance.Should().NotBeNull();
            NotificationBucketInstance.NextEvents.Should().HaveCount(2);
            NotificationBucketInstance.NextEvents.Should().NotContain(eventTest);
        }
    }
    #endregion
}
