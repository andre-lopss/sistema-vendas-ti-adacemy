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
    public class ServicoController : ControllerBase
    {
        private readonly ServicoRepository _repository;

        public ServicoController(ServicoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarServicoDTO dto)
        {
            var servico = new Servico(dto);
            _repository.Cadastrar(servico);
            return Ok(servico);
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var servicos = _repository.Listar();
            return Ok(servicos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var servico = _repository.ObterPorId(id);

            if (servico is not null)
                return Ok(servico);
            else
                return NotFound(new { Mensagem = "Servico não encontrado" });
        }

        [HttpGet("ObterPorNome/{nome}")]
        public IActionResult ObterPorNome(string nome)
        {
            var servicos = _repository.ObterPorNome(nome);
            return Ok(servicos);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarServicoDTO dto)
        {
            var servicos = _repository.ObterPorId(id);

            if (servicos is not null)
            {
                servicos.MapearAtualizarServicoDTO(dto);
                _repository.AtualizarServico(servicos);
                return Ok(servicos);
            }
            else
                return NotFound(new { Mensagem = "Servico não encontrado" });
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var servico = _repository.ObterPorId(id);

            if (servico is not null)
            {
                _repository.DeletarServico(servico);
                return NoContent();
            }
            else
                return NotFound(new { Mensagem = "Servico não encontrado" });
        }
    }
}