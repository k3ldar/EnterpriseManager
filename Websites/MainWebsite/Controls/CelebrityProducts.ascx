<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CelebrityProducts.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.CelebrityProducts" %>
<div class="featuredProduct">
    <h2><%=Languages.LanguageStrings.FavouriteProducts %>...</h2>
				
    <ul class="mycarousel fixed">
         <%=GetCelebrityProducts() %>
    </ul>
</div>