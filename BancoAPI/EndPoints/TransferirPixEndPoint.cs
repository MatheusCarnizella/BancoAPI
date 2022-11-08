using BancoAPI.Context;
using BancoAPI.Models;

namespace BancoAPI.EndPoints
{
    public static class TransferirPixEndPoint
    {
        public static void MapTransferirPixEndPoint(this WebApplication app)
        {
            app.MapPost("/transferenciaPix", async (Transacao transacao, AppDbContext db) =>
            {
                db.Transacao.Add(transacao);
                await db.SaveChangesAsync();

                return Results.Created($"/cadastrarCliente/{transacao.chavePix}", transacao);
            })
  .WithTags("Transfrencia Pix");
        }
    }
}
