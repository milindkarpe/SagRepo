<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true"
    CodeBehind="AddDistributor.aspx.cs" Inherits="SAG.AddDistributor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header class="jumbotron subhead" id="Header1">
        <div class="page-header">
            <h1>
                Add Distributor</h1>
        </div>
        <div align="center">
        <asp:Label ID="lblMsg" runat="server" CssClass="alert alert-success" Width="90%" Visible="false"></asp:Label>
        </div>
    </header>
    <asp:ToolkitScriptManager ID="sm" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <table class="table table-bordered table-condensed">
         <%--   <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>--%>
            <tr>
                <td>
                    Rank
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlRank" runat="server">
                        <asp:ListItem>1- Sales Executive</asp:ListItem>
                        <asp:ListItem>2- Chief Sales Executive</asp:ListItem>
                        <asp:ListItem>114</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Introducer
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtIntroducer" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="lnbUplinkDetails" runat="server" Text="Uplink Details"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    CSC
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlCSC" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Name
                </td>
                <td>
                    <asp:DropDownList ID="ddlPre" runat="server" CssClass="input-mini">
                        <asp:ListItem>Mr.</asp:ListItem>
                        <asp:ListItem>Mrs.</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                    Pancard
                </td>
                <td>
                    <asp:TextBox ID="txtPan" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPan"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPreSDW" runat="server" CssClass="input-mini">
                        <asp:ListItem>S/O</asp:ListItem>
                        <asp:ListItem>D/O</asp:ListItem>
                        <asp:ListItem>W/O</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtSDW" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSDW"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                    Email
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="Enter Valid EmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Present Address
                </td>
                <td>
                    <asp:TextBox ID="txtPreAdd" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPreAdd"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                    Permanent Address
                </td>
                <td>
                    <asp:TextBox ID="txtPerAdd" runat="server" TextMode="MultiLine"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPerAdd"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Pincode
                </td>
                <td>
                    <asp:TextBox ID="txtPrePin" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPrePin"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtPrePin"
                        Display="Dynamic" ErrorMessage="Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                </td>
                <td>
                    Pincode
                </td>
                <td>
                    <asp:TextBox ID="txtPerPin" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPerPin"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtPerPin"
                        Display="Dynamic" ErrorMessage="Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Mobile No
                </td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtMobile"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtMobile"
                        Display="Dynamic" ErrorMessage="Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="treFieldOfficerMobile" runat="server" ControlToValidate="txtMobile"
                        ValidationExpression="^((\+)?(\d{2}[-]))?(\d{10}){1}?$" Display="Dynamic" SetFocusOnError="True">Enter Valid Mobile No.</asp:RegularExpressionValidator>
                </td>
                <td>
                    Nominee
                </td>
                <td>
                    <asp:TextBox ID="txtNominee" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtNominee"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Telehone
                </td>
                <td>
                    <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtTelephone"
                        ErrorMessage="Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                </td>
                <td>
                    Relation
                </td>
                <td>
                    <asp:TextBox ID="txtRelation" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtRelation"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    DOB
                </td>
                <td>
                    <asp:TextBox ID="txtDOB" runat="server" CssClass="input-medium disabled"> </asp:TextBox>
                    <asp:CalendarExtender ID="cxDBO" runat="server" TargetControlID="txtDOB" PopupButtonID="imgCal"
                        Format="dd/MMM/yyyy" Animated="true">
                    </asp:CalendarExtender>
                    <i id="imgCal" class="icon icon-calendar"></i>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDOB"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDOB"
                        CssClass="RequiredFieldValidator" ErrorMessage="Date must in proper format" ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\/(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\/\d{4}$"></asp:RegularExpressionValidator>
                </td>
                <td>
                    Nominee DBO
                </td>
                <td>
                    <asp:TextBox ID="txtDBONom" runat="server" CssClass="input-medium disabled"></asp:TextBox>
                    <asp:CalendarExtender ID="cxNDBO" runat="server" TargetControlID="txtDBONom" PopupButtonID="imgCal2"
                        Format="dd/MMM/yyyy" Animated="true">
                    </asp:CalendarExtender>
                    <i id="imgCal2" class="icon icon-calendar"></i>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtDBONom"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDBONom"
                        CssClass="RequiredFieldValidator" ErrorMessage="Date must in proper format" ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\/(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\/\d{4}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Age
                </td>
                <td>
                <asp:TextBox ID="txtAge" runat="server" CssClass="input-mini"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtAge"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtAge"
                        ErrorMessage="Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                </td>
                <td>
                    Nominee Age
                </td>
                <td>
                    <asp:TextBox ID="txtAgeNom" runat="server" CssClass="input-mini"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtAgeNom"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtAgeNom"
                        ErrorMessage="Enter Only Numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Date of Joining
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtJoinDate" runat="server" CssClass="input-medium disabled"></asp:TextBox>
                    <asp:CalendarExtender ID="cxJoinDate" runat="server" TargetControlID="txtJoinDate"
                     Format="dd/MMM/yyyy"  Animated="true" PopupButtonID="imgJoinDate">
                    </asp:CalendarExtender>
                    <i id="imgJoinDate" class="icon icon-calendar"></i>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtJoinDate"
                        SetFocusOnError="true" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtJoinDate"
                        CssClass="RequiredFieldValidator" ErrorMessage="Date must in proper format" ValidationExpression="^(([0-9])|([0-2][0-9])|([3][0-1]))\/(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)\/\d{4}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" OnClick="btnSave_Click" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-info" 
                        ValidationGroup="Nothing" onclick="btnReset_Click"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
