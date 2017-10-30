<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.SalesLead.Index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="~/Staff/Controls/NotesNew.ascx" tagname="NotesNew" tagprefix="uc1" %>
<%@ Register src="~/Staff/Controls/OpenAction.ascx" tagname="OpenAction" tagprefix="uc2" %>
<%@ Register src="~/Staff/Controls/ClientOrders.ascx" tagname="ClientOrders" tagprefix="uc3" %>
<%@ Register src="~/Staff/Controls/ClientInvoices.ascx" tagname="ClientInvoices" tagprefix="uc3" %>
<%@ Register src="~/Staff/Controls/ClientOther.ascx" tagname="ClientOther" tagprefix="uc4" %>
<%@ Register src="~/Staff/Controls/SingleAction.ascx" tagname="SingleAction" tagprefix="uc5" %>
<%@ Register Src="~/Staff/Controls/CreateSalon.ascx" TagName="CreateSalon" TagPrefix="uc6" %>
<%@ Register Src="~/Members/Controls/CreateAccount.ascx" TagName="CreateAccount" TagPrefix="uc6" %>
<%@ Register Src="~/Staff/Controls/AccountType.ascx" TagName="AccountType" TagPrefix="uc6" %>

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
                    <li><a href="/Staff/SalesLeads.aspx">Sales Tracker</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/SalesLead/Index.aspx?ClientID=<%=GetClientID() %>"><%=GetCustomerName() %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
				<h1><%=GetCustomerName() %></h1>

                <asp:Accordion ID="acClientDetails" runat="server" 
                    FadeTransitions="true" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
                    ContentCssClass="accordionContent" TransitionDuration="250" FramesPerSecond="40" 
                    RequireOpenedPane="false" SuppressHeaderPostbacks="True" SelectedIndex="0">
                    <Panes>
                        <asp:AccordionPane ID="acNotes" runat="server" HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent">
                            <Header>Notes</Header>
                            <Content>
                                <asp:Panel ID="pnlNotes" runat="server">
                                <uc1:NotesNew ID="NotesNew1" runat="server" />
                                </asp:Panel>
                            </Content>
                        </asp:AccordionPane>

                        <asp:AccordionPane runat="server" ID="apTelephone" HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent">
                            <Header>Telephone Calls</Header>
                            <Content>
                                <asp:Panel ID="pnlTelephone" runat="server">
                                    <uc2:OpenAction ID="OpenActionTelephone" runat="server" />
                                </asp:Panel>
                            </Content>
                        </asp:AccordionPane>

                        <asp:AccordionPane ID="apVisits" runat="server" HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent">
                            <Header>Visits</Header>
                            <Content>
                                <asp:Panel ID="pnlVisits" runat="server">
                                    <uc2:OpenAction ID="OpenActionVisits" runat="server" />
                                </asp:Panel>
                            </Content>
                        </asp:AccordionPane>

                        <asp:AccordionPane ID="acTraining" runat="server" HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent">
                            <Header>Training</Header>
                            <Content>
                                <asp:Panel ID="pnlTraining" runat="server">
                                    <uc5:SingleAction ID="saTrainingBSF" runat="server" />
                                    <uc5:SingleAction ID="saTrainingLIA" runat="server" />
                                    <uc5:SingleAction ID="saTrainingDream" runat="server" />
                                </asp:Panel>
                            </Content>
                        </asp:AccordionPane>

                        <asp:AccordionPane ID="acSalons" runat="server" HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent">
                            <Header>Salons/Distributor</Header>
                            <Content>
                                <asp:Panel ID="pnlCreateSalons" runat="server">
                                </asp:Panel>
                            </Content>
                        </asp:AccordionPane>

                         <asp:AccordionPane ID="acOrders" runat="server" HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent">
                            <Header>Orders / Invoices</Header>
                            <Content>
                                <asp:Panel ID="pnlOrders" runat="server">
                                    <asp:TabContainer runat="server" Height="300px" Width="100%" 
                                        ActiveTabIndex="0" OnDemand="false" AutoPostBack="false" TabStripPlacement="Top" CssClass="ajax__tab_xp"
                                        ScrollBars="Auto" UseVerticalStripPlacement="False" VerticalStripWidth="120px">
                                        
                                        <asp:TabPanel runat="server" HeaderText="Invoices" Enabled="true" ScrollBars="Auto" OnDemandMode="Once" >
                                            <ContentTemplate>
                                                <uc3:ClientInvoices ID="ClientInvoices1" runat="server" />
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Orders" Enabled="true" ScrollBars="Auto" OnDemandMode="Once" >
                                            <ContentTemplate>
                                                <uc3:ClientOrders ID="ClientOrders1" runat="server" />
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                    </asp:TabContainer>
                                </asp:Panel>
                            </Content>
                        </asp:AccordionPane>

                        <asp:AccordionPane ID="acOther" runat="server" HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent">
                            <Header>Other</Header>
                            <Content>
                                <asp:Panel ID="pnlOther" runat="server">
                                    <uc5:SingleAction ID="saSendInfoPack" runat="server" />
                                    <uc5:SingleAction ID="saClientTakeOn" runat="server" />
                                    <uc5:SingleAction ID="saCreateAccount" runat="server" />

                                    <uc6:AccountType ID="AccountType1" runat="server" />
                                </asp:Panel>
                            </Content>
                        </asp:AccordionPane>

                        <asp:AccordionPane ID="acAccount" runat="server" HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent">
                            <Header>Account</Header>
                            <Content>
                                <asp:Panel ID="pnlAccount" runat="server">
                                    <p>Please fill out the details below and click Create Account.</p>
                                    <uc6:CreateAccount ID="CreateAccount1" runat="server" />
                                </asp:Panel>
                            </Content>
                        </asp:AccordionPane>

                        <asp:AccordionPane ID="acContactDetails" runat="server" HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent">
                            <Header>Contact details</Header>
                            <Content>
                                <asp:Panel ID="pnlContactDetails" runat="server">
                                    <p id="pContactDetails" runat="server">
                                    </p>
                                </asp:Panel>
                            </Content>
                        </asp:AccordionPane>

                        <asp:AccordionPane ID="acSignupNotes" runat="server" HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent">
                            <Header>Signup Notes</Header>
                            <Content>
                                <asp:Panel ID="pnlSignupNotes" runat="server">
                                    <p id="pSignupNotes" runat="server"></p>
                                </asp:Panel>
                            </Content>
                        </asp:AccordionPane>

                    </Panes>
                </asp:Accordion>

			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->


</asp:Content>
