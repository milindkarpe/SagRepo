<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="certificate.aspx.cs" Inherits="SAG.Admin.certificate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Certificate </title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container well">
        <div class="row">
            <div class="span">
                &nbsp;


            </div>
            <div class="span2">
                <img src="../images/Logo.png" width="80px" /><br />
            </div>
            <div class="span9">
                <br />
                <h1>
                    SAG SALES & FOODS PRIVATE LIMITED</h1>
            </div>
        </div>
        <div class="row">
            <div class="span4">
                <h4>
                    Reg No. 23423</h4>
                <h4>
                    Date/Time :
                    <asp:Label ID="lblTodaysDate" runat="server"></asp:Label></h4>
            </div>
            <div class="span4">
                <h2>
                    Certificate</h2>
            </div>
            <div class="span4">
                <h4>
                    Customer Id :
                    <asp:Label ID="lblCustId" runat="server"></asp:Label></h4>
            </div>
        </div>
        <div style="padding-top: 20px;">
            <table class="table table-bordered">
                <tr>
                    <td>
                        Reg No. & Date of Commencement
                    </td>
                    <td>
                        <asp:Label ID="lblRegNoDate" runat="server"></asp:Label>
                    </td>
                    <td>
                        Expected sum payable on Expiry of Term
                    </td>
                    <td>
                        <asp:Label ID="lblSumPayable" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Plan No. & Term
                    </td>
                    <td>
                        <asp:Label ID="lblPlan" runat="server"></asp:Label>
                    </td>
                    <td>
                        Subscription Due Date
                    </td>
                    <td>
                        <asp:Label ID="lblDueDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Amt. of Consideration
                    </td>
                    <td>
                        <asp:Label ID="lblAmtConsidaration" runat="server"></asp:Label>
                    </td>
                    <td>
                        Date of Last Payment
                    </td>
                    <td>
                        <asp:Label ID="lblLastPayDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Mode of Payment
                    </td>
                    <td>
                        <asp:Label ID="lblPayMode" runat="server"></asp:Label>
                    </td>
                    <td>
                        Date of Expiry of Term
                    </td>
                    <td>
                        <asp:Label ID="lblExpiryDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Installment Amount
                    </td>
                    <td>
                        <asp:Label ID="lblInstallAmt" runat="server"></asp:Label>
                    </td>
                    <td>
                        Code No.
                    </td>
                    <td>
                        <asp:Label ID="lblSeCode" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
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
                </tr>
            </table>
        </div>
        <div >
            <table class="table table-bordered">
                <tr>
                    <td>
                        Name of Purchaser
                    </td>
                    <td>
                        <asp:Label ID="lblPurchaser" runat="server"></asp:Label>
                    </td>
                    <td>
                        Age
                    </td>
                </tr>
                <tr>
                    <td>
                        Address
                    </td>
                    <td>
                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPurchaserAge" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nominee's Name
                    </td>
                    <td>
                        <asp:Label ID="lblNominee" runat="server"></asp:Label>
                    </td>
                    <td>
                        Age
                    </td>
                </tr>
                <tr>
                    <td>
                        Relation
                    </td>
                    <td>
                        <asp:Label ID="lblRelation" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblNomineeAge" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        Expected sum Payable (in words) :
                        <asp:Label ID="lblSumPayWords" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            Branch - Date - Checked BY - Signature - Stamp - Director
        </div>
        <div>
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <asp:Button ID="printButton" CssClass="btn btn-large btn-success" runat="server" Text="Print" OnClientClick="javascript:window.print();" />
        </div>
    </div>
    </form>
</body>
</html>
