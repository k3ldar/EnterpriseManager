<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientInvoices.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.ClientInvoices" %>
<asp:Table ID="tblInvoices" runat="server" CssClass="tblSalesLeads">
<asp:TableHeaderRow>
    <asp:TableHeaderCell Width="25%">Date</asp:TableHeaderCell>
    <asp:TableHeaderCell Width="25%">Invoice Reference</asp:TableHeaderCell>
    <asp:TableHeaderCell Width="25%">Item Quantity</asp:TableHeaderCell>
    <asp:TableHeaderCell Width="25%">Invoice Value</asp:TableHeaderCell>
</asp:TableHeaderRow>

<asp:TableFooterRow CssClass="tblOrders totals"><asp:TableCell ColumnSpan="4" ID="cellFooter" runat="server">Total Orders: £98.76</asp:TableCell></asp:TableFooterRow>
</asp:Table>
