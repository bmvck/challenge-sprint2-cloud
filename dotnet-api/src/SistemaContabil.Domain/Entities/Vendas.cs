using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaContabil.Domain.Entities;

/// <summary>
/// Entidade que representa uma Venda no sistema
/// </summary>
public class Vendas
{
    /// <summary>
    /// Identificador único da venda
    /// </summary>
    [Key]
    public int IdVendas { get; set; }

    /// <summary>
    /// Identificador do cliente associado
    /// </summary>
    [Required]
    public int ClienteIdCliente { get; set; }

    /// <summary>
    /// Identificador do registro contábil associado
    /// </summary>
    [Required]
    public int RegContIdRegCont { get; set; }

    /// <summary>
    /// Identificador do evento de venda (nullable)
    /// </summary>
    public long? VendaEventoIdEvento { get; set; }

    /// <summary>
    /// Cliente associado à venda
    /// </summary>
    [ForeignKey(nameof(ClienteIdCliente))]
    public virtual Cliente Cliente { get; set; } = null!;

    /// <summary>
    /// Registro contábil associado à venda
    /// </summary>
    [ForeignKey(nameof(RegContIdRegCont))]
    public virtual RegistroContabil RegistroContabil { get; set; } = null!;

    /// <summary>
    /// Valida se a venda está válida para operações
    /// </summary>
    /// <returns>True se válido, False caso contrário</returns>
    public bool IsValid()
    {
        return ClienteIdCliente > 0 && RegContIdRegCont > 0;
    }
}
