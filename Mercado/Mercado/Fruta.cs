namespace Mercado;

public class Fruta : Alimento
{
    public Fruta(string nomeFruta, string corFruta, double precoFruta)
    {
        Nome = nomeFruta;
        Cor = corFruta;
        Preco = precoFruta;
    }
    public string Cor { get; set; }

    public static void MostrarListaFrutas(List<Fruta> listaDeFrutas)
    {
        Console.Write("NOME         | COR          | PREÇO\n" +
            "-----------------------------------");
        foreach (Fruta fruta in listaDeFrutas)
        {
            Console.Write($"\n{fruta.Nome,-12} | {fruta.Cor,-12} | {fruta.Preco,5:N2}");
        }
    }

    public static void MostrarNomeFrutas(List<Fruta> listaDeFrutas)
    {
        Console.WriteLine("Frutas Disponíveis:");
        foreach (Fruta fruta in listaDeFrutas)
        {
            Console.WriteLine($"{fruta.Nome,-12}");
        }
    }

    public static void MostrarCorFrutas(List<Fruta> listaDeFrutas)
    {
        List<Fruta> ListaDeFrutasComCoresUnicas =
        listaDeFrutas
        .GroupBy(fruta => fruta.Cor)
        .Select(cor => cor.First())
        .ToList();

        Console.WriteLine("Cores Disponíveis:");
        foreach (Fruta fruta in ListaDeFrutasComCoresUnicas)
        {
            Console.WriteLine($"{fruta.Cor,-12}");
        }
    }

    public static string ComparaFruta<T>(T dado1, T dado2) where T : IComparable
    {
        if (dado1 is string)
        {
            if (dado1.CompareTo(dado2) == 0)
            {
                return "tem a mesma cor que";
            }
            else
            {
                return "não tem a mesma cor que";
            }
        }
        else if (dado1 is double)
        {
            if (dado1.CompareTo(dado2) == 0)
            {
                return "\ntem o mesmo preço";
            }
            else if(dado1.CompareTo(dado2) > 0)
            {
                return $"\n {dado1} é mais caro que {dado2}";
            }
            else
            {
                return $"\n{dado2} é mais caro que {dado1}";
            }
        }
        return "";
    }

    public static List<Fruta> OrdenarListaFrutas(List<Fruta> listaDeFrutas, string ordem)
    {
        return ordem switch
        {
            "Nome" => listaDeFrutas.OrderBy(fruta => fruta.Nome).ToList(),
            "Cor" => listaDeFrutas.OrderBy(fruta => fruta.Cor).ToList(),
            _ => listaDeFrutas.OrderBy(fruta => fruta.Preco).ToList()
        };
    }

    public static void FiltarFrutasCor(List<Fruta> listaDeFrutas, string cor)
    {
        IEnumerable<string> FrutaCorEspecifica =
            from Fruta frutas in listaDeFrutas
            where frutas.Cor == cor
            select frutas.Nome;

        foreach (string fruta in FrutaCorEspecifica)
        {
            Console.WriteLine($"\n{fruta} é {cor}");
        }
    }

    public static void FiltrarFrutasPreco(List<Fruta> listaDeFrutas, string maiorOuMenor, double preco)
    {
        if(maiorOuMenor == "Maior")
        {
            IEnumerable<string> FrutaPrecoMaior =
                from Fruta frutas in listaDeFrutas
                where frutas.Preco > preco
                select frutas.Nome;

            foreach (string fruta in FrutaPrecoMaior)
            {
                Console.WriteLine($"\n{fruta} custa mais que R${preco}");
            }
        }
        else if(maiorOuMenor == "Menor")
        {
            IEnumerable<string> FrutaPrecoMenor =
                from Fruta frutas in listaDeFrutas
                where frutas.Preco < preco
                select frutas.Nome;

            foreach (string fruta in FrutaPrecoMenor)
            {
                Console.WriteLine($"\n{fruta} custa menos que R${preco}");
            }
        }
    }

    public static void MostrarTipoFruta()
    {
        Console.Write(" e uma fruta");
    }
}