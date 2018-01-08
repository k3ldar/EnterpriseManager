<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="SieraDelta.Website.Members.Orders" %>
<%@ Register src="~/Members/Controls/ProfileOrders.ascx" tagname="ProfileOrders" tagprefix="uc1" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Orders %> - <%=Languages.LanguageStrings.MyAccount %> - <%=GetWebTitle()%></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
	<meta name="Keywords" content="<%=GetMetaKeyWords()%>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/Index.aspx"><%=Languages.LanguageStrings.MyAccount %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/Orders.aspx"><%=Languages.LanguageStrings.Orders %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
			<h1><%=Languages.LanguageStrings.MyOrders %></h1>
			    
                <p><%=Languages.LanguageStrings.OrdersDescription %></p>

                <p><strong><%=Languages.LanguageStrings.TotalOrders %></strong>: <%=Library.BOL.Orders.Orders.GetCount(GetUser()) %></p>
			
            	<uc1:ProfileOrders ID="ProfileOrders1" runat="server" />

            	<div class="pagination">
					<ul class="fixed">
						 <%=BuildPagination(Library.BOL.Orders.Orders.GetCount(GetUser()), 10, GetFormValue("Page", 1), "/Members/Orders.aspx")%>
					</ul>
				</div><!-- end of .pagination -->
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
