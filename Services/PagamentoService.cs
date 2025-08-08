using ControleDeConta.Data;
using ControleDeConta.Data.Dtos;
using ControleDeConta.Modelos;

namespace ControleDeConta.Services
{
    public class PagamentoService
    {
        private ControleDeContasContext _context;

        public PagamentoService(ControleDeContasContext context)
        {
            _context = context;
        }

        public Pagamento CreatePagamento(CreatePagamentoDto dto) 
        {
            Pagamento pagamento = new Pagamento(dto.valor, dto.dividaId, dto.devedorId);
            _context.Add(pagamento);

            var devedor = _context.Devedores.FirstOrDefault(d => d.Id == dto.devedorId);
            if (devedor == null) { throw new Exception("Devedor não encontrado"); }
            devedor.pagamentos.Add(pagamento);

            var divida = _context.Dividas.FirstOrDefault(d => d.Id == dto.dividaId);
            if (divida == null) { throw new Exception("Divida não encontrada"); }
            divida.valor -= pagamento.Valor;
            divida.pagamentos.Add(pagamento);

            _context.SaveChanges();
            return pagamento;
        }

        public IEnumerable<ReadPagamentoDto> ReadPagamento(int skip = 0, int take = 50) 
        { 
            var pagamentos = _context.Pagamentos.Skip(skip).Take(take).ToList();
            List<ReadPagamentoDto> listaDto = new List<ReadPagamentoDto>();
            foreach (var pagamento in pagamentos) 
            { 
                ReadDevedorDto Dto = new ReadDevedorDto 
                { 
                    Id = pagamento.devedor.Id,
                    Nome = pagamento.devedor.Nome
                
                };
                ReadPagamentoDto pagamentoDto = new ReadPagamentoDto 
                { 
                    Id = pagamento.Id,
                    valor = pagamento.Valor,
                    data = pagamento.Data,
                    devedorDto = Dto,
                };
                listaDto.Add(pagamentoDto);
            }
            return listaDto;
        }

        public ReadPagamentoDto ReadPagamentoById(int id) 
        { 
            var pagamento = _context.Pagamentos.FirstOrDefault(p => p.Id == id);
            if (pagamento == null) { throw new Exception("Pagamento não encontrado"); }
            ReadDevedorDto Dto = new ReadDevedorDto
            {
                Id = pagamento.devedor.Id,
                Nome = pagamento.devedor.Nome

            };
            ReadPagamentoDto pagamentoDto = new ReadPagamentoDto
            {
                Id = pagamento.Id,
                valor = pagamento.Valor,
                data = pagamento.Data,
                devedorDto = Dto,
            };
            return pagamentoDto;
        }

        public void UpdatePagamento(int id, UpdatePagamentoDto dto) 
        { 
            var pagamento = _context.Pagamentos.FirstOrDefault(p => p.Id == id);
            if (pagamento == null) { throw new Exception("Pagamento não encontrado"); }
            pagamento.Valor = dto.Valor;
            pagamento.Data = dto.Data;
            pagamento.divida.Id = dto.dividaId;
            pagamento.devedor.Id = dto.devedorId;
        }

        public void DeletePagamento(int id) 
        { 
            var pagamento = _context.Pagamentos.FirstOrDefault(p =>p.Id == id);
            if (pagamento == null) { throw new Exception("Pagamento não encontrado"); }
            _context.Pagamentos.Remove(pagamento);
            _context.SaveChanges();
        }
    }
}
