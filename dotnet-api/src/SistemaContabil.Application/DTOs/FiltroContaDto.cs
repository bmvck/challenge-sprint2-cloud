namespace SistemaContabil.Application.DTOs;

/// <summary>
/// DTO para filtros de busca de Contas Contábeis
/// </summary>
public class FiltroContaDto : SearchRequestDto
{
    /// <summary>
    /// Nome da conta contábil (busca parcial)
    /// </summary>
    public string? Nome { get; set; }

    /// <summary>
    /// Tipo da conta (R = Receita, D = Despesa)
    /// </summary>
    public char? Tipo { get; set; }

    /// <summary>
    /// ID do cliente associado
    /// </summary>
    public int? ClienteId { get; set; }
}
