using Microsoft.AspNetCore.Mvc;
using sistema_vendas_ti_adacemy.Repository;
using sistema_vendas_ti_adacemy.Dto;
using sistema_vendas_ti_adacemy.Models;

namespace sistema_vendas_ti_adacemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoRepository _repository;

        public PedidoController(PedidoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarPedidoDTO dto)
        {
            var pedido = new Pedido(dto);
            _repository.Cadastrar(pedido);
            return Ok(pedido);
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var pedidos = _repository.Listar();
            return Ok(pedidos);
        }

        [HttpGet("vendedor/{id}")]
        public IActionResult ListarPedidosVendedor(int id)
        {
            var pedidos = _repository.ListarPedidosVendedor(id);
            if (pedidos is not null)
            {
                return Ok(pedidos);
            }
            return NotFound(new { mensagem = $"Não foi encontrado nenhum pedido do Vendedor {id}" });
        }

        [HttpGet("cliente/{id}")]
        public IActionResult ListarPedidosCliente(int id)
        {
            var pedidos = _repository.ListarPedidosCliente(id);
            if (pedidos is not null)
            {
                return Ok(pedidos);
            }
            return NotFound(new { mensagem = $"Não foi encontrado nenhum pedido do Cliente {id}" });
        }

        [HttpGet("ObterId/{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            var pedido = _repository.ConsultarPorId(id);

            if (pedido is not null)
            {
                return Ok(pedido);
            }
            else
                return NotFound(new { Mensagem = "Pedido não encontrado" });
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(int id, AtualizarPedidoDTO dto)
        {
            var pedido = _repository.ConsultarPorId(id);

            if (pedido is not null)
            {
                pedido.MapearAtualizarPedidoDTO(dto);
                _repository.AtualizarPedido(pedido);
                return Ok(pedido);
            }
            else
                return NotFound(new { Mensagem = "Pedido não encontrado" });
        }

        [HttpPatch("PatchIdVendedor/{id}")]
        public IActionResult AtualizarIdVendedor(int id, AtualizarIdVendedorPedidoDTO dto)
        {
            var pedido = _repository.ConsultarPorId(id);

            if (pedido is not null)
            {
                _repository.AtualizarIdVendedor(pedido, dto);
                return Ok(pedido);
            }
            else
                return NotFound(new { Mensagem = "Pedido não encontrado" });
        }

        [HttpPatch("PatchIdCliente/{id}")]
        public IActionResult AtualizarIdCliente(int id, AtualizarIdClientePedidoDTO dto)
        {
            var pedido = _repository.ConsultarPorId(id);

            if (pedido is not null)
            {
                _repository.AtualizarIdCliente(pedido, dto);
                return Ok(pedido);
            }
            else
                return NotFound(new { Mensagem = "Pedido não encontrado" });
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var pedido = _repository.ConsultarPorId(id);

            if (pedido is not null)
            {
                _repository.ExcluirPedido(pedido);
                return NoContent();
            }
            else
                return NotFound(new { Mensagem = "Pedido não encontrado" });
        }
    }
}