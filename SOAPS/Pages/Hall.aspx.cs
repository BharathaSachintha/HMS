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
    public partial class Hall : System.Web.UI.Page
    {
        private HallMasterService oEmpService = new HallMasterService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                mvHall.ActiveViewIndex = 0;

                List<HallMasterDto> oSub = new List<HallMasterDto>();
                oSub = oEmpService.GetData();
                gvHallMaster.DataSource = oSub;
                gvHallMaster.DataBind();
                SetFunctionName();
                if (Session["result"] != "match")
                {
                    Response.Redirect("~/pages/Login.aspx");
                }
            }
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            mvHall.ActiveViewIndex = 1;
            SetDataEntryMode(DataEntryMode.Add);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            InsertData();
        }
        private void EnableControls(bool primary, bool secondary)
        {
            txtHallName.Enabled = primary;
            txtHallDescription.Enabled = secondary;
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
            mvHall.ActiveViewIndex = 0;
            ClearFields();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
       

        //protected void gvSubjectMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //}

        //protected void gvSubjectMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{

        //}

        protected void gvHallMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    txtHallName.Enabled = false;
                    SetDataEntryMode(DataEntryMode.Edit);
                    break;

                case "DeleteData":
                    ViewState["index"] = e.CommandArgument.ToString();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowDeleteConfirmation();", true);
                    break;
            }
        }

        protected void gvHallMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        private void PageLoad()
        {
            SetFunctionName();
            LoadGridView();
            ClearFields();
            mvHall.ActiveViewIndex = 0;
        }
        private void SetFunctionName()
        {
            try
            {
                Label lblFunctionName = this.Master.FindControl("lblFuncationName") as Label;
                lblFunctionName.Text = Functions.Hall.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertData()
        {
            HallMasterDto oHallData = new HallMasterDto();
            oHallData.HallName= txtHallName.Text.ToString();
            oHallData.HallDescription = txtHallDescription.Text.ToString();
            oHallData.StudentCapacity = txtStudentCapacity.Text.ToString();
            oHallData.CreateDate = System.DateTime.Now;
            oEmpService.Insertdata(oHallData);
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
                HallMasterDto oHall = new HallMasterDto();
                oHall.HallName = txtHallName.Text.ToString();
                oHall.HallDescription = txtHallDescription.Text.ToString();
                oHall.StudentCapacity = txtStudentCapacity.Text.ToString();
                oHall.ModifiedDateTime = System.DateTime.Now;
                oEmpService.SaveHall(oHall);
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
            GridViewRow oGridViewRow = gvHallMaster.Rows[Convert.ToInt32(ViewState["index"])];
            String HallName = ((Label)oGridViewRow.FindControl("lblHallName")).Text.ToString();
            oEmpService.DeleteSubject(HallName);
            PageLoad();
            ShowErrorMessage(ResponseMessages.DeleteSuccess);
        }

        private void ClearFields()
        {
            txtHallName.Text = string.Empty;
            txtHallDescription.Text = string.Empty;
            txtStudentCapacity.Text = string.Empty;
        }

        private void LoadGridView()
        {
            List<HallMasterDto> oHallData = new List<HallMasterDto>();
            oHallData = oEmpService.GetData();
            gvHallMaster.DataSource = oHallData;
            gvHallMaster.DataBind();
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
            GridViewRow oGridViewRow = gvHallMaster.Rows[Convert.ToInt32(ViewState["index"])];
            string HallName = ((Label)oGridViewRow.FindControl("lblHallName")).Text;
            string HallDescription = ((Label)oGridViewRow.FindControl("lblHallDescription")).Text.ToString();
            string StudentCapacity = ((Label)oGridViewRow.FindControl("lblStudentCapacity")).Text;

            txtHallName.Text = HallName.ToString();
            txtHallDescription.Text = HallDescription.ToString();
            txtStudentCapacity.Text = StudentCapacity.ToString();
            mvHall.ActiveViewIndex = 1;
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