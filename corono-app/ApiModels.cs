using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace corono_app
{
    // data for the covid API (https://geodata.rivm.nl/covid-19/COVID-19_aantallen_gemeente_cumulatief.json)
    class coronaApi
    {
        public DateTime Date_of_report { get; set; }
        public string Municipality_name { get; set; }
        public int Total_reported { get; set; }
    }

    // data for the CityAPI (https://wft-geo-db.p.rapidapi.com/v1/geo/)
    class CityApi
    {
        public List<CitiesModel> data { get; set; }
    }

    // handling the data from the CityApi class
    class CitiesModel
    {
        public string wikiDataId { get; set; }
    }

    // data for the PostCode API (https://api.spikkl.nl/)
    class postCodeApi
    {
        public List<postCodeApiResults> results { get; set; }
    }

    // handeling the results from the postCodeApi class
    class postCodeApiResults
    {
        public string postal_code { get; set; }
        public string city { get; set; }
    }

    // getting the citypopulation from the cities API
    class CityPopulation
    {
        public CityPopulationData data { get; set; }
    }

    // getting the population for the cityPopulation class
    class CityPopulationData
    {
        public int population { get; set; }
    }
}
