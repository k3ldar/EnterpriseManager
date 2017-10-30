<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="MemberDetails.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Members.MemberDetails" %>
<%@ Register src="~/Members/Controls/ProfileUserName.ascx" tagname="ProfileUserName" tagprefix="uc1" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.MemberDetails %> - <%=Languages.LanguageStrings.MyAccount %> - <%=GetWebTitle()%></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
	<meta name="Keywords" content="<%=GetMetaKeyWords()%>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/Index.aspx"><%=Languages.LanguageStrings.MyAccount %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/MemberDetails.aspx"><%=Languages.LanguageStrings.MemberDetails %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			<uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
            
            <div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.MemberDetails %></h1>
				
                <p><%=Languages.LanguageStrings.MemberDetailsDescription %>  </p>

				<uc1:ProfileUserName ID="ProfileUserName1" runat="server" />
				
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
