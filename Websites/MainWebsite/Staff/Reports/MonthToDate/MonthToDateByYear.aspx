<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="MonthToDateByYear.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Statistics.MonthToDateByYear" %>
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
					<li><a href="/Staff/Reports/MonthToDate/MonthToDateByYear.aspx">Month To Date by Year</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Sales</h1>
				
                <div class="content form">
                    <label>Year:</label> 
                    <asp:DropDownList ID="ddlYears" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYears_SelectedIndexChanged">
                    </asp:DropDownList><br />
                    <label>Country:</label>
                    <asp:DropDownList ID="ddlCountries" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYears_SelectedIndexChanged">
                    </asp:DropDownList><br />
                </div>
				<h3>Month To Date - Overall</h3>
				
			    <p>
                The following chart shows Sales for the selected year, the difference between current and previous year in £ and percent.
                </p>
                    <asp:Table ID="tblMtD" runat="server" class="tblMTD">
                        <asp:TableHeaderRow ID="tblMTDHeader" runat="server" class="tblMTD th">
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow ID="tblMTDCurrentRow" runat="server" class="tblMTD th">
                            <asp:TableCell>Current</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblMTDPreviousRow" runat="server">
                            <asp:TableCell>Previous</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblMTDDiffRow" runat="server">
                            <asp:TableCell>Difference</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblMTDPercent" runat="server">
                            <asp:TableCell>%</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>


                <h3>Month To Date - Online</h3>
				
			    <p>
                The following chart shows Sales for the last 12 Months, the difference between current and previous year in £ and percent.
                </p>
                    <asp:Table ID="tblMTDOnline" runat="server" class="tblMTD">
                        <asp:TableHeaderRow ID="tblMTDOnlineHeader" runat="server" class="tblMTD th">
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow ID="tblMTDOnlineCurrentRow" runat="server" class="tblMTD th">
                            <asp:TableCell>Current</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblMTDOnlinePreviousRow" runat="server">
                            <asp:TableCell>Previous</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblMTDOnlineDiffRow" runat="server">
                            <asp:TableCell>Difference</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblMTDOnlinePercent" runat="server">
                            <asp:TableCell>%</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>


				<h3>Month To Date - Salon</h3>
				
			    <p>
                The following chart shows Sales for the last 12 Months, the difference between current and previous year in £ and percent.
                </p>
                    <asp:Table ID="tblMTDSalon" runat="server" class="tblMTD">
                        <asp:TableHeaderRow ID="tblMTDSalonHeader" runat="server" class="tblMTD th">
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow ID="tblMTDSalonCurrentRow" runat="server" class="tblMTD th">
                            <asp:TableCell>Current</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblMTDSalonPreviousRow" runat="server">
                            <asp:TableCell>Previous</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblMTDSalonDiffRow" runat="server">
                            <asp:TableCell>Difference</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblMTDSalonPercent" runat="server">
                            <asp:TableCell>%</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>


				<h3>Month To Date - Office</h3>
				
			    <p>
                The following chart shows Sales for the last 12 Months, the difference between current and previous year in £ and percent.
                </p>
                    <asp:Table ID="tblMTDOffice" runat="server" class="tblMTD">
                        <asp:TableHeaderRow ID="tblMTDOfficeHeader" runat="server" class="tblMTD th">
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow ID="tblMTDOfficeCurrentRow" runat="server" class="tblMTD th">
                            <asp:TableCell>Current</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblMTDOfficePreviousRow" runat="server">
                            <asp:TableCell>Previous</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblMTDOfficeDiffRow" runat="server">
                            <asp:TableCell>Difference</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="tblMTDOfficePercent" runat="server">
                            <asp:TableCell>%</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
            
						
		</div><!-- end of #content -->
</asp:Content>
