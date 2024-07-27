using Microsoft.AspNetCore.Mvc;
using PousadaAPI.Data.DTO.Permissoes;
using PousadaAPI.Exceptions;
using PousadaAPI.Interfaces;

namespace PousadaAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PermissaoController : ControllerBase
    {
        private readonly IPermissaoService _permissaoService;

        public PermissaoController(IPermissaoService permissaoService)
        {
            _permissaoService = permissaoService;
        }

        [HttpPost("NovaPermissao")]
        public IActionResult InserirPermissao([FromBody] CreatePermissaoDTO permissao)
        {
            try
            {
                _permissaoService.InserirPermissao(permissao);
                return Ok("Nova permissão criada com sucesso!");
            }
            catch (PermissaoException pex)
            {
                return BadRequest(pex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("AtualizarPermissao")]
        public IActionResult AtualizarPermissao([FromBody] UpdatePermissaoDTO permissao)
        {
            try
            {
                _permissaoService.AtualizarPermissao(permissao);
                return Ok("Permissão atualizada com sucesso!");
            }
            catch (PermissaoException pex)
            {
                return BadRequest(pex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("BuscarPermissoes")]
        public IActionResult BuscarPermissoes()
        {
            try
            {
                var permissoes = _permissaoService.BuscarPermissoes();
                return Ok(permissoes);
            }
            catch (PermissaoNaoEncontradaException)
            {
                return NoContent();
            }
            catch (PermissaoException pex)
            {
                return BadRequest(pex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("BuscarPermissoesPorIdUsuario")]
        public IActionResult BuscarPermissoesPorIdUsuario([FromQuery] int idUsuario)
        {
            try
            {
                var permissoes = _permissaoService.BuscarPermissoesPorIdUsuario(idUsuario);
                return Ok(permissoes);
            }
            catch (PermissaoNaoEncontradaException)
            {
                return NoContent();
            }
            catch (PermissaoException pex)
            {
                return BadRequest(pex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("BuscarPermissaoPorId")]
        public IActionResult BuscarPermissaoPorId([FromQuery] int id)
        {
            try
            {
                var permissao = _permissaoService.BuscarPermissaoPorId(id);
                return Ok(permissao);
            }
            catch (PermissaoNaoEncontradaException)
            {
                return NoContent();
            }
            catch (PermissaoException pex)
            {
                return BadRequest(pex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeletarPermissao")]
        public IActionResult DeletarPermissao([FromQuery] int id)
        {
            try
            {
                _permissaoService.DeletarPermissao(id);
                return Ok("Permissão deletada com sucesso!");
            }
            catch (PermissaoException pex)
            {
                return BadRequest(pex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
