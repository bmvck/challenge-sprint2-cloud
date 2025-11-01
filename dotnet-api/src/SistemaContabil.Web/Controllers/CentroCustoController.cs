using Microsoft.AspNetCore.Mvc;
using SistemaContabil.Application.DTOs;
using SistemaContabil.Application.Services;

namespace SistemaContabil.Web.Controllers;

/// <summary>
/// Controller para operações de Centro de Custo
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CentroCustoController : ControllerBase
{
    private readonly ICentroCustoAppService _centroCustoService;
    private readonly ILogger<CentroCustoController> _logger;

    public CentroCustoController(ICentroCustoAppService centroCustoService, ILogger<CentroCustoController> logger)
    {
        _centroCustoService = centroCustoService;
        _logger = logger;
    }

    /// <summary>
    /// Obtém todos os centros de custo
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CentroCustoDto>>> ObterTodos()
    {
        try
        {
            var centrosCusto = await _centroCustoService.ObterTodosAsync();
            return Ok(centrosCusto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter centros de custo");
            return StatusCode(500, "Erro interno do servidor");
        }
    }

    /// <summary>
    /// Obtém um centro de custo por ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<CentroCustoDto>> ObterPorId(int id)
    {
        try
        {
            var centroCusto = await _centroCustoService.ObterPorIdAsync(id);
            if (centroCusto == null)
                return NotFound($"Centro de custo com ID {id} não encontrado");

            return Ok(centroCusto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter centro de custo {Id}", id);
            return StatusCode(500, "Erro interno do servidor");
        }
    }

    /// <summary>
    /// Cria um novo centro de custo
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<CentroCustoDto>> Criar([FromBody] CriarCentroCustoDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var centroCusto = await _centroCustoService.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = centroCusto.IdCentroCusto }, centroCusto);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Dados inválidos para criação de centro de custo");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar centro de custo");
            return StatusCode(500, "Erro interno do servidor");
        }
    }

    /// <summary>
    /// Atualiza um centro de custo existente
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<CentroCustoDto>> Atualizar(int id, [FromBody] AtualizarCentroCustoDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var centroCusto = await _centroCustoService.AtualizarAsync(id, dto);
            return Ok(centroCusto);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Dados inválidos para atualização de centro de custo {Id}", id);
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Centro de custo {Id} não encontrado", id);
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar centro de custo {Id}", id);
            return StatusCode(500, "Erro interno do servidor");
        }
    }

    /// <summary>
    /// Remove um centro de custo
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Remover(int id)
    {
        try
        {
            var removido = await _centroCustoService.RemoverAsync(id);
            if (!removido)
                return NotFound($"Centro de custo com ID {id} não encontrado");

            return Ok(new { message = "Centro de custo removido com sucesso" });
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Centro de custo {Id} não pode ser removido", id);
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao remover centro de custo {Id}", id);
            return StatusCode(500, "Erro interno do servidor");
        }
    }
}