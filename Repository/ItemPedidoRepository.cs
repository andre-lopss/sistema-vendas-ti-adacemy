using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sistema_vendas_ti_adacemy.Context;
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

        public ItemPedido ObterPorId(int id)
        {
            var itemPedido = _context.ItensPedidos.Include(x => x.Pedido)                               
                                                .Include(x => x.Servico)                                 
                                                .FirstOrDefault(x => x.Id == id);
            return itemPedido;
        }

        public ItemPedido AtualizarItemPedido(ItemPedido itemPedido)
        {
            _context.ItensPedidos.Update(itemPedido);
            _context.SaveChanges();
            return itemPedido;
        }
    }
}