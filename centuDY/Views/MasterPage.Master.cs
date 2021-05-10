using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centuDY.Views
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["current_user"] != null)
            {
                User logged_in_user = (User)Session["current_user"];

                if (!logged_in_user.Role.RoleName.Equals("Administrator"))
                {
                    btn_insert_medicine.Visible = false;
                    btn_view_users.Visible = false;
                    btn_view_transactions_report.Visible = false;
                } else
                {
                    btn_view_cart.Visible = false;
                    btn_view_transaction_history.Visible = false;
                }
            }
            else
            {
                btn_view_medicine.Visible = false;
                btn_view_profile.Visible = false;
                btn_insert_medicine.Visible = false;
                btn_view_users.Visible = false;
                btn_view_transactions_report.Visible = false;
                btn_view_cart.Visible = false;
                btn_view_transaction_history.Visible = false;
                btn_logout.Visible = false;
            }
        }


        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session["current_user"] = null;
            Response.Redirect("~/Views/Pages/Login.aspx");
        }

        protected void btn_view_transactions_report_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/Admin/ViewTransactionsReport.aspx");
        }

        protected void btn_view_users_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/Admin/ViewUsers.aspx");
        }

        protected void btn_insert_medicine_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/Admin/InsertMedicine.aspx");
        }

        protected void btn_view_transaction_history_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/Member/ViewTransactionHistory.aspx");
        }

        protected void btn_view_cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/Member/ViewCart.aspx");
        }

        protected void btn_view_profile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/ViewProfile.aspx");
        }

        protected void btn_view_medicine_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/ViewMedicine.aspx");
        }
    }
}