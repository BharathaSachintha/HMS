<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentPayment.aspx.cs" Inherits="HMS.Pages.StudentPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:MultiView ID="mvStudentPayment" runat="server">
                <asp:View ID="v1" runat="server">
                    <div class="card card-default">
                        <div class="card-header">
                            <div class="form-group row">
                                <div class="col-md-4">
                                    <%--<span class="col-sm-3 control-label">Class Category</span>--%>
                                    <asp:DropDownList ID="ddClassCategory" runat="server" CssClass="form-control" Visible="false">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <%--<span class="col-sm-3 control-label">Subject</span>--%>
                                    <asp:DropDownList ID="ddSubject" runat="server" CssClass="form-control" Visible="false">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <%-- <span class="col-sm-3 control-label">Lecture Name</span>--%>
                                    <asp:DropDownList ID="ddLecturer" runat="server" CssClass="form-control" Visible="false">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" TabIndex="1" placeholder="Search Student RFID Number" OnTextChanged="txtSearch_TextChanged" />
                                </div>

                                <div class="col-md-1">
                                    <asp:ImageButton ID="imgbtnSearch" runat="server" TabIndex="2" ImageUrl="~/Theme/dist/img/ic_search.png" OnClick="imgbtnSearch_Click" />
                                </div>
                                <div class="col-md-5">
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
                                    <asp:GridView ID="gvStudentPaymentMaster" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="True" PageSize="10" OnRowCommand="gvStudentPaymentMaster_RowCommand" OnPageIndexChanging="gvStudentPaymentMaster_PageIndexChanging">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Student ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStudentID" runat="server" Text='<%# Bind("StudentID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Student Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStudentName" runat="server" Text='<%# Bind("StudentName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Subject ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubjectID" runat="server" Text='<%# Bind("SubjectID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Lecturer ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLecturerID" runat="server" Text='<%# Bind("LecturerID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Subject Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubjectName" runat="server" Text='<%# Bind("SubjectName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Subject Fee">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFee" runat="server" Text='<%# Bind("PriceRate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Last Payment Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLastTransactionDate" runat="server" Text='<%# Bind("LastTransactionDate" , "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Payment Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPaid" runat="server" Text='<%# Enum.GetName(typeof(HMS.Model.Enum.PaymentMode), Convert.ToInt32(Eval("PaymentStatus"))) %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgbtnView" runat="server" CausesValidation="false" CommandName="Payment"
                                                        ImageUrl="~/Theme/dist/img/ic_view.png" Text="Button" CommandArgument="<%# Container.DisplayIndex %>" ImageAlign="AbsMiddle" OnClick="imgbtnView_Click" OnClientClick="Confirm()" />
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

            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hfPK1" runat="server" />
    <asp:Button ID="btnSave" runat="server" Text="Delete" Style="display: none" OnClick="btnSave_Click" />
    <%--<asp:HiddenField ID="hfPK1" runat="server" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" Style="display: none" OnClick="btnDelete_Click1" />--%>

    <%-- <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");

            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";

            if (confirm("Do you want to Confirm Payment?")) {
                confirm_value.value = "Yes";
            }
            else {
                confirm_value.value = "No";
            }

            document.forms[0].appendChild(confirm_value);
        }
    </script>--%>
    <script>
        function pageLoad() {
            $(document).ready(function () {
                Validate = function () {
                    <%--$('#<% = txtStartTime.ClientID %>').addClass('validate[required]');
                    $('#<% = txtEndTime.ClientID %>').addClass('validate[required]');--%>
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

            $("[id$=txtSheduledate]").datepicker({
                'format': 'yyyy-mm-dd', autoclose: true, todayHighlight: true
            }).attr('readonly', 'readonly');

            //$("[id$=txtPo_DoDate]").datepicker({
            //    'format': 'yyyy-mm-dd', autoclose: true, todayHighlight: true
            //}).attr('readonly', 'readonly');
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
            alertify.confirm("Paytment?", function (e) {
                if (e) {
                    jQuery("[ID$=btnSave]").click();
                } else {
                    alertify.error("OK!");
                }
            }).setHeader('<h3> Payment Confirmation </h3> ');;
            return flag;
        };
    </script>
</asp:Content>
