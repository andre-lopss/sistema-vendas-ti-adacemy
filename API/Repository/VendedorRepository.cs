using sistema_vendas_ti_adacemy.Context;
using sistema_vendas_ti_adacemy.Dto;
using sistema_vendas_ti_adacemy.Models;

namespace sistema_vendas_ti_adacemy.Repository
{
    public class VendedorRepository
    {
        private readonly VendasContext _context;

        public VendedorRepository(VendasContext context)
        {
            _context = context;
        }

        public void Cadastrar(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
        }

        public Vendedor ObterPorId(int id)
        {
            var vendedor = _context.Vendedores.Find(id);
            return vendedor;
        }

        public List<ObterVendedorDTO> ObterPorNome(string nome)
        {
            var vendedores = _context.Vendedores.Where(x => x.Nome.Contains(nome))
                                                .Select(x => new ObterVendedorDTO(x))
                                                .ToList();
            return vendedores;
        }

        public List<Vendedor> Listar()
        {
            return _context.Vendedores.ToList();
        }

        public Vendedor AtualizarVendedor(Vendedor vendedor)
        {
            _context.Vendedores.Update(vendedor);
            _context.SaveChanges();
            return vendedor;
        }

        public void AtualizarSenha(Vendedor vendedor, AtualizarSenhaVendedorDTO dto)
        {
            vendedor.Senha = dto.Senha;
            AtualizarVendedor(vendedor);
        }

        public void DeletarVendedor(Vendedor vendedor)
        {
            _context.Vendedores.Remove(vendedor);
            _context.SaveChanges();
        }
    }
}