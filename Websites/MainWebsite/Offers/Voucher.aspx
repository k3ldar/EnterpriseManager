<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Voucher.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Offers.Voucher" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Vouchers %> - <%=Languages.LanguageStrings.SpecialOffers %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
                    <li><%=Languages.LanguageStrings.SpecialOffers %></li>
                    <li>&rsaquo;</li>
					<li><a href="/Offers/Voucher.aspx"><%=Languages.LanguageStrings.Vouchers %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />		
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.Vouchers %></h1>
				
				<p><%=GetVoucher() %></p>
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
