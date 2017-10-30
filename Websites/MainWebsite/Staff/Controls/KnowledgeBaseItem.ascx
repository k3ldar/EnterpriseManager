<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KnowledgeBaseItem.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.KnowledgeBaseItem" %>
<p>
<asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label><br />
<label>Category:</label><asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
    <asp:Button
    ID="btnEdit" runat="server" Text="Edit" onclick="btnEdit_Click" />
</p>
