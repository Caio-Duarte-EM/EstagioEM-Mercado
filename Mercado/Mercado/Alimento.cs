namespace Mercado;

public class Alimento
{
    public string? Nome { get; set; }
    public double Preco { get; set; }
    public Data DataDeValidade { get; set; }
    public static void MostrarTipo()
    {
        Console.Write(" é um alimento");
    }

    public static double CalcularPrecoTotal(List<Alimento> listaDeAlimentos)
    {
        double precoTotal;
        return precoTotal = listaDeAlimentos.Sum(Alimento => Alimento.Preco);
    }

    public static void MostrarListaAlimentos(List<Alimento> listaDeAlimentos)
    {
        Console.Write("NOME         | PREÇO  | DATA DE VALIDADE\n" +
            "----------------------------------------");
        foreach (Alimento alimento in listaDeAlimentos)
        {
            if (alimento is Fruta)
            {
                Console.Write($"\n{alimento.Nome,-12} | {alimento.Preco,-6:N2} | --/--/----");
            }
            else
            {
                Console.Write($"\n{alimento.Nome,-12} | {alimento.Preco,-6:N2} | {alimento.DataDeValidade.Valor,9}");
            }
        }
    }

    public static void MostrarNomeAlimentos(List<Alimento> listaDeAlimentos)
    {
        Console.WriteLine("Alimentos Disponíveis:");
        foreach (Alimento alimento in listaDeAlimentos)
        {
            if (alimento is Fruta)
            {
                continue;
            }
            Console.WriteLine($"{alimento.Nome,-12}");
        }
    }
}