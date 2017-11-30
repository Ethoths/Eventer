using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationDomain;

namespace NotificationDomainTests.EventTests
{
    [TestClass]
    public class RemoveAttendanceTests
    {
        private readonly Attendance _attendance = new AttendanceBuilder().Build();

        [TestMethod]
        public void CallingRemoveAttendanceRemovesTheCorrectAttendanceWhenTheAttandanceExistsByUsername()
        {
            // Arrange
            var user = new UserBuilder().Build();
            var duplicateUsername = new UserBuilder().Username(user.Username).Build();
            var happening = new EventBuilder().AddAttendance(_attendance).Build();
            happening.AddAttendance(new AttendanceBuilder().User(user).Build());
            happening.AddAttendance(new AttendanceBuilder().Build());

            // Act
            happening.RemoveAttendance(duplicateUsername);

            // Assert
            Assert.AreEqual(2, happening.Attendances.Count);
            Assert.IsNull(happening.Attendances.FirstOrDefault(a => a.User.Username == user.Username));
        }

        [TestMethod]
        public void CallingRemoveAttendanceRemovesTheCorrectAttendanceWhenTheAttandanceExistsByReference()
        {
            // Arrange
            var user = new UserBuilder().Build();
            var happening = new EventBuilder().AddAttendance(_attendance).Build();
            happening.AddAttendance(new AttendanceBuilder().User(user).Build());
            happening.AddAttendance(new AttendanceBuilder().Build());

            // Act
            happening.RemoveAttendance(user);

            // Assert
            Assert.AreEqual(2, happening.Attendances.Count);
            Assert.IsNull(happening.Attendances.FirstOrDefault(a => a.User.Username == user.Username));
        }

        [TestMethod]
        public void CallingRemoveAttendanceSucceedsWhenTheAttendanceDoesNotExist()
        {
            // Arrange
            var happening = new EventBuilder().AddAttendance(_attendance).Build();
            happening.AddAttendance(new AttendanceBuilder().Build());
            happening.AddAttendance(new AttendanceBuilder().Build());

            // Act
            happening.RemoveAttendance(new UserBuilder().Build());

            // Assert
            Assert.AreEqual(3, happening.Attendances.Count);
        }
    }
}
