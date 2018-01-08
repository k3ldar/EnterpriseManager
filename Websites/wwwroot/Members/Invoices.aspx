<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="SieraDelta.Website.Members.Invoices" %>
<%@ Register src="~/Members/Controls/ProfileInvoice.ascx" tagname="ProfileInvoice" tagprefix="uc1" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Invoices %> - <%=Languages.LanguageStrings.MyAccount %> - <%=GetWebTitle()%></title>
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
					<li><a href="/Members/Invoices.aspx"><%=Languages.LanguageStrings.Invoices %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />			
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.MyInvoices %></h1>
				
                <p><%=Languages.LanguageStrings.InvoiceDescription %></p>

                <p><strong><%=Languages.LanguageStrings.TotalInvoices %></strong>: <%=Library.BOL.Invoices.Invoices.GetCount(GetUser()) %></p>
			
            	<uc1:ProfileInvoice ID="ProfileInvoice1" runat="server" />
                
                <div class="pagination">
					<ul class="fixed">
						 <%=BuildPagination(Library.BOL.Invoices.Invoices.GetCount(GetUser()), 10, GetFormValue("Page", 1), "/Members/Invoices.aspx")%>
					</ul>
				</div><!-- end of .pagination -->
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
