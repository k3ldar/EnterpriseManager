<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.PageIndex" %>
<%@ Register src="~/Controls/MediaLinks.ascx" tagname="MediaLinks" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=GetWebTitle()%></title>
        

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
        <div class="featureWrapper">
			<div class="feature">
				<div class="slider-wrapper theme-default">
					<div class="ribbon"></div>
					<div class="slider nivoSlider">
                        <%=GetHomePageImages(700, 320, true)%>
					</div>
				</div>
			</div>
        </div><!-- end of #feature -->
			
        <div class="clear">
            <!-- clear -->
        </div>

        <p>
            We offer a range of services to both small and medium sized companies, from bespoke software, custom web sites to software consultancy. All our services are tailored to meet the needs of the client whilst reducing overall cost and maximising productivity. 
        </p>
        <div class="featureWrapper">
			<div class="banners">
			
				<a href="/Services/BespokeSoftware.aspx" class="banner1" title="<%=Languages.LanguageStrings.Banner1Name %>">
					<div class="overlay"><h6><%=Languages.LanguageStrings.Banner1Description %></h6></div>
					<span><strong><%=Languages.LanguageStrings.Banner1Name %></strong></span>
				</a>
     		    <a href="/Products/WebDefenderServer.aspx" class="banner2" title="<%=Languages.LanguageStrings.ServerProtection %>">
					<div class="overlay"><h6><%=Languages.LanguageStrings.ServerProtectionDescription %></h6></div>
					<span><strong><%=Languages.LanguageStrings.ServerProtection %></strong></span>
				</a>
     		    <a href="/Modules/Index.aspx" class="banner3" title="<%=Languages.LanguageStrings.FreeSoftware %>">
					<div class="overlay"><h6><%=Languages.LanguageStrings.FreeSoftwareDescription %></h6></div>
					<span><strong><%=Languages.LanguageStrings.FreeSoftware %></strong></span>
				</a>
           
				<div class="clear"><!-- clear --></div>
			</div><!-- end of #banners -->
		</div>
				<uc1:MediaLinks ID="MediaLinks1" runat="server" class="CenteredDiv" />

		</div><!-- end of #content -->

</asp:Content>
