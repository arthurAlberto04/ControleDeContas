using System.ComponentModel.DataAnnotations;

namespace ControleDeConta.Modelos
{
    public class Devedor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        public virtual ICollection<Divida> dividas { get; set; }
        [Required]
        public int IdDividas { get; set; }
        public virtual ICollection<Pagamento> pagamentos { get; set; }
        [Required]
        public int IdPagamentos { get; set; }

        public Devedor(string nome, string cpf)
        {
            this.Nome = nome;
            this.Cpf = cpf;
        }
    }
}
