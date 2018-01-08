<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="SupportTickets.aspx.cs" Inherits="SieraDelta.Website.Members.SupportTickets" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>

<%@ Register src="Controls/ProfileSupportTickets.ascx" tagname="ProfileSupportTickets" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.SupportTickets %> - <%=Languages.LanguageStrings.MyAccount %> - <%=GetWebTitle()%></title>
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
					<li><a href="/Members/SupportTickets.aspx"><%=Languages.LanguageStrings.MySupportTickets %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />			
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.SupportTickets %></h1>
				
                <p><%=Languages.LanguageStrings.SupportTicketDescription %></p>

                <p><strong><%=Languages.LanguageStrings.TotalSupportTickets %></strong>: <%=SupportTicketCount() %></p>
			
            	<uc1:ProfileSupportTickets ID="ProfileSupportTickets1" runat="server" />
                
                <div class="pagination">
					<ul class="fixed">
						 <%=BuildPagination(SupportTicketCount(), 10, GetFormValue("Page", 1), "/Members/SupportTickets.aspx")%>
					</ul>
				</div><!-- end of .pagination -->
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
