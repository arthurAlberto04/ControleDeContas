using ControleDeConta.Data;
using ControleDeConta.Data.Dtos;
using ControleDeConta.Modelos;

namespace ControleDeConta.Services
{
    public class DividaService
    {
        private ControleDeContasContext _context;

        public DividaService(ControleDeContasContext context)
        {
            _context = context;
        }

        public Divida CreateDivida(CreateDividaDto dto) 
        { 
            Divida divida = new Divida(dto.Valor, dto.descricao, dto.dataDeInicio, dto.tipo);
            divida.devedor.Id = dto.devedorId;
            _context.Add(divida);
            _context.SaveChanges();
            return divida;
        }

        public IEnumerable<ReadDividaDto> GetDivida(int skip =0, int take = 50) 
        { 
            var dividas = _context.Dividas.Skip(skip).Take(take).ToList();
            List<ReadDividaDto> listDtos = new List<ReadDividaDto>();
            foreach (var divida in dividas) 
            { 
                ReadDividaDto dto = new ReadDividaDto { Id = divida.Id, 
                    dataDeInicio = divida.dataDeInicio,
                    tipo = divida.tipo,
                    valor = divida.valor,
                    descricao = divida.descricao,
                    devedor = divida.devedor,
                    pagamentos = divida.pagamentos
                };
                listDtos.Add(dto);
            }
            return listDtos;
        }

        public ReadDividaDto GetDividaById(int id) 
        { 
            var divida = _context.Dividas.FirstOrDefault(d => d.Id == id);
            if(divida == null) { throw new Exception("Divida não encontrada"); }
            ReadDividaDto dto = new ReadDividaDto
            {
                Id = divida.Id,
                dataDeInicio = divida.dataDeInicio,
                tipo = divida.tipo,
                valor = divida.valor,
                descricao = divida.descricao,
                devedor = divida.devedor,
                pagamentos = divida.pagamentos
            };
            return dto;
        }
        public void UpdateDivida(int id, UpdateDividaDto dto) 
        { 
            var divida = _context.Dividas.FirstOrDefault(d => d.Id == id);
            if (divida == null) { throw new Exception("Divida não encontrada"); }
            divida.valor = dto.valor;
            divida.descricao = dto.descricao;
            divida.tipo = dto.tipo;
            divida.dataDeInicio = dto.dataDeInicio;
            _context.SaveChanges();
        }
        public void DeleteDivida(int id) 
        {
            var divida = _context.Dividas.FirstOrDefault(d => d.Id == id);
            if(divida == null) { throw new Exception("Divida não encontrada"); }
            _context.Dividas.Remove(divida);
            _context.SaveChanges();
        }
    }
}
