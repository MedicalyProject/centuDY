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
    public partial class ViewUsers : System.Web.UI.Page
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
                        Response.Redirect("~/Views/Pages/Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Pages/Login.aspx");
                }

                refreshGridView();
            }
        }

        private void refreshGridView()
        {
            List<User> users = UserController.getMembers();

            grv_members.DataSource = users;
            grv_members.DataBind();
        }

        protected void grv_members_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grv_members.Rows[e.RowIndex];
            string id = row.Cells[0].Text;

            lbl_delete_error.Text = UserController.deleteMemberById(id);
            refreshGridView();
        }
    }
}