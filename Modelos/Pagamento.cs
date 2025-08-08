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
            this.dividaId = dividaId;
            this.devedorId = devedorId;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public float Valor { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public int dividaId { get; set; }
        public virtual Divida divida { get; set; }
        [Required]
        public int devedorId { get; set; }
        public virtual Devedor devedor { get; set; }
    }
}
