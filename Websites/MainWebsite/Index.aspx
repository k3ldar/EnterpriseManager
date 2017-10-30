<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.PageIndex" %>
<%@ Register src="~/Controls/MediaLinks.ascx" tagname="MediaLinks" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="feature">
				<div class="slider-wrapper theme-default">
					<div class="ribbon"></div>
					<div class="slider nivoSlider">
                        <%=GetHomePageImages()%>
					</div>
				</div>
			</div><!-- end of #feature -->

			<a href="/Redirect/Index.aspx?cmp=homeBlog&rd=http://heavenbydeborahmitchell.wordpress.com/" target="_blank" class="bannerBlog" title="Read Deborah's blog">
				<img src="/images/Deborahsblog.png" alt="Join me as I reveal my latest news & tips" width="224" height="320" />
			</a>
			
			<div class="banners" id="homeBanners" runat="server">
				<a href="/Redirect/Index.aspx?cmp=homeBanner1&rd=/Celebrities/Index.aspx" class="banner1<%=BannerType() %>" title="<%=Languages.LanguageStrings.SeeProductsCelebritiesLove %>">
					<div id="linkProductsDiv" runat="server" class="overlay"><h6><%=Languages.LanguageStrings.SeeProductsCelebritiesLove %></h6></div>
					<span id="linkProductsSpan" runat="server"><strong><%=Languages.LanguageStrings.Celebrities %></strong> <%=Languages.LanguageStrings.WhoLoveHeaven %></span>
				</a>
				
				<a href="/Redirect/Index.aspx?cmp=homeBanner2&rd=/Products.aspx?GroupID=2" class="banner2<%=BannerType() %>" title="<%=Languages.LanguageStrings.ViewAllCleansers %>">
					<div id="linkCleansersDiv" runat="server" class="overlay"><h6><%=Languages.LanguageStrings.ShinyLifelessSkin %></h6></div>
					<span id="linkCleansersSpan" runat="server"><%=Languages.LanguageStrings.ViewAll %> <strong><%=Languages.LanguageStrings.Cleansers %></strong></span>
				</a>
				
				<a href="/Redirect/Index.aspx?cmp=homeBanner3&rd=/Products.aspx?GroupID=5" class="banner3<%=BannerType() %>" title="<%=Languages.LanguageStrings.ViewAllMoisturisers %>">
					<div id="linkMoisturisersDiv" runat="server" class="overlay"><h6><%=Languages.LanguageStrings.WhyTakeTheRough %></h6></div>
					<span id="linkMoisturisersSpan" runat="server"><%=Languages.LanguageStrings.ViewAll %> <strong><%=Languages.LanguageStrings.Moisturisers %></strong></span>
				</a>
				<a href="/Redirect/Index.aspx?cmp=homeBanner4&rd=/appointments/Index.aspx?cmp=homeBanner4" id="linkSalonBookings" runat="server">
					<div id="linkSalonBookinsDiv" runat="server" class="overlay"><h6><%=Languages.LanguageStrings.DoYouWantHoned %></h6></div>
					<span id="linkSalonBookinsSpan" runat="server"><strong><%=Languages.LanguageStrings.BookYourTreatment %></strong> <%=Languages.LanguageStrings.Today %></span>
				</a>
			</div><!-- end of #banners -->
                
			<div class="clear"><!-- clear --></div>
			


            <div class="productScroller" style="padding-top:25px;">
			
				<h5><%=GetCarouselText() %></h5>
				
				<ul class="mycarousel fixed">
                    <%=GetCarouselProducts() %>
				</ul>
				
			</div><!-- end of #productScroller -->

			<uc1:MediaLinks ID="MediaLinks1" runat="server" class="CenteredDiv" />

		</div><!-- end of #content -->

    <%=GetMailChimpPopupIntegration() %>

</asp:Content>
