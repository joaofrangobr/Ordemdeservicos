using Microsoft.EntityFrameworkCore;
using OrdemServico.API.Models;

namespace OrdemServico.API.Data
{
    public class OrdemServicoContext : DbContext
    {
        public OrdemServicoContext(DbContextOptions<OrdemServicoContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Chamado> Chamados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chamado>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Chamado>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(c => c.PrestadorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}