using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NotificationDomainTests.EventTests
{
    [TestClass]
    public class StartTests
    {
        [TestMethod]
        public void TheEventStartDateIsTheSameAsTheEarliestArrivalDate()
        {
            // Arrange
            var attendance = new AttendanceBuilder().Build();
            var happening = new EventBuilder().AddAttendance(attendance).Build();

            // Assert
            Assert.AreEqual(attendance.Arrival, happening.Start);
        }

        [TestMethod]
        public void TheEventStartDateIsUpdatedWithAnEarlierAttendanceIsAdded()
        {
            // Arrange

            var attendance = new AttendanceBuilder().Arrival(DateTime.Now).Build();
            var earlierAttendance = new AttendanceBuilder().Arrival(DateTime.Now.AddHours(-Randomiser.Int(60))).Build();
            var happening = new EventBuilder().AddAttendance(attendance).Build();

            // Act
            happening.AddAttendance(earlierAttendance);

            // Assert
            Assert.AreEqual(earlierAttendance.Arrival, happening.Start);
        }
        [TestMethod]
        public void TheEventStartDateIsNotUpdatedWithAnLaterAttendanceIsAdded()
        {
            // Arrange
            var attendance = new AttendanceBuilder().Arrival(DateTime.Now).Build();
            var laterAttendance = new AttendanceBuilder().Arrival(DateTime.Now.AddHours(Randomiser.Int(20))).Departure(DateTime.Now.AddHours(Randomiser.Int(21, 60))).Build();
            var happening = new EventBuilder().AddAttendance(attendance).Build();

            // Act
            happening.AddAttendance(laterAttendance);

            // Assert
            Assert.AreEqual(attendance.Arrival, happening.Start);
        }

        [TestMethod]
        public void TheEventStartDateIsNotUpdatedWithALaterAttendanceIsRemoved()
        {
            // Arrange
            var attendance = new AttendanceBuilder().Arrival(DateTime.Now).Departure(DateTime.Now.AddHours(Randomiser.Int(1, 24))).Build();
            var laterAttendance = new AttendanceBuilder().Arrival(DateTime.Now.AddHours(Randomiser.Int(60))).Build();
            var happening = new EventBuilder().AddAttendance(attendance).AddAttendance(laterAttendance).Build();
            
            // Act
            happening.RemoveAttendance(laterAttendance.User);

            // Assert
            Assert.AreEqual(attendance.Arrival, happening.Start);
        }
    }
}
