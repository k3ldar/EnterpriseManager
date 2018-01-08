<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="CancelInvoice.aspx.cs" Inherits="SieraDelta.Website.Members.Invoice.CancelInvoice" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cancel Invoice - <%=GetWebTitle()%></title>
    <meta name="Description" content="<%=GetMetaDescription()%>" />
	<meta name="Keywords" content="<%=GetMetaKeyWords()%>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx">Home</a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/Index.aspx">my account</a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/Invoices.aspx">invoices</a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/InvoiceView.aspx?ID=<%=GetInvoiceNumber() %>">view</a></li>
					<li>&rsaquo;</li>
					<li><a href="/Members/Invoice/CancelInvoice.aspx?ID=<%=GetInvoiceNumber() %>">cancel</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
			<h1>cancel invoice</h1>
			    
                <p>You can cancel an Invoice right up until your items are ready to send out to you, to cancel this Invoice please complete the sections below and click 
                    &#39;Cancel Invoice&#39;.  Please allow 3 working days for your refund to be processed.</p>

                <p><strong>Invoice</strong> WI<%=GetInvoiceNumber()%></p>

                <p><strong>Date</strong> <%=GetInvoiceDate()%></p>

                <p><strong>Total</strong> <%=GetInvoiceTotal()%></p>

                <p><strong>Items</strong> <%=GetFirstItem() %></p>

                <div class="content form">
                    <asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error message goes here"></asp:Label><br />
                    <label>Why do you want to cancel</label>
                    <asp:DropDownList ID="cmbReason" runat="server">
                        <asp:ListItem Selected="True">Please select</asp:ListItem>
                        <asp:ListItem>Changed my mind</asp:ListItem>
                        <asp:ListItem>Order is delayed I need it immediately</asp:ListItem>
                        <asp:ListItem>Found it cheaper elsewhere (please indicate below)</asp:ListItem>
                        <asp:ListItem>Other (please indicate below)</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <label>Other information</label><asp:TextBox ID="txtOtherInformation" 
                        runat="server" TextMode="MultiLine"></asp:TextBox><br />
   
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel Invoice" 
                        onclick="btnCancel_Click" />
                    <!-- <div class="spacer"></div> -->
            </div>

			</div><!-- end of #mainContent -->
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
