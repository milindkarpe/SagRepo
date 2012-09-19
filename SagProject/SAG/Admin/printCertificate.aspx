<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printCertificate.aspx.cs"
    Inherits="SAG.Admin.printCertificate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Certificate </title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container " style="width: 21cm; height: 29cm;">
        <div class="row" style="margin-top: 4.4cm; margin-left: 3.5cm">
            <div class="span6">
                <asp:Label ID="lblPrintBy" runat="server">Mr. Milind</asp:Label>
                <br />
                <asp:Label ID="lblTodaysDate" runat="server"></asp:Label>
            </div>
            <%-- <div class="span2">
                <asp:Label ID="lblPolicyId" runat="server">  Policy Id :</asp:Label>
            </div>--%>
        </div>
        <div>
            <table style="margin-top: 1.5cm; margin-left: 1.5cm; margin-right: 1.5cm;" >
                <tr>
                    <td style="width: 3.6cm; height: 1.45cm;">
                        <%--Reg No. & Date of Commencement--%>
                    </td>
                    <td style="width: 5.6cm; height: 1.45cm;">
                        <asp:Label ID="lblRegNoDate" runat="server"></asp:Label>
                    </td>
                    <td style="width: 3.5cm; height: 1.45cm;">
                        <%--Expected sum payable on Expiry of Term--%>
                    </td>
                    <td style="width: 5.5cm; height: 1.45cm;">
                        <asp:Label ID="lblSumPayable" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="height: 0.75cm;">
                    <td>
                        <%--Plan No. & Term--%>
                    </td>
                    <td>
                        <asp:Label ID="lblPlan" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%--Subscription Due Date--%>
                    </td>
                    <td>
                        <asp:Label ID="lblDueDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="height: 0.75cm;">
                    <td>
                        <%--Amt. of Consideration--%>
                    </td>
                    <td>
                        <asp:Label ID="lblAmtConsidaration" runat="server"></asp:Label>
                    </td>
                    <td>
                       <%-- Date of Last Payment--%>
                    </td>
                    <td>
                        <asp:Label ID="lblLastPayDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="height: 0.75cm;">
                    <td>
                        <%--Mode of Payment--%>
                    </td>
                    <td>
                        <asp:Label ID="lblPayMode" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%--Date of Expiry of Term--%>
                    </td>
                    <td>
                        <asp:Label ID="lblExpiryDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="height: 0.75cm;">
                    <td>
                        <%--Installment Amount--%>
                    </td>
                    <td>
                        <asp:Label ID="lblInstallAmt" runat="server"></asp:Label>
                    </td>
                    <td>
                        <%--Code No.--%>
                    </td>
                    <td>
                        <asp:Label ID="lblSeCode" runat="server"></asp:Label>
                    </td>
                </tr>
                <%--                <tr>
                    <td>
                        Monthly Income
                    </td>
                    <td>
                        <asp:Label ID="lblMRAmount" runat="server"></asp:Label>
                    </td>
                    <td>
                        Amount on Accidental Death
                    </td>
                    <td>
                        <asp:Label ID="lblDeathAmount" runat="server"></asp:Label>
                    </td>
                </tr>--%>
                <tr style="height: 0.25cm;">
                    <td>
                    </td>
                </tr>
                <tr style="height: 0.6cm;">
                    <td>
                        <%--Name of Purchaser--%>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblPurchaser" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr style="height: 0.6cm;">
                    <td>
                        <%--Address--%>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr style="height: 0.6cm;">
                    <td>
                        <%--Telephone--%>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblTelephone" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr style="height: 0.6cm;">
                    <td>
                        <%--Age--%>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblPurchaserAge" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr style="height: 0.6cm;">
                    <td>
                        <%--Nominee's Name--%>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblNominee" runat="server"></asp:Label>
                        &nbsp; Age :
                        <asp:Label ID="lblNomineeAge" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr style="height: 0.6cm;">
                    <td>
                        <%--Relation--%>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblRelation" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr style="height: 0.7cm;">
                    <td>
                    </td>
                    <td style="padding-left: 1.5cm;" colspan="3">
                        <asp:Label ID="lblSumPayWords" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="height: 2.8cm;">
                    <td colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr style="height: 4.0cm;">
                    <td colspan="2">
                    </td>
                    <td colspan="2" valign="top" style="padding-left: 2.5cm;">
                        <asp:Label ID="lblRDate" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr style="height: 0.6cm;">
                    <td style="padding-left: 1.5cm;">
                        <asp:Label ID="lblCSC" runat="server" ></asp:Label>
                    </td>
                    <td style="padding-left: 2.0cm;">
                        <asp:Label ID="lblCSCNo" runat="server" ></asp:Label>
                    </td>
                    <td style="padding-left: 2.0cm;">
                        <asp:Label ID="lblRecNo" runat="server" ></asp:Label>
                    </td>
                    <td style="padding-left: 3.0cm;">
                        <asp:Label ID="lblSrNo" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr style="height: 0.6cm;">
                    <td colspan="4" style="padding-left: 17.0cm;">
                        <asp:Label ID="lblAge" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr style="height: 1.9cm;">
                    <td colspan="3">
                        <asp:Label ID="lblRName" runat="server" ></asp:Label><br />
                        <asp:Label ID="lblRAdd" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="height: 0.45cm;">
                    <td>
                    </td>
                    <td style="padding-left: 0.5cm;">
                        <asp:Label ID="lblRegNo" runat="server" ></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td style="padding-left: 0.5cm;">
                        <asp:Label ID="lblRInstalAmount" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr style="height: 0.45cm;">
                    <td>
                    </td>
                    <td style="padding-left: 0.5cm;">
                        <asp:Label ID="lblRStartDate" runat="server" ></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td style="padding-left: 0.5cm;">
                        <asp:Label ID="lblRDueDate" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr style="height: 0.45cm;">
                    <td>
                    </td>
                    <td style="padding-left: 0.5cm;">
                        <asp:Label ID="lblRPlanNoTerm" runat="server" ></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td style="padding-left: 0.5cm;">
                        <asp:Label ID="lblRExpDate" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr style="height: 0.45cm;">
                    <td>
                    </td>
                    <td style="padding-left: 0.5cm;">
                        <asp:Label ID="lblRPlanAmount" runat="server" ></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td style="padding-left: 0.5cm;">
                        <asp:Label ID="lblRCodeNo" runat="server" ></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <input type="button" value="Print This Page" class=" btn btn-large btn-success" onclick="window.print()" />
        </div>
    </div>
    </form>
</body>
</html>
