<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DownloadableFile.ascx.cs" Inherits="SieraDelta.Website.Controls.DownloadableFile" %>
<div class="content form">
<hr />
<div style="width:100%;height:100px;">
<asp:Image ID="imgPreview" runat="server" Width="100px" Height="100px" style="padding-right: 30px;" 
        Border="1" BorderStyle="None" ImageAlign="Left" />
<p id="lblFileName" runat="server"></p>
<p id="lblDescription" runat="server" style="font-weight:normal;float:left"></p>
<br />
<asp:Button ID="btnDownload" runat="server" Text="Download" onclick="btnDownload_Click" />
</div>
</div>

