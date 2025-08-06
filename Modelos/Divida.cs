using System.ComponentModel.DataAnnotations;

namespace ControleDeConta.Modelos
{
    public class Divida : CalculadoraDeJuros, IPagavel
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public float valor { get; set; }
        [Required]
        public String descricao { get; set; }
        [Required]
        public String tipo { get; set; }
        [Required]
        public DateOnly dataDeInicio { get; set; }
        [Required]  
        public virtual Devedor devedor { get; set; }
        public virtual ICollection<Pagamento> pagamentos { get; set; }
        [Required]
        public int IdPagamentos { get; set; }


        public Divida(float valor, string descricao, DateOnly dataDeInicio, string tipo)
        {
            if (valor > 0)
            {
                this.valor = valor;
            }
            this.descricao = descricao;
            this.dataDeInicio = dataDeInicio;
            this.tipo = tipo;
        }
        public float CalcularJuros(float taxaDeJuros)
        {
            return base.CalcularJuros(taxaDeJuros, valor, dataDeInicio);
        }
        public void Paga(Pagamento pag)
        {
            valor -= pag.Valor;
            pagamentos.Add(pag);
            //Console.WriteLine($"Pagamento recebido no valor de {pag.valor} feito em {pag.data:dd/MM/yyyy HH:mm}");
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
