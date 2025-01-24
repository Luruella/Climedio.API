using Climedio.Dominio.Entidades;

namespace Climedio.Repositorio;
public interface IAgendamentoRepositorio
{
    Task Salvar(Agendamento agendamento);
    Task Atualizar(Agendamento agendamento);
    Task Remover(Agendamento agendamento);
    Task<Agendamento> ObterPorId(int id);
    Task<List<Agendamento>> Listar(int id);
    // Task<Agendamento> ObterPorNome(string nome);
}