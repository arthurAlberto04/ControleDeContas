namespace ControleDeConta
{
    public class Divida : CalculadoraDeJuros, IPagavel
    {
        private float valor { get; set; }
        private String descricao { get; set; }
        private DateOnly dataDeInicio { get; set; }
        private Devedor devedor { get; set; }
        private ICollection<Pagamento> pagamentos { get; set; }

        public Divida(float valor, string descricao, DateOnly dataDeInicio)
        {
            if (valor > 0)
            {
                this.valor = valor;
            }
            this.descricao = descricao;
            this.dataDeInicio = dataDeInicio;
        }
        public float CalcularJuros(float taxaDeJuros)
        {
            return base.CalcularJuros(taxaDeJuros, this.valor, this.dataDeInicio);
        }
        public void Paga(Pagamento pag) 
        {
            this.valor -= pag.valor;
            pagamentos.Add(pag);
            Console.WriteLine($"Pagamento recebido no valor de {pag.valor} feito em {pag.data:dd/MM/yyyy HH:mm}");
        }
        public override string ToString()
        {
            return $"Divida no valor de R${this.valor}, Devedor: {devedor.nome} " +
                $"lista de pagamentos recebidos - {ListarPagamentos} "; 
        }
        public void ListarPagamentos() 
        { 
            foreach (var pag in pagamentos) 
            {
                Console.WriteLine($"R${pag.valor}, feito em {pag.data:dd/MM/yyyy HH:mm}");            
            }
        }
    }
}
