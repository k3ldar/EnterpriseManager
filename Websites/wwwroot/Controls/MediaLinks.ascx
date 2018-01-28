<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MediaLinks.ascx.cs" Inherits="SieraDelta.Website.Controls.MediaLinks" %>

<table width="85%" cellpadding="0" cellspacing="0" border="0"  style="padding-top: 15px; padding-bottom: 15px; padding-right: 10px; border-collapse: separate; margin-left: auto; margin-right: auto;">
    <%=GetMediaLinks(true, true, false, true) %>
</table>

<div id="fb-root"></div>
<script>(function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "https://connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.4&appId=836803426406220";
        fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));</script>
<script type="text/javascript"> (function () { var po = document.createElement('script'); po.type = 'text/javascript'; po.async = true; po.src = 'https://apis.google.com/js/plusone.js'; var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(po, s); })(); </script>

<script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "https://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>