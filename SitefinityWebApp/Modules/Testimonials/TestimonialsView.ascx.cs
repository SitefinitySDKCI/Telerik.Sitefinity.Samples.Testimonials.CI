using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SitefinityWebApp.Modules.Testimonials.Data;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using SitefinityWebApp.Modules.Testimonials.ControlDesigners;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity;

namespace SitefinityWebApp.Modules.Testimonials
{
	/// <summary>
	/// User Control for managing the list Testimonials
	/// </summary>
	[ControlDesigner(typeof(TestimonialsViewDesigner)), PropertyEditorTitle("Testimonials")]
	public partial class TestimonialsView : System.Web.UI.UserControl
	{
		#region Check Mode

		public enum ControlMode
		{
			List,
			Details
		}

		/// <summary>
		/// Determines in which mode the control should be rendered
		/// </summary>
		public ControlMode Mode
		{
			get { return TestimonialID == Guid.Empty ? ControlMode.List : ControlMode.Details; }
		}

		private Guid testimonialID = Guid.Empty;
		/// <summary>
		/// Gets the testimonial ID to load in Edit Mode.
		/// </summary>
		protected Guid TestimonialID
		{
			get
			{
				if (testimonialID == Guid.Empty)
				{
					// ensure parameter is valid
					var param = Request.RequestContext.RouteData.Values["Params"] as string[];
					if (param == null) return Guid.Empty;

					// find testimonial by url name
					var url = param[0];
					var testimonial = context.Testimonials.FirstOrDefault(t => t.UrlName == url);
					testimonialID = (testimonial == null) ? Guid.Empty : testimonial.Id;
				}
				return testimonialID;
			}
		}

		#endregion

		#region Constants

		public static readonly string ViewName = "TestimonialsView";

		#endregion

		#region Public Properties

		public int Count
		{
			get { return _count; }
			set { _count = value; }
		}

		public Guid DetailsPageID { get; set; }

		#endregion

		#region Private Properties

		private int _count = 10;
		private TestimonialsContext context = TestimonialsContext.Get();

		#endregion
		

		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) return;

			switch (Mode)
			{
					// List View
				case ControlMode.List:
					ShowList();
					break;

					// Details View
				case ControlMode.Details:
					ShowDetails();
					break;
			}
		}
  
		private void ShowList()
		{
			// retrieve testimonials and bind
			var testimonials = context.Testimonials.Where(t=> t.Published).Take(Count);
			TestimonialsRepeater.DataSource = testimonials;
			TestimonialsRepeater.DataBind();
			TestimonialsMultiView.SetActiveView(ListView);
		}

		private void ShowDetails()
		{
			// retrieve testimonial
			var testimonial = context.Testimonials.Where(t => t.Id == TestimonialID && t.Published).FirstOrDefault();
			if (testimonial == null) return; // new default 404 response

			// mark route as handled/found
			RouteHelper.SetUrlParametersResolved();

			// show details
			Name.Text = testimonial.Name;
			Text.Text = testimonial.Text;
			Rating.Value = testimonial.Rating;
			DatePosted.Text = testimonial.DatePosted.ToLongDateString();
			TestimonialsMultiView.SetActiveView(DetailsView);

			// Update Page Title
			Page.Title = string.Concat("Testimonials: ", testimonial.Name);
		}

		protected string DetailsPageUrl()
		{
			// check for custom details page
			var currentPageUrl = SiteMapBase.GetActualCurrentNode().Url;
				  if (this.DetailsPageID == Guid.Empty)
					  return currentPageUrl;

			// make sure page exists
			var page = App.WorkWith().Pages().Where(p => p.Id == this.DetailsPageID).Get().FirstOrDefault();
			if (page == null) return currentPageUrl;

			// return page url
			return page.GetFullUrl();
		}

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);
			if (context != null)
				context.Dispose();
		}
	}
}
