using System;
using System.Collections.Generic;

class Angulo
{
    public int Graus { get; set; }
    public int Minutos { get; set; }
    public int Segundos { get; set; }

    public override string ToString()
    {
        return $"{Graus}º {Minutos}' {Segundos}''";
    }
}

class Estacao
{
    public Angulo AngEstacao { get; set; }
    public Angulo Azimute { get; set; }
    public float Distancia { get; set; }
    public char Deflexao { get; set; }

    public override string ToString()
    {
        return $"{AngEstacao} - {Distancia} - {Deflexao}";
    }
}

class Poligonal
{
    public string Descricao { get; set; }
    public int AzGraus { get; set; }
    public int AzMinutos { get; set; }
    public int AzSegundos { get; set; }
    public List<Estacao> Estacoes { get; set; }

    public Poligonal(string descricao, int azGraus, int azMinutos, int azSegundos)
    {
        Descricao = descricao;
        AzGraus = azGraus;
        AzMinutos = azMinutos;
        AzSegundos = azSegundos;
        Estacoes = new List<Estacao>();
    }

    public float Perimetro()
    {
        float perimetro = 0;
        foreach (var estacao in Estacoes)
        {
            perimetro += estacao.Distancia;
        }
        return perimetro;
    }

    public void Inserir()
    {
        // Implemente a inserção de dados da próxima estação aqui
    }

    public void Editar()
    {
        // Implemente a edição de dados da estação aqui
    }

    public void Excluir()
    {
        // Implemente a exclusão de uma estação aqui
    }

    public void Listar()
    {
        Console.WriteLine($"Poligonal: {Descricao}");
        Console.WriteLine("===========================================");
        Console.WriteLine("Estação Ângulo lido Deflexão Distância(m) Azimute");
        Console.WriteLine("===========================================");

        int pagina = 1;
        int estacoesPorPagina = 10;
        int inicio = (pagina - 1) * estacoesPorPagina;
        int fim = Math.Min(inicio + estacoesPorPagina, Estacoes.Count);

        for (int i = inicio; i < fim; i++)
        {
            var estacao = Estacoes[i];
            Console.WriteLine($"{i + 1:D4} {estacao.AngEstacao} {estacao.Deflexao} {estacao.Distancia} {estacao.Azimute}");
        }

        Console.WriteLine($"Perímetro: {Perimetro()} metros Pag.: {pagina} de {Math.Ceiling((double)Estacoes.Count / estacoesPorPagina)}");
        Console.WriteLine("<Esc> Sair <F1> Inserir <F2> Alterar <F3> Excluir <PgDn> <PgUp>");
    }

    public void CalcularAzimutes()
    {
        // Implemente o cálculo dos azimutes aqui conforme as observações
    }
}

class Program
{
    static void Main()
    {
        // Exemplo de uso
        var poligonal = new Poligonal("Fazenda Rio Verde", 225, 32, 48);
        poligonal.Listar();

        Console.ReadKey();
    }
}
