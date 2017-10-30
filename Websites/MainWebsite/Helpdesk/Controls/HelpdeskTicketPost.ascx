<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HelpdeskTicketPost.ascx.cs" Inherits="Heavenskincare.Helpdesk.Controls.HelpdeskTicketPost" %>
<hr />
<div class="supportTicket">
  <label><strong><%=GetTicketPostReplier() %></strong></label>
  <label><strong><%=GetTicketPostDate() %></strong></label>
</div>
<p>
<%=GetTicketPostText() %>
</p>