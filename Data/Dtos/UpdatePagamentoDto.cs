using ControleDeConta.Modelos;
using System.ComponentModel.DataAnnotations;

namespace ControleDeConta.Data.Dtos
{
    public class UpdatePagamentoDto
    {
        [Required]
        public float Valor { get; set; }
        [Required]
        public int dividaId { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public int devedorId { get; set; }
    }
}
