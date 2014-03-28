Type.registerNamespace("SitefinityWebApp.Modules.Testimonials.ControlDesigners");

SitefinityWebApp.Modules.Testimonials.ControlDesigners.SubmitTestimonialDesigner = function (element) {
    SitefinityWebApp.Modules.Testimonials.ControlDesigners.SubmitTestimonialDesigner.initializeBase(this, [element]);
}


SitefinityWebApp.Modules.Testimonials.ControlDesigners.SubmitTestimonialDesigner.prototype = {
    initialize: function () {
        SitefinityWebApp.Modules.Testimonials.ControlDesigners.SubmitTestimonialDesigner.callBaseMethod(this, 'initialize');

    },
    dispose: function () {
        SitefinityWebApp.Modules.Testimonials.ControlDesigners.SubmitTestimonialDesigner.callBaseMethod(this, 'dispose');
    },
    refreshUI: function () {
        var data = this._propertyEditor.get_control();
        jQuery("#AutoPublish").attr('checked', data.AutoPublish);
    },
    applyChanges: function () {

        var controlData = this._propertyEditor.get_control();

        controlData.AutoPublish = jQuery("#AutoPublish").attr('checked') == "checked";
    }
}

SitefinityWebApp.Modules.Testimonials.ControlDesigners.SubmitTestimonialDesigner.registerClass('SitefinityWebApp.Modules.Testimonials.ControlDesigners.SubmitTestimonialDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();