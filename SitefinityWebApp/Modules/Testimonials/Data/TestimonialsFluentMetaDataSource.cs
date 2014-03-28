using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.OpenAccess.Metadata.Fluent;

namespace SitefinityWebApp.Modules.Testimonials.Data
{
	public class TestimonialsFluentMetaDataSource : FluentMetadataSource
	{
		/// <summary>
		/// Called when this context instance is initializing and a model needs to be obtained.
		/// </summary>
		/// <returns></returns>
		protected override IList<MappingConfiguration> PrepareMapping()
		{
			var mappings = new List<MappingConfiguration>();
			var testimonialMapping = MapTestimonialsTable();
			mappings.Add(testimonialMapping);
			return mappings;
		}

		/// <summary>
		/// Maps the testimonial class to a database table.
		/// </summary>
		/// <returns></returns>
		private MappingConfiguration<Testimonial> MapTestimonialsTable()
		{
			// map to table
			var tableMapping = new MappingConfiguration<Testimonial>();
			tableMapping.MapType().ToTable("sf_testimonials");

			// map properties
			tableMapping.HasProperty(t => t.Id).IsIdentity(Telerik.OpenAccess.Metadata.KeyGenerator.Guid);
			tableMapping.HasProperty(t => t.Name).HasLength(255).IsNotNullable();
			tableMapping.HasProperty(t => t.Summary).HasLength(255).IsNotNullable();
			tableMapping.HasProperty(t => t.Text).HasColumnType("varchar(max)");
			tableMapping.HasProperty(t => t.Rating).IsNotNullable();
			tableMapping.HasProperty(t => t.DatePosted).IsNotNullable();
			tableMapping.HasProperty(t => t.Published).IsNotNullable();
			tableMapping.HasProperty(t => t.UrlName).IsNotNullable();

			return tableMapping;
		}
	}
}