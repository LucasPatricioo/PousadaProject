using Microsoft.AspNetCore.Mvc;
using PousadaAPI.Data.DTO.Modulo;
using PousadaAPI.Exceptions;
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
        catch (ModuloException mex)
        {
            return BadRequest(mex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("AtualizarModulo")]
    public IActionResult AtualizarModulo([FromBody] UpdateModuloDTO modulo)
    {
        try
        {
            _moduloService.AtualizarModulo(modulo);
            return Ok("Módulo atualizado com sucesso!");
        }
        catch (ModuloException mex)
        {
            return BadRequest(mex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("BuscarModulos")]
    public IActionResult BuscarModulos()
    {
        try
        {
            var modulos = _moduloService.BuscarModulos();
            return Ok(modulos);
        }
        catch (ModuloNaoEncontradoException)
        {
            return NoContent();
        }
        catch (ModuloException mex)
        {
            return BadRequest(mex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("BuscarModuloPorId")]
    public IActionResult BuscarModuloPorId([FromQuery] int id)
    {
        try
        {
            var modulo = _moduloService.BuscarModuloPorId(id);
            return Ok(modulo);
        }
        catch (ModuloNaoEncontradoException)
        {
            return NoContent();
        }
        catch (ModuloException mex)
        {
            return BadRequest(mex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("DeletarModulo")]
    public IActionResult DeletarModulo([FromQuery] int id)
    {
        try
        {
            _moduloService.DeletarModulo(id);
            return Ok("Módulo deletado com sucesso!");
        }
        catch (ModuloException mex)
        {
            return BadRequest(mex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
