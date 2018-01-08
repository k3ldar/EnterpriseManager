<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="RefreshTags.aspx.cs" Inherits="SieraDelta.Website.Admin.RefreshTags" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">

function setText(val, e) {
    document.getElementById(e).value = val;
}

function insertText(val, e) {
    document.getElementById(e).value += val;
}

var nav = null; 

function requestPosition() {
  if (nav == null) {
      nav = window.navigator;
  }
  if (nav != null) {
      var geoloc = nav.geolocation;
      if (geoloc != null) {
          geoloc.getCurrentPosition(successCallback);
      }
      else {
          alert("geolocation not supported");
      }
  }
  else {
      alert("Navigator not found");
  }
}



function successCallback(position)
{
   setText(position.coords.latitude, "latitude");
   setText(position.coords.longitude, "longitude");
}



</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<label for="latitude">Latitude: </label><input id="latitude" /> <br />
<label for="longitude">Longitude: </label><input id="longitude" /> <br />
<input type="button" onclick="requestPosition()" value="Get Latitude and Longitude"  /> 
</asp:Content>
