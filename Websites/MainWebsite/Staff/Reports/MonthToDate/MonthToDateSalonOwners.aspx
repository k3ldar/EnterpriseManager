<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="MonthToDateSalonOwners.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Reports.MonthToDate.MonthToDateSalonOwners" %>
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
                    <li>&rsaquo;</li>
                    <li>Month To Date</li>
					<li>&rsaquo;</li>
					<li><a href="/Staff/Reports/MonthToDate/MonthToDateSalonOwners.aspx">Sales - top salon owners</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Sales - Top Salon Owners</h1>
				
			    <p>
                The following charts shows Sales for the last 12 Months by Top 20 Salon Owners, the difference between current and previous year in £ and percent.
                </p>

                <p><strong>PLEASE NOTE:</strong> A Salon owner may also be a distributor, there is no current way of distinguishing sales for a distributor who also owns salons.</p>

              
              <p id="pPlaceHolder" runat="server"></p>

                
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
            
						
		</div><!-- end of #content -->
</asp:Content>
