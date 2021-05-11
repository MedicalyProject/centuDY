using centuDY.Controllers;
using centuDY.Handlers;
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centuDY.Views.Pages
{
    public partial class ViewMedicine : System.Web.UI.Page
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
                        btn_insert.Visible = false;
                        grv_medicines.Columns[5].Visible = false;
                    }
                    else
                    {
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Pages/Login.aspx");
                }

                refreshGridView();
            }
        }

        protected void grv_medicines_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grv_medicines.Rows[e.RowIndex];
            string id = row.Cells[0].Text;

            lbl_delete_error.Text = MedicineController.deleteMedicineById(id);
            refreshGridView();
        }

        protected void grv_medicines_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = grv_medicines.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text;
            Response.Redirect("~/Views/Pages/Admin/UpdateMedicine.aspx?id=" + id);
        }

        private void refreshGridView()
        {
            List<Medicine> medicines = MedicineController.getAllMedicine();

            grv_medicines.DataSource = medicines;
            grv_medicines.DataBind();
        }

        protected void btn_filter_Click(object sender, EventArgs e)
        {
            List<Medicine> medicines = MedicineController.getMedicineName(txt_name.Text);

            if (medicines != null)
            {

                grv_medicines.DataSource = medicines;
                grv_medicines.DataBind();
                
                return;
            }

            lbl_delete_error.Text = "[!] Medicine not found";
        }

        protected void btn_insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/Admin/InsertMedicine.aspx");
        }
    }
}