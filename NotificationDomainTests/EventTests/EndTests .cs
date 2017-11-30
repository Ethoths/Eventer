using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NotificationDomainTests.EventTests
{
    [TestClass]
    public class EndTests
    {
        [TestMethod]
        public void TheEventEndDateIsTheSameAsTheLatestDepartureDate()
        {
            // Arrange
            var attendance = new AttendanceBuilder().Build();
            var happening = new EventBuilder().AddAttendance(attendance).Build();

            // Assert
            Assert.AreEqual(attendance.Departure, happening.End);
        }

        [TestMethod]
        public void TheEventEndDateIsUpdatedWithALaterAttendanceIsAdded()
        {
            // Arrange
            var user = new UserBuilder().Build();
            var attendance = new AttendanceBuilder().User(user).Arrival(DateTime.Now).Build();
            var happening = new EventBuilder().AddAttendance(attendance).Build();
            var earlierAttendance = new AttendanceBuilder().User(user).Arrival(DateTime.Now.AddHours(-Randomiser.Int(60))).Build();

            // Act
            happening.AddAttendance(earlierAttendance);

            // Assert
            Assert.AreEqual(earlierAttendance.Departure, happening.End);
        }
        [TestMethod]
        public void TheEventStartDateIsNotUpdatedWithAnLaterAttendanceIsAdded()
        {
            // Arrange

            var attendance = new AttendanceBuilder().Arrival(DateTime.Now).Build();
            var laterAttendance = new AttendanceBuilder().Arrival(DateTime.Now.AddHours(Randomiser.Int(60))).Build();
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
            var attendance = new AttendanceBuilder().Arrival(DateTime.Now).Build();
            var laterAttendance = new AttendanceBuilder().Arrival(DateTime.Now.AddHours(Randomiser.Int(60))).Build();
            var happening = new EventBuilder().AddAttendance(attendance).AddAttendance(laterAttendance).Build();

            // Act
            happening.RemoveAttendance(laterAttendance.User);

            // Assert
            Assert.AreEqual(attendance.Arrival, happening.Start);
        }
    }
}
