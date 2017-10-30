<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="BoxingDay.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Offers.BoxingDay" %>

<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/BuyItNow.ascx" TagName="BuyItNow" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/MediaLinks.ascx" TagName="MediaLinks" TagPrefix="uc3" %>
<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.BoxingDayOffers %> - <%=Languages.LanguageStrings.SpecialOffers %> - <%=GetWebTitle()%></title>

    <%=GetMailChimpPopupIntegration() %>

    <link rel="stylesheet" href="<%=GetBuyitNowCSSLink() %>" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- Main Content -->
    <div class="content">
        <div class="breadcrumb">
            <ul class="fixed">
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><%=Languages.LanguageStrings.SpecialOffers %></li>
                <li>&rsaquo;</li>
                <li><a href="/Offers/BoxingDay.aspx"><%=Languages.LanguageStrings.BoxingDayOffers %></a></li>
            </ul>
        </div>
        <!-- end of #breadcrumb -->
        <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" ShowCampaign="false" />

        <div class="binMainContent">
            <h1><%=Languages.LanguageStrings.BoxingDayOffers %></h1>
                
            <div id="divBuyItNowItems" runat="server">
            </div>

            <div class="clear">
                <!-- clear -->
            </div>
                        
            <div class="clear"></div>
            <uc3:MediaLinks ID="MediaLinks1" runat="server" />
            <uc2:WebPageTags ID="WebPageTags1" runat="server" />

            <div class="clear">
                <!-- clear -->
            </div>
        </div>
        <!-- end of #mainContent -->
        <!-- Main Content End -->
    </div>

            <div class="clear">
                <!-- clear -->
            </div>
</asp:Content>
