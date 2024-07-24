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

    [HttpPost]
    public IActionResult InserirModulo([FromBody] CreateModuloDTO modulo)
    {
        _moduloService.InserirModulo(modulo);
        return Ok();
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
