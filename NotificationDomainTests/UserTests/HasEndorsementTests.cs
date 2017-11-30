using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NotificationDomainTests.UserTests
{
    [TestClass]
    public class HasEndorsementTests
    {
        public void CallingHasEndorsementReturnsTrueWhenTheUserHasTheEndorsementByReference()
        {
            // Arrange
            var endorsement = new EndorsementBuilder().Build();
            var user = new UserBulider().AddEndorsement(endorsement).Build();

            // Assert
            Assert.IsTrue(user.HasEndorsement(endorsement));
        }

        public void CallingHasEndorsementReturnsTrueWhenTheUserHasTheEndorsementByName()
        {
            // Arrange
            var endorsement = new EndorsementBuilder().Build();
            var user = new UserBulider().AddEndorsement(endorsement).Build();
            var endorsement2 = new EndorsementBuilder().Name(endorsement.Name).Build();

            // Assert
            Assert.IsTrue(user.HasEndorsement(endorsement2));
        }

        public void CallingHasEndorsementReturnsFalseWhenTheUserDoesNotHaveTheEndorsement()
        {
            // Arrange
            var endorsement = new EndorsementBuilder().Build();
            var user = new UserBulider().Build();

            // Assert
            Assert.IsFalse(user.HasEndorsement(endorsement));
        }
    }
}
