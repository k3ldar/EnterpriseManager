<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="WebDefenderServer.aspx.cs" Inherits="SieraDelta.Website.Products.WebDefenderServer" %>

<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/MediaLinks.ascx" TagName="MediaLinks" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc3" %>
<%@ Register src="~/Controls/StatisticsInfo.ascx" tagname="StatisticsInfo" tagprefix="uc1" %>

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
                <li><a href="/Products/WebDefenderServer.aspx">WebDefender - Server</a></li>
            </ul>

        </div>
        <!-- end of #breadcrumb -->


        <uc3:leftcontainercontrol id="LeftContainerControl1" runat="server" suboptionsshow="true" />

        <div class="mainContent">

            <h1>WebDefender - Server</h1>

            <div class="productImg">
                <asp:HyperLink ID="linkZoom" runat="server">
					    <img src="/Images/Products/webdefender_288.png" alt="" border="0" width="288" height="268"/>
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
            <uc1:StatisticsInfo ID="StatisticsInfo1" runat="server" />

            <!-- end of .productInfo -->

            <div class="productDescription" id="divDescriptionTranslated" runat="server">
                <p>
                    WebDefender - Server is a highly configurable intrusion prevention system which protects your Windows Server from brute-force attacks on various services (RDP, MS-SQL, MS-FTP & MailEnable).
                </p>
                <p>
                    By constantly monitoring logs for failed login''s WebDefender detects failed logon attempts, if the number of failed attempts exceeds the configuration then the IP Address is automatically included in a banned list for a user defined period of time. If the number of failed logon attempts from a single IP address reaches a set limit, the attacker's IP address will be blocked for a specified period of time.
                </p>
                <p>
                    WebDefender - Server provides an interface for viewing current activity as well as detailed logs.
                </p>
                <p>
                    <img src="/Images/Products/WebDefenderServer/Image1.jpg" border="0" alt="" />
                </p>
                <p>
                    IP Addresses are only temporarily banned, this is to allow for recycling of non static addressses, however they can be permanently black listed if required.
                </p>
                <p>
                    You can view the locations of the <a href="/GeoIP/CurrentlyBanned.aspx">currently banned IP Addresses</a> on a map.
                </p>
            </div>

            <div class="productFeatures">
                <h5><%=Languages.LanguageStrings.Features %></h5>
                <div id="divFeaturesTranslated" runat="server">
                    <ul>
                        <li>Instant protection for Windows Server</li>
                        <li>White/Black list.</li>
                        <li>1 Licence per server</li>
                        <li>Configure single data store for instant updates between multiple servers</li>
                        <li>Highly Configurable</li>
                        <li>Unlimited Updates/Patches</li>
                        <li>Immediate Access to Licence via our <a href="/Account/Licences/">Licence Page</a></li>
                        <li>3 Week Trial Licence.</li>
                        <li>Prevents brute force attacks</li>
                        <li>Automatic configuration of Windows Firewall</li>
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
    </span>
</asp:Content>
