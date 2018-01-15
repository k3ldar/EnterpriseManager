<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="Salons.aspx.cs" Inherits="SieraDelta.Website.PageSalons" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Salons - <%=GetWebTitle()%></title>

    <style type="text/css">
        .content .openingHours *
        {
        }
        .content .openingHours h3
        {
            font-size: 1.3em;
            font-weight: bold;
            color: #666;
            display: inline;
        }
        .content .openingHours ul
        {
            margin: 0px;
            list-style: none;
            border: 0;
            line-height:1.2em;
            float: right;
        }
            .content .openingHours ul li
            {
                font-size: 1.0em;
                margin: 0 0 0 0;
                padding: 0 0 3px 0;
                border: none;
                width: 150px;
            }
            .content .openingHours ul li span
            {
                float: right;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
        <div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Home/"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/Salons/"><%=Languages.LanguageStrings.Salons %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.Salons %></h1>
				
<%--				<h5 id="headerClients" runat="server"><%=Languages.LanguageStrings.Clients %></h5>
				
				<p><%=Languages.LanguageStrings.SalonsDescriptionA %> </p>--%>
				
				<h5 id="headerSalons" runat="server"><%=Languages.LanguageStrings.Salons %></h5>
				
				<p></p>
				

                 <div class="salonFinder form" id="frmSalonFinder" runat="server">
                	<label style="width:320px;"><%=Languages.LanguageStrings.EnterYourPostcode %>:</label>
					<asp:TextBox ID="txtPostCode" MaxLength="20" runat="server" style="width:120px;float:left;" ></asp:TextBox>
					<asp:Button ID="btnFindSalon" runat="server" style="float:left;margin-left:10px;" Text="Search" /><br />
                </div>

				
				<ul class="salonList">
                    <%=BuildSalonList()%>
				</ul>
				
				
				<div class="pagination">
					<ul class="fixed">
                        <%=BuildPagination(Library.BOL.Salons.Salons.GetCount(), 6, GetSalonPage(), "/Salons/", true)%>
					</ul>
				</div><!-- end of .pagination -->

                <uc2:WebPageTags ID="WebPageTags1" runat="server" />
			</div><!-- end of #mainContent -->
			<div class="clear"><!-- clear --></div>
		</div><!-- end of #content -->
</asp:Content>
