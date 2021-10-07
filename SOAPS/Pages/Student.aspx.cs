using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HMS.Model;
using HMS.Service;
using static HMS.Model.LecturesSubjectsDto;

namespace HMS.Pages
{
    public partial class Student : System.Web.UI.Page
    {
        private StudentMasterService oEmpService = new StudentMasterService();
        private SubjectMasterService oSubjectMasterService = new SubjectMasterService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                mvStudent.ActiveViewIndex = 0;

                List<StudentMasterDto> oLec = new List<StudentMasterDto>();
                oLec = oEmpService.GetData();
                gvStudentMaster.DataSource = oLec;
                gvStudentMaster.DataBind();
                Session["osub"] = null;
                Session["Listing"] = null;
                Loadddl();
                SetFunctionName();
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
        protected void gvStudentMaster_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void gvStudentMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            mvStudent.ActiveViewIndex = 1;
            SetDataEntryMode(DataEntryMode.Add);
            gvSelectCourses.DataSource = null;
            gvSelectCourses.DataBind();
            Session["osub"] = null;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            InsertData();
        }
        private void EnableControls(bool primary, bool secondary)
        {
            txtRFIDNo.Enabled = primary;
            //txtFirstName.Enabled = secondary;
            foreach (GridViewRow row in gvSelectCourses.Rows)
            {
                (row.Cells[6].FindControl("imgbtnDelete") as ImageButton).Visible = primary;
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
            mvStudent.ActiveViewIndex = 0;
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
            mvStudent.ActiveViewIndex = 0;
        }
        private void SetFunctionName()
        {
            try
            {
                Label lblFunctionName = this.Master.FindControl("lblFuncationName") as Label;
                lblFunctionName.Text = Functions.Student.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertData()
        {
            StudentMasterDto oStudentData = new StudentMasterDto();
            oStudentData.RFID = txtRFIDNo.Text.ToString();
            oStudentData.Initials = txtInitial.Text.ToString();
            oStudentData.FirstName = txtFirstName.Text.ToString();
            oStudentData.LastName = txtLastName.Text.ToString();
            oStudentData.Gender = DropDownGender.SelectedItem.ToString();
            oStudentData.DateOfBirth = Convert.ToDateTime(txtDOB.Text.ToString());
            oStudentData.Address = txtAddress.Text.ToString();
            oStudentData.GuardianName = txtGardianceName.Text.ToString();
            oStudentData.ContactNo = Convert.ToInt32(txtContact.Text.ToString());
            oStudentData.SchoolName = txtSchoolName.Text.ToString();
            oStudentData.StudCategory = DropDownListStudent.SelectedItem.ToString();
            oStudentData.CreateDate = System.DateTime.Now;

            List<CourcesDto> olist = new List<CourcesDto>();
            foreach (GridViewRow row in gvSelectCourses.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CourcesDto odata = new CourcesDto();
                    odata.RFID = oStudentData.RFID.ToString();
                    odata.LectureID = Convert.ToInt32((row.Cells[0].FindControl("lblLectureID") as Label).Text);
                    odata.SubjectCatID = Convert.ToInt32((row.Cells[2].FindControl("lblSubjectCatID") as Label).Text);
                    odata.SubjectID = Convert.ToInt32((row.Cells[3].FindControl("lblSubjectID") as Label).Text);
                    odata.PriceRate = Convert.ToDecimal((row.Cells[5].FindControl("lblPriceRate") as Label).Text);
                    odata.RegistrationDate = DateTime.Now;
                    odata.PaymentStatus = 1;
                    olist.Add(odata);
                }
            }

            oEmpService.Insertdata(oStudentData);
            oEmpService.InsertdataCourses(olist);
            oEmpService.InsertPayment(oStudentData, olist);

            PageLoad();
            ShowSuccessMessage(ResponseMessages.InsertSuccess);


        }

        private void Save()
        {
            try
            {
                StudentMasterDto oStd = new StudentMasterDto();
                oStd.RFID = txtRFIDNo.Text.ToString();
                oStd.Initials = txtInitial.Text.ToString();
                oStd.FirstName = txtFirstName.Text.ToString();
                oStd.LastName = txtLastName.Text.ToString();
                oStd.Gender = DropDownGender.SelectedItem.ToString();
                oStd.DateOfBirth = Convert.ToDateTime(txtDOB.Text.ToString());
                oStd.Address = txtAddress.Text.ToString();
                oStd.GuardianName = txtGardianceName.Text.ToString();
                oStd.ContactNo = Convert.ToInt32(txtContact.Text.ToString());
                oStd.SchoolName = txtSchoolName.Text.ToString();
                oStd.StudCategory = DropDownListStudent.SelectedItem.ToString();
                oStd.ModifiedDateTime = System.DateTime.Now;

                List<CourcesDto> olist = new List<CourcesDto>();
                foreach (GridViewRow row in gvSelectCourses.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CourcesDto odata = new CourcesDto();
                        odata.RFID = oStd.RFID.ToString();
                        odata.LectureID = Convert.ToInt32((row.Cells[0].FindControl("lblLectureID") as Label).Text);
                        odata.SubjectCatID = Convert.ToInt32((row.Cells[2].FindControl("lblSubjectCatID") as Label).Text);
                        odata.SubjectID = Convert.ToInt32((row.Cells[3].FindControl("lblSubjectID") as Label).Text);
                        odata.PriceRate = Convert.ToDecimal((row.Cells[5].FindControl("lblPriceRate") as Label).Text);
                        olist.Add(odata);
                    }
                }

                oEmpService.SaveStd(oStd);
                oEmpService.UpdatedataCourses(olist);
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
            GridViewRow oGridViewRow = gvStudentMaster.Rows[Convert.ToInt32(ViewState["index"])];
            String Rfid = ((Label)oGridViewRow.FindControl("lblRFIDNo")).Text.ToString();
            oEmpService.DeleteStd(Rfid);
            PageLoad();
            ShowErrorMessage(ResponseMessages.DeleteSuccess);
        }

        private void ClearFields()
        {
            txtContact.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtGardianceName.Text = string.Empty;
            txtInitial.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtRFIDNo.Text = string.Empty;
            txtSchoolName.Text = string.Empty;
        }

        private void LoadGridView()
        {
            List<StudentMasterDto> oStdData = new List<StudentMasterDto>();
            oStdData = oEmpService.GetData();
            gvStudentMaster.DataSource = oStdData;
            gvStudentMaster.DataBind();
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
                    txtRFIDNo.Enabled = false;
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
            GridViewRow oGridViewRow = gvStudentMaster.Rows[Convert.ToInt32(ViewState["index"])];
            string RFID = ((Label)oGridViewRow.FindControl("lblRFIDNo")).Text;
            string FirstName = ((Label)oGridViewRow.FindControl("lblStudentName")).Text.ToString();
            string Gender = ((Label)oGridViewRow.FindControl("lblGender")).Text;
            string ContactNo = ((Label)oGridViewRow.FindControl("lblContact")).Text;
            string Address = ((Label)oGridViewRow.FindControl("lblAddress")).Text;
            string StudCategory = ((Label)oGridViewRow.FindControl("lblStudentCat")).Text;
            string initials= ((Label)oGridViewRow.FindControl("lblStudentInitals")).Text;
            string lastname= ((Label)oGridViewRow.FindControl("lblStudentLast")).Text;
            string gurrdinace= ((Label)oGridViewRow.FindControl("lblGurdiance")).Text;
            string school= ((Label)oGridViewRow.FindControl("lblSchool")).Text;
            string dob= ((Label)oGridViewRow.FindControl("lblDOB")).Text;

            txtRFIDNo.Text = RFID.ToString();
            txtFirstName.Text = FirstName.ToString();
            DropDownGender.SelectedItem.Text = Gender.ToString();
            txtContact.Text = ContactNo.ToString();
            txtAddress.Text = Address.ToString();
            DropDownListStudent.SelectedItem.Text = StudCategory.ToString();
            txtInitial.Text = initials.ToString();
            txtLastName.Text = lastname.ToString();
            txtGardianceName.Text = gurrdinace.ToString();
            txtSchoolName.Text = school.ToString();
            txtDOB.Text = Convert.ToDateTime(dob).ToString("yyyy-MM-dd");

            List<LecturesSubjectsDto> olist = new List<LecturesSubjectsDto>();
            olist = oEmpService.GEtCourses(RFID);

            Session["osub"] = olist;
            gvSelectCourses.DataSource = olist;
            gvSelectCourses.DataBind();

            //Session["osub"] = olist;
            mvStudent.ActiveViewIndex = 1;
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

        protected void btnCourses_Click(object sender, EventArgs e)
        {
            Filterlist();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ShowSubs();", true);
        }

        protected void ddlSubcats_TextChanged(object sender, EventArgs e)
        {
            Filterlist();
        }

        private void Filterlist()
        {
            if (ddlSubcats.SelectedValue != "0")
            {
                List<LecturesSubjectsDto> osub = new List<LecturesSubjectsDto>();
                osub = oEmpService.GetfilterList(Convert.ToInt32(ddlSubcats.SelectedValue));
                gvCourses.DataSource = osub;
                gvCourses.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ShowSubs();", true);
            }
            else
            {
                List<LecturesSubjectsDto> osub = new List<LecturesSubjectsDto>();
                osub = oEmpService.GetfilterAllList();
                gvCourses.DataSource = osub;
                gvCourses.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ShowSubs();", true);
            }
        }

        protected void btnAddSubs_Click(object sender, EventArgs e)
        {
            try
            {
                List<LecturesSubjectsDto> osub = Session["osub"] != null ? (List<LecturesSubjectsDto>)Session["osub"] : new List<LecturesSubjectsDto>();

                //LecturesSubjectsDto oListing = new LecturesSubjectsDto();
                //if (Session["Listing"] != null)
                //    oListing = (LecturesSubjectsDto)Session["Listing"];

                LecturesSubjectsDto oget = new LecturesSubjectsDto();
                foreach (GridViewRow row in gvCourses.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;

                        if (isChecked)
                        {
                            oget.LectureID = (row.Cells[1].FindControl("lblLectureID") as Label).Text.ToString();
                            oget.LectureName = (row.Cells[2].FindControl("lblLectureName") as Label).Text.ToUpper().ToString();
                            oget.SubjectCatID = Convert.ToInt32((row.Cells[3].FindControl("lblSubjectCatID") as Label).Text);
                            oget.SubjectID = Convert.ToInt32((row.Cells[4].FindControl("lblSubjectID") as Label).Text);
                            oget.SubjectName = (row.Cells[5].FindControl("lblSubjectName") as Label).Text.ToUpper().ToUpper();
                            oget.PriceRate = Convert.ToDecimal((row.Cells[6].FindControl("lblPriceRate") as Label).Text);
                            osub.Add(oget);

                            Session["osub"] = osub;

                            //oListing.Getall.Add(new LecturesSubjectssDtos
                            //{
                            //    LectureID = oget.LectureID,
                            //    LectureName = oget.LectureName,
                            //    SubjectCatID = oget.SubjectCatID,
                            //    SubjectID = oget.SubjectID,
                            //    SubjectName = oget.SubjectName,
                            //    PriceRate = oget.PriceRate
                            //});
                            //Session["Listing"] = oListing;
                        }
                    }
                }

                gvSelectCourses.DataSource = osub;
                gvSelectCourses.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "HideSubs();", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void gvSelectCourses_RowCommand(object sender, GridViewCommandEventArgs e)
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
            GridViewRow oGridViewRow = gvSelectCourses.Rows[Convert.ToInt32(ViewState["index"])];
            int id = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblSubjectID")).Text);
            int idcat = Convert.ToInt32(((Label)oGridViewRow.FindControl("lblSubjectCatID")).Text);

            List<LecturesSubjectsDto> oItemWiselist = (List<LecturesSubjectsDto>)Session["osub"];
            oItemWiselist.RemoveAll(x => x.SubjectID == id && x.SubjectCatID == idcat);
            Session["osub"] = oItemWiselist;

            gvSelectCourses.DataSource = oItemWiselist;
            gvSelectCourses.DataBind();
        }

        protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
