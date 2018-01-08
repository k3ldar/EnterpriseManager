<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.ascx.cs" Inherits="SieraDelta.Website.Controls.FileUpload" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="content form">
<h3>Step 1 - Upload Files</h3>
<asp:AjaxFileUpload ID="AjaxFileUpload1" runat="server" ThrobberID="pleasewait"
    MaximumNumberOfFiles="10" ContextKeys="upload" allowedfiletypes="" />

<br />

<asp:Button ID="btnNext" runat="server" Text="Next" onclick="btnNext_Click" />
</div>