namespace SistemaContabil.Application.DTOs;

/// <summary>
/// DTO para filtros de busca de Centros de Custo
/// </summary>
public class FiltroCentroCustoDto : SearchRequestDto
{
    /// <summary>
    /// Nome do centro de custo (busca parcial)
    /// </summary>
    public string? Nome { get; set; }
}
