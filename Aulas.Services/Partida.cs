using Aulas.Domain.Models;
using Aulas.Extensions;
using Aulas.Jogos;
using Aulas.Jogos.Soma;
using Bogus;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Aulas.Services;

public class Partida
{
    const int qtdJogos = 10;
    private Jogador _jogador;

    public int Acertos => CountAcertos();

    public int Erros => CountErros();

    //public List<Resposta> Respostas { get; set; } = new();

    public List<InfoJogo> Jogos { get; set; } = new();
   

    //public List<ETipo> TiposDeJogo => Enum.GetValues(typeof(ETipo)).Cast<ETipo>().ToList();

    public Jogador Jogador => _jogador;

    public Partida(Jogador jogador)
    {
        _jogador = jogador;
    }

    public bool FimDePartida()
    {
        return Jogos.Count(x => x.RespostaInformada != "") >= qtdJogos;
    }

    public int PontuacaoFinal()
    {
        var pontos = Decimal.Truncate((decimal)CountAcertos() / Jogos.Count * 10);

        return (int)pontos;
    }

    public void Iniciar()
    {
        Jogos.Clear();

        NovoJogo();
    }

    private void NovoJogo()
    {
        //var randomGame = new Random(Partida.Jogos.Count).Next();

        //var tipoJogo = new Faker().PickRandom<ETipo>();

        var ass = Assembly.GetAssembly(typeof(Jogo))!;
        var list = ass.GetTypes().Where(x => x.IsClass && typeof(Jogo).IsAssignableFrom(x) && x != typeof(Jogo)).ToList();
        //var list = ass.GetTypes().Where(x => x.IsClass).ToList();

        //        for (int i = 0; i < qtdJogos; i++)
        //        {

        var randomGame = new Random().Next(list.Count);
        var jogo = (Jogo)Activator.CreateInstance(list[randomGame])!;

        Jogos.Add(new InfoJogo(jogo.Pergunta(), jogo.Resposta()));

        //foreach (var t in ass.GetTypes().Where(x => x.IsClass && typeof(IJogo).IsAssignableFrom(x)))
        //{
        //    var jogo = (IJogo)Activator.CreateInstance(t)!;
        //    if (jogo.TipoDeJogo == tipoJogo)
        //    {

        //    }
        //}
    }

    public void NovaResposta(string expressao)
    {
        Jogos.Last().GravarResposta(expressao);

        if (!FimDePartida())
        {
            NovoJogo();
        }
    }

    private int CountAcertos()
    {
        var count = 0;
        foreach (var jogo in Jogos)
        {
            if (jogo.Acerto && !string.IsNullOrWhiteSpace(jogo.RespostaInformada))
            {
                count++;
            }
        }

        return count;
    }

    private int CountErros()
    {
        var count = 0;
        foreach (var jogo in Jogos)
        {
            if (!jogo.Acerto && !string.IsNullOrWhiteSpace(jogo.RespostaInformada))
            {
                count++;
            }
        }

        return count;
    }

    public void SaveToSession(ISession session)
    {
        session.Set<Partida>("Partida", this);
    }

    public static Partida? ReadFromSession(ISession session)
    {
        return session.Get<Partida>("Partida");
    }

}