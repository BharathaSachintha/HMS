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
    public partial class UserRegister : System.Web.UI.Page
    {
        private UserRoleService oEmpService = new UserRoleService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                mvUserRegister.ActiveViewIndex = 0;
                PageLoad();
                List<UserRoleDto> oSub = new List<UserRoleDto>();
                oSub = oEmpService.GetData();
                gvUserRegisterMaster.DataSource = oSub;
                gvUserRegisterMaster.DataBind();
                if (Session["result"] != "match")
                {
                    Response.Redirect("~/pages/Login.aspx");
                }
            }
        }

        protected void gvUserRegisterMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "ViewData":
                    ViewState["index"] = e.CommandArgument.ToString();
                    RecordView();
                    //SetDataEntryMode(DataEntryMode.View);

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

        protected void gvUserRegisterMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            mvUserRegister.ActiveViewIndex = 1;
            //SetDataEntryMode(DataEntryMode.Add);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            InsertData();
        }
        private void EnableControls(bool primary, bool secondary)
        {
            txtusername.Enabled = primary;
            txtPassword.Enabled = secondary;
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
            mvUserRegister.ActiveViewIndex = 0;
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
            mvUserRegister.ActiveViewIndex = 0;
        }
        private void SetFunctionName()
        {
            try
            {
                Label lblFunctionName = this.Master.FindControl("lblFuncationName") as Label;
                lblFunctionName.Text = Functions.UserRegister.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertData()
        {
            UserRoleDto oUserData = new UserRoleDto();
            oUserData.UserName = txtusername.Text.ToString();
            oUserData.RealName = txtRealName.Text.ToString();
            oUserData.Password = txtPassword.Text.ToString();
            oEmpService.Insertdata(oUserData);
            PageLoad();
            ShowSuccessMessage(ResponseMessages.InsertSuccess);
        }

        private void Save()
        {
            try
            {
                UserRoleDto oUser = new UserRoleDto();
                oUser.UserName = txtusername.Text.ToString();
                oUser.RealName = txtRealName.Text.ToString();
                oUser.Password = txtPassword.Text.ToString();
                oEmpService.SaveHall(oUser);
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
            GridViewRow oGridViewRow = gvUserRegisterMaster.Rows[Convert.ToInt32(ViewState["index"])];
            String UserName = ((Label)oGridViewRow.FindControl("lblUser")).Text.ToString();
            oEmpService.DeleteSubject(UserName);
            PageLoad();
            ShowErrorMessage(ResponseMessages.DeleteSuccess);
        }

        private void ClearFields()
        {
            txtusername.Text = string.Empty;
            txtRealName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void LoadGridView()
        {
            List<UserRoleDto> oUserData = new List<UserRoleDto>();
            oUserData = oEmpService.GetData();
            gvUserRegisterMaster.DataSource = oUserData;
            gvUserRegisterMaster.DataBind();
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
            GridViewRow oGridViewRow = gvUserRegisterMaster.Rows[Convert.ToInt32(ViewState["index"])];
            string UserName = ((Label)oGridViewRow.FindControl("lblUser")).Text;
            string RealNAme = ((Label)oGridViewRow.FindControl("lblRealName")).Text.ToString();
            string Password = ((Label)oGridViewRow.FindControl("lblPassword")).Text;

            txtusername.Text = UserName.ToString();
            txtRealName.Text = RealNAme.ToString();
            txtPassword.Text = Password.ToString();
            mvUserRegister.ActiveViewIndex = 1;
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