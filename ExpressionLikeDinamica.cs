using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


public class Teste
{
    public Teste(string descricao1, string descricao2)
    {
        Descricao1 = descricao1;
        Descricao2 = descricao2;
    }

    public string Descricao1 {get; set;}
    public string Descricao2 {get; set;}
}   

public class Program
{   
    public static void Main(string[] args)
    {
        List<Teste> lista =  new(){
            new Teste("Teste1", "Teste2"),
            new Teste("Teste3", "Teste4")
        };

        var expressao = ExpressaoLike<Teste>("Descricao2", "Teste2");

        var filtro = lista.AsQueryable().Where(expressao);

        foreach(var i in filtro)
        {
            Console.WriteLine(i.Descricao1);
        }
    }

    public static Expression<Func<T, bool>> ExpressaoLike<T>(string campoDeBusca, string valorComparado)
    {
        var parametroEXP = Expression.Parameter(typeof(T));

        var campoEXP = Expression.Property(parametroEXP, campoDeBusca);

        MethodInfo metodo = typeof(string).GetMethod("Contains", new[] { typeof(string) });

        var valorEXP = Expression.Constant(valorComparado, typeof(string));

        var expressaoLike = Expression.Call(campoEXP, metodo, valorEXP);

        return Expression.Lambda<Func<T, bool>>(expressaoLike, parametroEXP);
    }
}
