using ControleDeConta.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ControleDeConta.Data
{
    public class ControleDeContasContext : DbContext
    {
        public ControleDeContasContext(DbContextOptions<ControleDeContasContext> opts) : base(opts) 
        { 
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<Devedor> Devedores { get; set; }
        public DbSet<Divida> Dividas { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
    }
}
