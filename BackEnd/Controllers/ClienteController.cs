using Microsoft.AspNetCore.Mvc;
using sistema_vendas_ti_adacemy.Repository;
using sistema_vendas_ti_adacemy.Dto;
using sistema_vendas_ti_adacemy.Models;

namespace sistema_vendas_ti_adacemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _repository;

        public ClienteController(ClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginClienteDTO dto)
        {
            var cliente = _repository.Login(new Cliente(dto));

            if(cliente is not null)
                return Ok(true);
            else
            return NotFound(new { Mensagem = "Login ou senha incorreto(s)" });
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var clientes = _repository.Listar();
            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarClienteDTO dto)
        {
            var cliente = new Cliente(dto);
            _repository.Cadastrar(cliente);
            return Ok(cliente);
        }
        
        [HttpGet("ObterId/{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            var cliente = _repository.ConsultarPorId(id);

            if (cliente is not null)
            {
                var clienteDTO = new ObterClienteDTO(cliente);
                return Ok(clienteDTO);
            }
            else
                return NotFound(new { Mensagem = "Cliente não encontrado" });
        }
        
        [HttpGet("ConsultarPorNome/{nome}")]
        public IActionResult ConsultarPorNome(string nome)
        {
            var cliente = _repository.ConsultarPorNome(nome);
            return Ok(cliente);
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(int id, AtualizarClienteDTO dto)
        {
            var cliente = _repository.ConsultarPorId(id);

            if (cliente is not null)
            {
                cliente.MapearAtualizarClienteDTO(dto);
                _repository.AtualizarCliente(cliente);
                return Ok(cliente);
            }
            else
                return NotFound(new { Mensagem = "Cliente não encontrado" });
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizarSenha(int id, AtualizarSenhaClienteDTO dto)
        {
            var cliente = _repository.ConsultarPorId(id);

            if (cliente is not null)
            {
                _repository.AtualizarSenha(cliente, dto);
                return Ok(cliente);
            }
            else
                return NotFound(new { Mensagem = "Vendedor não encontrado" });
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var cliente = _repository.ConsultarPorId(id);

            if (cliente is not null)
            {
                _repository.ExcluirCliente(cliente);
                return NoContent();
            }
            else
                return NotFound(new { Mensagem = "Cliente não encontrado" });
        }
    }
}