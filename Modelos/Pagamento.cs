namespace ControleDeConta.Modelos
{
    public class Pagamento
    {
        public Pagamento(float valor)
        {
            if (valor < 0) throw new ArgumentException("Valor Deve ser maior que zero");
            this.valor = valor;
            data = DateTime.UtcNow;
        }

        public int id { get; private set; }
        public float valor { get; private set; }
        public DateTime data { get; private set; }
        public Divida divida { get; private set; }
        public int IdDivida { get; private set; }
        public Devedor devedor { get; private set; }
        public int IdDevedor { get; private set; }
    }
}
