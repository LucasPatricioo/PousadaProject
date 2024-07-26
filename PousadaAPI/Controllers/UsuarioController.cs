using System;
using Microsoft.AspNetCore.Mvc;
using PousadaAPI.Data.DTO.Usuario;
using PousadaAPI.Exceptions;
using PousadaAPI.Interfaces;

namespace Controllers;

[ApiController]
[Route("v1/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("NovoUsuario")]
    public IActionResult NovoUsuario([FromBody] CreateUsuarioDTO usuario)
    {
        try
        {
            _usuarioService.InserirUsuario(usuario);
            return Ok("Novo usuário criado com sucesso!");
        }
        catch (UsuarioException uex)
        {
            return BadRequest(uex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("AtualizarUsuario")]
    public IActionResult AtualizarUsuario([FromBody] UpdateUsuarioDTO usuario)
    {
        try
        {
            _usuarioService.AtualizarUsuario(usuario);
            return Ok("Usuário atualizado com sucesso!");
        }
        catch (UsuarioException uex)
        {
            return BadRequest(uex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("BuscarUsuarios")]
    public IActionResult BuscarUsuarios()
    {
        try
        {
            return Ok(_usuarioService.BuscarUsuarios());
        }
        catch (UsuarioNaoEncontradoException)
        {
            return NoContent();
        }
        catch (UsuarioException uex)
        {
            return BadRequest(uex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("BuscarUsuarioPorId/{id}")]
    public IActionResult BuscarUsuarioPorId(int id)
    {
        try
        {
            return Ok(_usuarioService.BuscarUsuarioPorId(id));
        }
        catch (UsuarioNaoEncontradoException)
        {
            return NoContent();
        }
        catch (UsuarioException uex)
        {
            return BadRequest(uex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("DeletarUsuario/{id}")]
    public IActionResult DeletarUsuario(int id)
    {
        try
        {
            _usuarioService.DeletarUsuario(id);
            return Ok("Usuário deletado com sucesso!");
        }
        catch (UsuarioNaoEncontradoException uex)
        {
            return BadRequest(uex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}