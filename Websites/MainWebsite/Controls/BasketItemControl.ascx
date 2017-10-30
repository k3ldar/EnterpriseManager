<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasketItemControl.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.BasketItemControl" %>
<table style="width:940px;" border="0" cellspacing="0" cellpadding="0">
    <tr>
		<td width="90px" ID="tdImage" runat="server">Price</td>
		<td ID="tdDescription" runat="server">Description</td>
		<td width="80px" ID="tdPrice" runat="server">Price</td>
		<td width="80px" ID="tdQuantity" runat="server" halign="right"><asp:Label ID="lblQuantity" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btnIncreaseQuantity" runat="server" Text="+" style="font-size:10px;margin:0;padding:0;margin-left:10px;width:17px;height:15px;" OnClick="btnIncreaseQuantity_Click" />
            <asp:Button ID="btnDecreaseQuantity" runat="server" Text="-" style="font-size:10px;margin:0;padding:0;width:17px;height:15px;" OnClick="btnDecreaseQuantity_Click" />
        </td>
		<td width="80px" ID="tdTotal" runat="server">Total</td>
		<td width="75px" ID="tdDelete" runat="server">
            <asp:ImageButton ID="btnRemoveItem" runat="server" 
    ImageUrl="/Images/remove.gif" ToolTip="Remove from basket" 
    onclick="btnRemoveItem_Click" />
        </td>
	</tr>
</table>