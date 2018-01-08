<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientOrders.ascx.cs" Inherits="SieraDelta.Website.Controls.ClientOrders" %>
<asp:Table ID="tblOrders" runat="server" CssClass="tblSalesLeads">
<asp:TableHeaderRow>
    <asp:TableHeaderCell Width="25%">Date</asp:TableHeaderCell>
    <asp:TableHeaderCell Width="25%">Order Reference</asp:TableHeaderCell>
    <asp:TableHeaderCell Width="25%">Item Quantity</asp:TableHeaderCell>
    <asp:TableHeaderCell Width="25%">Order Value</asp:TableHeaderCell>
</asp:TableHeaderRow>

<asp:TableFooterRow CssClass="tblOrders totals"><asp:TableCell ColumnSpan="4" ID="cellFooter" runat="server">Total Orders: £98.76</asp:TableCell></asp:TableFooterRow>
</asp:Table>
