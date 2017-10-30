<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="MonthToDateTop10.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Statistics.MonthToDateTop10" %>
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
					<li><a href="/Staff/Reports/MonthToDate/MonthToDateTop10.aspx">Sales - top 10 Countries</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Sales - Top 10 Countries</h1>
				
			    <p>
                The following charts shows Sales for the last 12 Months by Top 10 countries, the difference between current and previous year in £ and percent.
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

                  <h3 id="hMTDTop56" runat="server">Month To Date</h3>
                    <asp:Table ID="tblMTDTop56" runat="server" class="tblMTD">
                        <asp:TableHeaderRow ID="TableHeaderRow6" runat="server" class="tblMTD th">
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow ID="TableRow21" runat="server" class="tblMTD th">
                            <asp:TableCell>Current</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow22" runat="server">
                            <asp:TableCell>Previous</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow23" runat="server">
                            <asp:TableCell>Difference</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow24" runat="server">
                            <asp:TableCell>%</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                  <h3 id="hMTDTop57" runat="server">Month To Date</h3>
                    <asp:Table ID="tblMTDTop57" runat="server" class="tblMTD">
                        <asp:TableHeaderRow ID="TableHeaderRow7" runat="server" class="tblMTD th">
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow ID="TableRow25" runat="server" class="tblMTD th">
                            <asp:TableCell>Current</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow26" runat="server">
                            <asp:TableCell>Previous</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow27" runat="server">
                            <asp:TableCell>Difference</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow28" runat="server">
                            <asp:TableCell>%</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                  <h3 id="hMTDTop58" runat="server">Month To Date</h3>
                    <asp:Table ID="tblMTDTop58" runat="server" class="tblMTD">
                        <asp:TableHeaderRow ID="TableHeaderRow8" runat="server" class="tblMTD th">
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow ID="TableRow29" runat="server" class="tblMTD th">
                            <asp:TableCell>Current</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow30" runat="server">
                            <asp:TableCell>Previous</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow31" runat="server">
                            <asp:TableCell>Difference</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow32" runat="server">
                            <asp:TableCell>%</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                  <h3 id="hMTDTop59" runat="server">Month To Date</h3>
                    <asp:Table ID="tblMTDTop59" runat="server" class="tblMTD">
                        <asp:TableHeaderRow ID="TableHeaderRow9" runat="server" class="tblMTD th">
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow ID="TableRow33" runat="server" class="tblMTD th">
                            <asp:TableCell>Current</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow34" runat="server">
                            <asp:TableCell>Previous</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow35" runat="server">
                            <asp:TableCell>Difference</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow36" runat="server">
                            <asp:TableCell>%</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                  <h3 id="hMTDTop510" runat="server">Month To Date</h3>
                    <asp:Table ID="tblMTDTop510" runat="server" class="tblMTD">
                        <asp:TableHeaderRow ID="TableHeaderRow10" runat="server" class="tblMTD th">
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow ID="TableRow37" runat="server" class="tblMTD th">
                            <asp:TableCell>Current</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow38" runat="server">
                            <asp:TableCell>Previous</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow39" runat="server">
                            <asp:TableCell>Difference</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow40" runat="server">
                            <asp:TableCell>%</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
            
						
		</div><!-- end of #content -->
</asp:Content>
