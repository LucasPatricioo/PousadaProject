using System;
using Microsoft.AspNetCore.Mvc;
using PousadaAPI.Interfaces;

namespace Controllers;

[ApiController]
[Route("v1/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioDAO _usuarioContext;

    public UsuarioController(IUsuarioDAO usuarioDAO)
    {
        _usuarioContext = usuarioDAO;
    }

    [HttpPost("NovoUsuario")]
    public IActionResult NovoUsuario([FromBody] Models.Usuario usuario)
    {
        _usuarioContext.InserirUsuario(usuario);
        return Ok("Novo usuário criado com sucesso!");
    }
}