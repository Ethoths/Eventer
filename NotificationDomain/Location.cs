using System.Collections.Generic;

namespace NotificationDomain
{
    public class Location
    {
        private readonly List<Endorsement> _endorsements;

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public List<Endorsement> Endorsements => new List<Endorsement>(_endorsements);

        public Location(string name, int capacity, List<Endorsement> endorsements)
        {
            Name = name;
            Capacity = capacity;
            _endorsements = endorsements;
        }
    }
}