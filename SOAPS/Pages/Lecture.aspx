<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lecture.aspx.cs" Inherits="HMS.Pages.Lecture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:MultiView ID="mvLecture" runat="server">
                <asp:View ID="v1" runat="server">
                    <div class="card card-default">
                        <div class="card-header">
                            <div class="form-group row">
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" TabIndex="1" placeholder="Enter here to search" Visible="false" />
                                </div>
                                <div class="col-md-1">
                                    <asp:ImageButton ID="imgbtnSearch" runat="server" TabIndex="2" ImageUrl="~/Theme/dist/img/ic_search.png" Visible="false" />
                                </div>
                                <div class="col-md-5">
                                </div>
                                <div class="col-md-2">
                                    <i class="fa fa-plus fa-fw fa-lg" aria-hidden="true"></i>
                                    <asp:Button ID="btnAddNew" runat="server" Text="Add Lecturer" CssClass="btn btn-default" TabIndex="3" OnClick="btnAddNew_Click" />
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
                                    <asp:GridView ID="gvLectureMaster" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="True" PageSize="10" OnRowCommand="gvLectureMaster_RowCommand" OnPageIndexChanging="gvLectureMaster_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Title">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLectureTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Initial" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLectureInitial" runat="server" Text='<%# Bind("Initials") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Lecturer First Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLectureName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Lecturer Last Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLectureLName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Lecturer Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLectureAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Lecturer NIC No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLectureNIC" runat="server" Text='<%# Bind("NICNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Lecturer Contact Number">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLectureContact" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rate" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLectureRate" runat="server" Text='<%# Bind("Rate") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Lecturer Email">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLecturerEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
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
                                                    <asp:Label ID="Label1" runat="server" Text="Subjects"></asp:Label></h4>
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
                                                    <asp:DropDownList ID="ddlSubcats" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSubcats_SelectedIndexChanged"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                &nbsp
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:GridView ID="gvSubs" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="True" PageSize="10">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkRow" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="1%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Sub Cat" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubCat" runat="server" Text='<%# Bind("SubjectCatID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SubjectCatName" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubjectCatName" runat="server" Text='<%# Bind("getCategory") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Subject ID" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubID" runat="server" Text='<%# Bind("SubjectID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="40%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Subject Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSubName" runat="server" Text='<%# Bind("getName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" Width="40%" />
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
                                    <span class="col-sm-3 control-label">Title</span>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="DropDownTitle" runat="server" CssClass="form-control" TabIndex="1">
                                            <asp:ListItem Selected="True" Value="1">Rev</asp:ListItem>
                                            <asp:ListItem Value="2">Prof</asp:ListItem>
                                            <asp:ListItem Value="3">Dr</asp:ListItem>
                                            <asp:ListItem Value="4">Mr</asp:ListItem>
                                            <asp:ListItem Value="5">Ms</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Initials</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtLecturerInitials" runat="server" CssClass="form-control" TabIndex="2" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Lecturer First Name</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtLecturerFirstName" runat="server" CssClass="form-control" TabIndex="3" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Lecturer Last Name</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtLecturerLastName" runat="server" CssClass="form-control" TabIndex="4" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Lecturer Address</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtLecturerAddress" runat="server" CssClass="form-control" TabIndex="5" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Lecturer NIC NO</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtLecturerNIC" runat="server" CssClass="form-control" TabIndex="6" MaxLength="12"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Lecturer Contact No</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtLecturerContact" runat="server" CssClass="form-control" TabIndex="7" MaxLength="10"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Lecturer Email</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtLecturerEmail" runat="server" CssClass="form-control" TabIndex="8" MaxLength="30"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Lecturer Rate</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtLecturerRate" runat="server" CssClass="form-control" TabIndex="9" MaxLength="30"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Subjects</span>
                                    <div class="col-sm-1">
                                        <asp:Button ID="btnSub" runat="server" Text="+" CssClass="btn btn-primary" OnClick="btnSub_Click" />
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <asp:GridView ID="gvPrice" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" OnRowCommand="gvPrice_RowCommand" AllowPaging="True" PageSize="10">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sub Cat" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubCat" runat="server" Text='<%# Bind("SubjectCatID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SubjectCatName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubjectCatName" runat="server" Text='<%# Bind("getCategory") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Subject ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubID" runat="server" Text='<%# Bind("SubjectID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Subject Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubName" runat="server" Text='<%# Bind("getName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="40%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Price Rate">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" AutoPostBack="true" Text='<%# Bind("PriceRate") %>' placeholder="0.00" TabIndex="1"></asp:TextBox>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="40%" />
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
                            <div class="card-footer" style="padding-bottom: 12px; padding-top: 12px; padding-left: 12px; padding-right: 12px;">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-success" TabIndex="8" OnClientClick="return Validate();" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" TabIndex="7" OnClientClick="return Validate();" OnClick="btnSave_Click" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-default" TabIndex="10" OnClick="btnClear_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-warning" TabIndex="8" OnClick="btnCancel_Click" />
                            </div>
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
                    $('#<% = DropDownTitle.ClientID %>').addClass('validate[required]');
                    $('#<% = txtLecturerInitials.ClientID %>').addClass('validate[required]');
                    $('#<% = txtLecturerFirstName.ClientID %>').addClass('validate[required]');
                    $('#<% = txtLecturerLastName.ClientID %>').addClass('validate[required]');
                    $('#<% = txtLecturerAddress.ClientID %>').addClass('validate[required]');
                    $('#<% = txtLecturerContact.ClientID %>').addClass('validate[required]');
                    $('#<% = txtLecturerEmail.ClientID %>').addClass('validate[required]');
                    $('#<% = txtLecturerNIC.ClientID %>').addClass('validate[required]');
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

        function IsNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

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
