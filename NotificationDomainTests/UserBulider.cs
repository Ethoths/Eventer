using System.Collections.Generic;
using NotificationDomain;

namespace NotificationDomainTests
{
    public class UserBulider
    {
        private string _username = Randomiser.String;
        private string _salutation = Randomiser.String;
        private List<Endorsement> _endorsements;
        private List<NotificationPreference> _notificationPreferences;

        public UserBulider Username(string username)
        {
            _username = username;

            return this;
        }

        public UserBulider Salutation(string salutation)
        {
            _salutation = salutation;

            return this;
        }

        public UserBulider Endorsements(List<Endorsement> endorsements)
        {
            _endorsements = endorsements;

            return this;
        }

        public UserBulider AddEndorsement(Endorsement endorsement)
        {
            _endorsements.Add(endorsement);

            return this;
        }

        public UserBulider ClearEndorsements()
        {
            _endorsements.Clear();

            return this;
        }

        public UserBulider NotificationPreferences(List<NotificationPreference> notificationPreferences)
        {
            _notificationPreferences = notificationPreferences;

            return this;
        }

        public UserBulider AddNotificationPreferences(NotificationPreference notificationPreference)
        {
            _notificationPreferences.Add(notificationPreference);

            return this;
        }

        public UserBulider ClearNotificationPreferences()
        {
            _notificationPreferences.Clear();

            return this;
        }

        public User Build()
        {
            return new User(_username, _salutation, _endorsements, _notificationPreferences);
        }
    }
}
