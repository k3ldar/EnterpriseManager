<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.Services.Index" %>

<%@ Register src="~/Controls/MediaLinks.ascx" tagname="MediaLinks" tagprefix="uc2" %>
<%@ register src="~/Controls/WebPageTags.ascx" tagprefix="uc1" tagname="WebPageTags" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Services %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
            <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Services/Index.aspx"><%=Languages.LanguageStrings.Services %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc3:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.Services %></h1>
				

				<div class="productDescription">
                    <p>
                        We offer a range of services to both small and medium sized companies, from bespoke software, 
                        custom web sites to software consultancy.  All our services are tailored to meet the needs of 
                        the client whilst reducing overall cost and maximising productivity.
                    </p>

                    <p>
                        We have many working and fully tested plug-in modules that may already be close to what you require, this further 
                        reduces development time and allows us to deliver our solutions within time and budget.
                    </p>

                    <p>
                        As a result of our expertise, we can define and develop very high performance and scalable solutions that will support 
                        our clients today and into the future.
                    </p>
				</div>

                <uc2:MediaLinks ID="MediaLinks1" runat="server" />
			    <%--<uc1:WebPageTags ID="WebPageTags1" runat="server" />--%>

				<div class="clear"><!-- clear --></div>
			</div><!-- end of #mainContent -->
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
