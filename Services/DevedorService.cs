using ControleDeConta.Data;
using ControleDeConta.Data.Dtos;
using ControleDeConta.Modelos;

namespace ControleDeConta.Services
{
    public class DevedorService
    {
        private ControleDeContasContext _context;

        public DevedorService(ControleDeContasContext context)
        {
            _context = context;
        }

        public Devedor CadastraDevedor(CreateDevedorDto dto) 
        { 
            Devedor devedor = new Devedor(dto.Nome, dto.Cpf);
            _context.Devedores.Add(devedor);
            _context.SaveChanges();
            return devedor;
        }
        public IEnumerable<ReadDevedorDto> GetDevedores(int skip = 0, int take = 50) 
        { 
            var devedores = _context.Devedores.Skip(skip).Take(take).ToList();
            List<ReadDevedorDto> DevedoresDto = new List<ReadDevedorDto>();
            foreach (var devedor in devedores) 
            {   
                ReadDevedorDto DevedorDto = new ReadDevedorDto { Nome = devedor.Nome, Cpf = devedor.Cpf, Id = devedor.Id };
                DevedoresDto.Add(DevedorDto);
            }
            return DevedoresDto;
        }
        public ReadDevedorDto GetDevedorById(int Id) 
        {
            var devedor = _context.Devedores.FirstOrDefault(d => d.Id == Id);
            if (devedor == null)
            {
                throw new Exception("Devedor Não Encontrado");
            }
            ReadDevedorDto dto = new ReadDevedorDto { Id = devedor.Id, Nome = devedor.Nome, Cpf= devedor.Cpf };
            return dto;
        }
        public void UpdateDevedor(int Id, UpdateDevedorDto dto) 
        {
            var devedor = _context.Devedores.FirstOrDefault(d => d.Id == Id);
            if (devedor == null)
            {
                throw new Exception("Devedor Não Encontrado");
            }
            devedor.Nome = dto.Nome;
            devedor.Cpf = dto.Cpf;
            _context.SaveChanges();
        }
        public void DeleteDevedor(int Id) 
        { 
            var devedor = _context.Devedores.FirstOrDefault(d => d.Id == Id);
            if(devedor == null)
            {
                throw new Exception("Devedor não encontrado");
            }
            _context.Devedores.Remove(devedor);
            _context.SaveChanges();
        }
    }
}
