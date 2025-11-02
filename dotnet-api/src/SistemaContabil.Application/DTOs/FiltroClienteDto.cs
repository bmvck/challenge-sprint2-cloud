namespace SistemaContabil.Application.DTOs;

/// <summary>
/// DTO para filtros de busca de Clientes
/// </summary>
public class FiltroClienteDto : SearchRequestDto
{
    /// <summary>
    /// Nome do cliente (busca parcial)
    /// </summary>
    public string? Nome { get; set; }

    /// <summary>
    /// CPF ou CNPJ do cliente (busca exata)
    /// </summary>
    public string? CpfCnpj { get; set; }

    /// <summary>
    /// Status ativo (S/N)
    /// </summary>
    public char? Ativo { get; set; }

    /// <summary>
    /// Email do cliente (busca parcial)
    /// </summary>
    public string? Email { get; set; }
}
