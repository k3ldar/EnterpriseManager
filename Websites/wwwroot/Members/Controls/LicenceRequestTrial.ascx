<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LicenceRequestTrial.ascx.cs" Inherits="SieraDelta.Website.Members.Controls.LicenceRequestTrial" %>

<div class="content form" style="width:94%;position:static;padding: 0 0 10px 0">
<h2><%=Languages.LanguageStrings.LicenceTrial %></h2>

<p><%=Languages.LanguageStrings.LicenceTrialDescription %></p>

<p>    <span><%=Languages.LanguageStrings.LicenceType %></span><br /><asp:DropDownList ID="ddlLicenceType" runat="server">
    </asp:DropDownList><br /><br />
</p>
    <asp:Button ID="btnCreateTrialLicence" runat="server" Text="Create" OnClick="btnCreateTrialLicence_Click" />
</div>