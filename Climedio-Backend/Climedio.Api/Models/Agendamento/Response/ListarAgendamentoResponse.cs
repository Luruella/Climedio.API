namespace Climedio.Api.Models.Agendamento.Response;

public class ListarAgendamentoResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int UsuarioIdProfissional { get; set; }
    public int UsuarioIdPaciente { get; set; }
    public decimal Valor { get; set; }
     public DateTime Data_hora { get; set; }
    public string Observacao { get; set; }
}


   
