<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="SEOBasicStats.aspx.cs" Inherits="SieraDelta.Website.Staff.SEO.SEOBasicStats" %>
<%@ Register src="~/Controls/SeoCharts.ascx" tagname="SeoCharts" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Seo Basic Statistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type='text/javascript' src='https://maps.googleapis.com/maps/api/js?v=3&key=AIzaSyBDtmYlTGa71O_OyqX0JPXAToiwE_0QYIc'></script>
    <div class="content">
        <div class="breadcrumb">
            <ul class="fixed">
                <li><a href="/Home/">Home</a></li>
                <li>&rsaquo;</li>
                <li><a href="/Staff/Index.aspx">Staff</a></li>
                <li>&rsaquo;</li>
                <li><a href="/Staff/Reports/Index.aspx">Reports</a></li>
                <li>&rsaquo;</li>
                <li><a href="/Staff/SEO/SEOBasicStats.aspx">SEO Basic Statistics</a></li>
            </ul>
        </div>
        <!-- end of #breadcrumb -->
        <div>
            <h1>SEO Hourly Users</h1>
            <uc1:SeoCharts ID="chartHourlyUsers" runat="server" />
            <uc1:SeoCharts ID="chartDailyUsers" runat="server" />
            <uc1:SeoCharts ID="chartWeeklyUsers" runat="server" />
            <uc1:SeoCharts ID="chartMonthlyUsers" runat="server" />

            <h1>SEO Hourly Sales</h1>
            <uc1:SeoCharts ID="chartSalesHourly" runat="server" />
            <uc1:SeoCharts ID="chartSalesDaily" runat="server" />
            <uc1:SeoCharts ID="chartSalesWeekly" runat="server" />
            <uc1:SeoCharts ID="chartSalesMonthly" runat="server" />

            <h1>SEO Conversions</h1>
            <uc1:SeoCharts ID="chartConvertHourly" runat="server" />
            <uc1:SeoCharts ID="chartConvertDaily" runat="server" />
            <uc1:SeoCharts ID="chartConvertWeekly" runat="server" />
            <uc1:SeoCharts ID="chartConvertMonthly" runat="server" />

            <h1>Referral Generic</h1>
            <uc1:SeoCharts ID="chartReferGenHourly" runat="server" />
            <uc1:SeoCharts ID="chartReferGenDaily" runat="server" />
            <uc1:SeoCharts ID="chartReferGenWeekly" runat="server" />
            <uc1:SeoCharts ID="chartReferGenMonthly" runat="server" />

            <h1>Referral Specific</h1>
            <uc1:SeoCharts ID="chartReferSpHourly" runat="server" />
            <uc1:SeoCharts ID="chartReferSpDaily" runat="server" />
            <uc1:SeoCharts ID="chartReferSpWeekly" runat="server" />
            <uc1:SeoCharts ID="chartReferSpMonthly" runat="server" />

            <h1>SEO Bot Visits</h1>
            <uc1:SeoCharts ID="chartBotDaily" runat="server" />
            <uc1:SeoCharts ID="chartBotWeekly" runat="server" />
            <uc1:SeoCharts ID="chartBotMonthly" runat="server" />

            <h1>Visit By Country</h1>
            <uc1:SeoCharts ID="chartVisitsByCountry" runat="server" />
            <uc1:SeoCharts ID="chartVisitsByCountryPrevious" runat="server" />

            <h1>Visit By City</h1>
            <uc1:SeoCharts ID="chartVisitsByCity" runat="server" />
            <uc1:SeoCharts ID="chartVisitsByCityPrevious" runat="server" />

            <h1>Sales By Country</h1>
            <uc1:SeoCharts ID="chartSalesByCountry" runat="server" />
            <uc1:SeoCharts ID="chartSalesByCountryPrevious" runat="server" />

            <h1>Sales By City</h1>
            <uc1:SeoCharts ID="chartSalesByCity" runat="server" />
            <uc1:SeoCharts ID="chartSalesByCityPrevious" runat="server" />
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
