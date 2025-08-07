using ControleDeConta.Data.Dtos;
using ControleDeConta.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeConta.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DividaController : ControllerBase
    {
        private DividaService _service;

        public DividaController(DividaService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult CriaDivida([FromBody] CreateDividaDto dto)
        {
            var divida = _service.CreateDivida(dto);
            return CreatedAtAction(nameof(GetDividaById), new { id = divida.Id }, divida);
        }

        [HttpGet]
        public IEnumerable<ReadDividaDto> GetDividas() 
        {
            return _service.GetDivida();
        }

        [HttpGet("{id}")]
        public IActionResult GetDividaById(int id)
        {
            var divida = _service.GetDividaById(id);
            return Ok(divida);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDivida([FromBody] UpdateDividaDto dto, int id) 
        { 
            _service.UpdateDivida(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDivida(int id) 
        { 
            _service.DeleteDivida(id);
            return NoContent();
        }
    }
}
