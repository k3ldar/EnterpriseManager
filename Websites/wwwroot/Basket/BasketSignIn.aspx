<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="BasketSignIn.aspx.cs" Inherits="SieraDelta.Website.Basket.BasketSignIn" %>
<%@ Register src="~/Members/Controls/MemberLogin.ascx" tagname="MemberLogin" tagprefix="uc1" %>
<%@ Register src="~/Members/Controls/CreateAccount.ascx" tagname="CreateAccount" tagprefix="uc2" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.SignIn %> - <%=Languages.LanguageStrings.YourShoppingBag %> - <%=GetWebTitle()%></title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

		<div class="content">
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Shopping/Basket/"><%=Languages.LanguageStrings.ShoppingBag %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Shopping/Basket/SignIn/"><%=Languages.LanguageStrings.SignIn %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
    			<h1><%=Languages.LanguageStrings.YourShoppingBag %></h1>
			
                <h3><%=Languages.LanguageStrings.ExistingMembers %></h3>

               <p><%=Languages.LanguageStrings.ExistingMembersDescription %></p>
               <uc1:MemberLogin ID="MemberLogin1" runat="server" SignupVisible="false" />
						

              <h3><%=Languages.LanguageStrings.NewMembers %></h3>

               <p><%=Languages.LanguageStrings.NewMembersDescription %></p>
    		   <uc2:CreateAccount ID="CreateAccount1" runat="server" />
            </div><!-- end of #mainContent -->

            <div class="clear"><!-- clear --></div>

		</div><!-- end of #content -->
</asp:Content>
