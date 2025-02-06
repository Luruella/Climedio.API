using Climedio.Dominio.Entidades;

namespace Climedio.Repositorio;
public interface IAgendamentoRepositorio
{
    Task<IEnumerable<Agendamento>> ListarTodosAgendamentos(bool ativo);
    Task Salvar(Agendamento agendamento);
    Task Atualizar(Agendamento agendamento);
    Task Remover(Agendamento agendamento);
    Task<Agendamento> ObterPorId(int id);
}