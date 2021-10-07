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
    public partial class StudentPayment : System.Web.UI.Page
    {
        StudentPaymentService oEmpService = new StudentPaymentService();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!this.IsPostBack)
            {
                mvStudentPayment.ActiveViewIndex = 0;
                PageLoad();
                SetFunctionName();
                //Loadddl();
                //Loaddd2();
                //Loaddd3();
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
                lblFunctionName.Text = Functions.StudentPayment.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void PageLoad()
        {

            StudentPaymentService obj = new StudentPaymentService();
            List<SPaymentDto> oClz = new List<SPaymentDto>();

            oClz = obj.GetAllData();
            gvStudentPaymentMaster.DataSource = oClz;
            gvStudentPaymentMaster.DataBind();
        }

        private void Loadddl()
        {
            ddClassCategory.DataSource = oEmpService.selectClass();
            ddClassCategory.DataTextField = "Category";
            ddClassCategory.DataValueField = "ClassID";
            ddClassCategory.DataBind();
        }
        private void Loaddd2()
        {
            ddSubject.DataSource = oEmpService.selectSub();
            ddSubject.DataTextField = "SubjectName";
            ddSubject.DataValueField = "SubjectID";
            ddSubject.DataBind();
        }
        private void Loaddd3()
        {
            ddLecturer.DataSource = oEmpService.selectLectu();
            ddLecturer.DataTextField = "FirstName";
            ddLecturer.DataValueField = "LecturerID";
            ddLecturer.DataBind();
        }

        protected void gvStudentPaymentMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Payment":
                    ViewState["index"] = e.CommandArgument.ToString();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowDeleteConfirmation();", true);

                    break;
            }
        }
        protected void gvStudentPaymentMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            StudentPaymentService obj = new StudentPaymentService();
            List<SPaymentDto> oClz = new List<SPaymentDto>();

            oClz = obj.GetData(txtSearch.Text);
            gvStudentPaymentMaster.DataSource = oClz;
            gvStudentPaymentMaster.DataBind();

            //Save();

            
        }
        
        private void ShowSuccessMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowSuccessMessage('" + msg + "');", true);
        }

        private void ShowErrorMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowErrorMessage('" + msg + "');", true);
        }
        private void InsertData()
        {
            List<ReceivedPaymentsDto> olist = new List<ReceivedPaymentsDto>();
            foreach (GridViewRow row in gvStudentPaymentMaster.Rows)
            {
                //if (row.RowType == DataControlRowType.DataRow)
                //{
                    ReceivedPaymentsDto odata = new ReceivedPaymentsDto();
                    odata.StudentId = (row.Cells[0].FindControl("lblStudentID") as Label).Text;
                    odata.SubjectId = Convert.ToInt32((row.Cells[2].FindControl("lblSubjectID") as Label).Text);
                    odata.LecturerId = (row.Cells[3].FindControl("lblLecturerID") as Label).Text;
                    odata.PriceRate = Convert.ToDouble((row.Cells[5].FindControl("lblFee") as Label).Text);
                    olist.Add(odata);

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowSuccessMessage('" + odata.SubjectId + "','" + odata.LecturerId + "','" + odata.PriceRate + "');", true);
               // }
            }

            

        }
        protected void imgbtnView_Click(object sender, ImageClickEventArgs e)
        {
            //string msg = "Clicked!";

            //string confirmValue = Request.Form["confirm_value"];

            //if (confirmValue == "Yes")
            //{
            //    InsertData();
            //}
            //else
            //{

            //}
        }

       

       

        protected void gvStudentPaymentMaster_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //int index = Convert.ToInt32(e);

            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowSuccessMessage('" + index + "');", true);


            //int 
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SPaymentDto oPayment = new SPaymentDto();
            GridViewRow oGridViewRow = gvStudentPaymentMaster.Rows[Convert.ToInt32(ViewState["index"])];
            oPayment.StudentID = ((Label)oGridViewRow.FindControl("lblStudentID")).Text;
            oPayment.SubjectID = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblSubjectID")).Text);
            oPayment.LecturerID = ((Label)oGridViewRow.FindControl("lblLecturerID")).Text;
            oPayment.PriceRate = Convert.ToInt64(((Label)oGridViewRow.FindControl("lblFee")).Text);
            oPayment.LastTransactionDate = DateTime.Now;
            oPayment.LectureStatus = 1;

            oEmpService.Insertdata(oPayment);
            oEmpService.LastPayment(oPayment);
            PageLoad();
            ShowSuccessMessage(ResponseMessages.InsertSuccess);
        }
    }
}