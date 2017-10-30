<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasketAddNail.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.BasketAddNail" %>
<li>
    <img id="nailImage" runat="server" src="/images/nails/.png" border="0" alt="" />
    <span id="nailPrice" runat="server"></span>
    <asp:Button ID="btnAddToBasket" runat="server" Text="Add To Basket Button" OnClick="btnAddToBasket_Click" />
</li>
