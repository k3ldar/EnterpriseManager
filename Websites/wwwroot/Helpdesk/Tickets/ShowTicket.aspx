<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="ShowTicket.aspx.cs" Inherits="SieraDelta.Website.Helpdesk.Tickets.ShowTicket" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.ViewTicket %> - <%=Languages.LanguageStrings.Helpdesk %> - <%=GetWebTitle()%></title>
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
					<li><a href="/Helpdesk/Tickets/ShowTicket.aspx"><%=Languages.LanguageStrings.ViewTicket %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.ViewTicket %></h1>
                <p class="content form">
					<label for=""><strong><%=Languages.LanguageStrings.TicketID %>:</strong></label><label style="text-align: left; font-weight: normal"><%=GetTicketKey() %></label><br />
					<label for=""><strong><%=Languages.LanguageStrings.Department %>:</strong></label><label style="text-align: left; font-weight: normal"><%=GetTicketDepartment() %></label><br />
                    <label for=""><strong><%=Languages.LanguageStrings.Subject %>:</strong></label><label style="text-align: left; font-weight: normal"><%=GetTicketSubject() %></label><br />
                    <label for=""><strong><%=Languages.LanguageStrings.Priority %>:</strong></label><label style="text-align: left; font-weight: normal"><%=GetTicketPriority() %></label><br />	
                    <label for=""><strong><%=Languages.LanguageStrings.Status %>:</strong></label><asp:DropDownList 
                    ID="lstStatus" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="lstStatus_SelectedIndexChanged">
                        </asp:DropDownList><br />		
                    <label for=""><strong><%=Languages.LanguageStrings.LastUpdatedBy %>:</strong></label><label style="text-align: left; font-weight: normal"><%=GetLastReplier() %></label><br />
                    <label for=""><strong><%=Languages.LanguageStrings.LastUpdated %>:</strong></label><label style="text-align: left; font-weight: normal"><%=GetLastUpdated() %></label><br />
                    
                    <!-- Individual posts -->	
                    <table border="0" id="tblPosts" runat="server" width="100%">
                    </table>
                    <!-- end of Individual posts -->

                    <!-- New post -->
                    <p class="content form">
                        <asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error Message goes here, hidden if no message"></asp:Label><br /><br />
                        <label for=""><strong><%=Languages.LanguageStrings.Name %></strong></label><asp:TextBox ID="txtReplyName" runat="server"></asp:TextBox><br />
                        <label for=""><strong><%=Languages.LanguageStrings.Message %></strong></label>
                        <asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" MaxLength="2000"></asp:TextBox><br />
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" />
                    </p>
                    <!-- end of New post -->
                </p>
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
