<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="CurrentlyBanned.aspx.cs" Inherits="SieraDelta.Website.GeoIP.CurrentlyBanned" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.CurrentlyBanned %> - <%=GetWebTitle()%></title>

    <script type="text/javascript" src='https://maps.googleapis.com/maps/api/js?v=3&key=AIzaSyBDtmYlTGa71O_OyqX0JPXAToiwE_0QYIc'></script>
    <script type='text/javascript'>
        function init_map()
        {
            var bannedLocations = [
              <%=GetLocations() %>
            ];
            var myOptions = { zoom: 2, center: new google.maps.LatLng(0, 0), mapTypeId: google.maps.MapTypeId.ROADMAP };
            map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions);

            for (var i = 0; i < bannedLocations.length; i++)
            {
                var location = bannedLocations[i];
                var contentString = location[0];
                var marker = new google.maps.Marker({
                    position: { lat: location[1], lng: location[2] },
                    map: map,
                    title: location[0],
                    optimized: false,
                    buborek: contentString
                });

                var mapIcon = 'https://maps.google.com/mapfiles/ms/icons/blue-dot.png';

                if (location[3] == 1) {
                    mapIcon = 'https://maps.google.com/mapfiles/ms/icons/yellow-dot.png';
                    marker.zIndex = marker.zIndex + 999;
                    marker.Title = marker.Title + marker.zIndex;
                }
                else if (location[3] == 2) {
                    mapIcon = 'https://maps.google.com/mapfiles/ms/icons/orange-dot.png';
                    marker.setZIndex(marker.getZIndex() + 9999);
                }
                else if (location[3] == 3) {
                    mapIcon = 'https://maps.google.com/mapfiles/ms/icons/red-dot.png';
                    marker.setZIndex(marker.getZIndex() + 999999);
                }

                marker.setIcon(mapIcon);

                google.maps.event.addListener(marker, 'click', function () {
                    infowindow.setContent(this.buborek);
                    infowindow.open(map, this);
                });
            }

        } google.maps.event.addDomListener(window, 'load', init_map);
    </script>

    <style type="text/css">
        .scrollFix { line-height: 1.35; white-space: nowrap; }
        .auto-style1 {
            width: 180px;
            float: left;
            font-family: "nimbus-sans", Helvetica, Arial, "Lucida Grande", sans-serif;
            font-size: 1.4em;
            line-height: 1.5em;
        }
            .auto-style1 td
            {
                text-align: left;
                vertical-align: top;
            }
            .auto-style1 th strong
            {
                font-weight: 200;
                vertical-align: top;
            }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/GeoIP/Index.aspx">Geo IP</a></li>
					<li>&rsaquo;</li>
					<li><a href="/GeoIP/CurrentlyBanned.aspx"><%=Languages.LanguageStrings.CurrentlyBanned %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.CurrentlyBanned %></h1>

                <div id="divTranslated" runat="server">				
                    <p>The following map shows IP Addresses currently blocked by <a href="/Products/WebDefenderServer.aspx">Web Defender</a>.</p>
                    <p>Currently there are <%=CurrentlyBannedNumber() %> IP Addresses which have been automatically banned from our public servers.</p>

                    <p><img src="https://maps.google.com/mapfiles/ms/icons/red-dot.png" width="16px" height="16px" alt="Less than 1 hours" /> Less than 1 hour old.
                        <img src="https://maps.google.com/mapfiles/ms/icons/orange-dot.png" width="16px" height="16px" alt="Less than 6 hours" /> Less than 6 hours old.
                    <img src="https://maps.google.com/mapfiles/ms/icons/yellow-dot.png" width="16px" height="16px" alt="Less than 24 hours" /> Less than 24 hours old.
                    <img src="https://maps.google.com/mapfiles/ms/icons/blue-dot.png" width="16px" height="16px" alt="24 Hours or older" /> 24 Hours or older.</p>
				</div>
                <div>
                    <div style="float:right;overflow:hidden;height:500px;width:95%;padding-bottom:10px;">
                        <div id="gmap_canvas" style="height:500px;width:95%;">

                        </div>
                    </div>
                    <p></p>
                </div>

                <uc2:WebPageTags ID="WebPageTags1" runat="server" />
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
