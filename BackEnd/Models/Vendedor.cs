using sistema_vendas_ti_adacemy.Dto;

namespace sistema_vendas_ti_adacemy.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Vendedor()
        {
        }

        public Vendedor(LoginVendedorDTO dto)
        {
            Login = dto.Login;
            Senha = dto.Senha;
        }
        public Vendedor(CadastrarVendedorDTO dto)
        {
            Nome = dto.Nome;
            Login = dto.Login;
            Senha = dto.Senha;
        }

        public void MapearAtualizarVendedorDTO(AtualizarVendedorDTO dto)
        {
            Nome = dto.Nome;
            Login = dto.Login;
            Senha = dto.Senha;
        }
    }
}