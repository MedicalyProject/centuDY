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
    public partial class ViewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User logged_in_user = (User)Session["current_user"];
                if (logged_in_user != null)
                {
                    if (!logged_in_user.Role.RoleName.Equals("Member"))
                    {
                        Response.Redirect("~/Views/Pages/Auth/Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Pages/Auth/Login.aspx");
                }

                refreshGridView(logged_in_user.UserId);
            }
        }

        private void refreshGridView(int id)
        {
            List<Cart> carts = CartController.getCartByUser(id);

            grv_user_carts.DataSource = carts;
            grv_user_carts.DataBind();
        }

        protected void btn_checkout_Click(object sender, EventArgs e)
        {

        }

        protected void grv_user_carts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grv_user_carts.Rows[e.RowIndex];
            string medicineId = row.Cells[0].Text;

            User logged_in_user = (User)Session["current_user"];

            lbl_delete_error.Text = CartController.deleteCart(logged_in_user.UserId, medicineId);

            refreshGridView(logged_in_user.UserId);
        }
    }
}