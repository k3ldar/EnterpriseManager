<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="UpdateSalons.aspx.cs" Inherits="SieraDelta.Website.Members.UpdateSalons" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.UpdateSalonDetails %> - <%=Languages.LanguageStrings.MyAccount %> - <%=GetWebTitle()%></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
	<meta name="Keywords" content="<%=GetMetaKeyWords()%>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link property="stylesheet" rel="stylesheet" href="/css/Modal.css" type="text/css" media="screen" />

	<div class="content">
			
		<div class="breadcrumb">
			
			<ul class="fixed">
				<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
				<li>&rsaquo;</li>
				<li><a href="/Account/"><%=Languages.LanguageStrings.MyAccount %></a></li>
				<li>&rsaquo;</li>
				<li><a href="/Account/Distributor/Outlet/"><%=Languages.LanguageStrings.UpdateSalonDetails %></a></li>
			</ul>
				
		</div><!-- end of #breadcrumb -->
			
			
		<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
		<div class="mainContent">
			
			<h1><%=Languages.LanguageStrings.MySalons %></h1>
				
            <p><%=Languages.LanguageStrings.MySalonsDescription %></p>

            <ul class="salonList">
            <p id="pSalons" runat="server">
                
            </p>
            </ul>

            <div runat="server" id="dvCreateNew">
                <h3><%=Languages.LanguageStrings.CreateNewSalon %></h3><br />
                <div class="content form">
                    <asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error message goes here"></asp:Label><br />
                    <label><%=Languages.LanguageStrings.SalonName %></label><asp:TextBox ID="txtSalonName" runat="server"></asp:TextBox><br />
                    <label><%=Languages.LanguageStrings.ContactName %></label><asp:TextBox ID="txtContact" runat="server"></asp:TextBox><br />
                    <label><%=Languages.LanguageStrings.Picture %> *</label><input class="TextBody" id="idFilePicture" type="file" 
                        name="idFilePicture" runat="server" style="WIDTH: 280px; HEIGHT: 22px" size="30" /><br />
                    <label><%=Languages.LanguageStrings.Telephone %></label><asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox><br />
                    <label><%=Languages.LanguageStrings.Fax %></label><asp:TextBox ID="txtFax" runat="server"></asp:TextBox><br />
                    <label><%=Languages.LanguageStrings.Email %></label><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
                    <label><%=Languages.LanguageStrings.Website %></label><asp:TextBox ID="txtWebsite" runat="server"></asp:TextBox><br />
                    <label><%=Languages.LanguageStrings.Address %></label><asp:TextBox ID="txtAddress" runat="server" 
                        Height="130px" TextMode="MultiLine"></asp:TextBox><br />
                    <label><%=Languages.LanguageStrings.Postcode %></label><asp:TextBox ID="txtPostCode" runat="server"></asp:TextBox><br />
                </div>
                <h3><%=Languages.LanguageStrings.OpeningTimes %></h3>
                <div class="content form">
                    <label><%=Languages.LanguageStrings.Monday %></label><asp:TextBox ID="txtMonday" runat="server" MaxLength="25"></asp:TextBox><br />
                    <label><%=Languages.LanguageStrings.Tuesday %></label><asp:TextBox ID="txtTuesday" runat="server" MaxLength="25"></asp:TextBox><br />
                    <label><%=Languages.LanguageStrings.Wednesday %></label><asp:TextBox ID="txtWednesday" runat="server" MaxLength="25"></asp:TextBox><br />
                    <label><%=Languages.LanguageStrings.Thursday %></label><asp:TextBox ID="txtThursday" runat="server" MaxLength="25"></asp:TextBox><br />
                    <label><%=Languages.LanguageStrings.Friday %></label><asp:TextBox ID="txtFriday" runat="server" MaxLength="25"></asp:TextBox><br />
                    <label><%=Languages.LanguageStrings.Saturday %></label><asp:TextBox ID="txtSaturday" runat="server" MaxLength="25"></asp:TextBox><br />
                    <label><%=Languages.LanguageStrings.Sunday %></label><asp:TextBox ID="txtSunday" runat="server" MaxLength="25"></asp:TextBox><br />
                    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                    <div class="spacer"></div>
                </div>
            </div>

		</div><!-- end of #mainContent -->
			
			
		<div class="clear"><!-- clear --></div>
						
	</div><!-- end of #content -->
</asp:Content>
