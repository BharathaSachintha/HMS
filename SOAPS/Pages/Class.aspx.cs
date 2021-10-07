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
    public partial class Class : System.Web.UI.Page
    {
        private ClassMasterService oEmpService = new ClassMasterService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                mvClass.ActiveViewIndex = 0;

                List<ClassMasterDto> oClz = new List<ClassMasterDto>();
                oClz = oEmpService.GetData();
                gvClassMaster.DataSource = oClz;
                gvClassMaster.DataBind();
                Loadddl();
                Loaddd2();
                SetFunctionName();
                if (Session["result"] != "match")
                {
                    Response.Redirect("~/pages/Login.aspx");
                }
            }
        }
        private void Loadddl()
        {
            DDLectureName.DataSource = oEmpService.selectLecture();
            DDLectureName.DataTextField = "LectureName";
            DDLectureName.DataValueField = "LecturerID";
            DDLectureName.DataBind();
        }
        private void Loaddd2()
        {
            DDSubjectName.DataSource = oEmpService.selectSubject();
            DDSubjectName.DataTextField = "SubjectName";
            DDSubjectName.DataValueField = "SubjectName";
            DDSubjectName.DataBind();
        }
        protected void gvClassMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "ViewData":
                    ViewState["index"] = e.CommandArgument.ToString();
                    RecordView();
                    SetDataEntryMode(DataEntryMode.View);

                    break;

                case "EditData":
                    ViewState["index"] = e.CommandArgument.ToString();
                    RecordView();
                    //SetDataEntryMode(DataEntryMode.Edit);
                    break;

                case "DeleteData":
                    ViewState["index"] = e.CommandArgument.ToString();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowDeleteConfirmation();", true);
                    break;
            }
        }

        protected void gvClassMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            mvClass.ActiveViewIndex = 1;
            //SetDataEntryMode(DataEntryMode.Add);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            InsertData();
        }
        private void EnableControls(bool primary, bool secondary)
        {
            txtClassCode.Enabled = primary;
            DDSubjectName.Enabled = secondary;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvClass.ActiveViewIndex = 0;
            ClearFields();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void PageLoad()
        {
            SetFunctionName();
            LoadGridView();
            ClearFields();
            mvClass.ActiveViewIndex = 0;
        }
        private void SetFunctionName()
        {
            try
            {
                Label lblFunctionName = this.Master.FindControl("lblFuncationName") as Label;
                lblFunctionName.Text = Functions.Class.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertData()
        {
            ClassMasterDto oClassData = new ClassMasterDto();
            oClassData.LecturerID = DDLectureName.SelectedItem.Text.ToString();
            oClassData.SubjectID = DDSubjectName.SelectedItem.Text.ToString();
            oClassData.ClassCode = txtClassCode.Text.ToString();
            oClassData.Description = txtDescription.Text.ToString();
            oClassData.Type = DDClassType.SelectedItem.Text.ToString();
            oClassData.Category = DDCategory.SelectedItem.Text.ToString();
            oClassData.StartDate =Convert.ToDateTime(txtStartDate.Text.ToString());
            oClassData.DateOfConduct = DDDateOfCon.SelectedValue.ToString();
            oClassData.StartTime =txtStartTime.Text.ToString();
            oClassData.EndTime = txtEndTime.Text.ToString();
            oClassData.AdmissionFee =Convert.ToDecimal(txtAdmission.Text.ToString());
            oClassData.MonthlyFee = Convert.ToDecimal(txtMonthly.Text.ToString());
            oClassData.CreateDate = System.DateTime.Now;
            oEmpService.Insertdata(oClassData);
            PageLoad();
            ShowSuccessMessage(ResponseMessages.InsertSuccess);


        }

        private void Save()
        {
            try
            {
                ClassMasterDto oCls = new ClassMasterDto();
                oCls.LecturerID = DDLectureName.SelectedItem.Text.ToString();
                oCls.SubjectID = DDSubjectName.SelectedItem.Text.ToString();
                oCls.ClassCode = txtClassCode.Text.ToString();
                oCls.Description = txtDescription.Text.ToString();
                oCls.Type = DDClassType.SelectedItem.Text.ToString();
                oCls.Category = DDCategory.SelectedItem.Text.ToString();
                oCls.StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
                oCls.DateOfConduct = DDDateOfCon.SelectedValue.ToString();
                oCls.StartTime = txtStartTime.Text.ToString();
                oCls.EndTime = txtEndTime.Text.ToString();
                oCls.AdmissionFee = Convert.ToDecimal(txtAdmission.Text.ToString());
                oCls.MonthlyFee = Convert.ToDecimal(txtMonthly.Text.ToString());
                oCls.ModifiedDateTime = System.DateTime.Now;
                oEmpService.SaveStd(oCls);
                ClearFields();
                PageLoad();
                ShowSuccessMessage(ResponseMessages.UpdateSuccess);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Delete()
        {
            GridViewRow oGridViewRow = gvClassMaster.Rows[Convert.ToInt32(ViewState["index"])];
            String LecName = ((Label)oGridViewRow.FindControl("lblClassCode")).Text.ToString();
            oEmpService.DeleteStd(LecName);
            PageLoad();
            ShowErrorMessage(ResponseMessages.DeleteSuccess);
        }

        private void ClearFields()
        {
            txtClassCode.Text = string.Empty;
            txtAdmission.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtEndTime.Text = string.Empty;
            txtMonthly.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtStartTime.Text = string.Empty;
            
        }

        private void LoadGridView()
        {
            List<ClassMasterDto> oClsData = new List<ClassMasterDto>();
            oClsData = oEmpService.GetData();
            gvClassMaster.DataSource = oClsData;
            gvClassMaster.DataBind();
        }
        private void SetDataEntryMode(DataEntryMode mode)
        {
            btnAdd.Visible = false;
            btnSave.Visible = false;
            btnClear.Visible = false;

            switch (mode)
            {
                case DataEntryMode.Add:
                    btnAdd.Visible = true;
                    btnClear.Visible = true;
                    EnableControls(true, true);
                    break;

                case DataEntryMode.Edit:
                    btnSave.Visible = true;
                    btnClear.Visible = true;
                    EnableControls(false, true);
                    break;

                case DataEntryMode.View:
                    btnAdd.Visible = false;
                    btnSave.Visible = false;
                    btnClear.Visible = false;
                    EnableControls(false, false);
                    break;
            }
        }

        private void RecordView()
        {
            GridViewRow oGridViewRow = gvClassMaster.Rows[Convert.ToInt32(ViewState["index"])];
            string ClassCode = ((Label)oGridViewRow.FindControl("lblClassCode")).Text;

            ClassMasterDto oClass = new ClassMasterDto();
            oClass = oEmpService.GetViewRecords(ClassCode);
            //string Description = ((Label)oGridViewRow.FindControl("lblDescription")).Text;
            //string Category = ((Label)oGridViewRow.FindControl("lblCategory")).Text.ToString();
            //string Type = ((Label)oGridViewRow.FindControl("lblType")).Text;
            //string DateOfConduct = ((Label)oGridViewRow.FindControl("lblStartDate")).Text;
            //string StartTime = ((Label)oGridViewRow.FindControl("lblStartTime")).Text;
            //string EndTime = ((Label)oGridViewRow.FindControl("lblEndTime")).Text;

            txtClassCode.Text = ClassCode.ToString();
            DDLectureName.SelectedItem.Text = oClass.LecturerID.ToString();
            txtDescription.Text = oClass.Description.ToString();
            DDSubjectName.SelectedItem.Text = oClass.SubjectID.ToString();
            DDCategory.SelectedItem.Text = oClass.Category.ToString();
            DDClassType.SelectedItem.Text = oClass.Type.ToString();
            DDDateOfCon.SelectedItem.Text = oClass.DateOfConduct.ToString();
            txtStartTime.Text = oClass.StartTime.ToString();
            txtEndTime.Text = oClass.EndTime.ToString();
            txtAdmission.Text = oClass.AdmissionFee.ToString();
            txtMonthly.Text = oClass.MonthlyFee.ToString();
            txtStartDate.Text = oClass.StartDate.ToString();
            mvClass.ActiveViewIndex = 1;
        }


        private void ShowSuccessMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowSuccessMessage('" + msg + "');", true);
        }

        private void ShowErrorMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowErrorMessage('" + msg + "');", true);
        }
        protected void btnDelete_Click1(object sender, EventArgs e)
        {
            Delete();
        }
    }
}