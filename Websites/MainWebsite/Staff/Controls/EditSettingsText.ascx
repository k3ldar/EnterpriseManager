<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditSettingsText.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.EditSettingsText" %>
<p>
    <strong id="settingName" runat="server"></strong><br />
    <span id="settingDescription" runat="server"></span><br />
    Value: <asp:TextBox ID="settingText" runat="server" MaxLength="500" Width="250px"></asp:TextBox><asp:CheckBox ID="cbSetting" runat="server"></asp:CheckBox>&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    
</p>