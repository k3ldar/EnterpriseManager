﻿<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Distributors.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.PageDistributors" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Distributors %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Distributors.aspx"><%=Languages.LanguageStrings.Distributors %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.Distributors %></h1>
				
				<p id="pDescriptionA" runat="server"></p>
				
				<h5 id="headerSalons" runat="server"><%=Languages.LanguageStrings.Salons %></h5>
				
				<p id="salonsDescription" runat="server"><%=Languages.LanguageStrings.DistributorsDescriptionB %></p>			
				
				<ul class="salonList">
                    <%=BuildDistributorList()%>
				</ul>
				
				
				<div class="pagination">
					<ul class="fixed">
                        <%=BuildPagination(Library.BOL.Distributors.Distributors.GetCount(), 6, GetFormValue("Page", 1), "/Distributors.aspx")%>
					</ul>
				</div><!-- end of .pagination -->

                <uc2:WebPageTags ID="WebPageTags1" runat="server" />

			</div><!-- end of #mainContent -->
			<div class="clear"><!-- clear --></div>
		</div><!-- end of #content -->
</asp:Content>
