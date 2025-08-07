using System.ComponentModel.DataAnnotations;

namespace ControleDeConta.Data.Dtos
{
    public class UpdateDevedorDto
    {
        [Required]
        public String Nome { get; set; }
    }
}
