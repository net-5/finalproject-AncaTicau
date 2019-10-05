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
    [HtmlTargetElement("editions", Attributes =ForAttributeName)]
    public class EditionTagHelper : TagHelper
    {
        private readonly IEditionService editionService;

        private const string ForAttributeName = "asp-for";

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }


        public EditionTagHelper(IEditionService editionService)
        {
            this.editionService = editionService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            var allEditions = editionService.GetAllEditions();
            output.TagName = "select";
            output.Attributes.SetAttribute("id", For.Name);
            output.Attributes.SetAttribute("name", For.Name);

            output.Attributes.Add("class", "form-control");

            foreach (var edition in allEditions)
            {
                TagBuilder option = new TagBuilder("option")
                {
                    TagRenderMode = TagRenderMode.Normal
                };

                option.Attributes.Add("value", edition.Name);
                //if (edition.Id == (int)For.Model)
                //{
                //    option.Attributes.Add("selected", "selected");
                //}
                option.InnerHtml.Append((edition.Name));

                output.Content.AppendHtml(option);
            }
        }
    }
}
