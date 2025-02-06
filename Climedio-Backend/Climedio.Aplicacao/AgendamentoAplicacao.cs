using Climedio.Repositorio;
using Climedio.Dominio.Entidades;

namespace Climedio.Aplicacao;
public class AgendamentoAplicacao : IAgendamentoAplicacao
{
    private readonly IAgendamentoRepositorio _agendamentoRepositorio;

    public AgendamentoAplicacao(IAgendamentoRepositorio agendamentoRepositorio)
    {
        _agendamentoRepositorio = agendamentoRepositorio;
    }

    public async Task Atualizar(DateTime DataHora, string observacao, decimal valor,
    int UsuarioIdProfissional, int UsuarioIdPaciente)
    {
        Agendamento agendamento = await _agendamentoRepositorio.ObterPorId(UsuarioIdProfissional);
        _ = await _agendamentoRepositorio.ObterPorId(UsuarioIdPaciente);

        if (agendamento == null)
        {
            throw new Exception("O Agendamento não foi encontrado.");
        }

        agendamento.DataHora = DataHora;
        agendamento.Observacao = observacao;
        agendamento.Valor = valor;
        agendamento.UsuarioIdProfissional = UsuarioIdProfissional;
        agendamento.UsuarioIdPaciente = UsuarioIdPaciente;


        VerificarAgendamento(agendamento);

        await _agendamentoRepositorio.Atualizar(agendamento);
    }

    public async Task Criar(Agendamento agendamento)
    {
        VerificarAgendamento(agendamento);

        await _agendamentoRepositorio.Salvar(agendamento);
    }

    public async Task<IEnumerable<Agendamento>>ListarTodosAgendamentos(bool ativo)
    {
        var listaAgendamentos = await _agendamentoRepositorio.ListarTodosAgendamentos(ativo);
        
        if (listaAgendamentos.Count() == 0)
        {
            throw new Exception("Nenhum Agendamento foi encontrado.");
        }

        return listaAgendamentos;
    }

    public async Task Remover(int id)
    {
        var agendamento = await _agendamentoRepositorio.ObterPorId(id);

        if (agendamento == null)
        {
            throw new Exception("O Agendamento não foi encontrado.");
        }

        agendamento.Ativo = false;

        await _agendamentoRepositorio.Atualizar(agendamento);
    }



    public void VerificarAgendamento(Agendamento agendamento)
    {
        if (agendamento == null)
        {
            throw new Exception("O agendamento não pode ser vazio.");
        }

        if (agendamento.Valor <= 0)
        {
            throw new Exception("O valor da consulta não pode ser negativo.");
        }

        if (agendamento.UsuarioIdPaciente < 0)
        {
            throw new Exception("O Paciente não pode ser vazio.");
        }

        if (agendamento.UsuarioIdProfissional < 0)
        {
            throw new Exception("O Profissional não pode ser vazio.");
        }
    }
}