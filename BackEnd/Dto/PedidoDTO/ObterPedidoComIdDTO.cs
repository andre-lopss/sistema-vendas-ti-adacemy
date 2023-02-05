using sistema_vendas_ti_adacemy.Models;

namespace sistema_vendas_ti_adacemy.Dto
{
    public class ObterPedidoComIdDTO
    {

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Vendedor Vendedor { get; set; }
        public Cliente Cliente { get; set; }

        public ObterPedidoComIdDTO(Pedido Pedido)
        {
            Id = Pedido.Id;
            Data = Pedido.Data;
            Vendedor = Pedido.Vendedor;
            Cliente = Pedido.Cliente;
        }
    }
}