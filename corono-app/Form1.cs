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
            init();
        }

        private void init()
        {

            RESTClient client = new RESTClient();
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
            string response = client.makeRequest();
            Console.WriteLine(response);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
