<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="SieraDelta.Website.Helpdesk.Feedback" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Feedback %> - <%=Languages.LanguageStrings.Helpdesk %> - <%=GetWebTitle()%></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
	<meta name="Keywords" content="<%=GetMetaKeyWords()%>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
				<ul class="fixed">
					<li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Help-Desk/"><%=Languages.LanguageStrings.Helpdesk %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Help-Desk/Feedback/"><%=Languages.LanguageStrings.Feedback %></a></li>
				</ul>
				
			</div><!-- end of .breadcrumb -->
			
			
			<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />			
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.Feedback %></h1>
				
				<p><%=Languages.LanguageStrings.HelpdeskFeedbackDescription %> <a href="/Help-Desk/Feedback/Leave/"><%=Languages.LanguageStrings.ClickHere %></a>.</p>
				
                <%=GetFeedback() %>
				
				<div class="pagination">
					<ul class="fixed">
						<%=BuildPagination(Library.BOL.Helpdesk.CustomerComments.GetCount(), 6, GetFormValue("Page", 1), "/Help-Desk/Feedback/", true) %>
					</ul>
				</div><!-- end of .pagination -->
												
			</div><!-- end of .mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of .content -->
</asp:Content>
