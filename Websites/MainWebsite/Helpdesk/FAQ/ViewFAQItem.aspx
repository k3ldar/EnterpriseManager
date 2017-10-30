<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewFAQItem.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Helpdeks.FAQ.ViewFAQItem" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.FrequentlyAskedQuestions %> <%=GetItemName() %> - <%=Languages.LanguageStrings.Helpdesk %> - <%=GetWebTitle()%></title>
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
					<li><a href="/Helpdesk/FAQ/Index.aspx"><%=Languages.LanguageStrings.FrequentlyAskedQuestions %></a></li>
					<li>&rsaquo;</li>
                    <%=GroupBreadCrumb() %>
				</ul>
				
			</div><!-- end of .breadcrumb -->
			

            <uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			
			<div class="mainContent">
			
				<h1><%=GetItemName()%></h1>
				
                <div class="faq">		
	                
                    <%=GetItem() %>
                    
                </div>

		</div><!-- end of .mainContent -->
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of .content -->
</asp:Content>
