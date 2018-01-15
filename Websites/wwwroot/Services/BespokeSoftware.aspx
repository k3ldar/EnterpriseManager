<%@ page title="" language="C#" masterpagefile="~/SSLSite.Master" autoeventwireup="true" codebehind="BespokeSoftware.aspx.cs" inherits="SieraDelta.Website.Services.BespokeSoftware" %>

<%@ register src="~/Controls/MediaLinks.ascx" tagname="MediaLinks" tagprefix="uc2" %>
<%@ register src="~/Controls/WebPageTags.ascx" tagprefix="uc1" tagname="WebPageTags" %>
<%@ register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.BespokeSoftware %> - <%=Languages.LanguageStrings.Services %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder" runat="server">
            <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Services/Index.aspx"><%=Languages.LanguageStrings.Services %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Services/BespokeSoftware.aspx"><%=Languages.LanguageStrings.BespokeSoftware %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc3:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.BespokeSoftware %></h1>
				

				<div class="productDescription">
                    <p>Are you looking for a customised and cost-effective software solution that will streamline your procedures and save you time? If so, you've come to the right place. </p>

                    <h3>What is bespoke software development?</h3>

                    <p>What we are talking about here is a customised software solution that is specially developed for you and your business. A tailored software system allows you to record specialist information or perform specific tasks which an 'off-the-shelf' package wouldn't let you do.</p>

                    <p>Benefits of customised software
                        <ul>
                            <li>You decide what the system does.</li>
                            <li>You decide what reports and tools you need.</li>
                            <li>You save time and money by having a specially customised system</li>
                            <li>Understanding your business needs</li>
                        </ul>
                    </p>

                    <p>At SieraDelta we listen carefully to our clients’ needs and ask questions to ensure that we really understand their business. That's why we are confident we can deliver flexible and scalable custom solutions that meet your company's requirements now, and in the future.</p>

                    <h3>Improving your bottom line</h3>

                    <p>In the initial consultancy process we will look for opportunities to improve the efficiency of your business processes. With every bespoke development project, our aim is to deliver a solution that meets all the requirements and goals of the customer. In addition, our goal is to minimise the work load and maintenance required to support a growing application.</p>

                    <h3>Our software development processes</h3>

                    <p>The project management and software development processes we use is flexible enough to cope with a wide range of company structures and sizes. The development process itself is split into stages with clear milestones so that you can see the progress being made.</p>

                    <p>For more information or to discuss how we can help your business please <a href="/ContactUs.aspx">get in touch</a></p>

				</div>

                <uc2:MediaLinks ID="MediaLinks1" runat="server" />
			    <%--<uc1:WebPageTags ID="WebPageTags1" runat="server" />--%>

				<div class="clear"><!-- clear --></div>
			</div><!-- end of #mainContent -->
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:content>
