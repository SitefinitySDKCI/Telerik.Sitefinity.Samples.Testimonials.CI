using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI.Fields;

namespace SitefinityWebApp.Modules.Testimonials.ControlDesigners
{
	public class TestimonialsViewDesigner : ControlDesignerBase
	{
		/// <summary>
		/// Initializes the controls.
		/// </summary>
		/// <param name="container">The container.</param>
		protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
		{
			base.DesignerMode = ControlDesignerModes.Simple;

			// set root node for page selector
			PageSelector.RootNodeID = Telerik.Sitefinity.Abstractions.SiteInitializer.FrontendRootNodeId;
		}

		/// <summary>
		/// Gets the page selector.
		/// </summary>
		protected PageField PageSelector
		{
			get { return Container.GetControl<PageField>("PageSelector", true); }
		}

		private string _layoutTemplatePath = "~/Modules/Testimonials/ControlDesigners/TestimonialsViewDesignerTemplate.ascx";
		/// <summary>
		/// Gets or sets the layout template path.
		/// </summary>
		/// <value>
		/// The layout template path.
		/// </value>
		public override string LayoutTemplatePath
		{
			get { return _layoutTemplatePath; }
			set { _layoutTemplatePath = value; }
		}

		private string _scriptPath = "~/Modules/Testimonials/ControlDesigners/TestimonialsViewDesigner.js";
		/// <summary>
		/// Gets or sets the designer script path.
		/// </summary>
		/// <value>
		/// The designer script path.
		/// </value>
		public string DesignerScriptPath
		{
			get { return _scriptPath; }
			set { _scriptPath = value; }
		}

		/// <summary>
		/// Gets the name of the layout template.
		/// </summary>
		/// <value>
		/// The name of the layout template.
		/// </value>
		protected override string LayoutTemplateName
		{
			get { return null; }
		}

		/// <summary>
		/// Gets the script references.
		/// </summary>
		/// <returns></returns>
		public override IEnumerable<ScriptReference> GetScriptReferences()
		{
			var scripts = base.GetScriptReferences() as List<ScriptReference>;
			if (scripts == null) return base.GetScriptReferences();

			scripts.Add(new ScriptReference(DesignerScriptPath));
			return scripts.ToArray();
		}

		/// <summary>
		/// Gets a collection of script descriptors that represent ECMAScript (JavaScript) client components.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerable"/> collection of <see cref="T:System.Web.UI.ScriptDescriptor"/> objects.
		/// </returns>
		public override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
		{
			var descriptors = new List<ScriptDescriptor>(base.GetScriptDescriptors());
			var descriptor = (ScriptControlDescriptor)descriptors.Last();
			descriptor.AddComponentProperty("PageSelector", this.PageSelector.ClientID);
			return descriptors;
		}
	}
}