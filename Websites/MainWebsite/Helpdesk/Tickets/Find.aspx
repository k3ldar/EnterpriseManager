<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Find.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Helpdesk.Tickets.PageFind" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.FindATicket %> - <%=Languages.LanguageStrings.Helpdesk %> - <%=GetWebTitle()%></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
	<meta name="Keywords" content="<%=GetMetaKeyWords()%>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Helpdesk/Index.aspx"><%=Languages.LanguageStrings.Helpdesk %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Helpdesk/Tickets/Find.aspx"><%=Languages.LanguageStrings.FindATicket %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
		
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.FindATicket %></h1>

                <p><%=Languages.LanguageStrings.HelpdeskFindDescription %></p>

                <p class="form">
                    <asp:Label ID="lblNotFound" runat="server" 
                    Text="The ticket could not be found!" Visible="False" /><br />
					<label for="ticket"><%=Languages.LanguageStrings.TicketID %>:</label>
                    <asp:TextBox ID="txtTicketID" class="text" runat="server"></asp:TextBox><br />
					
					<label for="email"><%=Languages.LanguageStrings.Email %>:</label>
                    <asp:TextBox ID="txtEmail" class="text" runat="server"></asp:TextBox><br />
					
					<asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                    onclick="btnSubmit_Click" /><br />
				</p>
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
