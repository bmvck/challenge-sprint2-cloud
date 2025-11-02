namespace SistemaContabil.Application.DTOs;

/// <summary>
/// DTO genérico para resultados paginados
/// </summary>
/// <typeparam name="T">Tipo dos itens da lista</typeparam>
public class PagedResultDto<T>
{
    /// <summary>
    /// Itens da página atual
    /// </summary>
    public IEnumerable<T> Items { get; set; } = new List<T>();

    /// <summary>
    /// Número da página atual (baseado em 1)
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Tamanho da página
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Total de itens disponíveis
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Total de páginas
    /// </summary>
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    /// <summary>
    /// Indica se existe página anterior
    /// </summary>
    public bool HasPreviousPage => Page > 1;

    /// <summary>
    /// Indica se existe próxima página
    /// </summary>
    public bool HasNextPage => Page < TotalPages;

    /// <summary>
    /// Links HATEOAS para navegação
    /// </summary>
    public Dictionary<string, string> Links { get; set; } = new();
}
