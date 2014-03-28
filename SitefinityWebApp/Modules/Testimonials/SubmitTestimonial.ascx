<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubmitTestimonial.ascx.cs" Inherits="SitefinityWebApp.Modules.Testimonials.SubmitTestimonial" %>



<%@ Register Assembly="Telerik.Sitefinity, Version=6.3.5000.0, Culture=neutral, PublicKeyToken=b28c218413bdf563" Namespace="Telerik.Sitefinity.Web.UI.Fields" TagPrefix="sf" %>

<h1>Submit a testimonial</h1>
<p>Share your thoughts below. Your testimonial will be posted after being reviewed by an administrator.</p>

<asp:Literal ID="Status" runat="server" />

<ul class="submit">
	<li>
		<asp:Label ID="Label1" runat="server" AssociatedControlID="Name" Text="Name" CssClass="sfTxtLbl" />
		<asp:TextBox ID="Name" runat="server" CssClass="sfTxt" />
		<asp:RequiredFieldValidator runat="server" ControlToValidate="Name" Text="Required" />
	</li>
	<li>
		<asp:Label ID="Label2" runat="server" AssociatedControlID="Summary" Text="Summary" CssClass="sfTxtLbl" />
		<asp:TextBox ID="Summary" runat="server" CssClass="sfTxt" />
		<asp:RequiredFieldValidator runat="server" ControlToValidate="Summary" Text="Required" />
	</li>
	<li>
		<asp:Label ID="Label3" runat="server" AssociatedControlID="Text" Text="Testimonial" CssClass="sfTxtLbl" />
		<sf:formmanager id="formManager" runat="server" />
		<sf:htmlfield id="Text" runat="server" width="99%" height="370px" displaymode="Write" fixcursorissue="True" CssClass="testimonial_text" />
		<asp:RequiredFieldValidator runat="server" ControlToValidate="Text" Text="Required" />
	</li>
	<li>
		<asp:Label ID="Label4" runat="server" AssociatedControlID="Rating" Text="Rating" CssClass="sfTxtLbl" />
		<telerik:RadRating ID="Rating" runat="server" Precision="Item" ItemCount="5" />
	</li>
	<li>
		<p><asp:Button ID="btnSave" runat="server" Text="Save Testimonial" OnClick="btnSave_Click" /></p>
	</li>
</ul>
<p><a href="<%= ResolveUrl("~/") %>">&laquo; Back to Testimonials</a></p>