<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountType.ascx.cs" Inherits="SieraDelta.Website.Controls.AccountType" %>

<asp:Table ID="tblAccountType" runat="server" Width="100%" CssClass="tblOrders">
    <asp:TableRow ID="trActionRequired" runat="server">
        <asp:TableCell Width="10%">Client Type:</asp:TableCell>
        <asp:TableCell ID="cellNew" runat="server" Width="65%">
            <asp:DropDownList ID="ddlClientType" runat="server">
                    <asp:ListItem Value="0">New Clients</asp:ListItem>
                    <asp:ListItem Value="10">Current Clients</asp:ListItem>
                    <asp:ListItem Value="30">New Distributors</asp:ListItem>
                    <asp:ListItem Value="40">Current Distributors</asp:ListItem>
                    <asp:ListItem Value="50">Archived Distributors</asp:ListItem>
                    <asp:ListItem Value="20">Archived Clients</asp:ListItem>
                    <asp:ListItem Value="60">Current @Home</asp:ListItem>
                    <asp:ListItem Value="70">Archived @Home</asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell ID="cellAction" runat="server" Width="25%">
            <asp:Button ID="btnChange" runat="server" OnClick="btnChange_Click" Text="Change Type" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>