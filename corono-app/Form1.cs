using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //calculating percentage
            int citizens = 35000; //is going to be replaced by the citizens in your city
          //int infected = 512; //is going to get replaced by the called number from an api 
            int visited = 460; //the amount of people you talked to or passed by 
          //int surroundedPeople = 780; //the number of people in a ? radius from your postcode
            float chanceInfectionsS = (visited / citizens) * 100; //chance you were infected
         
            //printing screen based on percentage
            if (chanceInfectionsS => 15)
            {
                //print black screen
            }
            else if (chanceInfectionsS => 5 < 15)
            {
                //print red screen
            }
            else if (chanceInfectionsS => 1 < 5)
            {
                //print screen 1-5%
            }
            else if (chanceInfectionsS < 1)
            {
                //print -1% screen
            }
        }

            private void txtbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
