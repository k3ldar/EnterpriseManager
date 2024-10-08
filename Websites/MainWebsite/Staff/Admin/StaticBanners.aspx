﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="StaticBanners.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Staff.Admin.StaticBanners" %>
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
					<li><a href="/Staff/Admin/Index.aspx">Admin</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Admin/StaticBanners.aspx">Static Homepage Banners</a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>Static Home Page Banners</h1>
                <p>You can have upto 5 static banners on the homepage, these will appear before and after any campaign banners</p>
                <p>Banners must be 700 pixels wide by 320 pixels high</p>

                <p id="pError" runat="server"><font color="red">ERROR: Unable to save campaign at this time!</font></p>


                <h2>Prefix Banners</h2>
                <p>Banners that appear before the campaign images</p>


                <h3>Banner 1</h3>
                                    
                <p class="form">
                    <asp:FileUpload width="700px" ID="FileUploadHomeBanner1" runat="server" CssClass="Form" />
                    <asp:Button ID="btnUploadHomeImage1" runat="server" Text="Upload" 
                        onclick="btnUploadHomeImage1_Click" /><br /><br />
                    <asp:Image ID="imageHomeBanner1" runat="server" /><br /><br />
                    <asp:Button ID="btnClearHomeImage1" onclick="btnClearHomeImage1_Click" runat="server" Text="Clear" />
                    <P>&nbsp;</P>
                    <p>Link<br />
                        <asp:textbox id="txtBannerURL1" runat="server" Width="500px"></asp:textbox></p>
                </p>

                <h3>Banner 2</h3>

                <p class="form">
                    <asp:FileUpload width="700px" ID="FileUploadHomeBanner2" runat="server" CssClass="Form" />
                    <asp:Button ID="btnUploadHomeImage2" runat="server" Text="Upload" 
                        onclick="btnUploadHomeImage2_Click" /><br /><br />
                    <asp:Image ID="imageHomeBanner2" runat="server" /><br /><br />
                    <asp:Button ID="btnClearHomeImage2" onclick="btnClearHomeImage2_Click" runat="server" Text="Clear" />
                    <P>&nbsp;</P>
                     <p>Link<br />
                        <asp:textbox id="txtBannerURL2" runat="server" Width="500px"></asp:textbox></p>
               </p>

 
                <h2>Suffix Banners</h2>
                <p>Banners that appear after the campaign images</p>


                <h3>Banner 3</h3>
                                    
                <p class="form">
                    <asp:FileUpload width="700px" ID="FileUploadHomeBanner3" runat="server" CssClass="Form" />
                    <asp:Button ID="btnUploadHomeImage3" runat="server" Text="Upload" 
                        onclick="btnUploadHomeImage3_Click" /><br /><br />
                    <asp:Image ID="imageHomeBanner3" runat="server" /><br /><br />
                    <asp:Button ID="btnClearHomeImage3" onclick="btnClearHomeImage3_Click" runat="server" Text="Clear" />
                    <P>&nbsp;</P>
                    <p>Link<br />
                        <asp:textbox id="txtBannerURL3" runat="server" Width="500px"></asp:textbox></p>
                </p>

                <h3>Banner 4</h3>

                <p class="form">
                    <asp:FileUpload width="700px" ID="FileUploadHomeBanner4" runat="server" CssClass="Form" />
                    <asp:Button ID="btnUploadHomeImage4" runat="server" Text="Upload" 
                        onclick="btnUploadHomeImage4_Click" /><br /><br />
                    <asp:Image ID="imageHomeBanner4" runat="server" /><br /><br />
                    <asp:Button ID="btnClearHomeImage4" onclick="btnClearHomeImage4_Click" runat="server" Text="Clear" />
                    <P>&nbsp;</P>
                    <p>Link<br />
                        <asp:textbox id="txtBannerURL4" runat="server" Width="500px"></asp:textbox></p>
                </p>

                <h3>Banner 5</h3>

                <p class="form">
                    <asp:FileUpload width="700px" ID="FileUploadHomeBanner5" runat="server" CssClass="Form" />
                    <asp:Button ID="btnUploadHomeImage5" runat="server" Text="Upload" 
                        onclick="btnUploadHomeImage5_Click" /><br /><br />
                    <asp:Image ID="imageHomeBanner5" runat="server" /><br /><br />
                    <asp:Button ID="btnClearHomeImage5" onclick="btnClearHomeImage5_Click" runat="server" Text="Clear" />
                    <P>&nbsp;</P>
                    <p>Link<br />
                        <asp:textbox id="txtBannerURL5" runat="server" Width="500px"></asp:textbox></p>
                </p>
               
                <p>&nbsp;</p>


                <h2>Left Hand Page Banners</h2>
                <h3>Blog Banner</h3>
                                    
                <p class="form">
                    <asp:FileUpload width="700px" ID="FileUploadBlog" runat="server" CssClass="Form" />
                    <asp:Button ID="btnUploadBlog" runat="server" Text="Upload" 
                        onclick="btnUploadBlogBanner_Click" /><br /><br />
                    <asp:Image ID="imageBlogBanner" runat="server" /><br /><br />
                    <asp:Button ID="btnClearBlogBanner" onclick="btnClearBlogBanner_Click" runat="server" Text="Clear" />
                    <P>&nbsp;</P>
                    <p>Link<br />
                        <asp:textbox id="txtBlogBanner" runat="server" Width="500px"></asp:textbox></p>
                </p>

                <h3>Trade Advantage Banner</h3>

                <p class="form">
                    <asp:FileUpload width="700px" ID="FileUploadTrade" runat="server" CssClass="Form" />
                    <asp:Button ID="Button3" runat="server" Text="Upload" 
                        onclick="btnUploadTradeBanner_Click" /><br /><br />
                    <asp:Image ID="imageTradeBanner" runat="server" /><br /><br />
                    <asp:Button ID="btnClearTradeBanner" onclick="btnClearTradeBanner_Click" runat="server" Text="Clear" />
                    <P>&nbsp;</P>
                    <p>Link<br />
                        <asp:textbox id="txtTradeBanner" runat="server" Width="500px"></asp:textbox></p>
                </p>

               
                <p>&nbsp;</p>

                <p class="form">
                    <asp:button runat="server" id="btnSave" text="Save" OnClick="btnSave_Click" />
                </p>
            </div><!-- end of #mainContent -->
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
