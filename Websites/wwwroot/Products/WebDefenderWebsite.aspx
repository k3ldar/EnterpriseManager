<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="WebDefenderWebsite.aspx.cs" Inherits="SieraDelta.Website.Products.WebDefenderWebsite" %>

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
                <li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><%=GetPrimaryProductGroup()%></li>
                <li>&rsaquo;</li>
                <li><a href="/Products/WebDefenderWebsite.aspx">WebDefender - Website</a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->


        <uc3:leftcontainercontrol id="LeftContainerControl1" runat="server" suboptionsshow="true" />

        <div class="mainContent">

            <h1>WebDefender - Website</h1>

            <div class="productImg">
                <asp:HyperLink ID="linkZoom" runat="server">
					    <img src="/Images/Products/webdefenderweb_288.png" alt="" border="0" width="288" height="268"/>
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
                    WebDefender - Website is used to determine the probability that your website is being subjected to:
                </p>
	            <ul>
                    <li>Hacking Attack</li>
                    <li>SQL Injection Attack</li>
                    <li>Spider/Bot intrusion detection</li>
                </ul>
                <p>
                    By using a heuristic algorithm, WebDefender looks at how your website is used over a period of time, taking into consideration
the keywords being submitted as part of the web request.
                </p>
            </div>

            <div class="productFeatures">
                <h5><%=Languages.LanguageStrings.Features %></h5>
                <div id="divFeaturesTranslated" runat="server">
                    <ul>
                        <li>Detects spiders and web bots.
                        </li>
                        <li>Detects malicious input.
                        </li>
                        <li>Detects hacking attempts.
                        </li>
                        <li>Detects SQL Injection attacks
                        </li>
                        <li>White List of IP Addresses
                        </li>
                        <li>Black List of IP Addresses
                        </li>
                        <li>Temporarily block/ban IP Address
                        </li>
                        <li>Highly Optimized
                        </li>
                        <li>Unlimited Updates/Patches
                        </li>
                        <li>Immediate Access to Licence via our <a href="/Account/Licences/">Licence Page</a>
                        </li>
                        <li>3 Week Trial Licence.
                        </li>
                        <li>1 Licence per website.
                        </li>
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
