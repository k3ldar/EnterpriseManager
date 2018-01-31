<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Basket.aspx.cs" Inherits="SieraDelta.Website.Basket.PageBasket" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.ShoppingCart %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function clickclearVoucher(thisfield) {
            var defaulttext = '<%=GetVoucherString()%>';

            if (thisfield.value == defaulttext) {
                thisfield.value = "";
            }
        }
        function clickrecallVoucher(thisfield) {
            var defaulttext = '<%=GetVoucherString()%>';

            if (thisfield.value == "") {
                thisfield.value = defaulttext;
            }
        }
    </script>
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Shopping/Basket/"><%=Languages.LanguageStrings.ShoppingCart %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->


			<h1><%=Languages.LanguageStrings.ShoppingCart %></h1>
			
            <%=GetExtraBasketInformation() %>
            

            <div id="divBasketMobile" runat="server">

            </div>
			<table width="940px" border="0" cellspacing="0" cellpadding="0" class="tblBasket" id="tblBasket" runat="server">
				<tr>
                    <th style="width:90px;">&nbsp</th>
					<th><%=Languages.LanguageStrings.Description %></th>
					<th style="width:80px;"><%=Languages.LanguageStrings.Price %></th>
					<th style="width:80px;"><%=Languages.LanguageStrings.Quantity %></th>
					<th style="width:80px;"><%=Languages.LanguageStrings.Total %></th>
					<th style="width:75px;"><%=Languages.LanguageStrings.Remove %></th>
				</tr>
                <tr>
                  <td colspan="7" id="tdBasketItems" runat="server" style="margin:0;padding:0;"></td>
                </tr>
				<tr class="voucher" id="trVoucher" runat="server">
					<td colspan="7" class="voucher">
							<%=Languages.LanguageStrings.EnterPromotionalCode %>:<asp:TextBox 
                                ID="txtVoucher" runat="server" CssClass="voucher" MaxLength="30"  
                                onblur="clickrecallVoucher(this)" onclick="clickclearVoucher(this)"></asp:TextBox>&nbsp;
                                    
                             <asp:Button ID="btnApplyVoucherCode" runat="server" Text="Apply Code" OnClick="btnApplyVoucherCode_Click" />
                            <br />
					</td>
				</tr>
				<tr class="totals">
					<td colspan="4" id="tdSubTotal" runat="server" style="text-align: right;"></td>
					<td colspan="3" id="tdSubTotalAmount" runat="server"></td>
				</tr>
				<tr class="totals" id="trDiscount" runat="server">
					<td colspan="4" id="tdDiscountRate" runat="server" style="text-align: right;"></td>
					<td colspan="3" id="tdDiscount" runat="server"></td>
				</tr>
				<tr class="totals" id="trVAT" runat="server">
					<td colspan="4" id="tdVatRate" runat="server" style="text-align: right;"></td>
					<td colspan="3" id="tdVatAmount" runat="server"></td>
				</tr>
				<tr class="totals">
					<td colspan="4" id="tdPostage" runat="server" style="text-align: right;"></td>
					<td colspan="3" id="tdPostageAmount" runat="server"></td>
				</tr>
				<tr class="totals">
					<td colspan="4" id="tdTotal" runat="server" style="text-align: right;"></td>
					<td colspan="3" id="tdTotalAmmount" runat="server"></td>
				</tr>
                <tr class="totals"><td>&nbsp;</td></tr>
                <tr class="voucher" id="trGiftWrap" runat="server">
                    <td colspan="5" class="voucher" id="tdGiftWrapMessage" runat="server">
                        
                    </td>
                    <td colspan="2" class="voucher">
                        <asp:Button ID="btnAddGiftWrapping" runat="server" Text="add" OnClick="btnAddGiftWrapping_Click" />
                    </td>
                </tr>
			</table>
            <div class="clear"><!-- clear --></div>
            <p class="content form">
                <asp:Button ID="btnCheckoutBasket" runat="server" Text="Checkout" OnClick="btnCheckoutBasket_Click" />

                <asp:Button ID="btnContinueShopping" runat="server" class="right" Text="Continue Shopping" OnClick="btnContinueShopping_Click" />
            </p>
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
