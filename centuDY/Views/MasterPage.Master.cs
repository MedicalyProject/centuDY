using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centuDY.Views
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["current_user"] != null)
            {
                btn_login.Visible = false;
            }
            else
            {
                btn_logout.Visible = false;
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/Login.aspx");
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session["current_user"] = null;
            Response.Redirect("~/Views/Pages/Login.aspx");
        }
    }
}