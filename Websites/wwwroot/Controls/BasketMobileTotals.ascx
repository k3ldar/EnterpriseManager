<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasketMobileTotals.ascx.cs" Inherits="SieraDelta.Website.Controls.BasketMobileTotals" %>
<div class="form mobileBasketTotals">
    <div class="basketVoucher">
		<p><%=Languages.LanguageStrings.EnterPromotionalCode %>:</p><asp:TextBox 
            ID="txtVoucher" runat="server" CssClass="voucher" MaxLength="30" style="max-width:80px;" 
            onblur="clickrecallVoucher(this)" onclick="clickclearVoucher(this)"></asp:TextBox>&nbsp;
                                    
            <asp:Button ID="btnApplyVoucherCode" runat="server" Text="Apply Code" style="float: right" OnClick="btnApplyVoucherCode_Click" />
    </div>

    <p id="pSubTotal" runat="server"></p>
    <p id="pVAT" runat="server"></p>
    <p id="pDiscount" runat="server"></p>
    <p id="pPostage" runat="server"></p>
    <p id="pTotal" runat="server"></p>
</div>