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

            if (!IsPostBack)
            {
                string url = "https://iplay.sports.gov.tw/api/GymSearchAllList?$format=application/json&City=高雄市";
                string content = JsonRetrieval.GetWebContent(url);
                Literal1.Text += $"{url}<br />" + content;
                //GymRootobject root = JsonSerializer.Deserialize<GymRootobject>(content);
                //List<Gym> gymData = root.gymData.ToList();
                //Gym gymDT1 = gymData[0];
                //Literal1.Text += gymDT1.GymID + "\t" + gymDT1.Name + "\t" + gymDT1.Address;

            }


        }


    }
}