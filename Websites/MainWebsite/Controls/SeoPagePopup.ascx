<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SeoPagePopup.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.SeoPagePopup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="SeoCharts.ascx" tagname="SeoCharts" tagprefix="uc1" %>

<style>
    .seoPopup
    {
        width:800px;
        height:600px;
        border: 2px solid black;
        overflow: scroll;
        background-color: white;
        display: block;
    }

	.seoPopup .form { font-size: 1.3em; width: 580px; }

		.seoPopup .form label {
			color: #333;
			display: block;
			float: left;
			font-weight: bold;
			margin: 0 0 20px 0;
			padding: 6px 10px 0 0;
			text-align: right;
			width: 200px;
		}
	
		.seoPopup .form input[type="text"], .seoPopup .form input[type="password"] { margin: 0 0 10px 0; width: 240px; }
		
		.seoPopup .form textarea {
			border: 1px solid #ccc;
			-moz-border-radius: 3px;  
			-webkit-border-radius: 3px;  
			border-radius: 3px;
			color: #333;
			margin: 0 0 10px 0;
			padding: 6px;
			width: 300px; height: 120px;
		}
		
		.seoPopup .form input[type="checkbox"]
		{
		    float: left;
		    margin-top: 7px;
		    text-align: left;
		}
		
		.seoPopup .form select { float: left; width: 254px; }
		
		.seoPopup .form input[type="submit"] {
			background-color: #000000;
			background-image: url('https://static.heavenskincare.com/images/btn_fallback.gif');
			background-image: -webkit-gradient(linear, 0% 0%, 0% 100%, from(#2c2c2c), to(#000000));
			background-image: -webkit-linear-gradient(top, #2c2c2c, #000000);
			background-image:    -moz-linear-gradient(top, #2c2c2c, #000000);
			background-image:     -ms-linear-gradient(top, #2c2c2c, #000000);
			background-image:      -o-linear-gradient(top, #2c2c2c, #000000);
			border: none;
			-moz-border-radius: 4px;  
			-webkit-border-radius: 4px;  
			border-radius: 4px;
			color: #fff;
			cursor: pointer;
			float: right;
			font-weight: bold;
			padding: 6px 16px;
			text-shadow: 0 -1px 0 #000;
			margin-right: 10px;
		}
				
		.seoPopup .form br { clear: both; }

    .seoStaticPageButton
    {
        border: 2px solid black;
        idth: 90px;
        height: 20px;
        position: fixed;
        left: 20px;
        top: 300px;
        display: block;
        padding: 5px 5px 0 5px;
        font-size: 1.3em;
    }
</style>

<div id="divPopupControl" runat="server" class="seoStaticPageButton">
    Seo Data
</div>

<cc1:modalpopupextender id="ModalPopupExtender1" runat="server" 
	cancelcontrolid="btnClose" 
    
	targetcontrolid="divPopupControl" 
    popupcontrolid="pnlSeoData"
    backgroundcssclass="ModalPopupBG">
</cc1:modalpopupextender>

<asp:panel id="pnlSeoData" runat="server">
	<div class="seoPopup form">

        <uc1:SeoCharts ID="SeoCharts1" runat="server" />
        
        <asp:Button ID="btnClose" runat="server" Text="Close" />
	</div>
</asp:panel>
