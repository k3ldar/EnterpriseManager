<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DownloadableFile.ascx.cs" Inherits="SieraDelta.Website.Members.Controls.DownloadableFile" %>
<div class="content form">
<hr />
<p>
<asp:Image ID="imgPreview" runat="server" Width="100px" Height="100px"  
        Border="1" BorderStyle="None" ImageAlign="Left" />
<p id="lblFileName" runat="server" style="float:left; left: 130px;position: absolute; top: 30px;"></p>
<p id="lblDescription" runat="server" style="font-weight:normal;float:left; left: 130px;position: absolute; top: 70px;"></p>
<br />
<asp:Button ID="btnDownload" runat="server" Text="Download" onclick="btnDownload_Click" />
</p>
</div>

