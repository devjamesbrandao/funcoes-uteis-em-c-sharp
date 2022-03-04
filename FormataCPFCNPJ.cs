using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(FormatarCPFCNPJ("12345678912"));
    }

    public static string FormatarCPFCNPJ(string valor)
    {
        var valorLimpo = Regex.Replace(valor, "[^0-9]", "");

        string valorFormatado = "";

        if(valorLimpo.Length == 11)
        {
            valorFormatado = Convert.ToUInt64(valorLimpo).ToString(@"000\.000\.000\-00");
        }
        else if(valorLimpo.Length == 14)
        {
            valorFormatado = Convert.ToUInt64(valorLimpo).ToString(@"00\.000\.000\/0000\-00");
        }
        else
        {
            valorFormatado = "00000000000";
        }

        return valorFormatado;
    }
}
