<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="EditCampaign.aspx.cs" Inherits="SieraDelta.Website.Staff.Campaigns.EditCampaign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Home/">Home</a></li>
					<li>&rsaquo;</li>
					<li><a href="/Staff/Index.aspx">Staff</a></li>
					<li>&rsaquo;</li>
					<li><a href="/Staff/Campaigns/Index.aspx">Campaigns</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Campaigns/EditCampaign.aspx?id=<%=GetCampaignID() %>">Edit <%=GetCampaignTitle() %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Edit <%=GetCampaignTitle() %></h1>
                <p>Please update the campaign details below</p>
                <p id="pError" runat="server"><font color="red">ERROR: Unable to save campaign at this time!</font></p>
                <h2>Settings</h2>

                <p>Campaign Name (tracking code) <asp:TextBox ID="txtCampaignName" runat="server" Width="300px" MaxLength="40"></asp:TextBox></p>
                <p>Campaign Title (friendly name) <asp:TextBox ID="txtCampaignTitle" runat="server" Width="300px" MaxLength="30"></asp:TextBox></p>
                <p>Start <asp:TextBox ID="txtStart" runat="server"></asp:TextBox> - (dd/mm/yyyy hh:mm)</p>
                <p>Finish <asp:TextBox ID="txtFinish" runat="server"></asp:TextBox> - (dd/mm/yyyy hh:mm)</p>

                <h2>Emails</h2>
                <p>Send Emails <asp:CheckBox ID="cbSendEmails" runat="server" AutoPostBack="True" /></p>
                <p id="pEmailSettings" runat="server">
                    Sender Name <asp:TextBox ID="txtSenderName" runat="server" Width="350px"></asp:TextBox><br /><br />
                    Sender Email <asp:TextBox ID="txtSenderEmail" runat="server" Width="350px"></asp:TextBox><br /><br />
                    Email Subject<asp:TextBox ID="txtEmailSubject" runat="server" Width="350px"></asp:TextBox><br /><br />
                    Message<br />
                    <asp:TextBox ID="txtEmailMessage" runat="server" Width="800px" MaxLength="30000" TextMode="MultiLine" Height="500"></asp:TextBox><br /><br />
                    <asp:Button ID="btnTestEmail" runat="server" Text="SendTestEmail" 
                        onclick="btnTestEmail_Click" />
                </p>

                <h2>Letters</h2>
                <p>Send Letters <asp:CheckBox ID="cbSendLetter" runat="server" AutoPostBack="True" /></p>
                <p id="pLetters" runat="server">
                    Letter<br />
                    <asp:TextBox ID="txtLetter" runat="server" Width="800px" MaxLength="30000" TextMode="MultiLine" Height="500"></asp:TextBox>
                </p>

                <h2>Website Changes</h2>
                                    
                <h3>Homepage Image</h3>

                <p class="form">
                    <asp:FileUpload width="350px" ID="FileUploadHomeImage" runat="server" CssClass="Form" />
                    <asp:Button ID="btnUploadHomeImage" runat="server" Text="Upload" 
                        onclick="btnUploadHomeImage_Click" /><br />
                    Homepage Image <asp:TextBox ID="txtImageHomePage" runat="server" Width="350px"></asp:TextBox><br /><br />
                    <asp:Image ID="imageHomePage" runat="server" />
                </p>

                <h3>Left Menu Bar Image</h3>

                <p class="form">
                    <asp:FileUpload width="350px" ID="FileUploadLeftMenu" runat="server" CssClass="Form" />
                    <asp:Button ID="btnUploadLeftImage" runat="server" Text="Upload" 
                        onclick="btnUploadLeftMenuImage_Click" /><br />
                    Left Menu Bar Image <asp:TextBox ID="txtImageLeftMenu" runat="server" Width="350px"></asp:TextBox><br /><br />
                    <asp:Image ID="imageLeftMenu" runat="server" />
                </p>


                <h3>Offers page Image</h3>

                <p class="form">
                    <asp:FileUpload width="350px" ID="FileUploadOffersPage" runat="server" CssClass="Form" />
                    <asp:Button ID="btnUploadOffersPageImage" runat="server" Text="Upload" 
                        onclick="btnUploadOffersPageImage_Click" /><br />
                    Offers Page Image <asp:TextBox ID="txtImageOffersPage" runat="server" Width="350px"></asp:TextBox><br /><br />
                    <asp:Image ID="imageOffersPage" runat="server" />
                </p>
                <p>
                    Offers Page Text<br />
                    <asp:TextBox ID="txtOffersPage" runat="server" Width="800px" MaxLength="6000" TextMode="MultiLine" Height="500"></asp:TextBox>
                </p>

                <p>
                    Link Override<br />
                    <asp:TextBox ID="txtLinkOverride" runat="server" MaxLength="150"></asp:TextBox>
                </p>

                <p>
                    Activate Product Group <br />
                    <asp:DropDownList ID="lstProductGroup" runat="server">
                    </asp:DropDownList>
                </p>

                <p id="pReplicate" runat="server">
                    Replicate<br />
                    <asp:CheckBox ID="cbReplicate" runat="server" />
                </p>


                <p class="form"><asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                        onclick="btnDelete_Click" /></p>
                
            </div><!-- end of #mainContent -->
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content --></asp:Content>
