<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Offers.aspx.cs" Inherits="SieraDelta.Website.Offers.Offers" %>
<%@ Register src="~/Controls/OfferBuyItNow.ascx" tagname="OfferBuyItNow" tagprefix="uc1" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Special offers at SieraDelta- <%=Languages.LanguageStrings.SpecialOffers %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
                    <li><%=Languages.LanguageStrings.SpecialOffers %></li>
                    <li>&rsaquo;</li>
					<li><a href="/Special-Offers/"><%=Languages.LanguageStrings.Offers %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
            <h1><%=Languages.LanguageStrings.Offers %></h1>

			<%=GetOffers() %>
			    
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
