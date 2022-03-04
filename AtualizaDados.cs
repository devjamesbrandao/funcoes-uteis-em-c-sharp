using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public Context(){}

    public Context(DbContextOptions<Context> options) : base(options) {}
}

public class Program
{   
    public async Task AtualizaDados<T>(
        T entidade, params Expression<Func<T, object>>[] camposAlterados
    )
    {
        // Contexto do banco de dados
        var context = new Context(); 

        var dbEntry = context.Entry(entidade);

        MemberExpression body;

        foreach(var campoAlterado in camposAlterados)
        {
            body = campoAlterado.Body as MemberExpression;

            dbEntry.Property(body.Member.Name).IsModified = true;
        }

        try
        {
            await context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException) // Evita erros se não conseguir atualizar
        {
            return;
        }
    }
}
