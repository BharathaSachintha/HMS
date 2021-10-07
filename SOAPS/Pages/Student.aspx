<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="HMS.Pages.Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:MultiView ID="mvStudent" runat="server">
                <asp:View ID="v1" runat="server">
                    <div class="card card-default">
                        <div class="card-header">
                            <div class="form-group row">
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" TabIndex="1" placeholder="Enter here to search" Visible="false"/>
                                </div>
                                <div class="col-md-1">
                                    <asp:ImageButton ID="imgbtnSearch" runat="server" TabIndex="2" ImageUrl="~/Theme/dist/img/ic_search.png" OnClick="imgbtnSearch_Click" Visible="false"/>
                                </div>
                                <div class="col-md-5">
                                </div>
                                <div class="col-md-2">
                                    <i class="fa fa-plus fa-fw fa-lg" aria-hidden="true"></i>
                                    <asp:Button ID="btnAddNew" runat="server" Text="Add Student" CssClass="btn btn-default" TabIndex="3" OnClick="btnAddNew_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="form-group row">
                                <div class="col-md-12">
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-12">
                                    <asp:GridView ID="gvStudentMaster" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="True" PageSize="10" OnRowCommand="gvStudentMaster_RowCommand" OnPageIndexChanging="gvStudentMaster_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="RFID Number">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRFIDNo" runat="server" Text='<%# Bind("RFID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStudentName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Gender">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGender" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Contact Number">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContact" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Student Category">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStudentCat" runat="server" Text='<%# Bind("StudCategory") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Student Initals" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStudentInitals" runat="server" Text='<%# Bind("Initials") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Student Last Name" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStudentLast" runat="server" Text='<%# Bind("LastName") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Gurdiance" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGurdiance" runat="server" Text='<%# Bind("GuardianName") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="School" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSchool" runat="server" Text='<%# Bind("SchoolName") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Date of Birth" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDOB" runat="server" Text='<%# Bind("DateOfBirth") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnView" runat="server" CausesValidation="false" CommandName="ViewData"
                                                        ImageUrl="~/Theme/dist/img/ic_view.png" Text="Button" CommandArgument="<%# Container.DisplayIndex %>" ImageAlign="AbsMiddle" />
                                                </ItemTemplate>
                                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnEdit" runat="server" CausesValidation="false" CommandName="EditData"
                                                        ImageUrl="~/Theme/dist/img/ic_edit.png" Text="Button" CommandArgument="<%# Container.DisplayIndex %>" ImageAlign="AbsMiddle" />
                                                </ItemTemplate>
                                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnDelete" runat="server" CausesValidation="false" CommandName="DeleteData"
                                                        ImageUrl="~/Theme/dist/img/ic_delete.png" Text="Button" CommandArgument="<%# Container.DisplayIndex %>" ImageAlign="AbsMiddle" />
                                                </ItemTemplate>
                                                <ItemStyle Width="3%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="v2" runat="server">
                    <div class="card card-default">
                        <div class="card-body">
                            <div class="modal fade" id="modal-Subjects" data-keyboard="false" data-backdrop="static">
                                <div class="modal-dialog modal-lg">
                                    <div class="modal-content">
                                        <div class="modal-header" style="padding-bottom: 12px; padding-top: 12px; padding-left: 12px; padding-right: 12px;">
                                            <div class="align-left">
                                                <h4 class="modal-title">
                                                    <asp:Label ID="Label1" runat="server" Text="Courses"></asp:Label></h4>
                                            </div>
                                            <button type="button" class="close" data-dismiss="modal"
                                                aria-label="close">
                                                <span aria-hidden="true">&times;</span></button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <asp:Label ID="Label3" runat="server" Text="Subject Catogary"></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    <asp:DropDownList ID="ddlSubcats" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="ddlSubcats_TextChanged"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                &nbsp
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="True" PageSize="10">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkRow" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Lecture ID" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLectureID" runat="server" Text='<%# Bind("LectureID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Lecture Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLectureName" runat="server" Text='<%# Bind("LectureName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="40%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SubjectCatID" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubjectCatID" runat="server" Text='<%# Bind("SubjectCatID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Subject ID" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubjectID" runat="server" Text='<%# Bind("SubjectID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Subject Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubjectName" runat="server" Text='<%# Bind("SubjectName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Fee">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPriceRate" runat="server" Text='<%# Bind("PriceRate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                            <div class="modal-footer" style="padding-bottom: 12px; padding-top: 12px; padding-left: 12px; padding-right: 12px;">
                                                <asp:Button ID="btnAddSubs" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddSubs_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form">
                                <div class="form-group row">
                                    <div class="col-md-12">
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">RFID No</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtRFIDNo" runat="server" CssClass="form-control" TabIndex="1" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Initial</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtInitial" runat="server" CssClass="form-control" TabIndex="2" MaxLength="20"></asp:TextBox>
                                    </div>
                                    <span class="col-sm-2 control-label"></span>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">First Name</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" TabIndex="3" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Last Name</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" TabIndex="4" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Gender</span>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="DropDownGender" runat="server" CssClass="form-control" TabIndex="5">
                                            <asp:ListItem Selected="True" Value="1">Male</asp:ListItem>
                                            <asp:ListItem Value="2">Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Address</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TabIndex="6" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Gardiance Name</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtGardianceName" runat="server" CssClass="form-control" TabIndex="7" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">School Name</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtSchoolName" runat="server" CssClass="form-control" TabIndex="8" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Student Category</span>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="DropDownListStudent" runat="server" CssClass="form-control" TabIndex="9">
                                            <asp:ListItem Selected="True" Value="1">A/L</asp:ListItem>
                                            <asp:ListItem Value="2">O/L</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Date of Birth</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" TabIndex="10"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Contact No</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" TabIndex="11" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Select Courses</span>
                                    <div class="col-sm-3">
                                        <asp:Button ID="btnCourses" runat="server" Text="+" CssClass="btn btn-primary" OnClick="btnCourses_Click"></asp:Button>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-md-12">
                                        <asp:GridView ID="gvSelectCourses" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="True" PageSize="10" OnRowCommand="gvSelectCourses_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Lecture ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLectureID" runat="server" Text='<%# Bind("LectureID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Lecture Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLectureName" runat="server" Text='<%# Bind("LectureName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="40%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SubjectCatID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSubjectCatID" runat="server" Text='<%# Bind("SubjectCatID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Subject ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSubjectID" runat="server" Text='<%# Bind("SubjectID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Subject Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSubjectName" runat="server" Text='<%# Bind("SubjectName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Fee">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPriceRate" runat="server" Text='<%# Bind("PriceRate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnDelete" runat="server" CommandName="DeleteItem"
                                                            ImageUrl="~/Theme/dist/img/ic_delete.png" ToolTip="Delete Item" CommandArgument="<%# Container.DisplayIndex %>" ImageAlign="AbsMiddle" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="1%" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer" style="padding-bottom: 12px; padding-top: 12px; padding-left: 12px; padding-right: 12px;">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-success" TabIndex="8" OnClientClick="return Validate();" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" TabIndex="7" OnClientClick="return Validate();" OnClick="btnSave_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-default" TabIndex="10" OnClick="btnClear_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-warning" TabIndex="8" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hfPK1" runat="server" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" Style="display: none" OnClick="btnDelete_Click1" />
    <script>
        function pageLoad() {
            $(document).ready(function () {
                Validate = function () {
                    $('#<% = txtAddress.ClientID %>').addClass('validate[required]');
                    $('#<% = txtContact.ClientID %>').addClass('validate[required]');
                    $('#<% = txtDOB.ClientID %>').addClass('validate[required]');
                    $('#<% = txtFirstName.ClientID %>').addClass('validate[required]');
                    $('#<% = txtGardianceName.ClientID %>').addClass('validate[required]');
                    $('#<% = txtInitial.ClientID %>').addClass('validate[required]');
                    $('#<% = txtLastName.ClientID %>').addClass('validate[required]');
                    $('#<% = txtRFIDNo.ClientID %>').addClass('validate[required]');
                    $('#<% = txtSchoolName.ClientID %>').addClass('validate[required]');
                    $("#form1").validationEngine('attach', { promptPosition: "inline", scroll: false });
                    var valid = $("#form1").validationEngine('validate');
                    var vars = $("#form1").serialize();
                    if (valid == true) {
                        $("#form1").validationEngine('detach');
                    } else {
                        $("#form1").validationEngine('attach', { promptPosition: "inline", scroll: false });
                        return false;
                    }
                }
            });

            $("[id$=txtDOB]").datepicker({
                'format': 'yyyy-mm-dd', autoclose: true, todayHighlight: true
            }).attr('readonly', 'readonly');
        }

        function IsNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

        function ShowSubs() {
            $('.modal-backdrop').remove();
            $('#modal-Subjects').modal('show');
            return false;
        };

        function HideSubs() {
            $('.modal-backdrop').remove();
            $('body').removeClass('modal-open');
            $('#modal-Subjects').modal('hide');
            return false;
        };

        function ShowDeleteConfirmation() {
            alertify.confirm("Are you sure you want to delete this item?", function (e) {
                if (e) {
                    jQuery("[ID$=btnDelete]").click();
                } else {
                    alertify.error("OK!");
                }
            }).setHeader('<h3> Delete Confirmation </h3> ');;
            return flag;
        };
    </script>
</asp:Content>
