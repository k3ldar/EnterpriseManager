<%@ Page validaterequest="false" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="LeaveFeedback.aspx.cs" Inherits="SieraDelta.Website.Helpdesk.Comments.LeaveFeedback" %>
<%@ Register src="~/Controls/VerificationImage.ascx" tagname="VerificationImage" tagprefix="uc1" %>
<%@ Register src="~/Helpdesk/Controls/LeaveFeedback.ascx" tagname="LeaveFeedback" tagprefix="uc2" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.LeaveFeedback %> - <%=Languages.LanguageStrings.Helpdesk %> - <%=GetWebTitle()%></title>
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
					<li>&rsaquo;</li>
					<li><a href="/Helpdesk/Feedback/"><%=Languages.LanguageStrings.Feedback %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Helpdesk/Comments/LeaveFeedback.aspx"><%=Languages.LanguageStrings.LeaveFeedback %></a></li>
				</ul>
				
			</div><!-- end of .breadcrumb -->
			
			
			<uc3:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.Feedback %></h1>
				
				<p><%=Languages.LanguageStrings.HelpdeskLeaveFeedbackDescription %></p>
                <p><%=Languages.LanguageStrings.NotSupportArea %> <a href="/Helpdesk/Tickets/Submit.aspx"><%=Languages.LanguageStrings.SupportTicket %></a></p>
				
                <uc2:LeaveFeedback ID="LeaveFeedback1" runat="server" />
                <p></p>
                <p><%=Languages.LanguageStrings.AbridgedWarning %></p>			
			</div><!-- end of .mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of .content -->
</asp:Content>
