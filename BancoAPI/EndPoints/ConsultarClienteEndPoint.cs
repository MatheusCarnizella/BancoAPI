using BancoAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.EndPoints
{
    public static class ConsultarClienteEndPoint
    {
        public static void MapConsultarClienteEndPoint(this WebApplication app)
        {
            app.MapGet("/consultarCliente", async (AppDbContext db) => await db.Cliente.ToListAsync())
      .WithTags("Consultar Cliente");
        }
    }
}
