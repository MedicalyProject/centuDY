using centuDY.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centuDY.Views.Pages.Auth
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(txt_password.Text.Trim())))
            {
                txt_password.Attributes["value"] = txt_password.Text;
            }
            if (!(String.IsNullOrEmpty(txt_confirm_password.Text.Trim())))
            {
                txt_confirm_password.Attributes["value"] = txt_confirm_password.Text;
            }
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            lbl_error.Text = AuthController.register(txt_username.Text, txt_password.Text, txt_confirm_password.Text, txt_name.Text, rb_male.Checked, rb_female.Checked, txt_phone_number.Text, txt_address.Text);
            if (lbl_error.Text.Equals("Sucess Register User!"))
            {
                hpr_login.NavigateUrl = "/Views/Pages/Auth/Login.aspx";
                hpr_login.Visible = true;
            }
        }
    }
}