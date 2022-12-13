using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_vendas_ti_adacemy.Context;
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
    }
}