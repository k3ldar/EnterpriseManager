<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileBillingAddress.ascx.cs" Inherits="SieraDelta.Website.Members.Controls.ProfileBillingAddress" %>
<div class="content form">
    <asp:Label ForeColor="Red" ID="lblError" runat="server">Error Message goes here, hidden if no message</asp:Label><br /><br />
    <label><%=Languages.LanguageStrings.BusinessName %></label><asp:TextBox ID="txtBusinessName" runat="server" MaxLength="95" AutoCompleteType="Company"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.AddressLine1 %></label><asp:TextBox ID="txtAddr1" runat="server" MaxLength="45" AutoCompleteType="HomeStreetAddress"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.AddressLine2 %></label><asp:TextBox ID="txtAddr2" runat="server" MaxLength="45"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.AddressLine3 %></label><asp:TextBox ID="txtAddr3" runat="server" MaxLength="45"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.City %></label><asp:TextBox ID="txtCity" runat="server" MaxLength="45" AutoCompleteType="HomeCity"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.County %></label><asp:TextBox ID="txtCounty" runat="server" MaxLength="45" AutoCompleteType="HomeCountryRegion"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Postcode %></label><asp:TextBox ID="txtPostcode" runat="server" MaxLength="14" AutoCompleteType="HomeZipCode"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Country %></label>
    <asp:DropDownList ID="lstCountry" runat="server">
    </asp:DropDownList><br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" />
</div>