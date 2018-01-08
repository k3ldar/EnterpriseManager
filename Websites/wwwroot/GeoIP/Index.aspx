<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.GeoIP.Index" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.LookupIPAddress %> - <%=GetWebTitle()%></title>

    <script type="text/javascript" src='https://maps.googleapis.com/maps/api/js?v=3&key=AIzaSyBDtmYlTGa71O_OyqX0JPXAToiwE_0QYIc'></script>
    <script type='text/javascript'>
        function init_map()
        {
            var latValue = <%=GetLatValue()%>;
            var lonValue = <%=GetLonValue()%>;
            var locationName = "<div class=\"scrollFixIPLookup\"><strong>IP Address:</strong> <%=GetIPAddress()%><br /><strong><%=Languages.LanguageStrings.Location %>:</strong> <%=GetCity()%>" + ", " + "<%=GetCountry()%></div>";
            var myOptions = { zoom: 9, center: new google.maps.LatLng(latValue, lonValue), mapTypeId: google.maps.MapTypeId.ROADMAP }; 
            map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions); 
            marker = new google.maps.Marker({ map: map, position: new google.maps.LatLng(latValue, lonValue) }); 
            infowindow = new google.maps.InfoWindow({ content:  locationName}); 
            google.maps.event.addListener(marker, 'click', function () { infowindow.open(map, marker); }); 
            infowindow.open(map, marker);
        } google.maps.event.addDomListener(window, 'load', init_map);
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li>Geo IP</li>
					<li>&rsaquo;</li>
					<li><a href="/GeoIP/Index.aspx"><%=Languages.LanguageStrings.LookupIPAddress %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.LookupIPAddress %></h1>

                <div id="divTranslated" runat="server">				
                    <p>Enter an IP address to view the Country, City, Postcode, Latitude and Longitude values: </p>
                    <p>Your IP Address: <%=GetUserIP() %></p>
				</div>
                <div>
                    <p><asp:TextBox ID="txtIPAddress" runat="server" MaxLength="15"></asp:TextBox><asp:Button ID="btnLookup" runat="server" style="margin-left: 15px;" CssClass="standardButton" Text="Lookup" /></p>
                    
                    <table align="left" cellspacing="1" class="ipLookupDetails">
                        <tr>
                            <th><strong><%=Languages.LanguageStrings.Country %>:</strong></th><td><%=GetCountry() %></td>
                        </tr>
                        <tr>
                            <th><strong><%=Languages.LanguageStrings.Region %>:</strong></th><td><%=GetRegion() %></td>
                        </tr>
                        <tr>
                            <th><strong><%=Languages.LanguageStrings.City %>:</strong></th><td><%=GetCity() %></td>
                        </tr>
                        <tr>
                            <th><strong><%=Languages.LanguageStrings.Postcode %>:</strong></th><td><%=GetPostCode() %></td>
                        </tr>
                        <tr>
                            <th><strong><%=Languages.LanguageStrings.Longitude %>:</strong></th><td><%=GetLonValue() %></td>
                        </tr>
                        <tr>
                            <th><strong><%=Languages.LanguageStrings.Latitude %>:</strong></th><td><%=GetLatValue() %></td>
                        </tr>
                        <tr>
                            <th><strong>Metro Code:</strong></th><td><%=GetMetroCode() %></td>
                        </tr>
                        <tr>
                            <th><strong>Area Code:</strong></th><td><%=GetAreaCode() %></td>
                        </tr>
                        <tr>
                            <th><strong>Numeric:</strong></th><td><%=GetNumeric() %></td>
                        </tr>
                        <tr>
                            <th><strong>Start:</strong></th><td><%=GetStartBlock() %></td>
                        </tr>
                        <tr>
                            <th><strong>End:</strong></th><td><%=GetEndBlock() %></td>
                        </tr>
                    </table>
                    <p>

                    </p>
                    <div style="float:left;overflow:hidden;height:330px;width:60%;padding-bottom:80px;">
                        <div id="gmap_canvas" style="height:330px;width:100%;">

                        </div>
                    </div>
                    <p></p>

                    <div style="float:right;overflow:hidden;padding-bottom:80px;">
                        <p id="pOwnIP" runat="server">
                            Is this information accurate?  Help us to improve the information by <a href="/GeoIP/UpdateLocation.aspx">selecting the nearest town or city</a> to your current location.
                        </p>
                    </div>
                </div>

                <div class="productDescription">
                    <p>This product includes modified IP data available from <a href="http://software77.net/geo-ip/" target="_blank">WebNet77</a> and GeoLite2 data created by MaxMind, available from <a href="http://www.maxmind.com" target="_blank">http://www.maxmind.com</a>.</p>
                </div>

                <uc2:WebPageTags ID="WebPageTags1" runat="server" />
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
