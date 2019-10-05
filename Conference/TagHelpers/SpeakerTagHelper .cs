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
    [HtmlTargetElement("speakers", Attributes = ForAttributeName)]
    public class SpeakerTagHelper : TagHelper
    {
        private readonly ISpeakerService speakerService;

        private const string ForAttributeName = "asp-for";

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }


        public SpeakerTagHelper(ISpeakerService speakerService)
        {
            this.speakerService = speakerService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var allSpeakers = speakerService.GetAllSpeakers();

            output.TagName = "select";
            output.Attributes.SetAttribute("id", For.Name);
            output.Attributes.SetAttribute("name", For.Name);
            output.Attributes.Add("class", "form-control");

            foreach (var speaker in allSpeakers)
            {
                var option = new TagBuilder("option")
                {
                    TagRenderMode = TagRenderMode.Normal
                };

                option.Attributes.Add("value", speaker.Id.ToString());

                // If the Model has already a value then select the option with that value
                if (speaker.Id == (int)For.Model)
                {
                    option.Attributes.Add("selected", "selected");
                }

                option.InnerHtml.Append(speaker.Name);

                output.Content.AppendHtml(option);
            }
        }
    }
}
