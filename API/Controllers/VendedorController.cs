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
        public IActionResult ObterPorId(int id)
        {
            var vendedor = _repository.ObterPorId(id);

            if (vendedor is not null)
            {
                var vendedorDTO = new ObterVendedorDTO(vendedor);
                return Ok(vendedorDTO);
            }
            else
                return NotFound(new { Mensagem = "Vendedor não encontrado" });
        }

        [HttpGet("ObterPorNome/{nome}")]
        public IActionResult ObterPorNome(string nome)
        {
            var vendedores = _repository.ObterPorNome(nome);
            return Ok(vendedores);
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var vendedores = _repository.Listar();
            return Ok(vendedores);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarVendedorDTO dto)
        {
            var vendedor = _repository.ObterPorId(id);

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
            var vendedor = _repository.ObterPorId(id);

            if (vendedor is not null)
            {
                _repository.AtualizarSenha(vendedor, dto);
                return Ok(vendedor);
            }
            else
                return NotFound(new { Mensagem = "Vendedor não encontrado" });
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var vendedor = _repository.ObterPorId(id);

            if (vendedor is not null)
            {
                _repository.DeletarVendedor(vendedor);
                return NoContent();
            }
            else
                return NotFound(new { Mensagem = "Vendedor não encontrado" });
        }
    }
}