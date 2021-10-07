using HMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HMS.Model;
using HMS.Service;

namespace SOAPS.Pages
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private DashboardService oDash = new DashboardService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                PageLoad();
                if (Session["result"] != "match")
                {
                    Response.Redirect("~/pages/Login.aspx");
                }
            }
        }

        private void PageLoad()
        {
            lblProcessDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            SetFunctionName();
            int StudentCount = oDash.GetstudentCount();
            int ClassCount = oDash.GetstudentCount();
            int MonthlyIncome = oDash.GetMonthlyIncome();
            lblStudentCount.Text = Convert.ToInt32(StudentCount).ToString();
            lblClassCount.Text = Convert.ToInt32(ClassCount).ToString();
            lblMonthlyIncome.Text = Convert.ToInt32(MonthlyIncome).ToString();

        }
        private void SetFunctionName()
        {
            try
            {
                Label lblFunctionName = this.Master.FindControl("lblFuncationName") as Label;
                lblFunctionName.Text = Functions.Dashboard.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}