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
            string url = "https://apiservice.mol.gov.tw/OdService/download/A17000000J-020057-8CT";
            string content = JsonRetrieval.GetWebContent(url);
            var medicalOrgs = JsonSerializer.Deserialize<IEnumerable<Medical>>(content);

            if (!IsPostBack)
            {
                //Add table header
                Literal1.Text += "<table style=\"width:100%\" border-collapse: collapse>" +
                    "<tr>" +
                    "<th>縣市別</th>" +
                    "<th>醫療機構代碼</th>" +
                    "<th>醫療機構名稱</th>" +
                    "<th>醫療機構地址</th>" +
                    "</tr>";

                foreach(var item in medicalOrgs)
                {
                    Literal1.Text += "<tr>" +
                        "<td>" + item.縣市別 + "</td>" +
                        "<td>" + item.醫療機構代碼 + "</td>" +
                        "<td>" + $"<a href=\"MedicalOrgDetails?OrgId={item.醫療機構代碼}\">" + item.醫療機構名稱 + "</a></td>" +
                        "<td>" + item.醫療機構地址 + "</td>" +
                        "</tr>";
                }

                Literal1.Text += "</table>";
            }
            
            

            

            
                

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string orgId = Request.QueryString["OrgId"].ToString();
            Response.Redirect($"MedicalOrg.aspx?OrgId={orgId}");
        }
    }
}