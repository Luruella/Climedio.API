using Climedio.Dominio.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Climedio.Repositorio;

public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
{

    public UsuarioRepositorio(ClimedioContexto contexto) : base(contexto)
    {
    }

    public async Task Atualizar(Usuario usuario)
    {
        _contexto.Usuarios.Update(usuario);
        await _contexto.SaveChangesAsync();
    }

    public async Task AtualizarInformacoes(Usuario usuario)
    {
        _contexto.Usuarios.Update(usuario);
        await _contexto.SaveChangesAsync();
    }


    public async Task<Usuario> ObterPorEmail(string email)
    {
        return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<Usuario> ObterPorId(int id)
    {
        return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task Remover(Usuario usuario)
    {
        _contexto.Usuarios.Remove(usuario);
        await _contexto.SaveChangesAsync();
    }

    public async Task Salvar(Usuario usuario)
    {
        _contexto.Usuarios.Add(usuario);
        await _contexto.SaveChangesAsync();
    }

    public async Task<IEnumerable<Usuario>> Listar(bool ativo)
    {
        return await _contexto.Usuarios.Where(u => u.Ativo == ativo).ToListAsync();
    }
    public async Task<IEnumerable<Usuario>> ListarPacientes(bool ativo)
    {
        return await _contexto.Usuarios.Where(u => u.Ativo == ativo && u.TipoUsuarioId == Dominio.Enumeradores.TipoUsuario.Paciente).ToListAsync();
    }
    public async Task<IEnumerable<Usuario>> ListarProfissionais(bool ativo)
    {
        return await _contexto.Usuarios.Where(u => u.Ativo == ativo && u.TipoUsuarioId == Dominio.Enumeradores.TipoUsuario.Medico || u.TipoUsuarioId == Dominio.Enumeradores.TipoUsuario.Dentista || u.TipoUsuarioId == Dominio.Enumeradores.TipoUsuario.Enfermeiro || u.TipoUsuarioId == Dominio.Enumeradores.TipoUsuario.Esteticista).ToListAsync();
    }


    public async Task<List<Usuario>> ListarUsuarios()
    {
        //return await _contexto.Usuarios.Where(u => u.Ativo == true).ToListAsync();

        return await _contexto.Usuarios
        .FromSqlRaw("EXEC ListarUsuarios")
        .ToListAsync();
    }
}