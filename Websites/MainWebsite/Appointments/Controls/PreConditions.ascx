<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PreConditions.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Appointments.Controls.PreConditions" %>
<h3>
    <%=Languages.LanguageStrings.PreConditions %></h3>
<p>
    <%=Languages.LanguageStrings.BookingConditionsDescription %></p>

<div class="content form">

    <asp:Button ID="btnNext" runat="server" Text="Next" onclick="btnNext_Click" />
</div>


