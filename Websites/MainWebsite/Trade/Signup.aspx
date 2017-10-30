<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Trade.Signup" %>
<%@ Register src="~/Controls/TradeSignup1.ascx" tagname="TradeSignup1" tagprefix="uc1" %>
<%@ Register src="~/Controls/TradeSignup2.ascx" tagname="TradeSignup2" tagprefix="uc2" %>
<%@ Register src="~/Controls/TradeSignup3.ascx" tagname="TradeSignup3" tagprefix="uc3" %>
<%@ Register src="../Controls/TradeSignupFinished.ascx" tagname="TradeSignupFinished" tagprefix="uc4" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.TradeEnquiry %> - <%=Languages.LanguageStrings.Trade %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Trade.aspx"><%=Languages.LanguageStrings.Trade %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Trade/Signup.aspx">Signup</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
						
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />

			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.TradeEnquiry %></h1>
				
				<uc1:TradeSignup1 ID="TradeSignup11" runat="server" />

			    <uc2:TradeSignup2 ID="TradeSignup21" runat="server" />

			    <uc3:TradeSignup3 ID="TradeSignup31" runat="server" />

			    <uc4:TradeSignupFinished ID="TradeSignupFinished1" runat="server" />
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
