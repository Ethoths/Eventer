using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationDomain;

namespace NotificationDomainTests.AttendanceTests
{
    [TestClass]
    public class ConstructionTests
    {
        [TestMethod]
        public void ConstructingAnAttendanceWithValidParametersSucceeds()
        {
            // Arrange
            var user = new UserBuilder().Build();
            var arrival = Randomiser.ArrivalDate;
            var departure = Randomiser.DepartureDate(arrival);

            // Act
            var attendance = new Attendance(user, arrival, departure);

            // Assert
            Assert.IsNotNull(attendance);
            Assert.AreEqual(user, attendance.User);
            Assert.AreEqual(arrival, attendance.Arrival);
            Assert.AreEqual(departure, attendance.Departure);
        }

        [TestMethod]
        public void ConstructingAnAttendanceWithANullUserThrowsAnArgumentNullException()
        {
            // Arrange
            var arrival = Randomiser.ArrivalDate;
            var departure = Randomiser.DepartureDate(arrival);

            // Act
            Action action =() => new Attendance(null, arrival, departure);

            // Assert
            action
                .ShouldThrow<ArgumentNullException>()
                .WithMessage("The user cannot be null.\n\rParameter name: user");
        }

        [TestMethod]
        public void ConstructingAnAttendanceWithAnArrivalAfterTheDepartureThrowsAnArgumentException()
        {
            // Arrange
            var arrival = Randomiser.ArrivalDate;
            var departure = arrival.AddMinutes(-Randomiser.Int(20));

            // Act
            Action action = () => new Attendance(new UserBuilder().Build(), arrival, departure);

            // Assert
            action
                .ShouldThrow<ArgumentException>()
                .WithMessage("The arrival must preceed the departure.");
        }
    }
}
