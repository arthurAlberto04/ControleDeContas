using ControleDeConta.Data.Dtos;
using ControleDeConta.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeConta.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DevedorController : ControllerBase
    {
        private DevedorService _service;

        public DevedorController(DevedorService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CreateDevedor([FromBody] CreateDevedorDto dto)
        {
            var createDevedor = _service.CadastraDevedor(dto);
            return CreatedAtAction(nameof(ReadDevedorById), new { id = createDevedor.Id }, createDevedor);
        }

        [HttpGet]
        public IEnumerable<ReadDevedorDto> GetDevedores([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            var autores = _service.GetDevedores(skip, take);
            return autores;
        }

        [HttpGet("{id}")]
        public IActionResult ReadDevedorById(int id)
        {
            var autor = _service.GetDevedorById(id);
            return Ok(autor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDevedor(int id, [FromBody] UpdateDevedorDto dto) 
        { 
            _service.UpdateDevedor(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDevedorById(int id) 
        { 
            _service.DeleteDevedor(id);
            return NoContent();
        }
    }
}
