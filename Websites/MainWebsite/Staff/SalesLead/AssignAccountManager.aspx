<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="AssignAccountManager.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.SalesLead.AssignAccountManager" %>
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
                <li><a href="/Staff/SalesLeads.aspx">Sales Tracker</a></li>
                <li>&rsaquo;</li>
                <li><a href="/Staff/SalesLead/Index.aspx?ClientID=<%=GetClientID() %>"><%=GetCustomerName() %></a></li>
			</ul>
				
		</div><!-- end of #breadcrumb -->
			
		<div class="mainContentStaff">
			<h1>Assign Account Manager for <%=GetCustomerName() %></h1>

            <div class="content form">
                <label>New Account Manager</label>
                <asp:DropDownList ID="lstStaff" runat="server">
                </asp:DropDownList>
                <br /><br />
                <asp:Button ID="btnAssignClient" runat="server" Text="Assign Account Manager" 
                    onclick="btnAssignClient_Click" />
            </div>
            <div>
                <h3>Contact Details</h3>
                <%=GetContactDetails() %>
            </div>
        </div>

        			
    	<div class="clear"><!-- clear --></div>

    </div>
</asp:Content>
