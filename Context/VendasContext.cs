using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sistema_vendas_ti_adacemy.Models;

namespace sistema_vendas_ti_adacemy.Context
{
    public class VendasContext : DbContext
    {
       public VendasContext(DbContextOptions<VendasContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; } 
    }
}