using ControleDeConta.Modelos;

namespace ControleDeConta.Data.Dtos
{
    public class ReadDividaDto
    {
        public int Id { get; set; }
        public float valor { get; set; }
        public String descricao { get; set; }
        public String tipo { get; set; }
        public DateOnly dataDeInicio { get; set; }
        public float taxaDeJuros { get; set; }
        public IEnumerable<ReadPagamentoDto> pagamentoDtos { get; set; }
    }
}
