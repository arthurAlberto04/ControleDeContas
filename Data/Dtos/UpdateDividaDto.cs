using System.ComponentModel.DataAnnotations;

namespace ControleDeConta.Data.Dtos
{
    public class UpdateDividaDto
    {
        [Required]
        public float valor { get; set; }
        [Required]
        public string descricao { get; set; }
        [Required]
        public String tipo { get; set; }
        [Required]
        public DateOnly dataDeInicio { get; set; }
        [Required]
        public float taxaDeJuros { get; set; }
    }
}
