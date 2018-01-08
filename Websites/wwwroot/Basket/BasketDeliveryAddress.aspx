<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="BasketDeliveryAddress.aspx.cs" Inherits="SieraDelta.Website.Basket.BasketDeliveryAddress" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.DeliveryAddress %> - <%=Languages.LanguageStrings.ShoppingBag %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Shopping/Basket/"><%=Languages.LanguageStrings.ShoppingBag %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Shopping/Basket/Delivery-Address/"><%=Languages.LanguageStrings.DeliveryAddress %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
            			
			<div class="mainContent">
    			<h1><%=Languages.LanguageStrings.ShoppingBagDeliveryAddress %></h1>
			
                <h3><%=Languages.LanguageStrings.ShoppingBagDeliveryAddressDescription %></h3>

                <p id="pDeliveryAddresses" runat="server" class="DeliveryAddress">
                
                
                </p>
    		   
                <div class="content form">
                    <asp:Button ID="btnNew" runat="server" Text="New" onclick="btnNew_Click" />
                    <div class="spacer"></div>
                </div>

            </div><!-- end of #mainContent -->

            <div class="clear"><!-- clear --></div>

		</div><!-- end of #content -->
</asp:Content>
