<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="VisitorLocations.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Reports.VisitorLocations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src='https://maps.googleapis.com/maps/api/js?v=3&key=AIzaSyBDtmYlTGa71O_OyqX0JPXAToiwE_0QYIc'></script>

    <style type="text/css">
        .scrollFix { line-height: 1.35; white-space: nowrap; }
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Staff/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Staff/Reports/Index.aspx">Reports</a></li>
					<li>&rsaquo;</li>
					<li><a href="/Staff/Reports/SEO/VisitorLocations.aspx">Active Visitor Locations</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
		<div class="mainContent">
			
			<h1>Active Visitor Locations</h1>

            <div >
                <div style="float:right;overflow:hidden;height:500px;width:800px;padding-bottom:10px;">
                    <div id="gmap_canvas" style="height:500px;width:800px;">

                    </div>
                </div>
            </div>
		    <div class="clear"><!-- clear --></div>
            <div>
                <p>
                    <img src="https://maps.google.com/mapfiles/ms/icons/blue.png" alt="blue" /> = Visitor <br />
                    <img src="https://maps.google.com/mapfiles/ms/icons/green.png" alt="green" /> = Registered User <br />
                    <img src="https://maps.google.com/mapfiles/ms/icons/green-dot.png" alt="green-dot" /> = Registered User (Mobile) <br />
                    <img src="https://maps.google.com/mapfiles/ms/icons/blue-pushpin.png" alt="blue-pushpin" /> = Sale <br />
                    <img src="https://maps.google.com/mapfiles/ms/icons/grn-pushpin.png" alt="grn-pushpin" /> = Sale (Mobile) <br />
                    <img src="https://maps.google.com/mapfiles/ms/icons/yellow.png" alt="yellow" /> = Bounced  <br />
                    <img src="https://maps.google.com/mapfiles/ms/icons/orange.png" alt="orange" /> = Bot  <br />
                </p>
            </div>
		</div><!-- end of #mainContent -->
			
			
		<div class="clear"><!-- clear --></div>
						
	</div><!-- end of #content -->
    <script type="text/javascript" src='https://maps.googleapis.com/maps/api/js?v=3&key=AIzaSyBDtmYlTGa71O_OyqX0JPXAToiwE_0QYIc'></script>

    <script type='text/javascript'>
        function init_map() {
            var locations = [<%=GetLocations() %>];
            var myOptions = { zoom: 2, center: new google.maps.LatLng(0, 0), mapTypeId: google.maps.MapTypeId.ROADMAP };
            map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions);
            var mapIcon = 'https://maps.google.com/mapfiles/ms/icons/red.png';

            for (var i = 0; i < locations.length; i++) {
                var location = locations[i];
                var contentString = location[0];
                mapIcon = 'https://maps.google.com/mapfiles/ms/icons/' + location[6] + '.png';

                var marker = new google.maps.Marker({
                    position: { lat: location[1], lng: location[2] },
                    map: map,
                    title: location[0],
                    optimized: false,
                    buborek: contentString
                });


                marker.setIcon(mapIcon);

                google.maps.event.addListener(marker, 'click', function () {
                    infowindow.setContent(this.buborek);
                    infowindow.open(map, this);
                });
            }
        } google.maps.event.addDomListener(window, 'load', init_map);
    </script>
</asp:Content>
