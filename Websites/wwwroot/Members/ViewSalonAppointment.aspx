<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="ViewSalonAppointment.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Members.ViewSalonAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>View Salon Appointment - <%=GetWebTitle()%></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
	<meta name="Keywords" content="<%=GetMetaKeyWords()%>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/Index.aspx"><%=Languages.LanguageStrings.MyAccount %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/SalonAppointments.aspx"><%=Languages.LanguageStrings.MyAppointments %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/ViewSalonAppointment.aspx?ID=<%=GetApptID() %>">view Appointment</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="leftColumn">
			
				<h5>my account</h5>
				
				<ul>
					<%=GetAccountOptions()%>
				</ul>
				
                <%=GetPromotionalOffer() %>	
				<a href="http://heavenbydeborahmitchell.wordpress.com/" target="_blank" title="Follow Deborah's blog" class="banner">
					<img src="https://www.heavenskincare.com/images/banner-blog.jpg" alt="Follow Deborah's blog for the latest news and tips" width="158" height="351" />
				</a>
				
			</div><!-- end of #leftColumn -->
			
			
			<div class="mainContent">
			
			<h1>View Salon Appointment</h1>
			    
                <p><strong>Date/Time:</strong> <%=GetApptDateTime()%></p>

                <p><strong>Tretment:</strong> <%=GetApptTreatment()%></p>

                <p><strong>Duration:</strong> <%=GetApptDuration()%></p>

                <p><strong>Therapist:</strong> <%=GetApptTherapist() %></p>

                <p><strong>Status:</strong> <%=GetApptStatus()%></p>

                <p><strong>Date Created:</strong> <%=GetApptDateCreated()%></p>

                <p><strong>Last Altered:</strong> <%=GetApptDateAltered()%></p>

                <p><strong>Altered By:</strong> <%=GetApptAlteredBy() %></p>

                <p><strong>Locked:</strong> <%=GetApptLocked()%></p>

                <p><strong>Notes:</strong><br /> <%=GetApptNotes()%></p>

                <p id="pCancelReason" runat="server" visible="false">
                <asp:Label ForeColor="Red" ID="lblError" runat="server">Error Message goes here, hidden if no message</asp:Label><br />
                Reason for Cancellation:<br />
                    <asp:TextBox ID="txtCancelReason" MaxLength="230" runat="server" Height="150px" 
                        TextMode="MultiLine" Width="380px"></asp:TextBox>
                </p>
			</div><!-- end of #mainContent -->
			
			<p class="content form">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel Appointment" onclick="btnCancel_Click" 
                     />
            </p>
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
