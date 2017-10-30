<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mobile.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Mobile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html>
<head id="head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="Description" content="<%#GetMetaDescription()%>" />
    <meta name="Keywords" content="<%#GetMetaKeyWords()%>" />
    
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <link property="stylesheet" rel="stylesheet" href="/css/mi.css" type="text/css" media="screen" />
    <link property="stylesheet" rel="stylesheet" href="/css/combined_m.css" type="text/css" media="screen" />
    <script type="text/javascript" src="/js/jquery-1.7.1.min.js"></script>

    <asp:ScriptManager ID="ScriptManager2" runat="server" ScriptMode="Release"></asp:ScriptManager>
    <form id="frmIndex" runat="server">
        <div class="wrapper" id="divWrapper">

            <!-- Header Start -->
            <div class="header">
                <div class="leftContainer">
                    <div class="socialMedia">
                        <ul>
                            <li id="socialFB" runat="server"><a href="<%=Heavenskincare.WebsiteTemplate.Global.SocialMediaFacebook %>" target="_blank">
                                <img src="/images/fb.jpg" alt="<%=Languages.LanguageStrings.JoinUsOnFacebook %>" /></a></li>
                            <li id="socialTwitter" runat="server"><a href="<%=Heavenskincare.WebsiteTemplate.Global.SocialMediaTwitter %>" target="_blank">
                                <img src="/images/twitter.jpg" alt="<%=Languages.LanguageStrings.JoinUsOnTwitter %>" /></a></li>
                            <li id="socialGPlus" runat="server"><a href="<%=Heavenskincare.WebsiteTemplate.Global.SocialMediaGPlus %>" target="_blank">
                                <img src="/images/googleplus.jpg" alt="<%=Languages.LanguageStrings.JoinUsOnTwitter %>" /></a></li>
                            <li id="socialRSS" runat="server"><a href="<%=Heavenskincare.WebsiteTemplate.Global.SocialMediaRSSFeed %>" target="_blank">
                                <img src="/images/rss-blog.jpg" alt="<%=Languages.LanguageStrings.SubscribeToOurBlog %>" /></a></li>
                        </ul>
                    </div>

                    <div class="frm_search">
                        <asp:TextBox ID="txtSearchTerms" runat="server" onblur="clickrecall(this)" onclick="clickclear(this)"></asp:TextBox>
                        <input type="image" src="/images/search.gif" alt="s" runat="server" id="btnSearch" />
                    </div>
                </div>
                <div class="centerContainer">
                    <a href="/Mobile.aspx" title="Heaven by Deborah Mitchell"><img src="/images/Heaven-Circle-logo.png" alt="logo" /></a>
                </div>
                <div class="rightContainer">
                    <img src="https://www.heavenskincare.com/images/made-in-britain.png" border="0" alt="Made In Britain" />
                </div>
            </div>
            <!-- end of #header -->

            <div class="tagLine" id="divTagLine" runat="server"></div>

            <!-- Header End -->
            <div class="featureWrapper">
                <div class="feature">
				    <div class="slider-wrapper theme-default">
					    <div class="ribbon"></div>
					    <div class="slider nivoSlider">
                            <%=GetHomePageImages(300, 137)%>
					    </div>
				    </div>
			    </div>
            </div>
            <!-- end of #feature -->

        <div class="clear">
            <!-- clear -->
        </div>

        <!-- Menu Items --->
        <div class="menuOptions">
            <ul id="menuUL">
                <%=GetProductGroupsHome() %>
                <li class="Other"><a  href="/Products.aspx"><span><div class="fullHeight"><%=Languages.LanguageStrings.Products %></div></span></a></li>
                <li class="Other"><a  href="/Search/SearchResults.aspx"><span><div class="fullHeight"><%=Languages.LanguageStrings.Search %></div></span></a></li>
            </ul>
            <div class="clear">
                <!-- clear -->
            </div>
        </div>
        <!-- Menu Items --->

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
        </div>

        <!-- End of Wrapper -->
    </form>
    
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
</body>

</html>
