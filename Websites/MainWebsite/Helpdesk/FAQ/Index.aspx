﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Helpdesk.FAQ.Index" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.FrequentlyAskedQuestions %> - <%=Languages.LanguageStrings.Helpdesk %> - <%=GetWebTitle()%></title>
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
                    <%=GroupBreadCrumb() %>
				</ul>
				
			</div><!-- end of .breadcrumb -->
			

            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />

			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.FrequentlyAskedQuestions %></h1>

				<p><%=Languages.LanguageStrings.HelpdeskFAQDescription %></p>
				
                <div class="faq faqGroupList">		
	                <ul>
                        <%=GetGroups() %>
                    </ul>
                </div>
		</div><!-- end of .mainContent -->

            
 			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of .content -->
</asp:Content>
