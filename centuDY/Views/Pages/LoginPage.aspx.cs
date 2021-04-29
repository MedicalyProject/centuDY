using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using centuDY.Handlers;
using centuDY.Models;
using centuDY.Repositories;

namespace centuDY.Views.Pages
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_error.Visible = false;
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string email = txt_email.Text;
            string password = txt_password.Text;
            bool is_checked = chk_remember.Checked;

            User user = UserHandlers.getUserByEmailAndPassword(email, password);

            if (user == null)
            {
                lbl_error.Visible = true;
            }
            else
            {
                Session["loggedInUserId"] = user.UserId;
                Session["loggedInUserName"] = user.Name;
                Session["loggedInUserType"] = user.Role;
                if (is_checked == true)
                {
                    HttpCookie cookie = new HttpCookie("loginCookie");
                    cookie.Value = user.UserId.ToString();
                    cookie.Expires = DateTime.Now.AddHours(1);

                    Response.Cookies.Add(cookie);
                }
            }

            Response.Redirect("~/Views/Pages/HomePage.aspx");
        }
    }
}