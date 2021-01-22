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
            RESTClient client = new RESTClient();
            client.endPoint = "https://geodata.rivm.nl/covid-19/COVID-19_aantallen_gemeente_cumulatief.json";
            client.host = "geodata.rivm.nl";
            client.headers = new string[][] { };
            string response = client.makeRequest();
            List<coronaApi> coronaStatsRes = JsonConvert.DeserializeObject<List<coronaApi>>(response);
            List<coronaApi> coronaStats = new List<coronaApi>();
            bool existDateNow = coronaStats.Exists(d => d.Date_of_report.Date == DateTime.Now.AddDays(-1).Date);
            coronaStatsRes.ForEach(res =>
            {
                if (res.Date_of_report.Date == (existDateNow ? DateTime.Now.Date : DateTime.Now.AddDays(-1).Date))
                {
                    coronaStats.Add(res);
                    return;
                }
                return;
            });
            return coronaStats;
        }

        private async void handleApplication(List<coronaApi> coronaStats, string postCode, int visitedCount)
        {
            RESTClient client = new RESTClient();
            string postcode = postCode;
            client.endPoint = $"https://api.spikkl.nl/geo/nld/lookup.json?postal_code={postcode}&filter=postal_code,street_name,city,municipality,administrative_areas,country&key=b6ee7d920ad5f67335a422f220f93cfc";
            client.host = "api.spikkl.nl";
            client.headers = new string[][] { };
            string response = client.makeRequest();
            postCodeApi postCodeResults = JsonConvert.DeserializeObject<postCodeApi>(response);
            List<string> cities = new List<string>();
            postCodeResults.results.ForEach(res =>
            {
                if (res.postal_code != postcode) { return; }
                int pos = cities.IndexOf(res.city);
                if (pos == -1)
                {
                    cities.Add(res.city);
                }
            });
            int citizenCount = 0;
            List<string> cityCodes = new List<string>();
            for (int i = 0; i < cities.Count;)
            {
                string city = cities[i];
                client.endPoint = $"https://wft-geo-db.p.rapidapi.com/v1/geo/countries/NL/regions/FR/cities?namePrefix={city}";
                client.host = "wft-geo-db.p.rapidapi.com";
                string[] apiKey = new string[2] { "x-rapidapi-key", "e6fba40ecbmsh53e0c124daa7214p19b766jsn4209defa38c2" };
                string[] host = new string[2] { "x-rapidapi-host", "wft-geo-db.p.rapidapi.com" };
                string[][] headers = new string[][] { apiKey, host };
                client.headers = headers;
                response = client.makeRequest();
                CityApi cityApiRes = JsonConvert.DeserializeObject<CityApi>(response);
                cityApiRes.data.ForEach(data =>
                {
                    if (cityCodes.IndexOf(data.wikiDataId) == -1)
                    {
                        cityCodes.Add(data.wikiDataId);
                    }
                });
                await Task.Delay(1000);
                i++;
            };
            await Task.Delay(1000); // handeling the 1 request per second
            for (int i = 0; i < cityCodes.Count;)
            {
                string cityCode = cityCodes[i];
                client.endPoint = $"https://wft-geo-db.p.rapidapi.com/v1/geo/cities/{cityCode}";
                client.host = "wft-geo-db.p.rapidapi.com";
                string[] apiKey = new string[2] { "x-rapidapi-key", "e6fba40ecbmsh53e0c124daa7214p19b766jsn4209defa38c2" };
                string[] host = new string[2] { "x-rapidapi-host", "wft-geo-db.p.rapidapi.com" };
                string[][] headers = new string[][] { apiKey, host };
                client.headers = headers;
                response = client.makeRequest();
                CityPopulation population = JsonConvert.DeserializeObject<CityPopulation>(response);
                citizenCount += population.data.population;
                // Waiting 1 second for the API rate limit.
                await Task.Delay(1500);
                //
                i++;
            }
            int coronaStatCount = 0;
            coronaStats.ForEach(stat =>
            {
                if (cities.Contains(stat.Municipality_name))
                {
                    coronaStatCount = stat.Total_reported;
                }
            });
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
            }
            else if (chanceInfection >= 5 && chanceInfection < 15)
            {
                Console.WriteLine("Its between 5 and 15%");
                panel1.BackColor = Color.FromArgb(238, 77, 77);

            }
            else if (chanceInfection >= 1 && chanceInfection < 5)
            {
                Console.WriteLine("Its between 1 and 5%");
                panel1.BackColor = Color.FromArgb(236, 151, 23);

            }
            else if (chanceInfection < 1)
            {
                Console.WriteLine("Its lower than 1%");
                panel1.BackColor = Color.FromArgb(110, 214, 30);

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
            int visited = Convert.ToInt32(contactBox.Text);
            string postCode = postcodeTextBox.Text;
            List<coronaApi> coronaStats = getCoronaStats();
            handleApplication(coronaStats, postCode, visited);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
