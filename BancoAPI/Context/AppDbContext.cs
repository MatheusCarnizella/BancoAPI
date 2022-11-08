using BancoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        { }

        public DbSet<Transacao>? Transacao { get; set; }
        public DbSet<Cliente>? Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Cliente>().HasKey(c => c.Nome);
            mb.Entity<Cliente>().Property(c => c.Documento).HasMaxLength(100).IsRequired();
            mb.Entity<Cliente>().Property(c => c.chavePix).IsRequired();

            mb.Entity<Transacao>().HasKey(c => c.chaveOrigem);
            mb.Entity<Transacao>().Property(c => c.Valor).HasPrecision(14, 2).IsRequired();
            mb.Entity<Transacao>().Property(c => c.chaveDestino).IsRequired();

            mb.Entity<Transacao>()
                .HasOne<Cliente>(c => c.Cliente)
                .WithMany(t => t.Transacoes)
                .HasForeignKey(c => c.chavePix);
        }
    }
}
