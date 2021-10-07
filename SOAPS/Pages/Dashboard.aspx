<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SOAPS.Pages.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="dms-box">
        <div class="inner">
            <table style="width: 100%;" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <div class="dms-container">
                            <div class="row">
                                <div class="col-lg-3 col-xs-6">
                                    <div class="small-box bg-deeporange">
                                        <div class="inner">
                                            <h4>
                                                <b>
                                                    <asp:Label ID="lblProcessDate" runat="server" Text=""></asp:Label></b></h4>
                                            <p></p>
                                        </div>
                                        <div class="icon">
                                            <i class="ion-ios-calendar"></i>
                                        </div>
                                        <a href="#" class="small-box-footer">&nbsp;</a>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-xs-6">
                                    <div class="small-box bg-teal">
                                        <div class="inner">
                                            <h4><b>
                                                <asp:Label ID="lblStudentCount" runat="server" Text=""></asp:Label></b></h4>
                                            <p>
                                                Student Count
                                            </p>
                                        </div>
                                        <div class="icon">
                                            <i class="ion-clipboard"></i>
                                        </div>
                                        <a href="#" class="small-box-footer">&nbsp;</a>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-xs-6">
                                    <div class="small-box bg-green">
                                        <div class="inner">
                                            <h4><b>
                                                <asp:Label ID="lblMonthlyIncome" runat="server" Text=""></asp:Label></b></h4>
                                            <p>Monthly Income(RS)</p>
                                        </div>
                                        <div class="icon">
                                            <i class="ion-clipboard"></i>
                                        </div>
                                        <a href="#" class="small-box-footer">&nbsp;</a>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-xs-6">
                                    <div class="small-box bg-yellow">
                                        <div class="inner">
                                            <h4><b>
                                                <asp:Label ID="lblClassCount" runat="server" Text=""></asp:Label></b></h4>
                                            <p>Class Count</p>
                                        </div>
                                        <div class="icon">
                                            <i class="ion-clipboard"></i>
                                        </div>
                                        <a href="#" class="small-box-footer">&nbsp;</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
