using System.Collections.Generic;
using Conference.Domain.Entities;
using Conference.Service;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Conference.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("sponsorType", Attributes =ForAttributeName)]
    public class SponsorTypeTagHelper : TagHelper
    {
        private readonly ISponsorTypeService _sponsorTypeService;

        private const string ForAttributeName = "asp-for";

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }


        public SponsorTypeTagHelper(ISponsorTypeService sponsorTypeService)
        {
            _sponsorTypeService = sponsorTypeService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IEnumerable<SponsorTypes> allSponsorTypes = _sponsorTypeService.GetAllSponsorTypes();

            output.TagName = "select";
            output.Attributes.SetAttribute("id", For.Name);
            output.Attributes.SetAttribute("name", For.Name);
            output.Attributes.Add("class", "form-control");

            foreach (SponsorTypes sponsorType in allSponsorTypes)
            {
                var option = new TagBuilder("option")
                {
                    TagRenderMode = TagRenderMode.Normal
                };

                option.Attributes.Add("value", sponsorType.Id.ToString());
                option.InnerHtml.Append((sponsorType.Name));

                // If the Model has already a value then select the option with that value
                if (For.Model != null && sponsorType.Id == (int)For.Model)
                {
                    option.Attributes.Add("selected", "selected");
                }

                output.Content.AppendHtml(option);
            }
        }
    }
}