using Aulas.Domain.Models;
using Aulas.Extensions;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;

namespace Aulas.Services;

public class Partida
{
    private Jogador _jogador;

    public int Acertos => CountAcertos();

    public int Erros => CountErros();

    public List<Jogada> Jogos { get; set; } = new();

    public Jogador Jogador => _jogador;

    public Partida(Jogador jogador)
    {
        _jogador = jogador;
    }

    public bool FimDeJogo()
    {
        return (Jogos.Count >= 10);
    }

    public int PontuacaoFinal()
    {
        var pontos = Decimal.Truncate((decimal)CountAcertos() / Jogos.Count * 10);

        return (int)pontos;
    }

    public void Iniciar()
    {
        Jogos.Clear();
    }

    public void NovaJogada(string expressao, bool respostaCerta)
    {
        Jogos.Add(new Jogada(expressao, respostaCerta));
    }

    private int CountAcertos()
    {
        var count = 0;
        foreach (var jogo in Jogos)
        {
            if (jogo.Acerto)
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
            if (!jogo.Acerto)
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