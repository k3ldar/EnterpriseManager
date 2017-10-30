<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeaturedStratosphere.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.FeaturedStratoshpere" %>
				
<div class="featuredProductStratosphere">
		
	<h5><%=Languages.LanguageStrings.FeaturedProducts %>...</h5>
	
	<ul class="mycarousel fixed">
        <%=GetCarouselProducts() %>
	</ul>
				
</div><!-- end of #productScroller -->
