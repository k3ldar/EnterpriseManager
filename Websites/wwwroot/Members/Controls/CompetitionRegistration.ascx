<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompetitionRegistration.ascx.cs" Inherits="SieraDelta.Website.Members.Controls.CompetitionRegistration" %>
<div class="content form">
    <h2><%=Languages.LanguageStrings.EnterCompetition %></h2>
    <label id="lblMessage" runat="server"></label>
    <label id="lblCompetition" runat="server"></label><br />
    <label><%=Languages.LanguageStrings.Name %>:</label><asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Email %>:</label><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.DateOfBirth %>:*</label><asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.ReceiveOffers %></label><asp:CheckBox ID="cbReceiveEmails" runat="server" Checked="true" />
    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" /><asp:Button ID="btnUnregister" runat="server" Text="Unregister" OnClick="btnUnregister_Click" Visible="False" /><br />
    <p style="font-size: 1.0em;">* <%=Languages.LanguageStrings.Optional %></p>
</div>