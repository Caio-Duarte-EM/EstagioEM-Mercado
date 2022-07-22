namespace Mercado;

public class Alimento
{
    public string? Nome { get; set; }
    public double Preco { get; set; }
    public static void MostrarTipo()
    {
        Console.Write(" é um alimento");
    }

    public static double CalcularPrecoTotal(List<Alimento> listaDeAlimentos)
    {
        double precoTotal = 0;
        foreach (Alimento alimento in listaDeAlimentos)
        {
            precoTotal += alimento.Preco;
        }
        return precoTotal;
    }  
}