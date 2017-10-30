<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MailListSubscribe.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.MailListSubscribe" %>
<%@ Register src="~/Controls/VerificationImage.ascx" tagname="VerificationImage" tagprefix="uc1" %>

<div class="content form">
    <asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error message goes here"></asp:Label><br />
    <label><%=Languages.LanguageStrings.Email %></label><asp:TextBox ID="txtEmail" runat="server" MaxLength="100" AutoCompleteType="Email"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Name %></label><asp:TextBox ID="txtName" runat="server" MaxLength="50" AutoCompleteType="FirstName"></asp:TextBox><br />
    <br />
    <uc1:VerificationImage ID="VerificationImage1" runat="server" />
    <br />
    <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" 
        onclick="btnCreateAccount_Click" />
    <div class="spacer"></div>
</div>
