<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CelebrityProducts.ascx.cs" Inherits="SieraDelta.Website.Controls.CelebrityProducts" %>
<div class="featuredProduct">
    <h2><%=SieraDelta.Languages.LanguageStrings.FavouriteProducts %>...</h2>
				
    <ul class="mycarousel fixed">
         <%=GetCelebrityProducts() %>
    </ul>
</div>