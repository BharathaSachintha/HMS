<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="HMS.Pages.UserRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:MultiView ID="mvUserRegister" runat="server">
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
                                    <asp:Button ID="btnAddNew" runat="server" Text="Add User" CssClass="btn btn-default" TabIndex="3" OnClick="btnAddNew_Click" />
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
                                    <asp:GridView ID="gvUserRegisterMaster" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="True" PageSize="10" OnRowCommand="gvUserRegisterMaster_RowCommand" OnPageIndexChanging="gvUserRegisterMaster_PageIndexChanging">
                                        <Columns>

                                            <asp:TemplateField HeaderText="User Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUser" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Real Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRealName" runat="server" Text='<%# Bind("RealName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"/>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Password" Visible="false">
                                                <ItemTemplate>
                                                       <asp:Label ID="lblPassword" runat="server" Text='<%# Bind("Password") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
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
                                    <span class="col-sm-3 control-label">User Name</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtusername" runat="server" CssClass="form-control" TabIndex="1" MaxLength="10"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Real Name</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtRealName" runat="server" CssClass="form-control" TabIndex="2" MaxLength="30"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <span class="col-sm-3 control-label">Password</span>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TabIndex="3" MaxLength="30" TextMode="Password"></asp:TextBox>
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
                    $('#<% = txtusername.ClientID %>').addClass('validate[required]');
                    $('#<% = txtRealName.ClientID %>').addClass('validate[required]');
                    $('#<% = txtPassword.ClientID %>').addClass('validate[required]');
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
    </script>
</asp:Content>
