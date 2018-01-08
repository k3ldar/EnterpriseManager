<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="BasketCheckout.aspx.cs" Inherits="SieraDelta.Website.Basket.BasketCheckout" %>

<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc1" %>

<%@ Register src="~/Controls/CreditCardPaymentControl.ascx" tagname="CreditCardPaymentControl" tagprefix="uc2" %>

<%@ Register src="~/Controls/OrderSummary.ascx" tagname="OrderSummary" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.ConfirmOrder %> - <%=Languages.LanguageStrings.YourShoppingBag %> - <%=GetWebTitle()%></title>
    <link rel="Stylesheet" href="/css/Basket.css" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">
        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Shopping/Basket/"><%=Languages.LanguageStrings.ShoppingBag %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Shopping/Basket/Delivery-Address/"><%=Languages.LanguageStrings.DeliveryAddress %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Shopping/Basket/Confirm-Order/"><%=Languages.LanguageStrings.ConfirmOrder %></a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->

        <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />

        <div class="mainContent">
            <h1><%=Languages.LanguageStrings.SelectPaymentMethod %></h1>

            <p><%=Languages.LanguageStrings.SelectPaymentMethodDescription %></p>

            <uc1:OrderSummary ID="OrderSummary1" runat="server" />

            <p><%=Languages.LanguageStrings.CheckoutDescription %></p>

            <p><strong><%=Languages.LanguageStrings.ChoosePaymentMethod %></strong>.</p>
            <div id="dCreditCard" runat="server" class="left">
                <p><input id="rbCreditCard" runat="server" type="radio" name="PaymentType"
                        value="rbCreditCard" style="margin-right: 10px;" /><%=Languages.LanguageStrings.CreditDebitCard %>
                <uc2:CreditCardPaymentControl ID="CreditCardPaymentControl1" runat="server" />
            </div>
            <div id="dOtherPayments" runat="server" class="right" style="width:370px; margin-left: 10px; margin-top: 40px;">
                <p id="pPaypoint" runat="server">
                    <input id="rbPaypoint" runat="server" type="radio" name="PaymentType"
                        value="rbPaypoint" />
                    <img src="/Images/Cart/Paypoint.png" alt="Instant online payments using Paypoint" border="0" align="middle" /><br />
                    <%=Languages.LanguageStrings.PayByPaypoint %>
                </p>

                <p id="pPaypal" runat="server">
                    <input id="rbPaypal" runat="server" type="radio" name="PaymentType" value="rbPaypal" />
                    <img src="/Images/Cart/Paypal2.png" align="middle" alt="Instant online payment using Paypal" /><br />
                    <%=Languages.LanguageStrings.PayByPaypal %>
                </p>
                <p id="pTelephone" runat="server">
                    <input id="rbCreditCardPhone" runat="server" type="radio" name="PaymentType" value="rbCreditCardPhone" />
                    <img src="/Images/Cart/paybyphone.jpg" align="middle" alt="Pay by Phone" />
                    <span><%=Languages.LanguageStrings.Telephone %> &nbsp;<br /> <%=GetWebsiteTelephoneNumber() %></span><br />
                    <%=Languages.LanguageStrings.PayOnPhone %>
                </p>

                <p id="pPayByCheque" runat="server">
                    <input id="rbCheque" runat="server" type="radio" name="PaymentType" value="rbCheque" />
                    <img src="/Images/Cart/cheque_postal.PNG" align="middle" alt="Pay by Cheque" /><br />
                    <%=Languages.LanguageStrings.ChequePostalOrder %>
                </p>

                <p id="pPayByCashOnDelivery" runat="server">
                    <input id="rbCOD" runat="server" type="radio" name="PaymentType" value="rbCOD" />
                    <img src="/Images/Cart/CashOnDelivery.PNG" align="middle" alt="Cash On Delivery" /><br />
                    <%=Languages.LanguageStrings.CashOnDeliveryDescription %>
                </p>

                <p id="pPayByDirectBankTransfer" runat="server">
                    <input id="rbDBT" runat="server" type="radio" name="PaymentType" value="rbDBT" />
                    <img src="/Images/Cart/DirectBankTransfer.PNG" align="middle" alt="Direct Bank Transfer" /><br />
                    <%=Languages.LanguageStrings.DirectBankTransferDescription %>
                </p>
            </div>

            <p>
                <strong><%=Languages.LanguageStrings.Notes %></strong> (<%=Languages.LanguageStrings.FreeOffers %>)<br />
                <asp:TextBox ID="txtNotes" runat="server" MaxLength="999" TextMode="MultiLine"
                    Height="120px" Width="80%"></asp:TextBox>
            </p>

            <div class="content form right">
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm Order"
                    OnClick="btnConfirm_Click" />
            </div>
        </div>
        <!-- end of #mainContent -->

        <div class="clear">
            <!-- clear -->
        </div>

    </div>
    <!-- end of #content -->
</asp:Content>
