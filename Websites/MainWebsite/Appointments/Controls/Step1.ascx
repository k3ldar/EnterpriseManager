<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Step1.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Appointments.Controls.Step1" %>
<p><%=Languages.LanguageStrings.SelectTreatment %></p>
<div class="content form">
    <asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error message goes here"></asp:Label><br />
	<label for="lstTreatments"><%=Languages.LanguageStrings.Treatments %>:</label>
    <asp:ListBox ID="lstTreatments" runat="server" SelectionMode="Multiple" style="HEIGHT: 350px;"></asp:ListBox><br />

    <asp:Button ID="btnNext" runat="server" Text="Next" onclick="btnNext_Click" />
    <div class="spacer"></div><br />
</div>