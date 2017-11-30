using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NotificationDomainTests.EventTests
{
    [TestClass]
    public class IsContinuousTests
    {
//        [TestMethod]
//        public void CallingIsContinuousReturnTrueWhenThereIsOnlyOnceAttendeeTest()
//        {
//            // Arrange
//            var attendee = new AttendanceBuilder().Build();
//            var happening = new EventBuilder().AddAttendance(attendee).Build();
//
//            // Act
//            var isContinuous = happening.IsContinuous();
//
//            // Assert
//            Assert.IsTrue(isContinuous);
//        }
//
//        [TestMethod]
//        public void CallingIsContinuousReturnTrueWhenThereTwoConcurrentAttendeesTest()
//        {
//            // Arrange
//            var attendee1 = new AttendanceBuilder().Build();
//            var attendee2 = new AttendanceBuilder().Arrival(attendee1.Arrival).Departure(attendee1.Departure).Build();
//            var happening = new EventBuilder().AddAttendance(attendee1).AddAttendance(attendee2).Build();
//
//            // Act
//            var isContinuous = happening.IsContinuous();
//
//            // Assert
//            Assert.IsTrue(isContinuous);
//        }
//
//        [TestMethod]
//        public void CallingIsContinuousReturnTrueWhenThereTwoSerialAttendeesTest()
//        {
//            // Arrange
//            var attendee1 = new AttendanceBuilder().Build();
//            var attendee2 = new AttendanceBuilder().Arrival(attendee1.Departure).Build();
//            var happening = new EventBuilder().AddAttendance(attendee1).AddAttendance(attendee2).Build();
//
//            // Act
//            var isContinuous = happening.IsContinuous();
//
//            // Assert
//            Assert.IsTrue(isContinuous);
//        }
//
//        [TestMethod]
//        public void CallingIsContinuousReturnTrueWhenThereTwoOverlappingAttendeesTest()
//        {
//            // Arrange
//            var attendee1 = new AttendanceBuilder().Build();
//            var attendee2 = new AttendanceBuilder().Arrival(attendee1.Departure.AddMinutes(-1)).Build();
//            var happening = new EventBuilder().AddAttendance(attendee1).AddAttendance(attendee2).Build();
//
//            // Act
//            var isContinuous = happening.IsContinuous();
//
//            // Assert
//            Assert.IsTrue(isContinuous);
//        }
//
//        [TestMethod]
//        public void CallingIsContinuousReturnFalseWhenThereIsAGap()
//        {
//            // Arrange
//            var attendee1 = new AttendanceBuilder().Build();
//            var attendee2 = new AttendanceBuilder().Arrival(attendee1.Departure.AddMinutes(1)).Build();
//            var happening = new EventBuilder().AddAttendance(attendee1).AddAttendance(attendee2).Build();
//
//            // Act
//            var isContinuous = happening.IsContinuous();
//
//            // Assert
//            Assert.IsFalse(isContinuous);
//        }
//
//        [TestMethod]
//        public void CallingIsContinuousReturnFalseWhenThereIsAGapBetweenTheSecondAndThirdAttendanceTest()
//        {
//            // Arrange
//            var attendee1 = new AttendanceBuilder().Build();
//            var attendee2 = new AttendanceBuilder().Arrival(attendee1.Departure.AddMinutes(-1)).Build();
//            var attendee3 = new AttendanceBuilder().Arrival(attendee2.Departure.AddMinutes(1)).Build();
//            var happening = new EventBuilder().AddAttendance(attendee1).AddAttendance(attendee2).AddAttendance(attendee3).Build();
//
//            // Act
//            var isContinuous = happening.IsContinuous();
//
//            // Assert
//            Assert.IsFalse(isContinuous);
//        }
//
//        [TestMethod]
//        public void CallingIsContinuousReturnFalseWhenThereIsAGapBetweenTheFirstAndSecondSecondAttendanceTest()
//        {
//            // Arrange
//            var attendee1 = new AttendanceBuilder().Build();
//            var attendee2 = new AttendanceBuilder().Arrival(attendee1.Departure.AddMinutes(1)).Build();
//            var attendee3 = new AttendanceBuilder().Arrival(attendee2.Departure.AddMinutes(-1)).Build();
//            var happening = new EventBuilder().AddAttendance(attendee1).AddAttendance(attendee2).AddAttendance(attendee3).Build();
//
//            // Act
//            var isContinuous = happening.IsContinuous();
//
//            // Assert
//            Assert.IsFalse(isContinuous);
//        }
    }
}
