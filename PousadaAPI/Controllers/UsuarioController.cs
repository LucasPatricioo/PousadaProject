using System;
using Microsoft.AspNetCore.Mvc;
using PousadaAPI.Data.DTO;
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
            _usuarioService.NovoUsuario(usuario);
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
}