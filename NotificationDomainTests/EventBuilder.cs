using System.Collections.Generic;
using NotificationDomain;

namespace NotificationDomainTests
{
    public class EventBuilder
    {
        private Location _location = new LocationBuilder().Build();
        private List<Attendance> _attendances = new List<Attendance>();

        public EventBuilder Location(Location location)
        {
            _location = location;

            return this;
        }

        public EventBuilder Attendances(List<Attendance> attendances)
        {
            _attendances = attendances;

            return this;
        }
        public EventBuilder AddAttendance(Attendance attendance)
        {
            _attendances.Add(attendance);

            return this;
        }

        public EventBuilder ClearAttendances()
        {
            _attendances.Clear();

            return this;
        }

        public Event Build()
        {
            return new Event(_location, _attendances);
        }
    }
}
