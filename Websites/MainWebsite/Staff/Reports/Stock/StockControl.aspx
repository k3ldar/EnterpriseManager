<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="StockControl.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Reports.StockControl" %>
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
                    <li><a href="/Staff/Reports/Stock/StockControl.aspx?ID=<%=GetLocationID() %>"><%=GetLocationName() %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Current Stock</h1>

                <h3><%=GetLocationName() %></h3>
                <p>
                    Product Type<br />
                    <asp:DropDownList ID="cmbProductType" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <br /><br />
                    <asp:Button ID="btnDownload" runat="server" Text="Download" 
                        onclick="btnDownload_Click" /><br /><br />
                </p>

			    <table id="tblStock" runat="server" class="tblStock">
                    <thead>
                      <tr>
                        <th class="textLeft">SKU</th>
                        <th class="textLeft">Product</th> 
                        <th class="textLeft">Size</th>
                        <th class="textCenter">Quantity</th>
                        <th class="textCenter">Minimum Level</th>
                        <th class="textCenter">Re-Order Quantity</th>
                        <th class="textLeft">Type</th>
                      </tr>
                    </thead>
                </table>
												
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
