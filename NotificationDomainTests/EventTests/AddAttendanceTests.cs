using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NotificationDomainTests.EventTests
{
    [TestClass]
    public class AddAttendanceTests
    {
        [TestMethod]
        public void CallingAddAttendanceAddsTheCorrectAttendanceWhenTheAttandanceDoesNotExist()
        {
            // Arrange
            var user = new UserBuilder().Build();
            var attendance = new AttendanceBuilder().Build();
            var happening = new EventBuilder().AddAttendance(attendance).Build();

            // Act
            happening.AddAttendance(new AttendanceBuilder().User(user).Build());

            // Assert
            Assert.AreEqual(2, happening.Attendances.Count);
            Assert.IsNotNull(happening.Attendances.FirstOrDefault(a => a.User.Username == user.Username));
        }

        [TestMethod]
        public void CallingAddAttendanceTwiceByReferenceOnlyAddsTheAttendanceOnceAndUpdatesTheArrivalAndDeparture()
        {
            // Arrange
            var user = new UserBuilder().Build();
            var arrival1 = DateTime.Now;
            var departure1 = arrival1.AddMinutes(Randomiser.Int(20));
            var attendance1 = new AttendanceBuilder().User(user).Arrival(arrival1).Departure(departure1).Build();
            var arrival2 = arrival1.AddMinutes(Randomiser.Int(10));
            var departure2 = arrival2.AddMinutes(Randomiser.Int(10, 20));
            var attendance2 = new AttendanceBuilder().User(user).Arrival(arrival2).Departure(departure2).Build();
            var happening = new EventBuilder().AddAttendance(attendance1).Build();

            // Act
           happening.AddAttendance(attendance2);

            // Assert
            Assert.AreEqual(1, happening.Attendances.Count);
            Assert.AreEqual(arrival2, happening.Start);
            Assert.AreEqual(departure2, happening.End);
        }

        [TestMethod]
        public void CallingAddAttendanceTwiceByUsernameOnlyAddsTheAttendanceOnceAndUpdatesTheArrivalAndDeparture()
        {
            // Arrange
            var user = new UserBuilder().Build();
            var arrival1 = DateTime.Now;
            var departure1 = arrival1.AddMinutes(20);
            var arrival2 = arrival1.AddMinutes(Randomiser.Int(10));
            var departure2 = arrival2.AddMinutes(Randomiser.Int(10, 60));
            var attendance = new AttendanceBuilder().User(user).Arrival(arrival1).Departure(departure1).Build();

            // Act
            var happening = new EventBuilder().AddAttendance(attendance).Build();
            happening.AddAttendance(new AttendanceBuilder().User(new UserBuilder().Username(user.Username).Build()).Arrival(arrival2).Departure(departure2).Build());

            // Assert
            Assert.AreEqual(1, happening.Attendances.Count);
            Assert.AreEqual(arrival2, happening.Start);
            Assert.AreEqual(departure2, happening.End);
        }
    }
}
