namespace SistemaContabil.Application.DTOs;

/// <summary>
/// DTO para filtros de busca de Vendas
/// </summary>
public class FiltroVendasDto : SearchRequestDto
{
    /// <summary>
    /// ID do cliente
    /// </summary>
    public int? ClienteId { get; set; }

    /// <summary>
    /// ID do registro contábil
    /// </summary>
    public int? RegContId { get; set; }

    /// <summary>
    /// ID do evento de venda
    /// </summary>
    public long? VendaEventoId { get; set; }
}
