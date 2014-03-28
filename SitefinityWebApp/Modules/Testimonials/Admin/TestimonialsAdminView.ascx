<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestimonialsAdminView.ascx.cs" Inherits="SitefinityWebApp.Modules.Testimonials.Admin.TestimonialsAdminView" %>

<h1 class="sfBreadCrumb">Testimonials</h1>

<div class="sfMain sfClearfix">
	<div class="sfMain sfClearfix">
		<div class="sfAllToolsWrapper">
		<div class="sfAllTools">
		<div class="sfActions">
			<ul>
				<li class="sfMainAction">
					<span><a class="sfLinkBtn sfNew" href="<%= ResolveUrl(Telerik.Sitefinity.Web.SiteMapBase.GetActualCurrentNode().Url) %>/Create"><span class="sfLinkBtnIn">Create a Testimonial</span></a></span>
				</li>
			</ul>
		</div>
		</div>
		</div>
		
		<div class="sfWorkArea sfClearfix">
		<div class="rgTopOffset">
		<telerik:RadGrid ID="TestimonialsGrid" runat="server" Skin="Sitefinity" ondeletecommand="TestimonialsGrid_DeleteCommand">
			<MasterTableView DataKeyNames="ID" AutoGenerateColumns="false">
			<NoRecordsTemplate>
				<div class="sfEmptyList" style="margin-top: 10px;">
					<span class="sfMessage sfMsgNeutral sfMsgVisible" style="background-color: #ffffcc; display: inline">No Testimonials have been created yet</span>
					<ol class="sfWhatsNext">
						<li class="sfCreateItem"><a href="<%= ResolveUrl(Telerik.Sitefinity.Web.SiteMapBase.GetActualCurrentNode().Url) %>/Create">Create
							a Testimonial <span class="sfDecisionIcon"></span></a></li>
					</ol>
				</div>
			</NoRecordsTemplate>
				<Columns>
					<telerik:GridHyperLinkColumn UniqueName="ID" DataNavigateUrlFields="Id" Text="Edit" />
					<telerik:GridButtonColumn ButtonType="LinkButton" CommandName="Delete" Text="Delete" ConfirmDialogType="Classic" ConfirmText="Are you sure you want to delete this item?" />
					<telerik:GridBoundColumn DataField="Name" HeaderText="Author" />
					<telerik:GridBoundColumn DataField="Summary" HeaderText="Summary" />
					<telerik:GridRatingColumn DataField="Rating" HeaderText="Rating" ReadOnly="true" />
					<telerik:GridDateTimeColumn DataField="DatePosted" HeaderText="Date Posted" DataFormatString="{0:ddd MMM dd, yyyy h:mm tt}" />
					<telerik:GridCheckBoxColumn DataField="Published" HeaderText="Published" />
				</Columns>
			</MasterTableView>
		</telerik:RadGrid>
		</div>
		</div>
	</div>
</div>