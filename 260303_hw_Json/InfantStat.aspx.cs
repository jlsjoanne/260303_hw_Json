using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.Json;

namespace _260303_hw_Json
{
    public partial class InfantStat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "https://www.ris.gov.tw/rs-opendata/api/v1/datastore/ODRP059/108";
            string content = JsonRetrieval.GetJsonContent(url);
            InfantRoot root = JsonSerializer.Deserialize<InfantRoot>(content);
            Infant[] infantStat = root.responseData;

            Literal1.Text += "<table style=\"width:100%\" border-collapse: collapse>" +
                "<tr>" +
                "<th>statistic_yy</th>" +
                "<th>according</th>" +
                "<th>site_id</th>" +
                "<th>birth_sex</th>" +
                "<th>mother_nation</th>" +
                "<th>mother_age</th>" +
                "<th>mother_education</th>" +
                "<th>birth_count</th>" +
                "</tr>";

            foreach(var item in infantStat)
            {
                Literal1.Text += "<tr>" +
                    "<td>" + item.statistic_yyy + "</td>" +
                    "<td>" + item.according + "</td>" +
                    "<td>" + item.site_id + "</td>" +
                    "<td>" + item.birth_sex + "</td>" +
                    "<td>" + item.mother_nation + "</td>" +
                    "<td>" + item.mother_age + "</td>" +
                    "<td>" + item.mother_education + "</td>" +
                    "<td>" + item.birth_count + "</td>" +
                    "</tr>";
            }
            Literal1.Text += "</table>";
        }
    }
}