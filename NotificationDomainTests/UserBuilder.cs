using System.Collections.Generic;
using NotificationDomain;

namespace NotificationDomainTests
{
    public class UserBuilder
    {
        private string _username = Randomiser.String;
        private string _salutation = Randomiser.String;
        private List<Endorsement> _endorsements = new List<Endorsement>();
        private List<NotificationPreference> _notificationPreferences = new List<NotificationPreference>();
        private List<string> _emailAddresses = new List<string>();

        public UserBuilder Username(string username)
        {
            _username = username;

            return this;
        }

        public UserBuilder Salutation(string salutation)
        {
            _salutation = salutation;

            return this;
        }

        public UserBuilder Endorsements(List<Endorsement> endorsements)
        {
            _endorsements = endorsements;

            return this;
        }

        public UserBuilder AddEndorsement(Endorsement endorsement)
        {
            _endorsements.Add(endorsement);

            return this;
        }

        public UserBuilder ClearEndorsement()
        {
            _endorsements.Clear();

            return this;
        }

        public UserBuilder NotificationPreferences(List<NotificationPreference> notificationPreferences)
        {
            _notificationPreferences = notificationPreferences;

            return this;
        }

        public UserBuilder EmailAddresses(List<string> emailAddresses)
        {
            _emailAddresses = emailAddresses;

            return this;
        }

        public UserBuilder AddEmailAddress(string emailAddress)
        {
            _emailAddresses.Add(emailAddress);

            return this;
        }
        public UserBuilder ClearEmailAddresses()
        {
            _emailAddresses.Clear();

            return this;
        }

        public User Build()
        {
            return new User(_username, _salutation, _endorsements, _notificationPreferences)
            {
                EmailAddresses = _emailAddresses
            };
        }
    }
}
