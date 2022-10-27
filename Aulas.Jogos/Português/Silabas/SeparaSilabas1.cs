using Aulas.Domain.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulas.Jogos.Português.Silabas
{
    public class SeparaSilabas1 : Jogo
    {
        private readonly List<string> _palavras = new();

        public override bool Enabled => true;
        public override ETipoPergunta TipoPergunta => ETipoPergunta.String;
        public override ETipoResposta TipoResposta => ETipoResposta.Text;
        public override string Titulo => "Separe as sílabas";
        public override string Descricao => "Sílabas 1: Separe as sílabas das palavras";
        public override int MaxPerguntas => _palavras.Count;

        public override void PreparaPergunta(IConfiguration config)
        {
            _palavras.AddRange(new string[] {
                "ba-na-na", "be-le-za", "bi-co", "bo-la", "bo-lo", "bo-ne-ca", "bo-ta", "bu-le", "bu-zi-na", "ca-be-lo", "ca-bi-de",
                "ca-me-lo", "ca-ne-ca", "ca-sa", "ca-va-lo", "co-me-ta", "da-do", "da-ma", "de-do", "di-vi-no", "do-ce", "fa-da",
                "fi-ve-la", "fo-ca", "fo-go", "ga-to", "ga-ve-ta", "go-la", "go-ta", "ma-ca-co", "ma-la", "ma-pa", "ma-to", "ma-çã",
                "me-ni-na", "me-ni-no", "me-sa", "pa-co-te", "pa-ne-la", "pa-ta", "pa-to", "pi-ja-ma", "pi-ra-ta", "po-te", "sa-co-la",
                "ta-be-la", "te-le-fo-ne", "ti-ge-la", "ti-jo-lo", "tu-ca-no", "va-ca", "sa-po", "so-pa", "ca-re-ta", "ba-la", "ve-la",
                "lu-va", "su-co"
            });

            var random = new Random().Next(_palavras.Count);

            Pergunta = _palavras[random].ToUpper().Replace("-", "");

            Resposta.Add(_palavras[random].ToUpper());
            Resposta.Add(_palavras[random].ToUpper().Replace("-", " "));
        }
    }
}
