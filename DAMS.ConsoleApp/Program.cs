using DAMS.EntityFrameworkCore;
using DAMS.EventReminder;
using DAMS.EventReminder.Event;
using DAMS.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using Terminal.Gui;

namespace DAMS.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InitApp();
            Application.Run();
        }

        static void InitApp()
        {
            Application.Init();
            var top = Application.Top;

            using (DAMSDbContext db = new DAMSDbContext())
            {
                #region OneTimeEvent
                var oneTimeEvent1 = new OneTimeEvent () { Date = new DateTime(2020, 07, 20, 23, 23, 00), Name = "ДР Андрюхи", Status = EventStatus.Active, 
                NotifyBefore = new TimeSpan(0, 5, 0) };
                db.OneTimeEvents.Add(oneTimeEvent1);
                db.SaveChanges();
                #endregion

                #region PeriodEvent
                var periodEvent1 = new PeriodEvent () { Date = new DateTime(2020, 08, 08, 15, 23, 00), Name = "ДР когось", NotifyBefore = new TimeSpan(24, 0, 0), 
                Status = EventStatus.Active, PeriodType = PeriodType.Yearly };
                db.PeriodEvents.Add(periodEvent1);
                db.SaveChanges();
                #endregion

                #region CustomEventModel
                var customEventModel1 = new CustomEventModel
                {
                    Name = "Поход на турнік",
                    Status = EventStatus.Active,
                    NotifyBefore = new TimeSpan(24, 0, 0)
                };
                db.CustomEventModels.Add(customEventModel1);
                db.SaveChanges();

                var myEventsModel1 = new CustomEventDate 
                {
                Date = new DateTime(2020, 07, 01, 12, 25, 00),
                Status = EventStatus.Active,
                CustomEventModel = customEventModel1
                };
                var myEventsModel2 = new CustomEventDate
                {
                    Date = new DateTime(2020, 07, 02, 12, 25, 00),
                    Status = EventStatus.Active,
                    CustomEventModel = customEventModel1
                };
                var myEventsModel3 = new CustomEventDate
                {
                    Date = new DateTime(2020, 07, 03, 12, 25, 00),
                    Status = EventStatus.Active,
                    CustomEventModel = customEventModel1
                };
                var myEventsModel4 = new CustomEventDate
                {
                    Date = new DateTime(2020, 07, 04, 12, 25, 00),
                    Status = EventStatus.Active,
                    CustomEventModel = customEventModel1
                };
                db.MyEventsModels.AddRange(myEventsModel1, myEventsModel2, myEventsModel3, myEventsModel4);
                db.SaveChanges();
                var customEventModel2 = new CustomEventModel
                {
                    Name = "Футболчік",
                    Status = EventStatus.Active,
                    NotifyBefore = new TimeSpan(0, 5, 0)
                };
                db.CustomEventModels.Add(customEventModel2);
                db.SaveChanges();

                var myEventsModel11 = new CustomEventDate
                {
                    Date = new DateTime(2020, 08, 11, 12, 25, 00),
                    Status = EventStatus.Active,
                    CustomEventModel = customEventModel2
                };
                var myEventsModel21 = new CustomEventDate
                {
                    Date = new DateTime(2020, 08, 12, 12, 25, 00),
                    Status = EventStatus.Active,
                    CustomEventModel = customEventModel2
                };
                var myEventsModel31 = new CustomEventDate
                {
                    Date = new DateTime(2020, 08, 13, 12, 25, 00),
                    Status = EventStatus.Active,
                    CustomEventModel = customEventModel2
                };
                var myEventsModel41 = new CustomEventDate
                {
                    Date = new DateTime(2020, 08, 14, 12, 25, 00),
                    Status = EventStatus.Closed,
                    CustomEventModel = customEventModel2
                };
                var myEventsModel51 = new CustomEventDate
                {
                    Date = new DateTime(2020, 06, 25, 12, 25, 00),
                    Status = EventStatus.Active,
                    CustomEventModel = customEventModel2
                };
                db.MyEventsModels.AddRange(myEventsModel11, myEventsModel21, myEventsModel31, myEventsModel41,myEventsModel51);
                db.SaveChanges();
                #endregion

                #region MinValue in our DB
                DateTime nextNotification = db.MyEventsModels.Min(p => p.Date ); 
                Console.WriteLine("2 - {0}", nextNotification);
                Console.ReadKey();
                #endregion
            }

            var window = new Window("DAMS Console")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            top.Add(window);
        }
    }
}
