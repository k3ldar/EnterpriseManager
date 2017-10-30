<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAction.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.OpenAction" %>
<p id="pData" runat="server" class="ActionData"></p>
<asp:TextBox ID="txtNewNotes" runat="server" Height="80px" MaxLength="249" 
    TextMode="MultiLine" Width="300px"></asp:TextBox><br />
<asp:Button ID="btnComplete" runat="server" Text="Complete Action" 
    onclick="btnComplete_Click" />
<asp:Button ID="btnAddNotes" runat="server" onclick="btnAddNotes_Click" 
    Text="Add Notes" />
<asp:Button ID="btnBookVisit"
    runat="server" Text="Book Visit" onclick="btnBookVisit_Click" />
    <hr />