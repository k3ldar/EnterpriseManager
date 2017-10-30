<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ChristmasGiftSets.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Products.ChristmasGiftSets" %>

<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controls/BuyItNow.ascx" TagName="BuyItNow" TagPrefix="uc2" %>
<%@ Register src="~/Controls/MediaLinks.ascx" tagname="MediaLinks" tagprefix="uc3" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Heavenly Christmas Gift Sets </title>
    <link rel="stylesheet" href="/css/BuyItNow.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="/css/xmas.css" type="text/css" media="screen" />
    <!-- required snowstorm JS, default behaviour -->
    <!--<script type="text/jscript" src="/js/snowstorm.js"></script>
    <!-- now, we'll customize the snowStorm object 
    <script type="text/javascript">
        snowStorm.snowColor = '#99ccff'; // blue-ish snow!?
        snowStorm.useTwinkleEffect = false; // let the snow flicker in and out of view
        snowStorm.snowStick = true;
        snowStorm.useMeltEffect = true;
        snowStorm.flakesMaxActive = 60;
        snowStorm.excludeMobile = false;
        snowStorm.randomizeWind();
    </script>-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">
        <div class="breadcrumb">
            <ul class="fixed">
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/Products.aspx">Products</a></li>
                <li>&rsaquo;</li>
                <li><a href="/Products/ChristmasGiftSets.aspx">Heavenly Christmas Gift Sets</a></li>
            </ul>
        </div>
        <!-- end of #breadcrumb -->
        <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" ShowCampaign="false" />
        <div class="binMainContent">
            <div class="binProductDescription binImage">
                <img src="/Images/Offers/xmas/salon.jpg" border="0" align="right" alt="" />
            </div>
            <h1>
                Heavenly Christmas Gift Sets</h1>
            <h4>
                give a heavenly gift set this christmas</h4>
            <p class="binProductDescription">
                It is that time of year when the magic starts to happen, the twinkling lights get brighter and the nights get darker,the air outside becomes crisp, and this year having a Heaven Christmas is even more special because we have a whole new stratosphere range to bring you festive cheer!
            </p>
            <p class="binProductDescription">
                We have luxury gifts for everyone on your Christmas list, from beautifully crafted scented candles to set the mood, to his and hers skin care sets that are out of this world, for the perfect Christmas glow and heavenly holiday!
            </p>
            <p class="binProductDescription">
                Also this year why not have a Heaven bespoke gift, choose what you want in the set and we will send you Heaven branded gift boxes and ribbon along with a special little something just for you from Heaven (just give us a hint so we can choose your Heaven Surprise!)
            </p>
            <p class="binProductDescription">
                Lets us send your Christmas experience into the Stratosphere!
            </p>
                <uc2:BuyItNow ID="BuyItNow1" runat="server" Image="/Images/Stratosphere/xmas-gift-set1_148.jpg"  PriceFontColour="#0000FF"
                Contains="Contains: 30ml Silver Bee Venom Mask, 15ml Black Age Defiance, 15ml Black Heavenly Eyes." ProductID="1740" />

                <uc2:BuyItNow ID="BuyItNow2" runat="server" Image="/Images/Stratosphere/xmas-gift-set2_148.jpg"  PriceFontColour="#0000FF"
                Contains="Contains: 200ml Close Shave, 100ml Aftershave relief  spray,50ml Aftershave Balm, 15ml O2 Eye Cream, 30ml SOS Oil."
                ProductID="1741" />

                <uc2:BuyItNow ID="BuyItNow3" runat="server" Image="/Images/Stratosphere/xmas-gift-set3_148.jpg"  PriceFontColour="#0000FF"
                Contains="Contains: 60ml   Black Bee Venom Mask, 15ml Black Age Defiance Cream, 50ml Vanilla Pod Hand & Face Cream."
                ProductID="1742" />

                <uc2:BuyItNow ID="BuyItNow4" runat="server" Image="/Images/Stratosphere/xmas-gift-set4_148.jpg"  PriceFontColour="#0000FF"
                Contains="Contains: 60ml   Black Bee Venom Mask, Black Label 15ml Heavenly Eyes, 15ml Black Age defiance."
                ProductID="1743" />

                <uc2:BuyItNow ID="BuyItNow5" runat="server" Image="/Images/Stratosphere/xmas-gift-set5_148.jpg"  PriceFontColour="#0000FF"
                Contains="Contains: 50ml Black Overnight Success, 60ml Black Bee Venom Mask, 15ml Heavenly Eyes."
                ProductID="1774" />


                <uc2:BuyItNow ID="BuyItNow6" runat="server" Image="/Images/Stratosphere/xmas-gift-set6_148.jpg"  PriceFontColour="#0000FF"
                Contains="Contains: 30ml B Polish, 30ml Youthful Moisturiser, 1 pack Ellajane Facial Wipes."
                ProductID="1775" />

                <uc2:BuyItNow ID="BuyItNow7" runat="server" Image="/Images/Stratosphere/xmas-gift-set7_148.jpg"  PriceFontColour="#0000FF"
                Contains="Contains: 30ml   Silver Bee Venom Mask, 15ml Black Age Defiance, 5ml Formula B Eyes."
                ProductID="1748" />

                <uc2:BuyItNow ID="BuyItNow8" runat="server" Image="/Images/Stratosphere/xmas-gift-set8_148.jpg"  PriceFontColour="#0000FF"
                Contains="Contains: 30ml  New limited edition, 30ml B Polish, 30ml Chamomile Hydro-gel."
                ProductID="1749" />

                <uc2:BuyItNow ID="BuyItNow9" runat="server" Image="/Images/Stratosphere/xmas-gift-set9_148.jpg"  PriceFontColour="#0000FF"
                Contains="10ml Orange Flower Hydro-gel, 10ml Bee Polish, 10ml Hydro cleanser, 15ml Age Defiance."
                ProductID="1987" />

                <uc2:BuyItNow ID="BuyItNow14" runat="server" Image="/Images/Stratosphere/xmas-gift-set9_148.jpg"  PriceFontColour="#0000FF"
                Contains="10ml Chamomile Hydro-gel, 10ml Hydro Cleanser, 10ml Bee Polish, 5ml Age Defiance."
                ProductID="1988" />

                <uc2:BuyItNow ID="BuyItNow15" runat="server" Image="/Images/Stratosphere/xmas-gift-set9_148.jpg"  PriceFontColour="#0000FF"
                Contains="5ml Bee Venom Mask, 5ml Age Defiance, 10ml Chamomile Hydro-gel, 10ml New Limited Edition."
                ProductID="1990" />

                <uc2:BuyItNow ID="BuyItNow16" runat="server" Image="/Images/Stratosphere/xmas-gift-set9_148.jpg"  PriceFontColour="#0000FF"
                Contains="10ml Hydro Cleanser, 10ml Chamomile Hydro-gel, 5ml Divine Cream, 5ml Bee Venom Mask."
                ProductID="1991" />

                <uc2:BuyItNow ID="BuyItNow17" runat="server" Image="/Images/Stratosphere/xmas-gift-set9_148.jpg"  PriceFontColour="#0000FF"
                Contains="10ml Hydro Cleanser, 10ml Youthful Moisturiser, 10ml Peppermint Hydro-gel, 10ml Bee Polish."
                ProductID="1976" />

                <uc2:BuyItNow ID="BuyItNow18" runat="server" Image="/Images/Stratosphere/xmas-gift-set9_148.jpg"  PriceFontColour="#0000FF"
                Contains="10ml Chamomile Hydro-gel, 10ml Ltd Edition, 10ml Bee Polish, 5ml Age Defiance."
                ProductID="1989" />

                <uc2:BuyItNow ID="BuyItNow19" runat="server" Image="/Images/Stratosphere/xmas-gift-set9_148.jpg"  PriceFontColour="#0000FF"
                Contains="10ml Bee Polish, 10ml Peppermint Hydro-gel, 10ml Cleanse & Foam, 5ml Age Defiance."
                ProductID="1992" />

                <uc2:BuyItNow ID="BuyItNow20" runat="server" Image="/Images/Stratosphere/xmas-gift-set9_148.jpg"  PriceFontColour="#0000FF"
                Contains="10ml Hydro cleanser, 10ml Bee polish, 10ml Chamomile  Hydro-gel, 15ml Age Defiance."
                ProductID="1993" />

                <uc2:BuyItNow ID="BuyItNow11" runat="server" Image="/Images/Stratosphere/xmas-gift-set10_148.jpg"  PriceFontColour="#0000FF"
                Contains="Contains: Heaven Diffuser - Ode."
                ProductID="1754" />

                <uc2:BuyItNow ID="BuyItNow12" runat="server" Image="/Images/Stratosphere/xmas-gift-set11_148.jpg"  PriceFontColour="#0000FF"
                Contains="Contains: 4 Wick Heaven Candle, Ode."
                ProductID="1766" />

                <uc2:BuyItNow ID="BuyItNow21" runat="server" Image="/Images/Stratosphere/xmas-gift-set12_148.jpg"  PriceFontColour="#0000FF"
                Contains="Contains: 3 Wick Heaven Candle, Ode."
                ProductID="1767" />

                <uc2:BuyItNow ID="BuyItNow13" runat="server" Image="/Images/Stratosphere/xmas-gift-set13_148.jpg"  PriceFontColour="#0000FF"
                Contains="Contains: 1 Wick Candle 30cl, Ode."
                ProductID="1769" />

                <uc2:BuyItNow ID="BuyItNow10" runat="server" Image="/Images/Stratosphere/xmas-gift-set14_148.jpg"  PriceFontColour="#0000FF"
                Contains="Contains: 1 Wick Candle 30cl, Ode & Heaven Scent."
                ProductID="1996" />

            <p class="binProductDescription binAbsolute">
                
Please note that due to high demand and production time, the scented candles and luxury soaps will be delivered at the end of November. 
You can however pre-order them now.</p>

<uc3:MediaLinks ID="MediaLinks1" runat="server"  />
			    <uc2:WebPageTags ID="WebPageTags1" runat="server" />

            <div class="clear">
                <!-- clear -->
            </div>
        </div>
        <!-- end of #mainContent -->
        <div class="clear">
            <!-- clear -->
        </div>
    </div>
    <!-- end of #content -->
</asp:Content>
