using NotificationDomain;

namespace NotificationDomainTests
{
    public class EndorsementBuilder
    {
        private string _name = Randomiser.String;
        private Endorsement _parent;

        public EndorsementBuilder Name(string name)
        {
            _name = name;

            return this;
        }

        public EndorsementBuilder Parent(Endorsement parent)
        {
            _parent = parent;

            return this;
        }

        public Endorsement Build()
        {
            return new Endorsement(_name, _parent);
        }
    }
}
