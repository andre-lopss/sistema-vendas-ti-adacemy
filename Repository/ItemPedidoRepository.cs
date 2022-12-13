using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void Cadastrar(ItemPedido itemPedido)
        {
            _context.ItensPedidos.Add(itemPedido);
            _context.SaveChanges();
        }
    }
}