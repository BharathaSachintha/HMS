<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Class.aspx.cs" Inherits="HMS.Pages.Class" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:MultiView ID="mvClass" runat="server">
                <asp:View ID="v1" runat="server">
                    <div class="card card-default">
                        <div class="card-header">
                            <div class="form-group row">
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" TabIndex="1" placeholder="Enter here to search" Visible="false"/>
                                </div>
                                <div class="col-md-1">
                                    <asp:ImageButton ID="imgbtnSearch" runat="server" TabIndex="2" ImageUrl="~/Theme/dist/img/ic_search.png"  Visible="false"/>
                                </div>
                                <div class="col-md-5">
                                </div>
                                <div class="col-md-2">
                                    <i class="fa fa-plus fa-fw fa-lg" aria-hidden="true"></i>
                                    <asp:Button ID="btnAddNew" runat="server" Text="Add Class" CssClass="btn btn-default" TabIndex="3" OnClick="btnAddNew_Click"/>
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
                                    <asp:GridView ID="gvClassMaster" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="True" PageSize="10" OnRowCommand="gvClassMaster_RowCommand" OnPageIndexChanging="gvClassMaster_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Class Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClassCode" runat="server" Text='<%# Bind("ClassCode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Class Description">
                                                <ItemTemplate>
                                                       <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Class Category">
                                                <ItemTemplate>
                                                       <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Class Type">
                                                <ItemTemplate>
                                                       <asp:Label ID="lblType" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Date of Conduct">
                                                <ItemTemplate>
                                                       <asp:Label ID="lblStartDate" runat="server" Text='<%# Bind("StartDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Start Time">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStartTime" runat="server" Text='<%# Bind("StartTime") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"/>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="End Time">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEndTime" runat="server" Text='<%# Bind("EndTime") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"/>
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
                            <div class="form">
                                <div class="form-group row">
                                    <div class="col-md-12">
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Lecture Name</span>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="DDLectureName" runat="server" CssClass="form-control" TabIndex="1"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Subject Name</span>
                                    <div class="col-sm-3">
                                       <asp:DropDownList ID="DDSubjectName" runat="server" CssClass="form-control" TabIndex="2"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Class Code</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtClassCode" runat="server" CssClass="form-control" TabIndex="3" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Description</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TabIndex="4" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Class Category</span>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="DDCategory" runat="server" CssClass="form-control" TabIndex="5">
                                            <asp:ListItem Selected="True" Value="1">A/L</asp:ListItem>
                                            <asp:ListItem Value="2">O/L</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Class Type</span>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="DDClassType" runat="server" CssClass="form-control" TabIndex="6">
                                            <asp:ListItem Selected="True" Value="1">Theory</asp:ListItem>
                                            <asp:ListItem Value="2">Revision</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Start Date</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" TabIndex="7" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Date of Conduct</span>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="DDDateOfCon" runat="server" CssClass="form-control" TabIndex="8" MaxLength="12">
                                            <asp:ListItem Selected="True" Value="1">Monday</asp:ListItem>
                                            <asp:ListItem Value="2">Tuesday</asp:ListItem>
                                            <asp:ListItem Value="3">Wensday</asp:ListItem>
                                            <asp:ListItem Value="4">Thursday</asp:ListItem>
                                            <asp:ListItem Value="5">Friday</asp:ListItem>
                                            <asp:ListItem Value="6">Saturday</asp:ListItem>
                                            <asp:ListItem Value="7">Sunday</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Start Time</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtStartTime" runat="server" CssClass="form-control" TabIndex="9" MaxLength="7"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">End Time</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtEndTime" runat="server" CssClass="form-control" TabIndex="10" MaxLength="7"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Admission Fee</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtAdmission" runat="server" CssClass="form-control" TabIndex="11" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Monthly Fee</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtMonthly" runat="server" CssClass="form-control" TabIndex="12" MaxLength="20"></asp:TextBox>
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
                    $('#<% = DDLectureName.ClientID %>').addClass('validate[required]');
                    $('#<% = DDSubjectName.ClientID %>').addClass('validate[required]');
                    $('#<% = txtClassCode.ClientID %>').addClass('validate[required]');
                    $('#<% = txtDescription.ClientID %>').addClass('validate[required]');
                    $('#<% = DDCategory.ClientID %>').addClass('validate[required]');
                    $('#<% = DDClassType.ClientID %>').addClass('validate[required]');
                    $('#<% = txtStartDate.ClientID %>').addClass('validate[required]');
                    $('#<% = DDDateOfCon.ClientID %>').addClass('validate[required]');
                    $('#<% = txtStartTime.ClientID %>').addClass('validate[required]');
                    $('#<% = txtEndTime.ClientID %>').addClass('validate[required]');
                    $('#<% = txtAdmission.ClientID %>').addClass('validate[required]');
                    $('#<% = txtMonthly.ClientID %>').addClass('validate[required]');
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

            $("[id$=txtStartDate]").datepicker({
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
