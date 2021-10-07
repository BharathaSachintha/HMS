<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginMaster.aspx.cs" Inherits="HMS.LoginMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="login-box-body">
                <p class="login-box-msg">Sign in to start your session</p>
                <div class="form-group">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text"><i class="fas fa-user"></i></span>
                        </div>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" TabIndex="1" placeholder="Username"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text"><i class="fas fa-lock"></i></span>
                        </div>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TabIndex="2" placeholder="Password" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-8">
                        &nbsp;
                    </div>
                    <div class="col-4">
                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-block" TabIndex="3" Text="Sign In" OnClick="btnLogin_Click"/>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <asp:Label ID="lblError" runat="server" CssClass="form-label" ForeColor="Red"></asp:Label>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
