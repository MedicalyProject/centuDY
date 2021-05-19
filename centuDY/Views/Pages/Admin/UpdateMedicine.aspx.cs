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
    public partial class UpdateMedicine : System.Web.UI.Page
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


                    string id = Request["id"];

                    Medicine medicine = MedicineController.getMedicineById(id);

                    txt_name.Text = medicine.Name;
                    txt_description.Text = medicine.Description;
                    txt_stock.Text = medicine.Stock.ToString();
                    txt_price.Text = medicine.Price.ToString();
                } else
                {
                    Response.Redirect("~/Views/Pages/Auth/Login.aspx");
                }          
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            string description = txt_description.Text;
            string stock = txt_stock.Text;
            string price = txt_price.Text;

            string id = Request["id"];

            string response = MedicineController.updateMedicine(id, name, description, stock, price);

            lbl_error.Text = response;

            if (response.Equals(""))
            {
                Response.Redirect("~/Views/Pages/ViewMedicine.aspx");
            }
        }
    }
}