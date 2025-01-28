namespace Climedio.Api.Models.Agendamento.Request;

public class AdicionarAgendamentoRequest
{
    public string Nome { get; set; }
    public int UsuarioIdProfissional { get; set; }
    public int UsuarioIdPaciente { get; set; }
    public decimal Valor { get; set; }
    public DateTime _data_hora { get; set; }
    public string Observacao { get; set; }
}