<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftContainerControl.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.LeftContainerControl" %>
<%@ Register src="~/Controls/MailListSubscription.ascx" tagname="MailListSubscription" tagprefix="uc1" %>

<div id="divMobileShowColumn" runat="server" class="mobileShowColumn">
    <img src="https://www.heavenskincare.com/images/showtoolbar.png" onclick="openToolbar()" alt="Toolbar"/>
</div>

<div class="leftColumn" id="leftToolbar">
    <a id="adivClose" runat="server" href="javascript:void(0)" class="closebtn" onclick="closeToolbar()">&times;</a>
          
    <h5 id="subHeader" runat="server" visible="false">sub header</h5>
				
    <ul id="subOptions" runat="server" visible="false">
        
    </ul>

    <div id="divSubscribers" runat="server" class="mailList" visible="false" style="color:white;"><uc1:MailListSubscription ID="MailListSubscription1" runat="server" /></div>

    <%=GetCampaignText() %>	

	<a href="http://heavenbydeborahmitchell.wordpress.com/" target="_blank" title="Follow Deborah's blog" class="banner">
	    <img src="/images/banner-blog.png" id="imageBlog" runat="server" alt="Follow Deborah's blog for the latest news and tips" width="158" />
	</a>
				
	<a href="/Trade.aspx" title="Become a certified Heaven Stockist / Therapist" class="banner">
	    <img src="/images/banner-trade.gif" id="imageTrade" runat="server" alt="Join the ever growing community of Heaven Trade Advantage Clients" width="158" height="261" />
	</a>		
</div><!-- end of #leftColumn -->
