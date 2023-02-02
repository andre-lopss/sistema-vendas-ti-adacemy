using sistema_vendas_ti_adacemy.Context;
using sistema_vendas_ti_adacemy.Dto;
using sistema_vendas_ti_adacemy.Models;

namespace sistema_vendas_ti_adacemy.Repository
{
    public class ClienteRepository
    {
        private readonly VendasContext _context;

        public ClienteRepository(VendasContext context)
        {
            _context = context;
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public Cliente ObterPorId(int id)
        {
            var cliente = _context.Clientes.Find(id);
            return cliente;
        }

        public List<ObterClienteDTO> ObterPorNome(string nome)
        {
            var clientes = _context.Clientes.Where(x => x.Nome.Contains(nome))
                                                    .Select(x => new ObterClienteDTO(x))
                                                    .ToList();
            return clientes;
        }

        public List<Cliente> Listar()
        {
            return _context.Clientes.ToList();
        }

        public Cliente AtualizarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public void AtualizarSenha(Cliente cliente, AtualizarSenhaClienteDTO dto)
        {
            cliente.Senha = dto.Senha;
            AtualizarCliente(cliente);
        }

        public void DeletarCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }
    }
}