using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.OpenAccess.Metadata;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Data.OA;
using Telerik.Sitefinity.Model;

namespace SitefinityWebApp.Modules.Testimonials.Data
{
	public class TestimonialsMetaDataProvider : IOpenAccessMetadataProvider, IOpenAccessCustomContextProvider
	{
		public MetadataSource GetMetaDataSource(IDatabaseMappingContext context)
		{
			return new TestimonialsFluentMetaDataSource();
		}

		public SitefinityOAContext GetContext(string connectionString, Telerik.OpenAccess.BackendConfiguration backendConfig, MetadataContainer metadataContainer)
		{
			return new TestimonialsContext(connectionString, backendConfig, metadataContainer);
		}

		public string ModuleName
		{
			get { return TestimonialsModule.ModuleName; }
		}
	}
}