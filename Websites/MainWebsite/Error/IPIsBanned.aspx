<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IPIsBanned.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Error.IPIsBanned" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.BannedIPAddress %> - <%=Languages.LanguageStrings.Error %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><%=Languages.LanguageStrings.Error %></li>
					<li>&rsaquo;</li>
					<li><%=Languages.LanguageStrings.BannedIPAddress %></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.BannedIPAddress %></h1>
				
				<p>
                    <%=Languages.LanguageStrings.ErrorBannedA %><br />
                    <br />
                    web.master_@heavenskincare_.com<br />
                    <br />
                    <%=Languages.LanguageStrings.ErrorBannedB %>
                </p>
				
												
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"></div>
						
		</div><!-- end of #content -->
</asp:Content>
