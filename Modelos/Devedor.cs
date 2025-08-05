namespace ControleDeConta.Modelos
{
    public class Devedor
    {
        public int id { get; private set; }
        public string nome { get; private set; }
        private string cpf { get; set; }
        private ICollection<Divida> dividas { get; set; }
        private ICollection<Pagamento> pagamentos { get; set; }

        public Devedor(string nome, string cpf)
        {
            this.nome = nome;
            this.cpf = cpf;
        }
    }
}
