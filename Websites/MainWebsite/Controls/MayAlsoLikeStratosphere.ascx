<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MayAlsoLikeStratosphere.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.MayAlsoLikeStratosphere" %>
<div class="featuredProductStratosphere">
                <h2><%=Languages.LanguageStrings.YouMayAlsoLike %>...</h2>
				
              	<ul class="mycarousel fixed">
                    <%=GetCarouselProducts() %>
	            </ul>
</div>