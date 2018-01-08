<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NotesNew.ascx.cs" Inherits="SieraDelta.Website.Controls.NotesNew" %>
<b>Note:</b><br />
<asp:TextBox ID="txtNewNotes" runat="server" Height="80px" MaxLength="249" 
    TextMode="MultiLine" Width="300px"></asp:TextBox><br />
<asp:Button ID="btnAdd" runat="server" Text="Add Notes" 
    onclick="btnAdd_Click" />