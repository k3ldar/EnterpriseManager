<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="MassEmail.aspx.cs" Inherits="SieraDelta.Website.WebsiteMassEmail.MassEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx">Home</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Index.aspx">Staff</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/MassEmail/MassEmail.aspx">Mass Email</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContent">
			
				<h1>Send Mass Email</h1>
				
                <div class="form">
				<p>Please enter your message and intended recipients</p>
				<p>
                <label>Title</label><asp:TextBox ID="txtTitle" runat="server" Width="150px"></asp:TextBox><br />

                <label>Message</label>
                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Height="180px" Width="350px"></asp:TextBox><br /><br />

                <label>Recipients</label><asp:DropDownList ID="cmbRecipients" runat="server">
                    <asp:ListItem Value="6">All Staff</asp:ListItem>
                    <asp:ListItem Value="8">All Admins</asp:ListItem>
                </asp:DropDownList><br /><br />

                <label>Country</label>
                <asp:DropDownList ID="cmbCountry" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="cmbCountry_SelectedIndexChanged"></asp:DropDownList><br /><br />

                    <label>Advanced Send</label><asp:CheckBox ID="cbAdvancedSend" runat="server" /><br />
                    <asp:Button ID="btnSend" runat="server" Text="Send" onclick="btnSend_Click" />
                </p>
                <p id="pMsg" runat="server"></p>
									</div>			
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
