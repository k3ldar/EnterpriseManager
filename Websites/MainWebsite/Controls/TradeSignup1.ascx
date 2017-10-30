<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TradeSignup1.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.TradeSignup1" %>
<%@ Register src="VerificationImage.ascx" tagname="VerificationImage" tagprefix="uc1" %>
<div class="content form">
    <h3><%=Languages.LanguageStrings.StepOneOfThree %></h3>
    <asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error message goes here"></asp:Label><br />
    <label><%=Languages.LanguageStrings.Email %></label><asp:TextBox ID="txtEmail" runat="server" MaxLength="250"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.ContactName %></label><asp:TextBox ID="txtName" runat="server" 
        MaxLength="99"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.CompanyName %></label><asp:TextBox ID="txtCompany" runat="server" 
        MaxLength="149"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.TelephoneNumber %></label><asp:TextBox ID="txtTelephone" runat="server" 
        MaxLength="99"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.AddressLine1 %></label><asp:TextBox ID="txtAddr1" runat="server" 
        MaxLength="100"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.AddressLine2 %></label><asp:TextBox ID="txtAddr2" runat="server" 
        MaxLength="100"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.AddressLine3 %></label><asp:TextBox ID="txtAddr3" runat="server" 
        MaxLength="100"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.City %></label><asp:TextBox ID="txtCity" runat="server" MaxLength="100"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.County %></label><asp:TextBox ID="txtCounty" runat="server" MaxLength="100"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Postcode %></label><asp:TextBox ID="txtPostCode" runat="server" 
        MaxLength="15"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Country %></label>
        <asp:DropDownList ID="lstCountry" runat="server">
        </asp:DropDownList><br />
   
    <uc1:VerificationImage ID="VerificationImage1" runat="server" />
    <br />
    <asp:Button ID="btnNext" runat="server" Text="Next" 
        onclick="btnNext_Click" />
    <div class="spacer"></div>
</div>

