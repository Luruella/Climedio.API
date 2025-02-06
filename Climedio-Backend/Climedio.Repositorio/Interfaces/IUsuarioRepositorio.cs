using Climedio.Dominio.Entidades;

namespace Climedio.Repositorio;

public interface IUsuarioRepositorio
{
    
     Task Salvar(Usuario usuario);
    Task Atualizar(Usuario usuario);
    Task Remover(Usuario usuario);
    Task<Usuario> ObterPorId(int id);
    Task<Usuario> ObterPorEmail(string email);
    Task<IEnumerable<Usuario>> Listar(bool ativo);
    Task<List<Usuario>> ListarUsuarios();
    Task<IEnumerable<Usuario>> ListarPacientes(bool ativo);
    Task<IEnumerable<Usuario>> ListarProfissionais(bool ativo);
    Task AtualizarInformacoes(Usuario usuario);
}