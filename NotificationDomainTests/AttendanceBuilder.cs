using NotificationDomain;
using System;

namespace NotificationDomainTests
{
    public class AttendanceBuilder
    {
        private User _user = new UserBuilder().Build();
        private DateTime _arrival = Randomiser.ArrivalDate;
        private DateTime _departure;

        public AttendanceBuilder User(User user)
        {
            _user = user;

            return this;
        }

        public AttendanceBuilder Arrival(DateTime arrival)
        {
            _arrival = arrival;
            _departure = Randomiser.DepartureDate(arrival);

            return this;
        }
        public AttendanceBuilder Departure(DateTime departure)
        {
            _departure = departure;

            return this;
        }

        public AttendanceBuilder()
        {
            _departure = Randomiser.DepartureDate(_arrival);
        }

        public Attendance Build()
        {
            return new Attendance(_user, _arrival, _departure);
        }
    }
}
