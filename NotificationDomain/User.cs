using System.Collections.Generic;
using System.Linq;

namespace NotificationDomain
{
    public class User
    {
        private readonly List<Endorsement> _endorsements;
        private readonly List<NotificationPreference> _notificationPreferences;

        public string Username { get; private set; }

        public List<string> EmailAddresses { get; set; } //TODO Make this immutable.

        public string Salutation { get; private set; }

        public List<Endorsement> Endorsements => new List<Endorsement>(_endorsements);

        public bool HasEndorsement(Endorsement endorsement)
        {
            return _endorsements.Any(e => e.Name == endorsement.Name);
        }

        public List<NotificationPreference> NotificationPreferences => new List<NotificationPreference>(_notificationPreferences);

        public User(string username, string salutation, List<Endorsement> endorsements, List<NotificationPreference> notificationPreferences)
        {
            Username = username;
            Salutation = salutation;
            _endorsements = endorsements;
            _notificationPreferences = notificationPreferences;
        }
    }
}