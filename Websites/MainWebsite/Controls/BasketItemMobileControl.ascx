<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasketItemMobileControl.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.BasketItemMobileControl" %>
<div class="basketMobile">
    <div id="pImage" runat="server" class="left"></div>
    <div class="right" style="width:65%;">
        <p id="pDescription" runat="server"></p>
        <p id="pQtyAndPrice" runat="server"></p>
        <div ID="divDelete" runat="server">
            <asp:Button ID="btnIncreaseQuantity" runat="server" Text="+" style="font-size:10px;margin:0;padding:0;margin-right:16px;width:17px;height:15px;" OnClick="btnIncreaseQuantity_Click" />
            <asp:Button ID="btnDecreaseQuantity" runat="server" Text="-" style="font-size:10px;margin:0;padding:0;margin-right:16px;width:17px;height:15px;" OnClick="btnDecreaseQuantity_Click" />
            <asp:ImageButton ID="btnRemoveItem" runat="server" 
                ImageUrl="/Images/remove.gif" ToolTip="Remove from basket" 
                onclick="btnRemoveItem_Click" />
            <p id="pTotal" runat="server" class="right"></p>

        </div>
    </div>
</div>