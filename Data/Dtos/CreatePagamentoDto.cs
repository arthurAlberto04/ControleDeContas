using System.ComponentModel.DataAnnotations;

namespace ControleDeConta.Data.Dtos
{
    public class CreatePagamentoDto
    {
        [Required]
        public float valor {  get; set; }
        [Required] 
        public int dividaId { get; set; }
        [Required]
        public int devedorId { get; set; }
    }
}
