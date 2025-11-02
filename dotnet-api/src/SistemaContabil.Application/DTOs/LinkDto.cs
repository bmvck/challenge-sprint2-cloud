namespace SistemaContabil.Application.DTOs;

/// <summary>
/// DTO para links HATEOAS
/// </summary>
public class LinkDto
{
    /// <summary>
    /// Relação do link (self, create, update, delete, search, etc)
    /// </summary>
    public string Rel { get; set; } = string.Empty;

    /// <summary>
    /// URL do link
    /// </summary>
    public string Href { get; set; } = string.Empty;

    /// <summary>
    /// Método HTTP do link
    /// </summary>
    public string Method { get; set; } = "GET";

    /// <summary>
    /// Cria um novo link
    /// </summary>
    public LinkDto(string rel, string href, string method = "GET")
    {
        Rel = rel;
        Href = href;
        Method = method;
    }
}
