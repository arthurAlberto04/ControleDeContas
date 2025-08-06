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
        DbSet<Devedor> Devedores { get; set; }
        DbSet<Divida> Dividas { get; set; }
        DbSet<Pagamento> Pagamentos { get; set; }
    }
}
