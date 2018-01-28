<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeaturedProducts.ascx.cs" Inherits="SieraDelta.Website.Controls.FeaturedProducts" %>
<script type="text/javascript" src="/js/jquery.jcarousel.min.js"></script>
<style>
    .jcarousel {
        left: 40px;
        overflow: hidden;
        width: 700px;
        direction: ltr;
        position: relative;
    }

        .jcarousel ul {
    width: 20000em;
    position: relative;
    list-style: none;
    margin: 0;
    padding: 0;
        }

        .jcarousel li {
            width: 220px;
            float: left;
            height: 215px;
            padding-left: 10px;
        }

    .jcarousel-control-prev, .jcarousel-control-next {
    position: absolute;
    top: 120px;
    width: 30px;
    height: 30px;
    text-align: center;
    background: #4E443C;
    color: #fff;
    text-decoration: none;
    text-shadow: 0 0 1px #000;
    font: 24px/27px Arial, sans-serif;
    -webkit-border-radius: 30px;
       -moz-border-radius: 30px;
            border-radius: 30px;
    -webkit-box-shadow: 0 0 2px #999;
       -moz-box-shadow: 0 0 2px #999;
            box-shadow: 0 0 2px #999;
    }

    .jcarousel-control-prev {
        /*background: transparent url('/images/arrow-previous.png') no-repeat center 0;*/
        left: 0px;
    }

    .jcarousel-control-next {
        /*background: transparent url('/images/arrow-next.png') no-repeat center 0;*/
        right: -20px;
    }

.jcarousel-control-prev:hover span,
.jcarousel-control-next:hover span {
    display: block;
}

.jcarousel-control-prev.inactive,
.jcarousel-control-next.inactive {
    opacity: .5;
    cursor: default;
}
        /*.jcarousel-control-next:hover, .jcarousel-control-next:focus, .jcarousel-control-next:active,
        .jcarousel-control-prev:hover, .jcarousel-control-prev:focus, .jcarousel-control-prev:active {
            opacity: 1;
        }

    .jcarousel-next-disabled-horizontal, .jcarousel-next-disabled-horizontal:hover, .jcarousel-next-disabled-horizontal:focus, .jcarousel-next-disabled-horizontal:active,
    .jcarousel-prev-disabled-horizontal, .jcarousel-prev-disabled-horizontal:hover, .jcarousel-prev-disabled-horizontal:focus, .jcarousel-prev-disabled-horizontal:active {
        opacity: 0.2;
    }*/


    .jcarousel ul li a span.new, .jcarousel ul li a span.best {
        background: #000;
        color: #fff;
        overflow: hidden;
        position: absolute;
        text-align: center;
        text-indent: 0px;
        top: 5px;
        right: 5px;
        width: 60px;
        height: 40px;
        padding-top: 10px;
        font-size: 0.8em;
    }

    .jcarousel ul li a {
        color: #333;
        display: block;
        font-size: 1.4em;
        font-weight: normal;
        line-height: 1.2;
        text-decoration: none;
    }

        .jcarousel ul li a span.info {
            display: block;
            margin: 0 0 10px 0;
            height: 62px;
        }

            .jcarousel ul li a span.info strong {
                padding: 10px 0 0 0;
            }

        .jcarousel ul li a img {
            -moz-border-radius: 2px;
            -webkit-border-radius: 2px;
            border-radius: 2px;
            background-color: #fff;
        }

        .jcarousel ul li a:hover img {
            border-color: #999;
        }

        .jcarousel ul li a strong {
            color: #999;
            display: block;
            font-size: 0.8em;
        }
.jcarousel-pagination {
    position: absolute;
    bottom: 0;
    left: 15px;
}

.jcarousel-pagination a {
    text-decoration: none;
    display: inline-block;
    
    font-size: 11px;
    line-height: 14px;
    min-width: 14px;
    
    background: #fff;
    color: #4E443C;
    border-radius: 14px;
    padding: 3px;
    text-align: center;
    
    margin-right: 2px;
    
    opacity: .75;
}

.jcarousel-pagination a.active {
    background: #4E443C;
    color: #fff;
    opacity: 1;
    text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.75);
}

</style>
<div class="jcarousel-wrapper">
    <h2><%=Languages.LanguageStrings.FeaturedProducts %></h2>
    <div class="jcarousel">

        <ul class="mycarousel fixed">
            <%=GetCarouselProducts() %>
        </ul>
    </div>

    <a href="#" class="jcarousel-control-prev">&lsaquo;</a>
    <a href="#" class="jcarousel-control-next">&rsaquo;</a>
</div>
<script type="text/javascript">
    (function ($) {
        $(function () {
            $('.jcarousel').jcarousel();

            $('.jcarousel-control-prev')
                .on('jcarouselcontrol:active', function () {
                    $(this).removeClass('inactive');
                })
                .on('jcarouselcontrol:inactive', function () {
                    $(this).addClass('inactive');
                })
                .jcarouselControl({
                    target: '-=3'
                });

            $('.jcarousel-control-next')
                .on('jcarouselcontrol:active', function () {
                    $(this).removeClass('inactive');
                })
                .on('jcarouselcontrol:inactive', function () {
                    $(this).addClass('inactive');
                })
                .jcarouselControl({
                    target: '+=3'
                });

        });
    })(jQuery);
</script>
