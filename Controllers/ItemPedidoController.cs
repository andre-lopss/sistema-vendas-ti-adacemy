using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var itemPedido= new ItemPedido(dto);
            _repository.Cadastrar(itemPedido);
            return Ok(itemPedido);
        }

        [HttpGet("id")]
        public IActionResult ObterPorId(int id)
        {
            var itemPedido = _repository.ObterPorId(id);
            if(itemPedido is not null){
                return Ok(itemPedido);
            }
            else
            {
                return NotFound(new{ Mensagem = "Item do pedido nâo encontrado"});
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarItemPedidoDTO dto)
        {
            var itemPedido = _repository.ObterPorId(id);

            if(itemPedido is not null)
            {
                itemPedido.MapearAtualizarItemPedidoDTO(dto);
                _repository.AtualizarItemPedido(itemPedido);
                return Ok(itemPedido);
            }else
            {
                return NotFound(new{ Mensagem = "Item do pedido nâo encontrado"});
            }

        }
    }
}