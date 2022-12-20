using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistema_vendas_ti_adacemy.Models;

namespace sistema_vendas_ti_adacemy.Dto
{
    public class ObterPedidoDTO
    {
        public DateTime Data { get; set; }
        public int VendedorId { get; set; }
        public int ClienteId { get; set; }

        public ObterPedidoDTO(Pedido pedido)
        {
            Data = pedido.Data;
            VendedorId = pedido.VendedorId;
            ClienteId = pedido.ClienteId;
        }
    }
}