<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateSalon.ascx.cs" Inherits="Heavenskincare.WebsiteTemplate.Controls.CreateSalon" %>
<h3>Create new Salon / Distributor</h3>
<div class="content form">
    
    <asp:Label ID="lblError" ForeColor="Red" runat="server" Text="Error message goes here"></asp:Label><br />
    <label>Name</label><asp:TextBox ID="txtSalonName" runat="server" /><br />
    <label>Contact Name</label><asp:TextBox ID="txtContact" runat="server"></asp:TextBox><br />
    <!--<label>Picture *</label><input class="TextBody" id="idFilePicture" type="file" 
               name="idFilePicture" runat="server" style="WIDTH: 280px; HEIGHT: 22px" size="30" /><br />-->
    <label>Telephone</label><asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox><br />
    <label>Fax</label><asp:TextBox ID="txtFax" runat="server"></asp:TextBox><br />
    <label>Email</label><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
    <label>Website</label><asp:TextBox ID="txtWebsite" runat="server"></asp:TextBox><br />
    <label>Address</label><asp:TextBox ID="txtAddress" runat="server" 
                        Height="130px" TextMode="MultiLine"></asp:TextBox><br />
    <label>Postcode</label><asp:TextBox ID="txtPostCode" runat="server"></asp:TextBox><br />

    <h3><%=Languages.LanguageStrings.OpeningTimes %></h3>
    <label><%=Languages.LanguageStrings.Monday %></label><asp:TextBox ID="txtMonday" runat="server" MaxLength="25"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Tuesday %></label><asp:TextBox ID="txtTuesday" runat="server" MaxLength="25"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Wednesday %></label><asp:TextBox ID="txtWednesday" runat="server" MaxLength="25"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Thursday %></label><asp:TextBox ID="txtThursday" runat="server" MaxLength="25"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Friday %></label><asp:TextBox ID="txtFriday" runat="server" MaxLength="25"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Saturday %></label><asp:TextBox ID="txtSaturday" runat="server" MaxLength="25"></asp:TextBox><br />
    <label><%=Languages.LanguageStrings.Sunday %></label><asp:TextBox ID="txtSunday" runat="server" MaxLength="25"></asp:TextBox><br />

    <asp:RadioButton ID="rbSalon" runat="server" Text="Salon" /><br />
    <asp:RadioButton ID="rbDistributor" runat="server" Text="Distributor" /><br />
    <asp:RadioButton ID="rbStockist" runat="server" Text="Stockist Only" /><br />
    <asp:Button ID="btnCreate" OnClick="btnCreate_Click" runat="server" Text="Create" />
</div>