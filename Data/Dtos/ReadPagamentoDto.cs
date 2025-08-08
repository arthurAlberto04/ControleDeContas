using ControleDeConta.Modelos;

namespace ControleDeConta.Data.Dtos
{
    public class ReadPagamentoDto
    {
        public int Id { get; set; }
        public float valor { get; set; }
        public DateTime data {  get; set; }
        public virtual Devedor devedor { get; set; }
        public virtual Divida divida { get; set; }
    }
}
