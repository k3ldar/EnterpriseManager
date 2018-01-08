<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SieraDelta.Website.PageAbout" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.AboutUs %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/About.aspx"><%=Languages.LanguageStrings.AboutUs %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.AboutUs %></h1>
								
                <div id="divTranslated" runat="server">				
				    <p>We provide bespoke products, high quality websites and back office products along with powerful custom database systems for clients around the globe and have earned a reputation as a company that is trusted and innovative in its approach to solving customer problems.</p>

                    <p>We build unique software solutions that fully integrate with business processes and systems, including stock control, dispatch, accounts, crm solutions.</p>

                    <p>We understand how businesses work and have experience in providing business software solutions across a wide range of industry sectors. Committed to your success, we provide flexible, on-going support.
                    Helping businesses with similar challenges to yours.</p>
                    
                    <p>Whether you need a simple or sophisticated stand-alone application, we've probably already helped a business like yours.</p>

                    <p>We also provide a growing list of products under our WebDefender banner, designed to protect your servers, databases and websites from known and emerging hacking attempts.</p>
				</div>

                <uc2:WebPageTags ID="WebPageTags1" runat="server" />
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
