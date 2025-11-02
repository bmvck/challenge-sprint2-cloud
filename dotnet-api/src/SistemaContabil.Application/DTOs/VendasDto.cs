namespace SistemaContabil.Application.DTOs;

/// <summary>
/// DTO para Vendas
/// </summary>
public class VendasDto
{
    /// <summary>
    /// Identificador único da venda
    /// </summary>
    public int IdVendas { get; set; }

    /// <summary>
    /// ID do cliente
    /// </summary>
    public int ClienteIdCliente { get; set; }

    /// <summary>
    /// Nome do cliente
    /// </summary>
    public string NomeCliente { get; set; } = string.Empty;

    /// <summary>
    /// ID do registro contábil
    /// </summary>
    public int RegContIdRegCont { get; set; }

    /// <summary>
    /// Valor do registro contábil
    /// </summary>
    public decimal Valor { get; set; }

    /// <summary>
    /// ID do evento de venda (opcional)
    /// </summary>
    public long? VendaEventoIdEvento { get; set; }
}

/// <summary>
/// DTO para criação de Vendas
/// </summary>
public class CriarVendasDto
{
    /// <summary>
    /// ID do cliente
    /// </summary>
    public int ClienteIdCliente { get; set; }

    /// <summary>
    /// ID do registro contábil
    /// </summary>
    public int RegContIdRegCont { get; set; }

    /// <summary>
    /// ID do evento de venda (opcional)
    /// </summary>
    public long? VendaEventoIdEvento { get; set; }
}

/// <summary>
/// DTO para atualização de Vendas
/// </summary>
public class AtualizarVendasDto
{
    /// <summary>
    /// ID do cliente
    /// </summary>
    public int ClienteIdCliente { get; set; }

    /// <summary>
    /// ID do registro contábil
    /// </summary>
    public int RegContIdRegCont { get; set; }

    /// <summary>
    /// ID do evento de venda (opcional)
    /// </summary>
    public long? VendaEventoIdEvento { get; set; }
}
