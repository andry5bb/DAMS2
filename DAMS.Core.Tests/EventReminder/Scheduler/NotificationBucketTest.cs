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

        [SetUp]
        public void Setup()
        {
           // _notifier = Substitute.For<INotifier>();   // Here is mock
           // _eventDate = DateTime.Now;

            NotificationBucketInstance = new NotificationBucket(events);
        }

        #region Add()

        [Test]
        public void Check_Method_Add_in_NotificationBucket ()
        {
            //Arrang створюються змінні для того щоб виконати тестування
            var _events = new List<IEvent>()
            {
                new OneTimeEvent (_notifier, DateTime.Now.AddMinutes(10).AddSeconds(60)),
                new OneTimeEvent (_notifier, DateTime.Now.AddMinutes(15).AddSeconds(50)),
                new OneTimeEvent (_notifier, DateTime.Now.AddMinutes(4).AddSeconds(40)),
                new OneTimeEvent (_notifier, DateTime.Now.AddMinutes(3).AddSeconds(40)),
            };

            //Act виконуються определенние действия над системой
            foreach (var item in _events)
            {
               NotificationBucketInstance.Add(item);
            }
           
            //Assert очікуваний результат
            NotificationBucketInstance.Should().NotBeNull();
            NotificationBucketInstance.NextEvents.Should().HaveCount(4);

        }
    
    #endregion
    #region Remove()
    [Test]
    public void Check_Method_Remove_in_NotificationBucket ()
    {
        //Arrang створюються змінні для того щоб виконати тестування
        var _events = new List<IEvent>()
            {
                new OneTimeEvent (_notifier, DateTime.Now.AddMinutes(10).AddSeconds(60)),
                new OneTimeEvent (_notifier, DateTime.Now.AddMinutes(15).AddSeconds(50)),
                new OneTimeEvent (_notifier, DateTime.Now.AddMinutes(4).AddSeconds(40)),
                new OneTimeEvent (_notifier, DateTime.Now.AddMinutes(3).AddSeconds(40)),
            };

        //Act виконуються определенние действия над системой
        foreach (var item in _events)
        {
            NotificationBucketInstance.Remove(item);
        }

        //Assert очікуваний результат
        NotificationBucketInstance.Should().NotBeNull();
        NotificationBucketInstance.NextEvents.Should().HaveCount(0);

    }
}
    #endregion
}
