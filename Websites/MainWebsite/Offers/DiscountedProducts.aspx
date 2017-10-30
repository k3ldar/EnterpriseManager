<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DiscountedProducts.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Offers.DiscountedProducts" %>

<%@ Register Src="~/Controls/LeftContainerControl.ascx" TagName="LeftContainerControl" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/BuyItNow.ascx" TagName="BuyItNow" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/MediaLinks.ascx" TagName="MediaLinks" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/css/Discounts.css" type="text/css" media="screen" />
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">
        <div class="breadcrumb">
            <ul class="fixed">
                <li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
                <li>&rsaquo;</li>
                <li>Offers</li>
                <li>&rsaquo;</li>
                <li><a href="/Offers/DiscountedProducts.aspx">Easter Offers</a></li>
            </ul>
        </div>
        <!-- end of #breadcrumb -->
        <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" ShowCampaign="false" />

        <div class="binMainContent">
            <div id="divDiscountedProducts" runat="server" class="binMainContent">

            </div>

            <div class="clear"></div>
            <uc3:MediaLinks ID="MediaLinks1" runat="server" />

            <div class="clear">
                <!-- clear -->
            </div>
        </div>
        <!-- end of #mainContent -->
        <div class="clear">
            <!-- clear -->
        </div>
    </div>
    <!-- end of #content -->
</asp:Content>
