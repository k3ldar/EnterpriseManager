<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.ContactUs" %>
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
			
				<h1><%=Languages.LanguageStrings.ContactUs %></h1>
								
                <div id="divCustomContents" runat="server">
				<img src="/Images/Salons/h_salon1.jpg" alt="" border="0" width="250" 
                    height="200" class="right"/>
				
				<p>There may be a Salon in your area, why not search <a href="/Salons.aspx">for your nearest salon here</a>. Alternatively, you can email us for details of your local stockist here <a href="mailto:sales@heavenskincare.com">Local Stockists</a>.</p>
				
				<p>Why not visit the Heaven Health &amp; Beauty Salon. All heaven therapists are trained by myself to look after you, Liza, Charlotte and Natalie. Alternatively you can book with myself Deborah Mitchell. Patricia will be happy to help you with boookings or find someone in your area who again we have trained in the heaven way.</p>
				
				<p>Heaven is situated in the beautiful Shropshire town of Shifnal, close to the famous Ironbridge Gorge and close to the M54.</p>
				
				<p>Use the contact form below, call to make an appointment or write to the address below: Deborah Mitchell works from Heaven.</p>
				
				<img src="/Images/Salons/h_salon2.jpg" alt="" border="0" width="250" 
                    height="200" class="right"/>
				
				<p>Heaven Health &amp; Beauty Ltd<br />13a Market Place<br />Shifnal<br />Shropshire<br />TF11 9AU</p>
				
				<h5>Telephone:</h5>
				
				<p>
				<strong>Office / General Enquiries:</strong> +44(0) 1952 462505 or +44(0) 1952 463574<br />
                <strong>Salon / Appointments:</strong> +44(0) 1952 461888<br />
				<strong>Fax:</strong> +44(0) 1952 407462</p>
				
				<p><strong>Email:</strong> <a href="mailto:sales@heavenskincare.com">sales@heavenskincare.com</a></p>
				
                <p>You can also use our online <a href="/Helpdesk/Index.aspx">Helpdesk</a> to get in touch</p>
												
                </div>
                <uc2:WebPageTags ID="WebPageTags1" runat="server" />
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
