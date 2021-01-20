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
using Newtonsoft.Json;

namespace corono_app
{
    public partial class Form1 : Form
    {
        RESTClient client = new RESTClient();
        class jsonDeserialize
        {
            public DataSet results { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            /*
             CITY API
            client.endPoint = "https://wft-geo-db.p.rapidapi.com/v1/geo/countries/NL/regions/FR/cities";
            string[] headers1 = new string[2] {"x-rapidapi-key", "e6fba40ecbmsh53e0c124daa7214p19b766jsn4209defa38c2" };
            string[] headers2 = new string[2] { "x-rapidapi-host", "wft-geo-db.p.rapidapi.com" };
            string[][] headers = new string[][] { headers1, headers2 };
            client.headers = headers;
            client.host = "wft-geo-db.p.rapidapi.com";
            */
            /*
             POST CODE API
            client.endPoint = "https://api.spikkl.nl/geo/nld/lookup.json?postal_code=2611HB&filter=postal_code,street_name,city,municipality,administrative_areas,country&key=2e6a697089bb6b7ae817737d21d080dd";
            client.host = "api.spikkl.nl";
            string[][] headers = new string[][] { };
            client.headers = headers;
            */
            /*
             Corona statistieken API
            client.endPoint = "https://geodata.rivm.nl/covid-19/COVID-19_aantallen_gemeente_cumulatief.json";
            client.host = "geodata.rivm.nl";
            string[][] headers = new string[][] { };
            client.headers = headers;
            */
            //string response = client.makeRequest();
            //Console.WriteLine(response);
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
            //get city from postcode
            string postcode = textBox1.Text.ToLower();
            client.endPoint = "https://api.spikkl.nl/geo/nld/lookup.json?postal_code=" + postcode + "&filter=city&key=2e6a697089bb6b7ae817737d21d080dd";
            client.host = "api.spikkl.nl";
            string[][] headers = new string[][] { };
            client.headers = headers;
            //string response = client.makeRequest();
            string response = "{\"results\":[{\"postal_code\":\"8933CL\",\"match\":\"approximate\"}],\"status\":\"ok\",\"meta\":{\"timestamp\":1611139326473,\"trace_id\":\"8e386fbdeadcf115a587a09a\"}}";
            postCodeApi responseDeser = JsonConvert.DeserializeObject<postCodeApi>(response);
            //DataTable dataTable = responseDeser.Tables["results"];
            Console.WriteLine(responseDeser);

            //calculating percentage
            int visited = Convert.ToInt32(contactBox.Text);
            #region postcodeToCitizens
            
            //here the Postcode will be converted to citizens, via api or hardcoded formulas


            #endregion 
            int citizens = 35000; //is going to be replaced by the citizens in your city
          //int infected = 512; //is going to get replaced by the called number from an api 
          //int surroundedPeople = 780; //the number of people in a ? radius from your postcode
            float chanceInfectionsS = (visited / citizens) * 100; //chance you were infected
         
            //printing screen based on percentage
            if (chanceInfectionsS >= 15)
            {
               
            }
            else if (chanceInfectionsS >= 5 && chanceInfectionsS < 15)
            {
               
            }
            else if (chanceInfectionsS >= 1 && chanceInfectionsS  < 5)
            {
               
               
            }
            else if (chanceInfectionsS < 1)
            {
              
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
