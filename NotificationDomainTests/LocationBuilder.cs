using System.Collections.Generic;
using NotificationDomain;

namespace NotificationDomainTests
{
    public class LocationBuilder
    {
        private string _assemblyName = Randomiser.String;
        private int _capacity = Randomiser.Int(); 
        private List<Endorsement> _endorsements = new List<Endorsement>();

        public LocationBuilder AssemblyName(string assemblyName)
        {
            _assemblyName = assemblyName;

            return this;
        }

        public LocationBuilder Capacity(int capacity)
        {
            _capacity = capacity;

            return this;
        }

        public LocationBuilder Endorsements(List<Endorsement> endorsements)
        {
            _endorsements = endorsements;

            return this;
        }
        public LocationBuilder AddEndorsement(Endorsement endorsement)
        {
            _endorsements.Add(endorsement);

            return this;
        }

        public LocationBuilder ClearEndorsements()
        {
            _endorsements.Clear();

            return this;
        }
        
        public Location Build()
        {
            return new Location(_assemblyName, _capacity, _endorsements);
        }
    }
}