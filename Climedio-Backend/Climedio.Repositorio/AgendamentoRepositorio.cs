
using Climedio.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Climedio.Repositorio
{
    public class AgendamentoRepositorio : BaseRepositorio, IAgendamentoRepositorio
    {
        public AgendamentoRepositorio(ClimedioContexto _contexto) : base(_contexto)
        {
        }

        public async Task Atualizar(Agendamento agendamento)
        {
            _contexto.Agendamentos.Update(agendamento);
            await _contexto.SaveChangesAsync();
        }

        public async Task<List<Agendamento>> Listar(int id)
        {
            return await _contexto.Agendamentos.Where(x => x.Id == id).ToListAsync();
        }

        public async Task<Agendamento> ObterPorId(int id)
        {
            return await _contexto.Agendamentos.FirstOrDefaultAsync(x => x.Id == id);
        }

        // public async Task<Agendamento> ObterPorNome(string nome)
        // {
        //     return await _contexto.Agendamentos.FirstOrDefaultAsync(x => x.Nome == nome);
        // }

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