<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="FaceBook.aspx.cs" Inherits="Heavenskincare.WebsiteTemplateFeeds.FaceBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx">Home</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Index.aspx">Staff</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Feeds/Facebook.aspx">Facebook</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Facebook</h1>

                <div id="fb-root"></div> <script>                                             (function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (d.getElementById(id)) return; js = d.createElement(s); js.id = id; js.src = "//connect.facebook.net/en_GB/all.js#xfbml=1"; fjs.parentNode.insertBefore(js, fjs); } (document, 'script', 'facebook-jssdk'));</script>
<div class="fb-post" data-href="https://www.facebook.com/photo.php?fbid=10153240787110301&amp;set=a.10150646359295301.684905.10150090553065301&amp;type=1"><div class="fb-xfbml-parse-ignore"><a href="https://www.facebook.com/photo.php?fbid=10153240787110301&amp;set=a.10150646359295301.684905.10150090553065301&amp;type=1">Post</a> by <a href="https://www.facebook.com/heavenskincare">heaven skincare</a>.</div></div>
												
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->



</asp:Content>
