<%@ Page Language="C#" validaterequest="false" MasterPageFile="~/SSLSite.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.PageAbout" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<%@ Register src="~/Controls/WebPageTags.ascx" tagname="WebPageTags" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.AboutUs %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="/About.aspx"><%=Languages.LanguageStrings.AboutUs %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.AboutUs %></h1>
				
				<h3><%=Languages.LanguageStrings.OrganicSkincare %></h3>
                <div id="divCustomContents" runat="server">
				
				<img src="/Images/Trade/allProductsShot.jpg" alt="" border="0" width="250" height="250" class="right"/>
				
				<p>I formulated this wonderful all-natural organic range of products, skin and body treatments to offer you the potent power of nature in perfect harmony with the latest breakthroughs in beauty technology.</p>
				
				<p>With over twenty five years experience as a hands on therapist I have developed a completely unique approach to looking after the skin and extensive knowledge of ancient herbal remedies. This has enabled me to create a unique way of thinking about beautiful skin and optimisation for perfection.</p>
				
				<p>Contrary to most popular skin care programmes Heaven seeks not to add more oil, but more moisture, which plumps out skin cells, making the complexion more lustrous and youthful.</p>
				
				<p>Heaven's unique skin care approach has now been proven many times over to help skin conditions such as psoriasis, eczema, acne, oily and blemished skin.</p>
				
				<p>As a qualified teacher in beauty therapy I run my very own Heaven training school for therapists from all over the world. My in-depth knowledge of the spiritual and healing side of health and beauty also brings a unique addition to my training skills.</p>
				
				<p>Highly acclaimed with numerous awards for both treatments and products I have had and have the pleasure of treating many celebrities from the world of music, film, sport and even royalty and qualified to provide tips on all manner of issues including: acne, anti-ageing, nutrition, hormonal problems, post natal depression, healing, hair loss, reflexology, colonics, semi-permanent make-up for cancer patients and stress; treating everything holistically, looking at internal and external influences to get to the root cause of health and beauty issues.</p>
				
				<p>By using Heaven's all-natural organic range of products you will see spots and blemishes improve while keeping a youthful complexion. Feel the difference immediately and check your complexion after five days - the results are remarkable. With Heaven, you can realise your own natural beauty.</p>
				
				<p>Be healthy, happy and your skin will radiate beauty:</p>
				
				<p>Love</p>
				
				<p>Deborah Mitchell</p>
				
				<h3>personal treatment</h3>
				
				<p>If you would like to see your skin improve too, personal treatments with Deborah Mitchell are available at the Hale Clinic in London and her Shifnal salon and training school. For more information or to make an appointment call +44 (0)1952 461888 or email <a href="mailto:sales@heavenskincare.com">sales@heavenskincare.com</a></p>
									
                </div>			
                <uc2:WebPageTags ID="WebPageTags1" runat="server" />
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
