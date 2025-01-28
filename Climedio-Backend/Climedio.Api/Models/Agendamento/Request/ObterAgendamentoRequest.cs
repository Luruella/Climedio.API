namespace Climedio.Api.Models.Agendamento.Request;

public class ObterAgendamentoRequest
{
    public int UsuarioId { get; set; }
    public bool Ativo { get; set; }
}