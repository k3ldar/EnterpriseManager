<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="WebMonitor.aspx.cs" Inherits="SieraDelta.Website.Products.WebMonitor" %>

<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/MediaLinks.ascx" TagName="MediaLinks" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=GetProductGroupName()%> - <%=GetProductName() %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">

        <div class="breadcrumb">

            <ul class="fixed">
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><%=GetPrimaryProductGroup()%></li>
                <li>&rsaquo;</li>
                <li><a href="/Products/WebMonitor.aspx">WebMonitor</a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->


        <uc3:leftcontainercontrol id="LeftContainerControl1" runat="server" suboptionsshow="true" />

        <div class="mainContent">

            <h1>WebMonitor</h1>

            <div class="productImg">
                <asp:HyperLink ID="linkZoom" runat="server">
					    <img src="/Images/Products/webmonitor_288.png" alt="" border="0" width="288" height="268"/>
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

            <div class="productDescription" id="divDescriptionTranslated" runat="server">
                <p>
	                WebMonitor is a highly configurable service which can crawl through a website and validate pages, links and images.
                </p>
                <p>
                WebMonitor provides an interface for viewing current activity as well as detailed logs.
                </p>
                <p>
                <img src="/Images/Products/WebMonitor/tabwebsite.png" border="0" alt="" />
                </p>
            </div>

            <div class="productFeatures">
                <h5><%=Languages.LanguageStrings.Features %></h5>
                <div id="divFeaturesTranslated" runat="server">
                    <ul>
                        <li>Detects missing links.</li>
                        <li>Detects missing images.</li>
                        <li>Receive email notifications with details of errors.</li>
                        <li>1 Licence per server</li>
                        <li>Multiple websites checked simultaneously</li>
                        <li>Highly Configurable
                        </li>
                        <li>Unlimited Updates/Patches</li>
                        <li>Immediate Access to Licence via our <a href="/Members/Licences.aspx">Licence Page</a></li>
                        <li>3 Week Trial Licence.</li>
                    </ul>
                </div>
            </div>

            <div class="productVideo" id="divVideoLink" runat="server">
                <h5><%=Languages.LanguageStrings.Video %></h5>
                <p><%=GetVideoLink() %></p>
                <span><%=Languages.LanguageStrings.VideoDescription %> <a href="<%=GetFullVideoLink() %>" target="_blank"><%=Languages.LanguageStrings.ClickHere %></a></span>
            </div>

            <uc2:medialinks id="MediaLinks1" runat="server" />
            <uc2:webpagetags id="WebPageTags1" runat="server" />

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
