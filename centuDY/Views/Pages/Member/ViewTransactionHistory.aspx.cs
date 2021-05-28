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
    public partial class ViewTransactionHistory : System.Web.UI.Page
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
                lbl_user_name.Text += logged_in_user.Name;
                refreshGridView(logged_in_user.UserId);
            }
        }

        private void refreshGridView(int id)
        {
            List<DetailTransaction> transactions = TransactionController.getTransactionByUser(id);
            grv_user_transactions.DataSource = transactions;
            grv_user_transactions.DataBind();
            calculateGrandTotal();
        }

        //kalkulasi grand total dari semua histori transaksi
        private void calculateGrandTotal()
        {
            int sum = 0;
            for (int i = 0; i < grv_user_transactions.Rows.Count; i++)
            {
                Label subtotal = (Label)grv_user_transactions.Rows[i].FindControl("lbl_sub_total");
                sum += int.Parse(subtotal.Text);
            }
            lbl_grand_total.Text = sum.ToString();
        }
    }
}