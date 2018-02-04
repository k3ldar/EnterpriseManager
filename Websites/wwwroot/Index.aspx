<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.PageIndex" %>
<%@ Register src="~/Controls/MediaLinks.ascx" tagname="MediaLinks" tagprefix="uc1" %>

<%@ Register src="Controls/FeaturedProducts.ascx" tagname="FeaturedProducts" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=GetWebTitle()%></title>
        

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
	<div class="content">
			
        <div id="slider" class="featureWrapper">
			<div class="feature">
				<div class="slider-wrapper theme-default">
					<div class="ribbon"></div>
					<div class="slider nivoSlider">
                        <%=GetHomePageImages(700, 320, true)%>
					</div>
				</div>
			</div>
        </div><!-- end of #feature -->
			
        <div class="clear">
            <!-- clear -->
        </div>

        <div id="divTranslated" runat="server">
        </div>			

        <div id="divBanners" runat="server" class="featureWrapper">
			<div class="banners">
			    <%=GetBannerLinks() %>
           
				<div class="clear"><!-- clear --></div>
			</div><!-- end of #banners -->
		</div>
				
        <uc1:MediaLinks ID="MediaLinks1" runat="server" class="CenteredDiv" />
        <uc2:FeaturedProducts ID="FeaturedProducts1" runat="server" />
	</div><!-- end of #content -->

    <link rel="stylesheet" href="/css/nivo-slider.css" type="text/css" />
    <script type="text/javascript" src="/js/jquery.nivo.slider.pack.js"></script>
    <script type="text/javascript">
        $(window).on('load', function () { $('.slider').nivoSlider({ animSpeed: 500, directionNav: false, effect: 'fade', pauseTime: 6000 }); });
    </script>
</asp:Content>
