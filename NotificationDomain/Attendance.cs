using System;

namespace NotificationDomain
{
    public class Attendance
    {
        public User User { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime Departure { get; set; }

        public Attendance(User user, DateTime arrival, DateTime departure)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "The user cannot be null.");
            }

            if (arrival.CompareTo(departure) >= 0)
            {
                throw new ArgumentException("The arrival must preceed the departure.");
            }
            
            User = user;
            Arrival = arrival;
            Departure = departure;
        }
    }
}