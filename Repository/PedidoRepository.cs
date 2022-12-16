using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sistema_vendas_ti_adacemy.Context;
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

        public Pedido ObterPorId(int id)
        {
            var pedido = _context.Pedidos.Include(x => x.Vendedor)
                    .Include(x => x.Cliente)
                    .FirstOrDefault(x => x.Id == id);
            return pedido;
        }

        // public List<ObterVendedorDTO> ObterPorNome(string nome)
        // {
        //     var vendedores = _context.Vendedores.Where(x => x.Nome.Contains(nome))
        //                                             .Select(x => new ObterVendedorDTO(x))
        //                                             .ToList();
        //     return vendedores;
        // }

        public Pedido AtualizarPedido(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
            return pedido;
        }

        public void DeletarPedido(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
        }

        // public void AtualizarSenha(Vendedor vendedor, AtualizarSenhaVendedorDTO dto)
        // {
        //     vendedor.Senha = dto.Senha;
        //     AtualizarVendedor(vendedor);
        // }
    }
}