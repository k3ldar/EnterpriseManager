<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Heavenskincare.WebsiteTemplate.Blog.Index" %>
<%@ Register src="~/Controls/LeftContainerControl.ascx" tagname="LeftContainerControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%=Languages.LanguageStrings.Blog %> - <%=GetWebTitle()%></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="/Index.aspx"><%=Languages.LanguageStrings.Home %></a></li>
					<li>&rsaquo;</li>
					<li><a href="http://heavenbydeborahmitchell.wordpress.com/" target="_blank">Blog</a></li>
				</ul>
				
			</div><!-- end of .breadcrumb -->
			
            <uc1:LeftContainerControl ID="LeftContainerControl1" runat="server" />
			
			<div class="mainContent">
			
				<h1><%=Languages.LanguageStrings.Blog %></h1>
				
                <p>
                  <%=Languages.LanguageStrings.BlogOffline %>
                </p>
				<!--<div class="blogList">
					<h3><a href="blog-post.html">Nutri Beauty stocks Heaven Range on New Website</a></h3>
					<p>This week I attended the launch of the brand new Nutri Beauty website. In between canapés, me and the PR team mingled with Beauty Editors, bloggers, make-up artists and anyone who's anyone in the industry including a personal idol of mine - Nadine Baggott of Hello! It was a THRILL to meet her and an even bigger thrill to hear how impressed she is with my Bee Venom Mask! Watch this space&hellip;</p>
					<p class="date">Thursday, October 6 &nbsp;|&nbsp; 2 Comments</p>
				</div>
				
				<div class="blogList">
					<h3><a href="blog-post.html">Nutri Beauty stocks Heaven Range on New Website</a></h3>
					<img src="http://placehold.it/132x90" alt="" border="0" width="132" height="90"/>
					<p>This week I attended the launch of the brand new Nutri Beauty website. In between canapés, me and the PR team mingled with Beauty Editors, bloggers, make-up artists and anyone who's anyone in the industry including a personal idol of mine - Nadine Baggott of Hello! It was a THRILL to meet her and an even bigger thrill to hear how impressed she is with my Bee Venom Mask! Watch this space&hellip;</p>
					<p class="date">Thursday, October 6 &nbsp;|&nbsp; 2 Comments</p>
				</div>
				
				<div class="blogList">
					<h3><a href="blog-post.html">Nutri Beauty stocks Heaven Range on New Website</a></h3>
					<p>This week I attended the launch of the brand new Nutri Beauty website. In between canapés, me and the PR team mingled with Beauty Editors, bloggers, make-up artists and anyone who's anyone in the industry including a personal idol of mine - Nadine Baggott of Hello! It was a THRILL to meet her and an even bigger thrill to hear how impressed she is with my Bee Venom Mask! Watch this space&hellip;</p>
					<p class="date">Thursday, October 6 &nbsp;|&nbsp; 2 Comments</p>
				</div>
				
				<div class="blogList">
					<h3><a href="blog-post.html">Nutri Beauty stocks Heaven Range on New Website</a></h3>
					<p>This week I attended the launch of the brand new Nutri Beauty website. In between canapés, me and the PR team mingled with Beauty Editors, bloggers, make-up artists and anyone who's anyone in the industry including a personal idol of mine - Nadine Baggott of Hello! It was a THRILL to meet her and an even bigger thrill to hear how impressed she is with my Bee Venom Mask! Watch this space&hellip;</p>
					<p class="date">Thursday, October 6 &nbsp;|&nbsp; 2 Comments</p>
				</div>
				
				<div class="pagination">
					<ul class="fixed">
						<li class="disabled"><a href="javascript: void(0)">&laquo; Previous</a></li>
						<li class="current"><a href="#">1</a></li>
						<li><a href="#">2</a></li>
						<li><a href="#">3</a></li>
						<li><a href="#">Next &raquo;</a></li>
					</ul>
				</div><!-- end of .pagination -->
				
				
			</div><!-- end of .mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of .content -->
</asp:Content>
