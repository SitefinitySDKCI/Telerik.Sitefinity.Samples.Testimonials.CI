using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Modules.Testimonials.Data
{
	/// <summary>
	/// Class used to represent a Testimonial
	/// </summary>
	public class Testimonial
	{
		/// <summary>
		/// Gets or sets the testimonial ID.
		/// </summary>
		/// <value>
		/// The testimonial ID.
		/// </value>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the name of the user who submitted the testimonial.
		/// </summary>
		/// <value>
		/// The name of the testimonial author.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets a one-line summary for the testimonials List View.
		/// </summary>
		/// <value>
		/// The testimonial summary.
		/// </value>
		public string Summary { get; set; }

		/// <summary>
		/// Gets or sets the full text of the testimonial.
		/// </summary>
		/// <value>
		/// The testimonial text.
		/// </value>
		public string Text { get; set; }

		/// <summary>
		/// Gets or sets the date the testimonial was created.
		/// </summary>
		/// <value>
		/// The date the testimonial was created.
		/// </value>
		public DateTime DatePosted { get; set; }

		/// <summary>
		/// Gets or sets the star rating.
		/// </summary>
		/// <value>
		/// The star rating.
		/// </value>
		public decimal Rating { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Testimonial"/> is published.
		/// </summary>
		/// <value>
		///   <c>true</c> if published; otherwise, <c>false</c>.
		/// </value>
		public bool Published { get; set; }

		public string UrlName { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Testimonial"/> class.
		/// </summary>
		public Testimonial()
		{
			DatePosted = DateTime.Now;
		}

	}
}