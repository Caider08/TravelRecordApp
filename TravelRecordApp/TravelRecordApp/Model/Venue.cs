using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.Model
{
    public class Venue
    {

        public static string GenerateURL(double l, double lon)
        {

           return String.Format(Constants.VENUE_SEARCH, l, lon, Constants.CLIENT_ID, Constants.CLIENT_SECRET, DateTime.Now.ToString("yyyyMMdd"));

            
        }
    }
}
