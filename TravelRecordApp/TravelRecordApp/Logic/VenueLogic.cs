using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;

namespace TravelRecordApp.Logic
{
    public class VenueLogic
    {
        public async static Task <List<Venue>> GetVenue(double lat, double lon)
        {
            List<Venue> Venues = new List<Venue>();

            var url = Venue.GenerateURL(lat, lon);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                var json = await response.Content.ReadAsStringAsync();

            }



                return Venues;
        }

    }
}
