<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cm.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Offers.cm" %>

<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/BuyItNow.ascx" TagName="BuyItNow" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/MediaLinks.ascx" TagName="MediaLinks" TagPrefix="uc3" %>
<%@ Register Src="~/Controls/WebPageTags.ascx" TagName="WebPageTags" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/BuyItNow.css" type="text/css" media="screen" />
    <title><%=GetCampaignName() %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">
        <div class="breadcrumb">
            <ul class="fixed">
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li><%=Languages.LanguageStrings.Offers %></li>
                <li>&rsaquo;</li>
                <li><a href="/Offers/cm.aspx?cmp=<%=GetCampaignURL() %>"><%=GetCampaignName() %></a></li>
            </ul>
        </div>
        <!-- end of #breadcrumb -->
        <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" ShowCampaign="false" />

        <div class="binMainContent">
            <h1><%=GetCampaignName() %></h1>
            <p class="binProductDescription" id="pDescription" runat="server">&nbsp;</p>
                
            <uc2:BuyItNow ID="BuyItNow1" runat="server" Image="/Images/Offers/MothersDay2014_178.png" UseProductName="false" PriceFontColour="#FF0000"
                    Contains="This gift set has all the luxuries a mother wants and needs, from heavenly hands, to products that will deliver an instant, beautiful and radiant complexion." ProductID="1797" />

            <uc2:BuyItNow ID="BuyItNow2" runat="server" Image="/Images/Offers/MothersDay2014_178.png" UseProductName="false" PriceFontColour="#FF0000"
                    Contains="This gift set has all the luxuries a mother wants and needs, from heavenly hands, to products that will deliver an instant, beautiful and radiant complexion." ProductID="1797" />

            <uc2:BuyItNow ID="BuyItNow3" runat="server" Image="/Images/Offers/MothersDay2014_178.png" UseProductName="false" PriceFontColour="#FF0000"
                    Contains="This gift set has all the luxuries a mother wants and needs, from heavenly hands, to products that will deliver an instant, beautiful and radiant complexion." ProductID="1797" />

            <uc2:BuyItNow ID="BuyItNow4" runat="server" Image="/Images/Offers/MothersDay2014_178.png" UseProductName="false" PriceFontColour="#FF0000"
                    Contains="This gift set has all the luxuries a mother wants and needs, from heavenly hands, to products that will deliver an instant, beautiful and radiant complexion." ProductID="1797" />


            <p class="binProductDescription"><img runat="server" id="imgPromotion" /></p>

            <div class="clear"></div>


            <uc3:MediaLinks ID="MediaLinks1" runat="server" />
            <uc2:WebPageTags ID="WebPageTags1" runat="server" />

            <div class="clear">
                <!-- clear -->
            </div>
        </div>
        <!-- end of #mainContent -->
        <div class="clear">
            <!-- clear -->
        </div>
    </div>
</asp:Content>
