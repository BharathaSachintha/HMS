using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using HMS.Model;
using HMS.Service;
using System.Web.UI.WebControls;

namespace HMS.Pages
{
    public partial class Subject : System.Web.UI.Page
    {
        private SubjectMasterService oEmpService = new SubjectMasterService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                mvSubject.ActiveViewIndex = 0;

                List<SubjectMasterDto> oSub = new List<SubjectMasterDto>();
                oSub = oEmpService.GetData();
                gvSubjectMaster.DataSource = oSub;
                gvSubjectMaster.DataBind();
                Loadddl();
                PageLoad();
                if (Session["result"] != "match")
                {
                    Response.Redirect("~/pages/Login.aspx");
                }
            }

        }

        private void Loadddl()
        {
            List<SubjectMasterDto> oSub = new List<SubjectMasterDto>();
            oSub = oEmpService.GetSubCat();
            DropDownList1.DataSource = oSub;
            DropDownList1.DataValueField = "SubjectCatID";
            DropDownList1.DataTextField = "SubjectCatName";
            DropDownList1.DataBind();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            mvSubject.ActiveViewIndex = 1;
            SetDataEntryMode(DataEntryMode.Add);
            txtSubCat.Text = string.Empty;
            txtSubjectDiscription.Text = string.Empty;
            txtSubjectName.Text = string.Empty;
            DropDownList1.SelectedIndex = 0;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            InsertData();
        }
        private void EnableControls(bool primary, bool secondary)
        {
            txtSubjectName.Enabled = primary;
            txtSubjectDiscription.Enabled = secondary;
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
            mvSubject.ActiveViewIndex = 0;
            ClearFields();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        protected void gvEmployeeMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    SetDataEntryMode(DataEntryMode.Edit);
                    break;

                case "DeleteData":
                    ViewState["index"] = e.CommandArgument.ToString();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowDeleteConfirmation();", true);
                    break;
            }
        }

        protected void gvSubjectMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        #region Methods
        private void PageLoad()
        {
            SetFunctionName();
            LoadGridView();
            ClearFields();
            mvSubject.ActiveViewIndex = 0;
        }
        private void SetFunctionName()
        {
            try
            {
                Label lblFunctionName = this.Master.FindControl("lblFuncationName") as Label;
                lblFunctionName.Text = Functions.Subject.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertData()
        {
            SubjectMasterDto oEmpData = new SubjectMasterDto();
            oEmpData.getName = txtSubjectName.Text.ToString();
            oEmpData.getCategory = DropDownList1.SelectedValue.ToString();
            oEmpData.getDescription = txtSubjectDiscription.Text.ToString();
            oEmpData.CreateDate = System.DateTime.Now;
            oEmpService.Insertdata(oEmpData);
            PageLoad();
            ShowSuccessMessage(ResponseMessages.InsertSuccess);
            //if (!oEmpService.CheckAvailability(txtSubjectName.Text))
            //{

            //}
            //else
            //{
            //    ShowErrorMessage(ResponseMessages.AlreadyExists);
            //}

        }

        private void Save()
        {
            try
            {
                SubjectMasterDto oEmp = new SubjectMasterDto();
                oEmp.getName = txtSubjectName.Text.ToString();
                oEmp.getCategory = DropDownList1.SelectedValue.ToString();
                oEmp.getDescription = txtSubjectDiscription.Text.ToString();
                oEmp.ModifiedDateTime = System.DateTime.Now;
                oEmpService.SaveSub(oEmp);
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
            GridViewRow oGridViewRow = gvSubjectMaster.Rows[Convert.ToInt32(ViewState["index"])];
            String SubjectNAme = ((Label)oGridViewRow.FindControl("lblSubjectName")).Text.ToString();
            oEmpService.DeleteSubject(SubjectNAme);
            PageLoad();
            ShowErrorMessage(ResponseMessages.DeleteSuccess);
        }

        private void ClearFields()
        {
            txtSubjectName.Text = string.Empty;
            txtSubjectDiscription.Text = string.Empty;
        }

        private void LoadGridView()
        {
            List<SubjectMasterDto> oEmpData = new List<SubjectMasterDto>();
            oEmpData = oEmpService.GetData();
            gvSubjectMaster.DataSource = oEmpData;
            gvSubjectMaster.DataBind();
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
            GridViewRow oGridViewRow = gvSubjectMaster.Rows[Convert.ToInt32(ViewState["index"])];
            string SubjectName = ((Label)oGridViewRow.FindControl("lblSubjectName")).Text;
            int SubjectCategory = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblSubjectCatID")).Text);
            string SubjectDiscription = ((Label)oGridViewRow.FindControl("lblSubjectDescription")).Text;
           
            txtSubjectName.Text = SubjectName.ToString();
            txtSubjectDiscription.Text = SubjectDiscription.ToString();
            DropDownList1.SelectedValue = Convert.ToInt32(SubjectCategory).ToString();
            mvSubject.ActiveViewIndex = 1;
        }


        private void ShowSuccessMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowSuccessMessage('" + msg + "');", true);
        }

        private void ShowErrorMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowErrorMessage('" + msg + "');", true);
        }
        #endregion Methods

        protected void gvSubjectMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    SetDataEntryMode(DataEntryMode.Edit);
                    break;

                case "DeleteData":
                    ViewState["index"] = e.CommandArgument.ToString();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowDeleteConfirmation();", true);
                    break;
            }
        }

        protected void gvSubjectMaster_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnDelete_Click1(object sender, EventArgs e)
        {
            Delete();
        }

        protected void btnAddSubCat_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ShowCat();", true);
        }

        protected void btnAddNewCat_Click(object sender, EventArgs e)
        {
            int lastsubcatid = oEmpService.GetLastSubCat();
            SubjectMasterDto oCat = new SubjectMasterDto();
            oCat.SubjectCatID = lastsubcatid;
            oCat.SubjectCatName = txtSubCat.Text.ToUpper().ToString();

            oEmpService.insetsubcat(oCat);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "HideCat();", true);
            ShowSuccessMessage(ResponseMessages.InsertSuccess);
            Loadddl();

        }

        //private void Delete()
        //{
        //    GridViewRow oGridViewRow = gvEmployeeMaster.Rows[Convert.ToInt32(ViewState["index"])];
        //    int EmployeeID = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblEmployeeID")).Text);
        //    oEmpService.DeleteEmployee(EmployeeID);
        //    PageLoad();
        //    ShowErrorMessage(ResponseMessages.DeleteSuccess);
        //}
    }
}
