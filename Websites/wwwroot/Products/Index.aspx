<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.PageProduct" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controls/MayAlsoLike.ascx" tagname="MayAlsoLike" tagprefix="uc1" %>
<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/MediaLinks.ascx" TagName="MediaLinks" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc3" %>
<%@ Register Src="~/Controls/OutOfStockNotification.ascx" TagName="OutOfStockNotification" TagPrefix="uc4" %>
<%@ Register Src="~/Controls/BasketSummary.ascx" TagPrefix="uc1" TagName="BasketSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=GetProductGroupName()%> - <%=GetProductName() %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('.mycarousel').jcarousel({
                scroll: 3,
                wrap: "circular"
            });
        });
    </script>
    <link property="stylesheet" rel="stylesheet" href="/css/Modal.css" type="text/css" media="screen" />
    <uc1:BasketSummary runat="server" ID="BasketSummary" Visible="false" />

    <div class="content">

        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><a href="/All-Products/Group/<%=GetPrimaryProductGroupName()%>/"><%=GetPrimaryProductGroupName()%></a></li>
                <li>&rsaquo;</li>
                <li><a href="<%=ProductSEOLocation()%>"><%=GetProductName() %></a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->


        <uc3:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />

        <div class="mainContent">

            <h1><%=GetProductName() %></h1>

            <div class="productImg">
                <asp:HyperLink ID="linkZoom" runat="server">
					    <img src="/Images/Products/<%=GetProductImage()%>" alt="" border="0" width="288" height="268"/>
                </asp:HyperLink>
            </div>
            <!-- end of .productImg -->

            <p class="prodBasket" id="pProductCost" runat="server">
                <label><%=Languages.LanguageStrings.Size %>:</label>
                <asp:DropDownList ID="lstProductTypes" runat="server">
                </asp:DropDownList>

                <span id="spanNotifications" runat="server">
                    <br />
                    <br />

                    <label><%=Languages.LanguageStrings.Quantity %>:</label>
                    <asp:DropDownList ID="lstQuantity" runat="server">
                    </asp:DropDownList><br />
                    <br />

                    <asp:Button ID="btnAddToBasket" runat="server" Text="Add To Basket" CssClass="standardButton" OnClick="btnAddToBasket_Click" />
                </span>
            </p>
            <!-- end of .productInfo -->

            <uc4:OutOfStockNotification ID="OutOfStockNotification1" runat="server" />

            <div class="productDescription">
                <p>
                    <%=GetProductDescription() %>
                </p>
            </div>

            <div class="productFeatures" id="divFeatures" runat="server">
                <h2><%=Languages.LanguageStrings.Features %></h2>
                <p>
                    <ul>
                        <%=GetProductFeatures() %>
                    </ul>
                </p>
            </div>

            <div class="productDescription" id="divIngredients" runat="server">
                <h2 id="hContains" runat="server"><%=Languages.LanguageStrings.Contains %></h2>
                <p>
                    <%=GetIngredients() %>
                </p>
            </div>

            <div id="divHowToUse" class="productDescription" runat="server">
                <h2><%=Languages.LanguageStrings.HowToUse %></h2>
                <p>
                    <%=GetHowToUse() %>
                </p>
            </div>

            <div class="productVideo" id="divVideoLink" runat="server">
                <h2><%=Languages.LanguageStrings.Video %></h2>
                <p><%=GetVideoLink() %></p>
                <span><%=Languages.LanguageStrings.VideoDescription %> <a href="<%=GetFullVideoLink() %>" target="_blank"><%=Languages.LanguageStrings.ClickHere %></a></span>
            </div>

            <uc2:MediaLinks ID="MediaLinks1" runat="server" />
            <uc1:MayAlsoLike ID="MayAlsoLike1" runat="server" />								
            <uc2:WebPageTags ID="WebPageTags1" runat="server" />

            <div class="clear">
                <!-- clear -->
            </div>
        </div>
        <!-- end of #mainContent -->

        <div class="clear">
            <!-- clear -->
        </div>

    </div>
    <!-- end of #content -->
</asp:Content>
