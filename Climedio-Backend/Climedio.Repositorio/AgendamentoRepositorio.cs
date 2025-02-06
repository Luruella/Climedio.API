// É o que conversa com o Banco de dados para fazer o crud

using Climedio.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Climedio.Repositorio
{
    public class AgendamentoRepositorio : BaseRepositorio, IAgendamentoRepositorio

    {


        public AgendamentoRepositorio(ClimedioContexto _contexto) : base(_contexto)
        {
        }

        public async Task<IEnumerable<Agendamento>> ListarTodosAgendamentos(bool ativo)
        {
            return await _contexto.Agendamentos.Where(a => a.Ativo == ativo)
                .Include(u => u.UsuarioPaciente )  
                .Include(u => u.UsuarioProfissional)  
                .ToListAsync();
        }

        public async Task Atualizar(Agendamento agendamento)
        {
            _contexto.Agendamentos.Update(agendamento);
            await _contexto.SaveChangesAsync();
        }

        // public async Task<List<Agendamento>> ListarPorIdProfissional(int IdProfissional)
        // {
        //     return await _contexto.Agendamentos.Where(x => x.UsuarioIdProfissional == IdProfissional).ToListAsync();
        // }

        // public async Task<List<Agendamento>> ListarPorIdPaciente(int IdPaciente)
        // {
        //     return await _contexto.Agendamentos.Where(x => x.UsuarioIdPaciente == IdPaciente).ToListAsync();
        // }
        public async Task<Agendamento> ObterPorId(int id)
        {
            return await _contexto.Agendamentos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Remover(Agendamento agendamento)
        {
            _contexto.Agendamentos.Remove(agendamento);
            await _contexto.SaveChangesAsync();
        }

        public async Task Salvar(Agendamento agendamento)
        {
            _contexto.Agendamentos.Add(agendamento);
            await _contexto.SaveChangesAsync();

        }

    }
}