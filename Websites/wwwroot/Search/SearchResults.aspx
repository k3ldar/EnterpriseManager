<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="SieraDelta.Website.Search.SearchResults" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Search %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Search/SearchResults.aspx"><%=Languages.LanguageStrings.Search %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.Search %></h1>				

                 <div class="salonFinder form">
                	<label style="width:320px;"><%=Languages.LanguageStrings.SearchDescription %></label>
					<asp:TextBox ID="txtSearchTerms" MaxLength="20" runat="server" style="width:120px;float:left;" ></asp:TextBox>
					<asp:Button ID="btnSearch" runat="server" style="float:left;margin-left:10px;" Text="Search" OnClick="btnSearch_Click" /><br />
                </div>

				
				<ul class="searchResult" id="sResults" runat="server">
                    
				</ul>
			</div><!-- end of #mainContent -->
			<div class="clear"><!-- clear --></div>
		</div><!-- end of #content -->
</asp:Content>
