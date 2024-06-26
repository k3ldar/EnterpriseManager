﻿<%@ Page Title="" Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Christmas.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Offers.Christmas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/BuyItNow.ascx" TagName="BuyItNow" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/MediaLinks.ascx" TagName="MediaLinks" TagPrefix="uc3" %>
<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>

<%@ Register src="~/Controls/CountryLanguageSelect.ascx" tagname="CountryLanguageSelect" tagprefix="uc1" %>

<%@ Register src="~/Controls/SeoPagePopup.ascx" tagname="SeoPagePopup" tagprefix="uc2" %>


<!DOCTYPE html>

<html>
<head id="head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <%#GetStyleSheet() %>

    <meta name="Description" content="<%#GetMetaDescription()%>" />
    <meta name="Keywords" content="<%#GetMetaKeyWords()%>" />
    
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <script type="text/javascript">if(top.location != window.location) {window.top.location.href='<%#GetURL() %>';}</script>

    <title>Christmas Offers</title>
</head>
<body>
    <script type="text/javascript" src="/js/jquery-1.7.1.min.js"></script>
    <asp:ScriptManager ID="ScriptManager2" runat="server"   ScriptMode="Release"></asp:ScriptManager>
    <form id="frmIndex" runat="server">
        <div class="wrapper">

            <!-- Header Start -->
            <div class="header">
                <a href="/Index.aspx" title="Heaven by Deborah Mitchell" class="logo">Heaven by Deborah Mitchell</a>

                <div class="rightContainer">
                    <uc1:CountryLanguageSelect ID="CountryLanguageSelect1" runat="server" ShowFlags="false" ShowLanguageSelector="false" />
                    <div class="socialMedia">
                        <ul>
                            <li id="socialFB" runat="server"><a href="<%=Heavenskincare.WebsiteTemplate.Global.SocialMediaFacebook %>" target="_blank">
                                <img src="/images/Offers/xmas-16/FB-purple.png" alt="<%=Languages.LanguageStrings.JoinUsOnFacebook %>" /></a></li>
                            <li id="socialTwitter" runat="server"><a href="<%=Heavenskincare.WebsiteTemplate.Global.SocialMediaTwitter %>" target="_blank">
                                <img src="/images/Offers/xmas-16/twitter-purple.png" alt="<%=Languages.LanguageStrings.JoinUsOnTwitter %>" /></a></li>
                            <li id="socialGPlus" runat="server"><a href="<%=Heavenskincare.WebsiteTemplate.Global.SocialMediaGPlus %>" target="_blank">
                                <img src="/images/Offers/xmas-16/gp-purple.png" alt="<%=Languages.LanguageStrings.JoinUsOnTwitter %>" /></a></li>
                            <li id="socialRSS" runat="server"><a href="<%=Heavenskincare.WebsiteTemplate.Global.SocialMediaRSSFeed %>" target="_blank">
                                <img src="/images/Offers/xmas-16/rss-blog-purple.png" alt="<%=Languages.LanguageStrings.SubscribeToOurBlog %>" /></a></li>
                        </ul>
                    </div>

                    <div class="frm_search">
                        <asp:TextBox ID="txtSearchTerms" runat="server" onblur="clickrecall(this)" onclick="clickclear(this)"></asp:TextBox>
                        <input type="image" src="/images/search.gif" alt="s" runat="server" id="btnSearch" />
                    </div>

                    <div class="actions">
                        <p><a href="/Members/Index.aspx"><%=Languages.LanguageStrings.MyAccount %></a> | <a href="/Helpdesk/Index.aspx"><%=Languages.LanguageStrings.Helpdesk %></a></p>
                        <div class="bag" id="divShoppingCart" runat="server">
                            <p><%=BasketInfo()%></p>
                            <a href="/Basket/Basket.aspx"><%=Languages.LanguageStrings.ViewShoppingBag %> &raquo;</a>
                            <span class="png_bg"></span>
                        </div>
                        <!-- end of #bag -->
                    </div>
                </div>
                <!-- end of #actions -->
                <div class="clear">
                    <!-- clear -->
                </div>
            </div>
            <!-- end of #header -->

            <div class="navigation">
                <div class="menuBorder leftMenu">
                    <ul id="topNav" class="topNav">
                        <!--<li class="current"><a href="/Index.aspx"><span class="png_bg"></span></a></li>-->
                        <li><a href="/Products.aspx"><%=Languages.LanguageStrings.Products %></a>

                            <div class="sub" id="subMenu">
                                <div class="cat">
                                    <h6 id="hCategories" runat="server"><%=Languages.LanguageStrings.Categories %></h6>
                                    <ul>
                                        <%=GetProductCategories(false, false)%>
                                    </ul>
                                </div>
                                <div class="prod">
                                    <h6><%=Languages.LanguageStrings.FeaturedProduct %></h6>
                                    <%=GetFeaturedProduct() %>
                                </div>
                                <div class="clear">
                                    <!-- clear -->
                                </div>
                            </div>
                        </li>
                        <%=ShowTreatments() %>
                        <%=ShowSalons() %>
                        <%=ShowDistributors() %>
                        <!--<li><a href="https://www.heavenskincare.com/Home.aspx"><img src="/images/Heaven-Circle-logo.png" alt="Heaven Home" /></a></li>-->
                        <%=ShowTipsAndTricks() %>
                        <li><a href="/Trade.aspx"><%=Languages.LanguageStrings.Trade %></a></li>
                        <li><a href="/Video/Index.aspx"><%=Languages.LanguageStrings.Videos %></a></li>
                        <li><a href="/Helpdesk/Feedback.aspx"><%=Languages.LanguageStrings.Feedback %></a></li>
                        <li id="liSearch" runat="server"><a href="/search/searchresults.aspx" style="font-size:15px;"><%=Languages.LanguageStrings.Search %></a></li>
                        <li id="liMobileNavigator" runat="server" class="icon"><a href="javascript:void(0);" style="width:43px;height:43px;padding: 0px;position: fixed;" onclick="openNavigation()"><img src="https://www.heavenskincare.com/images/mm.png" alt="&#9776;" style="width:43px; height:43px;padding:0px;text-align: left;" /></a></li>
                    </ul>
                </div>
            </div>
            <!-- end of #navigation -->

            <div class="tagLine" id="divTagLine" runat="server"></div>

            <!-- Header End -->


            <!-- Main Content -->
            <div class="content">
                <div class="breadcrumb">
                    <ul class="fixed">
                        <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                        <li>&rsaquo;</li>
                        <li>Offers</li>
                        <li>&rsaquo;</li>
                        <li><a href="/Offers/Christmas.aspx">Christmas Offers</a></li>
                    </ul>
                </div>
                <!-- end of #breadcrumb -->
                <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" ShowCampaign="false" />

                <div class="binMainContent">
                    <h1>Christmas Offers</h1>
                
                    <div id="divBuyItNowItems" runat="server">
                    </div>
                        
                    <div class="clear"></div>
                    <uc3:MediaLinks ID="MediaLinks1" runat="server" />
                    <uc2:WebPageTags ID="WebPageTags1" runat="server" />

                    <div class="clear">
                        <!-- clear -->
                    </div>
                </div>
                <!-- end of #mainContent -->

    <!-- End of Wrapper -->
        <!-- Main Content End -->
    </div>
            <div class="clear">
                <!-- clear -->
            </div>


            <!-- Footer -->
            <div class="footer png_bg">
                <p id="pMobileSite" runat="server">View Desktop Website</p>
                <!--<h6><%=Languages.LanguageStrings.ContactUs %></h6>-->
                <p><%=WebsitePostalAddress() %></p>
                <p id="pFooterDetails" runat="server">
                    <a href="mailto:<%=WebsiteEmailAddress() %>"><%=WebsiteEmailAddress() %></a> - 
                    <a href="/ContactUs.aspx"><%=Languages.LanguageStrings.ContactUs %></a> - 
                    <a href="/About.aspx"><%=Languages.LanguageStrings.AboutUs %></a>
                    <%=GetTermsAndConditions() %>
                    <%=GetPrivacyPolicy() %>
                    <%=GetReturnsPolicy() %>
                </p>
                <p>&copy; Copyright 2011 - <%=CurrentYear() %> Heaven Health &amp; Beauty Ltd. All rights reserved. Heaven Health & Beauty Ltd. Registered in England No. 3095876</p>
            </div>
            <!-- Footer -->
            <div class="clear">
                <!-- clear -->
            </div>

        <!-- end of #content -->
        </div>
    
        <script type="text/javascript" src="/js/jquery.hoverIntent.minified.js"></script>

        <script type="text/javascript" src="/js/jquery.jcarousel.min.js"></script>

        <script type="text/javascript" src="/js/jquery.nivo.slider.pack.js"></script>

        <script type="text/javascript">
            <%=GetGoogleAnalyticsCode()%>
        </script>

        <%=GetMobileOnlyScripts() %>

        <script type="text/javascript">
            $(window).load(function () { $('.slider').nivoSlider({ animSpeed: 500, directionNav: false, effect: 'fade', pauseTime: 6000 }); });
            jQuery(document).ready(function () {var scrollCount = <%=GetScrollCount()%>;  jQuery('.mycarousel').jcarousel({ scroll: scrollCount, wrap: "circular", auto: 10 }); });


            function clickclear(a) { var defaulttext = '<%=GetSearchString()%>'; if (a.value == defaulttext) { a.value = ""; }}
            function clickrecall(a) { var defaulttext = '<%=GetSearchString()%>'; if (a.value == "") {a.value = defaulttext;}}
        </script>
        <%=GetCookieConsent() %>

    </form>
    
    </body>
</html>
