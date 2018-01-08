<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.Reports.Index" %>
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
                    <li><a href="/Staff/Reports/Index.aspx">Reports</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Reports</h1>

                <h3>Active Users</h3>
                <p><a href="/Staff/Reports/SEO/VisitorLocations.aspx">Active Visitor Locations (map)</a></p>
                <p><a href="/Staff/Reports/SEO/VisitorDetails.aspx">Active Visitor Details</a></p>

                <h3>Meta Data and SEO</h3>
                <p>The following report will show products without SEO data</p>
                <p><a href="/Staff/SEO/Index.aspx">SEO Report</a></p>

                <h3>Annotated Reports</h3>
                <p>The following report using annotations to depict different time line events</p>
                <p><a href="/Staff/Reports/SalesEvents.aspx">Sales with Events</a></p>

                <h3>Month To Date</h3>
                <p><a href="/Staff/Reports/MonthToDate/MonthToDate.aspx">Sales Month To Date</a></p>
                <p><a href="/Staff/Reports/MonthToDate/MonthToDateTop5.aspx">Sales Month To Date - Top 5 Countries</a></p>
                <p><a href="/Staff/Reports/MonthToDate/MonthToDateBySalon.aspx">Sales Month To Date - By Salons</a></p>
                <p><a href="/Staff/Reports/MonthToDate/MonthToDateSalonOwners.aspx">Sales Month To Date - Top Salon Owners</a></p>

                <h3>Charts</h3>
                <p><a href="/Staff/Reports/Charts.aspx">View More Statistics</a></p>

                <h3>Stock Control</h3>
                <p>Please select the location to view current Stock.</p>
                <ul>
                    <li><a href="/Staff/Reports/Stock/StockControl.aspx?ID=1">The Mill</a></li>
                    <li><a href="/Staff/Reports/Stock/StockControl.aspx?ID=3">Salon</a></li>
                </ul>

                <h3>Salon</h3>
                <ul>
                    <li><a href="/Staff/Reports/Salon/SalonDaily.aspx">Daily Breakdown</a></li>
                    <li><a href="/Staff/Reports/Salon/SalonMonthly.aspx">Monthly Breakdown</a></li>
                    <li><a href="/Staff/Reports/Salon/Charts.aspx">Monthly Charts</a></li>
                </ul>

                <h3>Customer Activity Report</h3>
				
				<p>Please enter the users email address</p>
				

                <label>Email</label>
                <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox>
                <asp:Button ID="btnView" runat="server" Text="View" onclick="btnView_Click" />
												
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
