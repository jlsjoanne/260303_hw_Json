using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _260303_hw_Json
{
    public partial class TWShowDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UID"] != null)
            {
                ShowInfo[] showinfo = (ShowInfo[]) Session["showInfo"];
                GridView1.DataSource = showinfo.ToList();
                GridView1.DataBind();
            }
        }
    }
}