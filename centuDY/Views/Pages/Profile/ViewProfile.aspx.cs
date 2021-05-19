using centuDY.Controllers;
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centuDY.Views.Pages.Profile
{
    public partial class ViewProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["current_user"] != null)
                {
                    User logged_in_user = (User)Session["current_user"];

                    init(UserController.getUser(logged_in_user.UserId));
                }
                else
                {
                    Response.Redirect("~/Views/Pages/Auth/Login.aspx");
                }
            }
        }

        private void init(User user)
        {
            lbl_view_profile.Text = "Hello, " + user.Name;

            txt_username.Text = user.Username;
            txt_name.Text = user.Name;
            txt_gender.Text = user.Gender;
            txt_phone_number.Text = user.PhoneNumber;
            txt_address.Text = user.Address;
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/Profile/UpdateProfile.aspx");
        }

        protected void btn_change_password_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/Profile/ChangePassword.aspx");
        }
    }
}