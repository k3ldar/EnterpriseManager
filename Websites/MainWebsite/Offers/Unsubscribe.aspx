<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Unsubscribe.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Offers.Unsubscribe" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>
<%@ Register src="../Controls/MailListUnsubscribe.ascx" tagname="MailListUnsubscribe" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Offers %> - <%=Languages.LanguageStrings.MailListUnsubscribeTitle %> - <%=GetWebTitle()%></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
	<meta name="Keywords" content="<%=GetMetaKeyWords()%>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><%=Languages.LanguageStrings.Offers %></li>
					<li>&rsaquo;</li>
					<li><a href="/Offers/Unsubscribe.aspx"><%=Languages.LanguageStrings.MailListUnsubscribeTitle %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" />			
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.MailListUnsubscribeTitle %></h1>
				
				<div id="divCustomContents" runat="server">
                    <p>To unsubscribe from our mail lists please enter your email address below and click unsubscribe.</p>
                </div>
				
				<uc1:MailListUnsubscribe ID="MailListUnsubscribe1" runat="server" OnOnUnsubscribe="MailListUnsubscribe1_OnUnsubscribe" OnOnUnsubscribeFailed="MailListUnsubscribe1_OnUnsubscribeFailed" />
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
