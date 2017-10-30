<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="MailLists.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Offers.MailLists" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>

<%@ Register src="~/Controls/MailListSubscribe.ascx" tagname="MailListSubscribe" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Offers %> - <%=Languages.LanguageStrings.MailListTitle %> - <%=GetWebTitle()%></title>
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
					<li><a href="/Offers/MailLists.aspx"><%=Languages.LanguageStrings.MailListTitle %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" />			
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.MailListTitle %></h1>
				
				<div id="divCustomContents" runat="server">
                    <p>Subscribe below to get email updates on new product announcements, gift ideas, special promotions, sales and more.</p>
                    
                    <p>You can unsubscribe at any time by visiting the <a href="/Offers/Unsubscribe.aspx">unsubscribe page</a>, which is also included on all emails we send.</p>
                </div>
				
				<uc1:MailListSubscribe ID="MailListSubscribe1" OnOnSubscribed="MailListSubscribe1_OnSubscribed" runat="server" />
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
