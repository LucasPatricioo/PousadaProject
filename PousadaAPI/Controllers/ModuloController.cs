using Microsoft.AspNetCore.Mvc;
using PousadaAPI.Data.DTO.Modulo;
using PousadaAPI.Interfaces;

namespace PousadaAPI.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class ModuloController : ControllerBase
{
    private readonly IModuloService _moduloService;

    public ModuloController(IModuloService moduloService)
    {
        _moduloService = moduloService;
    }

    [HttpPost("NovoModulo")]
    public IActionResult InserirModulo([FromBody] CreateModuloDTO modulo)
    {
        try
        {
            _moduloService.InserirModulo(modulo);
            return Ok("Novo módulo criado com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public IActionResult AtualizarModulo([FromBody] UpdateModuloDTO modulo)
    {
        _moduloService.AtualizarModulo(modulo);
        return Ok();
    }

    [HttpGet]
    public IActionResult BuscarModulos()
    {
        var modulos = _moduloService.BuscarModulos();
        return Ok(modulos);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarModuloPorId(int id)
    {
        var modulo = _moduloService.BuscarModuloPorId(id);
        return Ok(modulo);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarModulo(int id)
    {
        _moduloService.DeletarModulo(id);
        return Ok();
    }
}
