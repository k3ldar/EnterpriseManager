<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true"
    CodeBehind="Charts.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Reports.Salon.Charts" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
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
                <li><a href="/Staff/Reports/Salon/Charts.aspx">Monthly Salon Chart</a></li>
            </ul>
        </div>
        <!-- end of #breadcrumb -->
        <div class="mainContentStaff">
            <h1>
                Monthly Salon Chart</h1>
            <div class="content">
                <p>
                    Select Month:<br />
                    <asp:DropDownList ID="lstMonth" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="lstMonth_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                </p>
                <p>
                    <asp:Chart ID="Chart1" runat="server" Width="800px" Height="600px" Palette="BrightPastel">
                        <Titles>
                            <asp:Title Font="Ariel, 14pt"></asp:Title>
                        </Titles>
                        <Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea"  AlignmentOrientation="Horizontal">
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1" Docking="Bottom" Alignment="Center" >
                            </asp:Legend>
                        </Legends>
                    </asp:Chart>
                </p>
            </div>
        </div>
        <!-- end of #mainContent -->
        <div class="clear">
            <!-- clear -->
        </div>
    </div>
    <!-- end of #content -->
</asp:Content>
