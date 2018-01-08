<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OfferBuyItNow.ascx.cs" Inherits="SieraDelta.Website.Controls.OfferBuyItNow" %>
<div>
    <p>
        <label><%=Languages.LanguageStrings.Size %>:</label>
        <asp:DropDownList ID="lstProductTypes" runat="server">
        </asp:DropDownList><br />
        <br />
        <asp:ImageButton ID="btnAddToBasket" runat="server"
            ImageUrl="/images/btn-add-to-bag.gif" OnClick="btnAddToBasket_Click" /><br />
    </p>
    <!-- end of .productInfo -->

</div>
