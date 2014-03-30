using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
using SitefinityWebApp.Modules.Testimonials;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Pages.Model;
using SitefinityWebApp.Modules.Testimonials.Data;
using Telerik.Sitefinity.Samples.Common;
using Telerik.Sitefinity.Modules.GenericContent.Web.UI;
using Telerik.Sitefinity.Data.OA;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp
{
	public class Global : System.Web.HttpApplication
	{
		private const string SamplesThemeName = "SamplesTheme";     
		private const string SamplesThemePath = "~/App_Data/Sitefinity/WebsiteTemplates/Samples/App_Themes/Samples";

		private const string SamplesTemplateId = "015b4db0-1d4f-4938-afec-5da59749e0e8";
		private const string SamplesTemplateName = "SamplesMasterPage";
		private const string SamplesTemplatePath = "~/App_Data/Sitefinity/WebsiteTemplates/Samples/App_Master/Samples.master";

		private const string HomePageID = "3A7A00D6-AFFA-45AF-A811-8D2C30F8A345";
		private const string TestimonialsPageID = "AA6EB759-BCCE-4417-8616-1C5C36FD4417";

		private const string SubmitTestimonialPageID = "CD2CB68F-A2BF-46C8-8C99-B36949FD94FE"; 

		private const string TESIMONIAL_TEXT = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer dapibus, tellus eu laoreet bibendum, dolor ante porttitor nunc, non convallis magna arcu eget dui. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.</p><p>Nunc condimentum condimentum diam id dapibus. Proin et risus leo. Mauris tristique feugiat ante, a tristique tellus vehicula rhoncus. Mauris odio nibh, lacinia sit amet vehicula in, feugiat ut turpis.</p><p>Suspendisse mi felis, lobortis non ultricies eu, fermentum vitae massa. Quisque laoreet elit placerat nisi placerat congue faucibus enim malesuada. Integer justo erat, faucibus nec tincidunt sed, fringilla id nisl. Sed enim libero, adipiscing eget dignissim et, suscipit non odio.</p>";

		protected void Application_Start(object sender, EventArgs e)
		{
			Telerik.Sitefinity.Abstractions.Bootstrapper.Initializing += new EventHandler<Telerik.Sitefinity.Data.ExecutingEventArgs>(Bootstrapper_Initializing);
			Telerik.Sitefinity.Abstractions.Bootstrapper.Initialized += new EventHandler<Telerik.Sitefinity.Data.ExecutedEventArgs>(Bootstrapper_Initialized);
		}

		protected void Bootstrapper_Initializing(object sender, Telerik.Sitefinity.Data.ExecutingEventArgs args)
		{
			if (args.CommandName == "RegisterRoutes")
			{
                SampleUtilities.RegisterModule<TestimonialsModule>("Testimonials", "A simple user-control based module for maintaining a list of testimonials that can be sumitted by users.");
			}
		}

        protected void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs args)
        {
            if (args.CommandName == "Bootstrapped")
            {
                SystemManager.RunWithElevatedPrivilegeDelegate worker = new SystemManager.RunWithElevatedPrivilegeDelegate(CreateSampleWorker);
                SystemManager.RunWithElevatedPrivilege(worker);
                this.AddValueToBigList(1);
            }
        }

        //This method is intended to test CI with Jenkins for assemblies that require NuGet packages
        private void AddValueToBigList(int item)
        {
            var list = new Wintellect.PowerCollections.BigList<T>();
            list.Add(item);
            list.Clear();
        }

        private void CreateSampleWorker(object[] args)
        {            
            SampleUtilities.CreateUsersAndRoles();
            SampleUtilities.RegisterTheme(SamplesThemeName, SamplesThemePath);
            SampleUtilities.RegisterTemplate(new Guid(SamplesTemplateId), SamplesTemplateName, SamplesTemplateName, SamplesTemplatePath, SamplesThemeName);

            // Create Testimonials home page
            var result = SampleUtilities.CreatePage(new Guid(HomePageID), "Home", true);
            if (result)
            {
                SampleUtilities.SetTemplateToPage(new Guid(HomePageID), new Guid(SamplesTemplateId));

                // add welcome and instructions to page
                var generalInformationBlock = new ContentBlock();
                generalInformationBlock.Html = @"<h1>Testimonials Intra-Site Module Example</h1><p>This is the home page for the Testimonials Intra-Site module. Below is the Testimonials View Widget. It has a property to set a <a href=""testimonials"">separate page</a> for the details view.</p><p>On <a href=""testimonials"">the testimonials page</a> is a separate Testimonials View Widget that uses its own page as the details page.</p><p>This allows you to have multiple instances of the same content lists, all pointing to the same details page.</p>";

                SampleUtilities.AddControlToPage(new Guid(HomePageID), generalInformationBlock, "Content", "Content block");

                // create Testimonials View
                var mgr = PageManager.GetManager();
                var ctrl = mgr.CreateControl<PageControl>("~/Modules/Testimonials/TestimonialsView.ascx", "Content");
                ctrl.Caption = "TestimonialsView";

                // set details page to Testimonials Page
                var prop = ctrl.Properties.FirstOrDefault(p => p.Name == "DetailsPageID");
                if (prop == null)
                {
                    prop = new ControlProperty();
                    prop.Id = Guid.NewGuid();
                    prop.Name = "DetailsPageID";
                    ctrl.Properties.Add(prop);
                }

                // the ID is needed for the control to be duplicated
                var idProp = ctrl.Properties.FirstOrDefault(p => p.Name == "ID");
                if (idProp == null)
                {
                    idProp = new ControlProperty();
                    idProp.Id = Guid.NewGuid();
                    idProp.Name = "ID";
                    ctrl.Properties.Add(idProp);
                }

                prop.Value = TestimonialsPageID;
                idProp.Value = "TestimonialsView";

                SampleUtilities.AddControlToPage(new Guid(HomePageID), ctrl, "Content");
            }

            // Create Testimonials list/details page
            result = SampleUtilities.CreatePage(new Guid(TestimonialsPageID), "Testimonials", false);
            if (result)
            {
                SampleUtilities.SetTemplateToPage(new Guid(TestimonialsPageID), new Guid(SamplesTemplateId));
                SampleUtilities.AddControlToPage(new Guid(TestimonialsPageID), "~/Modules/Testimonials/TestimonialsView.ascx", "Content", "TestimonialsView");
            }

            // "Submit Testimonial" page
            result = SampleUtilities.CreatePage(new Guid(SubmitTestimonialPageID), "Submit", false);
            if (result)
            {
                SampleUtilities.SetTemplateToPage(new Guid(SubmitTestimonialPageID), new Guid(SamplesTemplateId));
                SampleUtilities.AddControlToPage(new Guid(SubmitTestimonialPageID), "~/Modules/Testimonials/SubmitTestimonial.ascx", "Content", "SubmitTestimonial");
            }

            // create sample testimonials
            var context = TestimonialsContext.Get();
            if (context.Testimonials.Count() > 0) return;

            context.Add(new Testimonial()
            {
                Name = "John Doe",
                Rating = 5,
                Summary = "What a great product!",
                Text = TESIMONIAL_TEXT,
                DatePosted = DateTime.Now,
                Published = true,
                UrlName = "john-doe"
            });
            context.Add(new Testimonial()
            {
                Name = "Jane Doe",
                Rating = 4,
                Summary = "A solid product, almost perfect!",
                Text = TESIMONIAL_TEXT,
                DatePosted = DateTime.Now,
                Published = true,
                UrlName = "jane-doe"
            });
            context.Add(new Testimonial()
            {
                Name = "Jim Doe",
                Rating = 3,
                Summary = "Not bad; worth my time but could use a few more features.",
                Text = TESIMONIAL_TEXT,
                DatePosted = DateTime.Now,
                Published = true,
                UrlName = "jim-doe"
            });
            context.SaveChanges();            

            //create admin
            SampleUtilities.CreateUsersAndRoles();
            //SampleUtilities.FrontEndAuthenticate();
        }		

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}
