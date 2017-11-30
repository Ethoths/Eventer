using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NotificationService.Controllers
{
    [Route("[controller]")]
    public class ValuesController : Controller
    {
        // POST values
        [HttpPost]
        public void Post([FromBody] SendEmailDto sendEmailDto)
        {
            Console.WriteLine(sendEmailDto.EmailType);
        }


        public class SendEmailDto
        {
            public EmailType EmailType { get; set; }

            public User Recipient { get; set; }

            public Event Event { get; set; }
        }
    }

    public class Event
    {
        public string Location { get; set; }

        public List<Attendance> Attendances { get; set; }
    }


    public class Attendance
    {
        public User User { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime Departure { get; set; }
    }

    public class User
    {
        public string EmailAddress { get; set; }

        public string Salutation { get; set; }

        public List<NotificationPreference> NotificationPreferences { get; set; }

        public User()
        {
            NotificationPreferences = new List<NotificationPreference>();
        }
    }

    public enum NotificationPreference
    {
        NotSet = 0
    }

    public enum EmailType
    {
        NotSet = 0
    }
}
