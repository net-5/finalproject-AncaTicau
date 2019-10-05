using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Conference.Service;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.CodeAnalysis.CSharp;

namespace Conference.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("sponsorType", Attributes =ForAttributeName)]
    public class SponsorTypeTagHelper : TagHelper
    {
        private readonly ISponsorTypeService sponsorTypeService;

        private const string ForAttributeName = "asp-for";

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }


        public SponsorTypeTagHelper(ISponsorTypeService sponsorTypeService)
        {
            this.sponsorTypeService = sponsorTypeService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            var allSponsorTypes = sponsorTypeService.GetAllSponsorTypes();
            output.TagName = "select";
            output.Attributes.SetAttribute("id", For.Name);
            output.Attributes.SetAttribute("name", For.Name);

            output.Attributes.Add("class", "form-control");

            foreach (var sponsorType in allSponsorTypes)
            {
                TagBuilder myOption = new TagBuilder("option")
                {
                    TagRenderMode = TagRenderMode.Normal
                };

                myOption.Attributes.Add("value", sponsorType.Id.ToString());
                myOption.InnerHtml.Append((sponsorType.Name));

                output.Content.AppendHtml(myOption);
            }
        }
    }
}
