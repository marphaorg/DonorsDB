using System;
using System.Collections.Generic;
using System.Text;

namespace Helper
{
    public class HelperDateTime
    {
        public static DateTime? ToDate(string dateText)
        {
            DateTime dt = new DateTime();
            try
            {
                if (!string.IsNullOrEmpty(dateText))
                    DateTime.TryParse(dateText, out dt);
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            return dt;
        }

        public static string GetPrettyDate(DateTime d)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(d);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("{0} seconds ago", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("about {0} minutes ago", timeSpan.Minutes) :
                    "about a minute ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("about {0} hours ago", timeSpan.Hours) :
                    "about an hour ago";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("about {0} days ago", timeSpan.Days) :
                    "yesterday";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("about {0} months ago", timeSpan.Days / 30) :
                    "about a month ago";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("about {0} years ago", timeSpan.Days / 365) :
                    "about a year ago";
            }

            return result;
        }

        public static string GetPrettyDate(string datetime)
        {
            DateTime? d = ToDate(datetime);
            if(d.HasValue)
                return  GetPrettyDate(d.Value);
            return datetime;
        }
    }
}
