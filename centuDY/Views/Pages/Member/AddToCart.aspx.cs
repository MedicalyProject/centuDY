using centuDY.Controllers;
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centuDY.Views.Pages.Member
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["current_user"] != null)
                {
                    User logged_in_user = (User)Session["current_user"];

                    if (!logged_in_user.Role.RoleName.Equals("Member"))
                    {
                        Response.Redirect("~/Views/Pages/Auth/Login.aspx");
                    }
                    string id = Request["id"];

                    Medicine medicine = MedicineController.getMedicineById(id);

                    txt_name.Text = medicine.Name;
                    txt_description.Text = medicine.Description;
                    txt_stock.Text = medicine.Stock.ToString();
                    txt_price.Text = medicine.Price.ToString();
                }
                else
                {
                    Response.Redirect("~/Views/Pages/Auth/Login.aspx");
                }
            }
        }

        //execute ketika button add to cart diklik
        protected void btn_add_to_cart_Click(object sender, EventArgs e)
        {
            string qty = txt_qty.Text;

            string id = Request["id"];
            User currentUser = (User)Session["current_user"];

            string response = CartController.addItemToCart(currentUser.UserId,id,qty);

            lbl_error.Text = response;

            if (response.Equals(""))
            {
                Response.Redirect("~/Views/Pages/Member/ViewCart.aspx");
            }
        }
    }
}