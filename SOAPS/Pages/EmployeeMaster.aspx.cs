using HMS.Model;
using HMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HMS.Pages
{
    public partial class EmployeeMaster : System.Web.UI.Page
    {
        private EmployeeMasterService oEmpService = new EmployeeMasterService();

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PageLoad();
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            mvEmployee.ActiveViewIndex = 1;
            SetDataEntryMode(DataEntryMode.Add);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            InsertData();
        }
        private void EnableControls(bool primary, bool secondary)
        {
            txtEmployeeCode.Enabled = primary;
            txtName.Enabled = secondary;
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
            mvEmployee.ActiveViewIndex = 0;
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

        protected void gvEmployeeMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        #endregion Events

        #region Methods
        private void PageLoad()
        {
            SetFunctionName();
            //LoadGridView();
            //ClearFields();
            mvEmployee.ActiveViewIndex = 0;
        }
        private void SetFunctionName()
        {
            try
            {
                Label lblFunctionName = this.Master.FindControl("lblFuncationName") as Label;
                lblFunctionName.Text = Functions.EmployeeMaster.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertData()
        {
            if (!oEmpService.CheckAvailability(Convert.ToInt32(txtEmployeeCode.Text)))
            {
                EmployeeMasterDto oEmpData = new EmployeeMasterDto();
                oEmpData.EmpID = Convert.ToInt32(txtEmployeeCode.Text);
                oEmpData.EmployeeName = txtName.Text.ToString();
                oEmpData.CreateDate = System.DateTime.Now;
                oEmpService.Insertdata(oEmpData);
                PageLoad();
                ShowSuccessMessage(ResponseMessages.InsertSuccess);
            }
            else
            {
                ShowErrorMessage(ResponseMessages.AlreadyExists);
            }

        }

        private void Save()
        {
            try
            {
                EmployeeMasterDto oEmp = new EmployeeMasterDto();
                oEmp.EmpID = Convert.ToInt32(txtEmployeeCode.Text.Trim());
                oEmp.EmployeeName = txtName.Text.Trim();
                oEmp.ModifiedDateTime = System.DateTime.Now;
                oEmpService.SaveEmp(oEmp);
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
            GridViewRow oGridViewRow = gvEmployeeMaster.Rows[Convert.ToInt32(ViewState["index"])];
            int EmployeeID = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblEmployeeID")).Text);
            oEmpService.DeleteEmployee(EmployeeID);
            PageLoad();
            ShowErrorMessage(ResponseMessages.DeleteSuccess);
        }

        private void ClearFields()
        {
            txtEmployeeCode.Text = string.Empty;
            txtName.Text = string.Empty;
        }

        private void LoadGridView()
        {
            List<EmployeeMasterDto> oEmpData = new List<EmployeeMasterDto>();
            oEmpData = oEmpService.GetData();
            gvEmployeeMaster.DataSource = oEmpData;
            gvEmployeeMaster.DataBind();
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
            GridViewRow oGridViewRow = gvEmployeeMaster.Rows[Convert.ToInt32(ViewState["index"])];
            int EmpID = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblEmployeeID")).Text);
            string EmpName = ((Label)oGridViewRow.FindControl("lblEmployeeName")).Text;

            txtEmployeeCode.Text = Convert.ToInt32(EmpID).ToString();
            txtName.Text = EmpName.ToString();
            mvEmployee.ActiveViewIndex = 1;
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
    }
}