<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.Staff.Campaigns.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Home/">Home</a></li>
					<li>&rsaquo;</li>
					<li><a href="/Staff/Index.aspx">Staff</a></li>
					<li>&rsaquo;</li>
					<li><a href="/Staff/Campaigns/Index.aspx">Campaigns</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Website Advertising Campaigns</h1>

                <asp:Table ID="tblCampaigns" runat="server" Width="100%" CssClass="tblSalesLeads" BorderWidth="0px">
                    <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Campaign</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Total Visits</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Total Invoices</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Total Sales</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
				
            </div><!-- end of #mainContent -->
			
            <div class="form">
                <p id="pError" runat="server"></p>
                <asp:Button ID="btnNew" runat="server" Text="New Campaign" 
                    onclick="btnNew_Click" />
            </div>
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
