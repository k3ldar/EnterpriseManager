<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DiscountedProductItem.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.DiscountedProductItem" %>
<div class="binProductImg">
        <a Name="#tag" id="hrAnchor" runat="server">
            <img src="/Images/Product/no_image.jpg" alt="Product Image" border="0"
            runat="server" id="imgProduct" /></a>
        <div class="divDescription">
            <p class="binProductDescription" runat="server" id="pProductDescription">
                <strong>Delicate Days Sensitive Set</strong><br />
                Brief Description.
            </p>
            <p class="binProductDescription binProductContains" runat="server" id="pPriceDiscount">
                Contains: 15ml Bee Venom Eyes, Bee Venom Mask & Age Defiance.
            </p>
        </div>
        <p class="binProductBasket" id="pProductCost" runat="server">
            <label>
                Quantity:</label>
            <asp:DropDownList ID="lstQuantity" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:ImageButton ID="btnAddToBasket" runat="server" ImageUrl="/images/btn-add-to-bag.gif"
                Style="vertical-align: middle" OnClick="btnAddToBasket_Click" />
        </p>
</div>

<!-- end product -->
