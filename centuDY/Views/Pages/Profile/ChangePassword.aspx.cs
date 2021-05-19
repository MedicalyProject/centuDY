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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["current_user"] == null)
                {
                    Response.Redirect("~/Views/Pages/Auth/Login.aspx");
                }
            }

            if (!(string.IsNullOrEmpty(txt_old_password.Text.Trim())))
            {
                txt_old_password.Attributes["value"] = txt_old_password.Text;
            }
            if (!(string.IsNullOrEmpty(txt_new_password.Text.Trim())))
            {
                txt_new_password.Attributes["value"] = txt_new_password.Text;
            }

            if (!(string.IsNullOrEmpty(txt_confirm_password.Text.Trim())))
            {
                txt_confirm_password.Attributes["value"] = txt_confirm_password.Text;
            }
        }


        protected void btn_update_Click(object sender, EventArgs e)
        {
            string oldPassword = txt_old_password.Text;
            string newPassword = txt_new_password.Text;
            string confirmPassword = txt_confirm_password.Text;

            User user = (User)Session["current_user"];
            int id = user.UserId;

            string response = UserController.updatePassword(id, oldPassword, newPassword, confirmPassword);

            lbl_error.Text = response;

            if (response.Equals(""))
            {
                Response.Redirect("~/Views/Pages/Profile/ViewProfile.aspx");
            }
        }
    }
}