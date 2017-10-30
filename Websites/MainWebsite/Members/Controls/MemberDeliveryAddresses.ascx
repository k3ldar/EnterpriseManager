<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberDeliveryAddresses.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Members.Controls.MemberDeliveryAddresses" %>
<div class="DeliveryAddress">
<p id="pAddress" runat="server"></p>

<p id="pPostageCost" runat="server"></p>

<div style="float: right; top: -150px;">
    <p class="content form"><asp:Button ID="btnSelect" runat="server" Text="Select" 
        onclick="btnSelect_Click" /></p>
</div>
</div>
