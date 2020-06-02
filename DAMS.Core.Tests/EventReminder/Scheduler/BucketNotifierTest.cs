using DAMS.EventReminder.Event;
using DAMS.EventReminder.Notifier;
using System;
using System.Collections.Generic;
using System.Text;
using DAMS.EventReminder.Event;
using NUnit.Framework;
using DAMS.EventReminder.Scheduler;
using NUnit.Framework.Internal;
using DAMS.EventReminder;
using NSubstitute;

namespace DAMS.Core.Tests.EventReminder.Scheduler
{
    class BucketNotifierTest
    {
        /// <summary>
        /// System under test
        /// </summary>
        public BucketNotifier BucketNotifierInstance { get; set; }

        private INotifier _notifier;
        private DateTime _eventDate;

        [SetUp]
        public void Setup()
        {
            _notifier = Substitute.For<INotifier>();
            _eventDate = DateTime.Now;
            BucketNotifierInstance = new BucketNotifier();
        }

        [Test]
        public void NotifyForAll_should_do_notification_for_each_event_in_bucket()
        {
            //Arrange створюються змінні для того щоб виконати тестування
            var events = new List<IEvent>()
            {
                Substitute.For<IEvent>(),
                Substitute.For<IEvent>(),
                Substitute.For<IEvent>(),
            };
            var notificationBucket = new NotificationBucket(events);

            //Act  виконуються визначенні дії над системой
            BucketNotifierInstance.NotifyForAll(notificationBucket);

            //Assert очікуваний результат
            events.ForEach(e => e.Received(1).Notify());
        }
    }
}
