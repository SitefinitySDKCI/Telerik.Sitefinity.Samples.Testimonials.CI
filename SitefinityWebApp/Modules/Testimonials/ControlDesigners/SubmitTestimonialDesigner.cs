using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Web.UI;

namespace SitefinityWebApp.Modules.Testimonials.ControlDesigners
{
	public class SubmitTestimonialDesigner : ControlDesignerBase
	{
		/// <summary>
		/// Initializes the controls.
		/// </summary>
		/// <param name="container">The container.</param>
		protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
		{
			base.DesignerMode = ControlDesignerModes.Simple;
		}

		private string _layoutTemplatePath = "~/Modules/Testimonials/ControlDesigners/SubmitTestimonialDesignerTemplate.ascx";
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

		private string _scriptPath = "~/Modules/Testimonials/ControlDesigners/SubmitTestimonialDesigner.js";
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
	}
}