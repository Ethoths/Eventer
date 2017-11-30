using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationDomain;

namespace NotificationDomainTests.EventTests
{
    [TestClass]
    public class ConstructionTests
    {
        [TestMethod]
        public void ANewEventIsConstructedCorrectlyWithASingleAttendance()
        {
            // Act
            var attendance = new AttendanceBuilder().Build();
            var happening = new EventBuilder().AddAttendance(attendance).Build();

            // Assert
            Assert.IsNotNull(happening.Attendances);
            Assert.AreEqual(1, happening.Attendances.Count);
            Assert.AreEqual(attendance.Arrival, happening.Start);
            Assert.AreEqual(attendance.Departure, happening.End);
            //Assert.AreEqual("Location", happening.Location);
        }

        [TestMethod]
        public void ANewEventIsConstructedCorrectlyWithAnAttendanceList()
        {
            // Arrange
            var user = new UserBuilder().Build();
            var arrivalDate = Randomiser.ArrivalDate;
            var departureDate = Randomiser.DepartureDate(arrivalDate);

            // Act
            var attendances = new List<Attendance>
            {
                new Attendance(user, arrivalDate, departureDate),
                new Attendance(user, arrivalDate, departureDate)
            };

            var happening = new EventBuilder().Attendances(attendances).Build();

            // Assert
            Assert.IsNotNull(happening.Attendances);
            Assert.AreEqual(2, happening.Attendances.Count);
           // Assert.AreEqual("Location", happening.Location);
        }

        [TestMethod]
        public void AttemptingToConstructAnEventWithAnEmptyAttendanceListThrowsAnArgumentException()
        {
            // Act
            Action action = () => new EventBuilder().Build();

            // Assert
            action
                .ShouldThrow<ArgumentException>()
                .WithMessage("The list of attendances cannot be empty.\r\nParameter name: attendances");
                
        }

        [TestMethod]
        public void AttemptingToConstructAnEventWithAnEmptyAttendanceListThrowsANullArgumentException()
        {
            // Act
            Action action = () => new EventBuilder().Attendances(null).Build();

            // Assert
            action
                .ShouldThrow<ArgumentNullException>()
                .WithMessage("The list of attendances cannot be null.\r\nParameter name: attendances");
        }
    }
}
