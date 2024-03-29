using Microsoft.EntityFrameworkCore;
using sistema_vendas_ti_adacemy.Context;
using sistema_vendas_ti_adacemy.Dto;
using sistema_vendas_ti_adacemy.Models;

namespace sistema_vendas_ti_adacemy.Repository
{
    public class ItemPedidoRepository
    {
        private readonly VendasContext _context;

        public ItemPedidoRepository(VendasContext context)
        {
            _context = context;
        }

        public ItemPedido Cadastrar(ItemPedido itemPedido)
        {
            _context.ItensPedidos.Add(itemPedido);
            _context.SaveChanges();
            return itemPedido;
        }

        public List<ObterItemPedidoComIdDTO> Listar()
        {
            return _context.ItensPedidos.Include(x => x.Pedido)
                                        .Include(x => x.Servico)
                                        .Select(x => new ObterItemPedidoComIdDTO(x))
                                        .ToList();
        }

        public ItemPedido ListarPorId(int id)
        {
            var itemPedido = _context.ItensPedidos.Include(x => x.Pedido)
                                                  .Include(x => x.Pedido.Cliente)
                                                  .Include(x => x.Pedido.Vendedor)
                                                  .Include(x => x.Servico)                                         
                                                  .FirstOrDefault(x => x.Id == id);
            return itemPedido;
        }

        public List<ObterItemPedidoComIdDTO> ListarPorPedido(int id)
        {
            var itensPedido = _context.ItensPedidos.Include(x => x.Servico)
                                                   .Include(x => x.Pedido)
                                                   .Where(x => x.PedidoId == id)
                                                   .Select(x => new ObterItemPedidoComIdDTO(x))
                                                   .ToList();
            return itensPedido;
        }

        public ItemPedido AtualizarItemPedido(ItemPedido itemPedido)
        {
            _context.ItensPedidos.Update(itemPedido);
            _context.SaveChanges();
            return itemPedido;
        }

        public void AtualizarIdPedido(ItemPedido itemPedido, AtualizarIdPedidoItemPedidoDTO dto)
        {
            itemPedido.PedidoId = dto.PedidoId;
            AtualizarItemPedido(itemPedido);
        }

        public void AtualizarIdServico(ItemPedido itemPedido, AtualizarIdServicoItemPedidoDTO dto)
        {
            itemPedido.ServicoId = dto.ServicoId;
            AtualizarItemPedido(itemPedido);
        }

        public void AtualizarQuantidade(ItemPedido itemPedido, AtualizarQuantidadeItemPedidoDTO dto)
        {
            itemPedido.Quantidade = dto.Quantidade;
            AtualizarItemPedido(itemPedido);
        }

        public void AtualizarValor(ItemPedido itemPedido, AtualizarValorItemPedidoDTO dto)
        {
            itemPedido.Valor = dto.Valor;
            AtualizarItemPedido(itemPedido);
        }

        public void ExcluirItemPedido(ItemPedido itemPedido)
        {
            _context.ItensPedidos.Remove(itemPedido);
            _context.SaveChanges();
        }
    }
}