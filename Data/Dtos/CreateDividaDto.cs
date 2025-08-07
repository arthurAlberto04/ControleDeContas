using ControleDeConta.Modelos;
using System.ComponentModel.DataAnnotations;

namespace ControleDeConta.Data.Dtos
{
    public class CreateDividaDto
    {
        [Required]
        public float Valor {  get; set; }
        [Required]
        public String descricao { get; set; }
        [Required]
        public String tipo { get; set; }
        [Required]
        public DateOnly dataDeInicio { get; set; }
        [Required]
        public int devedorId { get; set;}
    }
}
