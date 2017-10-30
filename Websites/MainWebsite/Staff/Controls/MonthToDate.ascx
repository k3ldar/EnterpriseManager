<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MonthToDate.ascx.cs"
    Inherits="Heavenskincare.WebsiteTemplate.Controls.MonthToDate" %>
<h3 id="hMTD" runat="server">
    Month To Date</h3>

<asp:Table ID="tblMonthToDate" runat="server" class="tblMTD">
    <asp:TableHeaderRow ID="TableHeaderRow5" runat="server" class="tblMTD th">
        <asp:TableCell>&nbsp;</asp:TableCell>
    </asp:TableHeaderRow>
    <asp:TableRow ID="TableRowCurrent" runat="server" class="tblMTD th">
        <asp:TableCell>Current</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="TableRowPrevious" runat="server">
        <asp:TableCell>Previous</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="TableRowDifference" runat="server">
        <asp:TableCell>Difference</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="TableRowPercent" runat="server">
        <asp:TableCell>%</asp:TableCell>
    </asp:TableRow>
</asp:Table>
