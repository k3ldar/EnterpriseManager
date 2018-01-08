<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Submit.aspx.cs" Inherits="SieraDelta.Website.Helpdesk.Tickets.Submit" %>
<%@ Register src="~/Controls/VerificationImage.ascx" tagname="VerificationImage" tagprefix="uc1" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.SubmitATicket %> - <%=Languages.LanguageStrings.Helpdesk %> - <%=GetWebTitle()%></title>
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
					<li><a href="/Helpdesk/Tickets/Submit.aspx"><%=Languages.LanguageStrings.SubmitATicket %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			<uc2:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.SubmitATicket %></h1>
                <p class="content form">

                <%=Languages.LanguageStrings.HelpdeskSubmitDescription %><br />

				    <asp:Label ID="lblError" ForeColor="Red" runat="server">Error Message goes here, hidden if no message</asp:Label><br /><br />
					<label for="department"><%=Languages.LanguageStrings.Department %>:</label>
					<asp:DropDownList ID="lstDepartment" runat="server">
                    </asp:DropDownList><br />
					
					<label for="name"><%=Languages.LanguageStrings.Name %>:</label>
                    <asp:TextBox ID="txtName" runat="server" ></asp:TextBox><br />
					
					<label for="email"><%=Languages.LanguageStrings.Email %>:</label>
					<asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox><br />
					
					<label for="priority"><%=Languages.LanguageStrings.Priority %>:</label>
                    <asp:DropDownList ID="lstPriority" runat="server"></asp:DropDownList><br />
					
					<label for="subject"><%=Languages.LanguageStrings.Subject %>:</label>
                    <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox><br />
					
					<label for="message"><%=Languages.LanguageStrings.Message %>:</label>&nbsp;
                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" MaxLength="2000"></asp:TextBox><br />
                
                <uc1:VerificationImage ID="VerificationImage1" runat="server" />
                <br />
                
					<asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                    onclick="btnSubmit_Click" />
                    <br />
				</p>
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
        </div>
</asp:Content>
