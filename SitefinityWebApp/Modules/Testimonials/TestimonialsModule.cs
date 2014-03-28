using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Services;
using SitefinityWebApp.Modules.Testimonials.Data;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using Telerik.Sitefinity.Modules.Pages;
using SitefinityWebApp.Modules.Testimonials.Admin;

namespace SitefinityWebApp.Modules.Testimonials
{
	public class TestimonialsModule : ModuleBase
	{
		/// <summary>
		/// Installs this module in Sitefinity system for the first time.
		/// </summary>
		/// <param name="initializer">The Site Initializer. A helper class for installing Sitefinity modules.</param>
		public override void Install(SiteInitializer initializer)
		{
			#region Install Pages 
			
			// get page manager
			var pageManager = initializer.PageManager;

			// create Module Landing Page if doesn't exist
			var landingPage = pageManager.GetPageNodes().SingleOrDefault(p => p.Id == this.LandingPageId);
			if (landingPage == null)
			{
				// create admin list view control and add to new landing page
				var ctrl = pageManager.CreateControl<PageControl>("~/Modules/Testimonials/Admin/TestimonialsAdminView.ascx", "Content");
				CreatePage(pageManager, LandingPageId, SiteInitializer.ModulesNodeId, TestimonialsModule.ModuleName, true, TestimonialsModule.ModuleName, ctrl);
			}

			// create testimonials "Create" Page if doesn't exist
			var createPage = pageManager.GetPageNodes().SingleOrDefault(p => p.Id == this.CreatePageId);
			if (createPage == null)
			{
				// create admin control, set properties
				var ctrl = pageManager.CreateControl<PageControl>("~/Modules/Testimonials/Admin/TestimonialsAddEditView.ascx", "Content");
				var prop = ctrl.Properties.FirstOrDefault(p => p.Name == "Mode");
				if (prop == null)
				{
					prop = new ControlProperty();
					prop.Id = Guid.NewGuid();
					prop.Name = "Mode";
					ctrl.Properties.Add(prop);
				}

				// set control to "Create" mode
				prop.Value = SitefinityWebApp.Modules.Testimonials.Admin.TestimonialsAddEditView.AdminControlMode.Create.ToString();

				// create backend page and add control
				CreatePage(pageManager, CreatePageId, LandingPageId, "Create", false, "Create Testimonial", ctrl);
			}

			// create testimonials "Edit" Page if doesn't exist
			var editPage = pageManager.GetPageNodes().SingleOrDefault(p => p.Id == this.EditPageId);
			if (editPage == null)
			{
				// create admin control, set properties
				var ctrl = pageManager.CreateControl<PageControl>("~/Modules/Testimonials/Admin/TestimonialsAddEditView.ascx", "Content");
				var prop = ctrl.Properties.FirstOrDefault(p => p.Name == "Mode");
				if (prop == null)
				{
					prop = new ControlProperty();
					prop.Id = Guid.NewGuid();
					prop.Name = "Mode";
					ctrl.Properties.Add(prop);
				}

				// set control to "Create" mode
				prop.Value = SitefinityWebApp.Modules.Testimonials.Admin.TestimonialsAddEditView.AdminControlMode.Edit.ToString();

				// create backend page and add control
				CreatePage(pageManager, EditPageId, LandingPageId, "Edit", false, "Edit Testimonial", ctrl);
			}

			#endregion

			#region Register Toolbox Widget

            string toolboxName = "PageControls";
            string sectionName = "Samples";
            var config = initializer.Context.GetConfig<ToolboxesConfig>();

            var controls = config.Toolboxes[toolboxName];
            var section = controls.Sections.Where<ToolboxSection>(e => e.Name == sectionName).FirstOrDefault();

            if (section == null)
            {
                section = new ToolboxSection(controls.Sections)
                {
                    Name = sectionName,
                    Title = sectionName,
                    Description = sectionName,
                    ResourceClassId = typeof(PageResources).Name
                };
                controls.Sections.Add(section);
            }

            // Add TestimonialsView Widget if doesn't exist
            if (!section.Tools.Any<ToolboxItem>(e => e.Name == TestimonialsView.ViewName))
            {
                var tool = new ToolboxItem(section.Tools)
                {
                    Name = TestimonialsView.ViewName,
                    Title = "TestimonialsView",
                    Description = "Public control for the Testimonials module",
                    ControlType = "~/Modules/Testimonials/TestimonialsView.ascx",
                    CssClass = "sfTestimonialsWidget"
                };
                section.Tools.Add(tool);
            }

            // Add SubmitTestimonial Widget if doesn't exist
            if (!section.Tools.Any<ToolboxItem>(e => e.Name == SubmitTestimonial.ViewName))
            {
                var tool = new ToolboxItem(section.Tools)
                {
                    Name = SubmitTestimonial.ViewName,
                    Title = "SubmitTestimonial",
                    Description = "Public control for submitting Testimonial",
                    ControlType = "~/Modules/Testimonials/SubmitTestimonial.ascx",
                    CssClass = "sfTestimonialsWidget"
                };
                section.Tools.Add(tool);
            }
            
            #endregion
        }
  
		private void CreatePage(PageManager pageManager, Guid pageID, Guid parentPageID, string UrlName, bool ShowInNavigation, string Title, PageControl control)
		{
			// get backend node
			var parentPage = pageManager.GetPageNode(parentPageID);

			// Create a node in the SiteMap for that page. 
			var node = pageManager.CreatePageNode(pageID);
			pageManager.ChangeParent(node, parentPage);
			parentPage.Nodes.Add(node);

			// set page properties
			node.RenderAsLink = true;
			node.Title = Title;
			node.ShowInNavigation = ShowInNavigation;
			node.UrlName = UrlName;

			// Create a PageData object to hold the actual page contents
			var pageData = pageManager.CreatePageData();
			pageData.Template = pageManager.GetTemplate(SiteInitializer.DefaultBackendTemplateId);
			pageData.HtmlTitle = Title;
			pageData.Title = Title;
			pageData.Status = ContentLifecycleStatus.Live;
			pageData.Visible = true;
			pageData.Version = 1;

			//associate the node with the PageData object
			node.Page = pageData;

			// add admin control to the page
			if (control != null) pageData.Controls.Add(control);
		}

		/// <summary>
		/// Upgrades this module from the specified version.
		/// </summary>
		/// <param name="initializer">The Site Initializer. A helper class for installing Sitefinity modules.</param>
		/// <param name="upgradeFrom">The version this module us upgrading from.</param>
		public override void Upgrade(SiteInitializer initializer, Version upgradeFrom) { }

		/// <summary>
		/// Gets the module config.
		/// </summary>
		/// <returns></returns>
		protected override ConfigSection GetModuleConfig() { return null; }

		/// <summary>
		/// Gets the landing page id for each module inherit from <see cref="T:Telerik.Sitefinity.Services.SecuredModuleBase"/> class.
		/// </summary>
		/// <value>
		/// The landing page id.
		/// </value>
		public override Guid LandingPageId
		{
			get { return new Guid("D7CC19E4-BCE6-4D0F-97D0-C2B667DBBAA8"); }
		}

		public Guid CreatePageId
		{
			get { return new Guid("A58078E4-9CCA-43C4-BAC7-EAE0EFE0489A"); }
		}

		public Guid EditPageId
		{
			get { return new Guid("C1725944-EC74-4F05-8BA2-3DA5B57CE325"); }
		}

		/// <summary>
		/// Gets the CLR types of all data managers provided by this module.
		/// </summary>
		/// <value>
		/// An array of <see cref="T:System.Type"/> objects.
		/// </value>
		public override Type[] Managers
		{
			get { return null; }
		}

		#region Static Properties

		public static string ModuleName = "Testimonials";
		public static string UrlName = "Testimonials";

		#endregion
	}
}