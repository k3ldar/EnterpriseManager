﻿<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tip.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Tips.Tip" %>
<%@ Register src="~/Controls/FeaturedProducts.ascx" tagname="FeaturedProducts" tagprefix="uc1" %>
<%@ Register src="~/Controls/MediaLinks.ascx" tagname="MediaLinks" tagprefix="uc2" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=GetTipName() %> - <%=Languages.LanguageStrings.TipsAndTricks %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/TipsnTricks.aspx"><%=Languages.LanguageStrings.TipsAndTricks %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Tips/Tip.aspx?ID=<%=GetFormValue("ID", 1) %>"><%=GetTipName() %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc3:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
				<h1><%=GetTipName() %></h1>
				
				<div class="clear"><!-- clear --></div>
				
				<p><%=GetTipDescription() %></p>
				
				<div class="pagination">
					<ul class="fixed">
						 <%=BuildPagination(Library.BOL.TipsTricks.TipsTricks.GetCount(), 1, GetFormValue("Page", 1), "/Tips/Tip.aspx")%>
					</ul>
				</div><!-- end of .pagination -->

                <uc2:MediaLinks ID="MediaLinks1" runat="server" />
                
				<uc1:FeaturedProducts ID="FeaturedProducts1" runat="server" />
                			    
                <uc2:WebPageTags ID="WebPageTags1" runat="server" />

			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
