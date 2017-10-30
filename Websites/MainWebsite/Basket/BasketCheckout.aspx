<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="BasketCheckout.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Basket.BasketCheckout" %>

<%@ Register Src="~/Controls/CreditCardPaymentControl.ascx" TagName="CreditCardPaymentControl" TagPrefix="uc2" %>

<%@ Register src="~/Controls/OrderSummary.ascx" tagname="OrderSummary" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.ConfirmOrder %> - <%=Languages.LanguageStrings.YourShoppingBag %> - <%=GetWebTitle()%></title>
    <link property="stylesheet" rel="Stylesheet" href="/css/Basket.css" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">
        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Basket/Basket.aspx"><%=Languages.LanguageStrings.HeavenShoppingBag %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Basket/BasketDeliveryAddress.aspx"><%=Languages.LanguageStrings.DeliveryAddress %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Basket/BasketCheckout.aspx"><%=Languages.LanguageStrings.ConfirmOrder %></a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->

        <div class="mainContent" style="float: left;">
            <h1><%=Languages.LanguageStrings.SelectPaymentMethod %></h1>

            <div class="orderPayment">
                <p><%=Languages.LanguageStrings.SelectPaymentMethodDescription %></p>

                <uc1:OrderSummary ID="OrderSummary1" runat="server" />

                <p><%=Languages.LanguageStrings.CheckoutDescription %></p>

                <p><strong><%=Languages.LanguageStrings.ChoosePaymentMethod %></strong>.</p>
                <div id="dCreditCard" runat="server" class="left">
                        <input id="rbCreditCard" runat="server" type="radio" name="PaymentType"
                            value="rbCreditCard" style="margin-right: 10px;" /><%=Languages.LanguageStrings.CreditDebitCard %>
                        <uc2:CreditCardPaymentControl ID="CreditCardPaymentControl1" runat="server" />
                </div>
                <div id="dOtherPayments" runat="server" class="right" style="width: 370px; margin-left: 10px; margin-top: 40px;">
                    <p id="pPaypoint" runat="server">
                        <input id="rbPaypoint" runat="server" type="radio" name="PaymentType"
                            value="rbPaypoint" />
                        <img src="/Images/Cart/Paypoint.png" alt="Instant online payments using Paypoint" border="0" align="middle" /><br />
                        <%=Languages.LanguageStrings.PayByPaypoint %>
                    </p>

                    <p id="pPaypal" runat="server">
                        <input id="rbPaypal" runat="server" type="radio" name="PaymentType" value="rbPaypal" />
                        <img src="/Images/Cart/Paypal2.png" align="middle" alt="Instant online payment using Paypal" /><br />
                        <span id="spPayPalDescription" runat="server"></span>
                    </p>
                    <p id="pTelephone" runat="server">
                        <input id="rbCreditCardPhone" runat="server" type="radio" name="PaymentType" value="rbCreditCardPhone" />
                        <img src="/Images/Cart/paybyphone.jpg" align="middle" alt="Pay by Phone" />
                        <span><%=Languages.LanguageStrings.Telephone %> &nbsp;<br />
                            <%=GetWebsiteTelephoneNumber() %></span><br />
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
                        <span id="spCODDescription" runat="server"></span>
                    </p>

                    <p id="pPayByDirectBankTransfer" runat="server">
                        <input id="rbDBT" runat="server" type="radio" name="PaymentType" value="rbDBT" />
                        <img src="/Images/Cart/DirectBankTransfer.PNG" align="middle" alt="Direct Bank Transfer" /><br />
                        <span id="spDBTDescription" runat="server"></span>
                    </p>

                    <p id="pSunTechWebATM" runat="server">
                        <input id="rbWebATM" runat="server" type="radio" name="PaymentType" value="rbWebATM" />
                        <img src="/Images/Cart/WebATM.PNG" align="middle" alt="SunTech WebATM" /><br />
                       <!-- <%=Languages.LanguageStrings.DirectBankTransferDescription %> -->
                    </p>

                    <p id="pSunTech24Payment" runat="server">
                        <input id="rb24Payment" runat="server" type="radio" name="PaymentType" value="rb24Payment" />
                        <img src="/Images/Cart/24Payment.PNG" align="middle" alt="SunTech 24Payment" /><br />
                       <!-- <%=Languages.LanguageStrings.DirectBankTransferDescription %> -->
                    </p>

                    <p id="pSunTechBuySafe" runat="server">
                        <input id="rbBuySafe" runat="server" type="radio" name="PaymentType" value="rbBuySafe" />
                        <img src="/Images/Cart/BuySafe.PNG" align="middle" alt="SunTech BuySafe" /><br />
                       <!-- <%=Languages.LanguageStrings.DirectBankTransferDescription %> -->
                    </p>

                    <p id="pTestPurchase" runat="server">
                        <input id="rbTestPurchase" runat="server" type="radio" name="PaymentType" value="rbTestPurchase" />
                        This is a test purchase only, the purchase will succeed but will be cancelled automatically
                        after 24 hours.                       
                    </p>
                </div>

                <div class="content form left">
                    <p>
                        <strong><%=Languages.LanguageStrings.Notes %></strong> <span id="spFreeOffers" runat="server">(<%=Languages.LanguageStrings.FreeOffers %>)</span><br />
                        <asp:TextBox ID="txtNotes" runat="server" MaxLength="999" TextMode="MultiLine"
                            Height="120px" Width="450px"></asp:TextBox>
                    </p>
                    <asp:Button ID="btnConfirm" style="float:left;" runat="server" Text="Confirm Order"
                        OnClick="btnConfirm_Click" />
                </div>
            </div>

            
        </div>
        <!-- end of #mainContent -->

        <div class="clear">
            <!-- clear -->
        </div>

    </div>
    <!-- end of #content -->
</asp:Content>
