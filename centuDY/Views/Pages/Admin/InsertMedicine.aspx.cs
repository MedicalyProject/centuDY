using centuDY.Controllers;
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centuDY.Views.Pages.Admin
{
    public partial class InsertMedicine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["current_user"] != null)
                {
                    User logged_in_user = (User)Session["current_user"];

                    if (!logged_in_user.Role.RoleName.Equals("Administrator"))
                    {
                        Response.Redirect("~/Views/Pages/Auth/Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Pages/Auth/Login.aspx");
                }
            }
        }

        protected void btn_insert_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            string description = txt_description.Text;
            string price = txt_price.Text;
            string stock = txt_stock.Text;

            lbl_error.Text = MedicineController.addMedicine(name, description, stock, price);
        }
    }
}