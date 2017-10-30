<%@ Page Language="c#" AutoEventWireup="True" CodeFile="APIError.aspx.cs" Inherits="APIError" CodeBehind="APIError.aspx.cs" %>
<HTML>
	<HEAD>
		<title>PayPal - Error Page</title>
	</HEAD>
	<body>
		
		<TABLE id="Table1">
			<TR>
				<TD >Error Code</TD>
				<TD><%=Request.QueryString.Get("ErrorCode")%></TD>
			</TR>
			
			<TR>
				<TD >Description</TD>
				<TD><%=Request.QueryString.Get("Desc")%></TD>
			</TR>
			
			<TR>
				<TD >Description 2</TD>
				<TD><%=Request.QueryString.Get("Desc2")%></TD>
			</TR>

		</TABLE>
	</body>
</HTML>
