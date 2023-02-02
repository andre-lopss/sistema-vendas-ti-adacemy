using Microsoft.AspNetCore.Mvc;
using sistema_vendas_ti_adacemy.Repository;
using sistema_vendas_ti_adacemy.Dto;
using sistema_vendas_ti_adacemy.Models;

namespace sistema_vendas_ti_adacemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemPedidoController : ControllerBase
    {
        private readonly ItemPedidoRepository _repository;

        public ItemPedidoController(ItemPedidoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarItemPedidoDTO dto)
        {
            var itemPedido = new ItemPedido(dto);
            _repository.Cadastrar(itemPedido);
            return Ok(itemPedido);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var itemPedido = _repository.ObterPorId(id);
            if (itemPedido is not null)
            {
                return Ok(itemPedido);
            }
            else
            {
                return NotFound(new { Mensagem = "Item do pedido nâo encontrado" });
            }
        }

        [HttpGet("Listar")]
        public IActionResult ObterTodos()
        {
            var itensPedidos = _repository.ObterTodos();
            return Ok(itensPedidos);
        }

        [HttpGet("pedido/{id}")]
        public IActionResult ObterPorPedido(int id)
        {
            var ItensPedido = _repository.ObterPedido(id);
            if (ItensPedido is not null)
            {
                return Ok(ItensPedido);
            }
            return NotFound(new { mensagem = $"Não foi encontrado nenhum item de pedido do pedido de id {id}" });
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarItemPedidoDTO dto)
        {
            var itemPedido = _repository.ObterPorId(id);

            if (itemPedido is not null)
            {
                itemPedido.MapearAtualizarItemPedidoDTO(dto);
                _repository.AtualizarItemPedido(itemPedido);
                return Ok(itemPedido);
            }
            else
            {
                return NotFound(new { Mensagem = "Item do pedido nâo encontrado" });
            }
        }

        [HttpPatch("PatchIdPedido/{id}")]
        public IActionResult AtualizarIdPedidoItemPedido(int id, AtualizarIdPedidoItemPedidoDTO dto)
        {
            var itemPedido = _repository.ObterPorId(id);

            if (itemPedido is not null)
            {
                _repository.AtualizarIdPedido(itemPedido, dto);
                return Ok(itemPedido);
            }
            else
                return NotFound(new { Mensagem = "Item do pedido não encontrado" });
        }

        [HttpPatch("PatchIdServico/{id}")]
        public IActionResult AtualizarIdServicoItemPedido(int id, AtualizarIdServicoItemPedidoDTO dto)
        {
            var itemPedido = _repository.ObterPorId(id);

            if (itemPedido is not null)
            {
                _repository.AtualizarIdServico(itemPedido, dto);
                return Ok(itemPedido);
            }
            else
                return NotFound(new { Mensagem = "Item do pedido não encontrado" });
        }

        [HttpPatch("PatchQuantidade/{id}")]
        public IActionResult AtualizarQuantidadeItemPedido(int id, AtualizarQuantidadeItemPedidoDTO dto)
        {
            var itemPedido = _repository.ObterPorId(id);

            if (itemPedido is not null)
            {
                _repository.AtualizarQuantidade(itemPedido, dto);
                return Ok(itemPedido);
            }
            else
                return NotFound(new { Mensagem = "Item do pedido não encontrado" });
        }

        [HttpPatch("PatchValor/{id}")]
        public IActionResult AtualizarValorItemPedido(int id, AtualizarValorItemPedidoDTO dto)
        {
            var itemPedido = _repository.ObterPorId(id);

            if (itemPedido is not null)
            {
                _repository.AtualizarValor(itemPedido, dto);
                return Ok(itemPedido);
            }
            else
                return NotFound(new { Mensagem = "Item do pedido não encontrado" });
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var itemPedido = _repository.ObterPorId(id);

            if (itemPedido is not null)
            {
                _repository.DeletarItemPedido(itemPedido);
                return NoContent();
            }
            else
                return NotFound(new { Mensagem = "Item do pedido não encontrado" });
        }
    }
}
