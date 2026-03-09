using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.Json;

namespace _260303_hw_Json
{
    public partial class TWShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "https://cloud.culture.tw/frontsite/trans/SearchShowAction.do?method=doFindTypeJ&category=2";
            string content = JsonRetrieval.GetJsonContent(url);

            var showInfos = JsonSerializer.Deserialize<IEnumerable<Show>>(content);
            GridView1.DataSource = showInfos;
            GridView1.DataBind();
            

        }

        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}