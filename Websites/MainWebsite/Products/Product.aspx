<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.PageProduct" %>
<%@ Register src="~/Controls/MayAlsoLike.ascx" tagname="MayAlsoLike" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>
<%@ Register src="~/Controls/MediaLinks.ascx" tagname="MediaLinks" tagprefix="uc2" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc3" %>
<%@ Register src="~/Controls/OutOfStockNotification.ascx" tagname="OutOfStockNotification" tagprefix="uc4" %>
<%@ Register Src="~/Controls/BasketSummary.ascx" TagPrefix="uc1" TagName="BasketSummary" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=GetProductName() %> - <%=GetProductGroupName()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link property="stylesheet" rel="stylesheet" href="/css/Modal.css" type="text/css" media="screen" />
    <script type="text/javascript">
        jQuery(document).ready(function () {
            var scrollCount = <%=GetScrollCount()%>; 
            jQuery('.mycarousel').jcarousel({
                scroll: scrollCount,
                wrap: "circular", auto: 10
            });
        });
    </script>
    <uc1:BasketSummary runat="server" ID="BasketSummary" Visible="false" />
        <div class="content">
			
		<div class="breadcrumb">
			
			<ul class="fixed">
				<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
				<li>&rsaquo;</li>
				<li><%=GetProductGroupLink()%></li>
				<li>&rsaquo;</li>
				<li><a href="/Products/Product.aspx?ID=<%=GetFormValue("ID", 1) %>"><%=GetProductName() %></a></li>
			</ul>
				
		</div><!-- end of #breadcrumb -->
			
			
		<uc3:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
		<div class="mainContent">
			
			<h1><%=GetProductName() %></h1>
				
			<div class="productImg">
                <asp:HyperLink ID="linkZoom" runat="server" >
					<img src="https://static.heavenskincare.com/Images/Products/<%=GetProductImage()%>" alt="" border="0" width="288" height="268"/>
					<span class="png_bg" runat="server" id="spZoom"><%=Languages.LanguageStrings.Zoom %></span>
                </asp:HyperLink>
			</div><!-- end of .productImg -->
				
			<p class="ProductBasket" id="pProductCost" runat="server">
                    
					<label><%=Languages.LanguageStrings.Size %>:</label>
                    <asp:DropDownList ID="lstProductTypes" runat="server">
                    </asp:DropDownList>

					<span id="spanNotifications" runat="server">
						<br /><br />
                        <label><%=Languages.LanguageStrings.Quantity %>:</label>
                        <asp:DropDownList ID="lstQuantity" runat="server">
                        </asp:DropDownList><br /><br />

                        <asp:Button ID="btnAddToBasket" runat="server" Text="Add To Basket" CssClass="standardButton" OnClick="btnAddToBasket_Click" />

                    </span>
			</p><!-- end of .productInfo -->

			<uc4:OutOfStockNotification ID="OutOfStockNotification1" runat="server" />
			            <p id="pPreOrder" runat="server"><br /><br />Pre-launch. Please allow up to 4 weeks for delivery.</p>
			<p class="ProductDescription"><%=GetProductDescription() %></p>
				
            <uc2:MediaLinks ID="MediaLinks1" runat="server" />
            <uc1:MayAlsoLike ID="MayAlsoLike1" runat="server" />								
			<uc2:WebPageTags ID="WebPageTags1" runat="server" />

			<div class="clear"><!-- clear --></div>
		</div><!-- end of #mainContent -->
			
		<div class="clear"><!-- clear --></div>
						
	</div><!-- end of #content -->
</asp:Content>
