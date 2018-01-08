<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileDeliveryAddressEdit.ascx.cs" Inherits="SieraDelta.Website.Members.Controls.ProfileDeliveryAddressEdit" %>
<div class="content form">
    <asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error message goes here"></asp:Label><br />
    <label><%=Languages.LanguageStrings.Name %></label><asp:TextBox ID="txtName" runat="server" MaxLength="100"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.AddressLine1 %></label><asp:TextBox ID="txtAddr1" runat="server" MaxLength="45" AutoCompleteType="HomeStreetAddress"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.AddressLine2 %></label><asp:TextBox ID="txtAddr2" runat="server" MaxLength="45"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.AddressLine3 %></label><asp:TextBox ID="txtAddr3" runat="server" MaxLength="45"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.City %></label><asp:TextBox ID="txtCity" runat="server" MaxLength="45" AutoCompleteType="HomeCity"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.County %></label><asp:TextBox ID="txtCounty" runat="server" MaxLength="45" AutoCompleteType="HomeCountryRegion"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Postcode %></label><asp:TextBox ID="txtPostCode" runat="server" MaxLength="14" AutoCompleteType="HomeZipCode"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Country %></label>
        <asp:DropDownList ID="lstCountry" runat="server">
        </asp:DropDownList><br />
   
    <br />
    <asp:CheckBox ID="cbConfirmDelete" runat="server" Text="Confirm Delete" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" 
        onclick="btnDelete_Click" /> &nbsp;&nbsp;
    <asp:Button ID="btnUpdate" runat="server" Text="Submit" 
        onclick="btnUpdate_Click" />
    <div class="spacer"></div>
</div>

