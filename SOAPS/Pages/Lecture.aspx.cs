using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HMS.Model;
using HMS.Service;
using static HMS.Model.SubjectMasterDto;

namespace HMS.Pages
{
    public partial class Lecture : System.Web.UI.Page
    {
        private LectureMasterService oEmpService = new LectureMasterService();
        private SubjectMasterService oSubjectMasterService = new SubjectMasterService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                mvLecture.ActiveViewIndex = 0;

                List<LectureMasterDto> oLec = new List<LectureMasterDto>();
                oLec = oEmpService.GetData();
                gvLectureMaster.DataSource = oLec;
                gvLectureMaster.DataBind();
                Session["osub"] = null;
                PageLoad();
               // Session["Listing"] = null;
                Loadddl();
                if (Session["result"] != "match")
                {
                    Response.Redirect("~/pages/Login.aspx");
                }
            }
        }

        private void Loadddl()
        {
            ddlSubcats.DataSource = oSubjectMasterService.GetSubCate();
            ddlSubcats.DataValueField = "SubjectCatID";
            ddlSubcats.DataTextField = "SubjectCatName";
            ddlSubcats.DataBind();
        }

        protected void gvLectureMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    txtLecturerNIC.Enabled = false;
                    SetDataEntryMode(DataEntryMode.Edit);
                    break;

                case "DeleteData":
                    ViewState["index"] = e.CommandArgument.ToString();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowDeleteConfirmation();", true);
                    break;
            }
        }

        protected void gvLectureMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            mvLecture.ActiveViewIndex = 1;
            SetDataEntryMode(DataEntryMode.Add);
            Session["osub"] = null;
           // Session["Listing"] = null;
            gvPrice.DataSource = null;
            gvPrice.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            InsertData();
        }
        private void EnableControls(bool primary, bool secondary)
        {
            txtLecturerNIC.Enabled = primary;
            //txtLecturerLastName.Enabled = secondary;
            foreach (GridViewRow row in gvPrice.Rows)
            {
                (row.Cells[5].FindControl("imgbtnDelete") as ImageButton).Visible = primary;
            }
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
            mvLecture.ActiveViewIndex = 0;
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
            mvLecture.ActiveViewIndex = 0;
        }
        private void SetFunctionName()
        {
            try
            {
                Label lblFunctionName = this.Master.FindControl("lblFuncationName") as Label;
                lblFunctionName.Text = Functions.Lecturer.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertData()
        {
            LectureMasterDto oLectureData = new LectureMasterDto();
            oLectureData.Title = DropDownTitle.SelectedItem.Text.ToString();
            oLectureData.Initials = txtLecturerInitials.Text.ToString();
            oLectureData.FirstName = txtLecturerFirstName.Text.ToString();
            oLectureData.LastName = txtLecturerLastName.Text.ToString();
            oLectureData.Address = txtLecturerAddress.Text.ToString();
            oLectureData.NICNo =Convert.ToInt32(txtLecturerNIC.Text.ToString());
            oLectureData.ContactNo = txtLecturerContact.Text.ToString();
            oLectureData.Email = txtLecturerEmail.Text.ToString();
            oLectureData.LecturerRate = Convert.ToInt32(txtLecturerRate.Text.ToString());
            oLectureData.CreateDate = System.DateTime.Now;

            List<LecturesSubjectsDto> olist = new List<LecturesSubjectsDto>();
            foreach (GridViewRow row in gvPrice.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    LecturesSubjectsDto odata = new LecturesSubjectsDto();
                    odata.LectureID = Convert.ToInt32(oLectureData.NICNo).ToString();
                    odata.SubjectCatID = Convert.ToInt32((row.Cells[0].FindControl("lblSubCat") as Label).Text);
                    odata.SubjectID = Convert.ToInt32((row.Cells[2].FindControl("lblSubID") as Label).Text);
                    odata.SubjectName = (row.Cells[3].FindControl("lblSubName") as Label).Text.ToString();
                    odata.PriceRate = Convert.ToDecimal((row.Cells[4].FindControl("txtPrice") as TextBox).Text);
                    olist.Add(odata);
                }
            }
            oEmpService.Insertdata(oLectureData);
            oEmpService.InsertdataLecsub(olist);
            PageLoad();
            ShowSuccessMessage(ResponseMessages.InsertSuccess);
        }

        private void Save()
        {
            try
            {
                LectureMasterDto oLec = new LectureMasterDto();
                oLec.Title = DropDownTitle.SelectedItem.Text.ToString();
                oLec.Initials = txtLecturerInitials.Text.ToString();
                oLec.FirstName = txtLecturerFirstName.Text.ToString();
                oLec.LastName = txtLecturerLastName.Text.ToString();
                oLec.Address = txtLecturerAddress.Text.ToString();
                oLec.NICNo = Convert.ToInt32(txtLecturerNIC.Text.ToString());
                oLec.ContactNo = txtLecturerContact.Text.ToString();
                oLec.Email = txtLecturerEmail.Text.ToString();
                oLec.LecturerRate = Convert.ToInt32(txtLecturerRate.Text.ToString());
                oLec.ModifiedDateTime = System.DateTime.Now;

                List<LecturesSubjectsDto> olist = new List<LecturesSubjectsDto>();
                foreach (GridViewRow row in gvPrice.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        LecturesSubjectsDto odata = new LecturesSubjectsDto();
                        odata.LectureID = Convert.ToInt32(oLec.NICNo).ToString();
                        odata.SubjectCatID = Convert.ToInt32((row.Cells[0].FindControl("lblSubCat") as Label).Text);
                        odata.SubjectID = Convert.ToInt32((row.Cells[2].FindControl("lblSubID") as Label).Text);
                        odata.SubjectName = (row.Cells[3].FindControl("lblSubName") as Label).Text.ToString();
                        odata.PriceRate = Convert.ToDecimal((row.Cells[4].FindControl("txtPrice") as TextBox).Text);
                        olist.Add(odata);
                    }
                }

                oEmpService.SaveSub(oLec);
                oEmpService.UpdateataLecsub(olist);
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
            GridViewRow oGridViewRow = gvLectureMaster.Rows[Convert.ToInt32(ViewState["index"])];
            String LecName = ((Label)oGridViewRow.FindControl("lblLectureName")).Text.ToString();
            oEmpService.DeleteSubject(LecName);
            PageLoad();
            ShowErrorMessage(ResponseMessages.DeleteSuccess);
        }

        private void ClearFields()
        {
            txtLecturerFirstName.Text = string.Empty;
            txtLecturerInitials.Text = string.Empty;
            txtLecturerLastName.Text = string.Empty;
            txtLecturerAddress.Text = string.Empty;
            txtLecturerContact.Text = string.Empty;
            txtLecturerEmail.Text = string.Empty;
            txtLecturerNIC.Text = string.Empty;
            txtLecturerRate.Text = string.Empty;
        }

        private void LoadGridView()
        {
            List<LectureMasterDto> oLecData = new List<LectureMasterDto>();
            oLecData = oEmpService.GetData();
            gvLectureMaster.DataSource = oLecData;
            gvLectureMaster.DataBind();
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
                    txtLecturerNIC.Enabled = false;                  
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
            GridViewRow oGridViewRow = gvLectureMaster.Rows[Convert.ToInt32(ViewState["index"])];
            string LectureTitle = ((Label)oGridViewRow.FindControl("lblLectureTitle")).Text;
            string Initails= ((Label)oGridViewRow.FindControl("lblLectureInitial")).Text;
            string LectureFirstName = ((Label)oGridViewRow.FindControl("lblLectureName")).Text;
            string LectureLastName = ((Label)oGridViewRow.FindControl("lblLectureLName")).Text.ToString();
            string Address = ((Label)oGridViewRow.FindControl("lblLectureAddress")).Text;
            string NICNo = ((Label)oGridViewRow.FindControl("lblLectureNIC")).Text;
            string ContactNo = ((Label)oGridViewRow.FindControl("lblLectureContact")).Text;
            string Email = ((Label)oGridViewRow.FindControl("lblLecturerEmail")).Text;
            string Rate= ((Label)oGridViewRow.FindControl("lblLectureRate")).Text;

            DropDownTitle.SelectedItem.Text = LectureTitle.ToString();
            txtLecturerFirstName.Text = LectureFirstName.ToString();
            txtLecturerLastName.Text = LectureLastName.ToString();
            txtLecturerAddress.Text = Address.ToString();
            txtLecturerNIC.Text = NICNo.ToString();
            txtLecturerContact.Text = ContactNo.ToString();
            txtLecturerEmail.Text = Email.ToString();
            txtLecturerInitials.Text = Initails.ToString();
            txtLecturerRate.Text = Rate.ToString();
            mvLecture.ActiveViewIndex = 1;

            List<SubjectMasterDto> olist = new List<SubjectMasterDto>();

            olist = oEmpService.getlecture(Convert.ToInt32(NICNo));
            gvPrice.DataSource = olist;
            gvPrice.DataBind();
            Session["osub"] = olist;                 
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

        protected void btnSub_Click(object sender, EventArgs e)
        {
            Filterlist();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ShowSubs();", true);
        }

        private void Filterlist()
        {
            if (ddlSubcats.SelectedValue != "0")
            {
                List<SubjectMasterDto> osub = new List<SubjectMasterDto>();
                osub = oEmpService.GetfilterSub(Convert.ToInt32(ddlSubcats.SelectedValue));
                gvSubs.DataSource = osub;
                gvSubs.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ShowSubs();", true);
            }
            else
            {
                List<SubjectMasterDto> osub = new List<SubjectMasterDto>();
                osub = oSubjectMasterService.GetData();
                gvSubs.DataSource = osub;
                gvSubs.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ShowSubs();", true);
            }
        }

        protected void ddlSubcats_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filterlist();
        }

        protected void btnAddSubs_Click(object sender, EventArgs e)
        {
            try
            {
                List<SubjectMasterDto> osub = Session["osub"] != null ? (List<SubjectMasterDto>)Session["osub"] : new List<SubjectMasterDto>();

               

                SubjectMasterDto oget = new SubjectMasterDto();
                foreach (GridViewRow row in gvSubs.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;

                        if (isChecked)
                        {
                            oget.SubjectCatID = Convert.ToInt32((row.Cells[1].FindControl("lblSubCat") as Label).Text);
                            oget.getCategory = (row.Cells[2].FindControl("lblSubjectCatName") as Label).Text.ToString();
                            oget.SubjectID = Convert.ToInt32((row.Cells[3].FindControl("lblSubID") as Label).Text);
                            oget.getName = (row.Cells[4].FindControl("lblSubName") as Label).Text.ToString();
                            osub.Add(oget);

                            Session["osub"] = osub;

                        }
                    }
                }

                gvPrice.DataSource = osub;
                gvPrice.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "HideSubs();", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }          
        }

        protected void gvPrice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DeleteItem":
                    ViewState["index"] = e.CommandArgument.ToString();
                    DeleteItems();
                    break;
            }
        }

        private void DeleteItems()
        {
            GridViewRow oGridViewRow = gvPrice.Rows[Convert.ToInt32(ViewState["index"])];
            int id = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblSubID")).Text);
            int idcat = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblSubCat")).Text);

            List<SubjectMasterDto> oItemWiselist = (List<SubjectMasterDto>)Session["osub"];
            oItemWiselist.RemoveAll(x => x.SubjectID == id);
            Session["osub"] = oItemWiselist;

            gvPrice.DataSource = oItemWiselist;
            gvPrice.DataBind();
        }


    }
}
