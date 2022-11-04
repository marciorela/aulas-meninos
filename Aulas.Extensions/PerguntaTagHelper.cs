using Aulas.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Extensions
{
    public class PerguntaTagHelper : TagHelper
    {
        public string Tipo { get; set; } = "";
        public string Value { get; set; } = "";
        //public string Resposta { get; set; } = "";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //var resposta = (String.IsNullOrWhiteSpace(Resposta) ? "?" : Resposta);

            if (Tipo == ETipoPergunta.String.ToString())
            {
                output.TagName = "div";
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Content.SetContent($"{Value}");
            }
            else if (Tipo == ETipoPergunta.Imagem.ToString())
            {
                output.TagName = "img";
                output.Attributes.Add("src", Value);

                //output.TagName = null;

                //var img = new TagBuilder("img");
                //img.Attributes.Add("src", Value);
                //output.Content.AppendHtml(img);
            }
        }

    }
}
