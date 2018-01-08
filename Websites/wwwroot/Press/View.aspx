<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="SieraDelta.Website.Press.View" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.NewsAndPressView %> - <%=Languages.LanguageStrings.NewsAndPress %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
                    <li><a href="/Press/Index.aspx"><%=Languages.LanguageStrings.NewsAndPress %></a></li>
					<li>&rsaquo;</li>
                    <li><a href="/Press/View.aspx?ID=<%=GetNewsID() %>">View</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
				<h1><%=GetNewsTitle() %></h1>
				
				<img src="/Images/Press/<%=GetPressImage() %>.png" alt="" border="0"/><br /><br />
				
                <p><%=GetNewsText() %></p>
											
                <p><%=GetNewsDate()%></p>                                            			
								
				<div class="clear"><!-- clear --></div>

			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
