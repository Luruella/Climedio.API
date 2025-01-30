using Climedio.Dominio.Enumeradores;

namespace Climedio.Api.Models.Usuarios.Response;

class ListarUsuariosResponse
{
    public int UsuarioId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string TipoUsuario { get; set; }
}
