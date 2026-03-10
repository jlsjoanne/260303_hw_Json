using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.Json;

namespace _260303_hw_Json
{
    public partial class MedicalOrgDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "https://apiservice.mol.gov.tw/OdService/download/A17000000J-020057-8CT";
            string content = JsonRetrieval.GetWebContent(url);
            var medicalOrgs = JsonSerializer.Deserialize<IEnumerable<Medical>>(content);

            if (!IsPostBack)
            {
                if (Request.QueryString["OrgId"] != null)
                {
                    List<string> targetId = new List<string> { Request.QueryString["OrgId"].ToString() };
                    var selectedData = medicalOrgs
                        .Where(o => targetId.Contains(o.醫療機構代碼))
                        .Select(o => new
                        {
                            o.醫療機構名稱,
                            o.勞工健檢聯絡人,
                            o.連絡電話,
                            o.分機號碼,
                            o.認可類別及有效期限,
                            o.備註
                        });

                    Literal1.Text += "<table style=\"width:100%\" border-collapse: collapse>" +
                        "<tr>" +
                        "<th>醫療機構名稱</th>" +
                        "<th>勞工健檢聯絡人</th>" +
                        "<th>連絡電話</th>" +
                        "<th>分機號碼</th>" +
                        "<th>認可類別及有效期限</th>" +
                        "<th>備註</th>" +
                        "<tr>";

                    foreach(var item in selectedData)
                    {
                        Literal1.Text += "<tr>" +
                            "<td>" + item.醫療機構名稱 + "</td>" +
                            "<td>" + item.勞工健檢聯絡人 + "</td>" +
                            "<td>" + item.連絡電話 + "</td>" +
                            "<td>" + item.分機號碼 + "</td>" +
                            "<td>" + item.認可類別及有效期限 + "</td>" +
                            "<td>" + item.備註 + "</td>" +
                            "</tr>";
                    }

                    Literal1.Text += "</table>";
                }
                else
                {
                    Literal1.Text += "機構代碼錯誤";
                }
            }
        }
    }
}