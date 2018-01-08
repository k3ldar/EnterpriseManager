<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="GeoIP.aspx.cs" Inherits="SieraDelta.Website.Products.GeoIP" %>

<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/MediaLinks.ascx" TagName="MediaLinks" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc3" %>
<%@ Register src="~/Controls/FileDownload.ascx" tagname="FileDownload" tagprefix="uc1" %>

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
                <li><a href="/Products/GeoIP.aspx">GeoIP</a></li>
            </ul>
        </div>
        <!-- end of #breadcrumb -->


        <uc3:leftcontainercontrol id="LeftContainerControl1" runat="server" suboptionsshow="true" />

        <div class="mainContent">
            <h1>GeoIP Update</h1>

            <div class="productImg">
                <asp:HyperLink ID="linkZoom" runat="server">
					    <img src="/Images/Products/geoip_288.png" alt="" border="0" width="288" height="268"/>
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
                <br /><br />
                <a href="/GeoIP/Index.aspx">Geo IP Lookup</a>
            </p>
                
            <!-- end of .productInfo -->

            <div class="productDescription" id="divDescriptionTranslated" runat="server">
                <p>
                    Our GeoIP database contains over 4 billion IPv4 Addresses and over 370,000 Cities/Town records, and provide the country code for each IP Address, along with Latitude and Longitude, City Name and Region.
                </p>
                <h3>How it works</h3>
                <p>
                    Our GeoIP service connects directly to any Firebird, MySQL or MS SQL Server database and directly updates the GeoIP data based on changes made by the controlling authorities.
                </p>
                <p>
                    Updates only include the relevant changes made during the previous 24 hour period, making updating your database quick and easy.  You only need to supply the connection details for your database.
                </p>
                <p id="pGeoIPVersion" runat="server"></p>

                <h5>Firebird</h5>
                <p>To query the table using firebird you can call a stored procedure with the IP Address you want to query:</p>
                <p><code>SELECT p.OPCOUNTRY<br />FROM WD$GEO_DECODE_IP('158.32.56.128') p</code></p>
                <p>Or if you need more detailed information about the IP Address<br /><br /><code>SELECT p.OPCOUNTRY, p.OPCITY, p.OPREGION, p.OPPOSTCODE, p.OPLATITUDE, p.OPLONGITUDE<br />FROM WD$GEO_DECODE_IP('158.32.56.128') p</code></p>

                <h5>MySQL</h5>
                <p>To query the table using firebird you query the table directly:</p>
                <p><code>SELECT wd$country_code<br />FROM sieradelta.wd$iptocountry<br />WHERE wd$from_ip < INET_ATON('85.17.24.66') AND wd$to_ip > INET_ATON('85.17.24.66')</code></p>

                <h5>MS SQL</h5>
                <p>To query the table using MS SQL you call a function with the IP Address you want to query:</p>
                <p>
                    <code>
                        SELECT [dbo].[WD$GEO_DECODE_IP] ('158.32.56.128')<br />
                        GO
                    </code>
                </p>
                <h3><%=Languages.LanguageStrings.PossibleApplications %></h3>
                <p>There are many possible applications for this data including:</p>
                <ul>
                    <li>Real Time Country Geo-Location</li>
                    <li>Auto country detection for rapid form entry such as country, currency, language.</li>
                    <li>On-line campaigns such as targeted Banner Ads</li>
                    <li>Fraud Detection, Credit Card Fraud vetting etc.</li>
                    <li>Web Server Log analysis</li>
                    <li>Creation of Location Aware Content such as language, currency, etc</li>
                    <li>Filter web access on basis of originating country</li>
                    <li>Spam mail Filtering</li>
                    <li>Firewall and HTTP filtering rules</li>
                    <li>Email services for identifying the country of the sender</li>
                    <li>Digital Rights Management such as music or film distribution</li>
                </ul>

                <h3>Service Application</h3>
                <p>The service comes with a simple management interface and runs in the back ground</p>
                <p>
                    <img src="/Images/Products/GeoIP/GeoIPDatabases.png" border="0" alt="" />
                </p>
                <p>Please note you will need to <a href="/Members/Signup.aspx">sign up for an account</a> to obtain the free 3 database licence, once signed up you can goto your <a href="/Members/Licences.aspx">licence page</a> to view and activate your licence. </p>
            </div>

            <div class="productFeatures">
                <h5><%=Languages.LanguageStrings.Features %></h5>
                <div id="divFeaturesTranslated" runat="server">
                    <ul>
                        <li>GUI Interface.
                        </li>
                        <li>Small, fast daily updates, where available.
                        </li>
                        <li>Free for commercial/non commercial use (maximum connection of 3 databases) *.
                        </li>
                        <li>Unlimited Updates/Patches.
                        </li>
                        <li>Only works on local databases.</li>
                    </ul>
                </div>
            </div>

                            
                <div class="productDescription">
                    <h3>What information is provided?</h3>
                    <p>The following information is available within our database:</p>

                    <ul>
                        <li>The country</li>
                        <li>The region/state</li>
                        <li>The city</li>
                        <li>Postcode, if available</li>
                        <li>The latitude and longitude of the location</li>
                        <li>The area code for that region</li>
                    </ul>
                    
                    <h3>What information is not available.</h3>
                    <p>There is no personal information available like a person's name or street address. </p>
                </div>

            <uc1:FileDownload ID="FileDownload1" runat="server" />

            <div class="productVideo" id="divVideoLink" runat="server">
                <h5><%=Languages.LanguageStrings.Video %></h5>
                <p><%=GetVideoLink() %></p>
                <span><%=Languages.LanguageStrings.VideoDescription %> <a href="<%=GetFullVideoLink() %>" target="_blank"><%=Languages.LanguageStrings.ClickHere %></a></span>
            </div>


            <div class="productDescription">
                <p>*  A licence is created in your <a href="/Members/Licences.aspx">licence page</a> when you sign up for an account.</p>
            </div>

            <div class="productDescription">
                <p>This product includes modified IP data available from <a href="http://software77.net/geo-ip/" target="_blank">WebNet77</a> and GeoLite2 data created by MaxMind, available from <a href="http://www.maxmind.com" target="_blank">http://www.maxmind.com</a>.</p>
            </div>

            <uc2:medialinks id="MediaLinks1" runat="server" />
            <uc2:webpagetags id="WebPageTags1" runat="server" />

            <div class="clear">
                <!-- clear -->
            </div>
        </div>

        <div class="clear">
            <!-- clear -->
        </div>

    </div>
    <!-- end of #content -->
</asp:Content>
