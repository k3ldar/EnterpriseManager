<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="BasketOrderComplete.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Basket.BasketOrderComplete" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.OrderComplete %> - <%=Languages.LanguageStrings.HeavenShoppingBag %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<!-- Google Code for Sale Conversion Page -->
<script type="text/javascript">
    /* <![CDATA[ */
    var google_conversion_id = 975251604;
    var google_conversion_language = "en";
    var google_conversion_format = "2";
    var google_conversion_color = "ffffff";
    var google_conversion_label = "KY7zCMy2tQgQlNGE0QM";
    var google_conversion_value = 0;
    var google_remarketing_only = false;
    /* ]]> */
</script>
<script type="text/javascript" src="//www.googleadservices.com/pagead/conversion.js">
</script>
<noscript>
<div style="display:inline;">
<img height="1" width="1" style="border-style:none;" alt="" src="//www.googleadservices.com/pagead/conversion/975251604/?value=0&amp;label=KY7zCMy2tQgQlNGE0QM&amp;guid=ON&amp;script=0"/>
</div>
</noscript>

        <div class="content">
		
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
    			<h1 id="hHeader" runat="server"><%#Languages.LanguageStrings.OrderComplete %></h1>

                <h3 id="hInvoice" runat="server" class="content form">
                    <%#Languages.LanguageStrings.Invoice %>
                </h3>

                <p id="pPaypal" runat="server" class="content form">
                       
                </p>

                <p id="pCheque" runat="server" class="content form">

                </p>

                <p id="pTelephone" runat="server" class="content form">
                        
                </p>

                <p id="pCashOnDelivery" runat="server" class="content form">
                        
                </p>

                <p id="pDirectTransfer" runat="server" class="content form">
                        
                </p>

                <p id="pTestPurchase" runat="server" class="content form">
                    This is a test purchase only and the invoice will be automatically cancelled within 24 hours.
                </p>

                <p class="content form"><strong><%#Languages.LanguageStrings.QuoteOrderNumber %></strong></p>
                <p id="pPostalAddress" runat="server" class="content form">
                        
                </p>

                <p><a href="/Members/Orders.aspx"><%=Languages.LanguageStrings.ClickToTrackOrder %></a></p>
            </div><!-- end of #mainContent -->

            <div class="clear"><!-- clear --></div>

		</div><!-- end of #content -->
</asp:Content>
