<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MayAlsoLike.ascx.cs" Inherits="SieraDelta.Website.Controls.MayAlsoLike" %>
<script type="text/javascript" src="/js/jquery.jcarousel.min.js"></script>
<div class="jcarousel-wrapper">
    <h2><%=Languages.LanguageStrings.YouMayAlsoLike %></h2>
    <div class="jcarousel">
        <ul class="mycarousel fixed">
            <%=GetCarouselProducts() %>
        </ul>
    </div>

    <div class="jcarousel-control-prev">&lsaquo;</div>
    <div class="jcarousel-control-next">&rsaquo;</div>
</div>
<script type="text/javascript">
    (function ($) {
        var scrollCount = '<%=GetScrollCount()%>'; 
        var scrollInterval = 1500;
        $('.jcarousel').jcarousel({
            vertical: false,
            wrap: 'circular',
            animation: {
                duration: 700,
                easing: 'linear'
            },
            transitions: true,
            autostart: true,
            interval: scrollInterval
        });
        $('.jcarousel').jcarouselAutoscroll({
            target: '+=' + scrollCount
        });
        $(function () {
            $('.jcarousel-control-prev')
                .on('jcarouselcontrol:active', function () {
                    $(this).removeClass('inactive');
                })
                .on('jcarouselcontrol:inactive', function () {
                    $(this).addClass('inactive');
                })
                .jcarouselControl({
                    target: '-=' + scrollCount
                });

            $('.jcarousel-control-next')
                .on('jcarouselcontrol:active', function () {
                    $(this).removeClass('inactive');
                })
                .on('jcarouselcontrol:inactive', function () {
                    $(this).addClass('inactive');
                })
                .jcarouselControl({
                    target: '+=' + scrollCount
                });
        });
    })(jQuery);
</script>
