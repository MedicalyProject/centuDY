using centuDY.Controllers;
using centuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centuDY.Views.Pages
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_welcome.Visible = false;
            if (Session["current_user"] != null)
            {
                User logged_in_user = (User)Session["current_user"];
                lbl_welcome.Text = "Welcome, " + logged_in_user.Name;
                lbl_welcome.Visible = true;
                if (logged_in_user.RoleId == 2)
                {
                    refreshGridView();
                }
                
            } else
            {
                Response.Redirect("~/Views/Pages/Auth/Login.aspx"); ;
            }
        }

        private void refreshGridView()
        {
            List<Medicine> medicines = MedicineController.getRandomMedicines();

            grv_medicines.DataSource = medicines;
            grv_medicines.DataBind();
        }

        protected void grv_medicines_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = grv_medicines.Rows[index];

                string id = row.Cells[0].Text;
                Response.Redirect("~/Views/Pages/Member/AddToCart.aspx?id=" + id);
            }
        }
    }
}