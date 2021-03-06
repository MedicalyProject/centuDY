using centuDY.Controllers;
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centuDY.Views.Pages.Auth
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies.Get("loginCookie") != null)
            {
                User user  = UserController.getUser(int.Parse(Request.Cookies.Get("loginCookie").Value));

                txt_username.Attributes.Add("value",user.Username);
                txt_password.Attributes.Add("value", user.Password);
            }

            if ((Session["current_user"] != null))
            {
                Response.Redirect("~/Views/Pages/Home.aspx");
            }

            lbl_error.Visible = false;

            hpr_register.NavigateUrl = "/Views/Pages/Auth/Register.aspx";
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;
            bool is_checked = chk_remember.Checked;
            System.Diagnostics.Debug.WriteLine(username + ", " + password);
            User user = AuthController.login(username, password);

            if (user == null)
            {
                System.Diagnostics.Debug.WriteLine("user login nonexistant");
                lbl_error.Visible = true; 
                return;
            }
            else
            {
                Session["current_user"] = user;
                if (is_checked == true)
                {
                    HttpCookie cookie = new HttpCookie("loginCookie");
                    cookie.Value = user.UserId.ToString();
                    cookie.Expires = DateTime.Now.AddHours(1);

                    Response.Cookies.Add(cookie);
                }
            }

            Response.Redirect("~/Views/Pages/Home.aspx");
        }
    }
}