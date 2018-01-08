<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductScroller.ascx.cs" Inherits="SieraDelta.Website.Controls.ProductScroller" %>
<div class="productScroller" style="width: <%=GetScrollerWidth()%>; overflow: hidden;" >
    <h5 runat="server" id="hHeader"><%=SieraDelta.Languages.LanguageStrings.CheckOutLatestGreatest %></h5>

    <ul class="mycarousel fixed">
        <%=GetProducts() %>
    </ul>
</div>
<!-- end of #productScroller -->

