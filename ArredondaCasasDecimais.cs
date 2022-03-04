using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(ArredondarCasasDecimais(12.3333M, 2));
    }

    public static decimal ArredondarCasasDecimais(decimal valor, double casasDecimais)
    {
        var potencia = Convert.ToDecimal(Math.Pow(10, casasDecimais));
        
        return Math.Floor(valor * potencia) / potencia;
    }
}
