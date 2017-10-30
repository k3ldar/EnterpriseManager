<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileUserName.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Members.Controls.ProfileUserName" %>
<div class="content form">
    <asp:Label ForeColor="Red" ID="lblError" runat="server">Error Message goes here, hidden if no message</asp:Label><br /><br />
    <label><%=Languages.LanguageStrings.Email %></label><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.FirstName %></label><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.LastName %></label><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.TelephoneNumber %></label><asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox><br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" />
</div>