Type.registerNamespace("SitefinityWebApp.Modules.Testimonials.ControlDesigners");

SitefinityWebApp.Modules.Testimonials.ControlDesigners.TestimonialsViewDesigner = function (element) {
	SitefinityWebApp.Modules.Testimonials.ControlDesigners.TestimonialsViewDesigner.initializeBase(this, [element]);
	this._PageSelector = null;
}


SitefinityWebApp.Modules.Testimonials.ControlDesigners.TestimonialsViewDesigner.prototype = {
	initialize: function () {
		SitefinityWebApp.Modules.Testimonials.ControlDesigners.TestimonialsViewDesigner.callBaseMethod(this, 'initialize');

	},
	dispose: function () {
		SitefinityWebApp.Modules.Testimonials.ControlDesigners.TestimonialsViewDesigner.callBaseMethod(this, 'dispose');
	},
	refreshUI: function () {
		var data = this._propertyEditor.get_control();

		// load max testimonials count
		jQuery("#Count").val(data.Count);

		// load selected details page (if any)
		var p = this.get_PageSelector();
		var pageid = data.DetailsPageID;
		if (pageid) p.set_value(pageid);

		// resize dialog handlers
		p.add_selectorOpened(this._resizeControlDesigner);
		p.add_selectorClosed(this._resizeControlDesigner);
	},
	applyChanges: function () {
		var controlData = this._propertyEditor.get_control();

		// save max testimonials count
		controlData.Count = jQuery("#Count").val();

		// save selected details page
		controlData.DetailsPageID = this.get_PageSelector().get_value();
	},

		// Page Selector
	get_PageSelector: function () {
		return this._PageSelector;
	},
	set_PageSelector: function (value) {
		this._PageSelector = value;
	},

	// function to initialize resizer methods and handlers
	_resizeControlDesigner: function () {
		setTimeout("dialogBase.resizeToContent()", 100);
	}
}

SitefinityWebApp.Modules.Testimonials.ControlDesigners.TestimonialsViewDesigner.registerClass('SitefinityWebApp.Modules.Testimonials.ControlDesigners.TestimonialsViewDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();