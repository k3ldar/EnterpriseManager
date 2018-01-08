<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="CustomWebsites.aspx.cs" Inherits="SieraDelta.Website.Services.CustomWebsites" %>

<%@ Register src="~/Controls/MediaLinks.ascx" tagname="MediaLinks" tagprefix="uc2" %>
<%@ register src="~/Controls/WebPageTags.ascx" tagprefix="uc1" tagname="WebPageTags" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.CustomWebsites %> - <%=Languages.LanguageStrings.Services %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
            <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Services/Index.aspx"><%=Languages.LanguageStrings.Services %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Services/CustomWebsites.aspx"><%=Languages.LanguageStrings.CustomWebsites %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc3:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.CustomWebsites %></h1>
				

				<div class="productDescription">
                
                    <p>We use a Rapid Web Development approach when building our web solutions, meaning your web site can be up and running in a very short time.</p>

                    <p>Some organizations have specialized needs, and generic services may not fit the bill.  In this case, custom web development becomes necessary.  Our custom web application development begins from an existing baseline that all websites start with.  That means you only pay for the features that are unique to your system.  You don't have to reinvent the wheel and for unnecessary work.</p>

                    <h3>Modular Development</h3>

                    <p>We have many working plug-in modules that may already be close to what you require, such as:</p>
                        <ul>
                            <li>Blogs and forums</li>
                            <li>Registration forms</li>
                            <li>Member management </li>
                            <li>Licence Management</li>
                            <li>Newsletter and email communication modules</li>
                            <li>Event calendars and advanced registration systems</li>
                            <li>Photo galleries and photo sharing tools</li>
                            <li>Product catalogues and shopping carts</li>
                        </ul>

                    <p>In these cases, your customizations may only involve changes to these existing systems that are already debugged and tested in real-world use.</p>

                    <p>Because of the modular nature of our development framework, even if your requirements are completely unique and unprecedented, they are easy to incorporate without having to start from scratch.  Your specialized components are modularized so that they work as self-contained components, or as part of an existing solution.</p>

                    <h3>User-Friendly Development Process</h3>

                    <p>Because it is possible to have a prototype website up so quickly, that means you are involved with the development of your website from the very beginning.  You can see the results instantly, and view the progress of your site's development in real time.  You stay in touch with the development of the site, avoiding situations where your team is working unseen and unreviewed for months at a time.</p>

                    <p>Our solutions are designed to give complete control to the website owner, you will have direct control over the content of your site, helping to sculpt the site pages, content, and your organization's data, to ensure that the product works as you require it to.</p>

                    <h3>Development Environment</h3>

                    <p>Our solutions employ the following robust, industry standard technologies:</p>
                        <ul>
                            <li>Windows operating system</li>
                            <li>IIS web server</li>
                            <li>.Net programming environment</li>
                            <li>Databases currently employed:
                                <ul style="margin: 10px 0 0 20px;font-size: 1.0em;">
                                    <li>MS SQL Server</li>
                                    <li>Oracle</li>
                                    <li>Firebird</li>
                                    <li>MySQL</li>
                                </ul>
                            </li>
                        </ul>

                        <p>All solutions are built using scalable technology, allowing the website to expand in line with ever changing business requirements.</p>
				</div>

                <uc2:MediaLinks ID="MediaLinks1" runat="server" />
			    <%--<uc1:WebPageTags ID="WebPageTags1" runat="server" />--%>

				<div class="clear"><!-- clear --></div>
			</div><!-- end of #mainContent -->
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
