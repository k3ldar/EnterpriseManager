<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OutOfStock.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Products.OutOfStock" %>
<%@ Register src="~/Controls/MayAlsoLike.ascx" tagname="MayAlsoLike" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc3" %>

<%@ Register src="~/Controls/OutOfStockNotification.ascx" tagname="OutOfStockNotification" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=GetProductGroupName()%> - <%=GetProductCostName() %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link property="stylesheet" rel="stylesheet" href="/css/Modal.css" type="text/css" media="screen" />
<script type="text/javascript">
    jQuery(document).ready(function () {
        var scrollCount = <%=GetScrollCount()%>; 
            jQuery('.mycarousel').jcarousel({
                scroll: scrollCount,
                wrap: "circular"
            });
        });
</script>
            <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><%=GetProductGroup()%></li>
					<li>&rsaquo;</li>
					<li><a href="/Products/Product.aspx?ID=<%=GetFormValue("ID", 1) %>"><%=GetProductCostName() %></a></li>
                    <li>&rsaquo;</li>
                    <li><%=Languages.LanguageStrings.OutOfStock %></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<uc3:LeftContainerControl ID="LeftContainerControl1" runat="server" SubOptionsShow="true" />
			
			<div class="mainContent">
			
				<h1><%=GetProductCostName() %> </h1>
				
				<div class="productImg">
                    <asp:HyperLink ID="linkZoom" runat="server" >
					    <img src="https://static.heavenskincare.com/Images/<%=GetProductImage()%>" alt="" border="0" width="288" height="268"/>
						<span class="png_bg" runat="server" id="spZoom"><%=Languages.LanguageStrings.Zoom %></span>
                    </asp:HyperLink>
				</div><!-- end of .productImg -->
				
                <uc4:OutOfStockNotification ID="OutOfStockNotification1" runat="server" />
				
                <p><br /></p>
                <uc1:MayAlsoLike ID="MayAlsoLike1" runat="server" />								
			    <uc2:WebPageTags ID="WebPageTags1" runat="server" />

				<div class="clear"><!-- clear --></div>
			</div><!-- end of #mainContent -->
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
