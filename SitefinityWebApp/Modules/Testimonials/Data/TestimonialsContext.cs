using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.OpenAccess;
using System.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data.Configuration;
using Telerik.Sitefinity.Data.OA;

namespace SitefinityWebApp.Modules.Testimonials.Data
{
	public class TestimonialsContext : SitefinityOAContext
	{
		public static TestimonialsContext Get()
		{
			return OpenAccessConnection.GetContext(new TestimonialsMetaDataProvider(), "Sitefinity") as TestimonialsContext;
		}

		public TestimonialsContext(string connectionString, BackendConfiguration backendConfig, Telerik.OpenAccess.Metadata.MetadataContainer metadataContainer)
			: base(connectionString, backendConfig, metadataContainer)
		{

		}

		/// <summary>
		/// Gets an IQueryable result of all testimonials.
		/// </summary>
		public IQueryable<Testimonial> Testimonials
		{
			get { return GetAll<Testimonial>(); }
		}
	}
}