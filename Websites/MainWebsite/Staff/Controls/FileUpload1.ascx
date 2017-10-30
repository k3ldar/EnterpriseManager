<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileUpload1.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.FileUpload1" %>
<div class="content form">
<h3>Step 2 - Review Upload</h3>
<label>FileName</label>
<asp:TextBox ID="txtFileName" runat="server"></asp:TextBox><br />
<label>Description</label>
<asp:TextBox ID="txtDescription" runat="server" Height="70px" MaxLength="200" 
    TextMode="MultiLine"></asp:TextBox><br />
<br />

<asp:Button ID="btnNext" runat="server" Text="Next" 
        onclick="btnNext_Click" /></div>