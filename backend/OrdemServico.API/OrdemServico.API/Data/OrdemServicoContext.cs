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
    }
}