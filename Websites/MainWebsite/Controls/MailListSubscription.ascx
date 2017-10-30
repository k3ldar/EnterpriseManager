<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MailListSubscription.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.MailListSubscription" %>


<div class="mailList mailListSubscribers" style="max-width=160px; width: 160px;padding-bottom: 15px;">
    <h3><%=Languages.LanguageStrings.MailListTitle %></h3>
    <label><%=Languages.LanguageStrings.MailListName %></label><br />
    <asp:TextBox ID="txtMailListName" runat="server" AutoCompleteType="FirstName" style="max-width=150px; width: 150px"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.MailListEmailAddress %></label><br />
    <asp:TextBox ID="txtMailListEmail" runat="server" AutoCompleteType="Email" style="max-width=150px; width: 150px"></asp:TextBox><br />
    <asp:Button ID="btnSubscribe" runat="server" Text="Subscribe" OnClick="btnSubscribe_Click" style="padding-top:8px;" />
</div>