﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MayAlsoLike.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.MayAlsoLike" %>
<div class="featuredProduct">
                <h2><%=Languages.LanguageStrings.YouMayAlsoLike %></h2>
				
              	<ul class="mycarousel fixed">
                    <%=GetCarouselProducts() %>
	            </ul>
</div>