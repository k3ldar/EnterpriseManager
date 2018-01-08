<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="LicenceEdit.aspx.cs" Inherits="SieraDelta.Website.Members.LicenceEdit" %>
<%@ Register src="../Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.MyAccount %>- <%=GetWebTitle()%>- <%=Languages.LanguageStrings.Home %></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
	<meta name="Keywords" content="<%=GetMetaKeyWords()%>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=GetLicenceUpdates() %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/Index.aspx"><%=Languages.LanguageStrings.MyAccount %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/Licences.aspx"><%=Languages.LanguageStrings.MyLicences %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/LicenceEdit.aspx?id=<%=GetLicenceID() %>"><%=Languages.LanguageStrings.LicenceEdit %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			

			<h1><%=Languages.LanguageStrings.LicenceEdit %></h1>

            <div id="divUpdated" runat="server" class="accountUpdated">
                <p><span><%=Languages.LanguageStrings.EmailSent %></span></p>
                <p><%=Languages.LanguageStrings.LicenceEmailSent %></p>
            </div>

                <p><span id="spEmptyDomain" runat="server"><%=GetIsValidLicenceDescription()%><br /><br /></span><strong><%=Languages.LanguageStrings.LicenceDomain %></strong> <asp:TextBox ID="txtDomain" runat="server"></asp:TextBox> 
                    <br /><%=GetLicenceUpdates() %></p>

                <p><strong><%=Languages.LanguageStrings.LicenceType %></strong> <%=GetLicenceType() %></p>

                <p><strong><%=Languages.LanguageStrings.LicenceTrial %></strong> <%=GetTrialLicence()%></p>

                <p><strong><%=Languages.LanguageStrings.LicenceActive %></strong> <%=GetIsValidLicence()%></p>

                <p><strong><%=Languages.LanguageStrings.LicenceExpires %></strong> <%=GetExpireyDate()%></p>
			    <div class="content form">

                <p runat="server" id="pnlLicence"><%=Languages.LanguageStrings.LicenceText %><br />
                    <asp:textbox id="txtLicenceText" runat="server" ReadOnly="true" MultiLine="true" TextMode="MultiLine"></asp:textbox>
                </p>
			
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Licence" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnSendEmail" runat="server" OnClick="btnSendEmail_Click" Text="Send Email" />
                </div>
			</div><!-- end of #mainContent -->
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
