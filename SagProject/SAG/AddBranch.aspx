<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true"
    CodeBehind="AddBranch.aspx.cs" Inherits="SAG.AddBranch" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <header class="jumbotron subhead" id="Header1">
        <div class="page-header">
            <h1>
                Add Branch</h1>
        </div>
        <div>
        </div>
    </header>
    <asp:ToolkitScriptManager ID="sm" runat="server">
    </asp:ToolkitScriptManager>
    <asp:TabContainer ID="tcBranch" runat="server" ActiveTabIndex="0">
        <asp:TabPanel ID="tpInsertEditDelete" runat="server">
            <HeaderTemplate>
                Insert/Edit Branch</HeaderTemplate>
            <ContentTemplate>
                <table class="table table-bordered table-condensed">
                    <tr valign="middle">
                        <td valign="middle">
                            Code
                        </td>
                        <td valign="middle">
                            <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RF1" runat="server" ErrorMessage="*" ControlToValidate="txtCode"
                                ValidationGroup="Save"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Branch Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtBName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFPQ" runat="server" ErrorMessage="*" ControlToValidate="txtBName"
                                ValidationGroup="Save"></asp:RequiredFieldValidator>                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Address
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtAddress"
                                ValidationGroup="Save"></asp:RequiredFieldValidator>                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            City
                        </td>
                        <td>
                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtCity"
                                ValidationGroup="Save"></asp:RequiredFieldValidator>                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            State
                        </td>
                        <td>
                            <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtState"
                                ValidationGroup="Save"></asp:RequiredFieldValidator>                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Telephone
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtTelephone"
                                ValidationGroup="Save"></asp:RequiredFieldValidator>                            
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblSaveMsg" runat="server" Width="90%" CssClass="alert alert-success"
                                Visible="False"></asp:Label>
                            <asp:Label ID="lblSaveError" runat="server" Width="90%" CssClass="alert alert-danger"
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info"
                                ValidationGroup="Save" onclick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-info" 
                                onclick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="tpSerch" runat="server">
            <HeaderTemplate>
                Search Branch</HeaderTemplate>
            <ContentTemplate>
                <table class="table table-bordered table-condensed">
                    <tr>
                        <td>
                            Enter Search Text :
                        </td>
                        <td>
                            <asp:TextBox ID="txtBranchforSearch" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblMsg" runat="server" Width="90%" CssClass="alert alert-success"
                                Visible="False"></asp:Label>
                            <asp:Label ID="lblErrorMsg" runat="server" Width="90%" CssClass="alert alert-danger"
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" 
                                onclick="btnSearch_Click" />
                            <asp:Label ID="lblBranchID" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gvBranch" runat="server" CssClass="table table-condensed"
                                AutoGenerateColumns="False" onrowdeleting="gvBranch_RowDeleting" 
                                onrowediting="gvBranch_RowEditing" >
                                <Columns>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnbEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                                Text="Edit"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnbDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                OnClientClick="return confirm('Are you sure you want to delete?');" Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBID" runat="server" Text='<%# Bind("BranchID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBCode" runat="server" Text='<%# Bind("bCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBName" runat="server" Text='<%# Bind("bName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="City">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBCity" runat="server" Text='<%# Bind("bCity") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("bAddress") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Contact">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTel" runat="server" Text='<%# Bind("bTelephone") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
</asp:Content>
