using System;
using System.Diagnostics.CodeAnalysis;

namespace NotificationDomainTests
{
    [ExcludeFromCodeCoverage]
    public static class Randomiser
    {
        private static readonly Random Ticks;

        static Randomiser()
        {
            Ticks = new Random((int) DateTime.Now.Ticks);
        }

        public static string String
        {
            get { return Guid.NewGuid().ToString(); }
        }

        public static DateTime PastDate
        {
            get { return DateTime.Now.AddDays(-Int(1000)); }
        }

        public static DateTime ArrivalDate
        {
            get { return DateTime.Now.AddDays(Int(4)).AddHours(Int(2)); }
        }

        public static DateTime DepartureDate(DateTime arrivalDate)
        {
            return arrivalDate.AddHours(Int(5)).AddMinutes(Int(60));
        }
        
        public static DateTime FutureDate
        {
            get { return DateTime.Now.AddDays(Int(1000)); }
        }

        public static string EmailAddress
        {
            get { return string.Format("{0}@{1}.com", ShortString(20), ShortString(20)); }
        }

        public static string Url
        {
            get { return string.Format("http://{0}.{1}.com", ShortString(20), ShortString(20)); }
        }

        public static string LandlineNumber
        {
            get { return "01" + Ticks.Next(0, 999999999).ToString("000000000"); }
        }

        public static string MobileNumber
        {
            get { return "07" + Ticks.Next(0, 999999999).ToString("000000000"); }
        }

        public static int Int(int maxValue = int.MaxValue)
        {
            return Ticks.Next(1, maxValue);
        }

        public static int Int(int minValue, int maxValue)
        {
            return Ticks.Next(minValue, maxValue);
        }

        public static bool Bool()
        {
            return Convert.ToBoolean(Ticks.Next(0, 1));
        }

        public static string ShortString(int length)
        {
            length = length > 20 ? 20 : length;

            return String.Replace("-", string.Empty).Substring(0, length);
        }
    }

}