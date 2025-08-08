using System.ComponentModel.DataAnnotations;

namespace ControleDeConta.Modelos
{
    public class Pagamento
    {
        public Pagamento(float valor, int dividaId, int devedorId)
        {
            if (valor < 0) throw new ArgumentException("Valor Deve ser maior que zero");
            this.Valor = valor;
            Data = DateTime.UtcNow;
            Divida.Id = dividaId;
            devedor.Id = devedorId;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public float Valor { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public virtual Divida Divida { get; set; }
        [Required]
        public virtual Devedor devedor { get; set; }
    }
}
