<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="SalonMonthly.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Reports.Salon.SalonMonthly" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
		<div class="contentStaff">
			
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
                    <li><a href="/Staff/Reports/Salon/SalonMonthly.aspx">Monthly Salon Report</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Monthly Salon Report</h1>

                <div  class="content form">
                <p>
                    Select Month:<br />
                    <asp:DropDownList ID="lstMonth" runat="server">
                    </asp:DropDownList>
                    <br />
                    <asp:Button ID="btnView" runat="server" Text="View" onclick="btnView_Click" 
                        CssClass="left" />
                </p>
                </div>
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
