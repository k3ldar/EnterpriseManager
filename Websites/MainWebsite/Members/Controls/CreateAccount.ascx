<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Members.Controls.CreateAccount" %>
<%@ Register src="~/Controls/VerificationImage.ascx" tagname="VerificationImage" tagprefix="uc1" %>
<div class="content form">
    <asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error message goes here"></asp:Label><br />
    <label><%=Languages.LanguageStrings.Email %></label><asp:TextBox ID="txtEmail" runat="server" MaxLength="100" AutoCompleteType="Email"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Password %></label><asp:TextBox ID="txtPassword" runat="server" 
        TextMode="Password" MaxLength="50"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.ConfirmPassword %></label><asp:TextBox ID="txtPasswordConfirm" 
        runat="server" TextMode="Password" MaxLength="50"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.FirstName %></label><asp:TextBox ID="txtFirstName" runat="server" MaxLength="50" AutoCompleteType="FirstName"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.LastName %></label><asp:TextBox ID="txtLastName" runat="server" MaxLength="50" AutoCompleteType="LastName"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.CompanyName %></label><asp:TextBox ID="txtCompany" runat="server" MaxLength="100" AutoCompleteType="Company"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.TelephoneNumber %></label><asp:TextBox ID="txtTelephone" runat="server" MaxLength="25" AutoCompleteType="HomePhone"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.AddressLine1 %></label><asp:TextBox ID="txtAddr1" runat="server" MaxLength="45" AutoCompleteType="HomeStreetAddress"></asp:TextBox><br />
    <label id="lblAddr2" runat="server"><%=Languages.LanguageStrings.AddressLine2 %></label><asp:TextBox ID="txtAddr2" runat="server" MaxLength="45"></asp:TextBox><br />
    <label id="lblAddr3" runat="server"><%=Languages.LanguageStrings.AddressLine3 %></label><asp:TextBox ID="txtAddr3" runat="server" MaxLength="45"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.City %></label><asp:TextBox ID="txtCity" runat="server" MaxLength="50" AutoCompleteType="HomeCity"></asp:TextBox><br />
    <label id="lblCounty" runat="server"><%=Languages.LanguageStrings.County %></label><asp:TextBox ID="txtCounty" runat="server" MaxLength="50" AutoCompleteType="HomeCountryRegion"></asp:TextBox><br />
    <label id="lblState" runat="server"><%=Languages.LanguageStrings.State %></label><asp:DropDownList ID="lstState" runat="server"></asp:DropDownList><br />
    <label id="lblPostCode" runat="server"><%=Languages.LanguageStrings.Postcode %></label><asp:TextBox ID="txtPostCode" runat="server" MaxLength="15" AutoCompleteType="HomeZipCode"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Country %></label>
        <asp:DropDownList ID="lstCountry" runat="server" 
        onselectedindexchanged="lstCountry_SelectedIndexChanged">
        </asp:DropDownList>
    <br />
    <uc1:VerificationImage ID="VerificationImage1" runat="server" />
    <br />
    <span><%=Languages.LanguageStrings.SpecialOffersDescription %></span><br /><br />
    <label><%=Languages.LanguageStrings.Telephone %></label><asp:CheckBox ID="cbTelephoneOffers" runat="server" /><br />
    <label><%=Languages.LanguageStrings.Email %></label><asp:CheckBox ID="cbEmailOffers" runat="server" Checked="true" /><br />
    <label><%=Languages.LanguageStrings.Postal %></label><asp:CheckBox ID="cbPostalOffers" runat="server" /><br />
    <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" 
        onclick="btnCreateAccount_Click" />
    <div class="spacer"></div>
</div>

