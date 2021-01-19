using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace corono_app
{

    class coronaApi
    {
        public DateTime Date_of_report { get; set; }
        public string Municipality_name { get; set; }
        public int Total_reported { get; set; }
    }

    class CityApi
    {
        public List<CitiesModel> data { get; set; }
    }

    class CitiesModel
    {
        public int id { get; set; }
        public string wikiDataId { get; set; }
        public string city { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string country { get; set; }
        public string regionCode { get; set; }
        public string countryCode { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    class postCodeApi
    {
        public string postal_code { get; set; }
        public string city { get; set; }
        public string municipality { get; set; }
        public List<areasModel> administrative_areas { get; set; }
        public countryModel country { get; set; }
    }

    class countryModel
    {
        public string iso3_code { get; set; }
        public string iso2_code { get; set; }
        public string name { get; set; }
    }

    class areasModel {
        public string type { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
    }
}
