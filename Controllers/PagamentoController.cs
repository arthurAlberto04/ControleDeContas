using ControleDeConta.Data.Dtos;
using ControleDeConta.Modelos;
using ControleDeConta.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeConta.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PagamentoController : ControllerBase
    {
        private PagamentoService _service;

        public PagamentoController(PagamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriaPagamento([FromBody] CreatePagamentoDto dto)
        {
            var pagamento = _service.CreatePagamento(dto);
            return CreatedAtAction(nameof(GetPagamentoById), new { id = pagamento.Id }, pagamento);
        }

        [HttpGet]
        public IEnumerable<ReadPagamentoDto> GetPagamentos(int skip = 0, int take = 50) 
        { 
            return _service.ReadPagamento(skip, take);
        }

        [HttpGet("{id}")]
        public IActionResult GetPagamentoById(int id) 
        {
            var pag = _service.ReadPagamentoById(id);
            return Ok(pag);
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePagamento(int id, [FromBody] UpdatePagamentoDto dto) 
        { 
            _service.UpdatePagamento(id, dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            _service.DeletePagamento(id);
            return NoContent();
        }
    }
}
