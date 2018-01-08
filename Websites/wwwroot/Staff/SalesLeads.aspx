<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="SalesLeads.aspx.cs" Inherits="SieraDelta.Website.Staff.SalesLeads" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="ModalPopupBG" DropShadow="true" PopupControlID="pnlSignupNotes" TargetControlID="hlHidden" OkControlID="btnSignupNotesOk">
    </asp:ModalPopupExtender>
    

		<div class="content">
            
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx">Home</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Index.aspx">Staff</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/SalesLeads.aspx">Sales Tracker</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
				<h1>Sales Tracker</h1>
                <asp:HyperLink ID="hlHidden" runat="server"></asp:HyperLink>
                <p>Client Type:
				<asp:DropDownList ID="cmbClientType" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="0">New Clients</asp:ListItem>
                    <asp:ListItem Value="10">Current Clients</asp:ListItem>
                    <asp:ListItem Value="30">New Distributors</asp:ListItem>
                    <asp:ListItem Value="40">Current Distributors</asp:ListItem>
                    <asp:ListItem Value="50">Archived Distributors</asp:ListItem>
                    <asp:ListItem Value="20">Archived Clients</asp:ListItem>
                    <asp:ListItem Value="60">Current @Home</asp:ListItem>
                    <asp:ListItem Value="70">Archived @Home</asp:ListItem>
                </asp:DropDownList></p>
				
                <asp:Table ID="tblTracker" runat="server" Width="100%" CssClass="tblSalesLeads" 
                    BorderWidth="0px">
                    <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Client</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Telephone Calls</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Visits</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Info Pack</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Take On</asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="20px">Account</asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="20px">Training</asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="20px">Salons</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    
                </asp:Table>

        

			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
            <asp:panel id="pnlSignupnotes" style="display: none" runat="server" CssClass="popup_Container" Width="500px" Height="400px">
            	<div>
                    <div class="popup_Titlebar" id="PopupHeader">Signup Notes</div>
                    <div class="popup_Body">
                        <p id="pSignupNotes" runat="server">Notes go here</p>
                    </div>
                    <div>
                        <asp:Button ID="btnSignupNotesOk" runat="server" Text="OK" />
		            </div>
                </div>
            </asp:panel>

		</div><!-- end of #content -->

</asp:Content>
