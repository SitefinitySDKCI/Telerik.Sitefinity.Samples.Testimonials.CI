using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SitefinityWebApp.Modules.Testimonials.Data;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using SitefinityWebApp.Modules.Testimonials.ControlDesigners;
using System.Text.RegularExpressions;

namespace SitefinityWebApp.Modules.Testimonials
{
	[ControlDesigner(typeof(SubmitTestimonialDesigner)), PropertyEditorTitle("Submit Testimonial")]
	public partial class SubmitTestimonial : System.Web.UI.UserControl
	{
        #region Constants

        public static readonly string ViewName = "SubmitTestimonial";

        #endregion

		#region Private Properties

        private const string UrlNameCharsToReplace = @"[^\w\-\!\$\'\(\)\=\@\d_]+";
        private const string UrlNameReplaceString = "-";
		private bool autoPublish = false;

		#endregion

		#region Public Properties

		public bool AutoPublish
		{
			get { return autoPublish; }
			set { autoPublish = value; }
		}

		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			
		}

		/// <summary>
		/// Handles the Click event of the btnSave control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				// create and save unpublished testimonial
				var context = TestimonialsContext.Get();
				var newTestimonial = new Testimonial();
				newTestimonial.Name = Name.Text;
                newTestimonial.UrlName = Regex.Replace(Name.Text.ToLower(), UrlNameCharsToReplace, UrlNameReplaceString);
				newTestimonial.Summary = Summary.Text;
				newTestimonial.Text = Text.Value.ToString();
				newTestimonial.Rating = Rating.Value;
				newTestimonial.Published = AutoPublish;
				context.Add(newTestimonial);

				context.SaveChanges();

				if (AutoPublish)
					Status.Text = "<p><strong>Your testimonial has been submitted successfully!</p>";
				else
					Status.Text = "<p><strong>Your testimonial has been submitted successfully! Please allow 24 hours for review by the administration.</p>";

				// reset form
				Name.Text = string.Empty;
				Summary.Text = string.Empty;
				Text.Value = string.Empty;
				Rating.Value = 0;
			}
			catch (Exception ex)
			{
				Status.Text = "<p><em>An error occurred while submitting your testimonial. Please try again.</p>";
			}
		}
	}
}