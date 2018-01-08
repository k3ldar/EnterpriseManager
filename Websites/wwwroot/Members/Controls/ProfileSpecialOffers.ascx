<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileSpecialOffers.ascx.cs" Inherits="SieraDelta.Website.Members.Controls.ProfileSpecialOffers" %>
<div class="content form">
    <asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error message goes here"></asp:Label><br />
    <label><%=Languages.LanguageStrings.AcceptOffersTelephone %></label><asp:CheckBox ID="cbTelephoneOffers" runat="server" /><br />
    <label><%=Languages.LanguageStrings.AcceptOffersEmail %></label><asp:CheckBox ID="cbEmailOffers" runat="server" /><br />
    <label><%=Languages.LanguageStrings.AcceptOffersPostal %></label><asp:CheckBox ID="cbPostalOffers" runat="server" /><br />
    <asp:Button ID="btnUpdateSpecialOffers" runat="server" Text="Submit" 
        onclick="btnUpdateSpecialOffers_Click" />
    <div class="spacer"></div>
</div>

