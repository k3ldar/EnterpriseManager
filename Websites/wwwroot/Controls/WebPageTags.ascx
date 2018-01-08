<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebPageTags.ascx.cs" Inherits="SieraDelta.Website.Controls.WebPageTags" %>
<div class="hashTags" runat="server" id="divHashTags">
    <h4><%=Languages.LanguageStrings.Tags %></h4>
    <ul id="ulTags" runat="server">
    </ul>
        <table id="tblTagManager" runat="server" class="hashTagsTable" width="100%">
            <tr><th colspan="3">Manage META&nbsp; #Tags &amp; Description</th></tr>
            <tr>
                <td>Add Tags</td>
                <td>
                    <asp:DropDownList ID="lstAddTags" runat="server">
                    </asp:DropDownList>
                </td>

                <td><asp:Button ID="btnAddTag" runat="server" Text="Add" 
                        onclick="btnAddTag_Click" /></td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td>Remove Tags</td>
                <td>
                    <asp:DropDownList ID="lstRemoveTags" runat="server">
                    </asp:DropDownList>
                </td>

                <td><asp:Button ID="btnRemoveTag" runat="server" Text="Remove" 
                        onclick="btnRemoveTag_Click" /></td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td>Create Tags</td>
                <td><asp:TextBox ID="txtCreateTag" runat="server"></asp:TextBox></td>
                <td><asp:Button ID="btnCreateTag" runat="server" Text="Create Tag" 
                        onclick="btnCreateTag_Click" /></td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr id="trDescription" runat="server">
                <td>META Description</td>
                <td id="tdDescription" runat="server" class="hashTagError"><asp:TextBox ID="txtDescription" runat="server" style="width: 90%" MaxLength="999" Rows="6" TextMode="MultiLine"></asp:TextBox></td>
                <td><asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" /></td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr id="tr1" runat="server">
                <td>Page Title</td>
                <td id="td1" runat="server" class="hashTagError"><asp:TextBox ID="txtTitle" runat="server" style="width: 90%" MaxLength="999" TextMode="SingleLine"></asp:TextBox></td>
                <td><asp:Button ID="btnSaveTitle" runat="server" Text="Save" OnClick="btnSaveTitle_Click" /></td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr><td>&nbsp;</td></tr>
            <tr id="trError" runat="server">
                <td>Error</td>
                <td colspan="2" id="tdError" runat="server" class="hashTagError"></td>
            </tr>
            <tr><td>&nbsp;</td></tr>
        </table>
</div>

