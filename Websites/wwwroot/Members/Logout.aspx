<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="SieraDelta.Website.Members.Logout" %>
<%@ Register src="~/Members/Controls/MemberLogout.ascx" tagname="MemberLogout" tagprefix="uc1" %>
<%@ Register src="../Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Logout %> - <%=Languages.LanguageStrings.MyAccount %> - <%=GetWebTitle()%></title>
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
					<li><a href="/Members/Logout.aspx"><%=Languages.LanguageStrings.Logout %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			<uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.Logout %></h1>
					
                <uc1:MemberLogout ID="MemberLogout1" runat="server" />
				
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
