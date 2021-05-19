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
    public partial class UpdateProfile : System.Web.UI.Page
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
            txt_name.Text = user.Name;

            if (user.Gender.Equals("Male"))
            {
                rb_male.Checked = true;
            } else
            {
                rb_female.Checked = true;
            }

            txt_phone_number.Text = user.PhoneNumber;
            txt_address.Text = user.Address;
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            string phoneNumber = txt_phone_number.Text;
            string address = txt_address.Text;

            User user = (User)Session["current_user"];
            int id = user.UserId;

            string response = UserController.updateProfile(id, name, rb_male.Checked, rb_female.Checked, phoneNumber, address);

            lbl_error.Text = response;

            if (response.Equals(""))
            {
                Response.Redirect("~/Views/Pages/Profile/ViewProfile.aspx");
            }
        }
    }
}