﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MayBankHoliday.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Products.MayBankHoliday" %>
<%@ Register src="~/Controls/MayAlsoLike.ascx" tagname="MayAlsoLike" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>
<%@ Register src="~/Controls/MediaLinks.ascx" tagname="MediaLinks" tagprefix="uc2" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc3" %>
<%@ Register src="~/Controls/OutOfStockNotification.ascx" tagname="OutOfStockNotification" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Offers %> - <%=GetProductName() %> - <%=GetWebTitle()%></title>
    <link rel="stylesheet" href="/css/Modal.css" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li>Offers</li>
					<li>&rsaquo;</li>
					<li><%=GetProductName() %></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc3:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
				<h1><%=GetProductName() %></h1>
				
				<div class="productImg">
                    <asp:HyperLink ID="linkZoom" runat="server" >
					    <img src="https://static.heavenskincare.com/images/products/<%=GetProductImage()%>" alt="" border="0" width="288" height="268"/>
                    </asp:HyperLink>
				</div><!-- end of .productImg -->
				
				<p class="productBasketStratosphere" id="pProductCost" runat="server">
						<label><%=Languages.LanguageStrings.Size %>:</label>
                        <asp:DropDownList ID="lstProductTypes" runat="server">
                        </asp:DropDownList>
                    
                    <span id="spanNotifications" runat="server"><br /><br />
						
						<label><%=Languages.LanguageStrings.Quantity %>:</label>
                        <asp:DropDownList ID="lstQuantity" runat="server">
                        </asp:DropDownList><br /><br />

                        <asp:Button ID="btnAddToBasket" runat="server" Text="Add To Basket" CssClass="standardButton" OnClick="btnAddToBasket_Click" />
                    </span>
				</p><!-- end of .productInfo -->
				
                <uc4:OutOfStockNotification ID="OutOfStockNotification1" runat="server" IsStratoshpere="true" />

                <div class="productIngredients" id="divIngredients" runat="server">
                    <h5 id="hContains" runat="server">Contains</h5>
                    <p>
                        <%=GetIngredients() %>
                    </p>
                </div>
				
                <div class="productFeatures" id="divFeatures" runat="server">
                    <h5>Features</h5>
                    <p>
                        <ul>
                            <%=GetProductFeatures() %>
                        </ul>
                    </p>
                </div>

				<div class="productDescription" id="divDescription" runat="server">
                    <p>
                        <%=GetProductDescription() %>
                    </p>
				</div>
				
                <div class="productHowToUse" id="divHowToUse" runat="server">
                    <h5>how to use</h5>
                    <p>
                        <%=GetHowToUse() %>
                    </p>
                </div>

                <div class="productVideo" id="divVideoLink" runat="server">
                    <h5>Video</h5>
                    <p><%=GetVideoLink() %></p>
                    <span>If this video does not display properly, or you wish to view this video in a new browser, <a href="<%=GetFullVideoLink() %>" target="_blank">click here</a></span>
                </div>

                <uc2:MediaLinks ID="MediaLinks1" runat="server" />
                <uc1:MayAlsoLike ID="MayAlsoLike1" runat="server" />								
			    <uc2:WebPageTags ID="WebPageTags1" runat="server" />

				<div class="clear"><!-- clear --></div>
			</div><!-- end of #mainContent -->
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->

</asp:Content>
