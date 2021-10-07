using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HMS.Model;
using HMS.Service;

namespace HMS.Pages
{
    public partial class LecturerPayment : System.Web.UI.Page
    {
        LecturePaymentService oEmpService = new LecturePaymentService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                mvLecturerPayment.ActiveViewIndex = 0;
                PageLoad();
                SetFunctionName();
                if (Session["result"] != "match")
                {
                    Response.Redirect("~/pages/Login.aspx");
                }

            }
        }
        private void SetFunctionName()
        {
            try
            {
                Label lblFunctionName = this.Master.FindControl("lblFuncationName") as Label;
                lblFunctionName.Text = Functions.LecturerPayment.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void PageLoad()
        {

            LecturePaymentService obj = new LecturePaymentService();
            List<ReceivedPaymentsDto> oClz = new List<ReceivedPaymentsDto>();

            oClz = obj.GetAllData();
            gvLecturerPaymentMaster.DataSource = oClz;
            gvLecturerPaymentMaster.DataBind();
        }
        protected void gvLecturerPaymentMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Payment":
                    ViewState["index"] = e.CommandArgument.ToString();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowDeleteConfirmation();", true);

                    break;
            }
        }

        protected void gvLecturerPaymentMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void imgbtnView_Click(object sender, ImageClickEventArgs e)
        {

           
        }
        private void ShowSuccessMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowSuccessMessage('" + msg + "');", true);
        }

        private void ShowErrorMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowErrorMessage('" + msg + "');", true);
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            LecturePaymentService obj = new LecturePaymentService();
            List<ReceivedPaymentsDto> oClz = new List<ReceivedPaymentsDto>();

            oClz = obj.GetData(txtSearch.Text);
            gvLecturerPaymentMaster.DataSource = oClz;
            gvLecturerPaymentMaster.DataBind();
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
        

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            LecturePaymentDto oLectPayment = new LecturePaymentDto();
            ReceivedPaymentsDto oRecevedpay = new ReceivedPaymentsDto();
            GridViewRow oGridViewRow = gvLecturerPaymentMaster.Rows[Convert.ToInt32(ViewState["index"])];

            string lectureid = ((Label)oGridViewRow.FindControl("lblLecturerID")).Text;
            decimal Total = Convert.ToDecimal(((Label)oGridViewRow.FindControl("lblFee")).Text);
            int SubjectID = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblSubjectID")).Text);

            decimal rate = oEmpService.Getrate(lectureid);

            decimal Cost = Total * (rate/100);

            decimal NetAmount = Total - Cost;

            oLectPayment.LectureID = lectureid.ToString();
            oLectPayment.SubjectID = Convert.ToInt32(SubjectID);
            oLectPayment.Cost = Convert.ToDecimal(Cost);
            oLectPayment.Price = Convert.ToDecimal(NetAmount);
            oLectPayment.TransactionDate = DateTime.Now;

            oRecevedpay.LecturerId = lectureid.ToString();
            oRecevedpay.SubjectId = Convert.ToInt32(SubjectID);
            oRecevedpay.LectureStatus = 2;

            oEmpService.Insertdata(oLectPayment);
            oEmpService.Updatestatus(oRecevedpay);

            ShowSuccessMessage(ResponseMessages.Payment);
            PageLoad();
        }
    }
}