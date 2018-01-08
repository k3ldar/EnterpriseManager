<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PreConditions.ascx.cs" Inherits="SieraDelta.Website.Appointments.Controls.PreConditions" %>
<h3>
    <%=SieraDelta.Languages.LanguageStrings.PreConditions %></h3>
<p>
    <%=SieraDelta.Languages.LanguageStrings.BookingConditionsDescription %></p>

<div class="content form">

    <asp:Button ID="btnNext" runat="server" Text="Next" onclick="btnNext_Click" />
</div>


