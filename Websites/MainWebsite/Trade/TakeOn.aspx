<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TakeOn.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Trade.TakeOn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.PackagesAndCosts %> - <%=Languages.LanguageStrings.Trade %> - <%=GetWebTitle()%></title>
<style type="text/css" media="screen">	
	.flashContent { width:100%; height:387px; box-shadow: 0 2px 5px rgba(0,0,0,0.6); }
    .flcontent { width:1100px; height:550px;  margin:20px; background:#FFFFFF;}
	.wrapper {
	    background-color: #fff;
	    box-shadow: 0 2px 5px rgba(0,0,0,0.6);
	    margin: 0px auto;
	    width: 1140px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Trade.aspx"><%=Languages.LanguageStrings.Trade %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Trade/TakeOn.aspx"><%=Languages.LanguageStrings.PackagesAndCosts %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
						
			<div class="flContent">
			
				<h1>Packages and Costs</h1>
				
								<div class="flashContent">
			<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" width="1110" height="387"  id="take-on-costs" align="middle">
				<param name="movie" value="take-on-costs.swf" />
				<param name="quality" value="high" />
				<param name="bgcolor" value="#FFF" />
				<param name="play" value="true" />
				<param name="loop" value="true" />
				<param name="wmode" value="opaque" />
				<param name="scale" value="exactfit" />
				<param name="menu" value="true" />
				<param name="devicefont" value="false" />
				<param name="salign" value="" />
				<param name="allowScriptAccess" value="sameDomain" />
				<!--[if !IE]>-->
				<object type="application/x-shockwave-flash" data="/Trade/take-on-costs.swf" width="1110" height="387" >
					<param name="movie" value="take-on-costs.swf" />
					<param name="quality" value="high" />
					<param name="bgcolor" value="#FFF" />
					<param name="play" value="true" />
					<param name="loop" value="true" />
					<param name="wmode" value="window" />
					<param name="scale" value="exactfit" />
					<param name="menu" value="true" />
					<param name="devicefont" value="false" />
					<param name="salign" value="" />
					<param name="allowScriptAccess" value="sameDomain" />
				<!--<![endif]-->
					<a href="http://www.adobe.com/go/getflash">
						<img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif" alt="Get Adobe Flash player" />
					</a>
				<!--[if !IE]>-->
				</object>
				<!--<![endif]-->
			</object>
		</div>
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
