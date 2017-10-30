<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberLogout.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Members.Controls.MemberLogout" %>
<div class="content form">
    <span><%=Languages.LanguageStrings.LogoutDescription %></span><br /><br />
    <asp:Button ID="btnAccountLogout" runat="server" Text="Logout" 
        onclick="btnAccountLogout_Click" />
    <div class="spacer"></div>
</div>