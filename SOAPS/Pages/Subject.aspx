<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subject.aspx.cs" Inherits="HMS.Pages.Subject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:MultiView ID="mvSubject" runat="server">
                <asp:View ID="v1" runat="server">
                    <div class="card card-default">
                        <div class="card-header">
                            <div class="form-group row">
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" TabIndex="1" placeholder="Enter here to search" Visible="false"/>
                                </div>
                                <div class="col-md-1">
                                    <asp:ImageButton ID="imgbtnSearch" runat="server" TabIndex="2" ImageUrl="~/Theme/dist/img/ic_search.png" Visible="false"/>
                                </div>
                                <div class="col-md-5">
                                </div>
                                <div class="col-md-2">
                                    <i class="fa fa-plus fa-fw fa-lg" aria-hidden="true"></i>
                                    <asp:Button ID="btnAddNew" runat="server" Text="Add Subject" CssClass="btn btn-default" TabIndex="3" OnClick="btnAddNew_Click" />
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
                                    <asp:GridView ID="gvSubjectMaster" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="True" PageSize="10" OnRowCommand="gvSubjectMaster_RowCommand" OnPageIndexChanging="gvSubjectMaster_PageIndexChanging1">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Subject Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubjectName" runat="server" Text='<%# Bind("getName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SubjectCatID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubjectCatID" runat="server" Text='<%# Bind("SubjectCatID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Subject Category">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubjectCategory" runat="server" Text='<%# Bind("getCategory") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Subject Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubjectDescription" runat="server" Text='<%# Bind("getDescription") %>'></asp:Label>
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
                            <div class="modal fade" id="modal-Cat" data-keyboard="false" data-backdrop="static">
                                <div class="modal-dialog modal-sm">
                                    <div class="modal-content">
                                        <div class="modal-header" style="padding-bottom: 12px; padding-top: 12px; padding-left: 12px; padding-right: 12px;">
                                            <div class="align-left">
                                                <h4 class="modal-title">
                                                    <asp:Label ID="Label1" runat="server" Text="New Subject Category"></asp:Label></h4>
                                            </div>
                                            <button type="button" class="close" data-dismiss="modal"
                                                aria-label="close">
                                                <span aria-hidden="true">&times;</span></button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtSubCat" runat="server" CssClass="form-control" placeholder="Enter New Category"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer" style="padding-bottom: 12px; padding-top: 12px; padding-left: 12px; padding-right: 12px;">
                                            <asp:Button ID="btnAddNewCat" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddNewCat_Click"/>
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
                                    <span class="col-sm-3 control-label">Subject Name</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtSubjectName" runat="server" CssClass="form-control" TabIndex="1" MaxLength="10"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Subject Category</span>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Button ID="btnAddSubCat" runat="server" Text="+" ToolTip="Add Subject Category" CssClass="btn btn-primary" OnClick="btnAddSubCat_Click" />
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Subject Discription</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtSubjectDiscription" runat="server" CssClass="form-control" TabIndex="2" MaxLength="30"></asp:TextBox>
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
                    $('#<% = txtSubjectName.ClientID %>').addClass('validate[required]');
                    $('#<% = DropDownList1.ClientID %>').addClass('validate[required]');
                    $('#<% = txtSubjectDiscription.ClientID %>').addClass('validate[required]');
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
        function ShowCat() {
            $('.modal-backdrop').remove();
            $('#modal-Cat').modal('show');
            return false;
        };

        function HideCat() {
            $('.modal-backdrop').remove();
            $('body').removeClass('modal-open');
            $('#modal-Cat').modal('hide');
            return false;
        };
    </script>
</asp:Content>
