using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationUnobtrusive.Helpers.Tags
{
    [HtmlTargetElement("form", Attributes = AjaxForm)]
    public class UnobtrusiveFormTagHelper : TagHelper
    {
        private const string AjaxForm = "asp-ajax";

        [HtmlAttributeName("asp-onsuccess")]
        public string AspOnSuccess { get; set; }

        [HtmlAttributeName("asp-onfailure")]
        public string AspOnFailure { get; set; }

        [HtmlAttributeName("asp-loading-id")]
        public string AspLoading { get; set; }

        [HtmlAttributeName("asp-loading-duration")]
        public double AspLoadingDuration { get; set; }

        [HtmlAttributeName("asp-update-id")]
        public string AspUpdate { get; set; }

        [HtmlAttributeName("asp-method")]
        public string AspMethod { get; set; }

        [HtmlAttributeName(AjaxForm)]
        public string AspAjax { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            // Enable ajax
            output.Attributes.Add("data-ajax-begin", "");
            output.Attributes.Add("data-ajax", AspAjax);

            // On Failure
            if (!string.IsNullOrEmpty(AspOnFailure))
                output.Attributes.Add("data-ajax-failure", AspOnFailure);

            // On Success
            if (!string.IsNullOrEmpty(AspOnSuccess))
                output.Attributes.Add("data-ajax-success", AspOnSuccess);

            // Loading
            if (!string.IsNullOrEmpty(AspLoading))
                output.Attributes.Add("data-ajax-loading", "#" + AspLoading);

            // Add Loading duration
            if (AspLoadingDuration > 0)
                output.Attributes.Add("data-ajax-loading-duration", AspLoadingDuration);

            // Update
            if (!string.IsNullOrEmpty(AspUpdate))
                output.Attributes.Add("data-ajax-update", "#" + AspUpdate);

            // Method
            if (!string.IsNullOrEmpty(AspMethod))
                output.Attributes.Add("data-ajax-method", AspMethod);
        }

    }
}
