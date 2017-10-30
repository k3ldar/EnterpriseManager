<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfilePassword.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Members.Controls.ProfilePassword" %>
<div class="content form">
    <asp:Label ForeColor="Red" ID="lblError" runat="server">Error Message goes here, hidden if no message</asp:Label><br /><br />
    <label><%=Languages.LanguageStrings.CurrentPassword %></label><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.NewPassword %></label><asp:TextBox ID="txtPasswordNew" runat="server" TextMode="Password"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.ConfirmNewPassword %></label><asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox><br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" />
</div>