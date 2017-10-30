<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="CampaignStats.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Reports.SEO.CampaignStats" %>
<%@ Register src="~/Controls/SeoCharts.ascx" tagname="SeoCharts" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Seo Basic Statistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type='text/javascript' src='https://maps.googleapis.com/maps/api/js?v=3&key=AIzaSyBDtmYlTGa71O_OyqX0JPXAToiwE_0QYIc'></script>
    <div class="content">
        <div class="breadcrumb">
            <ul class="fixed">
                <li><a href="/Index.aspx">Home</a></li>
                <li>&rsaquo;</li>
                <li><a href="/Staff/Index.aspx">Staff</a></li>
                <li>&rsaquo;</li>
                <li><a href="/Staff/Reports/Index.aspx">Reports</a></li>
                <li>&rsaquo;</li>
                <li><a href="/Staff/Reports/SEO/CampaignStats.aspx">Campaign Statistics</a></li>
            </ul>
        </div>
        <!-- end of #breadcrumb -->
        <div>
            <h1>Campaign</h1>
            <uc1:SeoCharts ID="chartCampaign" runat="server" />
        </div>
        <!-- end of #mainContent -->
        <div class="clear">
            <!-- clear -->
        </div>
    </div>
    <!-- end of #content -->


    <style type="text/css">
    .scrollFix { line-height: 1.35; white-space: nowrap; }
        .auto-style1 td
        {
            text-align: left;
            vertical-align: top;
        }
        .auto-style1 th strong
        {
            font-weight: 200;
            vertical-align: top;
        }
</style>
</asp:Content>
