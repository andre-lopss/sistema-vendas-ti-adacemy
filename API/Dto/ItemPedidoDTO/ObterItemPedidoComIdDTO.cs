using sistema_vendas_ti_adacemy.Models;

namespace sistema_vendas_ti_adacemy.Dto
{
    public class ObterItemPedidoComIdDTO
    {

        public int Id { get; set; }
        public Pedido Pedido { get; set; }
        public Servico Servico { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }

        public ObterItemPedidoComIdDTO(ItemPedido itemPedido)
        {
            Id = itemPedido.Id;
            Pedido = itemPedido.Pedido;
            Servico = itemPedido.Servico;
            Quantidade = itemPedido.Quantidade;
            Valor = itemPedido.Valor;
        }
    }
}