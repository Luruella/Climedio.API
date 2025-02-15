using Climedio.Dominio.Entidades;
using Climedio.Repositorio;

namespace Climedio.Aplicacao;

public class UsuarioAplicacao : IUsuarioAplicacao
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public UsuarioAplicacao(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    public async Task AtualizarSenha(int id, string senhaAntiga, string senhaNova)
    {
        var usuarioAtualizar = await _usuarioRepositorio.ObterPorId(id);

        if (string.IsNullOrEmpty(senhaNova))
        {
            throw new Exception("Senha do usuário não pode ser vazia.");
        }

        if (usuarioAtualizar.Senha == senhaAntiga)
        {
            throw new Exception("Senha antiga inválida.");
        }

        usuarioAtualizar.Senha = senhaNova;

        await _usuarioRepositorio.Atualizar(usuarioAtualizar);
    }


    public async Task Criar(Usuario usuario)
    {
        if (usuario == null)
        {
            throw new Exception("Usuario não pode ser vazio.");
        }

        if (string.IsNullOrEmpty(usuario.Nome))
        {
            throw new Exception("Nome do usuário não pode ser vazio.");
        }

        if (string.IsNullOrEmpty(usuario.Senha))
        {
            throw new Exception("Senha do usuário não pode ser vazia.");
        }

        if (await _usuarioRepositorio.ObterPorEmail(usuario.Email) != null)
        {
            throw new Exception("Usuário já existe.");
        }

        await _usuarioRepositorio.Salvar(usuario);
    }

    public async Task AtualizarInformacoes(Usuario usuarioAtualizar){
        var usuario = await _usuarioRepositorio.ObterPorId(usuarioAtualizar.Id);

        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        usuario.Nome = usuarioAtualizar.Nome;
        usuario.Email = usuarioAtualizar.Email;
        usuario.Telefone = usuarioAtualizar.Telefone;
        usuario.Endereco = usuarioAtualizar.Endereco;
        usuario.TipoUsuarioId = usuarioAtualizar.TipoUsuarioId;
        usuario.Cpf = usuarioAtualizar.Cpf;
        usuario.NomeSocial = usuarioAtualizar.NomeSocial;

        await _usuarioRepositorio.Atualizar(usuario);
    }

    public async Task<List<Usuario>> ListarUsuarios()
    {
        return await _usuarioRepositorio.ListarUsuarios();
    }
    


    public async Task<IEnumerable<Usuario>> ListarPacientes(bool ativo)
    {
        return await _usuarioRepositorio.ListarPacientes(ativo);
    }


    public async Task<IEnumerable<Usuario>> ListarProfissionais(bool ativo)
    {
        return await _usuarioRepositorio.ListarProfissionais(ativo);
    }


    public async Task<Usuario> ObterUsuario(int id)
    {
        return await _usuarioRepositorio.ObterPorId(id);
    }


    public async Task Remover(int id)
    {
        var usuario = await _usuarioRepositorio.ObterPorId(id);

        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        usuario.Ativo = false;

        await _usuarioRepositorio.Atualizar(usuario);
    }


    public Task<int> ValidarCPF(string cpf, string senha)
    {
        throw new NotImplementedException();
    }


    public async Task<int> ValidarLogin(string email, string senha)
    {
        var usuario = await _usuarioRepositorio.ObterPorEmail(email);

        if (usuario == null)
        {
            throw new Exception("Usuario não encontrado");
        }

        if (usuario.Senha != senha)
        {
            throw new Exception("Senha incorreta");
        }

        return usuario.Id;


    }
}