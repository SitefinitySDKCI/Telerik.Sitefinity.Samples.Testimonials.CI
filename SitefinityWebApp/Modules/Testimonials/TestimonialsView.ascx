<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestimonialsView.ascx.cs" Inherits="SitefinityWebApp.Modules.Testimonials.TestimonialsView" %>

<asp:MultiView ID="TestimonialsMultiView" runat="server" ActiveViewIndex="0">
	<asp:View ID="ListView" runat="server">
		<h1>Testimonials</h1>
		<asp:Repeater ID="TestimonialsRepeater" runat="server">
			<ItemTemplate>
				<h2><%# Eval("Name") %></h2>
				<p><%# Eval("Summary") %> <a href="<%= ResolveUrl(DetailsPageUrl()) %>/<%# Eval("UrlName") %>">Read More &raquo;</a></p>
				<telerik:RadRating ID="RadRating1" runat="server" Value='<%# Eval("Rating") %>' Precision="Half" ItemCount="5" ReadOnly="true" />
			</ItemTemplate>
		</asp:Repeater>

		<p>Have something to add? <a href="<%= ResolveUrl("~/Submit") %>">Submit your own testimonial</a></p>
	</asp:View>
	<asp:View ID="DetailsView" runat="server">
		<h1><asp:Literal ID="Name" runat="server" /></h1>
		<asp:Label ID="Text" runat="server" />
		<telerik:RadRating ID="Rating" runat="server" Precision="Item" ItemCount="5" ReadOnly="true" />
		<p><em>Posted: <asp:Literal ID="DatePosted" runat="server" /></em></p>
		<p><a href="<%= ResolveUrl(Telerik.Sitefinity.Web.SiteMapBase.GetActualCurrentNode().Url) %>">&laquo; All Testimonials</a></p>
	</asp:View>
</asp:MultiView>