using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.Json;

namespace _260303_hw_Json
{
    public partial class MedicalOrg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "https://data.fda.gov.tw/data/opendata/export/198/json";
            string content = JsonRetrieval.GetJsonContent(url);
            var medicalOrgs = JsonSerializer.Deserialize<IEnumerable<Medical>>(content);

            //Add table header
            Literal1.Text += "<table style=\"width:100%\" border-collapse: collapse>" +
                "<tr>" +
                "<th>機構代碼</th>" +
                "<th>機構名稱</th>" +
                "</tr>";

            foreach(var org in medicalOrgs)
            {
                Literal1.Text += "<tr>" +
                    "<td>" + org.機構代碼 + "</td>" +
                    "<td>" + $"<a href=\"Medical.aspx?Org={org.機構代碼}\">" + org.機構名稱 + "</a></td>" +
                    "<tr>";
            }

            Literal1.Text += "</table>";

            if (!IsPostBack)
            {
                if (Request.QueryString["Org"] != null)
                {
                    Literal1.Text = "<table style=\"width:100%\" border-collapse: collapse>" +
                        "<tr>" +
                        "<th>種類</th>" +
                        "<th>地址</th>" +
                        "<th>電話</th>" +
                        "<th>開業狀態</th>" +
                        "</tr>";

                    foreach(var org in medicalOrgs)
                    {
                        Literal1.Text += "<tr>" +
                            "<td>" + org.種類 + "</td>" +
                            "<td>" + org.地址 + "</td>" +
                            "<td>" + org.電話 + "</td>" +
                            "<td>" + org.開業狀態 + "</td>" +
                            "</tr>";
                    }

                    Literal1.Text += "</table>";
                }
            }
        }
    }
}