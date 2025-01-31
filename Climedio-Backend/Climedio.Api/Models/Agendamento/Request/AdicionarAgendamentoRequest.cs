namespace Climedio.Api.Models.Agendamento.Request;

public class AdicionarAgendamentoRequest
{
    public int UsuarioIdProfissional { get; set; }
    public int UsuarioIdPaciente { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataHora { get; set; }
    public string Observacao { get; set; }
}