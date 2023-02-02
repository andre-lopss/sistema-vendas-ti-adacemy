using Microsoft.AspNetCore.Mvc;
using sistema_vendas_ti_adacemy.Repository;
using sistema_vendas_ti_adacemy.Dto;
using sistema_vendas_ti_adacemy.Models;

namespace sistema_vendas_ti_adacemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly VendedorRepository _repository;

        public VendedorController(VendedorRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginVendedorDTO dto)
        {
            var vendedor = _repository.Login(new Vendedor(dto));

            if(vendedor is not null)
                return Ok(true);
            else
            return NotFound(new { Mensagem = "Login ou senha incorreto(s)" });
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarVendedorDTO dto)
        {
            var vendedor = new Vendedor(dto);
            _repository.Cadastrar(vendedor);
            return Ok(vendedor);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            var vendedor = _repository.ConsultarPorId(id);

            if (vendedor is not null)
            {
                var vendedorDTO = new ObterVendedorDTO(vendedor);
                return Ok(vendedorDTO);
            }
            else
                return NotFound(new { Mensagem = "Vendedor não encontrado" });
        }

        [HttpGet("ConsultarPorNome/{nome}")]
        public IActionResult ConsultarPorNome(string nome)
        {
            var vendedores = _repository.ConsultarPorNome(nome);
            return Ok(vendedores);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarVendedorDTO dto)
        {
            var vendedor = _repository.ConsultarPorId(id);

            if (vendedor is not null)
            {
                vendedor.MapearAtualizarVendedorDTO(dto);
                _repository.AtualizarVendedor(vendedor);
                return Ok(vendedor);
            }
            else
                return NotFound(new { Mensagem = "Vendedor não encontrado" });
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizarSenha(int id, AtualizarSenhaVendedorDTO dto)
        {
            var vendedor = _repository.ConsultarPorId(id);

            if (vendedor is not null)
            {
                _repository.AtualizarSenha(vendedor, dto);
                return Ok(vendedor);
            }
            else
                return NotFound(new { Mensagem = "Vendedor não encontrado" });
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var vendedor = _repository.ConsultarPorId(id);

            if (vendedor is not null)
            {
                _repository.ExcluirVendedor(vendedor);
                return NoContent();
            }
            else
                return NotFound(new { Mensagem = "Vendedor não encontrado" });
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var vendedores = _repository.Listar();
            return Ok(vendedores);
        }
    }
}