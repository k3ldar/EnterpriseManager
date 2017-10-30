<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MailListUnsubscribe.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.MailListUnsubscribe" %>

<div class="content form">
    <asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error message goes here"></asp:Label><br />
    <label><%=Languages.LanguageStrings.Email %></label><asp:TextBox ID="txtEmail" runat="server" MaxLength="100" AutoCompleteType="Email"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.MailListReason %></label><asp:TextBox ID="txtReason" runat="server" MaxLength="50" AutoCompleteType="FirstName"></asp:TextBox><br />
    <asp:Button ID="btnUnsubscribe" runat="server" Text="Unsubscribe" 
        onclick="btnUnsubscribe_Click" />
    <div class="spacer"></div>
</div>
