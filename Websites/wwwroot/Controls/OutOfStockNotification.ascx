<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OutOfStockNotification.ascx.cs" Inherits="SieraDelta.Website.Controls.OutOfStockNotification" %>
<p class="ProductBasket" id="pAddRemoveNotification" runat="server">
    <label id="lblDescription" runat="server"></label>
    <br />
    <br />
    <label><%=Languages.LanguageStrings.Email %></label>: <asp:TextBox ID="txtEmail" runat="server" MaxLength="100"></asp:TextBox>
    <br />
    <label id="lblError" runat="server"></label>
    <br />
    <asp:Button ID="btnAddNotification" runat="server" Text="Out of Stock" CssClass="standardButton" OnClick="btnAddNotification_Click" />
    <asp:Button ID="btnRemoveNotification" runat="server" Text="Out of Stock" CssClass="standardButton" OnClick="btnRemoveNotification_Click" />
</p>
<!-- end of .productInfo -->
