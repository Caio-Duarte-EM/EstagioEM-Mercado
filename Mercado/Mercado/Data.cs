namespace Mercado;
public readonly struct Data
{
    public readonly string Valor;

    private Data(string valorData)
    {
        Valor = ValorDataEhValido(valorData) ? FormateData(valorData) : "";
    }

    public static implicit operator string(Data data) => data.Valor;
    public static explicit operator Data(string valor) => new(valor);

    static bool ValorDataEhValido(string data)
    {
        string[] mesesCom30Dias = { "04", "06", "09", "11" };
        if (string.IsNullOrWhiteSpace(data))
        {
            return false;
        }

        if (data.Length != 8)
        {
            return false;
        }

        bool dataEhNumerica = long.TryParse(data, out _);
        if (dataEhNumerica == false)
        {
            return false;
        }

        string dia = data.Substring(0, 2);
        string mes = data.Substring(2, 2);
        string ano = data.Substring(4, 4);

        if (int.Parse(dia) > 31 || int.Parse(dia) <= 0)
        {
            return false;
        }

        if (int.Parse(mes) > 12 || int.Parse(mes) <= 0)
        {
            return false;
        }

        if (mes == "02" && int.Parse(dia) > 28)
        {
            return false;
        }
        else if (mesesCom30Dias.Contains(mes) && dia == "31")
        {
            return false;
        }

        if (int.Parse(ano) < 2022)
        {
            return false;
        }
        return true;
    }

    static string FormateData(string data)
    {
        return Convert.ToUInt64(data).ToString(@"00\/00\/0000");
    }
}