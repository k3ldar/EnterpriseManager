<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Location.aspx.cs" Inherits="SieraDelta.Website.Admin.Location" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script type="text/javascript">
    function setText(val, e) { document.getElementById(e).value = val; } function insertText(val, e) { document.getElementById(e).value += val; } var nav = null; function requestPosition() { if (nav == null) { nav = window.navigator; } if (nav != null) { var geoloc = nav.geolocation; if (geoloc != null) { geoloc.getCurrentPosition(successCallback); } else { alert("geolocation not supported"); } } else { alert("Navigator not found"); } } function successCallback(position) { setText(position.coords.latitude, "latitude"); setText(position.coords.longitude, "longitude"); }
</script></head>
<body>
    <form id="form1" runat="server">
    <div>
 <label for="latitude">Latitude: </label><input id="latitude" /> <br />
<label for="longitude">Longitude: </label><input id="longitude" /> <br />
<input type="button" onclick="requestPosition()" value="Get Latitude and Longitude"  /> 
   
    </div>
    </form>
</body>
</html>
