using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace corono_app
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            //List<coronaApi> coronaStats = getCoronaStats();
            //handleApplication(coronaStats, "8447AA", 500);
        }
        private List<coronaApi> getCoronaStats()
        {
            // Defining the RESTClient
            // giving the RESTClient the endpoint, host and headers.
            // making the API Request.
            RESTClient client = new RESTClient();
            client.endPoint = "https://geodata.rivm.nl/covid-19/COVID-19_aantallen_gemeente_cumulatief.json";
            client.host = "geodata.rivm.nl";
            client.headers = new string[][] { };
            string response = client.makeRequest();

            // Deserializing the response
            List<coronaApi> coronaStatsRes = JsonConvert.DeserializeObject<List<coronaApi>>(response);
            List<coronaApi> coronaStats = new List<coronaApi>();
            bool existDateNow = coronaStats.Exists(d => d.Date_of_report.Date == DateTime.Now.AddDays(-1).Date);
            // looping over the data
            // adding the data from today OR yesterday to a new List
            coronaStatsRes.ForEach(res =>
            {
                // checking if the current date exists otherwise taking the data from yesterday.
                if (res.Date_of_report.Date == (existDateNow ? DateTime.Now.Date : DateTime.Now.AddDays(-1).Date))
                {
                    coronaStats.Add(res);
                    return;
                }
                return;
            });
            // returning the corona stats from today OR yesterday.
            return coronaStats;
        }

        private async void handleApplication(List<coronaApi> coronaStats, string postCode, int visitedCount)
        {
            // Defining RESTClient
            // adding the endpoint, host and headers.
            RESTClient client = new RESTClient();
            string postcode = postCode;
            client.endPoint = $"https://api.spikkl.nl/geo/nld/lookup.json?postal_code={postcode}&filter=postal_code,street_name,city,municipality,administrative_areas,country&key=b6ee7d920ad5f67335a422f220f93cfc";
            client.host = "api.spikkl.nl";
            client.headers = new string[][] { };
            // making the API Request for the postcode.
            string response = client.makeRequest();
            // deserializing the response data.
            postCodeApi postCodeResults = JsonConvert.DeserializeObject<postCodeApi>(response);
            List<string> cities = new List<string>();
            // looping over the dezerialized data.
            postCodeResults.results.ForEach(res =>
            {
                // checking if its the right postcode. 
                if (res.postal_code != postcode) { return; }
                // checking if the current city exists in the new List.
                // if it doesn't exist in the new list, add it.
                int pos = cities.IndexOf(res.city);
                if (pos == -1)
                {
                    cities.Add(res.city);
                }
            });
            // defining the citizenCount and adding to it later.
            int citizenCount = 0;
            List<string> cityCodes = new List<string>();
            // looping over the cities of that postcode.
            for (int i = 0; i < cities.Count;)
            {
                // defining the current city in the loop.
                string city = cities[i];
                // adding the endpoint, host and headers for the API Call.
                client.endPoint = $"https://wft-geo-db.p.rapidapi.com/v1/geo/countries/NL/regions/FR/cities?namePrefix={city}";
                client.host = "wft-geo-db.p.rapidapi.com";
                string[] apiKey = new string[2] { "x-rapidapi-key", "e6fba40ecbmsh53e0c124daa7214p19b766jsn4209defa38c2" };
                string[] host = new string[2] { "x-rapidapi-host", "wft-geo-db.p.rapidapi.com" };
                string[][] headers = new string[][] { apiKey, host };
                client.headers = headers;
                // making the API call and deserializing it.
                response = client.makeRequest();
                CityApi cityApiRes = JsonConvert.DeserializeObject<CityApi>(response);
                // looping over the cityData
                cityApiRes.data.ForEach(data =>
                {
                    // checking if the city wikiDataId exists in the cityCodes List
                    // if it doesn't, add it.
                    if (cityCodes.IndexOf(data.wikiDataId) == -1)
                    {
                        cityCodes.Add(data.wikiDataId);
                    }
                });
                // waiting 1 second to handle the API requests per second.
                // There can only be 1 request per second.
                await Task.Delay(1000);
                i++;
            };
            await Task.Delay(1000); // handeling the 1 request per second
            // looping over the city codes and getting the city data
            for (int i = 0; i < cityCodes.Count;)
            {
                // defining cityCode to the current cityCode in the loop.
                string cityCode = cityCodes[i];
                // Adding endPoint, Host, headers
                client.endPoint = $"https://wft-geo-db.p.rapidapi.com/v1/geo/cities/{cityCode}";
                client.host = "wft-geo-db.p.rapidapi.com";
                string[] apiKey = new string[2] { "x-rapidapi-key", "e6fba40ecbmsh53e0c124daa7214p19b766jsn4209defa38c2" };
                string[] host = new string[2] { "x-rapidapi-host", "wft-geo-db.p.rapidapi.com" };
                string[][] headers = new string[][] { apiKey, host };
                client.headers = headers;
                // making the request and deserializing the response.
                response = client.makeRequest();
                CityPopulation population = JsonConvert.DeserializeObject<CityPopulation>(response);
                // adding the population to the citizenCount.
                citizenCount += population.data.population;
                // Waiting 1.5 second for the API rate limit.
                await Task.Delay(1500);
                //
                i++;
            }
            // defining the coronaStatCount and adding to it later.
            int coronaStatCount = 0;
            // looping over the corona stats
            coronaStats.ForEach(stat =>
            {
                // cehcking if the cities contain the city of the corona stats, if it does then add the reported stats to the coronaStatCount.
                if (cities.Contains(stat.Municipality_name))
                {
                    coronaStatCount = stat.Total_reported;
                }
            });
            // when this is done handle the percentages.
            handlePercentages(citizenCount, coronaStatCount, visitedCount);
        }

        private void handlePercentages(int citizenCount, int coronaStatCount, int visitedCount)
        {
            //calculating percentage
            //int visited = Convert.ToInt32(contactBox.Text);
            int visited = visitedCount;
            #region postcodeToCitizens

            //here the Postcode will be converted to citizens, via api or hardcoded formulas


            #endregion
            int citizens = citizenCount; //is going to be replaced by the citizens in your city
                                         //int infected = 512; //is going to get replaced by the called number from an api 
                                         //int surroundedPeople = 780; //the number of people in a ? radius from your postcode
            decimal InfectedCitizen = citizenCount / coronaStatCount;
            decimal chanceInfection = visitedCount / InfectedCitizen;




            /*
             * 78754 / 1252
             * 
             * 
             * 500 / ander antwoord = 7.9%
             * 
             * 7.948802600502832
             * 7.948802600502832
             * 787.54
             */

            //printing screen based on percentage
            if (chanceInfection >= 15)
            {
                Console.WriteLine("Its higher than 15%");
                panel1.BackColor = Color.FromArgb(93, 80, 80);
                percBox.Text = "+15%";
            }
            else if (chanceInfection >= 5 && chanceInfection < 15)
            {
                Console.WriteLine("Its between 5 and 15%");
                panel1.BackColor = Color.FromArgb(238, 77, 77);
                percBox.Text = "5% - 15%";

            }
            else if (chanceInfection >= 1 && chanceInfection < 5)
            {
                Console.WriteLine("Its between 1 and 5%");
                panel1.BackColor = Color.FromArgb(236, 151, 23);
                percBox.Text = "1% - 5%";
            }
            else if (chanceInfection < 1)
            {
                Console.WriteLine("Its lower than 1%");
                panel1.BackColor = Color.FromArgb(110, 214, 30);
                percBox.Text = "-1%";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
          
        }
        private void txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(contactBox.Text.Length == 0 || postcodeTextBox.Text.Length == 0)
            {
                label4.Show();
                return;
            }
            label4.Hide();
            // getting the visitedCount from the contactBox and converting it to a Number.
            int visited = Convert.ToInt32(contactBox.Text);
            // getting the postCode from the postcodeTextBox
            string postCode = postcodeTextBox.Text;
            // getting the coronaStats
            List<coronaApi> coronaStats = getCoronaStats();
            // handle the application with all the data it has already collected.
            handleApplication(coronaStats, postCode, visited);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
