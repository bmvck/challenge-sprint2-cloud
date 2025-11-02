using Microsoft.AspNetCore.Mvc;
using SistemaContabil.Application.DTOs;
using SistemaContabil.Application.Services;

namespace SistemaContabil.Web.Controllers;

/// <summary>
/// Controller para operações de Conta
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ContaController : ControllerBase
{
    private readonly IContaAppService _contaService;
    private readonly ILogger<ContaController> _logger;

    public ContaController(IContaAppService contaService, ILogger<ContaController> logger)
    {
        _contaService = contaService;
        _logger = logger;
    }

    /// <summary>
    /// Obtém todas as contas
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContaDto>>> ObterTodos()
    {
        try
        {
            var contas = await _contaService.ObterTodasAsync();
            return Ok(contas);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter contas");
            return StatusCode(500, "Erro interno do servidor");
        }
    }

    /// <summary>
    /// Obtém uma conta por ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ContaDto>> ObterPorId(int id)
    {
        try
        {
            var conta = await _contaService.ObterPorIdAsync(id);
            if (conta == null)
                return NotFound($"Conta com ID {id} não encontrada");

            return Ok(conta);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter conta {Id}", id);
            return StatusCode(500, "Erro interno do servidor");
        }
    }

    /// <summary>
    /// Cria uma nova conta
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ContaDto>> Criar([FromBody] CriarContaDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var conta = await _contaService.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = conta.IdContaContabil }, conta);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Dados inválidos para criação de conta");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar conta");
            return StatusCode(500, "Erro interno do servidor");
        }
    }

    /// <summary>
    /// Atualiza uma conta existente
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult<ContaDto>> Atualizar(int id, [FromBody] AtualizarContaDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var conta = await _contaService.AtualizarAsync(id, dto);
            return Ok(conta);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Dados inválidos para atualização de conta {Id}", id);
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Conta {Id} não encontrada", id);
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar conta {Id}", id);
            return StatusCode(500, "Erro interno do servidor");
        }
    }

    /// <summary>
    /// Remove uma conta
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Remover(int id)
    {
        try
        {
            var removida = await _contaService.RemoverAsync(id);
            if (!removida)
                return NotFound($"Conta com ID {id} não encontrada");

            return Ok(new { message = "Conta removida com sucesso" });
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "Conta {Id} não pode ser removida", id);
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao remover conta {Id}", id);
            return StatusCode(500, "Erro interno do servidor");
        }
    }
}