using BancoAPI.Context;
using BancoAPI.Models;

namespace BancoAPI.EndPoints
{
    public static class CadastrarClienteEndPoint
    {
        public static void MapCadastrarClienteEndPoint(this WebApplication app)
        {
            app.MapPost("/cadastrarCliente", async (Cliente cliente, AppDbContext db) =>
            {
                db.Cliente.Add(cliente);
                await db.SaveChangesAsync();

                return Results.Created($"/cadastrarCliente/{cliente.Nome}", cliente);
            })
      .WithTags("Cadastrar Cliente");
        }
    }
}
