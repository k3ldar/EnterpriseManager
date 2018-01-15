<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Licences.aspx.cs" Inherits="SieraDelta.Website.Members.Licences" %>
<%@ Register src="~/Members/Controls/ProfileLicences.ascx" tagname="ProfileLicences" tagprefix="uc1" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>
<%@ register src="~/Members/Controls/LicenceRequestTrial.ascx" tagprefix="uc1" tagname="LicenceRequestTrial" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Licences %> - <%=Languages.LanguageStrings.MyAccount %> - <%=GetWebTitle()%></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
	<meta name="Keywords" content="<%=GetMetaKeyWords()%>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Account/"><%=Languages.LanguageStrings.MyAccount %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Account/Licences/"><%=Languages.LanguageStrings.MyLicences %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />			
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.MyLicences %></h1>
				
                <p><%=Languages.LanguageStrings.LicenceDescription %></p>

                <uc1:LicenceRequestTrial runat="server" id="LicenceRequestTrial" />

                <div>
                    <div class="clear"><!-- clear --></div>
                <h2><%=Languages.LanguageStrings.LicencesCurrent %></h2>
                <p><strong><%=Languages.LanguageStrings.LicenceTotal %></strong>: <%=Library.BOL.Licencing.Licence.LicenceCount(GetUser()) %></p>
			
            	<uc1:ProfileLicences ID="Licences1" runat="server" />
                </div>
                <div class="pagination">
					<ul class="fixed">
						 <%=BuildPagination(Library.BOL.Licencing.Licence.LicenceCount(GetUser()), 10, GetLicencePage(), "/Account/Licences/", true)%>
					</ul>
				</div><!-- end of .pagination -->
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
