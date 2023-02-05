using Microsoft.EntityFrameworkCore;
using sistema_vendas_ti_adacemy.Context;
using sistema_vendas_ti_adacemy.Dto;
using sistema_vendas_ti_adacemy.Models;

namespace sistema_vendas_ti_adacemy.Repository
{
    public class PedidoRepository
    {
        private readonly VendasContext _context;

        public PedidoRepository(VendasContext context)
        {
            _context = context;
        }

        public Pedido Cadastrar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return pedido;
        }

        public List<Pedido> Listar()
        {
            return _context.Pedidos.Include(x => x.Vendedor)
                                   .Include(x => x.Cliente)
                                   .ToList();
        }

        public List<ObterPedidoComIdDTO> ListarPedidosVendedor(int id)
        {
            var pedidos = _context.Pedidos.Include(x => x.Vendedor)
                                                .Include(x => x.Cliente)
                                                .Where(x => x.VendedorId == id)
                                                .Select(x => new ObterPedidoComIdDTO(x))
                                                .ToList();
            return pedidos;
        }

        public List<ObterPedidoComIdDTO> ListarPedidosCliente(int id)
        {
            var pedidos = _context.Pedidos.Include(x => x.Vendedor)
                                                .Include(x => x.Cliente)
                                                .Where(x => x.ClienteId == id)
                                                .Select(x => new ObterPedidoComIdDTO(x))
                                                .ToList();
            return pedidos;
        }

        public Pedido ConsultarPorId(int id)
        {
            var pedido = _context.Pedidos.Include(x => x.Vendedor)
                                         .Include(x => x.Cliente)
                                         .FirstOrDefault(x => x.Id == id);
            return pedido;
        }

        public Pedido AtualizarPedido(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
            return pedido;
        }

        public void AtualizarIdVendedor(Pedido pedido, AtualizarIdVendedorPedidoDTO dto)
        {
            pedido.VendedorId = dto.VendedorId;
            AtualizarPedido(pedido);
        }

        public void AtualizarIdCliente(Pedido pedido, AtualizarIdClientePedidoDTO dto)
        {
            pedido.ClienteId = dto.ClienteId;
            AtualizarPedido(pedido);
        }

        public void ExcluirPedido(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
        }
    }
}