using sistema_vendas_ti_adacemy.Models;

namespace sistema_vendas_ti_adacemy.Dto
{
    public class LoginVendedorDTO
    {
        public LoginVendedorDTO(Vendedor vendedor)
        {
            Login = vendedor.Login;
            Senha = vendedor.Senha;
        }

        public string Login { get; set; }
        public string Senha { get; set; }
        
    }

}