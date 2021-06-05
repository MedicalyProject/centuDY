using centuDY.Controllers;
using centuDY.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace centuDY.Views.Pages.Admin
{
    public partial class ViewTransactionsReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CentuDY_Report report = new CentuDY_Report();
            crv_centuDY.ReportSource = report;
            report.SetDataSource(DataSetController.getDataset());
        }
    }
}