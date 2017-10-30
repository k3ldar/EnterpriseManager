<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCeleb.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Celebrities.ViewCeleb" %>
<%@ Register src="~/Controls/CelebrityProducts.ascx" tagname="CelebrityProducts" tagprefix="uc1" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.ViewCelebrity %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Celebrities/Index.aspx"><%=Languages.LanguageStrings.Celebrities %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Celebrities/ViewCeleb.aspx?ID=<%=GetFormValue("ID", 1) %>"><%=GetCelebName() %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
				<h1><%=GetCelebName() %></h1>
				
				<div class="productImg">
					<!-- <a href="/Images/Celebs/<%=GetCelebImage() %>" class="nivoZoom"> -->
						<img src="/Images/Celebs/<%=GetCelebImage() %>" alt="" border="0" />
					<!-- </a> -->
				</div><!-- end of .celeb img -->
				
                <p><%=GetCelebDescription()%></p>

				<!-- end of celeb info -->
				
				

                <uc1:CelebrityProducts ID="CelebrityProducts1" runat="server" />
                
                <uc2:WebPageTags ID="WebPageTags1" runat="server" />
                <div class="clear"><!-- clear --></div>
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
