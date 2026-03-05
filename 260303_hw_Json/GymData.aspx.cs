using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.Json;

namespace _260303_hw_Json
{
    public partial class GymData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //if (!IsPostBack)
            //{
            //    string url = "https://iplay.sa.gov.tw/api/GymSearchAllList?$format=application/json";
            //    string content = JsonRetrieval.GetJsonContentAsync(url).Result;
            //    GymRootobject root = JsonSerializer.Deserialize<GymRootobject>(content);
            //    List<Gym> gymData = root.gymData.ToList();
            //    Gym gymDT1 = gymData[0];
            //    Literal1.Text += gymDT1.GymID + "\t" + gymDT1.Name + "\t" + gymDT1.Address;
                
            //}
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string url = "https://iplay.sa.gov.tw/api/GymSearchAllList?$format=application/json";
            string content = JsonRetrieval.GetJsonContent(url);
            Literal1.Text += content;
            //GymRootobject root = JsonSerializer.Deserialize<GymRootobject>(content);
            //List<Gym> gymData = root.gymData.ToList();
            //Gym gymDT1 = gymData[0];
            //Literal1.Text += gymDT1.GymID + "\t" + gymDT1.Name + "\t" + gymDT1.Address;
        }
    }
}