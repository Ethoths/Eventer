using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationDomain
{
    public class Event
    {
        private readonly List<Attendance> _attendances;
        
        //public bool IsContinuous()
        //{
        //    var start = _attendances.OrderBy(a => a.Arrival).ThenByDescending(a => a.Departure).First();
        //    var end = _attendances.OrderBy(a => a.Departure).Last().Departure;
        //
        //    return NextContinuousAttandance(Attendances, start, end);
        //}
        //
        //private static bool NextContinuousAttandance(ICollection<Attendance> attendances, Attendance attendance, DateTime end)
        //{
        //    attendances.Remove(attendance);
        //
        //    if (attendance.Departure == end)
        //    {
        //        return true;
        //    }
        //
        //    var start = attendances.Where(a => a.Arrival <= attendance.Departure).OrderBy(a => a.Departure).LastOrDefault();
        //
        //    return start != null && NextContinuousAttandance(attendances, start, end);
        //}

        //public bool IsContinuous(Endorsement endorsement)
        //{
        //    var attendances = new List<Attendance>(_attendances);
        //
        //    foreach (var a in Attendances)
        //    {
        //        if (!a.User.HasEndorsement(endorsement))
        //        {
        //            attendances.Remove(a);
        //        }
        //    }
        //
        //    var start = _attendances.OrderBy(a => a.Arrival).ThenByDescending(a => a.Departure).First();
        //    var end = _attendances.OrderBy(a => a.Departure).Last().Departure;
        //
        //    if (start == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return NextContinuousAttandance(attendances, endorsement, start, end);
        //    }
        //}

        //private static bool NextContinuousAttandance(ICollection<Attendance> attendances, Endorsement endorsement, Attendance attendance, DateTime end)
        //{      
        //    attendances.Remove(attendance);
        //
        //    if (attendance.Departure == end)
        //    {
        //        return true;
        //    }
        //
        //    var start = attendances.Where(a => a.Arrival <= attendance.Departure).OrderBy(a => a.Departure).LastOrDefault();
        //
        //    if (start == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return NextContinuousAttandance(attendances, start, end);
        //    }
        //}

        public List<Thingy> GetThingys
        {
            get
            {
                var thingys = new List<Thingy>();

                foreach (var endorsement in Location.Endorsements)
                {
                    var thingy = new Thingy(endorsement);

                    foreach (var attandance in _attendances.Where(a => a.User.Endorsements.Any(s => s.Name == endorsement.Name)))
                    {
                        thingy.Periods.Add(new Period(attandance.User, attandance.Arrival, attandance.Departure));
                    }

                    thingys.Add(thingy);
                }

                return thingys;
            }
        }

        public Location Location { get; private set; }

        public List<Attendance> Attendances => new List<Attendance>(_attendances);

        public List<Attendance> AddAttendance(Attendance attendance)
        {
            RemoveAttendance(attendance.User);
            _attendances.Add(attendance);

            return Attendances;
        }

        public List<Attendance> RemoveAttendance(User user)
        {
            _attendances.RemoveAll(attendance => attendance.User.Username == user.Username);

            return Attendances;
        }

        public DateTime Start
        {
            get { return Attendances.OrderBy(a => a.Arrival).First().Arrival; }
        }

        public DateTime End
        {
            get { return Attendances.OrderBy(a => a.Departure).Last().Departure; }
        }

        public Event(Location location, Attendance attendance)
        {
            _attendances = new List<Attendance>
            {
                attendance
            };

            Location = location;
        }

        public Event(Location location, IEnumerable<Attendance> attendances)
        {
            if (attendances == null)
            {
                throw new ArgumentNullException(nameof(attendances), "The list of attendances cannot be null.");
            }

            var attendancesArray = attendances.ToArray();

            if (!attendancesArray.Any())
            {
                throw new ArgumentException("The list of attendances cannot be empty.", nameof(attendances));
            }

            _attendances = new List<Attendance>(attendancesArray);
            Location = location;
        }
    }

    public class Thingy
    {
        public Endorsement Endorsement { get; private set; }

        public List<Period> Periods { get; private set; }

        public Thingy(Endorsement endorsement)
        {
            Endorsement = endorsement;

            Periods = new List<Period>();
        }
    }

    public class Period
    {
        public User User { get; set; }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        public Period(User user, DateTime start, DateTime end)
        {
            User = user;
            Start = start;
            End = end;
        }
    }
}
