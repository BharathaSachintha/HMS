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
    public partial class InventoryProducts : System.Web.UI.Page
    {
        private InventoryProductService oInvService = new InventoryProductService();
        private UnitofMessureService oUomService = new UnitofMessureService();

        #region events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PageLoad();
            }
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            mvInv.ActiveViewIndex = 1;
            SetDataEntryMode(DataEntryMode.Add);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
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
            if (Session["Clear"] != null)
            {
                txtProductName.Text = string.Empty;
                lblMajor.Text = string.Empty;
                lblMinor.Text = string.Empty;
                lblspace.Text = string.Empty;
            }
            else
            {
                ClearFields();
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/InventoryProducts.aspx", false);
        }

        protected void gvInvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    Session["Clear"] = "";
                    break;

                case "DeleteData":
                    ViewState["index"] = e.CommandArgument.ToString();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowDeleteConfirmation();", true);
                    break;
            }
        }

        protected void gvInvProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        #endregion events

        #region Methods
        private void SetFunctionName()
        {
            try
            {
                Label lblFunctionName = this.Master.FindControl("lblFuncationName") as Label;
                lblFunctionName.Text = Functions.InventoryProduct.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PageLoad()
        {
            SetFunctionName();
            LoadGridView();
            ClearFields();
            Session["Clear"] = null;
            Session["UomID"] = null;
            mvInv.ActiveViewIndex = 0;
            lblspace.Visible = false;
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
                    lblspace.Visible = false;
                    break;

                case DataEntryMode.Edit:
                    btnSave.Visible = true;
                    btnClear.Visible = true;
                    EnableControls(false, true);
                    lblspace.Visible = true;
                    break;

                case DataEntryMode.View:
                    btnAdd.Visible = false;
                    btnSave.Visible = false;
                    btnClear.Visible = false;
                    EnableControls(false, false);
                    lblspace.Visible = true;
                    ImageButton1.Enabled = false;
                    break;
            }
        }
        private void EnableControls(bool primary, bool secondary)
        {
            txtProductCode.Enabled = primary;
            txtProductName.Enabled = secondary;
        }
        private void RecordView()
        {
            GridViewRow oGridViewRow = gvInvProduct.Rows[Convert.ToInt32(ViewState["index"])];
            string PID = ((Label)oGridViewRow.FindControl("lblProductCode")).Text;
            string PNAME = ((Label)oGridViewRow.FindControl("lblProductName")).Text;

            UnitofMessureDto oUom = oInvService.GetUoms(PID);
            lblMajor.Text = oUom.Major.ToString();
            lblMinor.Text = oUom.Minor.ToString();
            txtProductCode.Text = PID.ToString();
            txtProductName.Text = PNAME.ToString();
            mvInv.ActiveViewIndex = 1;
        }
        private void InsertData()
        {
            if (!oInvService.CheckAvailability(txtProductCode.Text.ToString()))
            {
                InvProductDto oInvData = new InvProductDto();
                oInvData.ProductID = txtProductCode.Text.ToString();
                oInvData.ProductName = txtProductName.Text.ToString();
                oInvData.UomID = Convert.ToInt32(Session["UomID"]);
                oInvData.CreateDate = System.DateTime.Now;
                oInvService.Insertdata(oInvData);
                PageLoad();
                ShowSuccessMessage(ResponseMessages.InsertSuccess);
            }
            else
            {
                ShowErrorMessage(ResponseMessages.AlreadyExists);
            }

        }
        private void ShowSuccessMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowSuccessMessage('" + msg + "');", true);
        }

        private void ShowErrorMessage(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowErrorMessage('" + msg + "');", true);
        }
        private void Save()
        {
            try
            {
                InvProductDto oInv = new InvProductDto();
                oInv.ProductID = txtProductCode.Text.ToString();
                oInv.ProductName = txtProductName.Text.ToString();
                oInv.UomID = Convert.ToInt32(Session["UomID"]);
                oInv.ModifiedDateTime = System.DateTime.Now;
                oInvService.Save(oInv);
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
            GridViewRow oGridViewRow = gvInvProduct.Rows[Convert.ToInt32(ViewState["index"])];
            int PID = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblProductCode")).Text);
            oInvService.Delete(PID);
            PageLoad();
            ShowErrorMessage(ResponseMessages.DeleteSuccess);
        }
        private void LoadGridView()
        {
            List<InvProductDto> oInvData = new List<InvProductDto>();
            oInvData = oInvService.GetData();
            gvInvProduct.DataSource = oInvData;
            gvInvProduct.DataBind();
        }
        private void ClearFields()
        {
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            lblMajor.Text = string.Empty;
            lblMinor.Text = string.Empty;
        }
        #endregion Methods

        private void GetUom()
        {
            GridViewRow oGridViewRow = gvUOM.Rows[Convert.ToInt32(ViewState["index"])];
            Session["UomID"] = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblUomID")).Text);
            string Major = ((Label)oGridViewRow.FindControl("lblMajor")).Text;
            string Minor = ((Label)oGridViewRow.FindControl("lblMinor")).Text;

            lblMajor.Text = Major.ToString();
            lblMinor.Text = Minor.ToString();
            lblspace.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                List<UnitofMessureDto> oUOM = oUomService.GetData();
                if (oUOM.Count > 0)
                {
                    gvUOM.DataSource = oUOM;
                    gvUOM.DataBind();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ShowCustomers();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "HideCustomers();", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvUOM_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {

                case "AddUOM":
                    ViewState["index"] = e.CommandArgument.ToString();
                    GetUom();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "HideCustomers();", true);
                    break;
            }
        }


        protected void gvUOM_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}