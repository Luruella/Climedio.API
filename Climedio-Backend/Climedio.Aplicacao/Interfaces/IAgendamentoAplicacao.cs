using Climedio.Dominio.Entidades;

namespace Climedio.Aplicacao;

public interface IAgendamentoAplicacao
{
    Task Criar(Agendamento agendamento);
    Task Atualizar(DateTime data_hora, string observacao, decimal valor, int usuarioIdProfissional, int usuarioIdPaciente);
    Task Remover(int id);
    Task<List<Agendamento>> Listar(int id, bool ativo);
}