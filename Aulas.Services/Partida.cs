using Aulas.Domain.Models;
using Aulas.Extensions;
using Aulas.Jogos;
using Aulas.Jogos.Soma;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Aulas.Services;

public class Partida
{
    private Jogador _jogador;
    private readonly IConfiguration _config;

    public int qtdJogos { get; set; } = 0;
    
    public int Acertos => CountAcertos();

    public int Erros => CountErros();

    public List<Jogo> Jogos { get; set; } = new();

    public Jogador Jogador => _jogador;

    public Partida(Jogador jogador)
    {
        _jogador = jogador;

        _config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)!.FullName)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            //.AddEnvironmentVariables()
            .Build();
    }

    public bool FimDePartida()
    {
        return (qtdJogos > 0 && Jogos.Count(x => x.RespostaInformada != "") >= qtdJogos);
    }

    public int PontuacaoFinal()
    {
        var pontos = Decimal.Truncate((decimal)CountAcertos() / Jogos.Count * 10);

        return (int)pontos;
    }

    public void Iniciar()
    {
        Jogos.Clear();

        qtdJogos = Math.Min(
            _config.GetValue<int>("Perguntas"),
            MaxPerguntas()
        );

        NovoJogo();
    }

    private int MaxPerguntas()
    {
        // CONTA O MÁXIMO DE JOGOS QUE ESSA PARTIDA PODE TER, BASEADO NO FILTRO ESCOLHIDO
        var max = 0;
        var jogos = TipoJogo.ListInstances();
        foreach (var jogo in jogos)
        {
            jogo.PreparaPergunta(_config);
            max += jogo.MaxPerguntas;
        }

        return max;
    }

    private void NovoJogo()
    {
        // ADICIONAR SOMENTE SE ESSA PERGUNTA JÁ NÃO TIVER SIDO FEITA
        Jogo jogo;
        do
        {
            jogo = TipoJogo.Random();
            jogo.PreparaPergunta(_config);
        } while (Jogos.Any(x => x.Pergunta == jogo.Pergunta));

        Jogos.Add(jogo);
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