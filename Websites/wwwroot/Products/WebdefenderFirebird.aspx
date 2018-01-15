<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="WebdefenderFirebird.aspx.cs" Inherits="SieraDelta.Website.Products.WebdefenderFirebird" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>
<%@ Register src="~/Controls/MediaLinks.ascx" tagname="MediaLinks" tagprefix="uc2" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc3" %>

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
				<li><a href="/Products/WebDefenderFirebird.aspx">WebDefender - Firebird</a></li>
			</ul>
				
		</div><!-- end of #breadcrumb -->
			
			
	    <uc3:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
        <div class="mainContent">

            <h1>WebDefender - Firebird</h1>

            <div class="productImg">
                <asp:HyperLink ID="linkZoom" runat="server">
					    <img src="/Images/Products/webdefenderfb_288.png" alt="" border="0" width="288" height="268"/>
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
                    WebDefender - Firebird is a highly configurable system which adds layers of protection to your Firebird installation and allows fine grain control over access to your databases.
                </p>
                <h3>TCP Monitoring</h3><p>
                    The product is split into two area's, the first monitors connections to database on a TCP level, allowing you to see which IP addresses are connection, how often they are connecting and how long they are connected for.
                </p>
                <p>This element is highly configurable and allows you to specify how monitoring takes place.</p>
                <p>
                    <img src="/Images/Products/FBDefender/SettingsTab.png" border="0" alt="" />
                </p>
                <p>
                    <img src="/Images/Products/FBDefender/MemoryTab.png" border="0" alt="" />
                </p>
                <h3>Access Control</h3>
                <p>The second part of the product allows you to directly control user access using Country, IP Address, Date/Time, User, Role and Application, specifying exactly how a user can access your data.</p>
                <p>
                    <img src="/Images/Products/FBDefender/RuleEdit.png" border="0" alt="" />
                </p>
                <p>
                    <a href="/Images/Products/FBDefender/RulesNode.png" target="_blank"><img src="/Images/Products/FBDefender/RulesNode.png" width="680px;" border="0" alt="" /></a>
                </p>
            </div>

            <div class="productFeatures">
                <h5><%=Languages.LanguageStrings.Features %></h5>
                <div id="divFeaturesTranslated" runat="server">
                    <ul>
                        <li>Instant protection for your Firebird Database</li>
                        <li>Access Control</li>
                        <li>Control access by Country</li>
                        <li>Control accesss by Time/Date</li>
                        <li>Control accesss by User</li>
                        <li>Control accesss by Role</li>
                        <li>Control accesss by IP Address</li>
                        <li>Control accesss by Application</li>
                        <li>Daily updates for Geo IP data</li>
                        <li>White/Black list.</li>
                        <li>1 Licence per server</li>
                        <!--<li>Configure single data store for instant updates between multiple servers</li>-->
                        <li>Highly Configurable</li>
                        <li>Unlimited Updates/Patches</li>
                        <li>Immediate Access to Licence via our <a href="/Account/Licences/">Licence Page</a></li>
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
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
