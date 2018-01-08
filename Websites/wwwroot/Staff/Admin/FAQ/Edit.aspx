<%@ Page validaterequest="false" Title="" Language="C#" MasterPageFile="~/SiteStaff.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SieraDelta.Website.Staff.Admin.FAQ.Edit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnDelete" 
            ConfirmText="Are you sure you want to delete this FAQ Item?"></asp:ConfirmButtonExtender>
		<div class="content">
			
			<div class="breadcrumb">
			
				<ul class="fixed">
					<li><a href="http://www.SieraDelta.com/Index.aspx">Home</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Index.aspx">Staff</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Admin/Index.aspx">Administration</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/Admin/FAQ/Index.aspx">FAQ</a></li>
                    <li>&rsaquo;</li>
                    <li><a href="/Staff/FAQ/Edit.aspx?ID=<%#GetItemID() %>">Edit <%#GetItemName() %></a></li>
				</ul>
				
			</div><!-- end of #breadcrumb -->
			
			
			<div class="mainContentStaff">
			
				<h1>FAQ Edit</h1>
				
                <p>
                    Description<br />
                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                </p>

                <p>
                    Location<br />
                    <asp:DropDownList ID="lstLocation" runat="server">
                    </asp:DropDownList>
                </p>

				<p>
                
                <asp:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" EnableSanitization="false"
                        DisplaySourceTab="true" TargetControlID="txtContent"  
                        onimageuploadcomplete="HtmlEditorExtender1_ImageUploadComplete">
                        <Toolbar> 
                            <asp:Undo />
                            <asp:Redo />
                            <asp:Bold />
                            <asp:Italic />
                            <asp:Underline />
                            <asp:StrikeThrough />
                            <asp:Subscript />
                            <asp:JustifyLeft />
                            <asp:JustifyCenter />
                            <asp:JustifyRight />
                            <asp:JustifyFull />
                            <asp:InsertOrderedList />
                            <asp:InsertUnorderedList />
                            <asp:RemoveFormat />
                            <asp:SelectAll />
                            <asp:UnSelect />
                            <asp:Delete />
                            <asp:Cut />
                            <asp:Copy />
                            <asp:Paste />
                            <asp:BackgroundColorSelector />
                            <asp:ForeColorSelector />
                            <asp:FontNameSelector />
                            <asp:FontSizeSelector />
                            <asp:Indent />
                            <asp:Outdent />
                            <asp:InsertHorizontalRule />
                            <asp:HorizontalSeparator />
                            <asp:CreateLink />
                            <asp:UnLink />
                            <asp:InsertImage />
            </Toolbar>
                </asp:HtmlEditorExtender>
                    <asp:TextBox ID="txtContent" runat="server" Height="400px" TextMode="MultiLine" 
                        Width="100%" MaxLength="8100"></asp:TextBox>
                </p>
                
				
                
				<div class="form">
                    <p>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                            onclick="btnDelete_Click" />
                        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                    </p>
                </div>

                <p></p>
							
			</div><!-- end of #mainContent -->
			
			
			<div class="clear"><!-- clear --></div>
						
		</div><!-- end of #content -->
</asp:Content>
