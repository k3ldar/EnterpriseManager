<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Home" %>

<%@ Register Src="~/Controls/MediaLinks.ascx" TagName="MediaLinks" TagPrefix="uc1" %>
<%@ Register Src="Controls/ProductScroller.ascx" TagName="ProductScroller" TagPrefix="uc2" %>

<!DOCTYPE html>

<html>
<head>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
    <meta name="Keywords" content="<%=GetMetaKeyWords()%>" />

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title><%=GetWebTitle()%></title>
</head>
<body>
    <%=GetStyleSheet() %>
    <link property="stylesheet" rel="stylesheet" href="/css/nivo-slider.css" type="text/css" media="screen" />
    <link property="stylesheet" rel="Stylesheet" href="/css/heaventags.css" type="text/css" media="screen" />
    <link property="stylesheet" rel="stylesheet" type="text/css" href="/css/dd.css" />

    <script type="text/javascript" src="/js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="/js/jquery.hoverIntent.minified.js"></script>

    <script type="text/javascript" src="/js/jquery.jcarousel.min.js"></script>
    <script type="text/javascript" src="/js/jquery.nivo.slider.pack.js"></script>

    <script type="text/javascript" src="/js/jquery.dd.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            p = navigator.platform;

            if (p === 'iPad' || p === 'iPhone' || p === 'iPod') {
                $("div.selectCountry").each(function () {
                    var onClick; // this will be a function
                    var firstClick = function () {
                        onClick = secondClick;
                        return false;
                    };
                    var secondClick = function () {
                        onClick = firstClick;
                        return true;
                    };
                    onClick = firstClick;
                    $(this).click(function () {
                        return onClick();
                    });
                });
            }
        });
</script>
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
      m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-45181427-1', 'heavenskincare.com');
        ga('send', 'pageview');

    </script>

    <script type="text/javascript">
        $(window).load(function () {
            $('.slider').nivoSlider({
                animSpeed: 500,
                directionNav: false,
                effect: 'fade',
                pauseTime: 6000
            });
        });

        jQuery(document).ready(function () {
            var scrollCount = <%=GetScrollCount()%>; 
            jQuery('.mycarousel').jcarousel({
                scroll: scrollCount,
                wrap: "circular", auto: 10
            });
        });


        function clickclear(thisfield) {
            var defaulttext = '<%=GetSearchString()%>';

            if (thisfield.value == defaulttext) {
                thisfield.value = "";
            }
        }
        function clickrecall(thisfield) {
            var defaulttext = '<%=GetSearchString()%>';

            if (thisfield.value == "") {
                thisfield.value = defaulttext;
            }
        }
    </script>

    <form id="frmIndex" runat="server">
        <div class="wrapper">

            <!-- Header Start -->
            <div class="header">
                <a href="<%=BaseURL()%>/Home.aspx" title="Heaven by Deborah Mitchell" class="logo">Heaven by Deborah Mitchell</a>

                <div class="rightContainer" style="width:190px;">
                    <div class="socialMedia" style="float:right;">
                        <!--<h6><%=Languages.LanguageStrings.FollowDeborah %></h6>-->
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

                    <div class="frm_search" style="float:right;">
                        <asp:TextBox ID="txtSearchTerms" runat="server" Style="width: 123px;" onblur="clickrecall(this)" onclick="clickclear(this)"></asp:TextBox>
                        <input type="image" src="/images/search.gif" alt="s" runat="server" id="btnSearch" />
                    </div>
                </div>

                <!-- end of #actions -->
                <div class="clear">
                    <!-- clear -->
                </div>
            </div>
            <!-- end of #header -->

            <!--  Navigation Menu   -->
            <div class="navigation">
                <div class="menuBorder leftMenu" style="border-bottom: none">
                </div>
                <img src="/images/Heaven-Circle-logo.png" alt="I" />

                <div class="menuBorder rightMenu" style="border-bottom: none">
                    <ul>
                    </ul>
                    <div class="clear">
                        <!-- clear -->
                    </div>
                </div>
            </div>
            <!-- end of Navigation Menu -->

            <h1 class="tagLineHome" id="divTagLine" runat="server" style="width:100%;"></h1>

            <!-- Header End -->


            <!-- Main Content -->
            <div class="content">
                <div class="homeBanner">
                    <img src="/images/BVM-silver-Mont.png" alt="I" />
                    <div class="countrySelection">
                        <span><a href="/index.aspx">International</a></span>
                        <ul>
                            <li>America
                                    <ul>
                                        <%=GetDistributorCountries("Americas")%>
                                    </ul>
                            </li>
                            <li>Asia
                                    <ul>
                                        <%=GetDistributorCountries("Asia")%>
                                    </ul>
                            </li>
                            <li>Europe
                                    <ul>
                                        <%=GetDistributorCountries("Europe")%>
                                    </ul>
                            </li>
                            <li>Middle East
                                    <ul>
                                        <%=GetDistributorCountries("Middle East")%>
                                    </ul>
                            </li>
                            <li>Australia
                                    <ul>
                                        <%=GetDistributorCountries("Australia")%>
                                    </ul>
                            </li>
                        </ul>
                    </div>
                    <div class="homeBannerDescription">
                        <img src="/images/Tall-box.png" alt="I" />
                        <p>
                            <br />
                            <span>Bee Venom Mask</span><br />
                            <br />
                            I invented Abeetoxin® to make my face look younger,<br />
                            <br />
                            I did not want to use Botox, so I developed Bee Venom / ABEETOXIN® as a natural alternative to the invasive injectable botulism&#8221;.
                        </p>
                    </div>
                </div>

                <uc2:ProductScroller ID="ProductScroller1" runat="server" VisibleProductCount="4" ShowBest="false" Clickable="true" ShowNew="false" ShowHeader="false" ShowPrices="false" CenterText="true" />
                <uc1:MediaLinks ID="MediaLinks1" runat="server" class="CenteredDiv" />

            </div>
            <!-- end of #content -->
            <!-- Main Content End -->
        </div>

        <!-- End of Wrapper -->


        <!-- Footer -->
        <div class="footer png_bg">
            <!--<h6><%=Languages.LanguageStrings.ContactUs %></h6>-->
            <p><%=WebsitePostalAddress() %></p>
            <p>
                <a href="mailto:<%=WebsiteEmailAddress() %>"><%=WebsiteEmailAddress() %></a> - 
                <a href="<%=BaseURL()%>/ContactUs.aspx"><%=Languages.LanguageStrings.ContactUs %></a> - 
                <a href="<%=BaseURL()%>/About.aspx"><%=Languages.LanguageStrings.AboutUs %></a>
            </p>
            <p>&copy; Copyright 2011 - <%=CurrentYear() %> Heaven Health &amp; Beauty Ltd. All rights reserved. Heaven Health & Beauty Ltd. Registered in England No. 3095876</p>
        </div>
        <!-- Footer -->
    </form>
</body>
</html>
