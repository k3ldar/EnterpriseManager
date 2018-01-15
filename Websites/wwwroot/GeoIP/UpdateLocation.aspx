<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="UpdateLocation.aspx.cs" Inherits="SieraDelta.Website.GeoIP.UpdateLocation" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title><%=Languages.LanguageStrings.GeoIPUpdateLocation %>- <%=Languages.LanguageStrings.GeoIP %></title>
    <script type="text/javascript">
        function setText(val, e) { document.getElementById(e).value = val; } function insertText(val, e) { document.getElementById(e).value += val; } var nav = null; function requestPosition() { if (nav == null) { nav = window.navigator; } if (nav != null) { var geoloc = nav.geolocation; if (geoloc != null) { geoloc.getCurrentPosition(successCallback, failCallback, {timeout:10000, maximumAge:0, enableHighAccuracy:true}); }else { window.location = "/GeoIP/UpdateLocation.aspx?error=geolocation not supported"; } } else { window.location = "/GeoIP/UpdateLocation.aspx?error=Navigator not found"; } } function successCallback(position)  { window.location = "/GeoIP/UpdateLocation.aspx?lat=" + position.coords.latitude + "&lon=" + position.coords.longitude; } function failCallback() { window.location = "/GeoIP/UpdateLocation.aspx?error=failed or permission denied"; }
    </script>
    <script type="text/javascript">
        var forceReload = <%=GetReload()%>; if (forceReload) window.onload = function () { requestPosition(); };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li>Geo IP</li>
					<li>&rsaquo;</li>
					<li><a href="/GeoIP/UpdateLocation.aspx"><%=Languages.LanguageStrings.GeoIPUpdateLocation %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.GeoIPUpdateLocation %></h1>

                <div id="divTranslated" runat="server">
                    <p id="pError" runat="server">
                        We were unable to determine your current position, please <a href="/GeoIP/UpdateLocation.aspx">try again</a> in a few seconds.<br />
                        <br />Extra information: <%=GetError() %>
                    </p>
                    <p id="pThanks" runat="server">
                        Thank you for helping to improve the accuracy of this location.
                    </p>
                    <p id="pPrompt" runat="server">To find the nearest towns and cities to you we need to know your location.  To do this you need to authorise the usage of the browser location services.  If you see a pop up requesting your authroization please select Share or Allow to continue.
                        <br /><br />
                    It may take a few seconds to determine your location.
                    </p>			
                    <p id="pUserDetails" runat="server">Your IP Address: <%=GetUserIP() %><br />Location:<br /> <%=GetLatLong()%></p>
				</div>
                <div runat="server" id="divTownSelect">
                    <p>Below is a list of town's and cities that are close to your location.  Please select your location and click submit.</p>
                    <p><%=Languages.LanguageStrings.GeoIPNearestTownOrCity %></p>
                    <p><asp:DropDownList ID="cityList" runat="server"></asp:DropDownList><asp:Button ID="btnSubmit" runat="server" style="margin-left: 15px;" CssClass="standardButton" Text="Submit" OnClick="btnSubmit_Click" /></p>
                    <p>Additional Information<br />
                        <asp:TextBox ID="txtAdditionalInfo" runat="server" MaxLength="500" Height="100px" Width="350px" TextMode="MultiLine"></asp:TextBox></p>
                </div>
			</div><!-- end of #mainContent -->
			<div class="clear"><!-- clear --></div>
		</div><!-- end of #content -->
</asp:Content>
