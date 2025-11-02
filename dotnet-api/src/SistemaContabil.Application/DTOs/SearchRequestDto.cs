namespace SistemaContabil.Application.DTOs;

/// <summary>
/// DTO para solicitação de busca com paginação e ordenação
/// </summary>
public class SearchRequestDto
{
    /// <summary>
    /// Número da página (baseado em 1, padrão: 1)
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// Tamanho da página (padrão: 10, máximo: 100)
    /// </summary>
    public int PageSize { get; set; } = 10;

    /// <summary>
    /// Campo para ordenação
    /// </summary>
    public string? SortBy { get; set; }

    /// <summary>
    /// Direção da ordenação (asc ou desc, padrão: asc)
    /// </summary>
    public string SortOrder { get; set; } = "asc";

    /// <summary>
    /// Valida e ajusta os parâmetros de busca
    /// </summary>
    public void Validate()
    {
        if (Page < 1)
            Page = 1;

        if (PageSize < 1)
            PageSize = 10;

        if (PageSize > 100)
            PageSize = 100;

        if (string.IsNullOrWhiteSpace(SortOrder))
            SortOrder = "asc";

        SortOrder = SortOrder.ToLowerInvariant();
        if (SortOrder != "asc" && SortOrder != "desc")
            SortOrder = "asc";
    }

    /// <summary>
    /// Retorna se a ordenação é descendente
    /// </summary>
    public bool IsDescending => SortOrder?.ToLowerInvariant() == "desc";
}
