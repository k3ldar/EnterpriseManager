<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Step2.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Appointments.Controls.Step2" %>
<div class="content form">
    <p><asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error message goes here"></asp:Label><br /></p>
	<label for="calDate"><%=Languages.LanguageStrings.PreferredDate %>:</label>
    <asp:Calendar ID="calDate" runat="server" 
        onselectionchanged="calDate_SelectionChanged"></asp:Calendar><br />
	<label for="lstStartTime"><%=Languages.LanguageStrings.PreferredStartTime %>:</label>
    <asp:DropDownList ID="lstStartTime" runat="server">
    </asp:DropDownList><br />
	<label for="lstTherapist"><%=Languages.LanguageStrings.PreferredTherapists %>:</label>
    <asp:DropDownList ID="lstTherapist" runat="server">
    </asp:DropDownList><br />
    <label for="txtNotes"><%=Languages.LanguageStrings.Notes %>:</label><asp:TextBox ID="txtNotes" runat="server" 
        MaxLength="230" TextMode="MultiLine"></asp:TextBox><br /><br />
    <asp:Button ID="btnNext" runat="server" Text="Next" onclick="btnNext_Click" />
    <div class="spacer"></div><br />
</div>