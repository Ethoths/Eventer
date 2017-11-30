using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NotificationDomainTests.EventTests
{
    [TestClass]
    public class IsContinuousWithEndorsementTests
    {
        [TestMethod]
        public void CallingIsContinuousReturnTrueWhenThereIsOnlyOneAttendeeTest()
        {
            // Arrange
            var endorsement = new EndorsementBuilder().Build();
            var user = new UserBuilder().AddEndorsement(endorsement).Build();
            var attendee = new AttendanceBuilder().User(user).Build();
            var happening = new EventBuilder().AddAttendance(attendee).Build();

            // Act
            var isContinuous = happening.IsContinuous();

            // Assert
            Assert.IsTrue(isContinuous);
        }

        [TestMethod]
        public void CallingIsContinuousReturnTrueWhenThereTwoConcurrentAttendeesTest()
        {
            // Arrange
            var endorsement1 = new EndorsementBuilder().Build();
            var user1 = new UserBuilder().AddEndorsement(endorsement1).Build();
            var attendee1 = new AttendanceBuilder().User(user1).Build();
            var endorsement2 = new EndorsementBuilder().Build();
            var user2 = new UserBuilder().AddEndorsement(endorsement2).Build();
            var attendee2 = new AttendanceBuilder().User(user2).Arrival(attendee1.Arrival).Departure(attendee1.Departure).Build();
            var happening = new EventBuilder().AddAttendance(attendee1).AddAttendance(attendee2).Build();
      
            // Act
            var isContinuous = happening.IsContinuous();
      
            // Assert
            Assert.IsTrue(isContinuous);
        }
      
        [TestMethod]
        public void CallingIsContinuousReturnTrueWhenThereTwoSerialAttendeesTest()
        {
            // Arrange
            var endorsement = new EndorsementBuilder().Build();
            var user1 = new UserBuilder().AddEndorsement(endorsement).Build();
            var attendee1 = new AttendanceBuilder().User(user1).Build();
            var user2 = new UserBuilder().AddEndorsement(endorsement).Build();
            var attendee2 = new AttendanceBuilder().User(user2).Arrival(attendee1.Departure).Build();
            var happening = new EventBuilder().AddAttendance(attendee1).AddAttendance(attendee2).Build();
      
            // Act
            var isContinuous = happening.IsContinuous(endorsement);
      
            // Assert
            Assert.IsTrue(isContinuous);
        }

        [TestMethod]
        public void CallingIsContinuousReturnFalseWhenThereTwoSerialAttendeesWithDifferentEndorsementsTest()
        {
            // Arrange
            var endorsement1 = new EndorsementBuilder().Build();
            var user1 = new UserBuilder().AddEndorsement(endorsement1).Build();
            var attendee1 = new AttendanceBuilder().User(user1).Build();
            var endorsement2 = new EndorsementBuilder().Build();
            var user2 = new UserBuilder().AddEndorsement(endorsement2).Build();
            var attendee2 = new AttendanceBuilder().User(user2).Arrival(attendee1.Departure).Build();

            //  Act
            var happening = new EventBuilder().AddAttendance(attendee1).AddAttendance(attendee2).Build();

            // Assert
            Assert.IsFalse(happening.IsContinuous(endorsement1));
            Assert.IsFalse(happening.IsContinuous(endorsement2));
        }

        [TestMethod]
        public void CallingIsContinuousReturnTrueWhenThereTwoOverlappingAttendeesTest()
        {
            // Arrange
            var endorsement = new EndorsementBuilder().Build();
            var user1 = new UserBuilder().AddEndorsement(endorsement).Build();
            var attendee1 = new AttendanceBuilder().User(user1).Build();
            var user2 = new UserBuilder().AddEndorsement(endorsement).Build();
            var attendee2 = new AttendanceBuilder().Arrival(attendee1.Departure.AddMinutes(-1)).User(user2).Build();
            var happening = new EventBuilder().AddAttendance(attendee1).AddAttendance(attendee2).Build();
      
            // Act
            var isContinuous = happening.IsContinuous();
      
            // Assert
            Assert.IsTrue(isContinuous);
        }
      
        [TestMethod]
        public void CallingIsContinuousReturnFalseWhenThereIsAGap()
        {
            // Arrange
            var endorsement = new EndorsementBuilder().Build();
            var user1 = new UserBuilder().AddEndorsement(endorsement).Build();
            var attendee1 = new AttendanceBuilder().User(user1).Build();
            var user2 = new UserBuilder().AddEndorsement(endorsement).Build();
            var attendee2 = new AttendanceBuilder().User(user2).Arrival(attendee1.Departure.AddMinutes(1)).Build();
            var happening = new EventBuilder().AddAttendance(attendee1).AddAttendance(attendee2).Build();
      
            // Act
            var isContinuous = happening.IsContinuous();
      
            // Assert
            Assert.IsFalse(isContinuous);
        }
      
        [TestMethod]
        public void CallingIsContinuousReturnFalseWhenThereIsAGapBetweenTheSecondAndThirdAttendanceTest()
        {
            // Arrange
            var endorsement = new EndorsementBuilder().Build();
            var user1 = new UserBuilder().AddEndorsement(endorsement).Build();
            var attendee1 = new AttendanceBuilder().User(user1).Build();
            var user2 = new UserBuilder().AddEndorsement(endorsement).Build();
            var attendee2 = new AttendanceBuilder().User(user2).Arrival(attendee1.Departure.AddMinutes(-1)).Build();
            var user3 = new UserBuilder().AddEndorsement(endorsement).Build();
            var attendee3 = new AttendanceBuilder().User(user3).Arrival(attendee2.Departure.AddMinutes(1)).Build();
            var happening = new EventBuilder().AddAttendance(attendee1).AddAttendance(attendee2).AddAttendance(attendee3).Build();
      
            // Act
            var isContinuous = happening.IsContinuous();
      
            // Assert
            Assert.IsFalse(isContinuous);
        }
      
        [TestMethod]
        public void CallingIsContinuousReturnFalseWhenThereIsAGapBetweenTheFirstAndSecondSecondAttendanceTest()
        {
            // Arrange
            var endorsement = new EndorsementBuilder().Build();
            var user1 = new UserBuilder().AddEndorsement(endorsement).Build();
            var attendee1 = new AttendanceBuilder().User(user1).Build();
            var user2 = new UserBuilder().AddEndorsement(endorsement).Build();
            var attendee2 = new AttendanceBuilder().User(user2).Arrival(attendee1.Departure.AddMinutes(1)).Build();
            var user3 = new UserBuilder().AddEndorsement(endorsement).Build();
            var attendee3 = new AttendanceBuilder().User(user3).Arrival(attendee2.Departure.AddMinutes(-1)).Build();
            var happening = new EventBuilder().AddAttendance(attendee1).AddAttendance(attendee2).AddAttendance(attendee3).Build();
      
            // Act
            var isContinuous = happening.IsContinuous();
      
            // Assert
            Assert.IsFalse(isContinuous);
        }

        // different endorsements.
        // hirearchial
    }
}
