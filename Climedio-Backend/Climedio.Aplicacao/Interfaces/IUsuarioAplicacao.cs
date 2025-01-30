using System.Net.Mail;
using Climedio.Aplicacao;
using Climedio.Dominio.Entidades;

namespace Climedio.Aplicacao;

public interface IUsuarioAplicacao
{
    Task Criar(Usuario usuario);
    Task AtualizarSenha(int id, string senhaAntiga, string senhaNova);
    Task Remover(int id);
    Task<int> ValidarLogin(string email, string senha);
     Task<int> ValidarCPF(string cpf, string senha);
    Task<Usuario> ObterUsuario(int id);
    Task<List<Usuario>> ListarUsuarios();
}

