using System.ComponentModel.DataAnnotations;

namespace ControleDeConta.Data.Dtos
{
    public class CreateDevedorDto
    {
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Cpf { get; set; }
    }
}
