using System.Collections.Generic;
using Conference.Domain.Entities;
using Conference.Service;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Conference.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("speakers", Attributes = ForAttributeName)]
    public class SpeakerTagHelper : TagHelper
    {
        private readonly ISpeakerService _speakerService;

        private const string ForAttributeName = "asp-for";

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }


        public SpeakerTagHelper(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IEnumerable<Speakers> allSpeakers = _speakerService.GetAllSpeakers();

            output.TagName = "select";
            output.Attributes.SetAttribute("id", For.Name);
            output.Attributes.SetAttribute("name", For.Name);
            output.Attributes.Add("class", "form-control");

            foreach (Speakers speaker in allSpeakers)
            {
                var option = new TagBuilder("option")
                {
                    TagRenderMode = TagRenderMode.Normal
                };

                option.Attributes.Add("value", speaker.Id.ToString());
                option.InnerHtml.Append(speaker.Name);
                
                // If the Model has already a value then select the option with that value
                if (For.Model != null && speaker.Id == (int)For.Model)
                {
                    option.Attributes.Add("selected", "selected");
                }

                output.Content.AppendHtml(option);
            }
        }
    }
}