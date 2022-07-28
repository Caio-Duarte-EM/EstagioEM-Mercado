using Mercado;

Console.WriteLine("BEM VINDO AO MERCADO\n" +
        "_______________________");
List<Fruta> FrutasDisponiveis = new();
List<Alimento> AlimentosDisponiveis = new();
while (true)
{
    string? OpcaoMenu = MostrarMenuOpcoes();
    if (OpcaoMenu == "999")
    {
        Console.WriteLine("Obrigado e volte sempre!\n");
        break;
    }
    if (OpcaoMenu == "1")
    {
        AdicionarFrutaNasListas(FrutasDisponiveis, AlimentosDisponiveis);
        continue;
    }
    if (OpcaoMenu == "2")
    {
        RemoverFrutaDasListas(FrutasDisponiveis, AlimentosDisponiveis);
        continue;
    }
    if (OpcaoMenu == "3")
    {
        Console.WriteLine("Deseja comparar frutas com base\n" +
            "(1) Na cor\n" +
            "(2) No preço");
        string? opcaoComparacao = Console.ReadLine();
        if (opcaoComparacao == "1")
        {
            CompararFrutasNaCor(FrutasDisponiveis);
        }
        else if (opcaoComparacao == "2")
        {
            CompararFrutasNoPreco(FrutasDisponiveis);
        }
        else
        {
            Console.WriteLine("Opção inválida");
        }
        continue;
    }
    if (OpcaoMenu == "4")
    {
        Console.WriteLine("Ordenar frutas por:\n" +
            "(1) - Nome\n" +
            "(2) - Cor\n" +
            "(3) - Preço\n");
        string? opcaoOrdenacao = Console.ReadLine();
        if (opcaoOrdenacao == "1")
        {
            List<Fruta> ListaOrdenadaNome = Fruta.OrdenarListaFrutas(FrutasDisponiveis, "Nome");
            Fruta.MostrarListaFrutas(ListaOrdenadaNome);
        }
        else if (opcaoOrdenacao == "2")
        {
            List<Fruta> ListaOrdenadaCor = Fruta.OrdenarListaFrutas(FrutasDisponiveis, "Cor");
            Fruta.MostrarListaFrutas(ListaOrdenadaCor);
        }
        else if (opcaoOrdenacao == "3")
        {
            List<Fruta> ListaOrdenadaPreco = Fruta.OrdenarListaFrutas(FrutasDisponiveis, "Preco");
            Fruta.MostrarListaFrutas(ListaOrdenadaPreco);
        }
        else
        {
            Console.WriteLine("Opção Inválida");
        }
        continue;
    }
    if (OpcaoMenu == "5")
    {
        Console.WriteLine("Consultar frutas por: \n" +
            "(1) - Cor\n" +
            "(2) - Preço\n");
        string? opcaoConsulta = Console.ReadLine();
        if (opcaoConsulta == "1")
        {
            ConsuultarFrutasPelaCor(FrutasDisponiveis);
        }
        else if (opcaoConsulta == "2")
        {
            ConsultarFrutasPeloPreco(FrutasDisponiveis);
        }
        else
        {
            Console.WriteLine("Opção Inválida");
        }
        continue;
    }
    if (OpcaoMenu == "6")
    {
        AdicionarAlimentoNaLista(AlimentosDisponiveis);
        continue;
    }
    if (OpcaoMenu == "7")
    {
        RemoverAlimentosDaLista(AlimentosDisponiveis);
        continue;
    }
    if (OpcaoMenu == "8")
    {
        MostrarListas(FrutasDisponiveis, AlimentosDisponiveis);
        continue;
    }
    if (OpcaoMenu == "9")
    {
        Console.WriteLine($"R$ {Alimento.CalcularPrecoTotal(AlimentosDisponiveis)} até agora.");
        continue;
    }

    Console.WriteLine("Opção inválida, tente novamente!");
}

foreach (Alimento alimento in AlimentosDisponiveis){
    Console.Write(alimento.Nome);
    Alimento.MostrarTipo();

    if (alimento is Fruta fruta)
    {
        Fruta.MostrarTipoFruta();
    }
    Console.WriteLine("");
}

Console.WriteLine($"Programa encerrado com um total de {AlimentosDisponiveis.Count} alimentos sendo {FrutasDisponiveis.Count} frutas");
Console.WriteLine($"Preço total da compra: {Alimento.CalcularPrecoTotal(AlimentosDisponiveis):N2}");
Console.WriteLine("Deseja emitir nota fiscal?\n" +
    "(1) - SIM\n" +
    "(2) - NÃO\n\n" +
    "Digite qualquer tecla pra encerrar o programa!");
string? opcaoNotaFiscal = Console.ReadLine();
if (opcaoNotaFiscal == "1")
{
    EmitirNotaFiscal(AlimentosDisponiveis);
}
Console.WriteLine("Obrigado e volte sempre!");

static string? MostrarMenuOpcoes()
{
    Console.WriteLine("\nO que deseja fazer?\n" +
            "(1) - ADICIONAR FRUTA\n" +
            "(2) - REMOVER FRUTA\n" +
            "(3) - COMPARAR FRUTAS\n" +
            "(4) - ORDENAR LISTA DE FRUTAS\n" +
            "(5) - FILTRAR FRUTAS\n" +
            "(6) - ADICIONAR ALIMENTO\n" +
            "(7) - REMOVER ALIMENTO\n" +
            "(8) - MOSTRAR LISTAS\n" +
            "(9) - CALCULAR VALOR DA COMPRA\n" +
            "(999) - SAIR");
    string? OpcaoMenu = Console.ReadLine();
    Console.Clear();
    return OpcaoMenu;
}

static void AdicionarFrutaNasListas(List<Fruta> listaDeFrutas, List<Alimento> listaDeAlimentos)
{
    string? nomeFruta = null;
    while (string.IsNullOrWhiteSpace(nomeFruta))
    {
        Console.Write("Nome da fruta: ");
        nomeFruta = Console.ReadLine();
    }
    string? corFruta = null;
    while (string.IsNullOrWhiteSpace(corFruta))
    {
        Console.Write("Cor da fruta: ");
        corFruta = Console.ReadLine();
    }
    double precoFruta = 0;
    while (precoFruta == 0)
    {
        Console.Write("Preço da fruta: ");
        string? precoFrutaRecebido = Console.ReadLine();
        if (double.TryParse(precoFrutaRecebido, out precoFruta))
        {
            Fruta novaFruta = new(nomeFruta, corFruta, precoFruta);
            listaDeFrutas.Add(novaFruta);
            listaDeAlimentos.Add(novaFruta);
            Console.WriteLine($"{nomeFruta} adicionado com sucesso à lista");
        }
        else
        {
            Console.WriteLine("Valor inválido, tente novamente");
        }
    }
}

static void RemoverFrutaDasListas(List<Fruta> listaDeFrutas, List<Alimento> listaDeAlimentos)
{
    string? remover = null;
    while (string.IsNullOrWhiteSpace(remover))
    {
        Fruta.MostrarNomeFrutas(listaDeFrutas);
        Console.WriteLine("\nQual o nome da fruta que deseja remover?");
        remover = Console.ReadLine();
    }

    string? nomeRemocao = null;
    foreach (Fruta fruta in listaDeFrutas)
    {
        if (fruta.Nome == remover)
        {
            nomeRemocao = fruta.Nome;
        }
    }
    if (nomeRemocao is null)
    {
        Console.WriteLine("Fruta inválida");
    }
    else
    {
        listaDeFrutas.RemoveAll(fruta => fruta.Nome == nomeRemocao);
        listaDeAlimentos.RemoveAll(fruta => fruta.Nome == nomeRemocao);
        Console.WriteLine($"{nomeRemocao} removido com sucesso");
    }
}

static void CompararFrutasNaCor(List<Fruta> listaDeFrutas)
{
    Fruta.MostrarNomeFrutas(listaDeFrutas);
    Console.WriteLine("Quais frutas deseja comparar a cor?");
    string? NomeFrutaPorCor1 = Console.ReadLine();
    string? NomeFrutaPorCor2 = Console.ReadLine();
    string? CorPrimeiraFruta = null;
    string? CorSegundaFruta = null;

    foreach (Fruta fruta in listaDeFrutas)
    {
        if (fruta.Nome == NomeFrutaPorCor1)
        {
            CorPrimeiraFruta = fruta.Cor;
        }
        else if (fruta.Nome == NomeFrutaPorCor2)
        {
            CorSegundaFruta = fruta.Cor;
        }
    }

    if (CorPrimeiraFruta is null || CorSegundaFruta is null)
    {
        Console.WriteLine("Uma ou mais frutas inválidas");
    }
    else
    {
        Console.WriteLine($"{NomeFrutaPorCor1} {Fruta.ComparaFruta(CorPrimeiraFruta, CorSegundaFruta)} {NomeFrutaPorCor2}");
    }
}

static void CompararFrutasNoPreco(List<Fruta> listaDeFrutas)
{
    Fruta.MostrarNomeFrutas(listaDeFrutas);
    Console.WriteLine("Quais futas deseja comparar o preço?");
    var NomeFrutaPorPreco1 = Console.ReadLine();
    var NomeFrutaPorPreco2 = Console.ReadLine();
    double PrecoPrimeiraFruta = 0;
    double PrecoSegundaFruta = 0;
    foreach (Fruta fruta in listaDeFrutas)
    {
        if (NomeFrutaPorPreco1 == fruta.Nome)
        {
            PrecoPrimeiraFruta = fruta.Preco;
        }
        else if (NomeFrutaPorPreco2 == fruta.Nome)
        {
            PrecoSegundaFruta = fruta.Preco;
        }
    }
    if (PrecoPrimeiraFruta == 0 || PrecoSegundaFruta == 0)
    {
        Console.WriteLine("Uma ou mais frutas inválidas");
    }
    else
    {
        Console.WriteLine(Fruta.ComparaFruta(PrecoPrimeiraFruta, PrecoSegundaFruta));
    }
}

static void ConsuultarFrutasPelaCor(List<Fruta> listaDeFrutas)
{
    Fruta.MostrarCorFrutas(listaDeFrutas);
    Console.WriteLine("Qual cor?");
    var corConsultada = Console.ReadLine();
    string? Cor = null;
    foreach (Fruta fruta in listaDeFrutas)
    {
        if (corConsultada == fruta.Cor)
        {
            Cor = fruta.Cor;
        }
    }
    if (Cor == null)
    {
        Console.WriteLine("Cor inválida");
    }
    else
    {
        Fruta.FiltarFrutasCor(listaDeFrutas, Cor);
    }
}

static void ConsultarFrutasPeloPreco(List<Fruta> listaDeFrutas)
{
    double precoFrutaConsultado = 0;
    while (precoFrutaConsultado == 0)
    {
        Console.WriteLine("Qual preço?");
        string? precoFrutaRecebido = Console.ReadLine();
        if (double.TryParse(precoFrutaRecebido, out precoFrutaConsultado))
        {
            Console.WriteLine($"Maior ou menor que {precoFrutaConsultado}?\n" +
                $"(1) - Maior\n" +
                $"(2) - Menor");
            var consultaMaiorMenor = Console.ReadLine();
            if (consultaMaiorMenor == "1")
            {
                Fruta.FiltrarFrutasPreco(listaDeFrutas, "Maior", precoFrutaConsultado);
            }
            else if (consultaMaiorMenor == "2")
            {
                Fruta.FiltrarFrutasPreco(listaDeFrutas, "Menor", precoFrutaConsultado);
            }
            else
            {
                Console.WriteLine("Opção Inválida");
            }
        }
        else
        {
            Console.WriteLine("Valor inválido, tente novamente");
        }
    }
}

static void AdicionarAlimentoNaLista(List<Alimento> listaDeAlimentos)
{
    string? nomeAlimento = null;
    while (string.IsNullOrWhiteSpace(nomeAlimento))
    {
        Console.Write("Nome do alimento: ");
        nomeAlimento = Console.ReadLine();
    }
    double precoAlimento = 0;
    while (precoAlimento == 0)
    {
        Console.Write("Preço do alimento: ");
        string? precoAlimentoRecebido = Console.ReadLine();
        if (Double.TryParse(precoAlimentoRecebido, out precoAlimento))
        {
            Alimento novoAlimento = new()
            {
                Nome = nomeAlimento,
                Preco = precoAlimento
            };
            listaDeAlimentos.Add(novoAlimento);
            Console.WriteLine($"{nomeAlimento} adicionado com sucesso à lista");
        }
        else
        {
            Console.WriteLine("Valor inválido, tente novamente");
        }
    }
}

static void EmitirNotaFiscal(List<Alimento> listaDeAlimentos)
{
    Console.Write("NOME         | PREÇO\n" +
            "--------------------------");
    foreach (var alimento in listaDeAlimentos)
    {
        Console.Write($"\n{alimento.Nome,-12} | {alimento.Preco,6:N2}");
    }
    Console.WriteLine("\n--------------------------\n" +
        $"TOTAL:       | {Alimento.CalcularPrecoTotal(listaDeAlimentos),6:N2}");
}

static void RemoverAlimentosDaLista(List<Alimento> listaDeAlimentos)
{
    string? remover = null;
    while (string.IsNullOrWhiteSpace(remover))
    {
        Alimento.MostrarNomeAlimentos(listaDeAlimentos);
        Console.WriteLine("\nQual o nome do alimento que deseja remover?");
        remover = Console.ReadLine();
    }

    string? nomeRemocao = null;
    foreach (Alimento alimento in listaDeAlimentos)
    {
        if (alimento.Nome == remover)
        {
            nomeRemocao = alimento.Nome;
        }
    }
    if (nomeRemocao is null)
    {
        Console.WriteLine("Alimento inválido");
    }
    else
    {
        listaDeAlimentos.RemoveAll(alimento => alimento.Nome == nomeRemocao);
        Console.WriteLine($"{nomeRemocao} removido com sucesso");
    }
}

static void MostrarListas(List<Fruta> FrutasDisponiveis, List<Alimento> AlimentosDisponiveis)
{
    string? opcaoLista = null;
    while (string.IsNullOrWhiteSpace(opcaoLista))
    {
        Console.WriteLine("Deseja ver lista de alimentos ou somente frutas?\n" +
            "(1) - Alimentos\n" +
            "(2) - Frutas");
        opcaoLista = Console.ReadLine();
        if (opcaoLista == "1")
        {
            Alimento.MostrarListaAlimentos(AlimentosDisponiveis);
        }
        else if(opcaoLista == "2")
        {
            Fruta.MostrarListaFrutas(FrutasDisponiveis);
        }
        else
        {
            Console.WriteLine("Opção inválida");
        }
    }
}