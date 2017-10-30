<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="SalonAppointments.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Members.SalonAppointments" %>
<%@ Register src="~/Members/Controls/ProfileAppointments.ascx" tagname="ProfileAppointments" tagprefix="uc1" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>salon appointments - <%=GetWebTitle()%></title>
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
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />			
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.MyAppointments %></h1>

                <p><%=Languages.LanguageStrings.MyAppointmentsDescription %></p>
                <p><uc1:ProfileAppointments ID="ProfileAppointments1" runat="server" />
                </p>

                
            	<div class="pagination">
					<ul class="fixed">
						 <%=BuildPagination(Library.BOL.Appointments.Appointments.GetCount(GetUser()), 10, GetFormValue("Page", 1), "/Members/SalonAppointments.aspx")%>
					</ul>
				</div><!-- end of .pagination -->

                <p>&nbsp;</p><p>&nbsp;</p>

                
                <h3><%=Languages.LanguageStrings.NewAppointment %></h3>
                <div class="content form">
                    <asp:Button ID="btnNewAppointment" runat="server" Text="Book New Appointment" 
                        onclick="btnNewAppointment_Click" /></div>
                       
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
