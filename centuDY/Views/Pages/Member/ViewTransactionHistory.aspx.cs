using centuDY.Controllers;
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
            GrandTotalCustomer();
        }

        private int grandTotal = 0;
        private int grandGrandTotal = 0;
        private int storeid = 0;
        private int rowIndex = 1;

        //grand total dari semua histori transaksi untuk customer yg logged in
        private void GrandTotalCustomer()
        {
            lbl_grand_total.Text = grandGrandTotal.ToString();
        }
        
        protected void grv_user_transactions_RowCreated(object sender, GridViewRowEventArgs e)
        {
            bool newRow = false;
            //untuk transaksi biasa (bukan akhir)
            if ((storeid > 0) && (DataBinder.Eval(e.Row.DataItem, "TransactionId") != null))
            {
                //jika row baru transaction id nya berbeda dengan row sebelumnya, buat row grand total baru
                if (storeid != Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TransactionId").ToString()))
                    newRow = true;
            }
            //untuk transaksi paling akhir (row indexnya akan -1 karena diluar bound)
            if ((storeid > 0) && (DataBinder.Eval(e.Row.DataItem, "TransactionId") == null))
            {
                newRow = true;
                rowIndex = 0;
            }
            if (newRow)
            {
                //menyiapkan variabel dan setting untuk row grand total
                GridView gv_tran = (GridView)sender;
                GridViewRow NewTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                NewTotalRow.Font.Bold = true;

                //untuk membuat cell dengan judul Grand Total
                TableCell Cell = new TableCell();
                Cell.Text = "Grand Total";
                Cell.ColumnSpan = 4;
                NewTotalRow.Cells.Add(Cell);

                //untuk membuat cell untuk hasil grand totalnya per transaction id
                Cell = new TableCell();
                Cell.Text = grandTotal.ToString();
                NewTotalRow.Cells.Add(Cell);

                //masukkan grand total row berdasarkan posisi index row skrg + jumlah row index grand total yang sudah dibuat
                //(kecuali jika ini adalah transaksi terakhir, rowIndex = 0 agar tidak bergeser ke atas)
                gv_tran.Controls[0].Controls.AddAt(e.Row.RowIndex + rowIndex, NewTotalRow);

                //jumlah row index untuk grand total bertambah, grandTotal di reset menjadi 0 karena sudah transaksi baru
                rowIndex++;
                grandTotal = 0;
            }
        }

        protected void grv_user_transactions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //untuk menyimpan row data saat ini masih dalam satu transaksi yang sama atau tidak
                storeid = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TransactionId").ToString());

                //untuk row data saat ini, jumlahkan dahulu subtotal yang ada (dari hasil qty * price)
                int subtotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem,"Quantity").ToString()) * 
                               Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Medicine.Price").ToString());
                grandTotal += subtotal;
                grandGrandTotal += subtotal;
            }
        }
    }
}