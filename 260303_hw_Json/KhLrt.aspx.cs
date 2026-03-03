using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.Json;

namespace _260303_hw_Json
{
    public partial class KhLrt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "https://data.kcg.gov.tw/Json/Get/72e2e1e1-ede1-4fc7-a551-b91113154120";
            string content = JsonRetrieval.GetJsonContent(url);
            KhLRTRootobject root = JsonSerializer.Deserialize<KhLRTRootobject>(content);
            KhLRTData[] lrtData = root.Data;
            

            Literal1.Text += "<table style=\"width:100%\" border= 1px solid black border-collapse: collapse>" + 
                "<tr>" +
                "<th>年</th>" +
                "<th>月</th>" +
                "<th>總運量</th>" +
                "<th>日均運量</th>" +
                "<th>假日均運量</th>" +
                "<th>月台上刷卡日均筆數</th>" +
                "<th>車上刷卡日均筆數</th>" +
                "<th>售票機日均筆數</th>" +
                "<th>補票日均筆數</th>" +
                "<th>團體票日均筆數</th>" +
                "</tr>";

            foreach(var item in lrtData)
            {
                Literal1.Text += "<tr>" +
                    "<td>" + item.年 + "</td>" +
                    "<td>" + item.月 + "</td>" +
                    "<td>" + item.總運量 + "</td>" +
                    "<td>" + item.日均運量 + "</td>" +
                    "<td>" + item.假日均運量 + "</td>" +
                    "<td>" + item.月台上刷卡日均筆數 + "</td>" +
                    "<td>" + item.車上刷卡日均筆數 + "</td>" +
                    "<td>" + item.售票機日均筆數 + "</td>" +
                    "<td>" + item.補票日均筆數 + "</td>" +
                    "<td>" + item.團體票日均筆數 + "</td>" +
                    "</tr>";
            }

            Literal1.Text += "</table>";
            
        }
    }
}