<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestimonialsAddEditView.ascx.cs" Inherits="SitefinityWebApp.Modules.Testimonials.Admin.TestimonialsAddEditView" %>



<%@ Register Assembly="Telerik.Sitefinity, Version=6.3.5000.0, Culture=neutral, PublicKeyToken=b28c218413bdf563" Namespace="Telerik.Sitefinity.Web.UI.Fields" TagPrefix="sf" %>

<h1 class="sfBreadCrumb">Testimonials</h1>

<div class="sfMain sfClearfix">
	<div class="sfContent">
		<div class="rgTopOffset sfWorkArea">
			<fieldset class="sfNewContentForm">
				<div class="sfFormIn">
					<ul>
						<li>
							<asp:Label runat="server" AssociatedControlID="Name" Text="Name" CssClass="sfTxtLbl" />
							<asp:TextBox ID="Name" runat="server" CssClass="sfTxt" />
						</li>
						<li>
							<asp:Label runat="server" AssociatedControlID="Summary" Text="Summary" CssClass="sfTxtLbl" />
							<asp:TextBox ID="Summary" runat="server" CssClass="sfTxt" />
						</li>
						<li>
							<asp:Label runat="server" AssociatedControlID="Text" Text="Testimonial" CssClass="sfTxtLbl" />
							<sf:FormManager ID="formManager" runat="server" />
							<sf:HtmlField ID="Text" runat="server" Width="99%" Height="370px" DisplayMode="Write" FixCursorIssue="True" />
							
						</li>
						<li>
							<asp:Label runat="server" AssociatedControlID="Rating" Text="Rating" CssClass="sfTxtLbl" />
							<telerik:RadRating ID="Rating" runat="server" Precision="Item" ItemCount="5" />
						</li>
						<li>
							<asp:Label runat="server" AssociatedControlID="Published" Text="Published" CssClass="sfTxtLbl" />
							<asp:CheckBox ID="Published" runat="server" />
						</li>
					</ul>

					<p><asp:Button ID="btnSave" runat="server" Text="Save Testimonial" onclick="btnSave_Click" /> or <a href="<%= ResolveUrl("~/Sitefinity/Content/Testimonials") %>">Cancel and go back to Testimonials</a></p>
				</div>
			</fieldset>
		</div>
	</div>
</div>
