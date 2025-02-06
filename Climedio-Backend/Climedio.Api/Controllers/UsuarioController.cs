using Climedio.Api.Models.Usuarios.Request;
using Climedio.Api.Models.Usuarios.Response;
using Climedio.Aplicacao;
using Climedio.Dominio.Entidades;
using Climedio.Dominio.Enumeradores;
using Microsoft.AspNetCore.Mvc;

namespace Climedio.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioAplicacao _usuarioAplicacao;

    public UsuarioController(IUsuarioAplicacao usuarioAplicacao)
    {
        _usuarioAplicacao = usuarioAplicacao;
    }

    [HttpPost]
    [Route("Adicionar")]
    public async Task<IActionResult> Adicionar([FromBody] UsuarioCriarRequest usuarioCriarRequest)
    {
        try
        {
            Usuario usuario = new Usuario(
            usuarioCriarRequest.Nome,
            usuarioCriarRequest.Email,
            DateOnly.FromDateTime(usuarioCriarRequest.DataNascimento),
            usuarioCriarRequest.Senha
        )
            {
                Cpf = usuarioCriarRequest.Cpf,
                NomeSocial = usuarioCriarRequest.NomeSocial,
                Telefone = usuarioCriarRequest.Telefone,
                Endereco = usuarioCriarRequest.Endereco,
                TipoUsuarioId = usuarioCriarRequest.TipoUsuario,
                Ativo = true
            };
            await _usuarioAplicacao.Criar(usuario);

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
            await _usuarioAplicacao.Remover(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("Atualizar")]
    public async Task<IActionResult> AtualizarSenha([FromBody] UsuarioAtualizarSenhaRequest usuario)
    {
        try
        {
            await _usuarioAplicacao.AtualizarSenha(usuario.Id, usuario.SenhaAntiga, usuario.SenhaNova);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("VerificarLogin")]
    public async Task<IActionResult> VerificarLogin([FromBody] UsuarioRequest usuarioRequest)
    {
        try
        {
            int id = await _usuarioAplicacao.ValidarLogin(usuarioRequest.Email, usuarioRequest.Senha);

            return Ok(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("Obter/{usuarioId}")]
    public async Task<IActionResult> ObterUsuarioAsync([FromRoute] int usuarioId)
    {
        try
        {
            Usuario usuario = await _usuarioAplicacao.ObterUsuario(usuarioId);

            var usuarioAtualizar = new UsuarioAtualizarRequest(){
                Nome = usuario.Nome,
                Email = usuario.Email,
                Cpf = usuario.Cpf,
                NomeSocial = usuario.NomeSocial,
                Telefone = usuario.Telefone,
                Endereco = usuario.Endereco,
                TipoUsuarioId = usuario.TipoUsuarioId
            };

            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("ListarUsuarios")]
    public async Task<IActionResult> ListarUsuarios()
    {
        try
        {
            var usuarios = await _usuarioAplicacao.ListarUsuarios();

            var usuariosResponse = usuarios.Select(usuario => new ListarUsuariosResponse
            {
                UsuarioId = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                TipoUsuario = usuario.TipoUsuarioId.ToString()
            }).ToList();

            return Ok(usuariosResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("ListarUsuariosPacientes")]
    public async Task<IActionResult> ListarPacientes()
    {
        try
        {
            var usuarios = await _usuarioAplicacao.ListarPacientes(true);

            var usuariosResponse = usuarios.Select(usuario => new ListarUsuariosResponse
            {
                UsuarioId = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                TipoUsuario = usuario.TipoUsuarioId.ToString()
            }).ToList();
            return Ok(usuariosResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("ListarUsuariosProfissional")]
    public async Task<IActionResult> ListarProfissionais()
    {
        try
        {
            var usuarios = await _usuarioAplicacao.ListarProfissionais(true);

            var usuariosResponse = usuarios.Select(usuario => new ListarUsuariosResponse
            {
                UsuarioId = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                TipoUsuario = usuario.TipoUsuarioId.ToString()
            }).ToList();
            return Ok(usuariosResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("ListarTiposUsuario")]
    public IActionResult ListarTiposUsuario()
    {
        try
        {
            var tiposUsuario = Enum.GetValues(typeof(TipoUsuario))
                                .Cast<TipoUsuario>()
                                .Select(tipo => new
                                {
                                    Key = (int)tipo,
                                    Value = tipo.ToString()
                                })
                                .ToList();

            return Ok(tiposUsuario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("AtualizarInformacoes")]
    public async Task<IActionResult> AtualizarInformacoes([FromBody] UsuarioAtualizarRequest usuarioAtualizar)
    {
        try
        {
            var usuario = new Usuario(usuarioAtualizar.Nome)
            {
                Id = usuarioAtualizar.Id,
                Email = usuarioAtualizar.Email,
                Cpf = usuarioAtualizar.Cpf,
                Telefone = usuarioAtualizar.Telefone,
                Endereco = usuarioAtualizar.Endereco,
                NomeSocial = usuarioAtualizar.NomeSocial,
                TipoUsuarioId = usuarioAtualizar.TipoUsuarioId
            };

            await _usuarioAplicacao.AtualizarInformacoes(usuario);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}