<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="Charts.aspx.cs" Inherits="SieraDelta.Website.Statistics.Charts" %>
<%@ Register TagPrefix="web" Namespace="WebChart" Assembly="WebChart" %>

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
					<li><a href="/Staff/Reports/Charts.aspx">Charts</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContent">
			
				<h1>Website Statistics</h1>
				
				<h3>Statistics</h3>
				
			    <p>
                    <asp:DropDownList ID="cmbChartType" runat="server" 
                        onselectedindexchanged="cmbChartType_SelectedIndexChanged" 
                        AutoPostBack="True">
                        <asp:ListItem Value="6">Sales Month To Date (Overall)</asp:ListItem>
                        <asp:ListItem Value="7">Sales Month To Date Invoice Count (Overall)</asp:ListItem>
                        <asp:ListItem Value="8">Sales Month To Date Online</asp:ListItem>
                        <asp:ListItem Value="9">Sales Month To Date Office</asp:ListItem>
                        <asp:ListItem Value="10">Sales Month To Date Salon (Shifnal)</asp:ListItem>
                        <asp:ListItem Value="13">Sales Month To Date (All Salons)</asp:ListItem>
                        <asp:ListItem Value="11">Sales Month To Date Top 5 Salons</asp:ListItem>
                        <asp:ListItem Value="12">Sales Month To Date Top 5 Countries</asp:ListItem>
                        <asp:ListItem Value="1">Invoice Totals By Month - Overall</asp:ListItem>
                        <asp:ListItem Value="2">Invoice Count By Day (Last 40 Days)</asp:ListItem>
                        <asp:ListItem Value="3">Visitors By Country (Top 10) [Very Slow]</asp:ListItem>
                        <asp:ListItem Value="4">Visitors By Country Today (Top 10)</asp:ListItem>
                        <asp:ListItem Value="5">Invoice Totals By Month (Last Year)</asp:ListItem>
                    </asp:DropDownList>
                </p>
                
                <p>
                
                <web:ChartControl id="ChartControl1" runat="server" BorderWidth="0px" 
                        BorderStyle="Outset" Width="700px"
														HasChartLegend="False" LeftChartPadding="40" BottomChartPadding="40" 
                        YValuesInterval="0" Padding="13" YCustomEnd="0" YCustomStart="0">
                                                        
                <Charts>
<web:LineChart DataXValueField="Date" Name="Line" DataYValueField="Total">
<DataLabels>

<Border Color="Transparent">
</Border>

<Background Color="Transparent">
</Background>

</DataLabels>
</web:LineChart>
<web:ScatterChart Name="Scatter">
<DataLabels>

<Border Color="Transparent">
</Border>

<Background Color="Transparent">
</Background>

</DataLabels>
</web:ScatterChart>
<web:ColumnChart Name="Column" ShowLineMarkers="False">
<DataLabels>

<Border Color="Transparent">
</Border>

<Background Color="Transparent">
</Background>

</DataLabels>
</web:ColumnChart>
</Charts>

<XTitle StringFormat="Far,Near,Character,LineLimit" Text="Date" Font="Tahoma, 8pt, style=Bold" 
                        ForeColor="White">
</XTitle>

<YAxisFont StringFormat="Far,Near,Character,LineLimit" Font="Tahoma, 8pt, style=Bold" 
                        ForeColor="115, 138, 156">
</YAxisFont>

                    <PlotBackground Color="#EEEEEE" />

<ChartTitle StringFormat="Near,Near,Character,LineLimit" Text="Total Website Users  by Hour" 
                        Font="Verdana, 10pt, style=Bold" ForeColor="DeepSkyBlue">
</ChartTitle>

<XAxisFont StringFormat="Center,Near,Character,LineLimit" Font="Tahoma, 8pt, style=Bold" 
                        ForeColor="115, 138, 156">
</XAxisFont>

                    <Border Color="222, 186, 132" Width="2" />

<Background Color="#000084" Angle="90" EndPoint="100, 400" ForeColor="Gainsboro" 
                        HatchStyle="DiagonalBrick" Type="LinearGradient">
</Background>

<YTitle StringFormat="Center,Near,Character,DirectionVertical" Text="Total" 
                        Font="Tahoma, 8pt, style=Bold" ForeColor="White">
</YTitle>
													</web:ChartControl>                                        
                                                      
                </p>
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
