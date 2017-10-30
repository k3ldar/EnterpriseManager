<%@ Page Title="" Language="C#" MasterPageFile="~/SSLSite.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="BasketCC.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Basket.BasketCC" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.PaymentCreditCard %> - <%=Languages.LanguageStrings.YourShoppingBag %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- Google Code for Sale Conversion Page -->
<script type="text/javascript">
    /* <![CDATA[ */
    var google_conversion_id = 975251604;
    var google_conversion_language = "en";
    var google_conversion_format = "2";
    var google_conversion_color = "ffffff";
    var google_conversion_label = "KY7zCMy2tQgQlNGE0QM";
    var google_conversion_value = 0;
    var google_remarketing_only = false;
    /* ]]> */
</script>
<script type="text/javascript" src="//www.googleadservices.com/pagead/conversion.js">
</script>
<noscript>
<div style="display:inline;">
<img height="1" width="1" style="border-style:none;" alt="" src="//www.googleadservices.com/pagead/conversion/975251604/?value=0&amp;label=KY7zCMy2tQgQlNGE0QM&amp;guid=ON&amp;script=0"/>
</div>
</noscript>
    		<div class="content">
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
    			<h1><%=Languages.LanguageStrings.PaymentCreditCard %></h1>
			
               <p id="pPaymentText" runat="server"></p>
            </div><!-- end of #mainContent -->

            <div class="clear"><!-- clear --></div>

		</div><!-- end of #content -->
</asp:Content>
