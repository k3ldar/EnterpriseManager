<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerTooBusy.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Error.ServerTooBusy" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="Description" content="Effective facial and body treatments that will give immediate results to the skin as well as ones well being by means of using the bodies own electricity. Heaven Skin Care for healthy skin, mind, body and soul." />
    <meta name="Keywords" content="Heaven Skincare Beauty Treatments  Victoria Beckham, Kylie Minogue, Michelle Phieffer, Cat Deelie, Patsy Kensit, Telford, Deborah Mitchell, Healthy Skin, Natural, Organic, Health Treatment, Bee Venom, Bee Venom Mask, Heaven, Deborah, Mitchell, Skin, Natural, Organic, Health, Care, Beauty, Slimming, LIA, Facial, Moisturiser, Essential Oils, Cleanser, Anti Ageing, Acne, Therapy, Healing, Relaxation, Massage, Body, Holistic, Pedicure, Manicure" />

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rel="stylesheet" href="/css/style3.css" type="text/css" media="screen" />

    <script type="text/javascript" src="/js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="/js/jquery.hoverIntent.minified.js"></script>

    <script type="text/javascript" src="/js/jquery.jcarousel.min.js"></script>
    <script type="text/javascript" src="/js/jquery.nivo.slider.pack.js"></script>

    <link rel="stylesheet" type="text/css" href="/css/dd.css" />
    <script type="text/javascript" src="/js/jquery.dd.js"></script>

    <!-- Script is used to call the JQuery for dropdown -->
    <title>Server too busy - Heaven Health & Beauty Ltd - Heaven Skin Care for healthy skin, mind, body and soul.</title>
    <script type="text/javascript">setTimeout(function () { window.location.href = '/Index.aspx' }, 60000);</script>
</head>
<body>
        <div class="wrapper">

            <!-- Header Start -->
            <div class="header">
                <a href="/Index.aspx" title="Heaven by Deborah Mitchell" class="logo">Heaven by Deborah Mitchell</a>

                <div class="socialMedia">
                    <!--<h6>Follow Deborah</h6>-->
                    <ul>
                        <li id="socialFB">
                            <a href="http://www.facebook.com/heavenskincare" target="_blank">
                                <img src="/images/fb.jpg" alt="Join Deborah on Facebook" />
                            </a>
                        </li>
                        <li id="socialTwitter">
                            <a href="https://twitter.com/#!/heavenskincare" target="_blank">
                                <img src="/images/twitter.jpg" alt="Join Deborah on Twitter" />
                            </a>
                        </li>
                        <li id="socialGPlus">
                            <a href="https://plus.google.com/u/0/+DeborahMitchellheaven/posts" target="_blank">
                                <img src="/images/googleplus.jpg" alt="Join Deborah on Twitter" />
                            </a>
                        </li>
                        <li id="socialRSS">
                            <a href="http://heavenbydeborahmitchell.me/feed/" target="_blank">
                                <img src="/images/rss-blog.jpg" alt="Subscribe to our Blog" />
                            </a>
                        </li>
                    </ul>
                </div>

                <!-- end of #actions -->
                <div class="clear">
                    <!-- clear -->
                </div>
            </div>
            <!-- end of #header -->

            <!-- Header End -->
            <!-- Main Content -->
            <div class="content">
                <div class="homeBanner">
                    <img src="/images/BVM-silver-Mont.png" alt="" />
                    <div class="countrySelection">
                        <ul>
                            <li style="line-height:2.0em; width: 600px;">
                                We are really sorry, we are experiencing unprecedented amount of visitors just now and are unable to service your request.
                            </li>
                            <li style="line-height:2.0em; width: 600px;">We will attempt to automatically connect you in 1 minute.</li>
                            <li style="line-height:2.0em; width: 600px;">
                                Please call our office on <%=TelephoneNumber() %> to place an order or check back later.
                            </li>
                        </ul>
                    </div>
                    <div class="homeBannerDescription">
                        <img src="/images/Tall-box.png" alt="" />
                        <p>
                            <br />
                            <span>bee venom</span><br />
                            mask<br />
                            <br />
                            I invented abeetoxin to make my face look younger<br />
                            <br />
                            I did not want to use Botox, so I developed bee venom/abeetoxin as a natural alternative to the invasive injectable botulism
                        </p>
                    </div>
                </div>
                <div id="fb-root"></div>
            </div>
            <!-- end of #content -->
            <!-- Main Content End -->
        </div>

        <!-- End of Wrapper -->
        <!-- Footer -->
        <div class="footer png_bg">
            <!--<h6>Contact Us</h6>-->
            <p>Heaven Health & Beauty Ltd 13a Market Place, Shifnal, Shropshire, TF11 9AU</p>
            <p>
                <a href="mailto:<%=Email() %>"><%=Email() %></a> 
            </p>
            <p>&copy; Copyright 2011 - 2017 Heaven Health &amp; Beauty Ltd. All rights reserved. Heaven Health & Beauty Ltd. Registered in England No. 3095876</p>
        </div>
        <!-- Footer -->
</body>
</html>
