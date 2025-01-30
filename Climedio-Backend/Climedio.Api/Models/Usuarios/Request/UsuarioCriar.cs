using Climedio.Dominio.Enumeradores;

namespace Climedio.Api.Models.Usuarios.Request;

public class UsuarioCriarRequest
{
    public TipoUsuario TipoUsuario {get;set;}
    public string Email { get; set; }
    public string Cpf { get; set; }
    public string Senha { get; set; }
    public string Nome { get; set; }
    public string NomeSocial { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public DateTime DataNascimento { get; set; }
}


 


   


   