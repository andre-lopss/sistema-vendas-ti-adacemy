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
        public IActionResult ConsultarPorId(int id)
        {
            var servico = _repository.ConsultarPorId(id);

            if (servico is not null)
                return Ok(servico);
            else
                return NotFound(new { Mensagem = "Servico não encontrado" });
        }

        [HttpGet("ConsultarPorNome/{nome}")]
        public IActionResult ConsultarPorNome(string nome)
        {
            var servicos = _repository.ConsultarPorNome(nome);
            return Ok(servicos);
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarServicoDTO dto)
        {
            var servicos = _repository.ConsultarPorId(id);

            if (servicos is not null)
            {
                servicos.MapearAtualizarServicoDTO(dto);
                _repository.AtualizarServico(servicos);
                return Ok(servicos);
            }
            else
                return NotFound(new { Mensagem = "Servico não encontrado" });
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizarNome(int id, AtualizarNomeServicoDTO dto)
        {
            var servico = _repository.ConsultarPorId(id);

            if (servico is not null)
            {
                _repository.AtualizarNome(servico, dto);
                return Ok(servico);
            }
            else
                return NotFound(new { Mensagem = "Serviço não encontrado" });
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var servico = _repository.ConsultarPorId(id);

            if (servico is not null)
            {
                _repository.ExcluirServico(servico);
                return NoContent();
            }
            else
                return NotFound(new { Mensagem = "Servico não encontrado" });
        }
    }
}