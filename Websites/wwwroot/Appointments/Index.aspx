<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SieraDelta.Website.Appointments.Index" %>
<%@ Register src="~/Appointments/Controls/NotAllowed.ascx" tagname="NotAllowed" tagprefix="uc1" %>
<%@ Register src="~/Appointments/Controls/Step1.ascx" tagname="Step1" tagprefix="uc2" %>
<%@ Register src="~/Appointments/Controls/Step2.ascx" tagname="Step2" tagprefix="uc3" %>
<%@ Register src="~/Appointments/Controls/Step3.ascx" tagname="Step3" tagprefix="uc4" %>
<%@ Register src="~/Appointments/Controls/Terms.ascx" tagname="Terms" tagprefix="uc5" %>
<%@ Register src="~/Appointments/Controls/PreConditions.ascx" tagname="PreConditions" tagprefix="uc6" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=SieraDelta.Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
                    <li><a href="/Index.aspx"><%=SieraDelta.Languages.LanguageStrings.BookSalonAppointment %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc7:LeftContainerControl ID="LeftContainerControl1" runat="server" />		
			
			<div class="mainContent">
			
				<h1><%=SieraDelta.Languages.LanguageStrings.BookSalonAppointment %></h1>
				
			    <uc1:NotAllowed ID="NotAllowed1" runat="server" />
                <uc5:Terms ID="Terms1" runat="server" />
                <uc6:PreConditions ID="PreConditions1" runat="server" />
			    <uc2:Step1 ID="Step11" runat="server" />
			    <uc3:Step2 ID="Step21" runat="server" />
			    <uc4:Step3 ID="Step31" runat="server" />

			</div><!-- end of #mainContent -->
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
