<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.Helpdesk.PageIndex" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Helpdesk %> - <%=GetWebTitle()%></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
	<meta name="Keywords" content="<%=GetMetaKeyWords()%>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Helpdesk/Index.aspx"><%=Languages.LanguageStrings.Helpdesk %></a></li>
				</ul>
				
			</div><!-- end of .breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.Helpdesk %></h1>
				
				<p><%=Languages.LanguageStrings.HelpdeskDescription %></p>

				<ul class="helpOptions memberOptions fixed">
					<li class="submit"><a href="/Helpdesk/Tickets/Submit.aspx"><%=Languages.LanguageStrings.SubmitATicket %></a></li>
					<li class="find"><a href="/Helpdesk/Tickets/Find.aspx"><%=Languages.LanguageStrings.FindATicket %></a></li>
                    <li class="faq"><a href="/Helpdesk/FAQ/Index.aspx"><%=Languages.LanguageStrings.FrequentlyAskedQuestions %></a></li>
                    <li class="feedback"><a href="/Helpdesk/Feedback/"><%=Languages.LanguageStrings.Feedback %></a></li>
				</ul>
				
			</div><!-- end of .mainContent -->
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of .content -->
</asp:Content>
