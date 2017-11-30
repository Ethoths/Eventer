namespace NotificationDomain
{
    public class Endorsement
    {
        public string Name { get; private set; }

        public Endorsement Parent { get; private set; }

        public Endorsement(string name) : this(name, null)
        {
        }

        public Endorsement(string name, Endorsement parent)
        {
            Name = name;
            Parent = parent;
        }
    }
}