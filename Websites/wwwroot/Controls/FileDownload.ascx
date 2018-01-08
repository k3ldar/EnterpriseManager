<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileDownload.ascx.cs" Inherits="SieraDelta.Website.Controls.FileDownload" %>
<div class="productFeatures">
<h5><%=Languages.LanguageStrings.Download %></h5>
    <div class="content form">
        <p> 
            <label id="lblFileName" runat="server" style="width: 280px;font-weight: normal;" />
            <asp:Button ID="btnDownload" runat="server" Text="Download" onclick="btnDownload_Click" /><br />
        </p>
    </div>
</div>
