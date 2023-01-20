namespace sistema_vendas_ti_adacemy.Models
{
    public class AtualizarPedidoDTO
    {
        public DateTime Data { get; set; }
        public int VendedorId { get; set; }
        public int ClienteId { get; set; }
    }
}