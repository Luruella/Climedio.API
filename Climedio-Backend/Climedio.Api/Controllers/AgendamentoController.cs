using Climedio.Api.Models.Agendamento.Request;
using Climedio.Api.Models.Agendamento.Response;
using Climedio.Aplicacao;
using Climedio.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Climedio.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AgendamentoController : ControllerBase
{
    private readonly IAgendamentoAplicacao _agendamentoAplicacao;

    public AgendamentoController(IAgendamentoAplicacao agendamentoAplicacao)
    {
        _agendamentoAplicacao = agendamentoAplicacao;
    }

    [HttpPost]
    [Route("Adicionar")]
    public async Task<IActionResult> Adicionar([FromBody] AdicionarAgendamentoRequest agendamentoRequest)
    {
        try
        {
            Agendamento agendamento = new Agendamento()
            {
                DataHora = agendamentoRequest.DataHora,
                Observacao = agendamentoRequest.Observacao,
                Valor = agendamentoRequest.Valor,
                UsuarioIdProfissional = agendamentoRequest.UsuarioIdProfissional,
                UsuarioIdPaciente = agendamentoRequest.UsuarioIdPaciente
            };

            await _agendamentoAplicacao.Criar(agendamento);

            return Ok();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("Atualizar")]
    public async Task<IActionResult> Atualizar([FromBody] AtualizarAgendamentoRequest agendamentoRequest)
    {
        try
        {
            await _agendamentoAplicacao.Atualizar(agendamentoRequest.Data_hora, agendamentoRequest.Observacao,
            agendamentoRequest.Valor, agendamentoRequest.UsuarioIdProfissional, agendamentoRequest.UsuarioIdPaciente);


            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("Remover/{id}")]
    public async Task<IActionResult> Remover([FromRoute] int id)
    {
        try
        {
            await _agendamentoAplicacao.Remover(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("Listar/{id}")]
    public async Task<IActionResult> Listar([FromRoute] int id, [FromQuery] bool ativo)
    {
        try
        {
            var listarAgendamentos = await _agendamentoAplicacao.Listar(id, ativo);

            List<ListarAgendamentoResponse> listaFinal = listarAgendamentos.Select
            (x => new ListarAgendamentoResponse()
            {
                Id = x.Id,
                UsuarioIdProfissional = x.UsuarioIdProfissional,
                UsuarioIdPaciente = x.UsuarioIdPaciente,
                Valor = x.Valor,
                Data_hora = x.DataHora,
                Observacao = x.Observacao,


            }).ToList();



            return Ok(listaFinal);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // [HttpGet]
    // [Route("ObterPorUsuarioId/{usuarioId}")]
    // public async Task<IActionResult> Listar([FromRoute] int usuarioId)
    // {
    //     try
    //     {
    //         var listaAgendamentos = await _agendamentoAplicacao.ObterAgendamentosPorUsuarioId(usuarioId);

    //         List<ListarAgendamentoResponse> listaFinal = listaAgendamentos.Select(x => new ListarAgendamentoResponse()
    //         {
    //             Id = x.Id,
    //             UsuarioIdProfissional = x.UsuarioIdProfissional,
    //             UsuarioIdPaciente = x.UsuarioIdPaciente,
    //             Valor = x.Valor,
    //             Data_hora = x.DataHora,
    //             Observacao = x.Observacao,

    //         }).ToList();

    //         return Ok(listaFinal);
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest(ex.Message);
    //     }
    // }
}