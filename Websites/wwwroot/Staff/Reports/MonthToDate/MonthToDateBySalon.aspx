<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="MonthToDateBySalon.aspx.cs" Inherits="SieraDelta.Website.Staff.Statistics.MonthToDateBySalon1" %>
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
					<li><a href="/Staff/Reports/MonthToDate/MonthToDateBySalon.aspx">Month To Date By Salon</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Sales</h1>
				
				<h3>Month To Date By Salon</h3>
				
			    <p>
                The following chart shows Sales for the last 12 Months, for Salons, the difference between current and previous year in £ and percent.
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

                <h1>Top 5 Salons by Sales</h1>

			    <p>
                The following charts shows Sales for the last 12 Months by Top 5 Salons, the difference between current and previous year in £ and percent.
                </p>

                <h3 id="hMTDTop51" runat="server">Month To Date</h3>
                    <asp:Table ID="tblMTDTop51" runat="server" class="tblMTD">
                        <asp:TableHeaderRow ID="TableHeaderRow1" runat="server" class="tblMTD th">
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow ID="TableRow1" runat="server" class="tblMTD th">
                            <asp:TableCell>Current</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow2" runat="server">
                            <asp:TableCell>Previous</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow3" runat="server">
                            <asp:TableCell>Difference</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow4" runat="server">
                            <asp:TableCell>%</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
              
                 <h3 id="hMTDTop52" runat="server">Month To Date</h3>
                    <asp:Table ID="tblMTDTop52" runat="server" class="tblMTD">
                        <asp:TableHeaderRow ID="TableHeaderRow2" runat="server" class="tblMTD th">
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow ID="TableRow5" runat="server" class="tblMTD th">
                            <asp:TableCell>Current</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow6" runat="server">
                            <asp:TableCell>Previous</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow7" runat="server">
                            <asp:TableCell>Difference</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow8" runat="server">
                            <asp:TableCell>%</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                  <h3 id="hMTDTop53" runat="server">Month To Date</h3>
                    <asp:Table ID="tblMTDTop53" runat="server" class="tblMTD">
                        <asp:TableHeaderRow ID="TableHeaderRow3" runat="server" class="tblMTD th">
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow ID="TableRow9" runat="server" class="tblMTD th">
                            <asp:TableCell>Current</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow10" runat="server">
                            <asp:TableCell>Previous</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow11" runat="server">
                            <asp:TableCell>Difference</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow12" runat="server">
                            <asp:TableCell>%</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                  <h3 id="hMTDTop54" runat="server">Month To Date</h3>
                    <asp:Table ID="tblMTDTop54" runat="server" class="tblMTD">
                        <asp:TableHeaderRow ID="TableHeaderRow4" runat="server" class="tblMTD th">
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow ID="TableRow13" runat="server" class="tblMTD th">
                            <asp:TableCell>Current</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow14" runat="server">
                            <asp:TableCell>Previous</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow15" runat="server">
                            <asp:TableCell>Difference</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow16" runat="server">
                            <asp:TableCell>%</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                  <h3 id="hMTDTop55" runat="server">Month To Date</h3>
                    <asp:Table ID="tblMTDTop55" runat="server" class="tblMTD">
                        <asp:TableHeaderRow ID="TableHeaderRow5" runat="server" class="tblMTD th">
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow ID="TableRow17" runat="server" class="tblMTD th">
                            <asp:TableCell>Current</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow18" runat="server">
                            <asp:TableCell>Previous</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow19" runat="server">
                            <asp:TableCell>Difference</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow20" runat="server">
                            <asp:TableCell>%</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
            
						
		</div><!-- end of #content -->
</asp:Content>
