using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centuDY.Views.Pages
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_welcome.Visible = false;
            if (Session["current_user"] != null)
            {
                User logged_in_user = (User)Session["current_user"];
                lbl_welcome.Text = "Welcome, " + logged_in_user.Name;
                lbl_welcome.Visible = true;
            } else
            {
                Response.Redirect("~/Views/Pages/Login.aspx"); ;
            }
        }
    }
}