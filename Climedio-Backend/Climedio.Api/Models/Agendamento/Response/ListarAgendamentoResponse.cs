using Climedio.Dominio.Entidades;
using Climedio.Dominio.Enumeradores;

namespace Climedio.Api.Models.Agendamento.Response;

public class ListarAgendamentoResponse
{
    public int Id { get; set; }
    public string UsuarioProfissionalNome { get; set; }
    public string UsuarioProfissionalTipo { get; set; }
    public string UsuarioPacienteNome { get; set; }
    public string UsuarioPacienteTipo { get; set; }


    public decimal Valor { get; set; }
    public DateTime DataHora { get; set; }
    public string Observacao { get; set; }
}




