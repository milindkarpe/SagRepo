<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true"
    CodeBehind="AddRank.aspx.cs" Inherits="SAG.AddRank" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header class="jumbotron subhead" id="Header1">
        <div class="page-header">
            <h1>
                Add Rank</h1>
        </div>
        <div>
        </div>
    </header>
    <asp:ToolkitScriptManager ID="sm" runat="server">
    </asp:ToolkitScriptManager>
    <asp:TabContainer ID="tcRank" runat="server" ActiveTabIndex="0">
        <asp:TabPanel ID="tpInsertEditDelete" runat="server">
            <HeaderTemplate>
                Insert/Edit Rank</HeaderTemplate>
            <ContentTemplate>
                <table class="table table-bordered table-condensed">
                    <tr>
                        <td>
                            Rank
                        </td>
                        <td>
                            <asp:TextBox ID="txtRank" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFRank" runat="server" ErrorMessage="*" ControlToValidate="txtRank"
                                ValidationGroup="Save"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Promotion Quota
                        </td>
                        <td>
                            <asp:TextBox ID="txtPQ" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFPQ" runat="server" ErrorMessage="*" ControlToValidate="txtPQ"
                                ValidationGroup="Save"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RVPQ" runat="server" ControlToValidate="txtPQ" ErrorMessage="Enter Valid Promotion Quota"
                                ValidationGroup="Save" MinimumValue="000" MaximumValue="9999999999" Type="Double"></asp:RangeValidator>
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
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" OnClick="btnSave_Click"
                                ValidationGroup="Save" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-info" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="tpSerch" runat="server">
            <HeaderTemplate>
                Search Rank</HeaderTemplate>
            <ContentTemplate>
                <table class="table table-bordered table-condensed">
                    <tr>
                        <td>
                            Enter Search Text :
                        </td>
                        <td>
                            <asp:TextBox ID="txtRankforSearch" runat="server"></asp:TextBox>
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
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" OnClick="btnSearch_Click" />
                            <asp:Label ID="lblRankID" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gvRank" runat="server" CssClass="table table-condensed" OnRowDeleting="gvRank_RowDeleting"
                                AutoGenerateColumns="False" onrowediting="gvRank_RowEditing">
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
                                    <asp:TemplateField HeaderText="RankID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRID" runat="server" Text='<%# Bind("RankID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rank">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRank" runat="server" Text='<%# Bind("Rank") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Promotional Quota">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPQ" runat="server" Text='<%# Bind("PQuota") %>'></asp:Label>
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
