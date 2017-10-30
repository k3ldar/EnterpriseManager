<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NotesNew.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.NotesNew" %>
<p style="display: block;margin-bottom:2px;"><b>Note:</b></p>
<asp:TextBox ID="txtNewNotes" runat="server" Height="80px" MaxLength="249" 
    TextMode="MultiLine" Width="300px"></asp:TextBox><br />
<asp:Button ID="btnAdd" runat="server" Text="Add Notes" 
    onclick="btnAdd_Click" />