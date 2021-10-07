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
    public partial class HallAllocation : System.Web.UI.Page
    {
        private HallAllocationMasterService oEmpService = new HallAllocationMasterService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                mvHallAllocation.ActiveViewIndex = 0;

                List<HallAllocationMasterDto> oHalla = new List<HallAllocationMasterDto>();
                oHalla = oEmpService.GetData();
                gvHallAllMaster.DataSource = oHalla;
                gvHallAllMaster.DataBind();
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
            dpHallName.DataSource = oEmpService.selectHall();
            dpHallName.DataTextField = "HallName";
            dpHallName.DataValueField = "HallID";
            dpHallName.DataBind();
        }
        private void Loaddd2()
        {
            dpClassCode.DataSource = oEmpService.selectClasss();
            dpClassCode.DataTextField = "ClassName";
            dpClassCode.DataValueField = "ClassID";
            dpClassCode.DataBind();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            mvHallAllocation.ActiveViewIndex = 1;
            //SetDataEntryMode(DataEntryMode.Add);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            InsertData();
        }
        private void EnableControls(bool primary, bool secondary)
        {
            dpHallName.Enabled = primary;
            dpClassCode.Enabled = secondary;
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
            mvHallAllocation.ActiveViewIndex = 0;
            ClearFields();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
        }
        protected void gvHallMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void gvHallMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        private void PageLoad()
        {
            SetFunctionName();
            LoadGridView();
            ClearFields();
            mvHallAllocation.ActiveViewIndex = 0;
        }
        private void SetFunctionName()
        {
            try
            {
                Label lblFunctionName = this.Master.FindControl("lblFuncationName") as Label;
                lblFunctionName.Text = Functions.HallAllocation.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertData()
        {
            HallAllocationMasterDto oHallData = new HallAllocationMasterDto();
            oHallData.HallID = dpHallName.SelectedValue.ToString();
            oHallData.ClassID = dpClassCode.Text.ToString();
            oHallData.ScheduleDate = Convert.ToDateTime(txtSheduledate.Text);
            oHallData.StartTime = txtStartTime.Text.ToString();
            oHallData.EndTime = txtEndTime.Text.ToString();
            oHallData.CreateDate = System.DateTime.Now;
            oEmpService.Insertdata(oHallData);
            PageLoad();
            ShowSuccessMessage(ResponseMessages.InsertSuccess);
        }

        private void Save()
        {
            try
            {
                HallAllocationMasterDto oHalla = new HallAllocationMasterDto();
                oHalla.HallID = dpHallName.SelectedValue.ToString();
                oHalla.ClassID = dpClassCode.SelectedItem.Text.ToString();
                oHalla.ScheduleDate = Convert.ToDateTime(txtSheduledate.Text);
                oHalla.StartTime = txtStartTime.Text.ToString();
                oHalla.EndTime = txtEndTime.Text.ToString();
                oHalla.ModifiedDateTime = System.DateTime.Now;
                oEmpService.SaveHalla(oHalla);
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
            GridViewRow oGridViewRow = gvHallAllMaster.Rows[Convert.ToInt32(ViewState["index"])];
            String HallID = ((Label)oGridViewRow.FindControl("lblHallName")).Text.ToString();
            oEmpService.DeleteSubject(HallID);
            PageLoad();
            ShowErrorMessage(ResponseMessages.DeleteSuccess);
        }

        private void ClearFields()
        {
            
            
            txtStartTime.Text = string.Empty;
            txtEndTime.Text = string.Empty;
        }

        private void LoadGridView()
        {
            List<HallAllocationMasterDto> oHallData = new List<HallAllocationMasterDto>();
            oHallData = oEmpService.GetData();
            gvHallAllMaster.DataSource = oHallData;
            gvHallAllMaster.DataBind();
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
            GridViewRow oGridViewRow = gvHallAllMaster.Rows[Convert.ToInt32(ViewState["index"])];
            string HallID = ((Label)oGridViewRow.FindControl("lblHallName")).Text;
            string CalssID = ((Label)oGridViewRow.FindControl("lblClassCode")).Text.ToString();
            string SceduleDate = ((Label)oGridViewRow.FindControl("lblSceduleTime")).Text;
            string StartTime = ((Label)oGridViewRow.FindControl("lblStartTime")).Text;
            string EndTime = ((Label)oGridViewRow.FindControl("lblEndTime")).Text;

            dpHallName.Text = HallID.ToString();
            dpClassCode.Text = CalssID.ToString();
            txtSheduledate.Text = Convert.ToDateTime(SceduleDate).ToString("yyyy-MM-dd");
            txtStartTime.Text=StartTime.ToString();
            txtEndTime.Text = EndTime.ToString();
            mvHallAllocation.ActiveViewIndex = 1;
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

        protected void gvHallAllMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void gvHallAllMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnDelete_Click2(object sender, EventArgs e)
        {
            Delete();
        }
    }
}