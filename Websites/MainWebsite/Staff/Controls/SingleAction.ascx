﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SingleAction.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.SingleAction" %>
<asp:Table ID="tblSingleAction" runat="server" Width="100%" CssClass="tblOrders" style="margin-top:10px;">
    <asp:TableRow ID="trActionRequired" runat="server">
        <asp:TableCell ID="cellDescription" runat="server" Width="75%"></asp:TableCell>
        <asp:TableCell ID="cellAction" runat="server" Width="25%">
            Notes: <asp:TextBox ID="txtNotes" runat="server" MaxLength="249" /><br /><asp:Button ID="btnComplete" runat="server" OnClick="btnComplete_Click" style="margin-top:10px;" Text="Complete" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>