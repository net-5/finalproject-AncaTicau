using System.Collections.Generic;
using Conference.Domain.Entities;
using Conference.Service;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Conference.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("editions", Attributes =ForAttributeName)]
    public class EditionTagHelper : TagHelper
    {
        private readonly IEditionService _editionService;

        private const string ForAttributeName = "asp-for";

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }


        public EditionTagHelper(IEditionService editionService)
        {
            _editionService = editionService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IEnumerable<Editions> allEditions = _editionService.GetAllEditions();

            output.TagName = "select";
            output.Attributes.SetAttribute("id", For.Name);
            output.Attributes.SetAttribute("name", For.Name);
            output.Attributes.Add("class", "form-control");

            foreach (Editions edition in allEditions)
            {
                var option = new TagBuilder("option")
                {
                    TagRenderMode = TagRenderMode.Normal
                };

                option.Attributes.Add("value", edition.Name);
                option.InnerHtml.Append((edition.Name));

                output.Content.AppendHtml(option);
            }
        }
    }
}