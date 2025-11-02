namespace SistemaContabil.Application.DTOs;

/// <summary>
/// DTO para filtros de busca de Registros Contábeis
/// </summary>
public class FiltroRegistroContabilDto : SearchRequestDto
{
    /// <summary>
    /// Valor mínimo do registro
    /// </summary>
    public decimal? ValorMin { get; set; }

    /// <summary>
    /// Valor máximo do registro
    /// </summary>
    public decimal? ValorMax { get; set; }

    /// <summary>
    /// ID da conta contábil
    /// </summary>
    public int? ContaId { get; set; }

    /// <summary>
    /// ID do centro de custo
    /// </summary>
    public int? CentroCustoId { get; set; }

    /// <summary>
    /// Data de criação inicial (inclusive)
    /// </summary>
    public DateTime? DataInicio { get; set; }

    /// <summary>
    /// Data de criação final (inclusive)
    /// </summary>
    public DateTime? DataFim { get; set; }
}
