using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centuDY.Views.Pages
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_welcome.Visible = false;
            if (Session["loggedInUserName"] != null)
            {
                lbl_welcome.Text = "Welcome, " + Session["loggedInUserName"].ToString();
                lbl_welcome.Visible = true;
            }
        }
    }
}