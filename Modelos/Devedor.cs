using System.ComponentModel.DataAnnotations;

namespace ControleDeConta.Modelos
{
    public class Devedor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Nome { get; set; }
        public virtual ICollection<Divida> dividas { get; set; }
        public virtual ICollection<Pagamento> pagamentos { get; set; }

        public Devedor(string nome)
        {
            this.Nome = nome;
        }
    }
}
