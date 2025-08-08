using System.ComponentModel.DataAnnotations;

namespace ControleDeConta.Modelos
{
    public class Divida : CalculadoraDeJuros
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public float taxaDeJuros { get; set; } 
        [Required]
        public float valor { get; set; }
        [Required]
        public String descricao { get; set; }
        [Required]
        public String tipo { get; set; }
        [Required]
        public DateOnly dataDeInicio { get; set; }
        [Required]
        public int devedorId { get; set; }
        public virtual Devedor devedor { get; set; }
        public virtual ICollection<Pagamento> pagamentos { get; set; }


        public Divida(float valor, string descricao, DateOnly dataDeInicio, string tipo, float taxaDeJuros)
        {
            this.descricao = descricao;
            this.dataDeInicio = dataDeInicio;
            this.tipo = tipo;
            this.taxaDeJuros = taxaDeJuros;
            if (valor > 0)
            {
                this.valor = valor;
            }
        }
        public float CalcularJuros()
        {
            return base.CalcularJuros(this.taxaDeJuros, this.valor, this.dataDeInicio);
        }
        public override string ToString()
        {
            return $"Divida no valor de R${valor}, Devedor: {devedor.Nome} " +
                $"lista de pagamentos recebidos - {ListarPagamentos} ";
        }
        public void ListarPagamentos()
        {
            foreach (var pag in pagamentos)
            {
                Console.WriteLine($"R${pag.Valor}, feito em {pag.Data:dd/MM/yyyy HH:mm}");
            }
        }
    }
}
