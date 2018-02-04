<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftContainerControl.ascx.cs" Inherits="SieraDelta.Website.Controls.LeftContainerControl" %>

<div id="divMobileShowColumn" runat="server" class="mobileShowColumn">
    <img src="/images/showtoolbar.png" onclick="openToolbar()" alt="Toolbar"/>
</div>

<div class="leftColumn" id="leftToolbar">
    <a id="adivClose" runat="server" href="javascript:void(0)" class="closebtn" onclick="closeToolbar()">&times;</a>
          
    <h5 id="subHeader" runat="server" visible="false">sub header</h5>
				
    <ul id="subOptions" runat="server" visible="false">
        
    </ul>

    <div id="subOptionsOther" runat="server" visible="false"></div>

    <%=GetPrefixPageBanners() %>

    <%=GetCampaignText() %>	

    <%=GetSuffixPageBanners() %>
	<!--<a href="https://www.sieradelta.com/blog/" target="_blank" title="Follow SieraDelta blog" class="banner">
	    <img src="/images/banner-blog.png" alt="Follow SieraDelta blog" width="158" height="351" />
	</a>-->
</div><!-- end of #leftColumn -->

