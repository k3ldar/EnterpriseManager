<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Treatments.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.PageTreatments" %>

<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Treatments %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
                    <li><a href="/Treatments.aspx"><%=Languages.LanguageStrings.Treatments %></a></li>
                        <%=GetTreatmentGroupTagLine() %>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />

			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.Treatments %></h1>
				
				<%=GetTreatmentGroupTagLine() %>
                <p id="pViewBrochure" runat="server"><%=Languages.LanguageStrings.TreatmentsDescription %>&nbsp;
                    <a href="/Download/Ebooks/Treatments/Index.html" target="_blank"><%=Languages.LanguageStrings.PleaseViewBrochure %></a>
                </p>
                    <%=GetTreatments(6) %>
				
				<p><%=Languages.LanguageStrings.TreatmentTimes %></p>
				<div class="pagination">
					<ul class="fixed">
						 <%=BuildPagination(6)%>
					</ul>
				</div><!-- end of .pagination -->
			
                <uc2:WebPageTags ID="WebPageTags1" runat="server" />	
			</div><!-- end of #mainContent -->

			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
