using sistema_vendas_ti_adacemy.Dto;

namespace sistema_vendas_ti_adacemy.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Cliente()
        {
        }

        public Cliente(LoginClienteDTO dto)
        {
            Login = dto.Login;
            Senha = dto.Senha;
        }

        public Cliente(CadastrarClienteDTO dto)
        {
            Nome = dto.Nome;
            Login = dto.Login;
            Senha = dto.Senha;
        }

        public void MapearAtualizarClienteDTO(AtualizarClienteDTO dto)
        {
            Nome = dto.Nome;
            Login = dto.Login;
            Senha = dto.Senha;
        }
    }
}