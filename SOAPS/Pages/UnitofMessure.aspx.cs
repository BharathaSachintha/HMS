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
    public partial class UnitofMessure : System.Web.UI.Page
    {
        private UnitofMessureService oUOMService = new UnitofMessureService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PageLoad();
            }
        }
        private void PageLoad()
        {
            SetFunctionName();
            LoadGridView();
            ClearFields();
            Session["UomID"] = null;
            mvUOM.ActiveViewIndex = 0;
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
        private void ClearFields()
        {
            txtMajor.Text = string.Empty;
            txtMinor.Text = string.Empty;
        }
        private void LoadGridView()
        {
            List<UnitofMessureDto> oUOM = new List<UnitofMessureDto>();
            oUOM = oUOMService.GetData();
            gvMessure.DataSource = oUOM;
            gvMessure.DataBind();
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            mvUOM.ActiveViewIndex = 1;
            SetDataEntryMode(DataEntryMode.Add);
            ClearFields();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void EnableControls(bool primary)
        {
            txtMajor.Enabled = primary;
            txtMinor.Enabled = primary;
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
                    EnableControls(true);
                    break;

                case DataEntryMode.Edit:
                    btnSave.Visible = true;
                    btnClear.Visible = true;
                    EnableControls(true);
                    break;

                case DataEntryMode.View:
                    btnAdd.Visible = false;
                    btnSave.Visible = false;
                    btnClear.Visible = false;
                    EnableControls(false);
                    break;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            InsertData();
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
            mvUOM.ActiveViewIndex = 0;
            ClearFields();
            Session["UomID"] = null;
        }

        protected void gvMessure_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void gvMessure_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        private void InsertData()
        {
            UnitofMessureDto oUOMData = new UnitofMessureDto();
            int lastuom = oUOMService.GetLastUomID();
            oUOMData.UomID = lastuom + 1;
            oUOMData.Major = txtMajor.Text.ToString().ToUpper();
            oUOMData.Minor = txtMinor.Text.ToString().ToUpper();
            oUOMData.CreateDate = System.DateTime.Now;
            oUOMService.Insert(oUOMData);
            ClearFields();
            PageLoad();
            ShowSuccessMessage(ResponseMessages.InsertSuccess);

        }

        private void Save()
        {
            try
            {
                UnitofMessureDto oUOMData = new UnitofMessureDto();
                oUOMData.UomID = Convert.ToInt32(Session["UomID"]);
                oUOMData.Major = txtMajor.Text.ToString();
                oUOMData.Minor = txtMinor.Text.ToString();
                oUOMData.ModifiedDateTime = System.DateTime.Now;
                oUOMService.Save(oUOMData);
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
            GridViewRow oGridViewRow = gvMessure.Rows[Convert.ToInt32(ViewState["index"])];
            int UomID = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblID")).Text);
            oUOMService.Delete(UomID);
            PageLoad();
            ShowErrorMessage(ResponseMessages.DeleteSuccess);
        }

        private void RecordView()
        {
            GridViewRow oGridViewRow = gvMessure.Rows[Convert.ToInt32(ViewState["index"])];
            Session["UomID"] = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblID")).Text);
            string Major = ((Label)oGridViewRow.FindControl("lblMajor")).Text;
            string Minor = ((Label)oGridViewRow.FindControl("lblMinor")).Text;

            txtMajor.Text = Major.ToString();
            txtMinor.Text = Minor.ToString();
            mvUOM.ActiveViewIndex = 1;
        }


        private void ShowSuccessMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowSuccessMessage('" + msg + "');", true);
        }

        private void ShowErrorMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowErrorMessage('" + msg + "');", true);
        }
    }
}