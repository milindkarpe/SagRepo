<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true"
    CodeBehind="FreshBusiness.aspx.cs" Inherits="SAG.Admin.FreshBusiness" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="sm" runat="server">
    </asp:ToolkitScriptManager>
    <header class="jumbotron subhead" id="Header1">
        <div class="page-header">
            <h1>
                Fresh Business</h1>
        </div>
        <div align="center">
            <asp:Label ID="lblMsg" runat="server" CssClass="alert alert-success"
                Visible="false">
            </asp:Label>
            <asp:HyperLink ID="lnbCertificateLink" runat="server" Target="_blank" 
                CssClass="alert alert-info" Visible="false" >Click Here To Generate Certificate</asp:HyperLink>
        </div>
    </header>
    <div style="padding-top:10px;">
        <table class="table table-bordered table-condensed">
            <tr>
                <td>
                    Plan Type
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlPlanType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanType_SelectedIndexChanged"
                                TabIndex="0">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPlanType"
                                SetFocusOnError="true" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    Plan Name
                </td>
                <td>
                    <asp:UpdatePanel ID="up1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlPlanName" runat="server" TabIndex="1">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlPlanName"
                                SetFocusOnError="true" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    Mode of Payment
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlPayMode" runat="server" TabIndex="2">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Monthly</asp:ListItem>
                                <asp:ListItem Value="2">Quarterly</asp:ListItem>
                                <asp:ListItem Value="3">Half Yearly</asp:ListItem>
                                <asp:ListItem Value="4">Yearly</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="ddlPayMode"
                                SetFocusOnError="true" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Customer Code
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtCustCode" runat="server" CssClass="input-mini" AutoPostBack="True"
                                OnTextChanged="txtCustCode_TextChanged" TabIndex="3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCustCode"
                                SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    Customer Name
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtCustName" runat="server" Enabled="false" CssClass="input-large disabled"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    Introducer
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtIntroCode" runat="server" CssClass="input-mini" AutoPostBack="True"
                                OnTextChanged="txtIntroCode_TextChanged" TabIndex="4"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtIntroCode"
                                SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    Introducer Name
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtIntroName" runat="server" Enabled="false" CssClass="input-large disabled"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    Amount Received
                </td>
                <td>
                    <asp:TextBox ID="txtAmtRec" runat="server" CssClass="input-mini" TabIndex="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAmtRec"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                    Amount Received Mode
                </td>
                <td>
                    <asp:DropDownList ID="ddlAmtRecMode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAmtRecMode_SelectedIndexChanged"
                        TabIndex="7">
                        <asp:ListItem Value="0">Cash</asp:ListItem>
                        <asp:ListItem Value="1">Cheque</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Registration Fees
                </td>
                <td>
                    <asp:TextBox ID="txtRegFees" runat="server" CssClass="input-mini" AutoPostBack="True"
                        OnTextChanged="txtRegFees_TextChanged" TabIndex="6"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRegFees"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                    Cheque Number
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtChqNo" runat="server" CssClass="input-mini disabled" Text="000000"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtChqNo"
                                SetFocusOnError="true" ErrorMessage="*" TabIndex="8"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    Net Amount
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtNetAmt" runat="server" CssClass="input-mini disabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNetAmt"
                                SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    Bank Name
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtBankName" runat="server" Text="N/A" CssClass="input disabled"
                                TabIndex="9"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtChqNo"
                                SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    Purchase Date
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtPurDate" runat="server" CssClass="input-medium disabled" TabIndex="10"></asp:TextBox>
                    <asp:CalendarExtender ID="cxDBO" runat="server" TargetControlID="txtPurDate" PopupButtonID="imgCal"
                        Format="dd/MMM/yyyy" Animated="true">
                    </asp:CalendarExtender>
                    <i id="imgCal" class="icon icon-calendar"></i>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtPurDate"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPurDate"
                        CssClass="RequiredFieldValidator" ErrorMessage="Date must in proper format" ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\/(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\/\d{4}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" TabIndex="11"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-info" ValidationGroup="Nothing"
                        TabIndex="12" OnClick="btnReset_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
