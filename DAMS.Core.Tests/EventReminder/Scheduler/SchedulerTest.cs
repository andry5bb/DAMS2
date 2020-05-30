﻿using System;
using System.Collections.Generic;
using DAMS.EventReminder;
using NUnit.Framework;
using SchedulerNS = DAMS.EventReminder.Scheduler;
using DAMS.EventReminder.Scheduler;
using DAMS.EventReminder.Event;
using FluentAssertions;
using NSubstitute;

namespace DAMS.Core.Tests.EventReminder.Scheduler
{
    public class SchedulerTest
    {

        public SchedulerNS.Scheduler Scheduler { get; set; }

        private INotifier _notifier;
        private DateTime _eventDate;
        [SetUp]
        public void Setup()
        {
            _notifier = Substitute.For<INotifier>();   // Here is mock
            _eventDate = DateTime.Now;

            Scheduler = new SchedulerNS.Scheduler();
        }

        [Test]
        public void PrepareNotificationBucket_should_sort_all_events_and_add_needed_event_in_a_new_bucket()
        {

            // Arrange
            var events = new List<IEvent>()
            {
              new OneTimeEvent (_notifier,new DateTime(2020,05,30,14,17,00)),
              new OneTimeEvent (_notifier,new DateTime(2020,05,30,23,10,10)),
            };
           // public NotificationBucket result => results as List<IEvent>;

            //Act 
            NotificationBucket result = Scheduler.PrepareNotificationBucket(events);
            
            //Assert
            result.Should().NotBeNull();
            result.NextEvents.Should().HaveCount(1);
        }

    }
}
