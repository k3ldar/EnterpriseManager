<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="SieraDelta.Website.ContactUs" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Contact Us - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/ContactUs.aspx"><%=Languages.LanguageStrings.ContactUs %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
                <h1><%=Languages.LanguageStrings.ProductRelatedQuestions %></h1>
                <p><a href="/Helpdesk/FAQ/Index.aspx"><%=Languages.LanguageStrings.ProductRelatedQuestionsDescription %></a></p>

				<h1><%=Languages.LanguageStrings.ContactUs %></h1>
								
                <div id="divTranslated" runat="server">
				    <p>For an informal chat with one of our friendly website or web database development specialists, please call us during office hours (Monday to Friday, 9.00am to 5.00pm, Central European Time).</p>
                
                    <p>Alternatively, please leave a message or email us anytime and we'll get back to you.</p>
				
				    <h5>Telephone:</h5>
				
				    <p>
				        +44(0) 7473 812281<br />
                        +45 28 81 29 83
				    </p> 
				
				    <p><strong>Email:</strong> <a href="mailto:sales@sieradelta.com">sales@sieradelta.com</a></p>
				
                    <p>You can also use our online <a href="/Helpdesk/Index.aspx">Helpdesk</a> to get in touch</p>
                </div>			
                <uc2:WebPageTags ID="WebPageTags1" runat="server" />
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
