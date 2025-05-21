namespace Brasileirao;

public class Time
{
    public string Nome { get; set; }
    public int Pontos { get; set; }

    public int Vitorias { get; set; }

    public int Derrotas { get; set; }

    public int Empate { get; set; }

    public List<string> Historico { get; set; } = new List<string>();


    public string Resumo => $"{Nome}: {Pontos} pontos. {Vitorias} V, {Derrotas} D, {Empate} E\n" +
        string.Join("\n", Historico);

    public Time() { }

    public Time(string nome)
    {
        Nome = nome;
        Pontos = 0;
        Vitorias = 0;
        Derrotas = 0;
        Empate = 0;
    }

    public void JogarPartida(Time t, char resultado)
    {
        if (resultado.Equals('v'))
        {
            Pontos += 3;
            Vitorias++;
            t.Derrotas++;
            Historico.Add($"Vitória contra {t.Nome}");
            t.Historico.Add($"Derrota para {Nome}");
        } else if (resultado.Equals('e'))
            {
            Pontos++;
            Empate++;
            t.Pontos++;
            t.Empate++;
            Historico.Add($"Empate com {t.Nome}");
            t.Historico.Add($"Empate com {Nome}");
        } else if (resultado.Equals('d'))
        {
            Derrotas++;
            t.Vitorias++;
            t.Pontos += 3;
            Historico.Add($"Derrota para {t.Nome}");
            t.Historico.Add($"Vitória contra {Nome}");
        }
    }

    public override string ToString()
    {
        return $"{Nome}: {Pontos} pontos";
    }
}
